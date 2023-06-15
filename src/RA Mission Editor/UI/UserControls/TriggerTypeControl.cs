using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.UI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TriggerTypeControl : UserControl
  {
    public TriggerTypeControl()
    {
      InitializeComponent();
      //PersistantType
      cbRepeating.Items.Add("0 - Fire once on any");
      cbRepeating.Items.Add("1 - Fire once on all");
      cbRepeating.Items.Add("2 - Fire on any, repeating");

      //MultiStyleType
      cbEventType.Items.Add("0 - Simple - Event 1 => Action(s)");
      cbEventType.Items.Add("1 - And - Event 1 && Event 2 => Action(s)");
      cbEventType.Items.Add("2 - Or - Event 1 || Event 2 => Action(s)");
      cbEventType.Items.Add("3 - Parallel - Event 1 => Action 1, Event 2 => Action 2");

      cbEvent1.Items.AddRange(TriggerEvents.GetTriggerEvents());
      cbEvent2.Items.AddRange(TriggerEvents.GetTriggerEvents());
      cbAction1.Items.AddRange(TriggerActions.GetTriggerActions());
      cbAction2.Items.AddRange(TriggerActions.GetTriggerActions());

      cbEvent1.Tag = lblEvent1;
      cbEvent2.Tag = lblEvent2;
      cbAction1.Tag = lblAction1;
      cbAction2.Tag = lblAction2;
      tbName.Tag = lblName;
      cbOwner.Tag = lblOwner;
      cbRepeating.Tag = lblRepeating;
      cbEventType.Tag = lblEventType;
      cbE1P.Tag = lblE1P;
      cbE2P.Tag = lblE2P;
      cbA1P1.Tag = lblA1P1;
      cbA1P2.Tag = lblA1P2;
      cbA1P3.Tag = lblA1P3;
      cbA2P1.Tag = lblA2P1;
      cbA2P2.Tag = lblA2P2;
      cbA2P3.Tag = lblA2P3;

      cbEvent1.SelectedIndexChanged += Value_Changed;
      cbEvent2.SelectedIndexChanged += Value_Changed;
      cbAction1.SelectedIndexChanged += Value_Changed;
      cbAction2.SelectedIndexChanged += Value_Changed;

      cbEvent1.SelectedIndexChanged += (_, __) => { ShowTriggerEventDescription(TriggerEvents.GetTriggerEvent(cbEvent1.SelectedIndex)); };
      cbEvent2.SelectedIndexChanged += (_, __) => { ShowTriggerEventDescription(TriggerEvents.GetTriggerEvent(cbEvent2.SelectedIndex)); };
      cbAction1.SelectedIndexChanged += (_, __) => { ShowTriggerActionDescription(TriggerActions.GetTriggerAction(cbAction1.SelectedIndex)); };
      cbAction2.SelectedIndexChanged += (_, __) => { ShowTriggerActionDescription(TriggerActions.GetTriggerAction(cbAction2.SelectedIndex)); };
    }

    public TriggerInfo Trigger { get; private set; }
    public Map Map { get; private set; }
    public NotifyDelegate TriggerTypeUpdated;

    // maintain direct references instead of copies
    private List<TriggerInfo> _trigger_list;
    private List<TeamTypeInfo> _teamtype_list;
    private bool _suspendDirty = false;

    public void UpdateTriggerSelections()
    {
      if (Trigger != null)
      {
        TriggerEventType event1 = TriggerEvents.GetTriggerEvent((int)Trigger.Event1.EventType);
        TriggerEventType event2 = TriggerEvents.GetTriggerEvent((int)Trigger.Event2.EventType);
        TriggerActionType action1 = TriggerActions.GetTriggerAction((int)Trigger.Action1.ActionType);
        TriggerActionType action2 = TriggerActions.GetTriggerAction((int)Trigger.Action2.ActionType);

        Fetch(cbE1P, lblE1P, event1.P1Type | event1.P2Type);
        Fetch(cbE2P, lblE2P, event2.P1Type | event2.P2Type);
        Fetch(cbA1P1, lblA1P1, action1.P1Type, action1.P1Name);
        Fetch(cbA1P2, lblA1P2, action1.P2Type, action1.P2Name);
        Fetch(cbA1P3, lblA1P3, action1.P3Type, action1.P3Name);
        Fetch(cbA2P1, lblA2P1, action2.P1Type, action2.P1Name);
        Fetch(cbA2P2, lblA2P2, action2.P2Type, action2.P2Name);
        Fetch(cbA2P3, lblA2P3, action2.P3Type, action2.P3Name);
      }
    }

    StringBuilder _sb = new StringBuilder(256);
    public void ShowTriggerEventDescription(TriggerEventType evt)
    {
      if (evt != null && !string.IsNullOrEmpty(evt.Description))
      {
        _sb.Clear();
        _sb.AppendLine(Resources.Strings.TriggerType_Event);
        _sb.AppendLine();
        _sb.AppendLine(evt.ID);
        _sb.AppendLine(evt.Description);
        tbHint.Text = _sb.ToString();
      }
    }

    public void ShowTriggerActionDescription(TriggerActionType act)
    {
      if (act != null && !string.IsNullOrEmpty(act.Description))
      {
        _sb.Clear();
        _sb.AppendLine(Resources.Strings.TriggerType_Action);
        _sb.AppendLine();
        _sb.AppendLine(act.ID);
        _sb.AppendLine(act.Description);
        tbHint.Text = _sb.ToString();
      }
    }

    public void SetTrigger(TriggerInfo trigger)
    {
      _suspendDirty = true;
      Trigger = trigger;

      if (trigger != null)
      {
        tbName.Text = trigger.Name;

        // refresh values
        TriggerEventType event1 = TriggerEvents.GetTriggerEvent((int)Trigger.Event1.EventType);
        TriggerEventType event2 = TriggerEvents.GetTriggerEvent((int)Trigger.Event2.EventType);
        TriggerActionType action1 = TriggerActions.GetTriggerAction((int)Trigger.Action1.ActionType);
        TriggerActionType action2 = TriggerActions.GetTriggerAction((int)Trigger.Action2.ActionType);

        try { cbOwner.SelectedIndex = trigger.Owner; } catch { cbOwner.SelectedIndex = 0; }
        try { cbRepeating.SelectedIndex = (int)Trigger.PersistanceControl; } catch { cbRepeating.SelectedIndex = 0; }
        try { cbEventType.SelectedIndex = (int)Trigger.EventControl; } catch { cbEventType.SelectedIndex = 0; }

        try { cbEvent1.SelectedIndex = (int)Trigger.Event1.EventType; } catch { cbEvent1.SelectedIndex = 0; }
        try { cbEvent2.SelectedIndex = (int)Trigger.Event2.EventType; } catch { cbEvent2.SelectedIndex = 0; }
        try { cbAction1.SelectedIndex = (int)Trigger.Action1.ActionType; } catch { cbAction1.SelectedIndex = 0; }
        try { cbAction2.SelectedIndex = (int)Trigger.Action2.ActionType; } catch { cbAction2.SelectedIndex = 0; }

        Fetch(cbE1P, lblE1P, event1.P1Type | event1.P2Type);
        Fetch(cbE2P, lblE2P, event2.P1Type | event2.P2Type);
        Fetch(cbA1P1, lblA1P1, action1.P1Type, action1.P1Name);
        Fetch(cbA1P2, lblA1P2, action1.P2Type, action1.P2Name);
        Fetch(cbA1P3, lblA1P3, action1.P3Type, action1.P3Name);
        Fetch(cbA2P1, lblA2P1, action2.P1Type, action2.P1Name);
        Fetch(cbA2P2, lblA2P2, action2.P2Type, action2.P2Name);
        Fetch(cbA2P3, lblA2P3, action2.P3Type, action2.P3Name);

        SetValue(cbE1P, event1.P1Type != TriggerParameterFlag.NONE ? Trigger.Event1.Parameter1.Value : Trigger.Event1.Parameter2.Value);
        SetValue(cbE2P, event2.P1Type != TriggerParameterFlag.NONE ? Trigger.Event2.Parameter1.Value : Trigger.Event2.Parameter2.Value);
        SetValue(cbA1P1, Trigger.Action1.Parameter1.Value);
        SetValue(cbA1P2, Trigger.Action1.Parameter2.Value);
        SetValue(cbA1P3, Trigger.Action1.Parameter3.Value);
        SetValue(cbA2P1, Trigger.Action2.Parameter1.Value);
        SetValue(cbA2P2, Trigger.Action2.Parameter2.Value);
        SetValue(cbA2P3, Trigger.Action2.Parameter3.Value);

        tbComment.Text = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TriggerPrefix + trigger.Name);
        tbRaw.Text = trigger.GetKeyAsString() + "=" + trigger.GetValueAsString(Map);
      }
      DirtyControlsHandler.ResetDirtyColor(this);
      bCancel.Enabled = false;
      UpdateUI();
      _suspendDirty = false;
    }

    public void SetMap(Map map)
    {
      Map = map;
      cbOwner.Items.Clear();
      cbOwner.Items.AddRange(Map.AttachedRules.Houses.GetAll());
      _trigger_list = map.TriggerSection.TriggerList;
      _teamtype_list = map.TeamTypeSection.TeamTypeList;
    }

    public void UpdateUI()
    {
      if (Trigger == null)
      {
        this.Visible = false;
        tbName.Enabled = false;
        cbOwner.Enabled = false;
        cbRepeating.Enabled = false;
        cbEventType.Enabled = false;

        lblEvent1.Visible = false;
        lblEvent2.Visible = false;
        lblAction1.Visible = false;
        lblAction2.Visible = false;
        lblE1P.Visible = false;
        lblE2P.Visible = false;
        lblA1P1.Visible = false;
        lblA1P2.Visible = false;
        lblA1P3.Visible = false;
        lblA2P1.Visible = false;
        lblA2P2.Visible = false;
        lblA2P3.Visible = false;

        cbEvent1.Visible = false;
        cbEvent2.Visible = false;
        cbAction1.Visible = false;
        cbAction2.Visible = false;
        cbE1P.Visible = false;
        cbE2P.Visible = false;
        cbA1P1.Visible = false;
        cbA1P2.Visible = false;
        cbA1P3.Visible = false;
        cbA2P1.Visible = false;
        cbA2P2.Visible = false;
        cbA2P3.Visible = false;
      }
      else
      {
        this.Visible = true;
        tbName.Enabled = true;
        cbOwner.Enabled = true;
        cbRepeating.Enabled = true;
        cbEventType.Enabled = true;
        
        TriggerEventType event1 = TriggerEvents.GetTriggerEvent(cbEvent1.SelectedIndex);
        TriggerEventType event2 = TriggerEvents.GetTriggerEvent(cbEvent2.SelectedIndex);
        TriggerActionType action1 = TriggerActions.GetTriggerAction(cbAction1.SelectedIndex);
        TriggerActionType action2 = TriggerActions.GetTriggerAction(cbAction2.SelectedIndex);

        lblEvent1.Visible = true;
        lblEvent2.Visible = cbEventType.SelectedIndex != (int)MultiStyleType.FIRST_ONLY;
        lblAction1.Visible = true;
        lblAction2.Visible = true;
        lblE1P.Visible = event1 != null && (event1.P1Type | event1.P2Type) != TriggerParameterFlag.NONE;
        lblE2P.Visible = event2 != null && (event2.P1Type | event2.P2Type) != TriggerParameterFlag.NONE;
        lblA1P1.Visible = action1 != null && action1.P1Type != TriggerParameterFlag.NONE;
        lblA1P2.Visible = action1 != null && action1.P2Type != TriggerParameterFlag.NONE;
        lblA1P3.Visible = action1 != null && action1.P3Type != TriggerParameterFlag.NONE;
        lblA2P1.Visible = action2 != null && action2.P1Type != TriggerParameterFlag.NONE;
        lblA2P2.Visible = action2 != null && action2.P2Type != TriggerParameterFlag.NONE;
        lblA2P3.Visible = action2 != null && action2.P3Type != TriggerParameterFlag.NONE;

        cbEvent1.Visible = true; // always true
        cbEvent2.Visible = cbEventType.SelectedIndex != (int)MultiStyleType.FIRST_ONLY;
        cbAction1.Visible = true;
        cbAction2.Visible = true;
        cbE1P.Visible = event1 != null && (event1.P1Type | event1.P2Type) != TriggerParameterFlag.NONE;
        cbE2P.Visible = event2 != null && (event2.P1Type | event2.P2Type) != TriggerParameterFlag.NONE;
        cbA1P1.Visible = action1 != null && action1.P1Type != TriggerParameterFlag.NONE;
        cbA1P2.Visible = action1 != null && action1.P2Type != TriggerParameterFlag.NONE;
        cbA1P3.Visible = action1 != null && action1.P3Type != TriggerParameterFlag.NONE;
        cbA2P1.Visible = action2 != null && action2.P1Type != TriggerParameterFlag.NONE;
        cbA2P2.Visible = action2 != null && action2.P2Type != TriggerParameterFlag.NONE;
        cbA2P3.Visible = action2 != null && action2.P3Type != TriggerParameterFlag.NONE;
      }
    }

    private void Fetch(ComboBox cbox, Label label, TriggerParameterFlag flag, string flagname = null)
    {
      object obj = cbox.SelectedItem;
      cbox.Items.Clear();
      if (flag == TriggerParameterFlag.NONE)
      {
        cbox.Enabled = false;
        cbox.Text = null;
        return;
      }
      else
      {
        cbox.Enabled = true;
      }

      ComboBoxStyle cstyle = ComboBoxStyle.DropDownList;
      string labelText = string.Empty;

      if (flag.Contains(TriggerParameterFlag.INFANTRYTYPE))
      {
        labelText = string.IsNullOrEmpty(labelText) ? "Infantry" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Infantries.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.UNITTYPE))
      {
        labelText = string.IsNullOrEmpty(labelText) ? "Unit" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Units.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.STRUCTURETYPE))
      {
        labelText = string.IsNullOrEmpty(labelText) ? "Structure" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Structures.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.SHIPTYPE))
      {
        labelText = string.IsNullOrEmpty(labelText) ? "Ship" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Ships.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.AIRCRAFTTYPE))
      {
        // not supported yet
        cbox.Items.AddRange(Map.AttachedRules.Aircrafts.GetAsObjectList());
        labelText = string.IsNullOrEmpty(labelText) ? "Aircraft" : "TechnoType";
      }
      if (flag.Contains(TriggerParameterFlag.HOUSE))
      {
        cbox.Items.AddRange(Map.AttachedRules.Houses.GetAll());
        labelText = "House";
      }
      if (flag.Contains(TriggerParameterFlag.COLOR))
      {
        Array alst = Enum.GetValues(typeof(ColorType));
        object[] olst = new object[alst.Length];
        alst.CopyTo(olst, 0);
        olst = olst.OrderBy(x => (int)(ColorType)x).ToArray();
        cbox.Items.AddRange(olst);
        labelText = "Color";
      }
      if (flag.Contains(TriggerParameterFlag.WAYPOINT))
      {
        object[] olst = new object[100];
        for (int i = 0; i < olst.Length; i++)
        {
          olst[i] = i;
        }
        cbox.Items.AddRange(olst);
        labelText = "Waypoint";
      }
      if (flag.Contains(TriggerParameterFlag.TRIGGER))
      {
        if (_trigger_list != null)
          cbox.Items.AddRange(_trigger_list.ToArray());

        labelText = "Trigger";
      }
      if (flag.Contains(TriggerParameterFlag.TEAMTYPE))
      {
        if (_teamtype_list != null)
          cbox.Items.AddRange(_teamtype_list.ToArray());

        labelText = "TeamType";
      }
      if (flag.Contains(TriggerParameterFlag.MISSIONTYPE))
      {
        cbox.Items.AddRange(Missions.GetAsObjectList());
        labelText = "Mission";
      }
      if (flag.Contains(TriggerParameterFlag.GLOBALS))
      {
        object[] olst = new object[Constants.MAX_GLOBALS];
        for (int i = 0; i < olst.Length; i++)
        {
          olst[i] = ParameterInfo.ParameterGlobals.GetValueFunc(i, Map);
        }
        cbox.Items.AddRange(olst);
        labelText = "Global";
      }
      if (flag.Contains(TriggerParameterFlag.MESSAGE))
      {
        if (!Map.BasicSection.UseCustomTutorialText.Value)
        {
          if (Map.AttachedRules.LanguageText != null)
          {
            object[] olst = new object[Map.AttachedRules.LanguageText.Count];
            for (int i = 0; i < olst.Length; i++)
            {
              olst[i] = ParameterInfo.ParameterMessage.GetValueFunc(i, Map);
            }
            cbox.Items.AddRange(olst);
          }
          else
          {
            // allow user input (integer)
            cstyle = ComboBoxStyle.DropDown;
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
          cbox.Items.AddRange(olst);
        }
        labelText = "Message";
      }
      if (flag.Contains(TriggerParameterFlag.TIME))
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;
        labelText = "Time";
      }
      if (flag.Contains(TriggerParameterFlag.SOUND))
      {
        cbox.Items.AddRange(Map.AttachedRules.Sounds.GetAll());
        labelText = "Sound";
      }
      if (flag.Contains(TriggerParameterFlag.SPEECH))
      {
        cbox.Items.AddRange(Map.AttachedRules.Speeches.GetAll());
        labelText = "Speech";
      }
      if (flag.Contains(TriggerParameterFlag.THEME))
      {
        cbox.Items.AddRange(Map.AttachedRules.Themes.GetAll());
        labelText = "Theme";
      }
      if (flag.Contains(TriggerParameterFlag.SWTYPE))
      {
        cbox.Items.AddRange(Map.AttachedRules.SpecialWeapons.GetAll());
        labelText = "Special Weapon";
      }
      if (flag.Contains(TriggerParameterFlag.INTEGER))
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;
        labelText = "Number";
      }
      //if (flag.Contains(TriggerParameterFlag.SWTYPE))
      //{
      //  // allow user input (integer)
      //  cstyle = ComboBoxStyle.DropDown;
      //
      //  // eventually support list for some of these item types
      //  labelText = "ID";
      //}

      label.Text = flagname ?? labelText;
      cbox.SelectedItem = obj;
      cbox.DropDownStyle = cstyle;
    }

    private object InferValueFromString(string value, TriggerParameterFlag flag)
    {
      if (flag.Contains(TriggerParameterFlag.TRIGGER))
      {
        return Map.TriggerSection.TriggerList.Find((t) => t.Name == value);
      }
      if (flag.Contains(TriggerParameterFlag.TEAMTYPE))
      {
        return Map.TeamTypeSection.TeamTypeList.Find((t) => t.Name == value);
      }
      return value;
    }

    private object InferValueFromIndex(int index, TriggerParameterFlag flag)
    {
      if (flag.Contains(TriggerParameterFlag.TRIGGER))
      {
        return (index >= 0 && index < Map.TriggerSection.TriggerList.Count) ? Map.TriggerSection.TriggerList[index] : null;
      }
      if (flag.Contains(TriggerParameterFlag.TEAMTYPE))
      {
        return (index >= 0 && index < Map.TeamTypeSection.TeamTypeList.Count) ? Map.TeamTypeSection.TeamTypeList[index] : null;
      }
      if (flag.Contains(TriggerParameterFlag.INFANTRYTYPE))
      {
        return Map.AttachedRules.Infantries.Get(index);
      }
      if (flag.Contains(TriggerParameterFlag.UNITTYPE))
      {
        return Map.AttachedRules.Units.Get(index);
      }
      if (flag.Contains(TriggerParameterFlag.STRUCTURETYPE))
      {
        return Map.AttachedRules.Structures.Get(index);
      }
      if (flag.Contains(TriggerParameterFlag.SHIPTYPE))
      {
        return Map.AttachedRules.Ships.Get(index);
      }
      if (flag.Contains(TriggerParameterFlag.AIRCRAFTTYPE))
      {
        return Map.AttachedRules.Aircrafts.Get(index);
      }
      if (flag.Contains(TriggerParameterFlag.HOUSE))
      {
        return Map.AttachedRules.Houses.GetHouse(index);
      }
      if (flag.Contains(TriggerParameterFlag.COLOR))
      {
        return (ColorType)index;
      }
      return index;
    }

    private int InferIndexFromValue(object value)
    {
      if (value == null)
      {
        return -1;
      }
      if (value is TriggerInfo triginfo)
      {
        return Map.TriggerSection.TriggerList.IndexOf(triginfo);
      }
      if (value is TeamTypeInfo teaminfo)
      {
        return Map.TeamTypeSection.TeamTypeList.IndexOf(teaminfo);
      }
      if (value is InfantryType iinfo)
      {
        return Map.AttachedRules.Infantries.GetID(iinfo.ID);
      }
      if (value is UnitType uinfo)
      {
        return Map.AttachedRules.Units.GetID(uinfo.ID);
      }
      if (value is StructureType stinfo)
      {
        return Map.AttachedRules.Structures.GetID(stinfo.ID);
      }
      if (value is ShipType shinfo)
      {
        return Map.AttachedRules.Ships.GetID(shinfo.ID);
      }
      if (value is AircraftType arinfo)
      {
        return Map.AttachedRules.Aircrafts.GetID(arinfo.ID);
      }
      if (value is HouseType hinfo)
      {
        return Map.AttachedRules.Houses.GetHouseID(hinfo.Name);
      }
      if (value is ColorType color)
      {
        return (int)color;
      }

      if (int.TryParse(value.ToString(), out int index))
        return index;
      else
        return -1;
    }

    private int InferIndexFromStringOrValue(ComboBox comboBox, TriggerParameterFlag flag)
    {
      object value = comboBox.SelectedItem;
      if (value != null)
      {
        value = comboBox.Text;
      }

      if (value is string s)
      {
        value = InferValueFromString(s, flag);
      }

      return InferIndexFromValue(value);
    }

    private bool SaveTrigger()
    {
      // check
      if (string.IsNullOrWhiteSpace(tbName.Text))
      {
        MessageBox.Show("Please enter a trigger name.");
        return false;
      }

      if (Map.TriggerSection.TriggerList.FindAll((t) => t != Trigger && t.Name == tbName.Text).Count > 0)
      {
        MessageBox.Show("An existing trigger already uses the trigger name. Please enter a unique trigger name.");
        return false;
      }

      string prevValue = Trigger.GetValueAsString(Map);
      string commentkey = Ext_CommentsSection.TriggerPrefix + Trigger.Name;

      if (Trigger.Name != tbName.Text)
      {
        string prevkey = Trigger.Name;
        Trigger.Name = tbName.Text;
        Map.Ext_CommentsSection.Transfer(prevkey, commentkey, true);
      }
      Trigger.Owner = Map.AttachedRules.Houses.GetHouseID(cbOwner.Text);
      Trigger.PersistanceControl = (PersistantType)cbRepeating.SelectedIndex;
      Trigger.EventControl = (MultiStyleType)cbEventType.SelectedIndex;

      Trigger.Event1.EventType = (TEventType)cbEvent1.SelectedIndex;
      Trigger.Event2.EventType = cbEvent2.Visible ? (TEventType)cbEvent2.SelectedIndex : TEventType.TEVENT_NONE;
      Trigger.Action1.ActionType = (TActionType)cbAction1.SelectedIndex;
      Trigger.Action2.ActionType = (TActionType)cbAction2.SelectedIndex;
      Trigger.ActionControl = Trigger.Action2.ActionType != TActionType.TACTION_NONE ? MultiStyleType.FIRST_AND_SECOND : MultiStyleType.FIRST_ONLY;

      TriggerEventType event1 = TriggerEvents.GetTriggerEvent((int)Trigger.Event1.EventType);
      TriggerEventType event2 = TriggerEvents.GetTriggerEvent((int)Trigger.Event2.EventType);
      TriggerActionType action1 = TriggerActions.GetTriggerAction((int)Trigger.Action1.ActionType);
      TriggerActionType action2 = TriggerActions.GetTriggerAction((int)Trigger.Action2.ActionType);

      Trigger.Event1.Parameter1 = TriggerInfo.SelectParameterInfo(event1.P1Type);
      Trigger.Event1.Parameter2 = TriggerInfo.SelectParameterInfo(event1.P2Type);

      Trigger.Event2.Parameter1 = TriggerInfo.SelectParameterInfo(event2.P1Type);
      Trigger.Event2.Parameter2 = TriggerInfo.SelectParameterInfo(event2.P2Type);

      Trigger.Action1.Parameter1 = TriggerInfo.SelectParameterInfo(action1.P1Type);
      Trigger.Action1.Parameter2 = TriggerInfo.SelectParameterInfo(action1.P2Type);
      Trigger.Action1.Parameter3 = TriggerInfo.SelectParameterInfo(action1.P3Type);

      Trigger.Action2.Parameter1 = TriggerInfo.SelectParameterInfo(action2.P1Type);
      Trigger.Action2.Parameter2 = TriggerInfo.SelectParameterInfo(action2.P2Type);
      Trigger.Action2.Parameter3 = TriggerInfo.SelectParameterInfo(action2.P3Type);

      Trigger.Event1.Parameter1.Value = event1.P1Type != TriggerParameterFlag.NONE ? (cbE1P.SelectedItem ?? cbE1P.Text) : -1; //cbE1P.Text;
      Trigger.Event1.Parameter2.Value = event1.P2Type != TriggerParameterFlag.NONE ? (cbE1P.SelectedItem ?? cbE1P.Text) : -1; //cbE1P.Text;
      Trigger.Event2.Parameter1.Value = event2.P1Type != TriggerParameterFlag.NONE ? (cbE2P.SelectedItem ?? cbE2P.Text) : -1; //cbE2P.Text;
      Trigger.Event2.Parameter2.Value = event2.P2Type != TriggerParameterFlag.NONE ? (cbE2P.SelectedItem ?? cbE2P.Text) : -1; //cbE2P.Text;
      Trigger.Action1.Parameter1.Value = cbA1P1.SelectedItem ?? cbA1P1.Text;
      Trigger.Action1.Parameter2.Value = cbA1P2.SelectedItem ?? cbA1P2.Text;
      Trigger.Action1.Parameter3.Value = cbA1P3.SelectedItem ?? cbA1P3.Text;
      Trigger.Action2.Parameter1.Value = cbA2P1.SelectedItem ?? cbA2P1.Text;
      Trigger.Action2.Parameter2.Value = cbA2P2.SelectedItem ?? cbA2P2.Text;
      Trigger.Action2.Parameter3.Value = cbA2P3.SelectedItem ?? cbA2P3.Text;

      bool commentChanged = false;
      if (tbComment.Text.Length > 0)
      {
        commentChanged = Map.Ext_CommentsSection.Put(commentkey, tbComment.Text);
      }
      else
      {
        commentChanged = Map.Ext_CommentsSection.Get(commentkey) != null;
        Map.Ext_CommentsSection.Remove(commentkey);
      }

      string thisValue = Trigger.GetValueAsString(Map);
      if (commentChanged || prevValue != thisValue) { Map.Dirty = true; }

      return true;
    }

    private void PreviewTrigger()
    {
      TriggerInfo trigger = new TriggerInfo();
      trigger.Name = string.IsNullOrWhiteSpace(tbName.Text) ? "???" : tbName.Text;
      trigger.Owner = Map.AttachedRules.Houses.GetHouseID(cbOwner.Text);
      trigger.PersistanceControl = (PersistantType)cbRepeating.SelectedIndex;
      trigger.EventControl = (MultiStyleType)cbEventType.SelectedIndex;

      trigger.Event1.EventType = (TEventType)cbEvent1.SelectedIndex;
      trigger.Event2.EventType = cbEvent2.Visible ? (TEventType)cbEvent2.SelectedIndex : TEventType.TEVENT_NONE;
      trigger.Action1.ActionType = (TActionType)cbAction1.SelectedIndex;
      trigger.Action2.ActionType = (TActionType)cbAction2.SelectedIndex;
      trigger.ActionControl = trigger.Action2.ActionType != TActionType.TACTION_NONE ? MultiStyleType.FIRST_AND_SECOND : MultiStyleType.FIRST_ONLY;

      TriggerEventType event1 = TriggerEvents.GetTriggerEvent((int)trigger.Event1.EventType);
      TriggerEventType event2 = TriggerEvents.GetTriggerEvent((int)Trigger.Event2.EventType);
      TriggerActionType action1 = TriggerActions.GetTriggerAction((int)trigger.Action1.ActionType);
      TriggerActionType action2 = TriggerActions.GetTriggerAction((int)trigger.Action2.ActionType);

      trigger.Event1.Parameter1 = TriggerInfo.SelectParameterInfo(event1.P1Type);
      trigger.Event1.Parameter2 = TriggerInfo.SelectParameterInfo(event1.P2Type);
      
      trigger.Event2.Parameter1 = TriggerInfo.SelectParameterInfo(event2.P1Type);
      trigger.Event2.Parameter2 = TriggerInfo.SelectParameterInfo(event2.P2Type);
      
      trigger.Action1.Parameter1 = TriggerInfo.SelectParameterInfo(action1.P1Type);
      trigger.Action1.Parameter2 = TriggerInfo.SelectParameterInfo(action1.P2Type);
      trigger.Action1.Parameter3 = TriggerInfo.SelectParameterInfo(action1.P3Type);
      
      trigger.Action2.Parameter1 = TriggerInfo.SelectParameterInfo(action2.P1Type);
      trigger.Action2.Parameter2 = TriggerInfo.SelectParameterInfo(action2.P2Type);
      trigger.Action2.Parameter3 = TriggerInfo.SelectParameterInfo(action2.P3Type);
      
      trigger.Event1.Parameter1.Value = event1.P1Type != TriggerParameterFlag.NONE ? (cbE1P.SelectedItem ?? cbE1P.Text) : -1; //cbE1P.Text;
      trigger.Event1.Parameter2.Value = event1.P2Type != TriggerParameterFlag.NONE ? (cbE1P.SelectedItem ?? cbE1P.Text) : -1; //cbE1P.Text;
      trigger.Event2.Parameter1.Value = event2.P1Type != TriggerParameterFlag.NONE ? (cbE2P.SelectedItem ?? cbE2P.Text) : -1; //cbE2P.Text;
      trigger.Event2.Parameter2.Value = event2.P2Type != TriggerParameterFlag.NONE ? (cbE2P.SelectedItem ?? cbE2P.Text) : -1; //cbE2P.Text;
      trigger.Action1.Parameter1.Value = cbA1P1.SelectedItem ?? cbA1P1.Text;
      trigger.Action1.Parameter2.Value = cbA1P2.SelectedItem ?? cbA1P2.Text;
      trigger.Action1.Parameter3.Value = cbA1P3.SelectedItem ?? cbA1P3.Text;
      trigger.Action2.Parameter1.Value = cbA2P1.SelectedItem ?? cbA2P1.Text;
      trigger.Action2.Parameter2.Value = cbA2P2.SelectedItem ?? cbA2P2.Text;
      trigger.Action2.Parameter3.Value = cbA2P3.SelectedItem ?? cbA2P3.Text;

      tbRaw.Text = trigger.GetKeyAsString() + "=" + trigger.GetValueAsString(Map);
    }


    private void Value_Changed(object sender, EventArgs e)
    {
      if (!_suspendDirty && sender is Control c)
      {
        DirtyControlsHandler.SetDirtyColor(c);
        bCancel.Enabled = true;
      }
      PreviewTrigger();
    }

    private void SetValue(ComboBox cbox, object value)
    {
      if (value == null)
      {
        // open with the first value
        if (cbox.Items.Count >= 1)
        {
          cbox.SelectedIndex = 0;
        }
        else
        {
          cbox.Text = "-1";
        }
      }
      else if (cbox.Items.Contains(value))
      {
        cbox.SelectedItem = value;
      }
      else if (value is int index && index >= -1 && index < cbox.Items.Count)
      {
        cbox.SelectedIndex = index;
      }
      else
      {
        cbox.Text = value.ToString();
      }
    }

    private void cbEventType_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateUI();
    }

    private void cbEvent1_SelectedIndexChanged(object sender, EventArgs e)
    {
      TriggerEventType event1 = TriggerEvents.GetTriggerEvent(cbEvent1.SelectedIndex);
      Fetch(cbE1P, lblE1P, event1.P1Type | event1.P2Type);
      SetValue(cbE1P, null);
      UpdateUI();
    }

    private void cbEvent2_SelectedIndexChanged(object sender, EventArgs e)
    {
      TriggerEventType event2 = TriggerEvents.GetTriggerEvent(cbEvent2.SelectedIndex);
      Fetch(cbE2P, lblE2P, event2.P1Type | event2.P2Type);
      SetValue(cbE2P, null);
      UpdateUI();
    }

    private void cbAction1_SelectedIndexChanged(object sender, EventArgs e)
    {
      TriggerActionType action1 = TriggerActions.GetTriggerAction(cbAction1.SelectedIndex);
      Fetch(cbA1P1, lblA1P1, action1.P1Type, action1.P1Name);
      Fetch(cbA1P2, lblA1P2, action1.P2Type, action1.P2Name);
      Fetch(cbA1P3, lblA1P3, action1.P3Type, action1.P3Name);
      SetValue(cbA1P1, null);
      SetValue(cbA1P2, null);
      SetValue(cbA1P3, null);
      UpdateUI();
    }

    private void cbAction2_SelectedIndexChanged(object sender, EventArgs e)
    {
      TriggerActionType action2 = TriggerActions.GetTriggerAction(cbAction2.SelectedIndex);
      Fetch(cbA2P1, lblA2P1, action2.P1Type, action2.P1Name);
      Fetch(cbA2P2, lblA2P2, action2.P2Type, action2.P2Name);
      Fetch(cbA2P3, lblA2P3, action2.P3Type, action2.P3Name);
      SetValue(cbA2P1, null);
      SetValue(cbA2P2, null);
      SetValue(cbA2P3, null);
      UpdateUI();
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      if (SaveTrigger())
      {
        Map.Update();
        TriggerTypeUpdated?.Invoke();
        DirtyControlsHandler.ResetDirtyColor(this);
      }
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      SetTrigger(Trigger);
    }

    private void tbName_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Name; }
    private void cbOwner_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Owner; }
    private void cbRepeating_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Repeating; }
    private void cbEventType_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_EventType; }
    private void cbEvent1_MouseEnter(object sender, EventArgs e)
    {
      if (cbEvent1.SelectedIndex != -1)
      {
        TriggerEventType event1 = TriggerEvents.GetTriggerEvent(cbEvent1.SelectedIndex);
        tbHint.Text = Resources.Strings.TriggerType_Event + Environment.NewLine + Environment.NewLine + event1.ID + Environment.NewLine + Environment.NewLine + event1.Description;
      }
      else
      {
        tbHint.Text = Resources.Strings.TriggerType_Event;
      }
    }

    private void cbEvent2_MouseEnter(object sender, EventArgs e)
    {
      if (cbEvent2.SelectedIndex != -1)
      {
        TriggerEventType event2 = TriggerEvents.GetTriggerEvent(cbEvent2.SelectedIndex);
        tbHint.Text = Resources.Strings.TriggerType_Event + Environment.NewLine + Environment.NewLine + event2.ID + Environment.NewLine + Environment.NewLine + event2.Description;
      }
      else
      {
        tbHint.Text = Resources.Strings.TriggerType_Event;
      }
    }

    private void cbAction1_MouseEnter(object sender, EventArgs e)
    {
      if (cbAction1.SelectedIndex != -1)
      {
        TriggerActionType action1 = TriggerActions.GetTriggerAction(cbAction1.SelectedIndex);
        tbHint.Text = Resources.Strings.TriggerType_Action + Environment.NewLine + Environment.NewLine + action1.ID + Environment.NewLine + Environment.NewLine + action1.Description;
      }
      else
      {
        tbHint.Text = Resources.Strings.TriggerType_Action;
      }
    }

    private void cbAction2_MouseEnter(object sender, EventArgs e)
    {
      if (cbAction2.SelectedIndex != -1)
      {
        TriggerActionType action2 = TriggerActions.GetTriggerAction(cbAction2.SelectedIndex);
        tbHint.Text = Resources.Strings.TriggerType_Action + Environment.NewLine + Environment.NewLine + action2.ID + Environment.NewLine + Environment.NewLine + action2.Description;
      }
      else
      {
        tbHint.Text = Resources.Strings.TriggerType_Action;
      }
    }

    private void tbComment_MouseEnter(object sender, EventArgs e)
    {
      tbHint.Text = Resources.Strings.Comment;
    }
  }
}
