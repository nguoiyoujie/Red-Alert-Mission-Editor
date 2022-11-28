using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class TutorialSection
  {
    public Dictionary<int, string> Messages = new Dictionary<int, string>();

    public void Read(IniFile.IniSection section)
    {
      Messages.Clear();
      foreach (var kvp in section.OrderedEntries) // do not care about indices
      {
        if (int.TryParse(kvp.Key, out int index))
          Messages.Add(index, kvp.Value.Value);
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();

      foreach (KeyValuePair<int, string> kvp in Messages)
      {
        section.SetValue(kvp.Key.ToString(), kvp.Value);
      }
    }

  }
}
