using System;

namespace RA_Mission_Editor.Util
{
  internal class FastByteReader
  {
    readonly byte[] src;
    int offset = 0;

    public FastByteReader(byte[] src)
    {
      this.src = src;
    }

    public bool Done() { return offset >= src.Length; }
    public byte ReadByte() { return src[offset++]; }
    public ushort ReadWord()
    {
      ushort x = ReadByte();
      return (ushort)(x | (ReadByte() << 8));
    }

    public void CopyTo(byte[] dest, int offset, int count)
    {
      Array.Copy(src, this.offset, dest, offset, count);
      this.offset += count;
    }

    public int Remaining() { return src.Length - offset; }
  }
}
