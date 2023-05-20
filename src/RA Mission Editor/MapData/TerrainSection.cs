using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
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
        TerrainInfo u = new TerrainInfo();
        if (u.Parse(kvp.Key, kvp.Value.Value))
          TerrainList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Terrain {kvp.Key} contains less than expected parameters");
        }
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
