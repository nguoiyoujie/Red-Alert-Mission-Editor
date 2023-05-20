using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor
{
  public static class MapExtractSet
  {
    public static string DirPath = @".\data\extract";

    public static readonly Dictionary<string, MapExtract> LoadedExtracts = new Dictionary<string, MapExtract>();

    public static void SaveExtract(string nameWithoutExtension, MapExtract extract)
    {
      Directory.CreateDirectory(DirPath);
      if (File.Exists(Path.Combine(DirPath, nameWithoutExtension + ".ini")))
      {
        int running = 1;
        while (File.Exists(Path.Combine(DirPath, nameWithoutExtension + "_" + running + ".ini")))
        {
          running++;
        }
        nameWithoutExtension += "_" + running;
      }
      extract.Save(Path.Combine(DirPath, nameWithoutExtension + ".ini"));
      Reload();
    }

    public static void Reload()
    {
      if (Directory.Exists(DirPath))
      {
        VirtualFileSystem vfs = new VirtualFileSystem();
        vfs.AddItem(DirPath);

        LoadedExtracts.Clear();
        foreach (string p in Directory.EnumerateFiles(DirPath, "*.ini", SearchOption.TopDirectoryOnly))
        {
          try
          {
            string filename = Path.GetFileName(p);
            string filename_noext = Path.GetFileNameWithoutExtension(p);

            IniFile f = vfs.OpenFile<IniFile>(filename);
            MapExtract extract = new MapExtract(f);
            LoadedExtracts.Add(filename_noext, extract);
          }
          finally
          {

          }
        }
      }
    }
  }
}
