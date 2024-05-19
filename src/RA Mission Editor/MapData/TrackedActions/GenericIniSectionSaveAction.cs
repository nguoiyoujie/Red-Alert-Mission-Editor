using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class GenericIniSectionSaveAction : ITrackedAction
  {
    public enum ModifyType { ADDSECTION, REMOVESECTION, SETKEY, REMOVEKEY }

    public Map Map;
    public string Description { get; set; }
    public ModifyType Type;
    public string Section;
    public string Key;
    public string Value;
    public IniFile.IniSection OldSectionData;
    public string OldValue;

    public GenericIniSectionSaveAction(Map map, ModifyType type, string section, string key = "", string value = "")
    {
      Map = map;
      Section = section;
      Type = type;
      switch (Type)
      {
        case ModifyType.ADDSECTION:
          Description = "Add INI Section [" + section + "]";
          break;
        case ModifyType.REMOVESECTION:
          Description = "Remove INI Section [" + section + "]";
          OldSectionData = new IniFile.IniSection(section);
          IniFile.IniSection entry = Map.SourceFile.GetSection(section);
          foreach (var line in entry.OrderedEntries)
          {
            OldSectionData.SetValue(line.Value.Key, line.Value.Value, line.Value.Comment, false);
          }
          break;
        case ModifyType.SETKEY:
          Description = "Add INI Value [" + section + "] " + key;
          Key = key;
          Value = value;
          OldValue = Map.SourceFile.GetSection(section)?.ReadString(key, null) ?? null;
          break;
        case ModifyType.REMOVEKEY:
          Description = "Add Remove Value [" + section + "] " + key;
          Key = key;
          Value = null;
          OldValue = Map.SourceFile.GetSection(section)?.ReadString(key, null) ?? null;
          break;
      }
    }

    public void Do()
    {
      switch (Type)
      {
        case ModifyType.ADDSECTION:
          Map.SourceFile.GetOrCreateSection(Section);
          break;
        case ModifyType.REMOVESECTION:
          foreach (var section in Map.SourceFile.Sections)
          {
            if (section.Name == Section)
            {
              Map.SourceFile.Sections.Remove(section);
            }
          }
          break;
        case ModifyType.SETKEY:
        case ModifyType.REMOVEKEY:
          if (Value == null)
          {
            Map.SourceFile.GetSection(Section).RemoveValue(Key);
          }
          else
          {
            Map.SourceFile.GetSection(Section).SetValue(Key, Value);
          }
          break;
      }
      Map.Dirty = true;
    }

    public void Undo()
    {
      switch (Type)
      {
        case ModifyType.ADDSECTION:
          foreach (var section in Map.SourceFile.Sections)
          {
            if (section.Name == Section)
            {
              Map.SourceFile.Sections.Remove(section);
            }
          }
          break;
        case ModifyType.REMOVESECTION:
          IniFile.IniSection entry = Map.SourceFile.GetOrCreateSection(Section);
          entry.Clear();
          foreach (var line in OldSectionData.OrderedEntries)
          {
            entry.SetValue(line.Value.Key, line.Value.Value, line.Value.Comment, false);
          }
          break;
        case ModifyType.SETKEY:
        case ModifyType.REMOVEKEY:
          if (OldValue == null)
          {
            Map.SourceFile.GetSection(Section).RemoveValue(Key);
          }
          else
          {
            Map.SourceFile.GetSection(Section).SetValue(Key, OldValue);
          }
          break;
      }
      Map.Dirty = true;
    }
  }
}