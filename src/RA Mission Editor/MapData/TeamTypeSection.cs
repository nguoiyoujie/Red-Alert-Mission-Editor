using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class TeamTypeSection
  {
    public List<TeamTypeInfo> TeamTypeList = new List<TeamTypeInfo>();

    public void ReadFirst(IniFile.IniSection section)
    {
      TeamTypeList.Clear();
      foreach (var kvp in section.OrderedEntries)
      {
        TeamTypeList.Add(new TeamTypeInfo() { Name = kvp.Key });
      }
    }

    public void ReadNext(Map map, IniFile.IniSection section)
    {
      int index = 0;
      // special: Triggers need to re-evaluated since its contents depend on  
      foreach (var kvp in section.OrderedEntries)
      {
        TeamTypeList[index++].ParseValue(map, kvp.Value.Value);
      }
    }

    public void Update(Map map, IniFile.IniSection section)
    {
      section.Clear();
      foreach (TeamTypeInfo team in TeamTypeList)
      {
        section.SetValue(team.GetKeyAsString(), team.GetValueAsString(map));
      }
    }
  }
}
