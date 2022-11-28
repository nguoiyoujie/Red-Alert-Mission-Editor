using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class MapOccupancyList
  {
    public class EntityComparer : IComparer<IEntity>
    {
      public int Compare(IEntity x, IEntity y)
      {
        return Comparer<int>.Default.Compare(_types.IndexOf(x.GetType()), _types.IndexOf(y.GetType()));
      }

      List<Type> _types = new List<Type>()
      {
        typeof(TemplateType),
        typeof(OverlayType),
        typeof(TerrainInfo),
        typeof(SmudgeInfo),
        typeof(BaseInfo),
        typeof(StructureInfo),
        typeof(UnitInfo),
        typeof(ShipInfo),
        typeof(InfantryInfo),
        typeof(WaypointInfo),
        typeof(CellTriggerInfo),
      };
    }

    public List<IEntity>[] OccupancyList;
    public Dictionary<IEntity, List<int>> CellOccupancyReference = new Dictionary<IEntity, List<int>>();
    private static EntityComparer _entityComparer = new EntityComparer();

    public MapOccupancyList(int size = Constants.MAP_CELL_W * Constants.MAP_CELL_H)
    {
      Reset(size);
    }

    public void Reset(int size)
    {
      OccupancyList = new List<IEntity>[size];
      for (int i = 0; i < OccupancyList.Length; i++)
      {
        OccupancyList[i] = new List<IEntity>();
      }
    }

    public void Rebuild(Map map, MapCache cache, VirtualFileSystem vfs)
    {
      CellOccupancyReference.Clear();
      for (int i = 0; i < OccupancyList.Length; i++)
      {
        OccupancyList[i].Clear();
      }

      for (int c = 0; c < map.MapPackSection.Template.Length; c++)
      {
        TemplateType tmpl = Templates.Get(map.MapPackSection.Template[c]);
        if (tmpl != null)
        {
          OccupancyList[c].Add(tmpl);
          List<int> cellOccupancy;
          if (!CellOccupancyReference.TryGetValue(tmpl, out cellOccupancy))
          {
            cellOccupancy = new List<int>();
            CellOccupancyReference.Add(tmpl, cellOccupancy);
          }
          cellOccupancy.Add(c);
        }
      }

      for (int c = 0; c < map.OverlayPackSection.Overlay.Length; c++)
      {
        OverlayType ovly = Overlays.Get(map.OverlayPackSection.Overlay[c]);
        if (ovly != null)
        {
          OccupancyList[c].Add(ovly);
          List<int> cellOccupancy;
          if (!CellOccupancyReference.TryGetValue(ovly, out cellOccupancy))
          {
            cellOccupancy = new List<int>();
            CellOccupancyReference.Add(ovly, cellOccupancy);
          }
          cellOccupancy.Add(c);
        }
      }

      foreach (var terr in map.TerrainSection.TerrainList)
      {
        UpdateEntity(map, cache, vfs, terr, false);
      }

      foreach (var smud in map.SmudgeSection.SmudgeList)
      {
        UpdateEntity(map, cache, vfs, smud, false);
      }

      foreach (var @base in map.BaseSection.BaseList)
      {
        UpdateEntity(map, cache, vfs, @base, false);
      }

      foreach (var stru in map.StructureSection.StructureList)
      {
        UpdateEntity(map, cache, vfs, stru, false);
      }

      foreach (var inft in map.InfantrySection.InfantryList)
      {
        UpdateEntity(map, cache, vfs, inft, false);
      }

      foreach (var unit in map.UnitSection.UnitList)
      {
        UpdateEntity(map, cache, vfs, unit, false);
      }

      foreach (var ship in map.ShipSection.ShipList)
      {
        UpdateEntity(map, cache, vfs, ship, false);
      }

      foreach (var wayp in map.WaypointSection.WaypointList)
      {
        if (map.IsCellInMap(wayp.Cell))
          UpdateEntity(map, cache, vfs, wayp, false);
      }

      foreach (var celt in map.CellTriggerSection.Triggers)
      {
        if (celt != null)
          UpdateEntity(map, cache, vfs, celt, false);
      }

      // sort now
      for (int i = 0; i < OccupancyList.Length; i++)
      {
        OccupancyList[i].Sort(_entityComparer);
      }
    }

    public void UpdateEntity(Map map, MapCache cache, VirtualFileSystem vfs, IEntity entity, bool autoSort = true)
    {
      if (entity == null) { return; }

      // remove old occupancy
      List<int> cellOccupancy = null;
      if (!(entity is TemplateType))
      {
        if (CellOccupancyReference.TryGetValue(entity, out cellOccupancy))
        {
          foreach (int c in cellOccupancy)
          {
            OccupancyList[c].Remove(entity);
            // removal does not require resort
          }
          cellOccupancy.Clear();
        }
        else
        {
          cellOccupancy = new List<int>();
          CellOccupancyReference.Add(entity, cellOccupancy);
        }
      }

      EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile _);
      if (entity is TemplateType tmpl)
      {
        // rescan map
        for (int c = 0; c < map.MapPackSection.Template.Length; c++)
        {
          if (tmpl == Templates.Get(map.MapPackSection.Template[c]))
          { 
            OccupancyList[c].RemoveAll((o) => o is TemplateType);
            OccupancyList[c].Add(tmpl);
            if (autoSort) OccupancyList[c].Sort(_entityComparer);
          }
        }
      }
      else if (entity is OverlayType ovly)
      {
        for (int c = 0; c < map.OverlayPackSection.Overlay.Length; c++)
        {
          if (ovly == Overlays.Get(map.OverlayPackSection.Overlay[c]))
          {
            OccupancyList[c].Add(ovly);
            if (autoSort) OccupancyList[c].Sort(_entityComparer);
            cellOccupancy.Add(c);
          }
        }
      }
      else if (entity is TerrainInfo terr)
      {
        int x0 = map.CellX(terr.Cell);
        int y0 = map.CellY(terr.Cell);
        EnvironmentRenderer.GetTerrainSizeInCells(cache, vfs, tt, terr.ID, out int xd, out int yd);
        for (int x = x0; x < x0 + xd; x++)
          for (int y = y0; y < y0 + yd; y++)
          {
            int c = map.CellNumber(x, y);
            if (c >= 0 && c < OccupancyList.Length)
            {
              OccupancyList[c].Add(terr);
              if (autoSort) OccupancyList[c].Sort(_entityComparer);
              cellOccupancy.Add(c);
            }
          }
      }
      else if (entity is SmudgeInfo smud)
      {
        int x0 = map.CellX(smud.Cell);
        int y0 = map.CellY(smud.Cell);
        SmudgeType stype = Smudges.Get(smud.ID);
        int xd = 1; 
        int yd = 1;
        if (stype != null)
        {
          xd = stype.BlockWidth;
          yd = stype.BlockHeight;
        }
        for (int x = x0; x < x0 + xd; x++)
          for (int y = y0; y < y0 + yd; y++)
          {
            int c = map.CellNumber(x, y);
            if (c >= 0 && c < OccupancyList.Length)
            {
              OccupancyList[c].Add(smud);
              if (autoSort) OccupancyList[c].Sort(_entityComparer);
              cellOccupancy.Add(c);
            }
          }
      }
      else if (entity is InfantryInfo inft)
      {
        // don't care about subcells, manually filter them later
        int c = inft.Cell;
        if (c >= 0 && c < OccupancyList.Length)
        {
          OccupancyList[c].Add(inft);
          if (autoSort) OccupancyList[c].Sort(_entityComparer);
          cellOccupancy.Add(c);
        }
      }
      else if (entity is UnitInfo unit)
      {
        int c = unit.Cell;
        if (c >= 0 && c < OccupancyList.Length)
        {
          OccupancyList[c].Add(unit);
          if (autoSort) OccupancyList[c].Sort(_entityComparer);
          cellOccupancy.Add(c);
        }
      }
      else if (entity is ShipInfo ship)
      {
        int c = ship.Cell;
        if (c >= 0 && c < OccupancyList.Length)
        {
          OccupancyList[c].Add(ship);
          if (autoSort) OccupancyList[c].Sort(_entityComparer);
          cellOccupancy.Add(c);
        }
      }
      else if (entity is BaseInfo @base)
      {
        int x0 = map.CellX(@base.Cell);
        int y0 = map.CellY(@base.Cell);
        TechnoTypeRenderer.GetStructureSizeInCells(map.AttachedRules, cache, vfs, tt, @base.ID, true, out int xd, out int yd);
        for (int x = x0; x < x0 + xd; x++)
          for (int y = y0; y < y0 + yd; y++)
          {
            int c = map.CellNumber(x, y);
            if (c >= 0 && c < OccupancyList.Length)
            {
              OccupancyList[c].Add(@base);
              if (autoSort) OccupancyList[c].Sort(_entityComparer);
              cellOccupancy.Add(c);
            }
          }
      }
      else if (entity is StructureInfo stru)
      {
        int x0 = map.CellX(stru.Cell);
        int y0 = map.CellY(stru.Cell);
        TechnoTypeRenderer.GetStructureSizeInCells(map.AttachedRules, cache, vfs, tt, stru.ID, true, out int xd, out int yd);
        for (int x = x0; x < x0 + xd; x++)
          for (int y = y0; y < y0 + yd; y++)
          {
            int c = map.CellNumber(x, y);
            if (c >= 0 && c < OccupancyList.Length)
            {
              OccupancyList[c].Add(stru);
              if (autoSort) OccupancyList[c].Sort(_entityComparer);
              cellOccupancy.Add(c);
            }
          }
      }
      else if (entity is WaypointInfo wayp)
      {
        int c = wayp.Cell;
        if (c >= 0 && c < OccupancyList.Length)
        {
          OccupancyList[c].Add(wayp);
          if (autoSort) OccupancyList[c].Sort(_entityComparer);
          cellOccupancy.Add(c);
        }
      }
      else if (entity is CellTriggerInfo celt)
      {
        int c = celt.Cell;
        if (c >= 0 && c < OccupancyList.Length)
        {
          OccupancyList[c].Add(celt);
          if (autoSort) OccupancyList[c].Sort(_entityComparer);
          cellOccupancy.Add(c);
        }
      }
    }

    public void RemoveEntity(IEntity entity)
    {
      if (entity == null) { return; }

      // remove old occupancy
      if (CellOccupancyReference.TryGetValue(entity, out List<int> cellOccupancy))
      {
        foreach (int c in cellOccupancy)
        {
          OccupancyList[c].Remove(entity);
          // removal does not require resort
        }
        cellOccupancy.Clear();
        CellOccupancyReference.Remove(entity);
      }
    }

    List<IEntity> _empty = new List<IEntity>();
    public List<IEntity> Pick(Map map, int x, int y)
    {
      int c = map.CellNumber(x, y);
      if (c >= 0 && c < OccupancyList.Length)
      {
        return OccupancyList[c];
      }
      return _empty;
    }
  }
}
