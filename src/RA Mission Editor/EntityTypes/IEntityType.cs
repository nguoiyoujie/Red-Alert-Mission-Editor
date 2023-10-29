using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public interface IEntityType
  {
    string ID { get; }
    Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview);
    void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight);
  }

  public interface IDrawable
  {
    Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview);
    void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight);
  }

  public interface ITechnoType : IEntityType
  {
  }

  public interface IOccupancyType : IEntityType
  {
    List<Point> Occupancy { get; }
  }
}
