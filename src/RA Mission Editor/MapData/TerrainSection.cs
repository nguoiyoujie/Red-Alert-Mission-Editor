using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class TerrainSection
  {
    public List<TerrainInfo> TerrainList = new List<TerrainInfo>();

    public void Read(IniFile.IniSection section)
    {
      TerrainList.Clear();
      foreach (var kvp in section.OrderedEntries)
      {
        TerrainList.Add(TerrainInfo.Parse(kvp.Key, kvp.Value.Value));
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      foreach (TerrainInfo terrain in TerrainList)
      {
        section.SetValue(terrain.GetKeyAsString(), terrain.GetValueAsString());
      }
    }
  }
}
