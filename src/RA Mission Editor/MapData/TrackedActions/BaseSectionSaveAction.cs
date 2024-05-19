using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class BaseSectionSaveAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;

    public BaseSectionSaveAction(Map map)
    {
      Map = map;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify [Base]";
    }

    public void SnapshotOld()
    {
      Map.BaseSection.Update(Map, OldSection);
    }

    public void SnapshotNew()
    {
      Map.BaseSection.Update(Map, NewSection);
    }

    public void Do()
    {
      Map.BaseSection.Update(Map, NewSection);
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }

    public void Undo()
    {
      Map.BaseSection.Update(Map, OldSection);
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }
  }
}