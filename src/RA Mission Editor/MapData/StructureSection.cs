using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
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
        StructureList.Add(StructureInfo.Parse(kvp.Key, kvp.Value.Value));
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
