using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA_Mission_Editor.Renderers
{
  public delegate void LayerUpdatedDelegate(MapCanvas.LayerType layerType);
  public delegate void MapUpdatedDelegate();

  public class MapCanvas
  {
    private struct TimeKeeper : IDisposable
    {
      private string _caption;
      private Stopwatch _stopwatch;
      public TimeKeeper(Stopwatch stopwatch, string caption)
      {
        _caption = caption;
        _stopwatch = stopwatch;
        _stopwatch.Restart();
      }

      public void Dispose()
      {
        Console.Out.WriteLine($"{_caption}: {_stopwatch.ElapsedMilliseconds} ms");
      }
    }

    // Note to self: it is much faster to redraw all objects into one Bitmap layer than to draw them on layers (allow less object redraws). and recompose them into a single layer.
    // Difference is about 600ms to ~120ms
    // Approximate benchmark for a full draw onto Image
    //    DrawTemplates: 127 ms
    //    DrawBaseBibs: 1 ms
    //    DrawStructureBibs: 2 ms
    //    DrawOverlays: 5 ms
    //    DrawSmudges: 0 ms
    //    DrawTerrain: 9 ms
    //    DrawBases: 0 ms
    //    DrawStructures: 4 ms
    //    DrawUnits: 3 ms
    //    DrawShips: 0 ms
    //    DrawInfantries: 6 ms
    //    DrawCellTriggers: 4 ms
    //    DrawWaypoints: 1 ms
    //    DrawBounds: 0 ms
    //    DrawGrid: 8 ms
    //
    // It would be a benefit to compose only the Template layer as a separate image
    //    PaintTemplate: 34 ms
    // Painting a full layer over Image costs about 40ms, so it is only worth it to paint a separate layer if this layer cost more than that, even if the layer is static, like the grid.


    public Bitmap Image;
    private Bitmap ImagePreplaced;
    private Bitmap ImageNoPreplaced;
    private Bitmap TemplateImage;

    public enum LayerType
    {
      Templates,
      Template_SingleColor,
      //BaseBibs, // combined with Bases
      //StructureBibs,  // combined with Structures
      Overlays,
      Smudges,
      Terrain,
      // Technotypes
      Bases,
      Structures,
      Units,
      Ships,
      Infantry,
      // Widgets
      CellTriggers,
      Waypoints,
      // Editor helpers
      Grid,
      Bounds,
      Selection,
      //Comment,
      //UserActive,
      //PreplaceTemplateEntity,
      PreplaceEntity,
      COUNT
    }

    private readonly bool[] Visible = new bool[(int)LayerType.COUNT];
    private Stopwatch _stopwatch = new Stopwatch();
    private Stopwatch _ostopwatch = new Stopwatch();
    private bool _suspend = false;
    private bool _dirty = false;
    private bool _preplaceDirty = false;
    private bool _templateDirty = false;
    private bool _pleplacedHighlight = false;
    private Timer _timer = new Timer();

    public bool SuspendDrawing { get { return _suspend; } set { if (_suspend != value) { _suspend = value; if (!_suspend) { MapDirtied?.Invoke(); } } } }
    public bool Dirty { get { return _dirty; } private set { if (_dirty != value) { _dirty = value; if (_dirty) { MapDirtied?.Invoke(); } } } }
    public bool PreplaceDirty { get { return _preplaceDirty; } private set { if (_preplaceDirty != value) { _preplaceDirty = value; if (_preplaceDirty) { MapDirtied?.Invoke(); } } } }
    public bool TemplateDirty { get { return _templateDirty; } private set { if (_templateDirty != value) { _templateDirty = value; if (_templateDirty) { MapDirtied?.Invoke(); } } } }
    public MapUpdatedDelegate MapUpdated;
    public MapUpdatedDelegate MapDirtied;

    public bool AnyDirty { get { return _dirty || _preplaceDirty || _templateDirty; } }

    public void SetVisible(LayerType ltype, bool visibility)
    {
      if (Visible[(int)ltype] != visibility)
      {
        Visible[(int)ltype] = visibility;
        switch (ltype)
        {
          case LayerType.Templates:
          case LayerType.Template_SingleColor:
            TemplateDirty = true;
            break;
          case LayerType.PreplaceEntity:
            PreplaceDirty = true;
            break;
          //case LayerType.PreplaceTemplateEntity:
          default:
            Dirty = true;
            break;
        }
      }
    }

    public void SetDirty()
    {
      Dirty = true;
    }

    public void SetPreplaceDirty()
    {
      PreplaceDirty = true;
    }

    public void TimerSetDirty(object sender, EventArgs e)
    {
      PreplaceDirty = true;
      _pleplacedHighlight = !_pleplacedHighlight;
    }

    public void SetTemplateDirty()
    {
      TemplateDirty = true;
    }

    public MapCanvas()
    {
      // one time init
      for (int i = 0; i < (int)LayerType.COUNT; i++)
      {
        Visible[i] = true;
      }
      Visible[(int)LayerType.Template_SingleColor] = false;
      Reset();
      _timer.Enabled = false;
      _timer.Interval = 500;
      _timer.Tick += TimerSetDirty; 
     }

    public void Reset(Map map = null)
    {
      int width = Constants.CELL_PIXEL_W * Constants.MAP_CELL_W;
      int height = Constants.CELL_PIXEL_H * Constants.MAP_CELL_H;
      if (map != null && map.Ext_MapSection.FullWidth > 0 && map.Ext_MapSection.FullHeight > 0)
      {
        width = map.Ext_MapSection.FullWidth * Constants.CELL_PIXEL_W;
        height = map.Ext_MapSection.FullHeight * Constants.CELL_PIXEL_H;
      }

      if (ImagePreplaced == null || ImagePreplaced.Size != new Size(width, height))
      {
        ImagePreplaced?.Dispose();
        ImagePreplaced = new Bitmap(width, height);
      }

      if (ImageNoPreplaced == null || ImageNoPreplaced.Size != new Size(width, height))
      {
        ImageNoPreplaced?.Dispose();
        ImageNoPreplaced = new Bitmap(width, height);
      }

      if (TemplateImage == null || TemplateImage.Size != new Size(width, height))
      {
        TemplateImage?.Dispose();
        TemplateImage = new Bitmap(width, height);
      }

      using (Graphics g = Graphics.FromImage(ImagePreplaced)) { g.Clear(Color.Black); }
      using (Graphics g = Graphics.FromImage(ImageNoPreplaced)) { g.Clear(Color.Black); }
      using (Graphics g = Graphics.FromImage(TemplateImage)) { g.Clear(Color.Black); }
      Image = ImageNoPreplaced;

      Dirty = true;
      TemplateDirty = true;

    }

    public void Clear()
    {
      using (Graphics g = Graphics.FromImage(Image))
      {
        g.Clear(Color.Black);
      }
    }

    public void Draw(MainModel model, Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preplaceEntity = null)
    {
      if (!AnyDirty) { return; }
      if (SuspendDrawing) { return; }
      bool preplaceTemplate = Visible[(int)LayerType.PreplaceEntity] && preplaceEntity != null && preplaceEntity.Type is TemplateType;

      using (new TimeKeeper(_ostopwatch, nameof(Draw)))
      {
        if (Dirty || TemplateDirty || preplaceTemplate)
        {
          using (Graphics g = Graphics.FromImage(ImageNoPreplaced))
          {
            // skip if Template can cover
            //g.Clear(Color.Black);

            // Ground layer, only drawn if Template is Dirty
            if (TemplateDirty)
            {
              using (new TimeKeeper(_stopwatch, nameof(EnvironmentRenderer.DrawTemplates)))
              using (Graphics tg = Graphics.FromImage(TemplateImage))
              {
                tg.CompositingMode = CompositingMode.SourceCopy;
                EnvironmentRenderer.DrawTemplates(map, cache, vfs, tg, Visible[(int)LayerType.Template_SingleColor]);
              }
              TemplateDirty = false;
            }

            using (new TimeKeeper(_stopwatch, "PaintTemplate"))
            {
              g.CompositingMode = CompositingMode.SourceCopy;
              g.DrawImage(TemplateImage, Point.Empty);
              g.CompositingMode = CompositingMode.SourceOver;
            }

            // Preplaced Template, if any
            if (Visible[(int)LayerType.PreplaceEntity] && preplaceEntity != null && preplaceEntity.Type is TemplateType)
              using (new TimeKeeper(_stopwatch, nameof(DrawPreplaceEntity)))
                DrawPreplaceEntity(map, rules, cache, vfs, g, preplaceEntity, _pleplacedHighlight);

            // Bib layers
            if (Visible[(int)LayerType.Bases])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawBaseBibs)))
                TechnoTypeRenderer.DrawBaseBibs(map, rules, cache, vfs, g);

            if (Visible[(int)LayerType.Structures])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawStructureBibs)))
                TechnoTypeRenderer.DrawStructureBibs(map, rules, cache, vfs, g);

            // Terrain layers
            if (Visible[(int)LayerType.Overlays])
              using (new TimeKeeper(_stopwatch, nameof(EnvironmentRenderer.DrawOverlays)))
                EnvironmentRenderer.DrawOverlays(map, cache, vfs, g);

            if (Visible[(int)LayerType.Smudges])
              using (new TimeKeeper(_stopwatch, nameof(EnvironmentRenderer.DrawSmudges)))
                EnvironmentRenderer.DrawSmudges(map, cache, vfs, g);

            if (Visible[(int)LayerType.Terrain])
              using (new TimeKeeper(_stopwatch, nameof(EnvironmentRenderer.DrawTerrain)))
                EnvironmentRenderer.DrawTerrain(map, cache, vfs, g);

            // Object layers
            if (Visible[(int)LayerType.Bases])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawBases)))
                TechnoTypeRenderer.DrawBases(map, rules, cache, vfs, g);

            if (Visible[(int)LayerType.Structures])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawStructures)))
                TechnoTypeRenderer.DrawStructures(map, rules, cache, vfs, g);

            if (Visible[(int)LayerType.Units])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawUnits)))
                TechnoTypeRenderer.DrawUnits(map, rules, cache, vfs, g);

            if (Visible[(int)LayerType.Ships])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawShips)))
                TechnoTypeRenderer.DrawShips(map, rules, cache, vfs, g);

            if (Visible[(int)LayerType.Infantry])
              using (new TimeKeeper(_stopwatch, nameof(TechnoTypeRenderer.DrawInfantries)))
                TechnoTypeRenderer.DrawInfantries(map, rules, cache, vfs, g);

            // Editor widgets layer
            if (Visible[(int)LayerType.CellTriggers])
              using (new TimeKeeper(_stopwatch, nameof(WidgetsRenderer.DrawCellTriggers)))
                WidgetsRenderer.DrawCellTriggers(map, preplaceEntity, g);

            if (Visible[(int)LayerType.Waypoints])
              using (new TimeKeeper(_stopwatch, nameof(WidgetsRenderer.DrawWaypoints)))
                WidgetsRenderer.DrawWaypoints(map, preplaceEntity, g);

            if (Visible[(int)LayerType.Bounds])
              using (new TimeKeeper(_stopwatch, nameof(WidgetsRenderer.DrawBounds)))
                WidgetsRenderer.DrawBounds(map, g);

            if (Visible[(int)LayerType.Selection])
              using (new TimeKeeper(_stopwatch, nameof(WidgetsRenderer.DrawSelection)))
                WidgetsRenderer.DrawSelection(model, map, g);

            if (Visible[(int)LayerType.Grid])
              using (new TimeKeeper(_stopwatch, nameof(WidgetsRenderer.DrawGrid)))
                WidgetsRenderer.DrawGrid(map, g);
          }
          Dirty = false;
        }

        // Preplaced objects, if any
        if (PreplaceDirty)
        {
          if (Visible[(int)LayerType.PreplaceEntity] && preplaceEntity != null && preplaceEntity.Type != null && !(preplaceEntity.Type is TemplateType))
          {
            using (Graphics g = Graphics.FromImage(ImagePreplaced))
            {
              using (new TimeKeeper(_stopwatch, "PaintImageNoPreplaced"))
              {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImage(ImageNoPreplaced, Point.Empty);
                g.CompositingMode = CompositingMode.SourceOver;
              }

              using (new TimeKeeper(_stopwatch, nameof(DrawPreplaceEntity)))
                DrawPreplaceEntity(map, rules, cache, vfs, g, preplaceEntity, _pleplacedHighlight);
            }
            Image = ImagePreplaced;
          }
          else
          {
            Image = ImageNoPreplaced;
          }
          PreplaceDirty = false;
        }

        using (new TimeKeeper(_stopwatch, "SetTimer"))
        {
          if (Visible[(int)LayerType.PreplaceEntity] && preplaceEntity != null)
          {
            if (!_timer.Enabled)
              _timer.Start();
          }
          else
          {
            if (_timer.Enabled)
              _timer.Stop();
          }
        }
        //if (MapUpdated != null)
        //  MapUpdated.Invoke();
      }
    }
    
    public void DrawPreplaceEntity(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo preplaceEntity, bool highlight)
    {
      if (preplaceEntity.Type == null) { return; }     
      preplaceEntity.Type.DrawOnMap(map, rules, cache, vfs, g, preplaceEntity, highlight);
    }
  }
}
