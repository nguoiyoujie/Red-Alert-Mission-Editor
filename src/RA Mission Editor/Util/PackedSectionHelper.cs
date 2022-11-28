using RA_Mission_Editor.FileFormats.Encodings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RA_Mission_Editor.Util
{
  public static class PackedSectionHelper
  {
    public static MemoryStream GetPackedSection(IEnumerable<string> values)
    {
      StringBuilder sb = new StringBuilder();
      foreach (string v in values)
      {
        sb.Append(v);
      }
      string base64String = sb.ToString();
      byte[] data = Convert.FromBase64String(base64String);

      List<byte[]> chunks = new List<byte[]>();
      BinaryReader reader = new BinaryReader(new MemoryStream(data));

      try
      {
        while (true)
        {
          uint length = reader.ReadUInt32() & 0x0000ffff;
          byte[] dest = new byte[8192];
          byte[] src = reader.ReadBytes((int)length);

          int readPtr = 0;
          WWCompression.LcwDecompress(src, ref readPtr, dest, src.Length);
          chunks.Add(dest);
        }
      }
      catch (EndOfStreamException) { }

      var ms = new MemoryStream();
      foreach (var chunk in chunks)
        ms.Write(chunk, 0, chunk.Length);

      ms.Position = 0;
      return ms;
    }

    public static IEnumerable<string> RepackSection(MemoryStream m)
    {
      BinaryReader reader = new BinaryReader(m);
      List<KeyValuePair<byte[], int>> chunks = new List<KeyValuePair<byte[], int>>();

      try
      {
        while (true)
        {
          byte[] src = reader.ReadBytes(8192);
          // end of stream reached
          if (src.Length == 0) break;
          byte[] dest = WWCompression.LcwCompress(src);
          chunks.Add(new KeyValuePair<byte[], int>(dest, src.Length));
        }
      }
      catch (EndOfStreamException) { }

      MemoryStream ms = new MemoryStream();
      BinaryWriter bw = new BinaryWriter(ms);
      foreach (var chunk in chunks)
      {
        bw.Write((ushort)chunk.Key.Length);
        bw.Write((ushort)chunk.Value);

        bw.Write(chunk.Key, 0, chunk.Key.Length);
      }
      ms.Position = 0;

      string base64str = Convert.ToBase64String(ms.ReadAllBytes());
      // split to parts 70 characters each
      //List<string> lines = new List<string>();
      //var treader = new StringReader(base64str);

      return base64str.SplitByLength(70);
    }
  }
}