#region Copyright & License Information
/*
 * Copyright 2007-2012 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 * 
 * Additional modifications were made to this code by Iran. See https://github.com/mvdhout1992/RAFullMapPreviewGenerator
 * Additional modifications were made to this code by YJ.
 * 
 */
#endregion

using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats.Encodings;
using RA_Mission_Editor.Resources;
using RA_Mission_Editor.Util;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RA_Mission_Editor.FileFormats
{
  public class ShpFile : VirtualFile
  {
    public class ShpImage
    {
      public uint Offset;
      public EncodingFormat Format;

      public uint RefOffset;
      public EncodingFormat RefFormat;
      public ShpImage RefImage;

      public byte[] Image;

      public ShpImage() { }

      public ShpImage(BinaryReader reader)
      {
        var data = reader.ReadUInt32();
        Offset = data & 0xffffff;
        Format = (EncodingFormat)(data >> 24);

        RefOffset = reader.ReadUInt16();
        RefFormat = (EncodingFormat)reader.ReadUInt16();
      }

      public void WriteTo(BinaryWriter writer)
      {
        writer.Write(Offset | ((uint)Format << 24));
        writer.Write((ushort)RefOffset);
        writer.Write((ushort)RefFormat);
      }
    }

    public ushort Width;
    public ushort Height;
    public ushort NumImages;
    public List<ShpImage> Images = new List<ShpImage>();

    static ShpFile()
    {
      Cache<ShpFile>.SetCreateFunction((s, f) => FormatHelper.OpenAsFormat(s, f, format: FormatHelper.GetFormatFromTypeclass(typeof(ShpFile))) as ShpFile);
    }

    public ShpFile(Stream baseStream, string filename, int baseOffset, int fileSize, bool isBuffered = true)
      : base(baseStream, filename, baseOffset, fileSize, isBuffered)
    {
      Parse();
    }

    public void Parse()
    {
      NumImages = ReadUInt16();
      ReadUInt16();
      ReadUInt16();
      Width = ReadUInt16();
      Height = ReadUInt16();
      ReadUInt32();

      for (int i = 0; i < NumImages; i++)
        Images.Add(new ShpImage(new BinaryReader(this)));

      new ShpImage(new BinaryReader(this)); // end-of-file header
      new ShpImage(new BinaryReader(this)); // all-zeroes header


      Dictionary<uint, ShpImage> offsets = new Dictionary<uint, ShpImage>();

      foreach (ShpImage h in Images)
      {
        offsets.Add(h.Offset, h);
      }


      for (int i = 0; i < NumImages; i++)
      {
        var h = Images[i];
        if (h.Format == EncodingFormat.Format20)
          h.RefImage = Images[i - 1];

        else if (h.Format == EncodingFormat.Format40)
          if (!offsets.TryGetValue(h.RefOffset, out h.RefImage))
            throw new InvalidDataException(string.Format("Reference doesnt point to image data {0}->{1}", h.Offset, h.RefOffset));
      }

      foreach (ShpImage h in Images)
        Decompress(this, h);
    }

    int recurseDepth = 0;
    void Decompress(Stream stream, ShpImage h)
    {
      if (recurseDepth > NumImages)
        throw new InvalidDataException("Format20/40 headers contain infinite loop");

      switch (h.Format)
      {
        case EncodingFormat.Format20:
        case EncodingFormat.Format40:
          {
            if (h.RefImage.Image == null)
            {
              ++recurseDepth;
              Decompress(stream, h.RefImage);
              --recurseDepth;
            }

            h.Image = CopyImageData(h.RefImage.Image);
            Format40.DecodeInto(ReadCompressedData(stream, h), h.Image);
            break;
          }
        case EncodingFormat.Format80:
          {
            byte[] imageBytes = new byte[Width * Height];
            int readPtr = 0;
            byte[] src = ReadCompressedData(stream, h);
            WWCompression.LcwDecompress(src, ref readPtr, imageBytes, src.Length);
            h.Image = imageBytes;
            break;
          }
        default:
          throw new InvalidDataException();
      }
    }

    static byte[] ReadCompressedData(Stream stream, ShpImage h)
    {
      stream.Position = h.Offset;
      // Actually, far too big. There's no length field with the correct length though :(
      var compressedLength = (int)(stream.Length - stream.Position);

      var compressedBytes = new byte[compressedLength];
      stream.Read(compressedBytes, 0, compressedLength);

      return compressedBytes;
    }

    byte[] CopyImageData(byte[] baseImage)
    {
      var imageData = new byte[Width * Height];
      for (int i = 0; i < Width * Height; i++)
        imageData[i] = baseImage[i];

      return imageData;
    }

    public void Save(string filename)
    {
      using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
      {
        var compressedFrames = Images.Select(f => WWCompression.LcwCompress(f.Image)).ToList();

        // note: end-of-file and all-zeroes headers
        var dataOffset = 14 + (compressedFrames.Count + 2) * 8;

        using (var bw = new BinaryWriter(fs))
        {
          bw.Write((ushort)compressedFrames.Count);
          bw.Write((ushort)0);
          bw.Write((ushort)0);
          bw.Write(Width);
          bw.Write(Height);
          bw.Write(0U);

          foreach (var f in compressedFrames)
          {
            var ih = new ShpImage { Format = EncodingFormat.Format80, Offset = (uint)dataOffset };
            dataOffset += f.Length;

            ih.WriteTo(bw);
          }

          var eof = new ShpImage { Offset = (uint)dataOffset };
          eof.WriteTo(bw);

          var allZeroes = new ShpImage { };
          allZeroes.WriteTo(bw);

          foreach (var f in compressedFrames)
            bw.Write(f);
        }
      }
    }
  }
}
