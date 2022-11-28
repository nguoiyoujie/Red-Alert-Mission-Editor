using RA_Mission_Editor.Common;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.Entities
{
  public class TeamTypeInfo
  {
    public struct TechnoCountInfo
    {
      public string ID;
      public int Num;

      public override string ToString()
      {
        return ID + ":" + Num;
      }
    }

    public struct ScriptInfo
    {
      public int ScriptType;
      public ParameterInfo Parameter;
    }

    public struct TeamTypeBitField
    {
      public bool AvoidThreats;
      public bool Suicide;
      public bool AutoCreate;
      public bool PrebuildMembers;
      public bool Reinforce;
      //public bool Transient; // used internally for reinforcements

      public int GetCode()
      {
        return (AvoidThreats ? 0x01 : 0)
             | (Suicide ? 0x02 : 0)
             | (AutoCreate ? 0x04 : 0)
             | (PrebuildMembers ? 0x08 : 0)
             | (Reinforce ? 0x10 : 0)
             ;
      }

      public static TeamTypeBitField FromCode(int code)
      {
        TeamTypeBitField b = new TeamTypeBitField();
        b.AvoidThreats = (code & 0x01) == 0x01;
        b.Suicide = (code & 0x02) == 0x02;
        b.AutoCreate = (code & 0x04) == 0x04;
        b.PrebuildMembers = (code & 0x08) == 0x08;
        b.Reinforce = (code & 0x10) == 0x10;
        return b;
      }
    }

    // NAME=HOUSE,BITFIELD,PRIORITY,INITNUM,MAX,WAYPOINT,WAYPOINT,TRIGGER,TECHNOCOUNTNUM,[TECHNOCOUNTLIST],SCRIPTNUM,[SCRIPTLIST]
    // Example: A_G21=6,2,7,0,0,72,-1,1,E1:2,2,3:2,12:21
    public string Name { get; set; } // Name
    public int Owner { get; set; } // Owning house as int
    public TeamTypeBitField BitField;

    public int Priority;
    public int InitNum;
    public int MaxAllowed;
    public int WaypointID;
    public TriggerInfo Trigger; // link
    public List<TechnoCountInfo> TechnoList = new List<TechnoCountInfo>(Constants.TEAMTYPE_MAX_TECHNOLIST);
    public List<ScriptInfo> ScriptList = new List<ScriptInfo>(Constants.TEAMTYPE_MAX_SCRIPTLIST);
    public string Comment;

    public string GetKeyAsString()
    {
      return Name;
    }

    public string GetValueAsString(Map map)
    {
      List<string> techno = new List<string>(TechnoList.Count);
      foreach (TechnoCountInfo t in TechnoList)
      {
        techno.Add(t.ID + ":" + t.Num); 
      }
      string techno_str = string.Join(",", techno);

      List<string> script = new List<string>(ScriptList.Count);
      foreach (ScriptInfo s in ScriptList)
      {
        script.Add(s.ScriptType + ":" + s.Parameter.GetIndex(map));
      }
      string script_str = string.Join(",", script);

      if (techno_str.Length > 0) { techno_str = TechnoList.Count + "," + techno_str; } else { techno_str = "0"; }
      if (script_str.Length > 0) { script_str = ScriptList.Count + "," + script_str; } else { script_str = "0"; }
      return string.Join(",", Owner
                            , BitField.GetCode()
                            , Priority
                            , InitNum
                            , MaxAllowed
                            , WaypointID
                            , map.TriggerSection.TriggerList.IndexOf(Trigger)
                            , techno_str
                            , script_str
                            );
    }

    public string GetExtKeyAsString()
    {
      return Ext_CommentsSection.TeamTypePrefix + Name;
    }

    public string GetExtValueAsString()
    {
      return Comment;
    }

    public override string ToString()
    {
      int ucount = 0;
      foreach (var t in TechnoList)
      {
        ucount += t.Num;
      }
      return $"{Name}, {ucount} units";
    }

    public static ParameterInfo SelectParameterInfo(ScriptParameterType type)
    {
      switch (type)
      {
        case ScriptParameterType.QUARRY:
          return ParameterInfo.ParameterEnum<QuarryType>();
        case ScriptParameterType.MISSIONTYPE:
          return ParameterInfo.ParameterMissionType;
        case ScriptParameterType.NONE:
        case ScriptParameterType.INTEGER:
        case ScriptParameterType.WAYPOINT:
        case ScriptParameterType.FORMATION:
        default:
          return ParameterInfo.ParameterDefault;
      }
    }

    public void ParseValue(Map map, string value)
    {
      string[] tokens = value.Split(',');
      if (tokens.Length < 8)
      {
        throw new Exception($"Map TeamType {Name} contains less than expected parameters");
      }
      Owner = int.Parse(tokens[0]);
      BitField = TeamTypeBitField.FromCode(int.Parse(tokens[1]));
      Priority = int.Parse(tokens[2]);
      InitNum = int.Parse(tokens[3]);
      MaxAllowed = int.Parse(tokens[4]);
      WaypointID = int.Parse(tokens[5]);
      int i = int.Parse(tokens[6]);
      Trigger = i >= 0 && i < map.TriggerSection.TriggerList.Count ? map.TriggerSection.TriggerList[i] : null;

      int technocount = int.Parse(tokens[7]);
      for (int n = 0; n < technocount; n++)
      {
        string[] kp = tokens[8 + n].Split(':');
        TechnoList.Add(new TechnoCountInfo() { ID = kp[0], Num = int.Parse(kp[1])});
      }

      int scriptcount = int.Parse(tokens[8 + technocount]);
      for (int n = 0; n < scriptcount; n++)
      {
        string[] kp = tokens[9 + technocount + n].Split(':');
        int scriptTypeID = int.Parse(kp[0]);
        ScriptActionType stype = ScriptActions.GetScriptAction(scriptTypeID);
        ScriptInfo sinfo = new ScriptInfo { ScriptType = int.Parse(kp[0]), Parameter = SelectParameterInfo(stype.ParameterType) };
        sinfo.Parameter.UpdateValue(int.Parse(kp[1]), map);
        ScriptList.Add(sinfo);
      }
    }
  }
}
