using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace RA_Mission_Editor.Renderers
{
  public static class EnvironmentRenderer
  {
    private static ColorMatrix _highlightMatrix = new ColorMatrix()
    {
      Matrix00 = 1.5f,
      Matrix11 = 1.5f,
      Matrix22 = 1.5f,
      Matrix33 = 1f,
      Matrix04 = 25f,
      Matrix14 = 25f,
      Matrix24 = 25f,
      Matrix44 = 1f,
    };
    private static ImageAttributes _highlightImageAttributes = new ImageAttributes();

    static EnvironmentRenderer()
    {
      _highlightImageAttributes.SetColorMatrix(_highlightMatrix, ColorMatrixFlag.Default, ColorAdjustType.Default);
    }

    public static void CheckTheatre(Map map, MapCache cache, VirtualFileSystem vfs, out TheaterType tt, out PalFile palFile)
    {
      string ts = map.MapSection.Theater.ToUpperInvariant();
      tt = Theaters.GetTheater(ts);
      if (tt.Equals(default(TheaterType)))
      {
        throw new Exception($"Invalid theater {ts} detected!");
      }

      string tpal = tt.ShortName + ".pal";
      if (!cache.GetOrOpen(tpal, vfs, out palFile))
      {
        throw new Exception($"Theater palette {tpal} does not exist!");
      }
    }

    public static void DrawTemplates(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g, bool asSingleColor)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      string tclear = Templates.Get(0).ID + tt.Extension;
      if (!cache.GetOrOpen(tclear, vfs, out TmpFile cleartmpFile))
      {
        throw new Exception($"Theater clear tile {tclear} does not exist!");
      }

      for (int xc = 0; xc < map.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < map.Ext_MapSection.FullHeight; yc++)
        {
          int c = map.CellNumber(xc, yc);
          TemplateType tem = Templates.Get(map.MapPackSection.Template[c]);
          Bitmap bmp = null;

          if (asSingleColor)
          {
            if (cache.GetOrCreate(MinimapRenderer.GetTileTypeColor(map, cache, vfs, tt, palFile, xc, yc), out Brush br))
            {
              g.FillRectangle(br, new RectangleF(xc * Constants.CELL_PIXEL_W, yc * Constants.CELL_PIXEL_H, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H));
            }
          }
          else
          {
            if (tem != null && cache.GetOrOpen(tem.ID + tt.Extension, vfs, out TmpFile tmpFile))
            {
              // fetch bitmap
              // if this is a clear tile (ID=0), the template has multiple tiles, pseudo-randomize them according to Clear_Icon() in
              // https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/TIBERIANDAWN/CELL.CPP
              int tile = map.MapPackSection.Template[c] == 0 ? map.ClearIcon(c) : map.MapPackSection.Tile[c];
              bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, tile);
            }
            else if (map.MapPackSection.Template[c] != 0xFFFF) // meant to have something, but does not exist in the definitions
            {
              // just warn, but draw the clear tile anyway
              // !!! Performance expensive when several cells have this issue, better to move this out to an explicit check function...
              Debug.WriteLine($"Template 'ID {map.OverlayPackSection.Overlay[c]}' at cell {{{map.CellX(c)},{map.CellY(c)}}} does not exist!");
            }

            // either the tile in the template does not exist, or the template does not exist (e.g. ID is 0xFFFF)
            if (bmp == null)
            {
              // use the clear tile
              int tile = map.ClearIcon(c);
              bmp = RenderUtils.RenderTemplate(cache, cleartmpFile, palFile, tile);
            }

            // draw
            g.DrawImage(bmp, xc * Constants.CELL_PIXEL_W, yc * Constants.CELL_PIXEL_H);
          }
        }
    }

    public static void DrawTemplates(Map map, MapExtract extract, int xoffset, int yoffset, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      string tclear = Templates.Get(0).ID + tt.Extension;
      if (!cache.GetOrOpen(tclear, vfs, out TmpFile cleartmpFile))
      {
        throw new Exception($"Theater clear tile {tclear} does not exist!");
      }

      for (int xc = 0; xc < extract.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < extract.Ext_MapSection.FullHeight; yc++)
        {
          int c = extract.CellNumber(xc, yc);
          TemplateType tem = Templates.Get(extract.MapPackSection.Template[c]);
          Bitmap bmp = null;

          if (tem != null && cache.GetOrOpen(tem.ID + tt.Extension, vfs, out TmpFile tmpFile))
          {
            // fetch bitmap
            // if this is a clear tile (ID=0), the template has multiple tiles, pseudo-randomize them according to Clear_Icon() in
            // https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/TIBERIANDAWN/CELL.CPP
            int tile = extract.MapPackSection.Template[c] == 0 ? map.ClearIcon(c) : extract.MapPackSection.Tile[c];
            bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, tile);
          }
          else if (extract.MapPackSection.Template[c] != 0xFFFF) // meant to have something, but does not exist in the definitions
          {
            // just warn, but draw the clear tile anyway
            // !!! Performance expensive when several cells have this issue, better to move this out to an explicit check function...
            Debug.WriteLine($"Template 'ID {extract.OverlayPackSection.Overlay[c]}' at cell {{{extract.CellX(c)},{extract.CellY(c)}}} does not exist!");
          }

          // for map extracts, draw only if an identified template exists. This means don't draw 0xFFFF as clear
          if (bmp != null && map.IsCellInMap(xoffset + xc, yoffset + yc))
          {
            g.DrawImage(bmp, (xoffset + xc) * Constants.CELL_PIXEL_W, (yoffset + yc) * Constants.CELL_PIXEL_H);
          }
        }
    }

    public static void DrawTemplate(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, int numID, bool highlight = false)
    {
      Bitmap bmp = null;
      if (cache.GetOrOpen(typeID + tt.Extension, vfs, out TmpFile tmpFile))
      {
        int c = map.CellNumber(x, y);
        // fetch bitmap
        // if this is a clear tile (ID=0), the template has multiple tiles, pseudo-randomize them according to Clear_Icon() in
        // https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/TIBERIANDAWN/CELL.CPP
        if (Templates.GetID(typeID) == 0)
        {
          bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, map.ClearIcon(c));
        }
        else
        {
          if (numID != 0xFF)
          {
            bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, numID);
          }
          else
          {
            bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile);
          }
        }

      }
      if (bmp != null)
      {
        if (highlight)
        {
          Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
          g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
        }
        else
        {
          g.DrawImage(bmp, x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H);
        }
      }
    }

    public static void DrawOverlays(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      for (int xc = 0; xc < map.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < map.Ext_MapSection.FullHeight; yc++)
        {
          int c = map.CellNumber(xc, yc);
          OverlayType ovl = Overlays.Get(map.OverlayPackSection.Overlay[c]);

          if (ovl != null &&
             (cache.GetOrOpen(ovl.ID + tt.Extension, vfs, out ShpFile shpFile) ||
              cache.GetOrOpen(ovl.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
          {
            // check for Ore, Gem and Ore, and precalculate frame number?
            int tile = 0;
            switch (ovl.SubType)
            {
              case OverlaySubType.WALL:
                tile = map.GetWallOverlayData(c);
                break;
              case OverlaySubType.GOLD:
                tile = map.GetOreOverlayData(c);
                break;
              case OverlaySubType.GEM:
                tile = map.GetGemOverlayData(c);
                break;
              default:
              case OverlaySubType.NONE:
                break;
            }
            if (shpFile.Images.Count <= tile)
            { tile = 0; }

            Bitmap bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile);
            if (bmp != null)
            {
              // draw
              g.DrawImage(bmp, xc * Constants.CELL_PIXEL_W, yc * Constants.CELL_PIXEL_H);
            }
          }
          else if (map.OverlayPackSection.Overlay[c] != 0xFF) // meant to have something, but does not exist in the definitions
          {
            Debug.WriteLine($"Overlay 'ID {map.OverlayPackSection.Overlay[c]}' at cell {{{map.CellX(c)},{map.CellY(c)}}} does not exist!");
          }
        }
    }

    public static void DrawOverlays(Map map, MapExtract extract, int xoffset, int yoffset, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      for (int xc = 0; xc < extract.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < extract.Ext_MapSection.FullHeight; yc++)
        {
          int c = extract.CellNumber(xc, yc);
          OverlayType ovl = Overlays.Get(extract.OverlayPackSection.Overlay[c]);

          if (ovl != null &&
             (cache.GetOrOpen(ovl.ID + tt.Extension, vfs, out ShpFile shpFile) ||
              cache.GetOrOpen(ovl.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
          {
            // check for Ore, Gem and Ore, and precalculate frame number?
            int tile = 0;
            switch (ovl.SubType)
            {
              case OverlaySubType.WALL:
                tile = extract.GetWallOverlayData(c);
                break;
              case OverlaySubType.GOLD:
                tile = extract.GetOreOverlayData(c);
                break;
              case OverlaySubType.GEM:
                tile = extract.GetGemOverlayData(c);
                break;
              default:
              case OverlaySubType.NONE:
                break;
            }
            if (shpFile.Images.Count <= tile)
            { tile = 0; }

            Bitmap bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile);
            if (bmp != null && map.IsCellInMap(xoffset + xc, yoffset + yc))
            {
              // draw
              g.DrawImage(bmp, (xoffset + xc) * Constants.CELL_PIXEL_W, (yoffset + yc) * Constants.CELL_PIXEL_H);
            }
          }
          else if (extract.OverlayPackSection.Overlay[c] != 0xFF) // meant to have something, but does not exist in the definitions
          {
            Debug.WriteLine($"Overlay 'ID {extract.OverlayPackSection.Overlay[c]}' at cell {{{extract.CellX(c)},{extract.CellY(c)}}} does not exist!");
          }
        }
    }

    public static void DrawOverlay(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, bool highlight = false)
    {
      Bitmap bmp = null;
      if (cache.GetOrOpen(typeID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(typeID + ".SHP", vfs, out shpFile))
      {
        bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
      }
      if (bmp != null)
      {
        if (highlight)
        {
          Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
          g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
        }
        else
        {
          g.DrawImage(bmp, x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H);
        }
      }
    }

    public static void DrawTerrainObjects(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      DrawOverlays(map, cache, vfs, g);
      DrawSmudges(map, cache, vfs, g);
      DrawTerrain(map, cache, vfs, g);
    }

    public static void DrawTerrainObjects(Map map, MapExtract extract, int xoffset, int yoffset, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      DrawOverlays(map, extract, xoffset, yoffset, cache, vfs, g);
      DrawSmudges(map, extract, xoffset, yoffset, cache, vfs, g);
      DrawTerrain(map, extract, xoffset, yoffset, cache, vfs, g);
    }

    public static void DrawSmudges(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var sInfo in map.SmudgeSection.EntityList)
      {
        int c = sInfo.Cell;
        SmudgeType smg = Smudges.Get(sInfo.ID);
        Bitmap bmp;

        if (smg != null &&
           (cache.GetOrOpen(smg.ID + tt.Extension, vfs, out ShpFile shpFile) ||
            cache.GetOrOpen(smg.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
        {
          int tile = 0;
          for (int yd = 0; yd < smg.BlockHeight; yd++)
            for (int xd = 0; xd < smg.BlockWidth; xd++)
            {
              bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
              if (bmp != null)
              {
                // draw
                g.DrawImage(bmp, (map.CellX(c) + xd) * Constants.CELL_PIXEL_W, (map.CellY(c) + yd) * Constants.CELL_PIXEL_H);
              }
            }
        }
        else
        {
          Debug.WriteLine($"Smudge '{sInfo.ID}' at cell {{{map.CellX(c)},{map.CellY(c)}}} does not exist!");
        }
      }
    }

    public static void DrawSmudges(Map map, MapExtract extract, int xoffset, int yoffset, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var sInfo in extract.SmudgeSection.EntityList)
      {
        int c = sInfo.Cell;
        SmudgeType smg = Smudges.Get(sInfo.ID);
        Bitmap bmp;

        if (smg != null &&
           (cache.GetOrOpen(smg.ID + tt.Extension, vfs, out ShpFile shpFile) ||
            cache.GetOrOpen(smg.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
        {
          int tile = 0;
          for (int yd = 0; yd < smg.BlockHeight; yd++)
            for (int xd = 0; xd < smg.BlockWidth; xd++)
            {
              bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
              if (bmp != null && map.IsCellInMap(xoffset + xd + extract.CellX(c), yoffset + yd + extract.CellY(c)))
              {
                // draw
                g.DrawImage(bmp, (extract.CellX(c) + xd + xoffset) * Constants.CELL_PIXEL_W, (extract.CellY(c) + yd + yoffset) * Constants.CELL_PIXEL_H);
              }
            }
        }
        else
        {
          Debug.WriteLine($"Smudge '{sInfo.ID}' at cell {{{extract.CellX(c)},{extract.CellY(c)}}} does not exist!");
        }
      }
    }

    public static void DrawSmudge(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, int block_x, int block_y, bool highlight = false)
    {
      Bitmap bmp = null;
      if (cache.GetOrOpen(typeID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(typeID + ".SHP", vfs, out shpFile))
      {
        int tx = block_x;
        int ty = block_y;
        if (tx == 1 && ty == 1)
        {
          bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
        }
        else
        {
          bmp = new Bitmap(tx * Constants.CELL_PIXEL_W, ty * Constants.CELL_PIXEL_H);
          using (Graphics gb = Graphics.FromImage(bmp))
          {
            int tile = 0;
            for (int yd = 0; yd < ty; yd++)
              for (int xd = 0; xd < tx; xd++)
              {
                Bitmap b = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
                if (b != null)
                {
                  // draw
                  gb.DrawImage(b, xd * Constants.CELL_PIXEL_W, yd * Constants.CELL_PIXEL_H);
                }
              }
          }
        }
      }
      if (bmp != null)
      {
        if (highlight)
        {
          Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
          g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
        }
        else
        {
          g.DrawImage(bmp, x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H);
        }
      }
      bmp?.DisposeIfNotCached();
    }

    public static void GetTerrainSizeInCells(MapCache cache, VirtualFileSystem vfs, TheaterType tt, string typeID, out int x, out int y)
    {
      x = 1;
      y = 1;

      TerrainType terr = Terrains.Get(typeID);
      if (terr != null && cache.TryGet(terr, out Size sz))
      {
        x = sz.Width;
        y = sz.Height;
        return;
      }

      if (terr != null &&
         (cache.GetOrOpen(terr.ID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(terr.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
      {
        x = shpFile.Width / Constants.CELL_PIXEL_W;
        y = shpFile.Height / Constants.CELL_PIXEL_H;
        cache.Register(terr, new Size(x, y));
      }
    }

    public static void DrawTerrain(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in map.TerrainSection.EntityList)
      {
        int c = tInfo.Cell;
        TerrainType terr = Terrains.Get(tInfo.ID);
        if (terr != null &&
            (cache.GetOrOpen(terr.ID + tt.Extension, vfs, out ShpFile shpFile) ||
            cache.GetOrOpen(terr.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
        {
          int tile = 0;
          Bitmap bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile);
          if (bmp != null)
          {
            // draw
            g.DrawImage(bmp, map.CellX(c) * Constants.CELL_PIXEL_W, map.CellY(c) * Constants.CELL_PIXEL_H);
          }
        }
        else
        {
          Debug.WriteLine($"Terrain '{tInfo.ID}' at cell {{{map.CellX(c)},{map.CellY(c)}}} does not exist!");
        }
      }
    }

    public static void DrawTerrain(Map map, MapExtract extract, int xoffset, int yoffset, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in extract.TerrainSection.EntityList)
      {
        int c = tInfo.Cell;
        TerrainType terr = Terrains.Get(tInfo.ID);
        if (terr != null &&
            (cache.GetOrOpen(terr.ID + tt.Extension, vfs, out ShpFile shpFile) ||
            cache.GetOrOpen(terr.ID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
        {
          int tile = 0;
          Bitmap bmp = RenderUtils.RenderShp(cache, shpFile, palFile, tile);
          if (bmp != null && map.IsCellInMap(xoffset + map.CellX(c), yoffset + map.CellY(c)))
          {
            // draw
            g.DrawImage(bmp, (xoffset + extract.CellX(c)) * Constants.CELL_PIXEL_W, (yoffset + extract.CellY(c)) * Constants.CELL_PIXEL_H);
          }
        }
        else
        {
          Debug.WriteLine($"Terrain '{tInfo.ID}' at cell {{{extract.CellX(c)},{extract.CellY(c)}}} does not exist!");
        }
      }
    }

    public static void DrawTerrain(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, bool highlight = false)
    {
      Bitmap bmp = null;
      if (cache.GetOrOpen(typeID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(typeID + ".SHP", vfs, out shpFile))
      {
        bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
      }
      if (bmp != null)
      {
        if (highlight)
        {
          Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
          g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
        }
        else
        {
          g.DrawImage(bmp, x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H);
        }
      }
    }
  }
}
