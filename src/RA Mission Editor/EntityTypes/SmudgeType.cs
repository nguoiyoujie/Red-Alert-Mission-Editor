﻿using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class SmudgeType : IEntityType
  {
    public string ID { get; }
    public int Images = 1;
    public int BlockWidth = 1;
    public int BlockHeight = 1;

    public SmudgeType(string id)
    {
      ID = id;
    }

    public string DisplayName { get => ToString(); }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Smudges; } }

    public override string ToString()
    {
      return ID;
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
    {
      Bitmap bmp = null;
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

      if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
          cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
      {
        int tx = BlockWidth;
        int ty = BlockHeight;
        if (tx == 1 && ty == 1)
        {
          if (Images == 1)
          {
            bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
          }
          else
          {
            bmp = new Bitmap(Images * Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
            using (Graphics g = Graphics.FromImage(bmp))
            {
              int tile = 0;
              for (int i = 0; i < Images; i++)
              {
                Bitmap b = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
                if (b != null)
                {
                  // draw
                  g.DrawImage(b, i * Constants.CELL_PIXEL_W, 0);
                }
              }
            }
          }
        }
        else
        {
          bmp = new Bitmap(tx * Constants.CELL_PIXEL_W, ty * Constants.CELL_PIXEL_H);
          using (Graphics g = Graphics.FromImage(bmp))
          {
            int tile = 0;
            for (int yd = 0; yd < ty; yd++)
              for (int xd = 0; xd < tx; xd++)
              {
                Bitmap b = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
                if (b != null)
                {
                  // draw
                  g.DrawImage(b, xd * Constants.CELL_PIXEL_W, yd * Constants.CELL_PIXEL_H);
                }
              }
          }
        }
      }
      return bmp;
    }

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
    {
      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
      EnvironmentRenderer.DrawSmudge(map, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, BlockWidth, BlockHeight, 0, highlight);

     //Bitmap bmp = null;
     //if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
     //    cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
     //{
     //  int tx = BlockWidth;
     //  int ty = BlockHeight;
     //  if (tx == 1 && ty == 1)
     //  {
     //    bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
     //  }
     //  else
     //  {
     //    bmp = new Bitmap(tx * Constants.CELL_PIXEL_W, ty * Constants.CELL_PIXEL_H);
     //    using (Graphics gb = Graphics.FromImage(bmp))
     //    {
     //      int tile = 0;
     //      for (int yd = 0; yd < ty; yd++)
     //        for (int xd = 0; xd < tx; xd++)
     //        {
     //          Bitmap b = RenderUtils.RenderShp(cache, shpFile, palFile, tile++);
     //          if (b != null)
     //          {
     //            // draw
     //            gb.DrawImage(b, xd * Constants.CELL_PIXEL_W, yd * Constants.CELL_PIXEL_H);
     //          }
     //        }
     //    }
     //  }
     //}
     //if (bmp != null)
     //{
     //  g.DrawImage(bmp, entity.X * Constants.CELL_PIXEL_W, entity.Y * Constants.CELL_PIXEL_H);
     //}
     //bmp?.DisposeIfNotCached();
    }
  }
}
