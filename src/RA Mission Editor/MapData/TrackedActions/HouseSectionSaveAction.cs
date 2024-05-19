using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class HouseSectionSaveAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public string Description { get; set; }
    public IniFile.IniSection OldSection;
    public IniFile.IniSection NewSection;
    public string House;

    public HouseSectionSaveAction(Map map, string house)
    {
      Map = map;
      House = house;
      OldSection = new IniFile.IniSection();
      NewSection = new IniFile.IniSection();
      Description = "Modify House " + house;
    }

    public void SnapshotOld()
    {
      Map.HouseSections[Map.AttachedRules.Houses.GetHouseID(House)].Update(OldSection);
    }

    public void SnapshotNew()
    {
      Map.HouseSections[Map.AttachedRules.Houses.GetHouseID(House)].Update(NewSection);
    }

    public void Do()
    {
      Map.HouseSections[Map.AttachedRules.Houses.GetHouseID(House)].Read(NewSection);
      Map.Update();
      Map.AttachedRules.ApplyRules();
      Map.AttachedRules.ApplyRulesWithMap(Map);
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }

    public void Undo()
    {
      Map.HouseSections[Map.AttachedRules.Houses.GetHouseID(House)].Read(OldSection);
      Map.Update();
      Map.AttachedRules.ApplyRules();
      Map.AttachedRules.ApplyRulesWithMap(Map);
      Map.Dirty = true;
      Map.InvalidateObjectDisplay?.Invoke();
    }
  }
}