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
using RA_Mission_Editor.Util;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.FileFormats
{
  public class TmpFile : VirtualFile
	{
    public class TmpImage
		{
			public byte[] TileData;
		}

		public const int TileSize = 24;

		public int Width;                  // width of blocks
		public int Height;                 // height in blocks
		public int BlockWidth;             // width of each block
		public int BlockHeight;            // height of each block

		public List<TmpImage> Images;
    public List<TileType> TileTypes;
    public List<byte> TransData;

    public bool IsClearTile
		{
			get { return BlockWidth * BlockHeight == 1 && Images.Count > 1; }
		}

    static TmpFile()
		{
			Cache<TmpFile>.SetCreateFunction((s, f) => FormatHelper.OpenAsFormat(s, f, format: FormatHelper.GetFormatFromTypeclass(typeof(TmpFile))) as TmpFile);
		}

		public TmpFile(Stream baseStream, string filename, int baseOffset, int fileSize, bool isBuffered = true)
			: base(baseStream, filename, baseOffset, fileSize, isBuffered)
		{
			Parse();
		}

		private void Parse()
		{
			Position = 0;
			
			Width = ReadUInt16(); // tileX
			Height = ReadUInt16(); // tileY
      int count = ReadInt32(); // Frames 
			BlockWidth = ReadInt32();
			BlockHeight = ReadInt32();
			uint iconoffset = ReadUInt32();
			ReadUInt32(); // Zero2

			uint indexStart, typeStart = 0, transFlagStart = 0;
			if (ReadUInt16() == 65535) // ID1 = FFFFh for cnc
			{
				ReadUInt16(); // ID2 
        transFlagStart = ReadUInt32();
				indexStart = ReadUInt32();
			}
			else // Load as a ra .tem
			{
				Position = 0;
				Width = ReadUInt16(); // tileX
        Height = ReadUInt16(); // tileY

        count = ReadInt32(); // Frames 
        BlockWidth = ReadUInt16(); // MapWidth
        BlockHeight = ReadUInt16(); // MapHeight
        uint dummy = ReadUInt32(); // FileSize
        iconoffset = ReadUInt32(); // first frame (0x28)
        uint paletteOffset = ReadUInt32(); // always 0
        uint remapOffset = ReadUInt32(); // ??
				transFlagStart = ReadUInt32();
        typeStart = ReadUInt32();
				indexStart = ReadUInt32();
			}
			Position = indexStart;

			Images = new List<TmpImage>(count);
      TileTypes = new List<TileType>(count);
			TransData = new List<byte>(count);

      foreach (byte b in new BinaryReader(this).ReadBytes(count))
			{
				if (b != 255)
				{
					Position = iconoffset + b * Width * Height;
					var img = new TmpImage();
					img.TileData = new BinaryReader(this).ReadBytes(Width * Height);
					Images.Add(img);
				}
        else
        { Images.Add(null); }
      }

			for (int i = 0; i < BlockWidth * BlockHeight; i++)
			{
				Position = typeStart + TileTypes.Count;
				TileTypes.Add((TileType)new BinaryReader(this).ReadByte());
			}

      for (int i = 0; i < count; i++)
      {
        Position = transFlagStart + TransData.Count;
        if (Images[i] != null)
        {
          TransData.Add(new BinaryReader(this).ReadByte());
        }
      }
    }

		public void Save(string filename)
		{
      if (Images.Count == 0) { return; }
      using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
      {
        int[] iconOffsets = new int[Images.Count];
        int[] indexOffsets = new int[Images.Count];
        int[] typeOffsets = new int[Images.Count];
        int[] transOffsets = new int[Images.Count];
				int offset = 0x28;
        for (int i = 0; i < Images.Count; i++)
        {
          if (Images[i] != null)
          {
            iconOffsets[i] = offset;
            offset += Images[i].TileData.Length;
          }
          else
          {
            iconOffsets[i] = -1;
          }
        }
        for (int i = 0; i < Images.Count; i++)
        {
          indexOffsets[i] = offset;
          offset++;
        }
        for (int i = 0; i < TransData.Count; i++)
        {
          transOffsets[i] = offset;
          offset++;
        }
        for (int i = 0; i < TileTypes.Count; i++)
        {
          typeOffsets[i] = offset;
          offset++;
        }

        // always save as ra .tem?
        using (var bw = new BinaryWriter(fs))
        {
          bw.Write((ushort)Width);
          bw.Write((ushort)Height);
          bw.Write(Images.Count);
          bw.Write((ushort)BlockWidth);
          bw.Write((ushort)BlockHeight);
          bw.Write(offset);
          bw.Write((uint)0x28);
          bw.Write((uint)0); // palette
          bw.Write((uint)0x2c730f6e); // remap (seems to be either 0x2c730f6e, 0x2c730f88 or 0x2c730000)
          bw.Write(transOffsets[0]);
          bw.Write(typeOffsets[0]);
          bw.Write(indexOffsets[0]);

          foreach (var img in Images)
          {
            if (img != null)
            {
              bw.Write(img.TileData);
            }
          }
          int c = 0;
          for (int i = 0; i < Images.Count; i++)
          {
            if (Images[i] != null)
            {
              bw.Write((byte)c++);
            }
            else
            {
              bw.Write((byte)255);
            }
          }
          for (int i = 0; i < TransData.Count; i++)
          {
            bw.Write((byte)TransData[i]);
          }
          for (int i = 0; i < Images.Count; i++)
          {
            bw.Write((byte)((i < TileTypes.Count) ? TileTypes[i] : 0));
          }
        }
      }
    }
	}
}
