using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class Ext_CommentsSection
  {
    /*
     * [Ext_Comments]
     * TRIG:TODO=what to do...
     * 
     */
    public Dictionary<string, string> CommentList = new Dictionary<string, string>();

    public const string TriggerPrefix = "TRIG:";
    public const string TeamTypePrefix = "TEAM:";
    public const string GlobalsPrefix = "GLOB:";

    public void Read(IniFile.IniSection section)
    {
      CommentList.Clear();
      foreach (var kvp in section.OrderedEntries) // if there are duplicate keys, use only the first matching entry
      {
        if (!CommentList.ContainsKey(kvp.Key))
        {
          CommentList.Add(kvp.Key, kvp.Value.Value);
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      foreach (var kvp in CommentList)
      {
        section.SetValue(kvp.Key, kvp.Value);
      }
    }

    public string Get(string key)
    {
      if (CommentList.ContainsKey(key))
      {
        return CommentList[key];
      }
      return null;
    }

    public bool Put(string key, string value)
    {
      bool changed = Get(key) != value;
      if (value == null)
      {
        Remove(key);
      }
      else
      {
        CommentList[key] = value;
      }
      return changed;
    }

    public void Remove(string key)
    {
      CommentList.Remove(key);
    }

    public void Transfer(string origin_key, string destination_key, bool delete_origin)
    {
      string val = Get(origin_key);
      Put(destination_key, val);
      if (delete_origin) { Remove(origin_key); }
    }
  }
}
