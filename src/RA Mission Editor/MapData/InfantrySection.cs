using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class InfantrySection
  {
    public List<InfantryInfo> EntityList = new List<InfantryInfo>();

    public void Read(IniFile.IniSection section)
    {
      EntityList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        InfantryInfo u = new InfantryInfo();
        if (u.Parse(kvp.Value.Value))
          EntityList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Infantry {kvp.Key} contains less than expected parameters");
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (InfantryInfo infantry in EntityList)
      {
        section.SetValue(index.ToString(), infantry.GetValueAsString());
        index++;
      }
    }
  }
}
