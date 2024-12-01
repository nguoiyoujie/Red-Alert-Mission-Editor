using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData.TechnoSets;
using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData.Ruleset
{
  public abstract class Rules
  {
    /// <summary>The combined rules that the game will see</summary>
    public IniFile GameRules;
    public LanguageFile LanguageText;

    public Houses Houses = new Houses();
    public Infantries Infantries = new Infantries();
    public Units Units = new Units();
    public Vessels Vessels = new Vessels();
    public Aircrafts Aircrafts = new Aircrafts();
    public Buildings Buildings = new Buildings();
    public Sounds Sounds = new Sounds();
    public Speeches Speeches = new Speeches();
    public Themes Themes = new Themes();
    public VQTypes Movies = new VQTypes();
    public SpecialWeapons SpecialWeapons = new SpecialWeapons();
    
    public void Clear() { GameRules = null; LanguageText = null; }

    public abstract void LoadRules(VirtualFileSystem vfs);

    public abstract void ApplyRules();

    public abstract void ApplyRulesWithMap(Map map);

    public string ReadString(string section, string key, out RulesSource source, string defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadString(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadString(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public int ReadInt(string section, string key, out RulesSource source, int defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadInt(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadInt(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public bool ReadBool(string section, string key, out RulesSource source, bool defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadBool(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadBool(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public float ReadFloat(string section, string key, out RulesSource source, float defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadFloat(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadFloat(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public List<string> ReadList(string section, string key, out RulesSource source, List<string> defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadList(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadList(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public double ReadDouble(string section, string key, out RulesSource source, double defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadDouble(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadDouble(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public short ReadShort(string section, string key, out RulesSource source, short defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadShort(key);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadShort(key);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }

    public T ReadEnum<T>(string section, string key, out RulesSource source, T defaultValue = default, IniFile mapFile = null)
    {
      if (mapFile != null && (mapFile.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.MAP_FILE;
        return mapFile.GetSection(section).ReadEnum(key, defaultValue);
      }
      if (GameRules != null && (GameRules.GetSection(section)?.HasKey(key) ?? false))
      {
        source = RulesSource.RULES_FILE;
        return GameRules.GetSection(section).ReadEnum(key, defaultValue);
      }
      source = RulesSource.NONE;
      return defaultValue;
    }
  }
}
