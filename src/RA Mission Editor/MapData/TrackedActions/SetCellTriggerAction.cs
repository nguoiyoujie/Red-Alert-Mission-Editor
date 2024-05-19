using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.Util;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class SetCellTriggerAction : ITrackedAction
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public int Cell;
    public string OldCellTriggerID;
    public string NewCellTriggerID;

    public SetCellTriggerAction(Map map, MapCache cache, VirtualFileSystem vfs, int cell, string oldCellTriggerID, string newCellTriggerID)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Cell = cell;
      OldCellTriggerID = oldCellTriggerID;
      NewCellTriggerID = newCellTriggerID;
      Description = "Modify CellTrigger @ " + cell;
    }

    public void Do()
    {
      if (OldCellTriggerID != NewCellTriggerID && Cell >= 0 && Cell < Map.CellTriggerSection.Triggers.Length)
      {
        CellTriggerInfo ncelt = string.IsNullOrEmpty(NewCellTriggerID) ? null : new CellTriggerInfo(Map)
        {
          ID = NewCellTriggerID,
          Cell = Cell
        };
        Map.CellTriggerSection.Triggers[Cell] = ncelt;
        Map.Dirty = true;
        List<IEntity> rm = new List<IEntity>();
        foreach (IEntity e in Map.MapOccupancyList.Pick(Map, MapHelper.CellX(Map, Cell), MapHelper.CellY(Map, Cell)))
        {
          if (e is CellTriggerInfo)
          {
            rm.Add(e);
          }
        }
        foreach (IEntity e in rm)
        {
          Map.MapOccupancyList.RemoveEntity(e);
        }
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, ncelt);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }

    public void Undo()
    {
      if (OldCellTriggerID != NewCellTriggerID && Cell >= 0 && Cell < Map.CellTriggerSection.Triggers.Length)
      {
        CellTriggerInfo ncelt = string.IsNullOrEmpty(OldCellTriggerID) ? null : new CellTriggerInfo(Map)
        {
          ID = OldCellTriggerID,
          Cell = Cell
        };
        Map.CellTriggerSection.Triggers[Cell] = ncelt;
        Map.Dirty = true;
        List<IEntity> rm = new List<IEntity>();
        foreach (IEntity e in Map.MapOccupancyList.Pick(Map, MapHelper.CellX(Map, Cell), MapHelper.CellY(Map, Cell)))
        {
          if (e is CellTriggerInfo)
          {
            rm.Add(e);
          }
        }
        foreach (IEntity e in rm)
        {
          Map.MapOccupancyList.RemoveEntity(e);
        }
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, ncelt); 
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }
  }
}