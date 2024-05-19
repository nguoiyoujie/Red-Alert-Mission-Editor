namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class GenericCommentSaveAction : ITrackedAction
  {
    public Map Map;
    public string Description { get; set; }
    public string Key;
    public string Value;
    public string OldValue;

    public GenericCommentSaveAction(Map map, string key, string value)
    {
      Map = map;
      Key = key;
      Value = value;
      OldValue = Map.Ext_CommentsSection.Get(key);
      Description = "Modify Comment " + key;
    }

    public void Do()
    {
      if (Value != null)
      {
        Map.Ext_CommentsSection.Put(Key, Value);
      }
      else
      {
        Map.Ext_CommentsSection.Remove(Key);
      }
      Map.Dirty = true;
    }

    public void Undo()
    {
      if (OldValue != null)
      {
        Map.Ext_CommentsSection.Put(Key, OldValue);
      }
      else
      {
        Map.Ext_CommentsSection.Remove(Key);
      }
      Map.Dirty = true;
    }
  }
}