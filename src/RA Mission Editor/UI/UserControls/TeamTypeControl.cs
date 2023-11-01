using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.UI.Dialogs;
using RA_Mission_Editor.UI.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TeamTypeControl : UserControl
  {
    public TeamTypeControl()
    {
      InitializeComponent();
      cbScriptType.Items.AddRange(ScriptActions.GetScriptActions());

      cbWaypoint.Tag = lblWaypoint;
      cbOwner.Tag = lblOwner;
      tbName.Tag = lblName;
      cbTrigger.Tag = lblTrigger;
      nudPriority.Tag = lblPriority;
      nudMax.Tag = lblMax;
      nudInitNum.Tag = lblInitNum;
      cbTechnoType1.Tag = gbMembers;
      cbTechnoType2.Tag = gbMembers;
      cbTechnoType3.Tag = gbMembers;
      cbTechnoType4.Tag = gbMembers;
      cbTechnoType5.Tag = gbMembers;
      nudTechnoNum1.Tag = gbMembers;
      nudTechnoNum2.Tag = gbMembers;
      nudTechnoNum3.Tag = gbMembers;
      nudTechnoNum4.Tag = gbMembers;
      nudTechnoNum5.Tag = gbMembers;

      bScriptDelete.Tag = gbScript;
      bScriptInsertAfter.Tag = gbScript;
      bScriptInsertBefore.Tag = gbScript;
      bScriptInsertReplace.Tag = gbScript;
      bScriptMoveDown.Tag = gbScript;
      bScriptMoveUp.Tag = gbScript;

      bScriptDelete.Click += Value_Changed_2;
      bScriptInsertAfter.Click += Value_Changed_2;
      bScriptInsertBefore.Click += Value_Changed_2;
      bScriptInsertReplace.Click += Value_Changed_2;
      bScriptMoveDown.Click += Value_Changed_2;
      bScriptMoveUp.Click += Value_Changed_2;
    }

    public TeamTypeInfo TeamType { get; private set; }
    public Map Map { get; private set; }

    private List<TeamTypeInfo.ScriptInfo> _scripts = new List<TeamTypeInfo.ScriptInfo>();
    private List<TeamTypeInfo.TechnoCountInfo> _technoList = new List<TeamTypeInfo.TechnoCountInfo>();
    private bool _suspendDirty = false;
    public NotifyDelegate TeamTypeUpdated;

    public void UpdateTriggerSelections()
    {
      object obj = cbTrigger.SelectedItem;
      cbTrigger.Items.Clear();
      cbTrigger.Items.Add("None");
      cbTrigger.Items.AddRange(Map.TriggerSection.TriggerList.ToArray());
      cbTrigger.SelectedItem = obj;
    }

    public void SetTeamType(TeamTypeInfo teamtype)
    {
      _suspendDirty = true;
      TeamType = teamtype;

      if (teamtype == null)
      {
        _scripts.Clear();
      }
      else
      {
        tbName.Text = teamtype.Name;

        try
        {
          cbOwner.SelectedIndex = teamtype.Owner;
          cbTrigger.SelectedItem = teamtype.Trigger;

          nudPriority.Value = teamtype.Priority;
          nudMax.Value = teamtype.MaxAllowed;
          nudInitNum.Value = teamtype.InitNum;
          cbWaypoint.SelectedItem = (teamtype.WaypointID >= 0 && teamtype.WaypointID < Map.WaypointSection.WaypointList.Count) ? Map.WaypointSection.WaypointList[teamtype.WaypointID] : null;
          cbAvoidThreats.Checked = teamtype.BitField.AvoidThreats;
          cbSuicide.Checked = teamtype.BitField.Suicide;
          cbAutocreate.Checked = teamtype.BitField.AutoCreate;
          cbPrebuild.Checked = teamtype.BitField.PrebuildMembers;
          cbReinforce.Checked = teamtype.BitField.Reinforce;

          _technoList.Clear();
          _technoList.AddRange(teamtype.TechnoList);

          lboxTeamMissions.Items.Clear();

          _scripts.Clear();
          _scripts.AddRange(teamtype.ScriptList);

          tbComment.Text = Map.Ext_CommentsSection.Get(Ext_CommentsSection.TeamTypePrefix + teamtype.Name);
          tbRaw.Text = teamtype.GetKeyAsString() + "=" + teamtype.GetValueAsString(Map);
        }
        catch
        {
          // message box?
        }
      }
      UpdateScriptBox();
      UpdateTechnoBox();
      UpdateUI();
      DirtyControlsHandler.ResetDirtyColor(this);
      _suspendDirty = false;
      bCancel.Enabled = false;
    }

    public bool IsDirty
    {
      get
      {
        return DirtyControlsHandler.IsDirtyColor(this);
      }
    }

    private ITechnoType IDToTechnoType(string id)
    {
      if (Map == null) return null;

      ITechnoType t = Map.AttachedRules.Infantries.Get(id);
      if (t == null) { t = Map.AttachedRules.Units.Get(id); }
      if (t == null) { t = Map.AttachedRules.Buildings.Get(id); }
      if (t == null) { t = Map.AttachedRules.Aircrafts.Get(id); }
      if (t == null) { t = Map.AttachedRules.Vessels.Get(id); }
      return t;
    }

    public void SetMap(Map map)
    {
      Map = map;
      cbOwner.Items.Clear();
      cbOwner.Items.AddRange(Map.AttachedRules.Houses.GetAll());
      foreach (ComboBox c in new ComboBox[] { cbTechnoType1, cbTechnoType2, cbTechnoType3, cbTechnoType4, cbTechnoType5 })
      {
        c.Items.Clear();
        c.Items.Add("");
        c.Items.AddRange(Map.AttachedRules.Infantries.GetAsObjectList());
        c.Items.AddRange(Map.AttachedRules.Units.GetAsObjectList());
        c.Items.AddRange(Map.AttachedRules.Buildings.GetAsObjectList());
        c.Items.AddRange(Map.AttachedRules.Aircrafts.GetAsObjectList());
        c.Items.AddRange(Map.AttachedRules.Vessels.GetAsObjectList());
      }
      cbWaypoint.Items.Clear();
      cbWaypoint.Items.Add("-1");
      cbWaypoint.Items.AddRange(map.WaypointSection.WaypointList.ToArray());
      cbTrigger.Items.Clear();
      cbTrigger.Items.Add("None");
      cbTrigger.Items.AddRange(map.TriggerSection.TriggerList.ToArray());
    }

    public void UpdateUI()
    {
      if (TeamType == null)
      {
        this.Visible = false;
      }
      else
      {
        this.Visible = true;
        ScriptActionType script = cbScriptType.SelectedItem as ScriptActionType;
        cbScriptParameter.Visible = script != null && script.ParameterType != ScriptParameterType.NONE;
      }
    }

    public void UpdateScriptBox()
    {
      int i = 0;
      int sel = lboxTeamMissions.SelectedIndex;
      lboxTeamMissions.Items.Clear();
      foreach (var s in _scripts)
      {
        ScriptActionType satype = ScriptActions.GetScriptAction(s.ScriptType);
        lboxTeamMissions.Items.Add($"{i++}\t{satype,-32}\t{s.Parameter.Value}");
      }
      if (sel < lboxTeamMissions.Items.Count)
      {
        lboxTeamMissions.SelectedIndex = sel;
      }
    }

    public void UpdateTechnoList()
    {
      _technoList.Clear();
      if (cbTechnoType1.SelectedItem != null && nudTechnoNum1.Value != 0) { _technoList.Add(new TeamTypeInfo.TechnoCountInfo() { ID = (cbTechnoType1.SelectedItem as ITechnoType).ID, Num = (int)nudTechnoNum1.Value }); }
      if (cbTechnoType2.SelectedItem != null && nudTechnoNum2.Value != 0) { _technoList.Add(new TeamTypeInfo.TechnoCountInfo() { ID = (cbTechnoType2.SelectedItem as ITechnoType).ID, Num = (int)nudTechnoNum2.Value }); }
      if (cbTechnoType3.SelectedItem != null && nudTechnoNum3.Value != 0) { _technoList.Add(new TeamTypeInfo.TechnoCountInfo() { ID = (cbTechnoType3.SelectedItem as ITechnoType).ID, Num = (int)nudTechnoNum3.Value }); }
      if (cbTechnoType4.SelectedItem != null && nudTechnoNum4.Value != 0) { _technoList.Add(new TeamTypeInfo.TechnoCountInfo() { ID = (cbTechnoType4.SelectedItem as ITechnoType).ID, Num = (int)nudTechnoNum4.Value }); }
      if (cbTechnoType5.SelectedItem != null && nudTechnoNum5.Value != 0) { _technoList.Add(new TeamTypeInfo.TechnoCountInfo() { ID = (cbTechnoType5.SelectedItem as ITechnoType).ID, Num = (int)nudTechnoNum5.Value }); }
    }

    public void UpdateTechnoBox()
    {
      if (_technoList.Count >= 1)
      {
        cbTechnoType1.SelectedItem = IDToTechnoType(_technoList[0].ID);
        nudTechnoNum1.Value = _technoList[0].Num;
        bTechnoType1.Text = "Del.";
        cbTechnoType1.Visible = true;
        nudTechnoNum1.Visible = true;
        bTechnoType2.Visible = true;
      }
      else
      {
        cbTechnoType1.SelectedItem = null;
        nudTechnoNum1.Value = 0;
        bTechnoType1.Text = "Add";
        cbTechnoType1.Visible = false;
        nudTechnoNum1.Visible = false;
        bTechnoType2.Visible = false;
      }

      if (_technoList.Count >= 2)
      {
        cbTechnoType2.SelectedItem = IDToTechnoType(_technoList[1].ID);
        nudTechnoNum2.Value = _technoList[1].Num;
        bTechnoType2.Text = "Del.";
        cbTechnoType2.Visible = true;
        nudTechnoNum2.Visible = true;
        bTechnoType3.Visible = true;
      }
      else
      {
        cbTechnoType2.SelectedItem = null;
        nudTechnoNum2.Value = 0;
        bTechnoType2.Text = "Add";
        cbTechnoType2.Visible = false;
        nudTechnoNum2.Visible = false;
        bTechnoType3.Visible = false;
      }

      if (_technoList.Count >= 3)
      {
        cbTechnoType3.SelectedItem = IDToTechnoType(_technoList[2].ID);
        nudTechnoNum3.Value = _technoList[2].Num;
        bTechnoType3.Text = "Del.";
        cbTechnoType3.Visible = true;
        nudTechnoNum3.Visible = true;
        bTechnoType4.Visible = true;
      }
      else
      {
        cbTechnoType3.SelectedItem = null;
        nudTechnoNum3.Value = 0;
        bTechnoType3.Text = "Add";
        cbTechnoType3.Visible = false;
        nudTechnoNum3.Visible = false;
        bTechnoType4.Visible = false;
      }

      if (_technoList.Count >= 4)
      {
        cbTechnoType4.SelectedItem = IDToTechnoType(_technoList[3].ID);
        nudTechnoNum4.Value = _technoList[3].Num;
        bTechnoType4.Text = "Del.";
        cbTechnoType4.Visible = true;
        nudTechnoNum4.Visible = true;
        bTechnoType5.Visible = true;
      }
      else
      {
        cbTechnoType4.SelectedItem = null;
        nudTechnoNum4.Value = 0;
        bTechnoType4.Text = "Add";
        cbTechnoType4.Visible = false;
        nudTechnoNum4.Visible = false;
        bTechnoType5.Visible = false;
      }

      if (_technoList.Count >= 5)
      {
        cbTechnoType5.SelectedItem = IDToTechnoType(_technoList[4].ID);
        nudTechnoNum5.Value = _technoList[4].Num;
        bTechnoType5.Text = "Del.";
        cbTechnoType5.Visible = true;
        nudTechnoNum5.Visible = true;
      }
      else
      {
        cbTechnoType5.SelectedItem = null;
        nudTechnoNum5.Value = 0;
        bTechnoType5.Text = "Add";
        cbTechnoType5.Visible = false;
        nudTechnoNum5.Visible = false;
      }
    }

    private void Fetch(ComboBox cbox, Label label, ScriptParameterType type)
    {
      cbox.Items.Clear();
      if (type == ScriptParameterType.NONE)
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

      if (type == ScriptParameterType.MISSIONTYPE)
      {
        labelText = "Mission";
        cbox.Items.AddRange(Missions.GetAsObjectList());
      }

      else if (type == ScriptParameterType.QUARRY)
      {
        labelText = "Target";
        cbox.Items.AddRange(Enum.GetNames(typeof(QuarryType)));
      }
      else if (type == ScriptParameterType.WAYPOINT)
      {
        object[] olst = new object[100];
        for (int i = 0; i < olst.Length; i++)
        {
          olst[i] = i;
        }
        cbox.Items.AddRange(olst);
        labelText = "Waypoint";
      }
      else if (type == ScriptParameterType.GLOBALS)
      {
        object[] olst = new object[Constants.MAX_GLOBALS];
        for (int i = 0; i < olst.Length; i++)
        {
          olst[i] = i;
        }
        cbox.Items.AddRange(olst);
        labelText = "Globals";
      }
      else if (type == ScriptParameterType.INTEGER
       || type == ScriptParameterType.FORMATION
       || type == ScriptParameterType.TARGET
       )
      {
        // allow user input (integer)
        cstyle = ComboBoxStyle.DropDown;

        // eventually support list for some of these item types
        labelText = "ID";
      }

      if (label != null) { label.Text = labelText; }
      cbox.DropDownStyle = cstyle;
    }

    private bool SaveTeamType()
    {
      // check
      if (string.IsNullOrWhiteSpace(tbName.Text))
      {
        MessageBox.Show("Please enter a team name.");
        return false;
      }

      if (Map.TeamTypeSection.TeamTypeList.FindAll((t) => t != TeamType && t.Name == tbName.Text).Count > 0)
      {
        MessageBox.Show("An existing teamtype already uses the trigger name. Please enter a unique teamtype name.");
        return false;
      }

      string prevValue = TeamType.GetValueAsString(Map);
      string commentkey = Ext_CommentsSection.TeamTypePrefix + TeamType.Name;

      if (TeamType.Name != tbName.Text)
      {
        string prevkey = TeamType.Name;
        TeamType.Name = tbName.Text;
        Map.Ext_CommentsSection.Transfer(prevkey, commentkey, true);
      }
      TeamType.Owner = Map.AttachedRules.Houses.GetHouseID(cbOwner.Text);
      TeamType.Trigger = cbTrigger.SelectedItem as TriggerInfo;

      TeamType.Priority = (int)nudPriority.Value;
      TeamType.MaxAllowed = (int)nudMax.Value;
      TeamType.InitNum = (int)nudInitNum.Value;
      TeamType.WaypointID = cbWaypoint.SelectedItem is WaypointInfo w ? int.Parse(w.ID) : -1;
      TeamType.BitField.AvoidThreats = cbAvoidThreats.Checked;
      TeamType.BitField.Suicide = cbSuicide.Checked;
      TeamType.BitField.AutoCreate = cbAutocreate.Checked;
      TeamType.BitField.PrebuildMembers = cbPrebuild.Checked;
      TeamType.BitField.Reinforce = cbReinforce.Checked;

      UpdateTechnoList();
      TeamType.TechnoList.Clear();
      TeamType.TechnoList.AddRange(_technoList);

      TeamType.ScriptList.Clear();
      TeamType.ScriptList.AddRange(_scripts);

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

      string thisValue = TeamType.GetValueAsString(Map);
      if (commentChanged || prevValue != thisValue) { Map.Dirty = true; }

      return true;
    }

    private void PreviewTeamType()
    {
      TeamTypeInfo teamtype = new TeamTypeInfo();
      teamtype.Name = string.IsNullOrWhiteSpace(tbName.Text) ? "???" : tbName.Text;
      teamtype.Owner = Map.AttachedRules.Houses.GetHouseID(cbOwner.Text);
      teamtype.Trigger = cbTrigger.SelectedItem as TriggerInfo;

      teamtype.Priority = (int)nudPriority.Value;
      teamtype.MaxAllowed = (int)nudMax.Value;
      teamtype.InitNum = (int)nudInitNum.Value;
      teamtype.WaypointID = cbWaypoint.SelectedItem is WaypointInfo w ? int.Parse(w.ID) : -1;
      teamtype.BitField.AvoidThreats = cbAvoidThreats.Checked;
      teamtype.BitField.Suicide = cbSuicide.Checked;
      teamtype.BitField.AutoCreate = cbAutocreate.Checked;
      teamtype.BitField.PrebuildMembers = cbPrebuild.Checked;
      teamtype.BitField.Reinforce = cbReinforce.Checked;

      teamtype.TechnoList.Clear();
      teamtype.TechnoList.AddRange(_technoList);

      teamtype.ScriptList.Clear();
      teamtype.ScriptList.AddRange(_scripts);

      tbRaw.Text = teamtype.GetKeyAsString() + "=" + teamtype.GetValueAsString(Map);
    }

    private void Value_Changed(object sender, EventArgs e)
    {
      if (!_suspendDirty && sender is Control c)
      {
        DirtyControlsHandler.SetDirtyColor(c);
        bCancel.Enabled = true;
      }
      PreviewTeamType();
    }

    private void Value_Changed_2(object sender, EventArgs e)
    {
      // change only the tag color
      if (!_suspendDirty && sender is Control c)
      {
        if (c.Tag is Control d)
        {
          DirtyControlsHandler.SetDirtyColor(d);
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

    private void bOK_Click(object sender, EventArgs e)
    {
      if (SaveTeamType())
      {
        // TO-DO: did not update parent control when name is changed!
        Map.Update();
        TeamTypeUpdated?.Invoke();
        SetTeamType(TeamType);
      }
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      SetTeamType(TeamType);
    }

    private void cbScriptType_SelectedIndexChanged(object sender, EventArgs e)
    {
      ScriptActionType script = ScriptActions.GetScriptAction(cbScriptType.SelectedIndex);
      Fetch(cbScriptParameter, null, script.ParameterType);
      SetValue(cbScriptParameter, null);
      bScriptInsertBefore.Enabled = cbScriptType.SelectedIndex != -1;
      bScriptInsertAfter.Enabled = cbScriptType.SelectedIndex != -1;
      bScriptInsertReplace.Enabled = cbScriptType.SelectedIndex != -1;
      bGetTarget.Visible = script.ParameterType == ScriptParameterType.TARGET;
      UpdateUI();
    }

    private void TechnoNum_ValueChanged(object sender, EventArgs e)
    {
      Value_Changed(sender, e);
    }

    private void lboxTeamMissions_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = lboxTeamMissions.SelectedIndex;
      if (index != -1)
      {
        cbScriptType.SelectedItem = ScriptActions.GetScriptAction(_scripts[index].ScriptType);
        SetValue(cbScriptParameter, _scripts[index].Parameter.Value);
      }
      bScriptDelete.Enabled = index != -1;
      bScriptMoveDown.Enabled = index != -1 && index != lboxTeamMissions.Items.Count - 1;
      bScriptMoveUp.Enabled = index != -1 && index != 0;
    }

    private void bScriptMoveUp_Click(object sender, EventArgs e)
    {
      // swap
      int index = lboxTeamMissions.SelectedIndex;
      if (index != -1 && index != 0)
      {
        var temp = _scripts[index];
        _scripts[index] = _scripts[index - 1];
        _scripts[index - 1] = temp;
        UpdateScriptBox();
        lboxTeamMissions.SelectedIndex = index - 1;
      }
    }

    private void bScriptMoveDown_Click(object sender, EventArgs e)
    {
      // swap
      int index = lboxTeamMissions.SelectedIndex;
      if (index != -1 && index != _scripts.Count - 1)
      {
        var temp = _scripts[index];
        _scripts[index] = _scripts[index + 1];
        _scripts[index + 1] = temp;
        UpdateScriptBox();
        lboxTeamMissions.SelectedIndex = index + 1;
      }
    }

    private void bScriptDelete_Click(object sender, EventArgs e)
    {
      int index = lboxTeamMissions.SelectedIndex;
      if (index != -1)
      {
        _scripts.RemoveAt(index);
        UpdateScriptBox();
      }
    }

    private bool TryGetScript(out TeamTypeInfo.ScriptInfo sinfo)
    {
      if (cbScriptType.SelectedIndex != -1)
      {
        ScriptActionType stype = ScriptActions.GetScriptAction(cbScriptType.SelectedIndex);
        sinfo = new TeamTypeInfo.ScriptInfo() { ScriptType = cbScriptType.SelectedIndex, Parameter = TeamTypeInfo.SelectParameterInfo(stype.ParameterType) };
        if (cbScriptParameter.SelectedIndex == -1 && int.TryParse(cbScriptParameter.Text, out int id))
        {
          sinfo.Parameter.UpdateValue(id, Map);
        }
        else
        {
          sinfo.Parameter.UpdateValue(cbScriptParameter.SelectedIndex, Map);
        }

        return true;
      }
      sinfo = default;
      return false;
    }

    private void bScriptInsertBefore_Click(object sender, EventArgs e)
    {
      int index = lboxTeamMissions.SelectedIndex;
      if (index == -1) { index = 0; }
      if (TryGetScript(out TeamTypeInfo.ScriptInfo sinfo))
      {
        _scripts.Insert(index, sinfo);
        UpdateScriptBox();
        lboxTeamMissions.SelectedIndex = index;
      }
    }

    private void bScriptInsertAfter_Click(object sender, EventArgs e)
    {
      int index = lboxTeamMissions.SelectedIndex;
      if (index == -1) { index = 0; }
      if (TryGetScript(out TeamTypeInfo.ScriptInfo sinfo))
      {
        int new_index;
        if (_scripts.Count == 0 || index == _scripts.Count - 1)
        {
          _scripts.Add(sinfo);
          new_index = _scripts.Count - 1;
        }
        else
        {
          _scripts.Insert(index + 1, sinfo);
          new_index = index + 1;
        }
        UpdateScriptBox();
        lboxTeamMissions.SelectedIndex = new_index;
      }
    }

    private void bScriptInsertReplace_Click(object sender, EventArgs e)
    {
      int index = lboxTeamMissions.SelectedIndex;
      if (index == -1) { index = 0; }
      if (TryGetScript(out TeamTypeInfo.ScriptInfo sinfo))
      {
        if (_scripts.Count > 0)
        {
          _scripts.RemoveAt(index);
        }
        _scripts.Insert(index, sinfo);
        UpdateScriptBox();
        lboxTeamMissions.SelectedIndex = index;
      }
    }

    private void cbTechnoType_SelectedIndexChanged(object sender, EventArgs e)
    {
      Value_Changed(sender, e);
    }

    private void tbName_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Name; }
    private void cbOwner_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Owner; }
    private void cbTrigger_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_TriggerTag; }
    private void nudTechno_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Techno; }
    private void cbAvoidThreats_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_AvoidThreats; }
    private void cbSuicide_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Suicide; }
    private void cbAutocreate_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Autocreate; }
    private void cbPrebuild_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Prebuild; }
    private void cbReinforce_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Reinforce; }
    private void nudPriority_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Priority; }
    private void nudMax_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Maximum; }
    private void nudInitNum_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_InitNum; }
    private void cbWaypoint_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TeamType_Waypoint; }
    private void tbComment_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.Comment; }
    private void bScriptMoveUp_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Moves the selected team mission up one step in the sequence";  }
    private void bScriptMoveDown_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Moves the selected team mission down one step in the sequence"; }
    private void bScriptDelete_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Removes the selected team mission from the sequence"; }
    private void bScriptInsertBefore_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Inserts the new team mission before the currently selected step"; }
    private void bScriptInsertReplace_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Replaces the selected team mission with the new one"; }
    private void bScriptInsertAfter_MouseEnter(object sender, EventArgs e) { tbHint.Text = "Inserts the new team mission after the currently selected step"; }
    private void cbScriptType_MouseEnter(object sender, EventArgs e)
    {
      if (cbScriptType.SelectedIndex != -1)
      {
        ScriptActionType stype = ScriptActions.GetScriptAction(cbScriptType.SelectedIndex);
        tbHint.Text = stype.ID + Environment.NewLine + Environment.NewLine + stype.Description + Environment.NewLine + Environment.NewLine + "Parameter Type: " + stype.ParameterType;
      }
      else
      {
        tbHint.Text = string.Empty;
      }
    }

    private void cbScriptParameter_MouseEnter(object sender, EventArgs e)
    {
      if (cbScriptType.SelectedIndex != -1)
      {
        ScriptActionType stype = ScriptActions.GetScriptAction(cbScriptType.SelectedIndex);
        switch (stype.ParameterType)
        {
          default:
          case ScriptParameterType.NONE:
            tbHint.Text = string.Empty;
            break;
          case ScriptParameterType.INTEGER:
            tbHint.Text = "Script Parameter: Integer" + Environment.NewLine + Environment.NewLine + "Enter a suitable numeric value for the action";
            break;
          case ScriptParameterType.QUARRY:
            tbHint.Text = "Script Parameter: QuarryType / Target Specification" + Environment.NewLine + Environment.NewLine + "Specifies which objects are considered as targets for the action.";
            break;
          case ScriptParameterType.WAYPOINT:
            tbHint.Text = "Script Parameter: Waypoint" + Environment.NewLine + Environment.NewLine + "Determines the waypoint as the target for the action.";
            break;
          case ScriptParameterType.FORMATION:
            tbHint.Text = "Script Parameter: Formation" + Environment.NewLine + Environment.NewLine + "Determines the formation that this team will take.";
            break;
          case ScriptParameterType.MISSIONTYPE:
            tbHint.Text = "Script Parameter: MissionType" + Environment.NewLine + Environment.NewLine + "Determines the mission that this team will take.";
            break;
          case ScriptParameterType.GLOBALS:
            tbHint.Text = "Script Parameter: Globals" + Environment.NewLine + Environment.NewLine + "Determines the global variable that this team will set.";
            break;
          case ScriptParameterType.TARGET:
            tbHint.Text = "Script Parameter: Target Identifier" + Environment.NewLine + Environment.NewLine + "Identifies an object in the game.";
            break;
        }
      }
    }

    private void lboxTeamMissions_MouseEnter(object sender, EventArgs e)
    {
      tbHint.Text = Resources.Strings.TeamType_TeamMissions;
    }

    private void bTechnoType1_Click(object sender, EventArgs e)
    {
      if (bTechnoType1.Text == "Del.")
      {
        cbTechnoType1.SelectedIndex = -1;
        nudTechnoNum1.Value = 0;
      }
      else
      {
        cbTechnoType1.SelectedItem = IDToTechnoType("E1");
        nudTechnoNum1.Value = 1;
      }
      UpdateTechnoList();
      UpdateTechnoBox();
    }

    private void bTechnoType2_Click(object sender, EventArgs e)
    {
      if (bTechnoType2.Text == "Del.")
      {
        cbTechnoType2.SelectedIndex = -1;
        nudTechnoNum2.Value = 0;
      }
      else
      {
        cbTechnoType2.SelectedItem = IDToTechnoType("E1");
        nudTechnoNum2.Value = 1;
      }
      UpdateTechnoList();
      UpdateTechnoBox();
    }

    private void bTechnoType3_Click(object sender, EventArgs e)
    {
      if (bTechnoType3.Text == "Del.")
      {
        cbTechnoType3.SelectedIndex = -1;
        nudTechnoNum3.Value = 0;
      }
      else
      {
        cbTechnoType3.SelectedItem = IDToTechnoType("E1");
        nudTechnoNum3.Value = 1;
      }
      UpdateTechnoList();
      UpdateTechnoBox();
    }

    private void bTechnoType4_Click(object sender, EventArgs e)
    {
      if (bTechnoType4.Text == "Del.")
      {
        cbTechnoType4.SelectedIndex = -1;
        nudTechnoNum4.Value = 0;
      }
      else
      {
        cbTechnoType4.SelectedItem = IDToTechnoType("E1");
        nudTechnoNum4.Value = 1;
      }
      UpdateTechnoList();
      UpdateTechnoBox();
    }

    private void bTechnoType5_Click(object sender, EventArgs e)
    {
      if (bTechnoType5.Text == "Del.")
      {
        cbTechnoType5.SelectedIndex = -1;
        nudTechnoNum5.Value = 0;
      }
      else
      {
        cbTechnoType5.SelectedItem = IDToTechnoType("E1");
        nudTechnoNum5.Value = 1;
      }
      UpdateTechnoList();
      UpdateTechnoBox();
    }

    private void bGetTarget_Click(object sender, EventArgs e)
    {
      using (SelectTarcomDialog std = new SelectTarcomDialog())
      {
        if (int.TryParse(cbScriptParameter.Text, out int index))
        {
          std.Set(index);
        } 
        if (std.ShowDialog() == DialogResult.OK)
        {
          int target = std.Target;
          cbScriptParameter.Text = target.ToString();
        }
      }
    }
  }
}
