using RA_Mission_Editor.Common;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;

namespace RA_Mission_Editor.Entities
{
  public class TriggerInfo
  {
    // slightly complicated because Iran's hack mixed the intended Parameter types
    public struct EventInfo
    {
      public TEventType EventType;
      public ParameterInfo Parameter1; // original: Team
      public ParameterInfo Parameter2;
    }

    public struct ActionInfo
    {
      public TActionType ActionType;
      public ParameterInfo Parameter1; // original: Team
      public ParameterInfo Parameter2; // original: Trigger
      public ParameterInfo Parameter3;
    }

    // NAME=PERSIST,HOUSE,EVENTMODE,ACTIONMODE,E1,E1P1,E1P2,E2,E2P1,E2P2,A1,A1P1,A1P2,A1P3,A2,A2P1,A2P2,A2P3
    // Example: g0=2,1,1,1,27,-1,0,13,-1,1,28,-1,-1,15,29,-1,-1,0
    public string Name { get; set; } // Name
    public PersistantType PersistanceControl; // Persistence: 0=Fire once on any, 1=Fire once on all, 2=Fire always on any
    public int Owner { get; set; } // Owning house
    public MultiStyleType EventControl;
    public MultiStyleType ActionControl; // only 0 and 1 are effective. Other values are handled just like 1.
    public EventInfo Event1;
    public EventInfo Event2;
    public ActionInfo Action1;
    public ActionInfo Action2;
    public string Comment;

    public string GetKeyAsString()
    {
      return Name;
    }

    public string GetValueAsString(Map map)
    {
      return string.Join(",", (byte)PersistanceControl
                            , Owner
                            , (byte)EventControl
                            , (byte)ActionControl
                            , (byte)Event1.EventType
                            , Event1.Parameter1.GetIndex(map)
                            , Event1.Parameter2.GetIndex(map)
                            , (byte)Event2.EventType
                            , Event2.Parameter1.GetIndex(map)
                            , Event2.Parameter2.GetIndex(map)
                            , (byte)Action1.ActionType
                            , Action1.Parameter1.GetIndex(map)
                            , Action1.Parameter2.GetIndex(map)
                            , Action1.Parameter3.GetIndex(map)
                            , (byte)Action2.ActionType
                            , Action2.Parameter1.GetIndex(map)
                            , Action2.Parameter2.GetIndex(map)
                            , Action2.Parameter3.GetIndex(map)
                            );
    }

    public string GetExtKeyAsString()
    {
      return Ext_CommentsSection.TriggerPrefix + Name;
    }

    public string GetExtValueAsString()
    {
      return Comment;
    }

    public override string ToString()
    {
      return $"{Name}";
    }

    public static ParameterInfo SelectParameterInfo(TriggerParameterFlag flag)
    {
      if (flag.Contains(TriggerParameterFlag.TEAMTYPE))
      {
        return ParameterInfo.ParameterTeamType;
      }
      else if (flag.Contains(TriggerParameterFlag.TRIGGER))
      {
        return ParameterInfo.ParameterTrigger;
      }
      else if (flag.Contains(TriggerParameterFlag.HOUSE))
      {
        return ParameterInfo.ParameterHouse;
      }
      else if (flag.Contains(TriggerParameterFlag.STRUCTURETYPE))
      {
        return ParameterInfo.ParameterStructureType;
      }
      else if (flag.Contains(TriggerParameterFlag.INFANTRYTYPE))
      {
        return ParameterInfo.ParameterInfantryType;
      }
      else if (flag.Contains(TriggerParameterFlag.UNITTYPE))
      {
        return ParameterInfo.ParameterUnitType;
      }
      else if (flag.Contains(TriggerParameterFlag.SHIPTYPE))
      {
        return ParameterInfo.ParameterShipType;
      }
      else if (flag.Contains(TriggerParameterFlag.AIRCRAFTTYPE))
      {
        return ParameterInfo.ParameterAircraftType;
      }
      else if (flag.Contains(TriggerParameterFlag.GLOBALS))
      {
        return ParameterInfo.ParameterGlobals;
      }
      else if (flag.Contains(TriggerParameterFlag.MESSAGE))
      {
        return ParameterInfo.ParameterMessage;
      }
      else if (flag.Contains(TriggerParameterFlag.COLOR))
      {
        return ParameterInfo.ParameterColorType;
      }
      else if (flag.Contains(TriggerParameterFlag.SOUND))
      {
        return ParameterInfo.ParameterSoundType;
      }
      else if (flag.Contains(TriggerParameterFlag.SPEECH))
      {
        return ParameterInfo.ParameterSpeechType;
      }
      else if (flag.Contains(TriggerParameterFlag.THEME))
      {
        return ParameterInfo.ParameterTheme;
      }
      else if (flag.Contains(TriggerParameterFlag.SWTYPE))
      {
        return ParameterInfo.ParameterSpecialWeapon;
      }
      else if (flag.Contains(TriggerParameterFlag.MISSIONTYPE))
      {
        return ParameterInfo.ParameterMissionType;
      }
      else
        return ParameterInfo.ParameterDefault;
    }

