using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class InfantrySection
  {
    public List<InfantryInfo> InfantryList = new List<InfantryInfo>();

    public void Read(IniFile.IniSection section)
    {
      InfantryList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        InfantryList.Add(InfantryInfo.Parse(kvp.Key, kvp.Value.Value));
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (InfantryInfo infantry in InfantryList)
      {
        section.SetValue(index.ToString(), infantry.GetValueAsString());
        index++;
      }
    }
  }
}
