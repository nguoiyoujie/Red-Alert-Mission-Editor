using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  // template is its own entity
  public class TemplateType : IEntityType, IEntity
	{
		public string ID { get; }
    public bool IsBridge;

    public LandType LandType;

		public TemplateType(LandType landType, string id)
		{
			LandType = landType;
			ID = id;
		}

    public string DisplayName { get => ToString(); }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Templates; } }

    public override string ToString()
    {
      return ID;
    }

    public IEntityType GetEntityType(Rules rules)
    {
      return this;
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
    {
      Bitmap bmp = null;
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      if (cache.GetOrOpen(ID + tt.Extension, vfs, out TmpFile tmpFile))
      {
        bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile);
        // 
        if (preview.TemplateCell != 0xFF && bmp != null)
        {
          Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
          // use actual bmp width instead of BlockWidth
          int width = bmp.Width / TmpFile.TileSize;
          int cx = preview.TemplateCell % width; // tmpFile.BlockWidth;
          int cy = preview.TemplateCell / width; //tmpFile.BlockWidth;
          using (Graphics g = Graphics.FromImage(newbmp))
          {
            g.DrawImage(bmp, 0, 0);
            g.DrawRectangle(MapUserThemes.GridPen, cx * Constants.CELL_PIXEL_W, cy * Constants.CELL_PIXEL_H, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
          }
          bmp.DisposeIfNotCached();
          bmp = newbmp;
        }
      }
      return bmp;
    }

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
    {
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
      if (cache.GetOrOpen(ID + tt.Extension, vfs, out TmpFile tmpFile))
      {
        if (tmpFile.Images.Count != tmpFile.BlockWidth * tmpFile.BlockHeight)
        {
          // draw only the first cell
          EnvironmentRenderer.DrawTemplate(map, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, 0, highlight);
        }
        else
        {
          EnvironmentRenderer.DrawTemplate(map, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, entity.TemplateCell, highlight);
        }
      }
    }
  }
}
