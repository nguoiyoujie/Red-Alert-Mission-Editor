﻿using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace RA_Mission_Editor.Renderers
{
  public static class TechnoTypeRenderer
  {
    private static StringFormat _triggerTagStringFormat;
    private static StringFormat _fakeStringFormat;

    private static ColorMatrix _translucentMatrix = new ColorMatrix()
    {
      Matrix03 = 0.9f,
      Matrix13 = 0.01f,
      Matrix23 = 0.1f,
      Matrix33 = 0.01f,
      Matrix43 = 0.01f,
    };
    private static ImageAttributes _translucentImageAttributes = new ImageAttributes();

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

    private static ColorMatrix _translucenthighlightMatrix = new ColorMatrix()
    {
      Matrix00 = 1.5f,
      Matrix11 = 1.5f,
      Matrix22 = 1.5f,
      Matrix03 = 0.9f,
      Matrix13 = 0.01f,
      Matrix23 = 0.1f,
      Matrix33 = 0.01f,
      Matrix43 = 0.01f,
      Matrix04 = 25f,
      Matrix14 = 25f,
      Matrix24 = 25f,
      Matrix44 = 1f,
    };
    private static ImageAttributes _translucenthighlightImageAttributes = new ImageAttributes();

    private static List<Point> _cachePlacement = new List<Point>();
    private static List<Point> _cachePlacement2 = new List<Point>();

    static TechnoTypeRenderer()
    {
      _triggerTagStringFormat = new StringFormat(StringFormat.GenericTypographic);
      _fakeStringFormat = new StringFormat(StringFormat.GenericTypographic);

      _translucentImageAttributes.SetColorMatrix(_translucentMatrix, ColorMatrixFlag.Default, ColorAdjustType.Default);
      _highlightImageAttributes.SetColorMatrix(_highlightMatrix, ColorMatrixFlag.Default, ColorAdjustType.Default);
      _translucenthighlightImageAttributes.SetColorMatrix(_translucenthighlightMatrix , ColorMatrixFlag.Default, ColorAdjustType.Default);

      _triggerTagStringFormat.Alignment = StringAlignment.Center;
      _triggerTagStringFormat.LineAlignment = StringAlignment.Center;
      _triggerTagStringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip;

      _fakeStringFormat.Alignment = StringAlignment.Center;
      _fakeStringFormat.LineAlignment = StringAlignment.Near;
      _fakeStringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip;
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

    public static void DrawBibs(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      DrawBaseBibs(map, rules, cache, vfs, g);
      DrawBuildingBibs(map, rules, cache, vfs, g);
    }

    public static void DrawBuildingTechnoTypes(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      DrawBases(map, rules, cache, vfs, g);
      DrawBuildings(map, rules, cache, vfs, g);
    }

    public static void DrawTechnoTypesExcludingBuildings(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      DrawUnits(map, rules, cache, vfs, g);
      DrawVessels(map, rules, cache, vfs, g);
      DrawInfantries(map, rules, cache, vfs, g);
    }

    public static void DrawBaseBibs(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in map.BaseSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);

        DrawBuildingBib(map, rules, cache, vfs, tt, palFile, tInfo.ID, g, x, y, true);
      }
    }

    public static void DrawBuildingBibs(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in map.BuildingSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);

        DrawBuildingBib(map, rules, cache, vfs, tt, palFile, tInfo.ID, g, x, y, false);
      }
    }

    public static void DrawBuildingBibs(Map map, MapExtract extract, int xoffset, int yoffset, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in extract.BuildingSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = xoffset + extract.CellX(c);
        int y = yoffset + extract.CellY(c);

        DrawBuildingBib(map, rules, cache, vfs, tt, palFile, tInfo.ID, g, x, y, false);
      }
    }

    private static void FillOccupancyGrid(List<Point> grid, MapCache cache, VirtualFileSystem vfs, TheaterType tt, BuildingType stype, bool includeBib)
    {
      if (stype == null)
      {
        return;
      }
      grid.Clear();
      grid.AddRange(stype.Occupancy);
      int ycOffset = 0;
      string bibName = null;
      if (includeBib)
      {
        string imageID = stype.RulesImage;
        if (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile buildingShpFile) || cache.GetOrOpen(imageID + ".SHP", vfs, out buildingShpFile)) // template extension provided no files, try .shp instead
        {
          ycOffset = buildingShpFile.Height / Constants.CELL_PIXEL_H - 1;
          bibName = stype.BibName;
        }
      }

      if (bibName != null)
      {
        SmudgeType smd = Smudges.Get(bibName);
        int tx = 1;
        int ty = 1;
        if (stype != null)
        {
          tx = smd.BlockWidth;
          ty = smd.BlockHeight;
        }

        for (int yd = 0; yd < ty; yd++)
          for (int xd = 0; xd < tx; xd++)
          {
            Point p = new Point(xd, yd + ycOffset);
            if (!grid.Contains(p))
            {
              grid.Add(p);
            }
          }
      }
    }

    private static void FillOccupancyGrid(List<Point> grid, TerrainType ttype)
    {
      if (ttype == null)
      {
        return;
      }
      grid.Clear();
      grid.AddRange(ttype.Occupancy);
    }

    public static void DrawPlacementGrid(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, bool includeBib)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp;
      BuildingType stype = rules.Buildings.Get(typeID);
      FillOccupancyGrid(_cachePlacement, cache, vfs, tt, stype, includeBib);

      if (cache.GetOrOpen("TRANS.ICN", vfs, out TmpFile tmpFile))
      {
        foreach (Point p in _cachePlacement)
        {
          bool clear = true;
          if (map.IsCellInMap(x + p.X, y + p.Y))
          {
            if (MinimapRenderer.IsTemplateBridge(map, x + p.X, y + p.Y))
            {
              clear = false;
            }
            if (clear)
            {
              TileType tilet = MinimapRenderer.GetTileType(map, cache, vfs, tt, palFile, x + p.X, y + p.Y);
              switch (tilet)
              {
                case TileType.BEACH_6:
                case TileType.ROCK_8:
                //case TileType.ROAD_9:
                case TileType.RIVER_B:
                case TileType.ROUGH_E:
                  clear = false;
                  break;
                case TileType.WATER_A:
                  clear = stype.IsNaval;
                  break;
                default:
                  clear = !stype.IsNaval;
                  break;
              }
            }
            if (clear)
            {
              foreach (IEntity e in map.MapOccupancyList.Pick(map, x + p.X, y + p.Y))
              {
                IEntityType etype = e.GetEntityType(rules);
                if (etype is InfantryType || etype is UnitType || etype is VesselType || etype is AircraftType || etype is OverlayType)
                {
                  // each of these occupy the exact tile
                  clear = false;
                  break;
                }
                else if (etype is TerrainType trt && e is TerrainInfo tinfo)
                {
                  FillOccupancyGrid(_cachePlacement2, trt);
                  int x2 = map.CellX(tinfo.Cell);
                  int y2 = map.CellY(tinfo.Cell);
                  Point poff = new Point(x + p.X - x2, y + p.Y - y2);
                  if (_cachePlacement2.Contains(poff))
                  {
                    clear = false;
                    break;
                  }
                }
                else if (etype is BuildingType st && e is BuildingInfo sinfo)
                {
                  FillOccupancyGrid(_cachePlacement2, cache, vfs, tt, st, includeBib);
                  int x2 = map.CellX(sinfo.Cell);
                  int y2 = map.CellY(sinfo.Cell);
                  Point poff = new Point(x + p.X - x2, y + p.Y - y2);
                  if (_cachePlacement2.Contains(poff))
                  {
                    clear = false;
                    break;
                  }
                }
              }
            }
            if (clear)
            {
              bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, 0);
            }
            else
            {
              bmp = RenderUtils.RenderTemplate(cache, tmpFile, palFile, 2);
            }
            if (bmp != null)
            {
              Rectangle rd = new Rectangle((x + p.X) * Constants.CELL_PIXEL_W, (y + p.Y) * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
              g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _translucenthighlightImageAttributes);
            }
          }
        }
      }
    }

    public static void DrawBuildingBib(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, Graphics g, int x, int y, bool translucent, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp;
      BuildingType stype = rules.Buildings.Get(typeID);
      if (stype == null)
      {
        // don't draw anything; the main building will be handled by DrawBuilding()
        return;
      }
      string imageID = stype.RulesImage;

      if (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile buildingShpFile) ||
          cache.GetOrOpen(imageID + ".SHP", vfs, out buildingShpFile)) // template extension provided no files, try .shp instead
      {
        // get SHP info of the main building
        int yOffset = buildingShpFile.Height - Constants.CELL_PIXEL_H;
        string bibName = stype.BibName;

        if (bibName != null)
        {
          if (cache.GetOrOpen(bibName + tt.Extension, vfs, out ShpFile bibShpFile) ||
            cache.GetOrOpen(bibName + ".SHP", vfs, out bibShpFile)) // template extension provided no files, try .shp instead
          {
            int tile = 0;
            SmudgeType smd = Smudges.Get(bibName);
            int tx = 1;
            int ty = 1;
            if (stype != null)
            {
              tx = smd.BlockWidth;
              ty = smd.BlockHeight;
            }
            for (int yd = 0; yd < ty; yd++)
              for (int xd = 0; xd < tx; xd++)
              {
                bmp = RenderUtils.RenderShp(cache, bibShpFile, palFile, tile++);
                if (bmp != null)
                {
                  // draw
                  if (translucent && highlight)
                  {
                    Rectangle rd = new Rectangle((x + xd) * Constants.CELL_PIXEL_W, (y + yd) * Constants.CELL_PIXEL_H + yOffset, bmp.Width, bmp.Height);
                    g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _translucenthighlightImageAttributes);
                  }
                  else if (translucent)
                  {
                    Rectangle rd = new Rectangle((x + xd) * Constants.CELL_PIXEL_W, (y + yd) * Constants.CELL_PIXEL_H + yOffset, bmp.Width, bmp.Height);
                    g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _translucentImageAttributes);
                  }
                  else if (highlight)
                  {
                    Rectangle rd = new Rectangle((x + xd) * Constants.CELL_PIXEL_W, (y + yd) * Constants.CELL_PIXEL_H + yOffset, bmp.Width, bmp.Height);
                    g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
                  }
                  else
                  {
                    g.DrawImage(bmp, (x + xd) * Constants.CELL_PIXEL_W, (y + yd) * Constants.CELL_PIXEL_H + yOffset);
                  }
                }
              }
          }
        }
      }
    }

    public static void DrawBases(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      foreach (var tInfo in map.BaseSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = rules.Houses.GetHouse(map.BaseSection.Player);
        int index = map.BaseSection.EntityList.IndexOf(tInfo);

        DrawBuilding(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, 256, 0, g, x, y, null, index, true);
      }
    }

    public static void DrawBuildings(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      foreach (var tInfo in map.BuildingSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawBuilding(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Health, tInfo.Facing, g, x, y, tInfo.Tag, -1, false);
      }
    }

    public static void DrawBuildings(Map map, MapExtract extract, int xoffset, int yoffset, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      foreach (var tInfo in extract.BuildingSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = xoffset + extract.CellX(c);
        int y = yoffset + extract.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawBuilding(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Health, tInfo.Facing, g, x, y, tInfo.Tag, -1, false);
      }
    }

    public static void GetBuildingSizeInCells(Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, string typeID, bool includeBib, out int x, out int y)
    {
      x = 1;
      y = 1;

      BuildingType stype = rules.Buildings.Get(typeID);
      if (stype == null)
      {
        return;
      }

      // ignore the second Image
      if (cache.TryGet(stype, out Size sz))
      {
        x = sz.Width;
        y = sz.Height;
        return;
      }

      if (stype != null &&
         (cache.GetOrOpen(stype.RulesImage + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(stype.RulesImage + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
      {
        x = shpFile.Width / Constants.CELL_PIXEL_W + (shpFile.Width % Constants.CELL_PIXEL_W == 0 ? 0 : 1);
        y = shpFile.Height / Constants.CELL_PIXEL_H + (shpFile.Height % Constants.CELL_PIXEL_H == 0 ? 0 : 1);

        if (includeBib && stype.BibName != null)
        {
          y++;
        }
        cache.Register(stype, new Size(x, y));
      }
    }

    public static void GetBuildingSizeInPixels(Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, string typeID, out int x, out int y)
    {
      x = Constants.CELL_PIXEL_W;
      y = Constants.CELL_PIXEL_H;

      BuildingType stype = rules.Buildings.Get(typeID);
      // ignore the second Image

      if (stype != null &&
         (cache.GetOrOpen(stype.RulesImage + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(stype.RulesImage + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
      {
        x = shpFile.Width;
        y = shpFile.Height;
      }
    }

    private static void DrawBuildingInner(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, BuildingType stype, string imageID, HouseType owner, int health, int facing, Graphics g, int x, int y, bool translucent, bool highlight, ref Bitmap bmp)
    {
      if (stype != null && 
         (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(imageID + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
      {
        ColorType color = stype.UseNeutralRemap ? rules.Houses.GetNeutralHouse().RulesPrimaryColor : owner.RulesPrimaryColor;
        PalFile hpalFile = RenderUtils.FetchHouseRemapPalette(cache, palFile, color);
        int tile = health < 128 ? shpFile.Images.Count / 2 : 0;
        if (stype.TurretDirections > 0)
        {
          int dir = (256 - facing) % 256 / (256 / stype.TurretDirections);
          tile += dir;
        }
        bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, tile);

        if (bmp != null)
        {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
          g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
          g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;


          if (translucent && highlight)
          {
            Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _translucenthighlightImageAttributes);
          }
          else if (translucent)
          {
            Rectangle rd = new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _translucentImageAttributes);
          }
          else if (highlight)
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
      else
      {
        DrawUnknownObject(cache, palFile, g, x, y);
      }
    }

    public static void DrawBuilding(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, HouseType owner, int health, int facing, Graphics g, int x, int y, string tag, int baseListIndex, bool translucent, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp = null;
      BuildingType stype = rules.Buildings.Get(typeID);
      if (stype != null)
      {
        // avoid array allocation in this function
        DrawBuildingInner(map, rules, cache, vfs, tt, palFile, stype, stype.RulesImage, owner, health, facing, g, x, y, translucent, highlight, ref bmp);
        // account for buildings with second Image
        if (stype.SecondImage != null && !stype.SecondImage.Equals("none", StringComparison.OrdinalIgnoreCase))
        {
          DrawBuildingInner(map, rules, cache, vfs, tt, palFile, stype, stype.SecondImage, owner, health, facing, g, x, y, translucent, highlight, ref bmp);
        }
      }
      else
      {
        Debug.WriteLine($"Building '{typeID}' at cell {new Point(x, y)} does not exist!");
        DrawUnknownObject(cache, palFile, g, x, y);
        return;
      }

      // draw text
      Rectangle r = bmp != null ? new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, bmp.Width, bmp.Height) : new Rectangle(x * Constants.CELL_PIXEL_W, y * Constants.CELL_PIXEL_H, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      if (stype.IsFake)
      {
        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        g.DrawString("FAKE", MapUserThemes.TechnoTypeFakeFont, MapUserThemes.TechnoTypeFakeBrush, r, _fakeStringFormat);
      }

      if (tag != null && tag.ToUpperInvariant() != "NONE")
      {
        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        SizeF size = g.MeasureString(tag, MapUserThemes.TechnoTypeTagFont, r.Size, _triggerTagStringFormat);
        g.FillRectangle(MapUserThemes.TechnoTypeTagBackgroundBrush, new RectangleF(r.Location.X + r.Size.Width / 2 - size.Width / 2, r.Location.Y + r.Size.Height / 2 - size.Height / 2, size.Width, size.Height));
        g.DrawString(tag, MapUserThemes.TechnoTypeTagFont, MapUserThemes.TechnoTypeTagBrush, r, _triggerTagStringFormat);
      }

      if (baseListIndex != -1)
      {
        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        g.DrawString(baseListIndex.ToString("000"), MapUserThemes.BaseNumberFont, MapUserThemes.BaseNumberBrush, r, _triggerTagStringFormat);
      }
    }

    public static void DrawUnits(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in map.UnitSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawUnit(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Facing, g, x, y, tInfo.Tag);
      }
    }

    public static void DrawUnits(Map map, MapExtract extract, int xoffset, int yoffset, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in extract.UnitSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = xoffset + extract.CellX(c);
        int y = yoffset + extract.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawUnit(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Facing, g, x, y, tInfo.Tag);
      }
    }

    public static void DrawUnknownObject(MapCache cache, PalFile palFile, Graphics g, int x, int y)
    {
      if (Globals.UnknownObjectShp != null)
      {
        Bitmap bmp = RenderUtils.RenderShp(cache, Globals.UnknownObjectShp, palFile, 0);
        int xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
        int yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);

        if (bmp != null)
        {
          // draw centered
          g.DrawImage(bmp, xd, yd);
        }
      }
    }

    public static void DrawUnit(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, HouseType owner, int facing, Graphics g, int x, int y, string tag, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp;
      UnitType ttype = rules.Units.Get(typeID);
      if (ttype == null)
      {
        DrawUnknownObject(cache, palFile, g, x, y);
        return;
      }
      // get Image=

      if (ttype != null
        && (cache.GetOrOpen(ttype.RulesImage + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(ttype.RulesImage + ".SHP", vfs, out shpFile))) // template extension provided no files, try .shp instead
      {
        // check if unit is harvester or MCV
        ColorType color;
        if (ttype.UsePrimaryColor)
        {
          color = owner.RulesPrimaryColor;
        }
        else
        {
          color = owner.RulesSecondaryColor;
        }

        PalFile hpalFile = RenderUtils.FetchHouseRemapPalette(cache, palFile, color);
        // 32 directions
        int dir = ttype.Directions == 0 ? 0 : (256 - facing) % 256 / (256 / ttype.Directions);
        bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);
        int xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
        int yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);

        if (bmp != null)
        {
          if (highlight)
          {
            Rectangle rd = new Rectangle(xd, yd, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
          }
          else
          {
            g.DrawImage(bmp, xd, yd);
          }
        }

        if (ttype.TurretLocations != null) // all units use the same SHP for turrets
        {
          for (int i = 0; i < ttype.TurretLocations.Length; i++)
          {
            Bitmap turrbmp = null;
            var turrLoc = ttype.TurretLocations[i];
            if (turrLoc != null)
            {
              if (ttype.ID != ttype.TurretName)
              {
                if (cache.GetOrOpen(ttype.TurretName + tt.Extension, vfs, out ShpFile tshpFile) ||
                    cache.GetOrOpen(ttype.TurretName + ".SHP", vfs, out tshpFile))
                {
                  dir = (256 - facing) % 256 / (256 / ttype.TurretDirections) + ttype.TurretShpFrame;
                  turrbmp = RenderUtils.RenderShp(cache, tshpFile, hpalFile, dir);
                }
              }
              else
              {
                dir = (256 - facing) % 256 / (256 / ttype.TurretDirections) + ttype.TurretShpFrame;
                turrbmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);
              }
              if (turrbmp != null)
              {
                // draw centered
                xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (turrbmp.Width / 2);
                yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (turrbmp.Height / 2);
                Point mov = turrLoc(i, facing);
                if (highlight)
                {
                  Rectangle rd = new Rectangle(xd + mov.X, yd + mov.Y, turrbmp.Width, turrbmp.Height);
                  g.DrawImage(turrbmp, rd, 0, 0, turrbmp.Width, turrbmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
                }
                else
                {
                  g.DrawImage(turrbmp, xd + mov.X, yd + mov.Y);
                }
              }
            }
          }
        }

        if (bmp != null && tag != null && tag.ToUpperInvariant() != "NONE")
        {
          // draw cell centered
          xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
          yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);
          Rectangle r = new Rectangle(xd, yd, bmp.Width, bmp.Height);
          g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          SizeF size = g.MeasureString(tag, MapUserThemes.TechnoTypeTagFont, r.Size, _triggerTagStringFormat);
          g.FillRectangle(MapUserThemes.TechnoTypeTagBackgroundBrush, new RectangleF(r.Location.X + r.Size.Width / 2 - size.Width / 2, r.Location.Y + r.Size.Height / 2 - size.Height / 2, size.Width, size.Height));
          g.DrawString(tag, MapUserThemes.TechnoTypeTagFont, MapUserThemes.TechnoTypeTagBrush, r, _triggerTagStringFormat);
        }
      }
      else
      {
        DrawUnknownObject(cache, palFile, g, x, y);
      }
    }

    public static void DrawVessels(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in map.VesselSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawVessel(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Facing, g, x, y, tInfo.Tag);
      }
    }

    public static void DrawVessels(Map map, MapExtract extract, int xoffset, int yoffset, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var tInfo in extract.VesselSection.EntityList)
      {
        int c = tInfo.Cell;
        int x = xoffset + extract.CellX(c);
        int y = yoffset + extract.CellY(c);
        HouseType house = rules.Houses.GetHouse(tInfo.Owner);

        DrawVessel(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Facing, g, x, y, tInfo.Tag);
      }
    }

    public static void DrawVessel(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, HouseType owner, int facing, Graphics g, int x, int y, string tag, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp;
      VesselType ttype = rules.Vessels.Get(typeID);
      if (ttype == null)
      {
        DrawUnknownObject(cache, palFile, g, x, y);
        return;
      }
      // get Image=
      string imageID = ttype.RulesImage;

      if (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(imageID + ".SHP", vfs, out shpFile)) // template extension provided no files, try .shp instead
      {
        ColorType color = owner.RulesSecondaryColor;

        PalFile hpalFile = RenderUtils.FetchHouseRemapPalette(cache, palFile, color);
        // 32 directions
        int dir = ttype.Directions == 0 ? 0 : (256 - facing) % 256 / (256 / ttype.Directions);
        bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);
        int xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
        int yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);

        if (bmp != null)
        {
          // draw centered
          if (highlight)
          {
            Rectangle rd = new Rectangle(xd, yd, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
          }
          else
          {
            g.DrawImage(bmp, xd, yd);
          }
        }

        if (ttype.TurretLocations != null) // all units use the same SHP for turrets
        {
          for (int i = 0; i < ttype.TurretLocations.Length; i++)
          {
            var turrLoc = ttype.TurretLocations[i];
            if (turrLoc != null)
            {
              if (ttype.ID != ttype.TurretName)
              {
                if (cache.GetOrOpen(ttype.TurretName + tt.Extension, vfs, out ShpFile tshpFile) ||
                    cache.GetOrOpen(ttype.TurretName + ".SHP", vfs, out tshpFile))
                {
                  dir = (256 - facing) % 256 / (256 / ttype.TurretDirections) + ttype.TurretShpFrame;
                  bmp = RenderUtils.RenderShp(cache, tshpFile, hpalFile, dir);
                }
              }
              else
              {
                dir = (256 - facing) % 256 / (256 / ttype.TurretDirections) + ttype.TurretShpFrame;
                bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);
              }
              if (bmp != null)
              {
                // draw centered
                xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
                yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);
                Point mov = turrLoc(i, facing);
                if (highlight)
                {
                  Rectangle rd = new Rectangle(xd + mov.X, yd + mov.Y, bmp.Width, bmp.Height);
                  g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
                }
                else
                {
                  g.DrawImage(bmp, xd + mov.X, yd + mov.Y);
                }
              }
            }
          }
        }

        if (tag != null && tag.ToUpperInvariant() != "NONE")
        {
          // draw centered
          xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
          yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);
          Rectangle r = new Rectangle(xd, yd, bmp.Width, bmp.Height);
          g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          SizeF size = g.MeasureString(tag, MapUserThemes.TechnoTypeTagFont, r.Size, _triggerTagStringFormat);
          g.FillRectangle(MapUserThemes.TechnoTypeTagBackgroundBrush, new RectangleF(r.Location.X + r.Size.Width / 2 - size.Width / 2, r.Location.Y + r.Size.Height / 2 - size.Height / 2, size.Width, size.Height));
          g.DrawString(tag, MapUserThemes.TechnoTypeTagFont, MapUserThemes.TechnoTypeTagBrush, r, _triggerTagStringFormat);
        }
      }
      else
      {
        DrawUnknownObject(cache, palFile, g, x, y);
      }
    }

    public static void DrawAircrafts(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      // There is no aircraft
      /*
      foreach (var tInfo in map.AircraftSection.AircraftList)
      {
        int c = tInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = Houses.GetHouse(tInfo.Owner);

        DrawAircraft(map, rules, cache, vfs, tt, palFile, tInfo.ID, house, tInfo.Facing, g, x, y, tInfo.Tag);
      }
      */
    }

    public static void DrawAircraft(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, HouseType owner, int facing, Graphics g, int x, int y, string tag, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      Bitmap bmp;
      AircraftType ttype = rules.Aircrafts.Get(typeID);
      if (ttype == null)
      {
        DrawUnknownObject(cache, palFile, g, x, y);
        return;
      }
      // get Image=
      string imageID = ttype.RulesImage;

      if (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(imageID + ".SHP", vfs, out shpFile)) // template extension provided no files, try .shp instead
      {
        ColorType color = owner.RulesSecondaryColor;

        PalFile hpalFile = RenderUtils.FetchHouseRemapPalette(cache, palFile, color);
        // 32 directions
        int dir = ttype.Directions == 0 ? 0 : (256 - facing) % 256 / (256 / ttype.Directions);
        bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);
        int xd = x * Constants.CELL_PIXEL_W + Constants.CELL_PIXEL_W / 2 - (bmp.Width / 2);
        int yd = y * Constants.CELL_PIXEL_H + Constants.CELL_PIXEL_H / 2 - (bmp.Height / 2);

        if (bmp != null)
        {
          // draw centered
          if (highlight)
          {
            Rectangle rd = new Rectangle(xd, yd, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
          }
          else
          {
            g.DrawImage(bmp, xd, yd);
          }
        }

        if (tag != null && tag.ToUpperInvariant() != "NONE")
        {
          Rectangle r = new Rectangle(xd, yd, bmp.Width, bmp.Height);
          g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          SizeF size = g.MeasureString(tag, MapUserThemes.TechnoTypeTagFont, r.Size, _triggerTagStringFormat);
          g.FillRectangle(MapUserThemes.TechnoTypeTagBackgroundBrush, new RectangleF(r.Location.X + r.Size.Width / 2 - size.Width / 2, r.Location.Y + r.Size.Height / 2 - size.Height / 2, size.Width, size.Height));
          g.DrawString(tag, MapUserThemes.TechnoTypeTagFont, MapUserThemes.TechnoTypeTagBrush, r, _triggerTagStringFormat);
        }
      }
      else
      {
        DrawUnknownObject(cache, palFile, g, x, y);
      }
    }

    public static void DrawInfantries(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var iInfo in map.InfantrySection.EntityList)
      {
        int c = iInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        HouseType house = rules.Houses.GetHouse(iInfo.Owner);

        DrawInfantry(map, rules, cache, vfs, tt, palFile, iInfo.ID, house, iInfo.Facing, g, x, y, iInfo.SubCell, iInfo.Tag);
      }
    }

    public static void DrawInfantries(Map map, MapExtract extract, int xoffset, int yoffset, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g)
    {
      CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

      foreach (var iInfo in extract.InfantrySection.EntityList)
      {
        int c = iInfo.Cell;
        int x = xoffset + extract.CellX(c);
        int y = yoffset + extract.CellY(c);
        HouseType house = rules.Houses.GetHouse(iInfo.Owner);

        DrawInfantry(map, rules, cache, vfs, tt, palFile, iInfo.ID, house, iInfo.Facing, g, x, y, iInfo.SubCell, iInfo.Tag);
      }
    }

    public static void DrawInfantry(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, TheaterType tt, PalFile palFile, string typeID, HouseType owner, int facing, Graphics g, int x, int y, int subCell, string tag, bool highlight = false)
    {
      if (!map.IsCellInMap(x, y)) { return; }

      InfantryType itype = rules.Infantries.Get(typeID);
      if (itype == null)
      {
        DrawUnknownObject(cache, palFile, g, x, y);
        return;
      }
      // get Image=
      string imageID = itype.RulesImage;

      if (cache.GetOrOpen(imageID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(imageID + ".SHP", vfs, out shpFile)) // template extension provided no files, try .shp instead
      {
        // read House section to determine Primary/Secondary house color
        if (itype.RemapOverrideKey != null)
        {
          palFile = RenderUtils.FetchEntityRemapPalette(cache, palFile, itype.RemapOverrideKey);
        }

        ColorType color = owner.RulesSecondaryColor;
        PalFile hpalFile = RenderUtils.FetchHouseRemapPalette(cache, palFile, color);
        // 8 directions
        int dir = itype.Directions == 0 ? 0 : (256 - facing) % 256 / (256 / itype.Directions);
        Bitmap bmp = RenderUtils.RenderShp(cache, shpFile, hpalFile, dir);

        MapHelper.GetSubCellOffsets(subCell, out int xd, out int yd);
        int xt = x * Constants.CELL_PIXEL_W + xd - bmp.Width / 2;
        int yt = y * Constants.CELL_PIXEL_H + yd - bmp.Height / 2;
        int tagwidth = 24;
        int tagheight = 24;
        if (bmp != null)
        {
          // draw centered
          if (highlight)
          {
            Rectangle rd = new Rectangle(xt, yt, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, _highlightImageAttributes);
          }
          else
          {
            g.DrawImage(bmp, xt, yt);
          }
          tagwidth = Math.Max(tagwidth, bmp.Width);
          tagheight = Math.Max(tagheight, bmp.Height);
        }

        if (tag != null && tag.ToUpperInvariant() != "NONE")
        {
          Rectangle r = new Rectangle(xt, yt, tagwidth, tagheight);
          g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
          SizeF size = g.MeasureString(tag, MapUserThemes.TechnoTypeTagFont, r.Size, _triggerTagStringFormat);
          g.FillRectangle(MapUserThemes.TechnoTypeTagBackgroundBrush, new RectangleF(r.Location.X + r.Size.Width / 2 - size.Width / 2, r.Location.Y + r.Size.Height / 2 - size.Height / 2, size.Width, size.Height));
          g.DrawString(tag, MapUserThemes.TechnoTypeTagFont, MapUserThemes.TechnoTypeTagBrush, r, _triggerTagStringFormat);
        }
      }
      else
      {
        DrawUnknownObject(cache, palFile, g, x, y);
      }
    }
  }
}
