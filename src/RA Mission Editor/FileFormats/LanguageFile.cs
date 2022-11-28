using System.IO;

namespace RA_Mission_Editor.FileFormats
{
  public class LanguageFile : VirtualFile
  {
    private string[] strings;

    public LanguageFile(Stream baseStream, string filename, int baseOffset, int fileSize, bool isBuffered = true)
      : base(baseStream, filename, baseOffset, fileSize, isBuffered)
    {
      Parse();
    }

    public int Count { get { return strings?.Length ?? 0; } }

    public string Get(int index)
    {
      // strings are 1-based
      index--;
      int c = Count;
      if (index < 0 || index >= c) return null;
      return strings[index];
    }

    public void Parse()
    {
      // read 
      Position = 0;
      ushort firstdataoffset = ReadUInt16();
      int datacount = firstdataoffset / 2;
      ushort[] dataoffsets = new ushort[datacount];
      dataoffsets[0] = firstdataoffset;
      strings = new string[datacount];

      for (int i = 1; i < datacount; i++)
      {
        dataoffsets[i] = ReadUInt16();
      }

      for (int i = 0; i < datacount; i++)
      {
        Position = dataoffsets[i];
        strings[i] = ReadString();
      }
    }
  }
}
