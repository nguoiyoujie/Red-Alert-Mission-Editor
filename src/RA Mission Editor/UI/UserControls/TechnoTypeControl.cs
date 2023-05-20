using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.UI.Logic;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TechnoTypeControl : UserControl
  {
    public TechnoTypeControl()
    {
      InitializeComponent();
      cbMission.Items.AddRange(Missions.GetAll());
      MapUserThemes.SetRAFont(this);

      cbOwner.Tag = lblOwner;
      cbType.Tag = lblType;
      nudStrength.Tag = lblStrength;
      nudX.Tag = lblXY;
      nudY.Tag = lblXY;
      nudFacing.Tag = lblFacing;
      cbTag.Tag = lblTag;
      cbMission.Tag = lblMission;
      rbC.Tag = lblSubcell;
      rbTL.Tag = lblSubcell;
      rbTR.Tag = lblSubcell;
      rbBL.Tag = lblSubcell;
      rbBR.Tag = lblSubcell;
    }

    public TechnoTypeControl(MainModel model, Map map, IEntity entity, bool showPanels) : this()
    {
      _showPanels = showPanels;
      SetModel(model);
      SetMap(map);
      SetEntity(entity);
      UpdateShowHide();
    }

    public bool ShowPanels { get => _showPanels; set { if (_showPanels != value) { _showPanels = value; UpdateShowHide(); } } }
    private bool _showPanels = false;
    private bool _suspendDirty = false;
    public IEntity Entity { get; private set; }

    public Action<int, int, int, IEntity> ObjectUpdated;
    public Map Map { get; private set; }
    public MainModel Model { get; private set; }
    public NotifyDelegate TechnoTypeUpdated;

    private void UpdateShowHide()
    {
      if (!ShowPanels)
      {
        bShowHide.Text = "Show";
        pCommon1.Enabled = false;
        pCommon2.Enabled = false;
        pInfantry.Enabled = false;
        pMission.Enabled = false;
        pStructure.Enabled = false;
        pBottom.Enabled = false;

        pCommon1.Visible = false;
        pCommon2.Visible = false;
        pInfantry.Visible = false;
        pMission.Visible = false;
        pStructure.Visible = false;
        pBottom.Visible = false;

        Height = pTop.Height + pBlack.Height;
      }
      else
      {
        bShowHide.Text = "Hide";
        pBottom.Enabled = true;
        pStructure.Enabled = Entity is StructureInfo;
        pMission.Enabled = Entity is InfantryInfo || Entity is UnitInfo || Entity is ShipInfo;
        pInfantry.Enabled = Entity is InfantryInfo;
        pCommon2.Enabled = true;
        pCommon1.Enabled = true;

        pBottom.Visible = true;
        pStructure.Visible = pStructure.Enabled;
        pMission.Visible = pMission.Enabled;
        pInfantry.Visible = pInfantry.Enabled;
        pCommon2.Visible = true;
        pCommon1.Visible = true;

        Height = pTop.Height + pCommon1.Height + pCommon2.Height + pBottom.Height + (pInfantry.Enabled ? pInfantry.Height : 0) + (pMission.Enabled ? pMission.Height : 0) + (pStructure.Enabled ? pStructure.Height : 0) + pBlack.Height;
      }
    }

    public bool IsDirty
    {
      get
      {
        return DirtyControlsHandler.IsDirtyColor(this);
      }
    }

    public void SetModel(MainModel model)
    {
      Model = model;
    }

    public void SetMap(Map map)
    {
      cbTag.Items.Clear();
      cbOwner.Items.Clear();
      cbTag.Items.Add("None");
      // update the tags from the map
      Map = map;
      List<string> slist = new List<string>();
      foreach (TriggerInfo tag in map.TriggerSection.TriggerList)
      {
        slist.Add(tag.Name);
      }
      slist.Sort();

      cbTag.Items.AddRange(slist.Select((t) => t).ToArray());
      cbOwner.Items.AddRange(Map.AttachedRules.Houses.GetAll());
      // cbType depends on the technotype category we are using this form for
    }

    public void SetEntity(IEntity entity)
    {
      if (entity is InfantryInfo iinfo)
        SetEntity(iinfo as InfantryInfo);
      else if (entity is UnitInfo uinfo)
        SetEntity(uinfo as UnitInfo);
      else if (entity is ShipInfo sinfo)
        SetEntity(sinfo as ShipInfo);
      else if (entity is StructureInfo tinfo)
        SetEntity(tinfo as StructureInfo);
      else if (entity is BaseInfo binfo)
        SetEntity(binfo as BaseInfo);
    }

    public void SetEntity(InfantryInfo sinfo)
    {
      _suspendDirty = true;
      cbType.Items.Clear();
      cbType.Items.AddRange(Map.AttachedRules.Infantries.GetAsObjectList()); // fill with name string

      Entity = sinfo;
      cbOwner.Text = sinfo.Owner;
      cbType.SelectedItem = Map.AttachedRules.Infantries.GetAll().ToList().Find((t) => t.ID == sinfo.ID);
      nudFacing.Value = Math.Min(nudFacing.Maximum, Math.Max(nudFacing.Minimum, sinfo.Facing));
      nudX.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.CellX(sinfo.Cell)));
      nudY.Value = Math.Min(nudY.Maximum, Math.Max(nudY.Minimum, Map.CellY(sinfo.Cell)));
      nudStrength.Value = Math.Min(nudStrength.Maximum, Math.Max(nudStrength.Minimum, (int)sinfo.Health));
      cbTag.Text = sinfo.Tag;
      cbMission.Text = sinfo.Mission;
      switch (sinfo.SubCell)
      {
        case 0: // C
          rbC.Checked = true;
          break;
        case 1: // TL
          rbTL.Checked = true;
          break;
        case 2: // TR
          rbTR.Checked = true;
          break;
        case 3: // BL
          rbBL.Checked = true;
          break;
        case 4: // BL
          rbBR.Checked = true;
          break;
      }

      cbOwner.Enabled = true;
      lblStrength.Text = "Strength";

      lblEntity.Text = $"{cbType.SelectedItem.ToString() ?? sinfo.ID}, {sinfo.Owner}";
      DirtyControlsHandler.ResetDirtyColor(this);
      UpdateShowHide();
      _suspendDirty = false;
      bCancel.Enabled = false;
    }

    public void SetEntity(StructureInfo sinfo)
    {
      cbType.Items.Clear();
      cbType.Items.AddRange(Map.AttachedRules.Structures.GetAsObjectList()); // fill with name string

      Entity = sinfo;
      cbOwner.Text = sinfo.Owner;
      cbType.SelectedItem = Map.AttachedRules.Structures.GetAll().ToList().Find((t) => t.ID == sinfo.ID);
      nudFacing.Value = Math.Min(nudFacing.Maximum, Math.Max(nudFacing.Minimum, sinfo.Facing));
      nudX.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.CellX(sinfo.Cell)));
      nudY.Value = Math.Min(nudY.Maximum, Math.Max(nudY.Minimum, Map.CellY(sinfo.Cell)));
      nudStrength.Value = Math.Min(nudStrength.Maximum, Math.Max(nudStrength.Minimum, (int)sinfo.Health));
      cbTag.Text = sinfo.Tag;
      cbRepairable.Checked = sinfo.AIRepairable;
      cbSellable.Checked = sinfo.AISellable;

      cbOwner.Enabled = true;
      lblStrength.Text = "Strength";

      lblEntity.Text = $"{cbType.SelectedItem.ToString() ?? sinfo.ID}, {sinfo.Owner}";
      DirtyControlsHandler.ResetDirtyColor(this);
      UpdateShowHide();
      bCancel.Enabled = false;
    }

    public void SetEntity(BaseInfo binfo)
    {
      // requires SetMap()
      cbType.Items.Clear();
      cbType.Items.AddRange(Map.AttachedRules.Structures.GetAsObjectList());

      Entity = binfo;
      cbOwner.Text = Map.BaseSection.Player;
      cbType.SelectedItem = Map.AttachedRules.Structures.GetAll().ToList().Find((t) => t.ID == binfo.ID);
      nudX.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.CellX(binfo.Cell)));
      nudY.Value = Math.Min(nudY.Maximum, Math.Max(nudY.Minimum, Map.CellY(binfo.Cell)));
      nudStrength.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.BaseSection.BaseList.IndexOf(binfo)));

      cbOwner.Enabled = false;
      lblStrength.Text = "Priority";

      lblEntity.Text = $"(Base) {cbType.SelectedItem.ToString() ?? binfo.ID}";
      DirtyControlsHandler.ResetDirtyColor(this);
      UpdateShowHide();
      bCancel.Enabled = false;
    }


    public void SetEntity(UnitInfo sinfo)
    {
      cbType.Items.Clear();
      cbType.Items.AddRange(Map.AttachedRules.Units.GetAsObjectList()); // fill with name string

      Entity = sinfo;
      cbOwner.Text = sinfo.Owner;
      cbType.SelectedItem = Map.AttachedRules.Units.GetAll().ToList().Find((t) => t.ID == sinfo.ID);
      nudFacing.Value = Math.Min(nudFacing.Maximum, Math.Max(nudFacing.Minimum, sinfo.Facing));
      nudX.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.CellX(sinfo.Cell)));
      nudY.Value = Math.Min(nudY.Maximum, Math.Max(nudY.Minimum, Map.CellY(sinfo.Cell)));
      nudStrength.Value = Math.Min(nudStrength.Maximum, Math.Max(nudStrength.Minimum, (int)sinfo.Health));
      cbTag.Text = sinfo.Tag;
      cbMission.Text = sinfo.Mission;

      cbOwner.Enabled = true;
      lblStrength.Text = "Strength";

      lblEntity.Text = $"{cbType.SelectedItem.ToString() ?? sinfo.ID}, {sinfo.Owner}";
      DirtyControlsHandler.ResetDirtyColor(this);
      UpdateShowHide();
      bCancel.Enabled = false;
    }

    public void SetEntity(ShipInfo sinfo)
    {
      cbType.Items.Clear();
      cbType.Items.AddRange(Map.AttachedRules.Ships.GetAsObjectList()); // fill with name string

      Entity = sinfo;
      cbOwner.Text = sinfo.Owner;
      cbType.SelectedItem = Map.AttachedRules.Ships.GetAll().ToList().Find((t) => t.ID == sinfo.ID);
      nudFacing.Value = Math.Min(nudFacing.Maximum, Math.Max(nudFacing.Minimum, sinfo.Facing));
      nudX.Value = Math.Min(nudX.Maximum, Math.Max(nudX.Minimum, Map.CellX(sinfo.Cell)));
      nudY.Value = Math.Min(nudY.Maximum, Math.Max(nudY.Minimum, Map.CellY(sinfo.Cell)));
      nudStrength.Value = Math.Min(nudStrength.Maximum, Math.Max(nudStrength.Minimum, (int)sinfo.Health));
      cbTag.Text = sinfo.Tag;
      cbMission.Text = sinfo.Mission;

      cbOwner.Enabled = true;
      lblStrength.Text = "Strength";

      lblEntity.Text = $"{cbType.SelectedItem.ToString() ?? sinfo.ID}, {sinfo.Owner}";
      DirtyControlsHandler.ResetDirtyColor(this);
      UpdateShowHide();
      bCancel.Enabled = false;
    }

    public bool SaveEntity()
    {
      if (Entity is UnitInfo uinfo)
      {
        string previnfo = uinfo.GetValueAsString();
        uinfo.Owner = cbOwner.Text;
        UnitType entitytype = cbType.SelectedItem as UnitType;
        if (entitytype == null)
        {
          entitytype = Map.AttachedRules.Units.GetAll().ToList().Find((u) => cbType.Text == u.ToString());
          if (entitytype == null)
          {
            MessageBox.Show("Please select a valid unit type.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        uinfo.ID = entitytype.ID;
        uinfo.Health = (short)nudStrength.Value;
        uinfo.Cell = Map.CellNumber((int)nudX.Value, (int)nudY.Value);
        uinfo.Facing = (byte)nudFacing.Value;
        uinfo.Tag = cbTag.Text ?? "None";
        uinfo.Mission = cbMission.Text;
        string thisinfo = uinfo.GetValueAsString();
        if (previnfo != thisinfo) { Map.Dirty = true; }
      }
      else if (Entity is ShipInfo sinfo)
      {
        string previnfo = sinfo.GetValueAsString();
        sinfo.Owner = cbOwner.Text;
        ShipType entitytype = cbType.SelectedItem as ShipType;
        if (entitytype == null)
        {
          entitytype = Map.AttachedRules.Ships.GetAll().ToList().Find((u) => cbType.Text == u.ToString());
          if (entitytype == null)
          {
            MessageBox.Show("Please select a valid ship type.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        sinfo.ID = entitytype.ID;
        sinfo.Health = (short)nudStrength.Value;
        sinfo.Cell = Map.CellNumber((int)nudX.Value, (int)nudY.Value);
        sinfo.Facing = (byte)nudFacing.Value;
        sinfo.Tag = cbTag.Text ?? "None";
        sinfo.Mission = cbMission.Text;
        string thisinfo = sinfo.GetValueAsString();
        if (previnfo != thisinfo) { Map.Dirty = true; }
      }
      else if (Entity is InfantryInfo iinfo)
      {
        string previnfo = iinfo.GetValueAsString();
        iinfo.Owner = cbOwner.Text;
        InfantryType entitytype = cbType.SelectedItem as InfantryType;
        if (entitytype == null)
        {
          entitytype = Map.AttachedRules.Infantries.GetAll().ToList().Find((u) => cbType.Text == u.ToString());
          if (entitytype == null)
          {
            MessageBox.Show("Please select a valid infantry type.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        iinfo.ID = entitytype.ID;
        iinfo.Health = (short)nudStrength.Value;
        iinfo.Cell = Map.CellNumber((int)nudX.Value, (int)nudY.Value);
        iinfo.Facing = (byte)nudFacing.Value;
        iinfo.Tag = cbTag.Text ?? "None";
        iinfo.Mission = cbMission.Text;
        if (rbC.Checked)
          iinfo.SubCell = 0;
        else if (rbTL.Checked)
          iinfo.SubCell = 1;
        else if (rbTR.Checked)
          iinfo.SubCell = 2;
        else if (rbBL.Checked)
          iinfo.SubCell = 3;
        else if (rbBR.Checked)
          iinfo.SubCell = 4;
        string thisinfo = iinfo.GetValueAsString();
        if (previnfo != thisinfo) { Map.Dirty = true; }
      }
      else if (Entity is StructureInfo tinfo)
      {
        string previnfo = tinfo.GetValueAsString();
        tinfo.Owner = cbOwner.Text;
        StructureType entitytype = cbType.SelectedItem as StructureType;
        if (entitytype == null)
        {
          entitytype = Map.AttachedRules.Structures.GetAll().ToList().Find((u) => cbType.Text == u.ToString());
          if (entitytype == null)
          {
            MessageBox.Show("Please select a valid structure type.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        tinfo.ID = entitytype.ID;
        tinfo.Health = (short)nudStrength.Value;
        tinfo.Cell = Map.CellNumber((int)nudX.Value, (int)nudY.Value);
        tinfo.Facing = (byte)nudFacing.Value;
        tinfo.Tag = cbTag.Text ?? "None";
        tinfo.AIRepairable = cbRepairable.Checked;
        tinfo.AISellable = cbSellable.Checked;
        string thisinfo = tinfo.GetValueAsString();
        if (previnfo != thisinfo) { Map.Dirty = true; }
      }
      else if (Entity is BaseInfo binfo)
      {
        StructureType entitytype = cbType.SelectedItem as StructureType;
        if (entitytype == null)
        {
          entitytype = Map.AttachedRules.Structures.GetAll().ToList().Find((u) => cbType.Text == u.ToString());
          if (entitytype == null)
          {
            MessageBox.Show("Please select a valid structure type.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        binfo.ID = entitytype.ID;
        binfo.Cell = Map.CellNumber((int)nudX.Value, (int)nudY.Value);
        // reorder
        Map.BaseSection.BaseList.Remove(binfo);
        int index = (int)nudStrength.Value;
        Map.BaseSection.BaseList.Insert(Math.Min(Map.BaseSection.BaseList.Count - 1, Math.Max(0, index)), binfo);
        Map.Dirty = true;
      }

      return true;
    }

    private void bShowHide_Click(object sender, EventArgs e) { ShowPanels = !ShowPanels; }

    private void cbOwner_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Owner; }
    private void cbType_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Type; }
    private void nudStrength_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Strength; }
    private void nudXY_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Coordinates; }
    private void nudFacing_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Facing; }
    private void cbTag_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_TriggerTag; }
    private void cbSubcell_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_SubCell; }
    private void cbMission_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_UnitMission; }
    private void cbRepairable_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_AIRepairable; }

    private void cbSellable_Enter(object sender, EventArgs e)
    {
      // Strange code from Repair_AI in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/BUILDING.CPP
      // Line 5781: Strange firing condition for sellback: 
      //    if ((Session.Type != GAME_NORMAL || IsAllowedToSell) && IsTickedOff && House->Control.TechLevel >= Rule.IQSellBack && Random_Pick(0, 50) < House->Control.TechLevel && !Trigger.Is_Valid() && *this != STRUCT_CONST && Health_Ratio() < Rule.ConditionRed) {
      tbHint.Text = Resources.Strings.TechnoType_AISellable;
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      Revert();
    }

    private void Revert()
    {
      // revert
      if (Entity is InfantryInfo iinfo)
        SetEntity(iinfo);
      else if (Entity is UnitInfo uinfo)
        SetEntity(uinfo);
      else if (Entity is ShipInfo sinfo)
        SetEntity(sinfo);
      else if (Entity is StructureInfo tinfo)
        SetEntity(tinfo);
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      if (SaveEntity())
      {
        Map.Update();
        TechnoTypeUpdated?.Invoke();
        Revert();
        // signal map to reclick and redraw
        ObjectUpdated?.Invoke((int)nudX.Value, (int)nudY.Value, Entity is InfantryInfo iinfo ? iinfo.SubCell : 0, Entity);
      }
    }

    private void bDelete_Click(object sender, EventArgs e)
    {
      Model.DeleteEntity(Entity);
    }

    private void Value_Changed(object sender, EventArgs e)
    {
      if (!_suspendDirty && sender is Control c)
      {
        DirtyControlsHandler.SetDirtyColor(c);
        bCancel.Enabled = true;
      }
    }
  }
}
