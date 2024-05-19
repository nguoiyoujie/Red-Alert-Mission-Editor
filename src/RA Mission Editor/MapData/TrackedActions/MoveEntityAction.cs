using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class MoveEntityAction<T> : ITrackedAction, ITrackedSnapshotAction
    where T : IEntity, ILocatable
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public T Entity;
    public int Index;
    public List<T> EntityList;
    public int OldCell;
    public int NewCell;
    public byte OldSubCell;
    public byte NewSubCell;

    public MoveEntityAction(Map map, MapCache cache, VirtualFileSystem vfs, T entity, List<T> list)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Entity = entity;
      EntityList = list;
      Index = list.IndexOf(entity);
      Description = "Drag Entity '" + entity.ToString() + "'";
    }

    public void SnapshotOld()
    {
      OldCell = Entity.Cell;
      if (Entity is InfantryInfo inf)
      {
        OldSubCell = inf.SubCell;
      }
    }

    public void SnapshotNew()
    {
      NewCell = Entity.Cell;
      if (Entity is InfantryInfo inf)
      {
        NewSubCell = inf.SubCell;
      }
    }

    public void Do()
    {
      if (OldCell != NewCell || OldSubCell != NewSubCell)
      {
        T entity = Entity;
        if (!EntityList.Contains(entity))
        {
          if (EntityList.Count > Index)
          {
            if (EntityList[Index].ID == entity.ID)
            {
              entity = EntityList[Index];
            }
          }
        }

        entity.Cell = NewCell;
        if (entity is InfantryInfo inf)
        {
          inf.SubCell = NewSubCell;
        }
        Map.Dirty = true;
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }

    public void Undo()
    {
      if (OldCell != NewCell || OldSubCell != NewSubCell)
      {
        T entity = Entity;
        if (!EntityList.Contains(entity))
        {
          if (EntityList.Count > Index)
          {
            if (EntityList[Index].ID == entity.ID)
            {
              entity = EntityList[Index];
            }
          }
        }

        entity.Cell = OldCell;
        if (entity is InfantryInfo inf)
        {
          inf.SubCell = OldSubCell;
        }
        Map.Dirty = true;
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }
  }
}