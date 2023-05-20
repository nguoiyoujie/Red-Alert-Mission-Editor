using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class UnitSection
  {
    public List<UnitInfo> UnitList = new List<UnitInfo>();

    public void Read(IniFile.IniSection section)
    {
      UnitList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        UnitInfo u = new UnitInfo();
        if (u.Parse(kvp.Value.Value))
          UnitList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Unit {kvp.Key} contains less than expected parameters");
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (UnitInfo unit in UnitList)
      {
        section.SetValue(index.ToString(), unit.GetValueAsString());
        index++;
      }
    }
  }
}
