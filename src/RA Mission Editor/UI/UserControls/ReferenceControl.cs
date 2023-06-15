using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class ReferenceControl : UserControl
  {
    public ReferenceControl()
    {
      InitializeComponent();
    }

    public Map Map { get; private set; }
    private StringBuilder _sb = new StringBuilder(1024);

    public void SetMap(Map map)
    {
      Map = map;
    }

    private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Map == null) { return; }

      cbItem.Items.Clear();
      switch (cbCategory.Text)
      {
        case "Waypoint":
          {
            object[] olst = new object[100];
            for (int i = 0; i < olst.Length; i++)
            {
              olst[i] = i;
            }
            cbItem.Items.AddRange(olst);
          }
          break;
        case "Trigger":
          cbItem.Items.AddRange(Map.TriggerSection.TriggerList.ToArray());
          break;
        case "TeamType":
          cbItem.Items.AddRange(Map.TeamTypeSection.TeamTypeList.ToArray());
          break;
        case "Global":
          {
            object[] olst = new object[Constants.MAX_GLOBALS];
            for (int i = 0; i < olst.Length; i++)
            {
              olst[i] = ParameterInfo.ParameterGlobals.GetValueFunc(i, Map);
            }
            cbItem.Items.AddRange(olst);
          }
          break;
        case "Mission Text":
          if (!Map.BasicSection.UseCustomTutorialText.Value)
          {
            if (Map.AttachedRules.LanguageText != null)
            {
              object[] olst = new object[Map.AttachedRules.LanguageText.Count];
              for (int i = 0; i < olst.Length; i++)
              {
                olst[i] = ParameterInfo.ParameterMessage.GetValueFunc(i, Map);
              }
              cbItem.Items.AddRange(olst);
            }
          }
          else
          {
            object[] olst = new object[Map.TutorialSection.Messages.Count];
            int i = 0;
            foreach (var kvp in Map.TutorialSection.Messages)
            {
              olst[i++] = ParameterInfo.ParameterMessage.GetValueFunc(kvp.Key, Map);
            }
            cbItem.Items.AddRange(olst);
          }
          break;
      }
      if (cbItem.Items.Count > 0)
      {
        cbItem.SelectedIndex = 0;
      }
    }

    private void UpdateView(object sender, EventArgs e)
    {
      if (Map == null) { return; }

      if (cbItem.SelectedItem is TriggerInfo trig)
      {
        Search(trig);
      }
      else if (cbItem.SelectedItem is TeamTypeInfo team)
      {
        Search(team);
      }
      else if (cbItem.SelectedItem is IntValueDesc idesc)
      {
        switch (cbCategory.Text)
        {
          case "Waypoint":
            SearchWaypoint(idesc.Value);
            break;
          case "Global":
            SearchGlobal(idesc.Value);
            break;
          case "Mission Text":
            SearchMissionText(idesc.Value);
            break;
        }
      }
      else if (cbItem.SelectedItem is int i)
      {
        switch (cbCategory.Text)
        {
          case "Waypoint":
            SearchWaypoint(i);
            break;
          case "Global":
            SearchGlobal(i);
            break;
          case "Mission Text":
            SearchMissionText(i);
            break;
        }
      }
    }

    private void Search(TriggerInfo info)
    {
      _sb.Clear();
      _sb.AppendLine("Trigger " + info.Name);
      _sb.AppendLine("---------------------------------------");

      foreach (var trig in Map.TriggerSection.TriggerList)
      {
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)trig.Action1.ActionType);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)trig.Action2.ActionType);

        if ((tA1.P1Type == TriggerParameterFlag.TRIGGER && trig.Action1.Parameter1.Value == info)
          || (tA1.P2Type == TriggerParameterFlag.TRIGGER && trig.Action1.Parameter2.Value == info)
          || (tA1.P3Type == TriggerParameterFlag.TRIGGER && trig.Action1.Parameter3.Value == info)
          )
        {
          _sb.AppendLine("Trigger (Action 1) \t" + trig.Name);
        }

        if ((tA2.P1Type == TriggerParameterFlag.TRIGGER && trig.Action2.Parameter1.Value == info)
          || (tA2.P2Type == TriggerParameterFlag.TRIGGER && trig.Action2.Parameter2.Value == info)
          || (tA2.P3Type == TriggerParameterFlag.TRIGGER && trig.Action2.Parameter3.Value == info)
          )
        {
          _sb.AppendLine("Trigger (Action 2) \t" + trig.Name);
        }
      }

      foreach (var team in Map.TeamTypeSection.TeamTypeList)
      {
        if (team.Trigger == info)
        {
          _sb.AppendLine("TeamType \t" + team.Name);
        }
      }

      foreach (var inf in Map.InfantrySection.InfantryList)
      {
        if (inf.Tag == info.Name)
        {
          _sb.AppendLine("Infantry \t" + inf.ToString());
        }
      }

      foreach (var inf in Map.UnitSection.UnitList)
      {
        if (inf.Tag == info.Name)
        {
          _sb.AppendLine("Unit \t" + inf.ToString());
        }
      }

      foreach (var inf in Map.ShipSection.ShipList)
      {
        if (inf.Tag == info.Name)
        {
          _sb.AppendLine("Vessel \t" + inf.ToString());
        }
      }

      foreach (var inf in Map.StructureSection.StructureList)
      {
        if (inf.Tag == info.Name)
        {
          _sb.AppendLine("Building \t" + inf.ToString());
        }
      }

      tbRef.Text = _sb.ToString();
    }

    private void Search(TeamTypeInfo info)
    {
      _sb.Clear();
      _sb.AppendLine("TeamType " + info.Name);
      _sb.AppendLine("---------------------------------------");
      
      foreach (var trig in Map.TriggerSection.TriggerList)
      {
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)trig.Action1.ActionType);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)trig.Action2.ActionType);

        if ((tA1.P1Type == TriggerParameterFlag.TEAMTYPE && trig.Action1.Parameter1.Value == info)
          || (tA1.P2Type == TriggerParameterFlag.TEAMTYPE && trig.Action1.Parameter2.Value == info)
          || (tA1.P3Type == TriggerParameterFlag.TEAMTYPE && trig.Action1.Parameter3.Value == info)
          )
        {
          _sb.AppendLine("Trigger (Action 1) \t" + trig.Name);
        }

        if ((tA2.P1Type == TriggerParameterFlag.TEAMTYPE && trig.Action2.Parameter1.Value == info)
          || (tA2.P2Type == TriggerParameterFlag.TEAMTYPE && trig.Action2.Parameter2.Value == info)
          || (tA2.P3Type == TriggerParameterFlag.TEAMTYPE && trig.Action2.Parameter3.Value == info)
          )
        {
          _sb.AppendLine("Trigger (Action 2) \t" + trig.Name);
        }
      }

      tbRef.Text = _sb.ToString();
    }

    private void SearchWaypoint(int waypoint)
    {
      _sb.Clear();
      _sb.AppendLine("Waypoint " + waypoint);
      _sb.AppendLine("---------------------------------------");

      foreach (var trig in Map.TriggerSection.TriggerList)
      {
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)trig.Action1.ActionType);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)trig.Action2.ActionType);
        TriggerEventType tE1 = TriggerEvents.GetTriggerEvent((int)trig.Event1.EventType);
        TriggerEventType tE2 = TriggerEvents.GetTriggerEvent((int)trig.Event2.EventType);

        if ((tA1.P1Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action1.Parameter1.Value) || (trig.Action1.Parameter1.Value is IntValueDesc iv11 && waypoint.Equals(iv11.Value))))
         || (tA1.P2Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action1.Parameter2.Value) || (trig.Action1.Parameter2.Value is IntValueDesc iv12 && waypoint.Equals(iv12.Value))))
         || (tA1.P3Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action1.Parameter3.Value) || (trig.Action1.Parameter3.Value is IntValueDesc iv13 && waypoint.Equals(iv13.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 1) \t" + trig.Name);
        }

        if ((tA2.P1Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action2.Parameter1.Value) || (trig.Action2.Parameter1.Value is IntValueDesc iv21 && waypoint.Equals(iv21.Value))))
         || (tA2.P2Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action2.Parameter2.Value) || (trig.Action2.Parameter2.Value is IntValueDesc iv22 && waypoint.Equals(iv22.Value))))
         || (tA2.P3Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Action2.Parameter3.Value) || (trig.Action2.Parameter3.Value is IntValueDesc iv23 && waypoint.Equals(iv23.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 2) \t" + trig.Name);
        }

        if ((tE1.P1Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Event1.Parameter1.Value) || (trig.Event1.Parameter1.Value is IntValueDesc ev11 && waypoint.Equals(ev11.Value))))
         || (tE1.P2Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Event1.Parameter2.Value) || (trig.Event1.Parameter2.Value is IntValueDesc ev12 && waypoint.Equals(ev12.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 1) \t" + trig.Name);
        }

        if ((tE2.P1Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Event2.Parameter1.Value) || (trig.Event2.Parameter1.Value is IntValueDesc ev21 && waypoint.Equals(ev21.Value))))
         || (tE2.P2Type == TriggerParameterFlag.WAYPOINT && (waypoint.Equals(trig.Event2.Parameter2.Value) || (trig.Event2.Parameter2.Value is IntValueDesc ev22 && waypoint.Equals(ev22.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 2) \t" + trig.Name);
        }
      }

      foreach (var team in Map.TeamTypeSection.TeamTypeList)
      {
        if (team.WaypointID == waypoint)
        {
          _sb.AppendLine("TeamType (Waypoint) \t" + team.Name);
        }

        int line = 0;
        foreach (var script in team.ScriptList) 
        {
          ScriptActionType satype = ScriptActions.GetScriptAction(script.ScriptType);
          if (satype.ParameterType == ScriptParameterType.WAYPOINT && waypoint.Equals(script.Parameter.Value))
          {
            _sb.AppendLine("TeamType (Script Line " + line + ") \t" + team.Name);
          }
          line++;
        }
      }

      tbRef.Text = _sb.ToString();
    }

    private void SearchGlobal(int global)
    {
      _sb.Clear();
      _sb.AppendLine("Global variable \t" + global);
      _sb.AppendLine("---------------------------------------");

      foreach (var trig in Map.TriggerSection.TriggerList)
      {
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)trig.Action1.ActionType);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)trig.Action2.ActionType);
        TriggerEventType tE1 = TriggerEvents.GetTriggerEvent((int)trig.Event1.EventType);
        TriggerEventType tE2 = TriggerEvents.GetTriggerEvent((int)trig.Event2.EventType);

        if ((tA1.P1Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action1.Parameter1.Value) || (trig.Action1.Parameter1.Value is IntValueDesc iv11 && global.Equals(iv11.Value))))
         || (tA1.P2Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action1.Parameter2.Value) || (trig.Action1.Parameter2.Value is IntValueDesc iv12 && global.Equals(iv12.Value))))
         || (tA1.P3Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action1.Parameter3.Value) || (trig.Action1.Parameter3.Value is IntValueDesc iv13 && global.Equals(iv13.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 1) \t" + trig.Name);
        }

        if ((tA2.P1Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action2.Parameter1.Value) || (trig.Action2.Parameter1.Value is IntValueDesc iv21 && global.Equals(iv21.Value))))
         || (tA2.P2Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action2.Parameter2.Value) || (trig.Action2.Parameter2.Value is IntValueDesc iv22 && global.Equals(iv22.Value))))
         || (tA2.P3Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Action2.Parameter3.Value) || (trig.Action2.Parameter3.Value is IntValueDesc iv23 && global.Equals(iv23.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 2) \t" + trig.Name);
        }

        if ((tE1.P1Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Event1.Parameter1.Value) || (trig.Event1.Parameter1.Value is IntValueDesc ev11 && global.Equals(ev11.Value))))
         || (tE1.P2Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Event1.Parameter2.Value) || (trig.Event1.Parameter2.Value is IntValueDesc ev12 && global.Equals(ev12.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 1) \t" + trig.Name);
        }

        if ((tE2.P1Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Event2.Parameter1.Value) || (trig.Event2.Parameter1.Value is IntValueDesc ev21 && global.Equals(ev21.Value))))
         || (tE2.P2Type == TriggerParameterFlag.GLOBALS && (global.Equals(trig.Event2.Parameter2.Value) || (trig.Event2.Parameter2.Value is IntValueDesc ev22 && global.Equals(ev22.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 2) \t" + trig.Name);
        }
      }

      foreach (var team in Map.TeamTypeSection.TeamTypeList)
      {
        int line = 0;
        foreach (var script in team.ScriptList)
        {
          ScriptActionType satype = ScriptActions.GetScriptAction(script.ScriptType);
          if (satype.ParameterType == ScriptParameterType.GLOBALS && global.Equals(script.Parameter.Value))
          {
            _sb.AppendLine("TeamType (Script Line " + line + ") \t" + team.Name);
          }
          line++;
        }
      }

      tbRef.Text = _sb.ToString();
    }

    private void SearchMissionText(int textID)
    {
      _sb.Clear();
      _sb.AppendLine("Mission Text " + textID);
      _sb.AppendLine("---------------------------------------");

      foreach (var trig in Map.TriggerSection.TriggerList)
      {
        TriggerActionType tA1 = TriggerActions.GetTriggerAction((int)trig.Action1.ActionType);
        TriggerActionType tA2 = TriggerActions.GetTriggerAction((int)trig.Action2.ActionType);
        TriggerEventType tE1 = TriggerEvents.GetTriggerEvent((int)trig.Event1.EventType);
        TriggerEventType tE2 = TriggerEvents.GetTriggerEvent((int)trig.Event2.EventType);

        if ((tA1.P1Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action1.Parameter1.Value) || (trig.Action1.Parameter1.Value is IntValueDesc iv11 && textID.Equals(iv11.Value))))
         || (tA1.P2Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action1.Parameter2.Value) || (trig.Action1.Parameter2.Value is IntValueDesc iv12 && textID.Equals(iv12.Value))))
         || (tA1.P3Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action1.Parameter3.Value) || (trig.Action1.Parameter3.Value is IntValueDesc iv13 && textID.Equals(iv13.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 1) \t" + trig.Name);
        }

        if ((tA2.P1Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action2.Parameter1.Value) || (trig.Action2.Parameter1.Value is IntValueDesc iv21 && textID.Equals(iv21.Value))))
         || (tA2.P2Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action2.Parameter2.Value) || (trig.Action2.Parameter2.Value is IntValueDesc iv22 && textID.Equals(iv22.Value))))
         || (tA2.P3Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Action2.Parameter3.Value) || (trig.Action2.Parameter3.Value is IntValueDesc iv23 && textID.Equals(iv23.Value))))
          )
        {
          _sb.AppendLine("Trigger (Action 2) \t" + trig.Name);
        }

        if ((tE1.P1Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Event1.Parameter1.Value) || (trig.Event1.Parameter1.Value is IntValueDesc ev11 && textID.Equals(ev11.Value))))
         || (tE1.P2Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Event1.Parameter2.Value) || (trig.Event1.Parameter2.Value is IntValueDesc ev12 && textID.Equals(ev12.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 1) \t" + trig.Name);
        }

        if ((tE2.P1Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Event2.Parameter1.Value) || (trig.Event2.Parameter1.Value is IntValueDesc ev21 && textID.Equals(ev21.Value))))
         || (tE2.P2Type == TriggerParameterFlag.MESSAGE && (textID.Equals(trig.Event2.Parameter2.Value) || (trig.Event2.Parameter2.Value is IntValueDesc ev22 && textID.Equals(ev22.Value))))
          )
        {
          _sb.AppendLine("Trigger (Event 2) \t" + trig.Name);
        }
      }

      tbRef.Text = _sb.ToString();
    }
  }
}
