using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Drawing;

namespace RA_Mission_Editor.Util
{
  public static class MapHelper
  {
    // cos and sin tables from https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/COORD.CPP
    static byte[] cosTable = new byte[] {
    0x00,0x03,0x06,0x09,0x0c,0x0f,0x12,0x15,
    0x18,0x1b,0x1e,0x21,0x24,0x27,0x2a,0x2d,
    0x30,0x33,0x36,0x39,0x3b,0x3e,0x41,0x43,
    0x46,0x49,0x4b,0x4e,0x50,0x52,0x55,0x57,
    0x59,0x5b,0x5e,0x60,0x62,0x64,0x65,0x67,
    0x69,0x6b,0x6c,0x6e,0x6f,0x71,0x72,0x74,
    0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7b,
    0x7c,0x7d,0x7d,0x7e,0x7e,0x7e,0x7e,0x7e,

    0x7f,0x7e,0x7e,0x7e,0x7e,0x7e,0x7d,0x7d,
    0x7c,0x7b,0x7b,0x7a,0x79,0x78,0x77,0x76,
    0x75,0x74,0x72,0x71,0x70,0x6e,0x6c,0x6b,
    0x69,0x67,0x66,0x64,0x62,0x60,0x5e,0x5b,
    0x59,0x57,0x55,0x52,0x50,0x4e,0x4b,0x49,
    0x46,0x43,0x41,0x3e,0x3b,0x39,0x36,0x33,
    0x30,0x2d,0x2a,0x27,0x24,0x21,0x1e,0x1b,
    0x18,0x15,0x12,0x0f,0x0c,0x09,0x06,0x03,

    0x00,0xfd,0xfa,0xf7,0xf4,0xf1,0xee,0xeb,
    0xe8,0xe5,0xe2,0xdf,0xdc,0xd9,0xd6,0xd3,
    0xd0,0xcd,0xca,0xc7,0xc5,0xc2,0xbf,0xbd,
    0xba,0xb7,0xb5,0xb2,0xb0,0xae,0xab,0xa9,
    0xa7,0xa5,0xa2,0xa0,0x9e,0x9c,0x9a,0x99,
    0x97,0x95,0x94,0x92,0x91,0x8f,0x8e,0x8c,
    0x8b,0x8a,0x89,0x88,0x87,0x86,0x85,0x85,
    0x84,0x83,0x83,0x82,0x82,0x82,0x82,0x82,

    0x82,0x82,0x82,0x82,0x82,0x82,0x83,0x83,
    0x84,0x85,0x85,0x86,0x87,0x88,0x89,0x8a,
    0x8b,0x8c,0x8e,0x8f,0x90,0x92,0x94,0x95,
    0x97,0x99,0x9a,0x9c,0x9e,0xa0,0xa2,0xa5,
    0xa7,0xa9,0xab,0xae,0xb0,0xb2,0xb5,0xb7,
    0xba,0xbd,0xbf,0xc2,0xc5,0xc7,0xca,0xcd,
    0xd0,0xd3,0xd6,0xd9,0xdc,0xdf,0xe2,0xe5,
    0xe8,0xeb,0xee,0xf1,0xf4,0xf7,0xfa,0xfd,
  };

