using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class InsertEntityAction<T> : ITrackedAction
    where T : IEntity
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public T Entity;
    public int Index;
    public List<T> EntityList;

    public InsertEntityAction(Map map, MapCache cache, VirtualFileSystem vfs, T entity, List<T> list)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Entity = entity;
      EntityList = list;
      Index = list.IndexOf(entity);
      if (Index == -1)
      {
        Index = list.Count;
      }
      Description = "Insert Entity '" + entity.ToString() + "'";
    }

    public void Do()
    {
      if (!EntityList.Contains(Entity))
      {
        EntityList.Add(Entity);
        Map.Dirty = true;
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, Entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }

    public void Undo()
    {
      bool success = false;
      T entity = Entity;
      if (EntityList.Remove(entity))
      {
        success = true;
      }
      else if (EntityList.Count > Index)
      {
        if (EntityList[Index].ID == entity.ID) // don't check cell; Map shifts can change the value
        {
          entity = EntityList[Index];
          Entity = entity;
          if (EntityList.Remove(entity))
          {
            success = true;
          }
        }
      }

      if (success)
      {
        Map.Dirty = true;
        Map.MapOccupancyList.RemoveEntity(entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }
  }
}