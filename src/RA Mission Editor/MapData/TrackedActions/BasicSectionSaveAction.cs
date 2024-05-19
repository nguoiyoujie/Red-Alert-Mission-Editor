using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class BasicSectionSaveAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;
    public string OldBriefing;
    public string NewBriefing;

    public BasicSectionSaveAction(Map map)
    {
      Map = map;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify [Basic]";
    }

    public void SnapshotOld()
    {
      Map.BasicSection.Update(OldSection);
      OldBriefing = Map.BriefingSection.Briefing;
    }

    public void SnapshotNew()
    {
      Map.BasicSection.Update(NewSection);
      NewBriefing = Map.BriefingSection.Briefing;
    }

    public void Do()
    {
      Map.BasicSection.Read(NewSection);
      Map.BriefingSection.Briefing = NewBriefing;
      Map.Dirty = true;
    }

    public void Undo()
    {
      Map.BasicSection.Read(OldSection);
      Map.BriefingSection.Briefing = OldBriefing;
      Map.Dirty = true;
    }
  }
}