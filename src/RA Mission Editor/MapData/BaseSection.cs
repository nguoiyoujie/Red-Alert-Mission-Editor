using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class BaseSection
  {
    // INDEX3=CELL,ID
    // Player=HOUSE
    // Count=x
    public string Player; // House
    public List<BaseInfo> EntityList = new List<BaseInfo>();

    public void Read(Map map, IniFile.IniSection section)
    {
      Player = section.ReadString("Player", map.AttachedRules.Houses.GetName(0));
      int count = section.ReadInt("Count", 0);
      EntityList.Clear();
      for (int i = 0; i < count; i++)
      {
        string key = $"{i:000}";
        EntityList.Add(BaseInfo.Parse(key, section.ReadString(key, "")));
      }
    }

    public void Update(Map map, IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (BaseInfo @base in EntityList)
      {
        string key = $"{index:000}";
        section.SetValue(key, @base.GetValueAsString());
        index++;
      }
      section.SetValue("Player", Player ?? map.AttachedRules.Houses.GetName(0));
      section.SetValue("Count", EntityList.Count.ToString());
    }
  }
}
