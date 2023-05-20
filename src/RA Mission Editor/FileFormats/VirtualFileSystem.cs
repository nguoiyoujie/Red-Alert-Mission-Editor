using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RA_Mission_Editor.FileFormats
{
  public class VirtualFileSystem
  {
    public static readonly VirtualFileSystem Instance = new VirtualFileSystem();
    public readonly List<IArchive> AllArchives = new List<IArchive>();

    public static VirtualFile Open(string filename)
    {
      return Instance.OpenFile(filename);
    }

    public static T Open<T>(string filename, BufferingMode m = BufferingMode.Default) where T : VirtualFile
    {
      return Open(filename, FormatHelper.GetFormatFromTypeclass(typeof(T)), m) as T;
    }

    public static T Open<T>(string filename, FileFormat f, BufferingMode m) where T : VirtualFile
    {
      return Open(filename, f, m) as T;
    }

    public T OpenFile<T>(string filename, BufferingMode m = BufferingMode.Default) where T : VirtualFile
    {
      return OpenFile(filename, FormatHelper.GetFormatFromTypeclass(typeof(T)), m) as T;
    }

    public static VirtualFile Open(string filename, FileFormat f, BufferingMode m)
    {
      return Instance.OpenFile(filename, f, m);
    }

    public static bool Add(string filename, BufferingMode mode = BufferingMode.Default)
    {
      return Instance.AddItem(filename, mode);
    }

    public static bool Exists(string imageFileName)
    {
      return Instance.FileExists(imageFileName);
    }

    private bool FileExists(string filename)
    {
      return AllArchives.Any(v => v != null && v.ContainsFile(filename));
    }

    public VirtualFile OpenFile(string filename)
    {
      var format = FormatHelper.GuessFormat(filename);
      return OpenFile(filename, format);
    }

    public VirtualFile OpenFile(string filename, FileFormat format = FileFormat.None, BufferingMode m = BufferingMode.Default)
    {
      if (AllArchives == null || AllArchives.Count == 0) return null;
      var archive = AllArchives.FirstOrDefault(v => v != null && v.ContainsFile(filename));
      if (archive == null) return null;

      try
      {
        return archive.OpenFile(filename, format, m);
      }
      catch
      {
        return null;
      }
    }

    public bool AddItem(string path, BufferingMode m = BufferingMode.Default)
    {
      // directory
      if (Directory.Exists(path))
      {
        AllArchives.Add(new DirArchive(path));
        //Log.Write("log", "Added <DirArchive> {0} to VFS", path);
        return true;
      }
      // regular file
      else if (File.Exists(path))
      {
        var fi = new FileInfo(path);
        // mix file
        if (FormatHelper.GuessFormat(path) == FileFormat.Mix)
        {
          var mf = new MixFile(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read), path);
          AllArchives.Add(mf);
          //Log.Write("log", "Added <MixFile> {0} to VFS", path);
          return true;
        }
      }
      // virtual mix file
      else if (FileExists(path))
      {
        var mx = OpenFile(path, FileFormat.Mix) as MixFile;
        AllArchives.Add(mx);
        //Log.Write("log", "Added <VirtualMixFile> {0} to VFS", path);
        return true;
      }
      return false;
    }

    public bool AddMix(MixFile mix)
    {
      AllArchives.Add(mix);
      return true;
    }
  }

  [Flags]
  public enum BufferingMode
  {
    None = 0,
    BufferMixes = 1 << 0,
    BufferContents = 1 << 1,

    Default = BufferContents
  }
}
