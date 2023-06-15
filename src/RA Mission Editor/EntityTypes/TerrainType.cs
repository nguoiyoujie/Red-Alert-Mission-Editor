using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class TerrainType : IEntityType
  {
    public string ID { get; }

    public TerrainType(string id)
    {
      ID = id;
    }

    public string DisplayName { get => ToString(); }

    public override string ToString()
    {
      return ID;
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
    {
      Bitmap bmp = null;
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
      {
        bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
      }
      return bmp;
    }

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
    {
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
      EnvironmentRenderer.DrawTerrain(map, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, highlight);

      //Bitmap bmp = null;
      //if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
      //    cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
      //{
      //  bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
      //}
      //if (bmp != null)
      //{
      //  g.DrawImage(bmp, entity.X * Constants.CELL_PIXEL_W, entity.Y * Constants.CELL_PIXEL_H);
      //}
    }
  }
}
