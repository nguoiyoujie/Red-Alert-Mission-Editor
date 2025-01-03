using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace RA_Mission_Editor.Renderers
{
  static class RenderUtils
  {
    static public PalFile FetchHouseRemapPalette(MapCache c, PalFile p, ColorType color, bool applyshadow = true)
    {
      if (c != null && c.TryGet(p, color, out PalFile pal))
      {
        return pal;
      }

      Color[] remap = ColorRemaps.GetColorRemap(color);
      PalFile palFile = p.Clone();
      if (applyshadow)
      {
        palFile.ApplyShadowRemap();
      }
      if (remap != null)
      {
        palFile.ApplyHouseRemap(remap);
      }
      if (c != null)
      {
        c.Register(p, color, palFile);
      }
      return palFile;
    }

    static public PalFile FetchEntityRemapPalette(MapCache c, PalFile p, string key)
    {
      if (c != null && c.TryGet(p, key, out PalFile pal))
      {
        return pal;
      }

      byte[] swaplist = ColorRemaps.GetOverrideRemap(key);
      PalFile palFile = p.Clone();
      palFile.ApplySwapRemap(swaplist);
      if (c != null)
      {
        c.Register(p, key, palFile);
      }
      return palFile;
    }

    static public Bitmap RenderShp(MapCache c, ShpFile shp, PalFile p, int frameNumber)
    {
      if (c != null && c.TryGet(shp, p, out Bitmap[] frames))
      {
        return frameNumber < frames.Length ? frames[frameNumber] : null;
      }

      frames = new Bitmap[shp.Images.Count];
      for (int f = 0; f < shp.Images.Count; f++)
      {
        ShpFile.ShpImage frame = shp.Images[f];

        Bitmap bitmap = new Bitmap(shp.Width, shp.Height, PixelFormat.Format8bppIndexed);

        bitmap.Palette = p.AsSystemPalette();

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

        unsafe
        {
          byte* q = (byte*)data.Scan0.ToPointer();
          var stride2 = data.Stride;

          for (var i = 0; i < shp.Width; i++)
            for (var j = 0; j < shp.Height; j++)
              q[j * stride2 + i] = frame.Image[i + shp.Width * j];
        }

        bitmap.UnlockBits(data);
        frames[f] = bitmap;
      }

      if (c != null)
      {
        c.Register(shp, p, frames);
      }

      return frameNumber < frames.Length ? frames[frameNumber] : null;
    }

    public static Bitmap RenderTemplate(MapCache c, TmpFile tmp, PalFile p, int frameNumber)
    {
      if (c != null && c.TryGet(tmp, p, out Bitmap[] frames))
      {
        return frameNumber < frames.Length ? frames[frameNumber] : null;
      }

      frames = new Bitmap[tmp.Images.Count];
      for (int f = 0; f < tmp.Images.Count; f++)
      {
        Bitmap bitmap = new Bitmap(TmpFile.TileSize, TmpFile.TileSize,
          PixelFormat.Format8bppIndexed);

        bitmap.Palette = p.AsSystemPalette();

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

        unsafe
        {
          byte* q = (byte*)data.Scan0.ToPointer();
          int stride = data.Stride;

          if (tmp.Images[f] != null)
          {
            TmpFile.TmpImage rawImage = tmp.Images[f];
            for (int i = 0; i < TmpFile.TileSize; i++)
              for (int j = 0; j < TmpFile.TileSize; j++)
                q[j * stride + i] = rawImage.TileData[i + TmpFile.TileSize * j];
          }
          else
          {
            for (int i = 0; i < TmpFile.TileSize; i++)
              for (int j = 0; j < TmpFile.TileSize; j++)
                q[j * stride + i] = 0;
          }
        }

        bitmap.UnlockBits(data);
        frames[f] = bitmap;
      }

      if (c != null)
      {
        c.Register(tmp, p, frames);
      }

      return frameNumber < frames.Length ? frames[frameNumber] : null;
    }

    public static Bitmap RenderTemplate(MapCache c, TmpFile tmp, PalFile p, bool asSingleColor = false)
    {
      if (!asSingleColor)
      {
        if (c != null && c.TryGet(tmp, p, out Bitmap image))
        {
          return image;
        }

        // copies are above 1 for special CLEAR1 tiles and some tiles in INTERIOR
        int copies = tmp.Images.Count / tmp.BlockWidth / tmp.BlockHeight;
        int copies2 = 1;
        if (copies == 6)
        {
          copies2 = 2;
          copies = 3;
        }
        else if (copies > 6)
        {
          copies2 = (copies + 3) / 4;
          copies = 4;
        }

        Bitmap bitmap = new Bitmap(TmpFile.TileSize * tmp.BlockWidth * copies, TmpFile.TileSize * tmp.BlockHeight * copies2,
            PixelFormat.Format8bppIndexed);

        bitmap.Palette = p.AsSystemPalette();

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

        unsafe
        {
          byte* q = (byte*)data.Scan0.ToPointer();
          int stride = data.Stride;

          for (int w = 0; w < copies; w++)
            for (int w2 = 0; w2 < copies2; w2++)
              for (int u = 0; u < tmp.BlockWidth; u++)
                for (int v = 0; v < tmp.BlockHeight; v++)
                {
                  int index = w * tmp.BlockWidth + u + v * tmp.BlockWidth;
                  if (index < tmp.Images.Count && tmp.Images[index] != null)
                  {
                    TmpFile.TmpImage rawImage = tmp.Images[index];
                    for (int i = 0; i < TmpFile.TileSize; i++)
                      for (int j = 0; j < TmpFile.TileSize; j++)
                        q[((w2 + v) * TmpFile.TileSize + j) * stride + (w * tmp.BlockWidth + u) * TmpFile.TileSize + i] = rawImage.TileData[i + TmpFile.TileSize * j];
                  }
                  else
                  {
                    for (int i = 0; i < TmpFile.TileSize; i++)
                      for (int j = 0; j < TmpFile.TileSize; j++)
                        q[((w2 + v) * TmpFile.TileSize + j) * stride + (w * tmp.BlockWidth + u) * TmpFile.TileSize + i] = 0;
                  }
                }  
        }

        bitmap.UnlockBits(data);
        c.Register(tmp, p, bitmap);
        return bitmap;
      }
      else
      {
        int copies = tmp.Images.Count / tmp.BlockWidth / tmp.BlockHeight;
        int copies2 = 1;
        if (copies == 6)
        {
          copies2 = 2;
          copies = 3;
        }
        else if (copies > 6)
        {
          copies2 = (copies + 3) / 4;
          copies = 4;
        }

        Bitmap bitmap = new Bitmap(tmp.Width * tmp.BlockWidth * copies, tmp.Height * tmp.BlockHeight * copies2);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          StringFormat textStringFormat = StringFormat.GenericTypographic;
          textStringFormat.Alignment = StringAlignment.Center;
          textStringFormat.LineAlignment = StringAlignment.Center;
          textStringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip;

          for (int w = 0; w < copies; w++)
            for (int w2 = 0; w2 < copies2; w2++)
              for (int u = 0; u < tmp.BlockWidth; u++)
                for (int v = 0; v < tmp.BlockHeight; v++)
                {
                  int index = w * tmp.BlockWidth + u + v * tmp.BlockWidth;
                  if (index < tmp.Images.Count && tmp.Images[index] != null)
                  {
                    c.GetOrCreate(p.GetColor(ColorRemaps.GetTileColor(tmp.TileTypes[(w2 * w * tmp.BlockWidth + u + v * tmp.BlockWidth) % tmp.TileTypes.Count])), out Brush br);
                    RectangleF rect = new RectangleF((w + u) * tmp.Width, (w2 + v) * tmp.Height, tmp.Width, tmp.Height);

                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.FillRectangle(br, rect);
                    g.DrawString(((int)tmp.TileTypes[(w2 * w * tmp.BlockWidth + u + v * tmp.BlockWidth) % tmp.TileTypes.Count]).ToString("X1"), MapUserThemes.ControlTextFont, Brushes.Black, rect, textStringFormat);
                  }
                }
        }
        return bitmap;
      }
    }
  }
}
