using RA_Mission_Editor.FileFormats;
using System;
using System.IO;

namespace RA_Mission_Editor.SettingsData
{
  public class Settings
  {
    const string SettingsFileName = @"settings.ini";

    public IniFile SourceFile { get; private set; }

    public CacheSection CacheSection = new CacheSection();

    public void Load()
    {
      VirtualFileSystem vfs = new VirtualFileSystem();
      vfs.AddItem(AppDomain.CurrentDomain.BaseDirectory);

      IniFile f = vfs.OpenFile<IniFile>(SettingsFileName);
      if (f == null)
      {
        // create file and try again
        f = new IniFile(null, null, 0, 0);
        CreateInitial(f);
        f.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFileName));
      }

      Load(f);
      f.Close(); // close the file handle
    }

    private void CreateInitial(IniFile f)
    {
      CacheSection.CreateInitial(f.GetOrCreateSection("Cache"));
    }

    private void Load(IniFile f)
    {
      SourceFile = f;

      CacheSection.Read(f.GetOrCreateSection("Cache"));
    }

    public void Save()
    {
      if (SourceFile == null) Load();
      Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFileName));
    }

    private void Save(string path)
    {
      IniFile f = SourceFile;

      CacheSection.Update(f.GetOrCreateSection("Cache"));

      f.Save(path);

      // Reload
      using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        Load(new IniFile(fs, Path.GetFileName(path), 0, (int)fs.Length));
      }
    }
  }
}
