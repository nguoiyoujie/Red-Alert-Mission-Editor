using RA_Mission_Editor.Common;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class EditPreplaceEntityDialog : Form
  {
    public EditPreplaceEntityDialog()
    {
      InitializeComponent();
      MapUserThemes.SetRAFont(this);

      cbMission.Items.AddRange(Missions.GetAll());
    }

    public PlaceEntityInfo Entity;
    public Map Map { get; private set; } // not required

    public void SetMap(Map map)
    {
      Map = map;
      cbOwner.Items.AddRange(Map.AttachedRules.Houses.GetAll());
    }

    public void SetEntity(PlaceEntityInfo entity)
    {
      Entity = entity;
      tbType.Text = entity.Type?.ID ?? null; // fixed
      cbOwner.SelectedItem = Map.AttachedRules.Houses.GetHouse(entity.Owner);
      cbMission.SelectedItem = entity.Mission;
      nudFacing.Value = Math.Min(nudFacing.Maximum, Math.Max(nudFacing.Minimum, entity.Facing));
      nudStrength.Value = Math.Min(nudStrength.Maximum, Math.Max(nudStrength.Minimum, entity.Health));
      cbSellable.Checked = entity.AISellable;
      cbRepairable.Checked = entity.AIRepairable;

      if (entity.Type is BuildingType)
      {
        cbMission.Enabled = false;
      }
      else
      {
        cbSellable.Enabled = false;
        cbRepairable.Enabled = false;
      }
    }


    public bool Save()
    {
      if (cbOwner.SelectedItem is HouseType house) { Entity.Owner = house.Name; }
      if (cbMission.SelectedItem is MissionType mtype) { Entity.Mission = mtype; }
      Entity.Health = (short)nudStrength.Value;
      Entity.Facing = (byte)nudFacing.Value;
      Entity.AISellable = cbSellable.Checked;
      Entity.AIRepairable = cbRepairable.Checked;
      return true;
    }

    private void cbOwner_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Owner; }
    private void cbType_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Type; }
    private void nudStrength_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Strength; }
    private void nudFacing_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_Facing; }
    private void cbMission_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_UnitMission; }
    private void cbSubcell_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_SubCell; }
    private void cbRepairable_MouseEnter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.TechnoType_AIRepairable; }

    private void cbSellable_MouseEnter(object sender, EventArgs e)
    {
      // Strange code from Repair_AI in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/BUILDING.CPP
      // Line 5781: Strange firing condition for sellback: 
      //    if ((Session.Type != GAME_NORMAL || IsAllowedToSell) && IsTickedOff && House->Control.TechLevel >= Rule.IQSellBack && Random_Pick(0, 50) < House->Control.TechLevel && !Trigger.Is_Valid() && *this != STRUCT_CONST && Health_Ratio() < Rule.ConditionRed) {
      tbHint.Text = Resources.Strings.TechnoType_AISellable;
    }
 
    private void bCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      if (Save())
      {
        //Map.Update();
        DialogResult = DialogResult.OK;
        Close();
      }
    }

    private void EditPreplaceEntityDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = cbOwner;
    }
  }
}
