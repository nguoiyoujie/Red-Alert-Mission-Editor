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

    public LandType LandType;

		public TemplateType(LandType landType, string id)
		{
			LandType = landType;
			ID = id;
		}

    public string DisplayName { get => ToString(); }

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
          int cx = preview.TemplateCell % tmpFile.BlockWidth;
          int cy = preview.TemplateCell / tmpFile.BlockWidth;
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

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity)
    {
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
      Bitmap bmp = null;
      if (cache.GetOrOpen(ID + tt.Extension, vfs, out TmpFile tmpFile))
      {
        int c = map.CellNumber(entity.X, entity.Y);
        // fetch bitmap
        // if this is a clear tile (ID=0), the template has multiple tiles, pseudo-randomize them according to Clear_Icon() in
        // https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/TIBERIANDAWN/CELL.CPP
        if (Templates.GetID(ID) == 0)
        {
          bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, map.ClearIcon(c));
        }
        else
        {
          if (entity.TemplateCell != 0xFF)
          {
            bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, entity.TemplateCell);
          }
          else
          {
            bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile);
          }
        }

      }
      if (bmp != null)
      {
        g.DrawImage(bmp, entity.X * Constants.CELL_PIXEL_W, entity.Y * Constants.CELL_PIXEL_H);
      }
    }
  }
}
