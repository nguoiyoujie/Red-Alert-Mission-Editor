using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class SmudgeSection
  {
    public List<SmudgeInfo> SmudgeList = new List<SmudgeInfo>();

    public void Read(IniFile.IniSection section)
    {
      SmudgeList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        SmudgeList.Add(SmudgeInfo.Parse(kvp.Key, kvp.Value.Value));
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (SmudgeInfo smudge in SmudgeList)
      {
        section.SetValue(index.ToString(), smudge.GetValueAsString());
        index++;
      }
    }
  }
}
