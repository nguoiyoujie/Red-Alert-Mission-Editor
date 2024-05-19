using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class TeamTypeSectionUpdateAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;
    public string Teamtype;
    public string OldTeamtype;
    public string Comment;
    public string OldComment;

    public TeamTypeSectionUpdateAction(Map map, string teamtype = null, string oldTeamtype = null)
    {
      Map = map;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify TeamType";
      Teamtype = teamtype;
      OldTeamtype = oldTeamtype;
    }

    public void SnapshotOld()
    {
      Map.TeamTypeSection.Update(Map, OldSection);
      if (Teamtype != null)
      {
        OldComment = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TeamTypePrefix + Teamtype);
      }
    }

    public void SnapshotNew()
    {
      Map.TeamTypeSection.Update(Map, NewSection);
      if (Teamtype != null)
      {
        Comment = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TeamTypePrefix + Teamtype);
      }
    }

    public void Do()
    {
      Map.TeamTypeSection.ReadFirst(NewSection);
      Map.TeamTypeSection.ReadNext(Map, NewSection);
      if (Teamtype != null)
      {
        if (Comment != null)
        {
          Map.Ext_CommentsSection.Put(Ext_CommentsSection.TeamTypePrefix + Teamtype, Comment);
        }
        else
        {
          Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TeamTypePrefix + Teamtype);
        }
      }
      if (OldTeamtype != null && OldTeamtype != Teamtype)
      {
        Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TeamTypePrefix + OldTeamtype);
      }
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }

    public void Undo()
    {
      Map.TeamTypeSection.ReadFirst(OldSection);
      Map.TeamTypeSection.ReadNext(Map, OldSection);
      if (OldTeamtype != null)
      {
        if (OldComment != null)
        {
          Map.Ext_CommentsSection.Put(Ext_CommentsSection.TeamTypePrefix + OldTeamtype, OldComment);
        }
        else
        {
          Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TeamTypePrefix + OldTeamtype);
        }
      }
      if (Teamtype != null && OldTeamtype != Teamtype)
      {
        Map.Ext_CommentsSection.Remove(Ext_CommentsSection.TeamTypePrefix + Teamtype);
      }
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }
  }
}