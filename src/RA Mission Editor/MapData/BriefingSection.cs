using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class BriefingSection
  {
    public string Briefing;

    public void Read(IniFile.IniSection section)
    {
      List<string> textList = new List<string>();
      foreach (var kvp in section.OrderedEntries)      // do not care about indices
      {
        textList.Add(kvp.Value.Value);
      }
      Briefing = string.Join(" ", textList).Replace("@", Environment.NewLine);
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      List<string> textList = new List<string>(Briefing.Replace(Environment.NewLine, "@").SplitByCharWithinLength(new char[] { ' ' }, 70));

      int index = 0;
      foreach (string t in textList)
      {
        section.SetValue(index.ToString(), t);
        index++;
      }
    }
  }
}
