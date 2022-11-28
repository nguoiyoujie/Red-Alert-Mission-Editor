using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

      cbEvent1. SelectedIndexChanged += Value_Changed;
      cbEvent2. SelectedIndexChanged += Value_Changed;
      cbAction1.SelectedIndexChanged += Value_Changed;
      cbAction2.SelectedIndexChanged += Value_Changed;
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
        Fetch(cbA1P1, lblA1P1, action1.P1Type);
        Fetch(cbA1P2, lblA1P2, action1.P2Type);
        Fetch(cbA1P3, lblA1P3, action1.P3Type);
        Fetch(cbA2P1, lblA2P1, action2.P1Type);
        Fetch(cbA2P2, lblA2P2, action2.P2Type);
        Fetch(cbA2P3, lblA2P3, action2.P3Type);
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
        Fetch(cbA1P1, lblA1P1, action1.P1Type);
        Fetch(cbA1P2, lblA1P2, action1.P2Type);
        Fetch(cbA1P3, lblA1P3, action1.P3Type);
        Fetch(cbA2P1, lblA2P1, action2.P1Type);
        Fetch(cbA2P2, lblA2P2, action2.P2Type);
        Fetch(cbA2P3, lblA2P3, action2.P3Type);

        SetValue(cbE1P, event1.P1Type != TriggerParameterFlag.NONE ? Trigger.Event1.Parameter1.Value : Trigger.Event1.Parameter2.Value);
        SetValue(cbE2P, event2.P1Type != TriggerParameterFlag.NONE ? Trigger.Event2.Parameter1.Value : Trigger.Event2.Parameter2.Value);
        SetValue(cbA1P1, Trigger.Action1.Parameter1.Value);
        SetValue(cbA1P2, Trigger.Action1.Parameter2.Value);
        SetValue(cbA1P3, Trigger.Action1.Parameter3.Value);
        SetValue(cbA2P1, Trigger.Action2.Parameter1.Value);
        SetValue(cbA2P2, Trigger.Action2.Parameter2.Value);
        SetValue(cbA2P3, Trigger.Action2.Parameter3.Value);

        tbComment.Text = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TriggerPrefix + trigger.Name);
      }
      ResetColor(this);
      UpdateUI();
      _suspendDirty = false;
    }

    public bool IsDirty
    {
      get
      {
        return IsDirtyColor(this);
      }
    }

    public bool IsDirtyColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        if (c.ForeColor == Color.Red || IsDirtyColor(c))
          return true;
      }
      return false;
    }

    public void ResetColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        c.ForeColor = Color.Black;
        ResetColor(c);
      }
      bCancel.Enabled = false;
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

    private void Fetch(ComboBox cbox, Label label, TriggerParameterFlag flag)
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
        labelText = labelText == string.Empty ? "Infantry" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Infantries.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.UNITTYPE))
      {
        labelText = labelText == string.Empty ? "Unit" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Units.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.STRUCTURETYPE))
      {
        labelText = labelText == string.Empty ? "Structure" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Structures.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.SHIPTYPE))
      {
        labelText = labelText == string.Empty ? "Ship" : "TechnoType";
        cbox.Items.AddRange(Map.AttachedRules.Ships.GetAsObjectList());
      }
      if (flag.Contains(TriggerParameterFlag.AIRCRAFTTYPE))
      {
        // not supported yet
        cbox.Items.AddRange(Map.AttachedRules.Aircrafts.GetAsObjectList());
        labelText = labelText == string.Empty ? "Aircraft" : "TechnoType";
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
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;
        labelText = "Global";
      }
      if (flag.Contains(TriggerParameterFlag.TIME))
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;
        labelText = "Time";
      }
      if (flag.Contains(TriggerParameterFlag.INTEGER))
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;
        labelText = "Number";
      }
      if (flag.Contains(TriggerParameterFlag.SOUND)
       || flag.Contains(TriggerParameterFlag.SPEECH)
       || flag.Contains(TriggerParameterFlag.MESSAGE)
       || flag.Contains(TriggerParameterFlag.SWTYPE)
       || flag.Contains(TriggerParameterFlag.THEME)
       )
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;

        // eventually support list for some of these item types
        labelText = "ID";
      }

      label.Text = labelText;
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

      Trigger.Action1.Parameter1 =TriggerInfo.SelectParameterInfo(action1.P1Type);
      Trigger.Action1.Parameter2 =TriggerInfo.SelectParameterInfo(action1.P2Type);
      Trigger.Action1.Parameter3 =TriggerInfo.SelectParameterInfo(action1.P3Type);

      Trigger.Action2.Parameter1 =TriggerInfo.SelectParameterInfo(action2.P1Type);
      Trigger.Action2.Parameter2 =TriggerInfo.SelectParameterInfo(action2.P2Type);
      Trigger.Action2.Parameter3 =TriggerInfo.SelectParameterInfo(action2.P3Type);

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

    private void Value_Changed(object sender, EventArgs e)
    {
      if (!_suspendDirty && sender is Control c)
      {
        c.ForeColor = Color.Red;
        if (c.Tag is Control d)
        {
          d.ForeColor = Color.Red;
        }
        bCancel.Enabled = true;
      }
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
      Fetch(cbA1P1, lblA1P1, action1.P1Type);
      Fetch(cbA1P2, lblA1P2, action1.P2Type);
      Fetch(cbA1P3, lblA1P3, action1.P3Type);
      SetValue(cbA1P1, null);
      SetValue(cbA1P2, null);
      SetValue(cbA1P3, null);
      UpdateUI();
    }

    private void cbAction2_SelectedIndexChanged(object sender, EventArgs e)
    {
      TriggerActionType action2 = TriggerActions.GetTriggerAction(cbAction2.SelectedIndex);
      Fetch(cbA2P1, lblA2P1, action2.P1Type);
      Fetch(cbA2P2, lblA2P2, action2.P2Type);
      Fetch(cbA2P3, lblA2P3, action2.P3Type);
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
        ResetColor(this);
      }
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      SetTrigger(Trigger);
    }

    private void tbName_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Name; }
    private void cbOwner_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Owner; }
    private void cbRepeating_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Repeating; }
    private void cbEventType_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_EventType; }
    private void cbEvent_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Event; }
    private void cbAction_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TriggerType_Action; }
  }
}