    static byte[] sinTable = new byte[] {
    0x7f,0x7e,0x7e,0x7e,0x7e,0x7e,0x7d,0x7d,
    0x7c,0x7b,0x7b,0x7a,0x79,0x78,0x77,0x76,
    0x75,0x74,0x72,0x71,0x70,0x6e,0x6c,0x6b,
    0x69,0x67,0x66,0x64,0x62,0x60,0x5e,0x5b,
    0x59,0x57,0x55,0x52,0x50,0x4e,0x4b,0x49,
    0x46,0x43,0x41,0x3e,0x3b,0x39,0x36,0x33,
    0x30,0x2d,0x2a,0x27,0x24,0x21,0x1e,0x1b,
    0x18,0x15,0x12,0x0f,0x0c,0x09,0x06,0x03,

    0x00,0xfd,0xfa,0xf7,0xf4,0xf1,0xee,0xeb,
    0xe8,0xe5,0xe2,0xdf,0xdc,0xd9,0xd6,0xd3,
    0xd0,0xcd,0xca,0xc7,0xc5,0xc2,0xbf,0xbd,
    0xba,0xb7,0xb5,0xb2,0xb0,0xae,0xab,0xa9,
    0xa7,0xa5,0xa2,0xa0,0x9e,0x9c,0x9a,0x99,
    0x97,0x95,0x94,0x92,0x91,0x8f,0x8e,0x8c,
    0x8b,0x8a,0x89,0x88,0x87,0x86,0x85,0x85,
    0x84,0x83,0x83,0x82,0x82,0x82,0x82,0x82,

    0x82,0x82,0x82,0x82,0x82,0x82,0x83,0x83,
    0x84,0x85,0x85,0x86,0x87,0x88,0x89,0x8a,
    0x8b,0x8c,0x8e,0x8f,0x90,0x92,0x94,0x95,
    0x97,0x99,0x9a,0x9c,0x9e,0xa0,0xa2,0xa5,
    0xa7,0xa9,0xab,0xae,0xb0,0xb2,0xb5,0xb7,
    0xba,0xbd,0xbf,0xc2,0xc5,0xc7,0xca,0xcd,
    0xd0,0xd3,0xd6,0xd9,0xdc,0xdf,0xe2,0xe5,
    0xe8,0xeb,0xee,0xf1,0xf4,0xf7,0xfa,0xfd,

    0x00,0x03,0x06,0x09,0x0c,0x0f,0x12,0x15,
    0x18,0x1b,0x1e,0x21,0x24,0x27,0x2a,0x2d,
    0x30,0x33,0x36,0x39,0x3b,0x3e,0x41,0x43,
    0x46,0x49,0x4b,0x4e,0x50,0x52,0x55,0x57,
    0x59,0x5b,0x5e,0x60,0x62,0x64,0x65,0x67,
    0x69,0x6b,0x6c,0x6e,0x6f,0x71,0x72,0x74,
    0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7b,
    0x7c,0x7d,0x7d,0x7e,0x7e,0x7e,0x7e,0x7e,
  };

    public static int CellNumber(this Map map, int x, int y)
    {
      return x + y * map.Ext_MapSection.FullWidth;
    }

    public static int CellX(this Map map, int cellNumber)
    {
      return cellNumber % map.Ext_MapSection.FullWidth;
    }

    public static int CellY(this Map map, int cellNumber)
    {
      return cellNumber / map.Ext_MapSection.FullWidth;
    }

    public static int CellNumber(this MapExtract map, int x, int y)
    {
      return x + y * map.Ext_MapSection.FullWidth;
    }

    public static int CellX(this MapExtract map, int cellNumber)
    {
      return cellNumber % map.Ext_MapSection.FullWidth;
    }

    public static int CellY(this MapExtract map, int cellNumber)
    {
      return cellNumber / map.Ext_MapSection.FullWidth;
    }

    public static Point Point(this Map map, int cellNumber)
    {
      if (cellNumber < 0) return new Point(-1, -1);
      return new Point(map.CellX(cellNumber), map.CellY(cellNumber));
    }

    public static bool IsCellInMap(this Map map, int x, int y)
    {
      return x >= 0 && x < map.Ext_MapSection.FullWidth
          && y >= 0 && y < map.Ext_MapSection.FullWidth;
    }

    public static bool IsCellInMap(this Map map, int cellNumber)
    {
      return cellNumber >= 0 && cellNumber < map.Ext_MapSection.FullCellCount;
    }

