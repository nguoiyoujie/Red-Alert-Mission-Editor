using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;

namespace RA_Mission_Editor.Common
{
  public struct ParameterInfo
  {
    public object Value;
    public Func<object, Map, int> GetIndexFunc;
    public Func<int, Map, object> GetValueFunc;

    public int GetIndex(Map map)
    {
      if (GetIndexFunc != null)
        return GetIndexFunc(Value, map);
      else
        return -1;
    }
    public void UpdateValue(int value, Map map)
    {
      if (GetValueFunc != null)
        Value = GetValueFunc(value, map);
      else
        Value = null;
    }

    public static ParameterInfo ParameterDefault = new ParameterInfo()
    {
      GetIndexFunc = (o, _) => 
      {
        return o is int i ? i : (o != null && int.TryParse(o.ToString(), out int ii) ? ii : -1); },
      GetValueFunc = (i, _) => i,
    };

    public static ParameterInfo ParameterTeamType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is TeamTypeInfo tinfo ? m.TeamTypeSection.TeamTypeList.IndexOf(tinfo) : -1; },
      GetValueFunc = (i, m) => i >= 0 && i < m.TeamTypeSection.TeamTypeList.Count ? m.TeamTypeSection.TeamTypeList[i] : null,
    };

    public static ParameterInfo ParameterTrigger = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is TriggerInfo tinfo ? m.TriggerSection.TriggerList.IndexOf(tinfo) : -1; },
      GetValueFunc = (i, m) => i >= 0 && i < m.TriggerSection.TriggerList.Count ? m.TriggerSection.TriggerList[i] : null,
    };

    public static ParameterInfo ParameterHouse = new ParameterInfo()
    {
      // Houses somehow requires -256 offset
      GetIndexFunc = (o, m) => { return o is HouseType htype ? (-256 + m.AttachedRules.Houses.GetHouseID(htype.Name)) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Houses.GetHouse(0xFF & i),
    };

    public static ParameterInfo ParameterMissionType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is MissionType mtype ? Missions.GetID(mtype.Name) : -1; },
      GetValueFunc = (i, m) => Missions.Get(i),
    };

    public static ParameterInfo ParameterStructureType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is StructureType type ? m.AttachedRules.Structures.GetID(type.ID) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Structures.Get(i),
    };

    public static ParameterInfo ParameterInfantryType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is InfantryType type ? m.AttachedRules.Infantries.GetID(type.ID) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Infantries.Get(i),
    };

    public static ParameterInfo ParameterUnitType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is UnitType type ? m.AttachedRules.Units.GetID(type.ID) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Units.Get(i),
    };

    public static ParameterInfo ParameterShipType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is ShipType type ? m.AttachedRules.Ships.GetID(type.ID) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Ships.Get(i),
    };

    public static ParameterInfo ParameterAircraftType = new ParameterInfo()
    {
      GetIndexFunc = (o, m) => { return o is AircraftType type ? m.AttachedRules.Aircrafts.GetID(type.ID) : -1; },
      GetValueFunc = (i, m) => m.AttachedRules.Aircrafts.Get(i),
    };

    public static ParameterInfo ParameterEnum<T>()
    {
      return new ParameterInfo()
      {
        GetIndexFunc = (o, m) => { return o is T tobj ? Convert.ToInt32(tobj) : -1; },
        GetValueFunc = (i, m) => (T)(object)i,
      };
    }
  }
}
