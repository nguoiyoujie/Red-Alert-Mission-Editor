using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class ShipSection
  {
    public List<ShipInfo> ShipList = new List<ShipInfo>();

    public void Read(IniFile.IniSection section)
    {
      ShipList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        ShipList.Add(ShipInfo.Parse(kvp.Key, kvp.Value.Value));
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (ShipInfo ship in ShipList)
      {
        section.SetValue(index.ToString(), ship.GetValueAsString());
        index++;
      }
    }
  }
}
