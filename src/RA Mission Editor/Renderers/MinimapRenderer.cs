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

    public static Color PutPixel(Map map, MapCache cache, PalFile palFile, int x, int y)
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

    public static void DrawMinimap(Map map, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType _, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      for (int xc = 0; xc < map.Ext_MapSection.FullWidth; xc++)
        for (int yc = 0; yc < map.Ext_MapSection.FullHeight; yc++)
        {
          if (cache.GetOrCreate(PutPixel(map, cache, palFile, xc, yc), out Brush br))
            g.FillRectangle(br, xc, yc, 1, 1);
        }
    }
  }
}