    public static TriggerInfo Populate(string index)
    {
      TriggerInfo s = new TriggerInfo();
      s.Name = index;
      return s;
    }

    public void ParseValue(Map map, string value)
    {
      string[] tokens = value.Split(',');
      if (tokens.Length < 18)
      {
        throw new Exception($"Map Trigger {Name} contains less than expected parameters");
      }
      unchecked
      {
        PersistanceControl = (PersistantType)byte.Parse(tokens[0]);
        Owner = int.Parse(tokens[1]);
        EventControl = (MultiStyleType)byte.Parse(tokens[2]);
        ActionControl = (MultiStyleType)byte.Parse(tokens[3]);

        Event1.EventType = (TEventType)int.Parse(tokens[4]);
        TriggerEventType tE1 = TriggerEvents.GetTriggerEvent((int)Event1.EventType);
        Event1.Parameter1 = SelectParameterInfo(tE1.P1Type);
        Event1.Parameter1.UpdateValue(int.Parse(tokens[5]), map);
        Event1.Parameter2 = SelectParameterInfo(tE1.P2Type);
        Event1.Parameter2.UpdateValue(int.Parse(tokens[6]), map);

        Event2.EventType = (TEventType)int.Parse(tokens[7]);
        TriggerEventType tE2 = TriggerEvents.GetTriggerEvent((int)Event2.EventType);
        Event2.Parameter1 = SelectParameterInfo(tE2.P1Type);
        Event2.Parameter1.UpdateValue(int.Parse(tokens[8]), map);
        Event2.Parameter2 = SelectParameterInfo(tE2.P2Type);
        Event2.Parameter2.UpdateValue(int.Parse(tokens[9]), map);

        Action1.ActionType = (TActionType)int.Parse(tokens[10]);
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)Action1.ActionType);
        Action1.Parameter1 = SelectParameterInfo(tA1.P1Type);
        Action1.Parameter1.UpdateValue(int.Parse(tokens[11]), map);
        Action1.Parameter2 = SelectParameterInfo(tA1.P2Type);
        Action1.Parameter2.UpdateValue(int.Parse(tokens[12]), map);
        Action1.Parameter3 = SelectParameterInfo(tA1.P3Type);
        Action1.Parameter3.UpdateValue(int.Parse(tokens[13]), map);

        Action2.ActionType = (TActionType)int.Parse(tokens[14]);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)Action2.ActionType);
        Action2.Parameter1 = SelectParameterInfo(tA2.P1Type);
        Action2.Parameter1.UpdateValue(int.Parse(tokens[15]), map);
        Action2.Parameter2 = SelectParameterInfo(tA2.P2Type);
        Action2.Parameter2.UpdateValue(int.Parse(tokens[16]), map);
        Action2.Parameter3 = SelectParameterInfo(tA2.P3Type);
        Action2.Parameter3.UpdateValue(int.Parse(tokens[17]), map);

        /*
        s.Event1.EventType = (TEventType)int.Parse(tokens[4]);
        s.Event1.Parameter1 = int.Parse(tokens[5]);
        s.Event1.Parameter2 = int.Parse(tokens[6]);
        s.Event2.EventType = (TEventType)int.Parse(tokens[7]);
        s.Event2.Parameter1 = int.Parse(tokens[8]);
        s.Event2.Parameter2 = int.Parse(tokens[9]);
        s.Action1.ActionType = (TActionType)int.Parse(tokens[10]);
        s.Action1.Parameter1 = int.Parse(tokens[11]);
        s.Action1.Parameter2 = int.Parse(tokens[12]);
        s.Action1.Parameter3 = int.Parse(tokens[13]);
        s.Action2.ActionType = (TActionType)int.Parse(tokens[14]);
        s.Action2.Parameter1 = int.Parse(tokens[15]);
        s.Action2.Parameter2 = int.Parse(tokens[16]);
        s.Action2.Parameter3 = int.Parse(tokens[17]);
        */
      }
    }
  }
}
