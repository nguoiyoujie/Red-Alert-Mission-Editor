using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.FileFormats
{
  public class StoredIniValue<T>
  {
    private readonly Predicate<IniFile.IniSection> _hasFunc;
    private readonly Func<IniFile.IniSection, T> _readFunc;
    private readonly Action<IniFile.IniSection, T> _updateFunc;
    private readonly Action<IniFile.IniSection> _deleteFunc;
    public bool HasValue { get; private set; }
    public T Value { get; private set; }
    public bool HasDefaultValue { get; private set; }
    public T DefaultValue { get; private set; }

    public StoredIniValue(Predicate<IniFile.IniSection> hasFunc, Func<IniFile.IniSection, T> readFunc, Action<IniFile.IniSection, T> updateFunc, Action<IniFile.IniSection> deleteFunc)
    {
      _hasFunc = hasFunc;
      _readFunc = readFunc;
      _updateFunc = updateFunc;
      _deleteFunc = deleteFunc;
      HasValue = false;
      Value = default;
    }

    public StoredIniValue(Predicate<IniFile.IniSection> hasFunc, Func<IniFile.IniSection, T> readFunc, Action<IniFile.IniSection, T> updateFunc, Action<IniFile.IniSection> deleteFunc, T defaultValue)
      : this(hasFunc, readFunc, updateFunc, deleteFunc)
    {
      HasDefaultValue = true;
      DefaultValue = defaultValue;
    }


    public void Set(T value)
    {
      HasValue = true;
      Value = value;
    }

    public void Clear()
    {
      HasValue = HasDefaultValue;
      Value = DefaultValue;
    }

    public void Read(IniFile.IniSection section)
    {
      if (_hasFunc(section))
      {
        HasValue = true;
        Value = _readFunc(section);
      }
      else
      {
        Clear();
      }
    }

    public void Update(IniFile.IniSection section)
    {
      if (HasValue)
      {
        _updateFunc(section, Value);
      }
      else
      {
        _deleteFunc(section);
      }
    }

    public override string ToString()
    {
      return HasValue ? (Value == null ? "<null>" : Value.ToString()) : "<No value>";
    }
  }

  public class StoredIniValueExt
  {
    public static StoredIniValue<int> CreateIniLink_Int(string key, int defaultValue) { return new StoredIniValue<int>(s => s.HasKey(key), s => s.ReadInt(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key), defaultValue); }
    public static StoredIniValue<float> CreateIniLink_Float(string key, float defaultValue) { return new StoredIniValue<float>(s => s.HasKey(key), s => s.ReadFloat(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key), defaultValue); }
    public static StoredIniValue<bool> CreateIniLink_Bool(string key, bool defaultValue) { return new StoredIniValue<bool>(s => s.HasKey(key), s => s.ReadBool(key), (s, v) => s.SetValue(key, v ? "yes" : "no"), (s) => s.RemoveValue(key), defaultValue); }
    public static StoredIniValue<string> CreateIniLink_String(string key, string defaultValue) { return new StoredIniValue<string>(s => s.HasKey(key), s => s.ReadString(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key), defaultValue); }
    public static StoredIniValue<List<string>> CreateIniLink_List(string key, List<string> defaultValue) { return new StoredIniValue<List<string>>(s => s.HasKey(key), s => s.ReadList(key), (s, v) => s.SetValue(key, string.Join(",", v)), (s) => s.RemoveValue(key), defaultValue); }

    public static StoredIniValue<int> CreateIniLink_Int(string key) { return new StoredIniValue<int>(s => s.HasKey(key), s => s.ReadInt(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key)); }
    public static StoredIniValue<float> CreateIniLink_Float(string key) { return new StoredIniValue<float>(s => s.HasKey(key), s => s.ReadFloat(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key)); }
    public static StoredIniValue<bool> CreateIniLink_Bool(string key) { return new StoredIniValue<bool>(s => s.HasKey(key), s => s.ReadBool(key), (s, v) => s.SetValue(key, v ? "yes" : "no"), (s) => s.RemoveValue(key)); }
    public static StoredIniValue<string> CreateIniLink_String(string key) { return new StoredIniValue<string>(s => s.HasKey(key), s => s.ReadString(key), (s, v) => s.SetValue(key, v.ToString()), (s) => s.RemoveValue(key)); }
    public static StoredIniValue<List<string>> CreateIniLink_List(string key) { return new StoredIniValue<List<string>>(s => s.HasKey(key), s => s.ReadList(key), (s, v) => s.SetValue(key, string.Join(",", v)), (s) => s.RemoveValue(key)); }
  }
}
