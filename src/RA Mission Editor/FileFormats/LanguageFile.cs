using System.IO;
using System.Text;
using System.Collections.Generic;

namespace RA_Mission_Editor.FileFormats
{
  public class LanguageFile : VirtualFile
  {
    public List<string> Strings;

    public LanguageFile(Stream baseStream, string filename, int baseOffset, int fileSize, bool isBuffered = true)
      : base(baseStream, filename, baseOffset, fileSize, isBuffered)
    {
      Parse();
    }

    public int Count { get { return Strings?.Count ?? 0; } }

    public string Get(int index)
    {
      // strings are 1-based
      index--;
      int c = Count;
      if (index < 0 || index >= c) return null;
      return Strings[index];
    }

    public void Set(int index, string value)
    {
      // strings are 1-based
      if (index >= Count) { Strings.Capacity = index; }
      index--;
      Strings[index] = value;
    }

    public void Parse()
    {
      // read 
      Position = 0;
      ushort firstdataoffset = ReadUInt16();
      int datacount = firstdataoffset / 2;
      ushort[] dataoffsets = new ushort[datacount];
      dataoffsets[0] = firstdataoffset;
      string[] _s = new string[datacount];

      for (int i = 1; i < datacount; i++)
      {
        dataoffsets[i] = ReadUInt16();
      }

      for (int i = 0; i < datacount; i++)
      {
        Position = dataoffsets[i];
        _s[i] = ReadString();
      }

      Strings = new List<string>(_s);
    }

    public void Save(string filename)
    {
      using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
      {
        using (var bw = new BinaryWriter(fs))
        {
          int offset = Count * 2;
          foreach (string s in Strings)
          {
            bw.Write((ushort)offset);
            offset += s.Length + 1;
          }

          foreach (string s in Strings)
          {
            bw.Write(Encoding.ASCII.GetBytes(s ?? string.Empty));
            bw.Write('\0');
          }
        }
      }
    }
  }
}
