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

			Width = ReadUInt16();
			Height = ReadUInt16();
			ReadUInt16(); // NumTiles
			ReadUInt16(); // Zero1
			BlockWidth = ReadInt32();
			BlockHeight = ReadInt32();
			uint imgStart = ReadUInt32();
			ReadUInt32(); // Zero2

			int IndexEnd, IndexStart;
			if (ReadUInt16() == 65535) // ID1 = FFFFh for cnc
			{
				ReadUInt16(); // ID2 
				IndexEnd = ReadInt32();
				IndexStart = ReadInt32();
			}
			else // Load as a ra .tem
			{
				Position = 0;
				Width = ReadUInt16();
				Height = ReadUInt16();

				ReadUInt16(); // NumTiles
				ReadUInt16(); // Zero1
				BlockWidth = ReadUInt16(); // XDim
				BlockHeight = ReadUInt16(); // YDim
				ReadUInt32(); // FileSize
				imgStart = ReadUInt32();
				ReadUInt32();
				ReadUInt32();
				IndexEnd = ReadInt32();
				ReadUInt32();
				IndexStart = ReadInt32();
			}
			Position = IndexStart;

			Images = new List<TmpImage>();
			foreach (byte b in new BinaryReader(this).ReadBytes(IndexEnd - IndexStart))
			{
				if (b != 255)
				{
					Position = imgStart + b * Width * Height;
					var img = new TmpImage();
					img.TileData = new BinaryReader(this).ReadBytes(Width * Height);
					Images.Add(img);
				}
				else
				{ Images.Add(null); }
			}
		}
	}
}
