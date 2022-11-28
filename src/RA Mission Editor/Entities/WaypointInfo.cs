using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Drawing;

namespace RA_Mission_Editor.Entities
{
  public class WaypointInfo : IEntity<WaypointInfo>, IEntityType, ILocatable
  {
    public readonly Map Map;

    public WaypointInfo(Map owner)
    {
      Map = owner;
    }

    // WAYPOINT=CELL
    // Example: 98=350
    public string ID { get; set; }  // Waypoint ID
    public int Cell { get; set; } // Cell ID
    public string Comment;

    public string DisplayName { get => ToString(); }

    public string GetKeyAsString()
    {
      return ID;
    }

    public string GetValueAsString()
    {
      return Cell.ToString();
    }

    public string GetExtKeyAsString()
    {
      return "WAYP:" + ID;
    }

    public string GetExtValueAsString(Map map)
    {
      return Comment;
    }

    public override string ToString()
    {
      return $"{ID} @ {{{MapHelper.CellX(Map, Cell)}, {MapHelper.CellY(Map, Cell)}}}";
    }

    public static WaypointInfo Parse(Map map, string index, string value)
    {
      WaypointInfo s = new WaypointInfo(map);
      // only waypoints 00-99 allowed
      if (!int.TryParse(index, out int nid) && (nid < 0 || nid > 99))
      {
        throw new Exception($"Map Waypoint {index} is invalid. Only Waypoints from 0 to 99 inclusive are allowed.");
      }
      s.ID = index;
      string[] tokens = value.Split(',');
      if (tokens.Length < 1)
      {
        throw new Exception($"Map Waypoint {index} contains less than expected parameters");
      }
      s.Cell = int.Parse(tokens[0]);
      return s;
    }

    public WaypointInfo GetEntityType(Rules rules)
    {
      return this;
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
    {
      Bitmap bmp = new Bitmap(Constants.CELL_PIXEL_W * 3, Constants.CELL_PIXEL_H * 3);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        WidgetsRenderer.DrawWaypoint(map, g, ID, 1, 1);
      }
      return bmp;
    }

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity)
    {
      WidgetsRenderer.DrawWaypoint(map, g, ID, entity.X, entity.Y);
      if (int.TryParse(ID, out int nid) && map.IsCellInMap(map.WaypointSection.WaypointList[nid].Cell))
      {
        int cell = map.WaypointSection.WaypointList[nid].Cell;
        int x2 = map.CellX(cell);
        int y2 = map.CellY(cell);
        WidgetsRenderer.DrawWaypointTransferLine(map, g, entity.X, entity.Y, x2, y2);
      }
    }
  }
}
