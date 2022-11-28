using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class WaypointSection
  {
    public List<WaypointInfo> WaypointList = new List<WaypointInfo>();

    public void Read(Map map, IniFile.IniSection section)
    {
      WaypointList.Clear();
      // populate all 99 waypoints immediately
      List<WaypointInfo> temp = new List<WaypointInfo>();
      foreach (var kvp in section.OrderedEntries)
      {
        temp.Add(WaypointInfo.Parse(map, kvp.Key, kvp.Value.Value));
      }

      for (int i = 0; i <= 99; i++)
      {
        string s = i.ToString();
        WaypointInfo wpt = temp.Find((w) => w.ID == s);
        WaypointList.Add(wpt ?? new WaypointInfo(map) { ID = s, Cell = -1 });
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      foreach (WaypointInfo waypoint in WaypointList)
      {
        if (waypoint.Cell > 0)
        {
          section.SetValue(waypoint.GetKeyAsString(), waypoint.GetValueAsString());
        }
      }
    }

    /* don't add, modify only
    public void Add(WaypointInfo wpt)
    {
      // Maintain the list order to ensure 99 waypoints, so overwrite only
      if (wpt.WaypointID >= 0 && wpt.WaypointID < WaypointList.Count)
      {
        // overwrite
        WaypointList[wpt.WaypointID].Cell = wpt.Cell;
      }
    }
    */
    public void Delete(int wptID)
    {
      // Maintain the list order to ensure 99 waypoints, so overwrite only
      if (wptID >= 0 && wptID < WaypointList.Count)
      {
        // overwrite
        WaypointList[wptID].Cell = -1;
      }
    }
  }
}
