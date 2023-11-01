using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;

namespace RA_Mission_Editor.Common
{
  public class PlaceEntityInfo
  {
    public IEntityType Type;
    public int X;
    public int Y;
    public byte TemplateCell = 0xFF;
    public byte SubCell; // for infantry
    public string Owner = null;
    public short Health = 256;
    public byte Facing = 0;
    public string Tag = null;
    public MissionType Mission = Missions.Get("Guard");
    public bool IsBase = false;
    public int BaseNumber = -1;
    public bool AIRepairable = false;
    public bool AISellable = false;

    public PlaceEntityInfo() { }

    public PlaceEntityInfo(IEntityType type, int x, int y, byte templatecell = 0xFF)
    {
      Type = type;
      X = x;
      Y = y;
      TemplateCell = templatecell;
      Owner = null;
    }

    // mobile technotypes
    public PlaceEntityInfo(IEntityType type, int x, int y, HouseType owner, short health, byte facing, string tag, MissionType mission, byte subCell = 0) : this(type, x, y)
    {
      Owner = owner.Name;
      Health = health;
      Facing = facing;
      Tag = tag;
      SubCell = subCell;
      Mission = mission ?? Missions.Get("Guard");
    }

    // base technotypes
    public PlaceEntityInfo(IEntityType type, int x, int y, HouseType owner, short health, byte facing, string tag, int baseNumber) : this(type, x, y, owner, health, facing, tag, null)
    {
      IsBase = true;
      BaseNumber = baseNumber;
    }

    // building technotypes
    public PlaceEntityInfo(IEntityType type, int x, int y, HouseType owner, short health, byte facing, string tag, bool aiRepairable, bool aiSellable) : this(type, x, y, owner, health, facing, tag, null)
    {
      IsBase = false;
      AIRepairable = aiRepairable;
      AISellable = aiSellable;
    }

    public void Update(Map map, IEntity entity)
    {
      Type = entity.GetEntityType(map.AttachedRules);

      // X, Y, Subcell are not updated
      if (entity is InfantryInfo iinfo)
      {
        Owner = iinfo.Owner;
        Health = iinfo.Health;
        Facing = iinfo.Facing;
        Tag = iinfo.Tag;
        Mission = Missions.Get(iinfo.Mission) ?? Missions.Get("Guard");
      }
      else if (entity is UnitInfo uinfo)
      {
        Owner = uinfo.Owner;
        Health = uinfo.Health;
        Facing = uinfo.Facing;
        Tag = uinfo.Tag;
        Mission = Missions.Get(uinfo.Mission) ?? Missions.Get("Guard");
      }
      else if (entity is VesselInfo sinfo)
      {
        Owner = sinfo.Owner;
        Health = sinfo.Health;
        Facing = sinfo.Facing;
        Tag = sinfo.Tag;
        Mission = Missions.Get(sinfo.Mission) ?? Missions.Get("Guard");
      }
      if (entity is BuildingInfo tinfo)
      {
        Owner = tinfo.Owner;
        Health = tinfo.Health;
        Facing = tinfo.Facing;
        Tag = tinfo.Tag;
        AIRepairable = tinfo.AIRepairable;
        AISellable = tinfo.AISellable;
        IsBase = false;
      }

      if (entity is BaseInfo binfo)
      {
        IsBase = true;
      }
    }
  }
}
