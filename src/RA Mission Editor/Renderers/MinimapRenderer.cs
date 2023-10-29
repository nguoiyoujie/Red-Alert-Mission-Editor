using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Drawing;

namespace RA_Mission_Editor.Renderers
{
  public static class MinimapRenderer
  {
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

    public static Color GetTemplateColor(Map map, MapCache cache, PalFile palFile, int x, int y)
    {
      int c = map.CellNumber(x, y);
      // template
      TemplateType tem = Templates.Get(map.MapPackSection.Template[c]);
      if (tem == null)
      {
        tem = Templates.Get(0);
      }
      Color color = palFile.GetColor(ColorRemaps.GetRadarColor(tem.LandType));

      bool hasOwnedEntity = false;
      foreach (IEntity v in map.Pick(x, y))
      {
        if (v is IOwnedEntity ov)
        {
          hasOwnedEntity = true;
          ColorType ctype = map.AttachedRules.Houses.GetHouse(ov.Owner).RulesSecondaryColor;
          if (ov.GetEntityType(map.AttachedRules) is StructureType sv)
          {
            ctype = map.AttachedRules.Houses.GetHouse(ov.Owner).RulesPrimaryColor;
            PalFile temp = RenderUtils.FetchHouseRemapPalette(cache, palFile, ctype);
            color = temp.GetColor(PalFile.DarkHouseColorIndex);
          }
          else
          {
            if (ov.GetEntityType(map.AttachedRules) is UnitType uv && uv.UsePrimaryColor)
            {
              ctype = map.AttachedRules.Houses.GetHouse(ov.Owner).RulesPrimaryColor;
            }
            PalFile temp = RenderUtils.FetchHouseRemapPalette(cache, palFile, ctype);
            color = temp.GetColor(PalFile.DarkHouseColorIndex);
          }
        }
      }

      if (!hasOwnedEntity && !map.IsCellInPlayArea(x, y))
      {
        color = Color.FromArgb(color.R / 2, color.G / 2, color.B / 2);
      }
      return color;
    }

    public static TileType GetTileType(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, int x, int y)
    {
      int c = map.CellNumber(x, y);
      TemplateType tem = Templates.Get(map.MapPackSection.Template[c]);
      // template
      if (tem == null)
      {
        tem = Templates.Get(0);
      }

      byte tile = map.MapPackSection.Tile[c];

      string tfile = tem.ID + tt.Extension;
      if (!cache.GetOrOpen(tfile, vfs, out TmpFile tmpFile))
      {
        throw new Exception($"Theater clear tile {tfile} does not exist!");
      }

      if (tmpFile.IsClearTile)
      {
        return tmpFile.TileTypes[0];
      }
      else
      {
        return tmpFile.TileTypes[tile];
      }
    }


    public static Color GetTileTypeColor(Map map, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, int x, int y)
    {
      TileType tilet = GetTileType(map, cache, vfs, tt, palFile, x, y);
      Color color = palFile.GetColor(ColorRemaps.GetTileColor(tilet));
      return color;
    }

    public static void DrawMinimap(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType _, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      for (int xc = 0; xc < map.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < map.Ext_MapSection.FullHeight; yc++)
        {
          if (cache.GetOrCreate(GetTemplateColor(map, cache, palFile, xc, yc), out Brush br))
            g.FillRectangle(br, xc, yc, 1, 1);
        }

      Region r = new Region(new Rectangle(0, 0, map.Ext_MapSection.FullWidth, map.Ext_MapSection.FullHeight));
      r.Exclude(new Rectangle(map.MapSection.X, map.MapSection.Y, map.MapSection.Width, map.MapSection.Height));
      if (cache.GetOrCreate(Color.FromArgb(80, Color.Black), out Brush brb))
      {
        g.FillRegion(brb, r);
      }
    }
  }
}
