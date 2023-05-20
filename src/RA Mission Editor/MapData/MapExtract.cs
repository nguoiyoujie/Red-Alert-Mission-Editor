using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.MapData
{
  public class MapExtract
  {
    // represents an exported extract of the map, usually of an area
    public IniFile SourceFile;
    public string FilePath;
    public string DisplayName;

    public override string ToString()
    {
      return DisplayName;
    }

    public MapPack MapPackSection = new MapPack();
    public OverlayPack OverlayPackSection = new OverlayPack();
    public TerrainSection TerrainSection = new TerrainSection();
    public InfantrySection InfantrySection = new InfantrySection();
    public UnitSection UnitSection = new UnitSection();
    public ShipSection ShipSection = new ShipSection();
    public StructureSection StructureSection = new StructureSection();
    public SmudgeSection SmudgeSection = new SmudgeSection();

    public Ext_MapSection Ext_MapSection = new Ext_MapSection();

    public MapExtract(IniFile sourceFile)
    {
      Load(sourceFile, sourceFile.FileName);
    }

    public MapExtract(Map map, List<int> cells)
    {
      SourceFile = new IniFile(new MemoryStream(1024), null, 0, 0);
      SetCells(map, cells);
    }

    public void Clear()
    {
      //SourceFile = null;
      WriteDefaultSections();
    }

    private void WriteDefaultSections()
    {
      IniFile.IniSection blankSection = new IniFile.IniSection();
      MapPackSection.Read(blankSection);
      OverlayPackSection.Read(blankSection);
      TerrainSection.Read(blankSection);
      InfantrySection.Read(blankSection);
      UnitSection.Read(blankSection);
      ShipSection.Read(blankSection);
      StructureSection.Read(blankSection);
      SmudgeSection.Read(blankSection);

      Ext_MapSection.Read(blankSection);
    }

    public void Load(IniFile f, string path = null)
    {
      SourceFile = f;
      FilePath = path;
      DisplayName = !string.IsNullOrEmpty(path)? Path.GetFileNameWithoutExtension(path) : "Extract";

      // extensions (begin with Ext_)
      Ext_MapSection.Read(f.GetOrCreateSection("Ext_Map"));

      MapPackSection = new MapPack(Ext_MapSection.FullCellCount);
      OverlayPackSection = new OverlayPack(Ext_MapSection.FullCellCount);

      /* [TERRAIN] */
      TerrainSection.Read(f.GetOrCreateSection("TERRAIN"));

      /* [MapPack] */
      MapPackSection.Read(f.GetOrCreateSection("MapPack"));

      /* [UNITS] */
      UnitSection.Read(f.GetOrCreateSection("UNITS"));

      /* [AIRCRAFT] */
      // bugged, don't use

      /* [SHIPS] */
      ShipSection.Read(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Read(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      StructureSection.Read(f.GetOrCreateSection("STRUCTURES"));

      /* [OverlayPack] */
      OverlayPackSection.Read(f.GetOrCreateSection("OverlayPack"));

      /* [SMUDGE] */
      SmudgeSection.Read(f.GetOrCreateSection("SMUDGE"));
    }

    public void Update()
    {
      IniFile f = SourceFile;

      // try to follow the same order as Read_Scenario_INI() in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/SCENARIO.CPP

      // extensions (begin with Ext_)
      Ext_MapSection.Update(f.GetOrCreateSection("Ext_Map"));

      /* [TERRAIN] */
      TerrainSection.Update(f.GetOrCreateSection("TERRAIN"));

      /* [MapPack] */
      MapPackSection.Update(f.GetOrCreateSection("MapPack"));

      /* [UNITS] */
      UnitSection.Update(f.GetOrCreateSection("UNITS"));

      /* [AIRCRAFT] */
      // bugged, don't use

      /* [SHIPS] */
      ShipSection.Update(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Update(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      StructureSection.Update(f.GetOrCreateSection("STRUCTURES"));

      /* [OverlayPack] */
      OverlayPackSection.Update(f.GetOrCreateSection("OverlayPack"));

      /* [SMUDGE] */
      SmudgeSection.Update(f.GetOrCreateSection("SMUDGE"));
    }

    public void Save(string path)
    {
      IniFile f = SourceFile;
      Update();
      f.Save(path);
    }

    public void SetCells(Map map, List<int> cells)
    {
      // determine the top left
      int x0 = ushort.MaxValue;
      int y0 = ushort.MaxValue;
      int x1 = 0;
      int y1 = 0;
      if (cells.Count == 0)
      {
        x0 = 0;
        y0 = 0;
        x1 = 0;
        y1 = 0;
      }
      else
      {
        foreach (int cell in cells)
        {
          x0 = Math.Min(map.CellX(cell), x0);
          y0 = Math.Min(map.CellY(cell), y0);
          x1 = Math.Max(map.CellX(cell), x1);
          y1 = Math.Max(map.CellY(cell), y1);
        }
      }

      Ext_MapSection.FullWidth = x1 - x0 + 1;
      Ext_MapSection.FullHeight = y1 - y0 + 1;

      // replace 
      MapPackSection = new MapPack(Ext_MapSection.FullCellCount);
      OverlayPackSection = new OverlayPack(Ext_MapSection.FullCellCount);

      foreach (int cell in cells)
      {
        AddCell(map, cell, x0, y0);
      }
    }

    public void AddCell(Map map, int cell, int extractX, int extractY)
    {
      CopyValueParseableTo(map.UnitSection.UnitList, UnitSection.UnitList, map, cell, extractX, extractY);
      CopyValueParseableTo(map.InfantrySection.InfantryList, InfantrySection.InfantryList, map, cell, extractX, extractY);
      CopyValueParseableTo(map.ShipSection.ShipList, ShipSection.ShipList, map, cell, extractX, extractY);
      CopyValueParseableTo(map.StructureSection.StructureList, StructureSection.StructureList, map, cell, extractX, extractY);
      CopyKeyValueParseableTo(map.TerrainSection.TerrainList, TerrainSection.TerrainList, map, cell, extractX, extractY);
      CopyValueParseableTo(map.SmudgeSection.SmudgeList, SmudgeSection.SmudgeList, map, cell, extractX, extractY);

      // Templates
      CopyArrayValueTo<ushort>(map.MapPackSection.Template, MapPackSection.Template, map, cell, extractX, extractY, true, 0xFFFF);
      CopyArrayValueTo<byte>(map.MapPackSection.Tile, MapPackSection.Tile, map, cell, extractX, extractY, true, 0xFF);

      // Overlays
      CopyArrayValueTo(map.OverlayPackSection.Overlay, OverlayPackSection.Overlay, map, cell, extractX, extractY);
    }

    private void CopyValueParseableTo<T>(List<T> src, List<T> dest, Map map, int cell, int dx, int dy) where T : IValueParsable<T>, ILocatable, new()
    {
      for (int i = src.Count - 1; i >= 0; i--)
      {
        if (src[i] != null && src[i].Cell == cell)
        {
          string token = src[i].GetValueAsString();
          T copy = new T();
          copy.Parse(token);
          int cx = map.CellX(copy.Cell) - dx;
          int cy = map.CellY(copy.Cell) - dy;
          // add copy
          copy.Cell = this.CellNumber(cx, cy);
          dest.Add(copy);
        }
      }
    }

    private void CopyKeyValueParseableTo<T>(List<T> src, List<T> dest, Map map, int cell, int dx, int dy) where T : IKeyValueParsable<T>, ILocatable, new()
    {
      for (int i = src.Count - 1; i >= 0; i--)
      {
        if (src[i] != null && src[i].Cell == cell)
        {
          string key = src[i].GetKeyAsString();
          string token = src[i].GetValueAsString();
          T copy = new T();
          copy.Parse(key, token);
          int cx = map.CellX(copy.Cell) - dx;
          int cy = map.CellY(copy.Cell) - dy;
          copy.Cell = this.CellNumber(cx, cy);
          dest.Add(copy);
        }
      }
    }

    private void CopyArrayValueTo<T>(T[] src, T[] dest, Map map, int cell, int dx, int dy, bool convertBlanksToZero = false, T blankValue = default) where T : struct
    {
      int cx = map.CellX(cell) - dx;
      int cy = map.CellY(cell) - dy;
      int cc = this.CellNumber(cx, cy);
      if (cc < dest.Length)
        dest[cc] = (!convertBlanksToZero || !src[cell].Equals(blankValue)) ? src[cell] : default;
    }

    public void Paste(Map destMap, int x, int y)
    {
      CopyValueParseableTo(UnitSection.UnitList, destMap.UnitSection.UnitList, destMap, x, y);
      CopyValueParseableTo(InfantrySection.InfantryList, destMap.InfantrySection.InfantryList, destMap, x, y);
      CopyValueParseableTo(ShipSection.ShipList, destMap.ShipSection.ShipList, destMap, x, y);
      CopyValueParseableTo(StructureSection.StructureList, destMap.StructureSection.StructureList, destMap, x, y);
      CopyKeyValueParseableTo(TerrainSection.TerrainList, destMap.TerrainSection.TerrainList, destMap, x, y);
      CopyValueParseableTo(SmudgeSection.SmudgeList, destMap.SmudgeSection.SmudgeList, destMap, x, y);

      // Templates
      CopyArrayValueTo<ushort>(MapPackSection.Template, destMap.MapPackSection.Template, destMap, x, y, false, 0xFFFF);
      CopyArrayValueTo<byte>(MapPackSection.Tile, destMap.MapPackSection.Tile, destMap, x, y, false, 0xFF);

      // Overlays
      CopyArrayValueTo<byte>(OverlayPackSection.Overlay, destMap.OverlayPackSection.Overlay, destMap, x, y, false, 0xFF);
    }

    private void CopyValueParseableTo<T>(List<T> src, List<T> dest, Map destMap, int x, int y) where T : IValueParsable<T>, ILocatable, new()
    {
      for (int i = src.Count - 1; i >= 0; i--)
      {
        if (src[i] != null)
        {
          string token = src[i].GetValueAsString();
          T copy = new T();
          copy.Parse(token);
          int cx = this.CellX(copy.Cell) + x;
          int cy = this.CellY(copy.Cell) + y;
          if (destMap.IsCellInMap(cx, cy))
          {
            // add copy
            copy.Cell = destMap.CellNumber(cx, cy);
            dest.Add(copy);
          }
          else
          {
            // don't add copy
          }
        }
      }
    }

    private void CopyKeyValueParseableTo<T>(List<T> src, List<T> dest, Map destMap, int x, int y) where T : IKeyValueParsable<T>, ILocatable, new()
    {
      for (int i = src.Count - 1; i >= 0; i--)
      {
        if (src[i] != null)
        {
          string key = src[i].GetKeyAsString();
          string token = src[i].GetValueAsString();
          T copy = new T();
          copy.Parse(key, token);
          int cx = this.CellX(copy.Cell) + x;
          int cy = this.CellY(copy.Cell) + y;
          if (destMap.IsCellInMap(cx, cy))
          {
            // add copy
            copy.Cell = destMap.CellNumber(cx, cy);
            dest.Add(copy);
          }
          else
          {
            // don't add copy
          }
        }
      }
    }

    private void CopyArrayValueTo<T>(T[] src, T[] dest, Map destMap, int x, int y, bool overrideWithBlank, T blankValue = default) where T : struct
    {
      for (int i = 0; i < src.Length; i++)
      {
        int cx = this.CellX(i) + x;
        int cy = this.CellY(i) + y;
        if (destMap.IsCellInMap(cx, cy) && (overrideWithBlank || !src[i].Equals(blankValue)))
        {
          dest[destMap.CellNumber(cx, cy)] = src[i];
        }
      }
    }
  }
}
