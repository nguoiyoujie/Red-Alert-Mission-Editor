using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class SmudgeSection
  {
    public List<SmudgeInfo> EntityList = new List<SmudgeInfo>();

    public void Read(IniFile.IniSection section)
    {
      EntityList.Clear();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        SmudgeInfo u = new SmudgeInfo();
        if (u.Parse(kvp.Value.Value))
          EntityList.Add(u);
        else
        {
          // feedback the error
          throw new Exception($"Map Smudge {kvp.Key} contains less than expected parameters");
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (SmudgeInfo smudge in EntityList)
      {
        section.SetValue(index.ToString(), smudge.GetValueAsString());
        index++;
      }
    }
  }
}
