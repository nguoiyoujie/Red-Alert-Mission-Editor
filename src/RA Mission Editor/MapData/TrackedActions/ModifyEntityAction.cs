using RA_Mission_Editor.Entities;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class ModifyEntityAction<T> : ITrackedAction, ITrackedSnapshotAction
    where T : IEntity, IValueParsable<T>
  {
    public Map Map;
    public string Description { get; set; }
    public T Entity;
    public int Index;
    public List<T> EntityList;
    public string OldData;
    public string NewData;

    public ModifyEntityAction(Map map, T entity, List<T> list)
    {
      Map = map;
      Entity = entity;
      EntityList = list;
      Index = list.IndexOf(entity);
      Description = "Modify Entity '" + entity.ToString() + "'";
    }

    public ModifyEntityAction(Map map, T entity, List<T> list, string oldData, string newData)
    {
      Map = map;
      Entity = entity;
      EntityList = list;
      Index = list.IndexOf(entity);
      OldData = oldData;
      NewData = newData;
      Description = "Modify Entity '" + entity.ToString() + "'";
    }

    public void SnapshotOld()
    {
      OldData = Entity.GetValueAsString();
    }

    public void SnapshotNew()
    {
      NewData = Entity.GetValueAsString();
    }

    public void Do()
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

      if (NewData != null && entity.Parse(NewData))
      {
        Map.Dirty = true;
      }
    }

    public void Undo()
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

      if (OldData != null && entity.Parse(OldData))
      {
        Map.Dirty = true;
      }
    }
  }
}