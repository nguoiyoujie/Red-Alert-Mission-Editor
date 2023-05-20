using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class StructureSection
  {
    public List<StructureInfo> StructureList = new List<StructureInfo>();

    public void Read(IniFile.IniSection section)
    {
      StructureList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        StructureInfo u = new StructureInfo();
        if (u.Parse(kvp.Value.Value))
          StructureList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Structure {kvp.Key} contains less than expected parameters");
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (StructureInfo unit in StructureList)
      {
        section.SetValue(index.ToString(), unit.GetValueAsString());
        index++;
      }
    }
  }
}
