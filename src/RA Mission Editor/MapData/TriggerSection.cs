using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class TriggerSection
  {
    public List<TriggerInfo> TriggerList = new List<TriggerInfo>();

    public void Read(Map map, IniFile.IniSection section)
    {
      TriggerList.Clear();
      foreach (var kvp in section.OrderedEntries)
      {
        TriggerList.Add(TriggerInfo.Populate(kvp.Key));
      }

      int index = 0;
      // special: Triggers need to re-evaluated since its contents depend on  
      foreach (var kvp in section.OrderedEntries)
      {
        TriggerList[index++].ParseValue(map, kvp.Value.Value);
      }
    }

    public void Update(Map map, IniFile.IniSection section)
    {
      section.Clear();
      foreach (TriggerInfo trigger in TriggerList)
      {
        section.SetValue(trigger.GetKeyAsString(), trigger.GetValueAsString(map));
      }
    }
  }
}
