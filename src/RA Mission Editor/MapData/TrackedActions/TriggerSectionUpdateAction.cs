using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class TriggerSectionUpdateAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;
    public string Trigger;
    public string OldTrigger;
    public string Comment;
    public string OldComment;

    public TriggerSectionUpdateAction(Map map, string trigger = null, string oldTrigger = null)
    {
      Map = map;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify Trigger";
      Trigger = trigger;
      OldTrigger = oldTrigger;
    }

    public void SnapshotOld()
    {
      Map.TriggerSection.Update(Map, OldSection);
      if (Trigger != null)
      {
        OldComment = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TriggerPrefix + Trigger);
      }
    }

    public void SnapshotNew()
    {
      Map.TriggerSection.Update(Map, NewSection);
      if (Trigger != null)
      {
        Comment = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TriggerPrefix + Trigger);
      }
    }

    public void Do()
    {
      Map.TriggerSection.Read(Map, NewSection);
      if (Trigger != null)
      {
        if (Comment != null)
        {
          Map.Ext_CommentsSection.Put(Ext_CommentsSection.TriggerPrefix + Trigger, Comment);
        }
        else
        {
          Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TriggerPrefix + Trigger);
        }
      }
      if (OldTrigger != null && OldTrigger != Trigger)
      {
        Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TriggerPrefix + OldTrigger);
      }
      Map.Dirty = true;
      Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
    }

    public void Undo()
    {
      Map.TriggerSection.Read(Map, OldSection);
      if (OldTrigger != null)
      {
        if (OldComment != null)
        {
          Map.Ext_CommentsSection.Put(Ext_CommentsSection.TriggerPrefix + OldTrigger, OldComment);
        }
        else
        {
          Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TriggerPrefix + OldTrigger);
        }
      }
      if (Trigger != null && OldTrigger != Trigger)
      {
        Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TriggerPrefix + Trigger);
      }
      Map.Dirty = true;
      Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
    }
  }
}