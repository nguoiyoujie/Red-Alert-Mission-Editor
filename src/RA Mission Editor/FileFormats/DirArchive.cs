using RA_Mission_Editor.Util;
using System.IO;

namespace RA_Mission_Editor.FileFormats
{
  public class DirArchive : IArchive
  {
    public readonly string Directory;

    public DirArchive(string path)
    {
      Directory = path;
    }

    public bool ContainsFile(string filename)
    {
      return File.Exists(Path.Combine(Directory, filename));
    }

    public VirtualFile OpenFile(string filename, FileFormat format = FileFormat.None, BufferingMode m = BufferingMode.Default)
    {
      string path = Path.Combine(Directory, filename);

      bool bufferMixes = (m & BufferingMode.BufferMixes) > 0;
      bool bufferContents = (m & BufferingMode.BufferContents) > 0;
      bool buffered = format == FileFormat.Mix ? bufferMixes : bufferContents;

      if (!buffered)
      {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        return FormatHelper.OpenAsFormat(fs, filename, 0, (int)fs.Length, format);
      }
      else
      {
        // Note: We can't always make buffer copies and free the files because some files are just too large. E.g. MAIN.MIX
        MemoryStream inMemoryCopy = new MemoryStream();
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
          fs.CopyTo(inMemoryCopy);
        }
        inMemoryCopy.Position = 0;
        return FormatHelper.OpenAsFormat(inMemoryCopy, filename, 0, (int)inMemoryCopy.Length, format);
      }
    }

    public void Close() { }

    public override string ToString()
    {
      return Path.GetFileName(Directory);
    }
  }
}
