using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class RemoveEntityAction<T> : ITrackedAction
    where T : IEntity
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public T Entity;
    public int Index;
    public List<T> EntityList;

    public RemoveEntityAction(Map map, MapCache cache, VirtualFileSystem vfs, T entity, List<T> list)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Entity = entity;
      Index = list.IndexOf(entity);
      EntityList = list;
      Description = "Remove Entity '" + entity.ToString() + "'";
    }

    public void Do()
    {
      bool success = false;
      T entity = Entity;
      if (EntityList.Remove(entity))
      {
        success = true;
      }
      else if (EntityList.Count > Index)
      {
        if (EntityList[Index].ID == entity.ID)
        {
          entity = EntityList[Index];
          if (EntityList.Remove(entity))
          {
            success = true;
          }
        }
      }

      if (success)
      {
        Map.Dirty = true;
        Map.MapOccupancyList.RemoveEntity(Entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }

    public void Undo()
    {
      if (!EntityList.Contains(Entity))
      {
        EntityList.Add(Entity);
        Map.Dirty = true;
        Map.MapOccupancyList.UpdateEntity(Map, Cache, Vfs, Entity);
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }
  }
}