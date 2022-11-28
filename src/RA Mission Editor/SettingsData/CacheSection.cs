using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.SettingsData
{
  public class CacheSection
  {
    /*
     * [Cache]
     * ExePath=C:/Games/RedAlert/RA95.exe
     * RecentFile00=C:/Games/RedAlert/testmap.ini
     * BackupMap=./cache/backup.ini
     * 
     */
    public string ExePath;
    public List<string> RecentFiles = new List<string>();
    public string BackupMap;

    private const int RecentFileLimit = 10;

    public void Read(IniFile.IniSection section)
    {
      ExePath = section.ReadString("ExePath", null);
      RecentFiles.Clear();
      foreach (var line in section.OrderedEntries)
      {
        if (line.Key.StartsWith("RecentFile"))
        {
          RecentFiles.Add(line.Value.Value);
        }
      }
      BackupMap = section.ReadString("BackupMap", null);
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      section.SetValue("ExePath", ExePath);

      for (int i = 0; i < RecentFiles.Count; i++)
      {
        section.SetValue($"RecentFile{i:00}", RecentFiles[i]);
      }
      section.SetValue("BackupMap", BackupMap);
    }

    internal void CreateInitial(IniFile.IniSection section)
    {
      section.SetValue("BackupMap", @"./cache/backup.ini");
    }

    public void SetRecentFile(string recentFile)
    {
      if (recentFile == null) { return; }

      if (RecentFiles.Contains(recentFile))
      {
        RecentFiles.Remove(recentFile);
      }

      RecentFiles.Insert(0, recentFile);

      if (RecentFiles.Count > RecentFileLimit)
      {
        RecentFiles.RemoveRange(RecentFileLimit, RecentFiles.Count - RecentFileLimit);
      }
    }
  }
}