    public static bool IsCellInPlayArea(this Map map, int x, int y)
    {
      return x >= map.MapSection.X && x < map.MapSection.X + map.MapSection.Width
          && y >= map.MapSection.Y && y < map.MapSection.Y + map.MapSection.Height;
    }

    public static bool IsCellInPlayArea(this Map map, int cellNumber)
    {
      int x = CellX(map, cellNumber);
      int y = CellY(map, cellNumber);
      return IsCellInPlayArea(map, x, y);
    }

    public static bool Within(this Map map, int cellTopLeft, int width, int height, int targetcell)
    {
      int x =  map.CellX(cellTopLeft);
      int y =  map.CellY(cellTopLeft);
      int tx = map.CellX(targetcell);
      int ty = map.CellY(targetcell);
      return tx >= x && tx < x + width && ty >= y && ty < y + height;
    }

    public static int ClearIcon(this Map map, int cellNumber)
    {
      return (map.CellX(cellNumber) & 0x03) | ((map.CellY(cellNumber) & 0x03) << 2);
    }

    public static int GetNeighbourCellsWithOre(this Map map, int cellNumber)
    {
      int x = CellX(map, cellNumber);
      int y = CellY(map, cellNumber);
      int count = 0;
      for (int x2 = Math.Max(0, x - 1); x2 < Math.Min(map.Ext_MapSection.FullWidth, x + 1); x2++)
        for (int y2 = Math.Max(0, y - 1); y2 < Math.Min(map.Ext_MapSection.FullHeight, y + 1); y2++)
        {
          if (x2 == x && y2 == x) { continue; } // ignore own cell
          int c2 = map.CellNumber(x2, y2);
          OverlayType ovl = Overlays.Get(map.OverlayPackSection.Overlay[c2]);
          if (ovl != null && ovl.SubType == OverlaySubType.GOLD)
          {
            count++;
          }
        }
      return count;
    }

    public static int GetNeighbourCellsWithGems(this Map map, int cellNumber)
    {
      int x = CellX(map, cellNumber);
      int y = CellY(map, cellNumber);
      int count = 0;
      for (int x2 = Math.Max(0, x - 1); x2 < Math.Min(map.Ext_MapSection.FullWidth, x + 1); x2++)
        for (int y2 = Math.Max(0, y - 1); y2 < Math.Min(map.Ext_MapSection.FullHeight, y + 1); y2++)
        {
          if (x2 == x && y2 == x) { continue; } // ignore own cell
          int c2 = map.CellNumber(x2, y2);
          OverlayType ovl = Overlays.Get(map.OverlayPackSection.Overlay[c2]);
          if (ovl != null && ovl.SubType == OverlaySubType.GEM)
          {
            count++;
          }
        }
      return count;
    }

    public static int GetNeighbourCellsWithOre(this MapExtract map, int cellNumber)
    {
      int x = CellX(map, cellNumber);
      int y = CellY(map, cellNumber);
      int count = 0;
      for (int x2 = Math.Max(0, x - 1); x2 < Math.Min(map.Ext_MapSection.FullWidth, x + 1); x2++)
        for (int y2 = Math.Max(0, y - 1); y2 < Math.Min(map.Ext_MapSection.FullHeight, y + 1); y2++)
        {
          if (x2 == x && y2 == x) { continue; } // ignore own cell
          int c2 = map.CellNumber(x2, y2);
          OverlayType ovl = Overlays.Get(map.OverlayPackSection.Overlay[c2]);
          if (ovl != null && ovl.SubType == OverlaySubType.GOLD)
          {
            count++;
          }
        }
      return count;
    }

