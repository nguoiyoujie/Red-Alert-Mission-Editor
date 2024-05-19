using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.UI.Dialogs;
using RA_Mission_Editor.UI.Logic;
using RA_Mission_Editor.UI.UserControls;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI
{
  public partial class MainEditor : Form
  {
    const string cacheDir = "cache";
    const string cacheMapFile = "backup.ini";

    public readonly MainModel MainModel = new MainModel(RulesType.LOVALMIDAS_EXTENSION);

    private bool _listBoxIsBase = false;

    private string ttipInfoText = "";
    private StringBuilder _cellInfosb = new StringBuilder();
    private StringBuilder _toolTipsb = new StringBuilder();
    private List<TechnoTypeControl> _technoTypeCtrlList = new List<TechnoTypeControl>();
    private EditorSelectMode _selectMode = EditorSelectMode.None;
    private float[] _zooms = new float[] { 0.5f, 1, 2, 4 };
    private int _dragSelectionX = -1;
    private int _dragSelectionY = -1;
    private IEntity _dragEntity = null;
    private ITrackedSnapshotAction _dragObjectAction = null;

    private Stopwatch _drawStopwatch = new Stopwatch();


    // for use to load a map at startup
    internal string InitialFilePath;

    public MainEditor()
    {
      InitializeComponent();
      splitMain.Enabled = false;
      pbMapCanvas.RequestDraw = Draw;
      pbMapCanvas.UpdateCoordinate += UpdateCoord;
      pbMapCanvas.UpdateCoordinate += UpdatePickEntity;
      pbMapCanvas.UpdateMouseDown = UpdateMouseDown;
      pbMapCanvas.UpdateMouseUp = UpdateMouseUp;
      pbMiniMapCanvas.ClickCoordinate = CenterCoord;
      pbMapCanvas.ClickCoordinate = ClickCoord;

      UpdateUI();

      // init
      for (int i = 0; i < 5; i++)
      {
        TechnoTypeControl ttc = new TechnoTypeControl();
        pTechnoList.Controls.Add(ttc);
        _technoTypeCtrlList.Add(ttc);
        ttc.Visible = false;
        ttc.Dock = DockStyle.Top;
        ttc.ObjectUpdated = (nx, ny, ns, e) =>
        {
          MainModel.OnEntityModified(e);
          pbMapCanvas.Renderer.SetDirty();
          UpdateCoord(nx, ny, ns, 0);
          ClickCoord(nx, ny, ns, MouseButtons.Right, e);
        };
      }

      MapUserThemes.SetRAFont(this);
    }

    public bool ProcessCmdKeyFromChildForm(ref Message msg, Keys keyData)
    {
      Message messageCopy = msg;
      messageCopy.HWnd = Handle;
      return ProcessCmdKey(ref messageCopy, keyData);
    }

    private void MainEditor_Load(object sender, EventArgs e)
    {
      try
      {
        // set up MainModel hooks
        MainModel.OnError += ErrorHandler.OnError;
        MainModel.OnMapChanged += OnMapSet;
        MainModel.OnClose += OnClose;
        MainModel.OnMapTemplateLayerChanged += pbMapCanvas.Renderer.SetTemplateDirty;
        MainModel.OnMapLayerChanged += pbMapCanvas.Renderer.SetDirty;

        MainModel.Initialize();
      }
      catch (Exception ex)
      {
        ErrorHandler.OnError($"Unexpected Error on Load:\n{ex.Message}\n\nThe application will now close", ErrorType.FATAL, false);
        Close();
        return;
      }

      if (InitialFilePath != null)
      {
        MainModel.LoadMap(InitialFilePath);
        InitialFilePath = null;
      }
    }

    public void OnMapSet()
    {
      pbMapCanvas.Renderer.Reset();
      Cleanup();
      RecentFilesHandler.UpdateRecentFileUIList(openRecentMapToolStripMenuItem, MainModel.ApplicationSettings.CacheSection.RecentFiles, OpenRecentFile);
      RefreshTitle();
      MainModel.CurrentMap.MapDirtyChanged = RefreshTitle;
      MainModel.CurrentMap.InvalidateSelectionList = SetObjectSelectionItems;
      MainModel.CurrentMap.InvalidateObjectDisplay = pbMapCanvas.Renderer.SetDirty;
      MainModel.CurrentMap.InvalidateObjectDisplay += RefreshObjectCanvas;
      MainModel.CurrentMap.InvalidateTemplateDisplay = pbMapCanvas.Renderer.SetTemplateDirty;
      MainModel.CurrentMap.UndoRedoChanged = UpdateUndoRedoUI;
      UpdateUI();
      UpdateUndoRedoUI();
    }

    public void Draw()
    {
      _drawStopwatch.Restart();
      MainModel.DrawMap(pbMapCanvas.Renderer); 
      MainModel.DrawMinimap(pbMiniMapCanvas.Renderer); 
      pbMiniMapCanvas.Invalidate();
      _drawStopwatch.Stop();
      tssRenderTime.Text = string.Format("Render Time: {0} ms", _drawStopwatch.ElapsedMilliseconds);
    }


    public void RefreshTitle()
    {
      Text = (MainModel.CurrentMap != null && MainModel.IsMapLoaded) ? $"{MainModel.CurrentMap.FilePath ?? "New map"} - \"{MainModel.CurrentMap.BasicSection.Name}\"" : Resources.Strings.Title;
      if (MainModel.IsMapLoaded)
      {
        if (MainModel.CurrentMap.Dirty)
        {
          Text += "*";
          menuStrip1.BackColor = Color.ForestGreen;
        }
        else
        {
          menuStrip1.BackColor = Color.DodgerBlue;
        }
      }
      else
      {
        menuStrip1.BackColor = Color.Silver;
      }
    }

    private void UpdateUndoRedoUI()
    { 
      undoToolStripMenuItem.Enabled = MainModel.CurrentMap?.TrackedActions.CanUndo() ?? false;
      redoToolStripMenuItem.Enabled = MainModel.CurrentMap?.TrackedActions.CanRedo() ?? false;
      undoToolStripMenuItem.Text = "Undo " + MainModel.CurrentMap?.TrackedActions.PeekUndo()?.Description ?? null;
      redoToolStripMenuItem.Text = "Redo " + MainModel.CurrentMap?.TrackedActions.PeekRedo()?.Description ?? null;
    }

    public void OnClose()
    {
      // last minute save?
      Close();
    }

    private void UpdateUI()
    {
      bool isMapOpen = MainModel.IsMapLoaded;
      splitMain.Enabled = isMapOpen;
      saveMapAsToolStripMenuItem.Enabled = isMapOpen;
      saveMapToolStripMenuItem.Enabled = isMapOpen;
      openRecentMapToolStripMenuItem.Enabled = openRecentMapToolStripMenuItem.DropDownItems.Count > 0;
      closeMapToolStripMenuItem.Enabled = isMapOpen;

      SetVisible(insertToolStripMenuItem, isMapOpen);
      SetVisible(editToolStripMenuItem, isMapOpen);
      SetVisible(advancedToolStripMenuItem, isMapOpen);
      SetVisible(visibilityToolStripMenuItem, isMapOpen);
      SetVisible(statisticsToolStripMenuItem, isMapOpen);
      SetVisible(renderToolStripMenuItem, isMapOpen);
      SetVisible(testToolStripMenuItem, isMapOpen);

      pbMapCanvas.Renderer?.SetVisible(MapCanvas.LayerType.Grid, cbGrid.Checked);
    }

    private void SetVisible(ToolStripMenuItem tsi, bool enable)
    {
      tsi.Visible = enable;
      foreach (object subobj in tsi.DropDownItems)
      {
        if (subobj is ToolStripMenuItem subtsi)
        {
          subtsi.Enabled = enable;
        }
      }
    }

    private void Cleanup()
    {
      DialogFunctions.GetEditorDialog()?.Close();
      foreach (TechnoTypeControl c in pTechnoList.Controls)
      {
        c.Visible = false;
      }
      _cellInfosb.Clear();
      _toolTipsb.Clear();
      ttipInfoText = null;
      tssRenderTime.Text = string.Empty;
    }

    private void OpenRecentFile(string path)
    {
      if (CheckAndWarnUnsavedMap())
        MainModel.LoadMap(path);
    }

    private void ttipInfo_Popup(object sender, PopupEventArgs e)
    {
      // on popup set the size of tool tip
      e.ToolTipSize = TextRenderer.MeasureText(ttipInfoText, MapUserThemes.ControlTextFont) + new Size(8, 4);
    }

    private void ttipInfo_Draw(object sender, DrawToolTipEventArgs e)
    {
      e.DrawBackground();
      e.DrawBorder();
      ttipInfoText = e.ToolTipText;
      e.Graphics.DrawString(e.ToolTipText, MapUserThemes.ControlTextFont, Brushes.Black, new PointF(2, 2));
    }

    private PlaceEntityMode GetMouseMode()
    {
      PlaceEntityMode mode = PlaceEntityMode.PLACE;
      if (_selectMode == EditorSelectMode.None)
      {
        mode |= PlaceEntityMode.SELECT;
      }
      else if ((MouseButtons & MouseButtons.Right) == MouseButtons.Right)
      {
        return PlaceEntityMode.DRAG; // drag and existing entity instead 
      }

      //modifiers
      if ((ModifierKeys & Keys.Control) == Keys.Control)
      {
        mode |= PlaceEntityMode.DELETE;
      }
      if ((ModifierKeys & Keys.Shift) == Keys.Shift)
      {
        mode |= PlaceEntityMode.PAINTING;
      }

      return mode;
    }

    private void UpdatePickEntity(int x, int y, int subcell, MouseButtons button)
    {
      IEntity pickentity = MainModel.PickEntity;
      if (pickentity != null && pickentity is ILocatable loce && button == MouseButtons.Right)
      {
        if (_dragEntity != pickentity)
        {
          _dragEntity = pickentity;
          if (pickentity is TerrainInfo terr)
          {
            _dragObjectAction = new MoveEntityAction<TerrainInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, terr, MainModel.CurrentMap.TerrainSection.EntityList);
          }
          else if (pickentity is SmudgeInfo smud)
          {
            _dragObjectAction = new MoveEntityAction<SmudgeInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, smud, MainModel.CurrentMap.SmudgeSection.EntityList);
          }
          else if (pickentity is InfantryInfo inft)
          {
            _dragObjectAction = new MoveEntityAction<InfantryInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, inft, MainModel.CurrentMap.InfantrySection.EntityList);
          }
          else if (pickentity is UnitInfo unit)
          {
            _dragObjectAction = new MoveEntityAction<UnitInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, unit, MainModel.CurrentMap.UnitSection.EntityList);
          }
          else if (pickentity is VesselInfo vessel)
          {
            _dragObjectAction = new MoveEntityAction<VesselInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, vessel, MainModel.CurrentMap.VesselSection.EntityList);
          }
          else if (pickentity is BaseInfo @base)
          {
            _dragObjectAction = new MoveEntityAction<BaseInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, @base, MainModel.CurrentMap.BaseSection.EntityList);
          }
          else if (pickentity is BuildingInfo building)
          {
            _dragObjectAction = new MoveEntityAction<BuildingInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, building, MainModel.CurrentMap.BuildingSection.EntityList);
          }
          else if (pickentity is WaypointInfo wayp)
          {
            _dragObjectAction = new MoveEntityAction<WaypointInfo>(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, wayp, MainModel.CurrentMap.WaypointSection.WaypointList);
          }
          _dragObjectAction.SnapshotOld();
        }
        // drag and hold
        bool changed = false;
        int c = MainModel.CurrentMap.CellNumber(x, y);
        if (pickentity is TemplateType || pickentity is CellTriggerInfo)
        {
          // ignore drag
          return;
        }
        if (loce.Cell != c)
        {
          changed = true;
          loce.Cell = c;
        }
        if (pickentity is InfantryInfo info)
        {
          if (info.SubCell != (byte)subcell)
          {
            changed = true;
            info.SubCell = (byte)subcell;
          }
        }
        if (changed)
        {
          MainModel.CurrentMap.MapOccupancyList.UpdateEntity(MainModel.CurrentMap, MainModel.Cache, MainModel.GameFileSystem, pickentity);
          MainModel.CurrentMap.Dirty = true;
          pbMapCanvas.Renderer.SetDirty();
        }
      }
    }

    private void UpdateCoord(int x, int y, int subcell, MouseButtons button)
    {
      int c = MainModel.CurrentMap.CellNumber(x, y);
      int prev_x = MainModel.PreplaceEntity.X;
      int prev_y = MainModel.PreplaceEntity.Y;
      int prev_subcell = MainModel.PreplaceEntity.SubCell;
      MainModel.PreplaceEntity.X = x;
      MainModel.PreplaceEntity.Y = y;
      MainModel.PreplaceEntity.SubCell = (byte)subcell;

      if (prev_x != x || prev_y != y || prev_subcell != subcell)
      {
        bool xy_unchanged = prev_x == x && prev_y == y;
        // should we rerender due to a change in the preplace entity location?
        if (MainModel.PreplaceEntity.Type != null)
        {
          // we care about changing subcells only if Infantry is involved
          if (!xy_unchanged || MainModel.PreplaceEntity.Type is InfantryType)
          {
            pbMapCanvas.Renderer.SetPreplaceDirty();
          }
        }
      }

      tssCoord.Text = $"Cell:{c:00000} X:{x:000} Y:{y:000} Sub:{subcell}";
      tssCellInfo.Text = "";
      tssCellTemplateInfo.Text = "";
      tssCellOverlayInfo.Text = "";
      _cellInfosb.Clear();
      _toolTipsb.Clear();
      foreach (IEntity entity in MainModel.DoPick(x, y, subcell))
      {
        if (entity is TemplateType tem)
        {
          tssCellTemplateInfo.Text = tem.ID;
        }
        else if (entity is OverlayType ovl)
        {
          tssCellOverlayInfo.Text = ovl.ID;
        }
        else if (entity is WaypointInfo wayp)
        {
          _cellInfosb.Append("Waypoint " + wayp.ID);
          _cellInfosb.Append(',');
        }
        else if (entity is CellTriggerInfo celt)
        {
          _cellInfosb.Append("CellTrig " + celt.ID);
          _cellInfosb.Append(',');
        }
        else if (entity is InfantryInfo iinfo && iinfo.SubCell != subcell)
        {
          // filter out infantry in other subcells
          continue;
        }
        else if (entity is IOwnedEntity owned)
        {
          _cellInfosb.Append(owned.Owner + " " + entity.ID);
          _cellInfosb.Append(',');
        }
        else if (entity != null)
        {
          _cellInfosb.Append(entity.ID);
          _cellInfosb.Append(',');
        }

        if (entity.GetEntityType(MainModel.CurrentMap.AttachedRules) is ITechnoType)
        {
          if (entity is IOwnedEntity ownedentity)
          {
            _toolTipsb.AppendLine(ownedentity.ID + "," + ownedentity.Owner);
          }
          else
          {
            _toolTipsb.AppendLine(entity.ID);
          }
        }
      }
      tssCellInfo.Text = _cellInfosb.ToString().Trim(',');
      ttipInfoText = _toolTipsb.ToString().Trim();
      ttipInfo.SetToolTip(pbMapCanvas, ttipInfoText);

      if (button == MouseButtons.Left)
      {
        MainModel.PaintEntity(GetMouseMode(), MainModel.PreplaceEntity);
      }

      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, (GetMouseMode() & PlaceEntityMode.NO_DRAW) == 0);
      pbMapCanvas.Cursor = GetCanvasCursor(GetMouseMode());
    }

    private void UpdateMouseDown(int x, int y, int subcell, MouseButtons button)
    {
      if (button == MouseButtons.Left)
      {
        PlaceEntityMode mode = GetMouseMode();
        if ((mode & PlaceEntityMode.SELECT) > 0)
        {
          _dragSelectionX = x;
          _dragSelectionY = y;
        }
      }
      else if (button == MouseButtons.Right)
      {
        UpdateSelectedPick(EditorSelectMode.Any);
        using (MapPickDialog mpd = DialogFunctions.GetMapPickDialog() ?? new MapPickDialog())
        {
          mpd.Location = MousePosition;
          mpd.ModeSelected = UpdateSelectedPick;
          if (mpd.Set(MainModel) >= 2)
          {
            mpd.ShowDialog();
          }
        }
      }
    }

    private void UpdateSelectedPick(EditorSelectMode selectMode)
    {
      if (selectMode == EditorSelectMode.Ignore) { return; }

      MainModel.DoSelectFromPick(selectMode);

      //if (_selectMode == EditorSelectMode.Any)
      //{
        if (MainModel.PickEntity != null)
        {
          selectMode = MainModel.PickEntity.SelectMode;
        }
        else
        {
          MainModel.PickEntity = Templates.Get(0);
          selectMode = EditorSelectMode.Templates;
        }
      //}

      SetObjectSelectionItems(selectMode);

      // update selection
      if (lboxObjects.Items.Count > 0)
      {
        MainModel.DoPeekFromPick(lboxObjects.Items[0].GetType());
        if (MainModel.PickEntity is CellTriggerInfo cinfo && lboxObjects.Items[0] is CellTriggerInfo)
        {
          foreach (CellTriggerInfo item in lboxObjects.Items)
          {
            if (cinfo.ID.Equals(item.ID, StringComparison.OrdinalIgnoreCase))
            {
              lboxObjects.SelectedItem = item;
              MainModel.PreplaceEntity.Update(MainModel.CurrentMap, MainModel.PickEntity);
              RefreshObjectCanvas();
              break;
            }
          }
        }
        else
        {
          if (MainModel.PickEntity != null)
          {
            IEntityType etype = MainModel.PickEntity.GetEntityType(MainModel.CurrentMap.AttachedRules);
            if (etype != null && lboxObjects.Items.Contains(etype))
            {
              lboxObjects.SelectedItem = MainModel.PickEntity.GetEntityType(MainModel.CurrentMap.AttachedRules);
              MainModel.PreplaceEntity.Update(MainModel.CurrentMap, MainModel.PickEntity);
              RefreshObjectCanvas();
            }
            else
            {
              // default to first item
              if (lboxObjects.Items.Count > 0)
              {
                etype = (IEntityType)(lboxObjects.Items[0]);
                lboxObjects.SelectedIndex = 0;
                //MainModel.PickEntity = 
              }
            }
          }
        }
      }
    }

    private void UpdateMouseUp(int x, int y, int subcell, MouseButtons button)
    {
      if (button == MouseButtons.Left)
      {
        PlaceEntityMode mode = GetMouseMode();
        if ((mode & PlaceEntityMode.SELECT) > 0)
        {
          if ((mode & PlaceEntityMode.PAINTING) == 0)
          {
            MainModel.SelectedCellsList.Clear();
          }

          int x0 = Math.Min(_dragSelectionX, x);
          int y0 = Math.Min(_dragSelectionY, y);
          int x1 = Math.Max(_dragSelectionX, x);
          int y1 = Math.Max(_dragSelectionY, y);
          for (int i = x0; i <= x1; i++)
            for (int j = y0; j <= y1; j++)
            {
              int cell = MainModel.CurrentMap.CellNumber(i, j);
              if (MainModel.SelectedCellsList.Contains(cell))
              {
                MainModel.SelectedCellsList.Remove(cell);
              }
              else
              {
                MainModel.SelectedCellsList.Add(cell);
              }
            }
          _dragSelectionX = -1;
          _dragSelectionY = -1;
          pbMapCanvas.Renderer.SetDirty();
        }
        MainModel.CurrentMap.LastClickedCell = MainModel.CurrentMap.CellNumber(x, y);
      }
      else if (button == MouseButtons.Right)
      {
        if (MainModel.PickEntity != null)
        {
          MainModel.PickEntity = null;
          MainModel.CurrentMap.Update();
        }

        if (_dragObjectAction != null)
        {
          _dragObjectAction.SnapshotNew();
          MainModel.CurrentMap.TrackedActions.Push(_dragObjectAction);
          _dragObjectAction = null;
          _dragEntity = null;
        }

        MapPickDialog mpd = DialogFunctions.GetMapPickDialog();
        if (mpd != null)
        {
          mpd.Close();
        }
      }
    }

    private void CenterCoord(int x, int y, int subcell, MouseButtons button, IEntity selectedEntity = null)
    {
      Panel c = pbMapCanvas.Parent as Panel;
      if (c != null)
      {
        c.AutoScrollPosition = new Point(x * pbMapCanvas.Size.Width / MainModel.CurrentMap.Ext_MapSection.FullWidth - c.Size.Width / 2, y * pbMapCanvas.Size.Height / MainModel.CurrentMap.Ext_MapSection.FullHeight - c.Size.Height / 2);
      }
    }

    private void ClickCoord(int x, int y, int subcell, MouseButtons button, IEntity selectedEntity = null)
    {
      if (button == MouseButtons.Left)
      {
        PlaceEntityMode mode = GetMouseMode();
        if ((mode & (PlaceEntityMode.PLACE | PlaceEntityMode.PAINTING)) > 0)
        {
          MainModel.PlaceEntity(mode, MainModel.PreplaceEntity);

          // refresh the list if placement may change the display list (e.g. names of the items in the list)
          // Waypoints do this as the display contains their current location
          IEntityType type = MainModel.PreplaceEntity.Type;
          if (type is WaypointInfo || type is CellTriggerInfo)
          {
            MainModel.CurrentMap?.InvalidateSelectionList?.Invoke((type is WaypointInfo) ? EditorSelectMode.Waypoints : EditorSelectMode.CellTriggers);
            foreach (object item in lboxObjects.Items)
            {
              if (item is CellTriggerInfo ctrig && type.ID.Equals(ctrig.ID, StringComparison.OrdinalIgnoreCase))
              {
                lboxObjects.SelectedItem = item;
                break;
              }
            }
          }
        }
      }
      if (button == MouseButtons.Right)
      {
        if (selectedEntity == null) { selectedEntity = MainModel.PickEntity; }

        // update selected cell label
        lblSelectCell.Text = $"Cell: X={x:000} Y={y:000} Sub={subcell}";

        // reuse panel elements
        foreach (TechnoTypeControl c in pTechnoList.Controls)
        {
          c.Visible = false;
        }

        // edit
        int i = 0;
        foreach (IEntity entity in MainModel.CurrentMap.Pick(x, y, subcell))
        {
          // filter out infantry in other subcells // filter is now implemented in Pick
          //if (entity is InfantryInfo iinfo && iinfo.SubCell != subcell)
          //  continue;

          if (entity.GetEntityType(MainModel.CurrentMap.AttachedRules) is ITechnoType)
          {
            TechnoTypeControl ttc;
            if (i >= _technoTypeCtrlList.Count)
            {
              ttc = new TechnoTypeControl(MainModel, MainModel.CurrentMap, entity, selectedEntity == entity);
              pTechnoList.Controls.Add(ttc);
              _technoTypeCtrlList.Add(ttc);
              ttc.Dock = DockStyle.Top;
              ttc.ObjectUpdated = (nx, ny, ns, e) =>
              {
                MainModel.OnEntityModified(e);
                pbMapCanvas.Renderer.SetDirty();
                UpdateCoord(nx, ny, ns, 0);
                ClickCoord(nx, ny, ns, button, e);
              };
              ttc.Visible = true;
            }
            else
            {
              ttc = _technoTypeCtrlList[i];
              ttc.ShowPanels = entity == selectedEntity;
              ttc.SetModel(MainModel);
              ttc.SetMap(MainModel.CurrentMap);
              ttc.SetEntity(entity);
              ttc.Visible = true;
            }
            i++;
          }
        }
        pTechnoList.Invalidate();
      }
    }

    private void setRedAlertDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show(Resources.Strings.Warn_ModifyExe, Resources.Strings.Title, MessageBoxButtons.YesNoCancel))
      {
        default:
        case DialogResult.Cancel:
          return;
        case DialogResult.Yes:
          saveMapToolStripMenuItem_Click(null, null);
          break;
        case DialogResult.No:
          break;
      }

      string exePath;
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Find Red Alert Executable",
        Filter = "Red Alert executable|RA95.exe|All files (*.*)|*.*",
        CheckPathExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        exePath = ofd.FileName;
        bool skipExe = false;
        while (!skipExe)
        {
          try
          {
            MainModel.LoadExe(exePath);
            break;
          }
          catch (Exception ex)
          {
            if (!MainModel.NotifyExeError(ex.Message, out exePath))
            {
              Close();
              skipExe = true;
            }
            else
            {
              continue;
            }
          }
        }
      }
    }

    private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (CheckAndWarnUnsavedMap())
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Open Map",
          Filter = "Map ini file|*.ini|All files (*.*)|*.*",
          CheckFileExists = true,
          Multiselect = false
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          MainModel.LoadMap(ofd.FileName);
        }
      }
    }

    private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (CheckAndWarnUnsavedMap())
      {
        EditMapAttributesDialog nmd = new EditMapAttributesDialog();
        if (nmd.ShowDialog() == DialogResult.OK)
        {
          // create map in internal cache
          string mapPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cacheDir, cacheMapFile);

          // update the map dialog
          MainModel.LoadMap(new IniFile(null, null, 0, 0), null, nmd.MapSection);
          MainModel.SaveMap(mapPath);
        }
      }
    }

    private void lboxObjects_SelectedIndexChanged(object sender, EventArgs e)
    {
      MainModel.PreplaceEntity.TemplateCell = 0xFF; // reset before regenerating image

      RefreshObjectCanvas();
      if (lboxObjects.SelectedItem is MapExtract selExtract)
      {

      }
      else
      {
        IEntityType etype = lboxObjects.SelectedItem as IEntityType;
        MainModel.PreplaceEntity.Type = etype;
        MainModel.PreplaceEntity.IsBase = _listBoxIsBase;
      }
    }

    private void SetObjectSelectionItems(EditorSelectMode mode)
    {
      if (mode == EditorSelectMode.Any || mode == EditorSelectMode.Ignore) { return; }
      object obj = lboxObjects.SelectedItem;
      lboxObjects.Items.Clear();
      _selectMode = mode;
      bool isSelect = _selectMode == EditorSelectMode.None;
      copySelectedCellsToolStripMenuItem.Enabled = isSelect;
      pasteSelectedCellsToolStripMenuItem.Enabled = isSelect;
      deleteObjectsInSelectionToolStripMenuItem.Enabled = isSelect;
      clearTemplateInSelectionToolStripMenuItem.Enabled = isSelect;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Selection, isSelect);

      switch (mode)
      {
        default:
        case EditorSelectMode.None:
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = -1;
          lboxObjects_SelectedIndexChanged(null, null);
          pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, false);
          if (MainModel.IsMapLoaded && MainModel.SelectedCellsList.Count > 0)
          {
            MainModel.CurrentMap.LastClickedCell = -1;
            MainModel.SelectedCellsList.Clear();
            pbMapCanvas.Renderer.SetDirty();
          }
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Templates:
          lboxObjects.Items.AddRange(Templates.GetAsObjectList());
          lboxObjects.MultiColumn = true;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Overlays:
          lboxObjects.Items.AddRange(Overlays.GetAsObjectList());
          lboxObjects.MultiColumn = true;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Terrain:
          lboxObjects.Items.AddRange(Terrains.GetAsObjectList());
          lboxObjects.MultiColumn = true;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Smudges:
          lboxObjects.Items.AddRange(Smudges.GetAsObjectList());
          lboxObjects.MultiColumn = true;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Infantry:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.AttachedRules.Infantries.GetAsObjectList());
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = true;
          break;
        case EditorSelectMode.Units:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.AttachedRules.Units.GetAsObjectList());
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = true;
          break;
        case EditorSelectMode.Vessels:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.AttachedRules.Vessels.GetAsObjectList());
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = true;
          break;
        case EditorSelectMode.Buildings:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.AttachedRules.Buildings.GetAsObjectList());
          _listBoxIsBase = false;
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = true;
          break;
        case EditorSelectMode.Bases:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.AttachedRules.Buildings.GetAsObjectList());
          _listBoxIsBase = true;
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Waypoints:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.WaypointSection.WaypointList.Select<WaypointInfo, object>((t) => t).ToArray());
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.CellTriggers:
          lboxObjects.Items.AddRange(MainModel.CurrentMap.TriggerSection.TriggerList.Select<TriggerInfo, object>((t) => new CellTriggerInfo(MainModel.CurrentMap) { ID = t.Name }).ToArray());
          lboxObjects.MultiColumn = false;
          lboxObjects.SelectedIndex = 0;
          bSetEntity.Enabled = false;
          break;
        case EditorSelectMode.Extracts:
          lboxObjects.Items.AddRange(MapExtractSet.LoadedExtracts.Values.Select<MapExtract, object>((t) => new ExtractType(t)).ToArray());
          lboxObjects.MultiColumn = true;
          if (lboxObjects.Items.Count > 0) { lboxObjects.SelectedIndex = 0; }
          bSetEntity.Enabled = false;
          break;
      }
      lboxObjects.SelectedItem = obj;
    }

    private void bLayerTemplate_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Templates); }
    private void bLayerOverlay_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Overlays); }
    private void bLayerTerrain_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Terrain); }
    private void bLayerSmudge_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Smudges); }
    private void bLayerInfantry_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Infantry); }
    private void bLayerUnits_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Units); }
    private void bLayerVessels_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Vessels); }
    private void bLayerBuildings_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Buildings); }
    private void bLayerBases_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Bases); }
    private void bLayerWaypoints_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Waypoints); }
    private void bLayerCellTriggers_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.CellTriggers); }
    private void bExtract_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.Extracts); }
    private void bLayerNone_Click(object sender, EventArgs e) { SetObjectSelectionItems(EditorSelectMode.None); }

    private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MainModel.MapFilePath == null)
      {
        saveMapAsToolStripMenuItem_Click(sender, e);
      }
      else
      {
        MainModel.SaveMap(MainModel.MapFilePath);
      }
    }

    private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog sfd = new SaveFileDialog()
      {
        Title = "Save Map",
        Filter = "Map ini file|*.ini|All files (*.*)|*.*",
        OverwritePrompt = true
      };
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        MainModel.SaveMap(sfd.FileName);
        MainModel.LoadMap(sfd.FileName);
      }
    }

    private void cbGrid_CheckedChanged(object sender, EventArgs e)
    {
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Grid, cbGrid.Checked);
    }

    private void closeMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (CheckAndWarnUnsavedMap())
      {
        MainModel.LoadMap(null as IniFile);
      }
    }

    private Cursor GetCanvasCursor(PlaceEntityMode mode)
    {
      if ((mode & PlaceEntityMode.DELETE) > 0) { return Cursors.Cross; }
      return Cursors.Default;
    }

    private void MainEditor_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        bLayerNone_Click(sender, e);
      }

      PlaceEntityMode mode = GetMouseMode();
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, (mode & PlaceEntityMode.NO_DRAW) == 0);
      if (pbMapCanvas.Renderer.Dirty)
      {
        if (pbMapCanvas.RequestDraw != null)
        {
          pbMapCanvas.RequestDraw.Invoke();
        }
      }
    }

    private void MainEditor_KeyUp(object sender, KeyEventArgs e)
    {
      PlaceEntityMode mode = GetMouseMode();
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, (mode & PlaceEntityMode.NO_DRAW) == 0);
      if (pbMapCanvas.Renderer.Dirty)
      {
        if (pbMapCanvas.RequestDraw != null)
        {
          pbMapCanvas.RequestDraw.Invoke();
        }
      }
    }

    private void pbObjectCanvas_MouseClick(object sender, MouseEventArgs e)
    {
      // get image coordinates
      byte prevTemplateCell = MainModel.PreplaceEntity.TemplateCell;
      if (e.Button == MouseButtons.Right)
      {
        MainModel.PreplaceEntity.TemplateCell = 0xFF;
      }
      if (e.Button == MouseButtons.Left && lboxObjects.SelectedItem is TemplateType)
      {
        Image image = pbObjectCanvas.BackgroundImage;
        if (image != null)
        {
          int x = e.X - (pbObjectCanvas.Width - image.Width) / 2;
          int y = e.Y - (pbObjectCanvas.Height - image.Height) / 2;

          if (x >= 0 && x < pbObjectCanvas.Width && y >= 0 && y < pbObjectCanvas.Height)
          {
            int dx = image.Width / Constants.CELL_PIXEL_W;
            int cx = x / Constants.CELL_PIXEL_W;
            int cy = y / Constants.CELL_PIXEL_H;
            MainModel.PreplaceEntity.TemplateCell = (byte)(cx + cy * dx);
          }
        }
      }
      if (prevTemplateCell != MainModel.PreplaceEntity.TemplateCell)
      {
        RefreshObjectCanvas();
      }
    }

    private void RefreshObjectCanvas()
    {
      // refresh visuals
      IEntityType etype = lboxObjects.SelectedItem as IEntityType;
      Image bmp = MainModel.FetchEntityTypeBitmap(etype, pbMapCanvas.Renderer);
      if (etype == null)
      {
        pbObjectCanvas.BackgroundImage?.DisposeIfNotCached();
        pbObjectCanvas.BackgroundImage = null;
        pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, false);
        lblPreplaceHouse.Visible = false;
      }
      else
      {
        pbObjectCanvas.BackgroundImage?.DisposeIfNotCached();
        pbObjectCanvas.BackgroundImage = bmp;
        if (bmp != null)
        {
          pbObjectCanvas.Location = Point.Empty;
          pbObjectCanvas.Size = bmp.Size;
          pbObjectCanvas.Location = new Point(Math.Max(0 ,(pbObjectCanvas.Parent.Width / 2) - (pbObjectCanvas.Width / 2)),
                                      Math.Max(0, (pbObjectCanvas.Parent.Height / 2) - (pbObjectCanvas.Height / 2)));
          pbObjectCanvas.Refresh();
        }

        pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.PreplaceEntity, true);
        pbMapCanvas.Renderer.SetDirty();
        if (etype is ITechnoType)
        {
          string sowner = MainModel.PreplaceEntity.Owner;
          HouseType owner = MainModel.CurrentMap.AttachedRules.Houses.GetHouse(sowner);
          if (owner != null)
          {
            lblPreplaceHouse.Visible = true;

            ColorType color;
            if (etype is BuildingType || (etype is UnitType utype && utype.UsePrimaryColor))
            {
              color = owner.RulesPrimaryColor;
            }
            else
            {
              color = owner.RulesSecondaryColor;
            }

            Color rcolor = ColorRemaps.GetRadarColor(color);
            lblPreplaceHouse.ForeColor = rcolor;
            int bgdiff = rcolor.R + rcolor.G + rcolor.B > 128 * 3 ? -150 : 150;
            lblPreplaceHouse.BackColor = Color.FromArgb(Math.Max(0, Math.Min(255, rcolor.R + bgdiff)), Math.Max(0, Math.Min(255, rcolor.G + bgdiff)), Math.Max(0, Math.Min(255, rcolor.B + bgdiff)));
            lblPreplaceHouse.Text = sowner;
          }
        }
        else
        {
          lblPreplaceHouse.Visible = false;
        }
      }
    }

    private void bSetEntity_Click(object sender, EventArgs e)
    {
      EditPreplaceEntityDialog epd = new EditPreplaceEntityDialog();
      epd.SetMap(MainModel.CurrentMap);
      epd.SetEntity(MainModel.PreplaceEntity);
      epd.ShowDialog();
      // refresh object view
      RefreshObjectCanvas();
    }

    private void triggersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditorDialog etd = DialogFunctions.GetEditorDialog() ?? new EditorDialog(this);
      etd.Owner = this;
      etd.AttachRenderer(pbMapCanvas.Renderer);
      etd.SetMap(MainModel.CurrentMap);
      etd.SetSelectionToTriggers();
      etd.Show();
    }

    private void teamTypesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditorDialog etd = DialogFunctions.GetEditorDialog() ?? new EditorDialog(this);
      etd.Owner = this;
      etd.SetMap(MainModel.CurrentMap);
      etd.SetSelectionToTeamTypes();
      etd.Show();
    }

    private void basicToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditorDialog ebd = DialogFunctions.GetEditorDialog() ?? new EditorDialog(this);
      ebd.Owner = this;
      ebd.SetMap(MainModel.CurrentMap);
      ebd.SetSelectionToBasic();
      ebd.Show();
    }

    private void housesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditorDialog ehd = DialogFunctions.GetEditorDialog() ?? new EditorDialog(this);
      ehd.Owner = this;
      ehd.SetMap(MainModel.CurrentMap);
      ehd.SetSelectionToHouses();
      ehd.Show();
      // color changes
      //MainModel.CurrentMap.Update();
      //MainModel.CurrentMap.AttachedRules.ApplyRulesWithMap(MainModel.CurrentMap);
      //pbMapCanvas.Renderer.SetDirty();
    }

    private void missionStringsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditorDialog ebd = DialogFunctions.GetEditorDialog() ?? new EditorDialog(this);
      ebd.Owner = this;
      ebd.SetMap(MainModel.CurrentMap);
      ebd.SetSelectionToTutorial();
      ebd.Show();
    }

    private void mapAttributesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EditMapAttributesDialog emd = new EditMapAttributesDialog();
      emd.SetMap(MainModel.CurrentMap);
      emd.ShowDialog();
    }

    private void editINIToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show(Resources.Strings.Warn_ModifyIni, Resources.Strings.Title, MessageBoxButtons.YesNoCancel))
      {
        default:
        case DialogResult.Cancel:
          return;
        case DialogResult.Yes:
          saveMapToolStripMenuItem_Click(null, null);
          break;
        case DialogResult.No:
          break;
      }
      EditIniDialog eid = new EditIniDialog();
      eid.SetMap(MainModel.CurrentMap);
      eid.ShowDialog();
      // reload the map
      bool dirty = MainModel.CurrentMap.Dirty;
      MainModel.LoadMap(MainModel.CurrentMap.SourceFile, MainModel.MapFilePath);
      // dirty flag was reset when reloading the ini values. Set the flag again.
      MainModel.CurrentMap.Dirty = dirty;
    }

    private void cbHint_CheckedChanged(object sender, EventArgs e)
    {
      lblHint.Visible = cbHint.Checked;
    }

    private void tbarZoom_Scroll(object sender, EventArgs e)
    {
      pbMapCanvas.Zoom = _zooms[tbarZoom.Value];
    }

    private void overlayToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      overlayToolStripMenuItem1.Checked = !overlayToolStripMenuItem1.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Overlays, overlayToolStripMenuItem1.Checked);
    }

    private void terrainToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      terrainToolStripMenuItem1.Checked = !terrainToolStripMenuItem1.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Terrain, terrainToolStripMenuItem1.Checked);
    }

    private void smudgeToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      smudgeToolStripMenuItem1.Checked = !smudgeToolStripMenuItem1.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Smudges, smudgeToolStripMenuItem1.Checked);
    }

    private void infantryToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      infantryToolStripMenuItem1.Checked = !infantryToolStripMenuItem1.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Infantry, infantryToolStripMenuItem1.Checked);
    }

    private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      unitsToolStripMenuItem.Checked = !unitsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Units, unitsToolStripMenuItem.Checked);
    }

    private void vesselsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      vesselsToolStripMenuItem.Checked = !vesselsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Vessels, vesselsToolStripMenuItem.Checked);
    }

    private void buildingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      buildingsToolStripMenuItem.Checked = !buildingsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Buildings, buildingsToolStripMenuItem.Checked);
    }

    private void basesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      basesToolStripMenuItem.Checked = !basesToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Bases, basesToolStripMenuItem.Checked);
    }

    private void scriptTypeCellTargetsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      scriptTypeCellTargetsToolStripMenuItem.Checked = !scriptTypeCellTargetsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.ScriptTypeCellTargets, scriptTypeCellTargetsToolStripMenuItem.Checked);
    }

    private void waypointsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      waypointsToolStripMenuItem.Checked = !waypointsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Waypoints, waypointsToolStripMenuItem.Checked);
    }

    private void cellTriggersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      cellTriggersToolStripMenuItem.Checked = !cellTriggersToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.CellTriggers, cellTriggersToolStripMenuItem.Checked);
    }

    private void boundsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      boundsToolStripMenuItem.Checked = !boundsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Bounds, boundsToolStripMenuItem.Checked);
    }
    private void templateColorsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      templateColorsToolStripMenuItem.Checked = !templateColorsToolStripMenuItem.Checked;
      pbMapCanvas.Renderer.SetVisible(MapCanvas.LayerType.Template_SingleColor, templateColorsToolStripMenuItem.Checked);
    }

    private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ViewStatisticsDialog vsd = new ViewStatisticsDialog();
      vsd.SetMap(MainModel.CurrentMap, MainModel.CurrentMap.AttachedRules);
      vsd.ShowDialog();
    }

    private void verifyMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MainModel.CurrentMap != null)
      {
        VerifyDialog vmd = new VerifyDialog();
        vmd.VerifyMap(MainModel.CurrentMap);
        vmd.ShowDialog();
      }
    }

    private void testMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      TestMapDialog tmd = new TestMapDialog();
      if (tmd.ShowDialog() == DialogResult.OK)
      {
        saveMapToolStripMenuItem_Click(null, null);
        TestMapDialog.DifficultyChoice diff = tmd.Difficulty;
        // transfer save map to game directory
        string testmapname = "testmap.ini";
        string dest = Path.Combine(Path.GetDirectoryName(MainModel.ExecutablePath), testmapname);
        File.Copy(MainModel.MapFilePath, dest, true);

        string arg = "-NOTITLE -ONETIME ";
        switch (diff)
        {
          case TestMapDialog.DifficultyChoice.EASY:
            arg += "-EASY ";
            break;
          case TestMapDialog.DifficultyChoice.NORMAL:
            arg += "-NORMAL ";
            break;
          case TestMapDialog.DifficultyChoice.HARD:
            arg += "-HARD ";
            break;
        }
        arg += "-M:" + testmapname;
        ProcessStartInfo pstart = new ProcessStartInfo(MainModel.ExecutablePath, arg);
        Process.Start(pstart);
      }
    }

    private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!CheckAndWarnUnsavedMap()) { e.Cancel = true; }
    }

    private bool CheckAndWarnUnsavedMap()
    {
      if (MainModel.CurrentMap != null && MainModel.CurrentMap.Dirty)
      {
        switch (MessageBox.Show("You have unsaved changes! \nWould you like to save the map before closing?", Resources.Strings.Title, MessageBoxButtons.YesNoCancel))
        {
          case DialogResult.Cancel:
            return false;
          case DialogResult.Yes:
            saveMapToolStripMenuItem_Click(null, null);
            if (MainModel.CurrentMap.Dirty) // still not saved
            {
              return false;
            }
            break;
          case DialogResult.No:
            break;
        }
      }
      return true;
    }

    private void openRAbinFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // warn that this is a beta use
      MessageBox.Show("This feature will attempt to import the template layer from an unpacked OpenRA .bin file. Be warned that this is a fancy feature with no guarantees.");
      if (CheckAndWarnUnsavedMap())
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Import Terrain",
          Filter = "OpenRA map .bin file|*.bin|All files (*.*)|*.*",
          CheckFileExists = true,
          Multiselect = false
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            DirArchive achv = new DirArchive(Path.GetDirectoryName(ofd.FileName));
            OpenRABinFile bin = achv.OpenFile(Path.GetFileName(ofd.FileName), FileFormat.OpenRABin) as OpenRABinFile;
            EditMapAttributesDialog nmd = new EditMapAttributesDialog();
            if (nmd.ShowDialog() == DialogResult.OK)
            {
              // create map in internal cache
              string mapPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cacheDir, cacheMapFile);

              // update the map dialog
              MainModel.LoadMap(new IniFile(null, null, 0, 0), null, nmd.MapSection);
              bin.ImportIntoMap(MainModel.CurrentMap, 0, 0);
              MainModel.CurrentMap.RebuildOccupancyList(MainModel.Cache, MainModel.GameFileSystem);
              MainModel.SaveMap(mapPath);
            }
          }
          catch
          {
            MessageBox.Show("An error has occurred in attempting to load the OpenRA file");
          }
        }
      }
    }

    private void shiftMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ShiftMapDialog smd = new ShiftMapDialog();
      if (smd.ShowDialog() == DialogResult.OK)
      {
        int x = smd.ShiftX;
        int y = smd.ShiftY;
        MainModel.CurrentMap.Shift(MainModel.Cache, MainModel.GameFileSystem, x, y);
      }
    }

    private void copySelectedCellsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Map map = MainModel.CurrentMap;
      MapExtract mapext = new MapExtract(map, MainModel.SelectedCellsList);
      mapext.Update();
      Clipboard.SetText(mapext.SourceFile.SaveToString());
    }

    private void pasteSelectedCellsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string str = Clipboard.GetText();
      if (str != null)
      {
        IniFile f = new IniFile(str);
        MapExtract mapext = new MapExtract(f);
        mapext.DisplayName = "Clipboard";

        //IniFile f = new IniFile();
        Map map = MainModel.CurrentMap;
        int cell = map.LastClickedCell;
        if (map.IsCellInMap(cell))
        {
          map.InsertEntity(MainModel.Cache, MainModel.GameFileSystem, new PlaceEntityInfo(new ExtractType(mapext), map.CellX(cell), map.CellY(cell)));
          //mapext.Paste(map, map.CellX(cell), map.CellY(cell));
          map.RebuildOccupancyList(MainModel.Cache, MainModel.GameFileSystem);
          map.Dirty = true;
          pbMapCanvas.Renderer.SetTemplateDirty();
          pbMapCanvas.Renderer.SetDirty();
        }
      }
    }

    private void saveSelectedCellsInExtractToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Map map = MainModel.CurrentMap;
      MapExtract mapext = new MapExtract(map, MainModel.SelectedCellsList);
      mapext.Update();
      SaveExtractDialog sed = new SaveExtractDialog();
      if (sed.ShowDialog() == DialogResult.OK)
      {
        MapExtractSet.SaveExtract(sed.Key, mapext);
      }
    }

    private void deleteObjectsInSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Map map = MainModel.CurrentMap;
      map.ClearObjectsOnCells(MainModel.Cache, MainModel.GameFileSystem, MainModel.SelectedCellsList);
      pbMapCanvas.Renderer.SetDirty();
    }

    private void clearTemplateInSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Map map = MainModel.CurrentMap;
      map.ClearTemplateOnCells(MainModel.Cache, MainModel.GameFileSystem, MainModel.SelectedCellsList);
      pbMapCanvas.Renderer.SetTemplateDirty();
    }

    private void renderToImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("The renderer will save the current display into the file.\nNote that you can change the visibility settings with the Visibility tab in the top menu ribbon.");
      SaveFileDialog sfd = new SaveFileDialog()
      {
        Title = "Save Image",
        Filter = "PNG image file|*.png|Bitmap image file|*.bmp|All files (*.*)|*.*",
        OverwritePrompt = true
      };
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          pbMapCanvas.Renderer.Image.Save(sfd.FileName);
        }
        catch (Exception ex)
        {
          MainModel.OnError?.Invoke($"TError encountered: {ex.Message}", ErrorType.WARNING, false);
        }
      }
    }

    private void reloadDirectoryContentsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show(Resources.Strings.Warn_ModifyExe, Resources.Strings.Title, MessageBoxButtons.YesNoCancel))
      {
        default:
        case DialogResult.Cancel:
          return;
        case DialogResult.Yes:
          saveMapToolStripMenuItem_Click(null, null);
          break;
        case DialogResult.No:
          break;
      }

      string exePath = MainModel.ExecutablePath;
      bool skipExe = false;
      while (!skipExe)
      {
        try
        {
          MainModel.LoadExe(exePath);
          break;
        }
        catch (Exception ex)
        {
          if (!MainModel.NotifyExeError(ex.Message, out exePath))
          {
            Close();
            skipExe = true;
          }
          else
          {
            continue;
          }
        }
      }
    }

    private void openOtherEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OtherEditorDialog oehd = DialogFunctions.GetOtherEditorDialog() ?? new OtherEditorDialog(this);
      oehd.Owner = this;
      oehd.SetModel(MainModel);
      oehd.Show();
    }

    private void MainEditor_DragEnter(object sender, DragEventArgs e)
    {
      IDataObject ido = e.Data;
      if (ido.GetFormats().Contains(DataFormats.FileDrop))
      {
        string[] filelist = ido.GetData(DataFormats.FileDrop) as string[];
        if (filelist.Length == 1)
        {
          e.Effect = DragDropEffects.Move;
          return;
        }
      }
      e.Effect = DragDropEffects.None;
    }

    private void MainEditor_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Effect == DragDropEffects.Move)
      {
        IDataObject ido = e.Data;
        if (ido.GetFormats().Contains(DataFormats.FileDrop))
        {
          string[] filelist = ido.GetData(DataFormats.FileDrop) as string[];
          if (filelist.Length == 1)
          {
            OpenRecentFile(filelist[0]);
          }
        }
      }
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MainModel.CurrentMap != null)
      {
        MainModel.CurrentMap.TrackedActions?.Undo();
        DialogFunctions.GetEditorDialog()?.SetMap(MainModel.CurrentMap);
      }
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MainModel.CurrentMap != null)
      {
        MainModel.CurrentMap.TrackedActions?.Redo();
        DialogFunctions.GetEditorDialog()?.SetMap(MainModel.CurrentMap);
      }
    }
  }
}