using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
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
        ShipInfo u = new ShipInfo();
        if (u.Parse(kvp.Value.Value))
          ShipList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Ship {kvp.Key} contains less than expected parameters");
        }
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