    public static int GetNeighbourCellsWithGems(this MapExtract map, int cellNumber)
    {
      int x = CellX(map, cellNumber);
      int y = CellY(map, cellNumber);
      int count = 0;
      for (int x2 = Math.Max(0, x - 1); x2 < Math.Min(map.Ext_MapSection.FullWidth, x + 1); x2++)
        for (int y2 = Math.Max(0, y - 1); y2 < Math.Min(map.Ext_MapSection.FullHeight, y + 1); y2++)
        {
          if (x2 == x && y2 == x) { continue; } // ignore own cell
          int c2 = map.CellNumber(x2, y2);
          OverlayType ovl = Overlays.Get(map.OverlayPackSection.Overlay[c2]);
          if (ovl != null && ovl.SubType == OverlaySubType.GEM)
          {
            count++;
          }
        }
      return count;
    }

    // See Tiberium_Adjust() in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/CELL.CPP
    private static int[] oreOverlay = { 0, 1, 3, 4, 6, 7, 8, 10, 11 };
    private static int[] gemOverlay = { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

    public static int GetOreOverlayData(this Map map, int cellNumber)
    {
      return oreOverlay[map.GetNeighbourCellsWithOre(cellNumber)];
    }

    public static int GetGemOverlayData(this Map map, int cellNumber)
    {
      return gemOverlay[map.GetNeighbourCellsWithGems(cellNumber)];
    }

    public static byte GetWallOverlayData(this Map map, int cellNumber)
    {
      int x = map.CellX(cellNumber);
      int y = map.CellY(cellNumber);
      int c = map.CellNumber(x, y);

      byte code = 0;
      // N
      if (y > 0)
      {
        int c2 = map.CellNumber(x, y - 1);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x1;
        }
      }

      // E
      if (x < map.Ext_MapSection.FullWidth - 1)
      {
        int c2 = map.CellNumber(x + 1, y);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x2;
        }
      }

      // S
      if (y < map.Ext_MapSection.FullHeight - 1)
      {
        int c2 = map.CellNumber(x, y + 1);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x4;
        }
      }

      // W
      if (x > 0)
      {
        int c2 = map.CellNumber(x - 1, y);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x8;
        }
      }

      return code;
    }

    public static int GetOreOverlayData(this MapExtract map, int cellNumber)
    {
      return oreOverlay[map.GetNeighbourCellsWithOre(cellNumber)];
    }

    public static int GetGemOverlayData(this MapExtract map, int cellNumber)
    {
      return gemOverlay[map.GetNeighbourCellsWithGems(cellNumber)];
    }

    public static byte GetWallOverlayData(this MapExtract map, int cellNumber)
    {
      int x = map.CellX(cellNumber);
      int y = map.CellY(cellNumber);
      int c = map.CellNumber(x, y);

      byte code = 0;
      // N
      if (y > 0)
      {
        int c2 = map.CellNumber(x, y - 1);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x1;
        }
      }

      // E
      if (x < map.Ext_MapSection.FullWidth - 1)
      {
        int c2 = map.CellNumber(x + 1, y);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x2;
        }
      }

      // S
      if (y < map.Ext_MapSection.FullHeight - 1)
      {
        int c2 = map.CellNumber(x, y + 1);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x4;
        }
      }

      // W
      if (x > 0)
      {
        int c2 = map.CellNumber(x - 1, y);
        if (map.OverlayPackSection.Overlay[c] == map.OverlayPackSection.Overlay[c2])
        {
          code += 0x8;
        }
      }

      return code;
    }

    public static void GetSubCellOffsets(int subCell, out int x, out int y)
    {
      x = -19; y = -9;

      switch (subCell)
      {
        case 1: x += 0; y += 0; break;
        case 2: x += 11; y += 0; break;
        case 3: y += 11; break;
        case 4: x += 11; y += 11; break;
        case 0: x += 6; y += 6; break;
        default: break;
      }
    }

    public static void MoveCoord(int x, int y, int distance, int facing, out int new_x, out int new_y)
    {
      // x, y in pixel coordinate units
      int f = (facing % 256 + 256) % 256;
      new_x = x + (sbyte)cosTable[f] * distance / 0x7f;
      new_y = y + (sbyte)sinTable[f] * distance / 0x7f / 2;  // yes, divide by 2 
    }
  }
}
