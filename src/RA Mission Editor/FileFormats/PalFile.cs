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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace RA_Mission_Editor.FileFormats
{
  public class PalFile : VirtualFile
  {
    static int[] DefaultShadowIndex = { 3, 4 };
    static int[] DefaultHouseColorIndex = { 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95 };

    public const int BrightHouseColorIndex = 80;
    public const int DarkHouseColorIndex = 84;

    private uint[] colors;
    private static Bitmap cacheImage = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
    private ColorPalette colorPalette;

    public PalFile(Stream baseStream, string filename, int baseOffset, int fileSize, bool isBuffered = true)
      : base(baseStream, filename, baseOffset, fileSize, isBuffered)
    {
      Parse();
    }

    private PalFile(uint[] colors)
      : base(null)
    {
      this.colors = colors;
    }

    public PalFile Clone()
    {
      return new PalFile((uint[])colors.Clone());
    }

    public Color GetColor(int index)
    {
      return Color.FromArgb((int)colors[index]);
    }

    public void SetColor(int index, Color color)
    {
      colors[index] = (uint)color.ToArgb();
    }

    public void SetColor(int index, uint color)
    {
      colors[index] = (uint)color;
    }

    public void RemapAsShadow(int index)
    {
      colors[index] = 140u << 24;
    }

    public void Remap(int index, Color rgb)
    {
      colors[index] = Value_From_Color(rgb);
    }

    public void ApplyShadowRemap()
    {
      foreach (int i in DefaultShadowIndex)
      {
        RemapAsShadow(i);
      }
    }

    public void ApplyHouseRemap(Color[] remapList)
    {
      if (remapList.Length != 16) throw new ArgumentException("remapList array expects 16 elements, but received " + remapList.Length + ".");

      for (int i = 0; i < DefaultHouseColorIndex.Length && i < remapList.Length; i++)
      {
        Remap(DefaultHouseColorIndex[i], remapList[i]);
      }
    }

    public void ApplySwapRemap(byte[] swapList)
    {
      uint[] copy = new uint[colors.Length];
      colors.CopyTo(copy, 0);

      for (int i = 0; i < swapList.Length; i++)
      {
        colors[i] = copy[swapList[i]];
      }
    }


    public void Parse()
    {
      // read originalPalette
      Position = 0;
      byte[] data = Read(256 * 3);

      colors = new uint[256];
      for (int i = 0; i < 256; i++)
      {
        byte r = (byte)(data[i * 3] << 2);
        byte g = (byte)(data[i * 3 + 1] << 2);
        byte b = (byte)(data[i * 3 + 2] << 2);
        colors[i] = (uint)((255 << 24) | (r << 16) | (g << 8) | b);
      }

      colors[0] = 0; //first color is transparent
      ApplyShadowRemap();
    }

    public ColorPalette AsSystemPalette()
    {
      if (colorPalette == null)
      {
        lock (cacheImage)
        {
          colorPalette = cacheImage.Palette;
        }
      }
      for (var i = 0; i < 256; i++)
        colorPalette.Entries[i] = GetColor(i);

      // hack around a mono bug -- the palette flags get set wrong.
      if (Environment.OSVersion.Platform != PlatformID.Win32NT)
        typeof(ColorPalette).GetField("flags",
            BindingFlags.Instance | BindingFlags.NonPublic).SetValue(colorPalette, 1);

      return colorPalette;
    }

    public static uint Value_From_Color(Color rgb)
    {
      byte r = rgb.R;
      byte g = rgb.G;
      byte b = rgb.B;
      return (uint)((255 << 24) | (r << 16) | (g << 8) | b);
    }
  }
}
