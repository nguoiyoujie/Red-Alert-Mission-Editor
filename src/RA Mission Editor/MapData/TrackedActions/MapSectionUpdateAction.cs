using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class MapSectionUpdateAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;
    public string Teamtype;

    public MapSectionUpdateAction(Map map)
    {
      Map = map;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify Map Dimensions";
    }

    public void SnapshotOld()
    {
      Map.MapSection.Update(OldSection);
    }

    public void SnapshotNew()
    {
      Map.MapSection.Update(NewSection);
    }

    public void Do()
    {
      Map.MapSection.Read(NewSection);
      Map.Dirty = true;
      Map.InvalidateTemplateDisplay?.Invoke();
    }

    public void Undo()
    {
      Map.MapSection.Read(OldSection);
      Map.Dirty = true;
      Map.InvalidateTemplateDisplay?.Invoke();
    }
  }
}