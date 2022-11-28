using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class HouseControl : UserControl
  {
    public HouseControl()
    {
      InitializeComponent();

      cbColor.Items.Add("");
      cbColor.Items.AddRange(Enum.GetNames(typeof(ColorType)));

      cbSecondaryColor.Items.Add("");
      cbSecondaryColor.Items.AddRange(Enum.GetNames(typeof(ColorType)));

      cbColor.Tag = lblColor;
      cbSecondaryColor.Tag = lblSecondaryColor;
      cbCountry.Tag = lblCountry;

      nudFirepower.Tag = lblFirepower;
      nudGroundSpeed.Tag = lblGroundSpeed;
      nudAirSpeed.Tag = lblAirSpeed;
      nudArmor.Tag = lblArmor;
      nudROF.Tag = lblROF;
      nudCost.Tag = lblCost;
      nudBuildTime.Tag = lblBuildTime;
      nudCredits.Tag = lblCredits;
      nudIQ.Tag = lblIQ;
      nudTechLevel.Tag = lblTechLevel;

      cbEnableIranOverrides.CheckedChanged += cbEnableIranOverrides_CheckedChanged;
    }

    public Map Map;
    public HouseSection HouseData;
    private CheckBox[] AlliesCheckBoxes;
    private bool _suspendDirty = false;

    private void cbEnableIranOverrides_CheckedChanged(object sender, EventArgs e)
    {
      gbIran.Enabled = cbEnableIranOverrides.Checked;
    }

    public void SetMap(Map map)
    {
      Map = map;
      AlliesCheckBoxes = new CheckBox[map.AttachedRules.Houses.Count];

      int initY = 14;
      int incrY = 20;
      int initX = 6;
      int x = initX;
      int y = initY;
      for (int i = 0; i < AlliesCheckBoxes.Length; i++)
      {
        AlliesCheckBoxes[i] = new CheckBox()
        {
          Text = map.AttachedRules.Houses.GetName(i),
          Location = new Point(x, y),
          Enabled = true,
          Visible = true,
        };
        AlliesCheckBoxes[i].Enter += cbAllies_Enter;
        AlliesCheckBoxes[i].CheckedChanged += Value_Changed;
        y += incrY;
      }
      gbAllies.Controls.AddRange(AlliesCheckBoxes);

      cbCountry.Items.Add("");
      cbCountry.Items.AddRange(map.AttachedRules.Houses.GetAll());
    }

    public void SetHouse(HouseSection house)
    {
      _suspendDirty = true;
      HouseData = house;

      if (house == null)
      {
        gbAllies.Enabled = false;
        gbIran.Enabled = false;
        gbMultipliers.Enabled = false;
        gbGeneral.Enabled = false;
      }
      else
      {
        nudTechLevel.Value = (house.TechLevel.HasValue) ? house.TechLevel.Value : 10;
        nudIQ.Value = (house.IQ.HasValue) ? house.IQ.Value : 0;
        nudCredits.Value = (house.Credits.HasValue) ? house.Credits.Value : 0;
        cbPlayerControl.Checked = (house.PlayerControl.HasValue) && house.PlayerControl.Value;

        nudFirepower.Value = (house.Firepower.HasValue) ? (decimal)house.Firepower.Value : 1;
        nudGroundSpeed.Value = (house.Groundspeed.HasValue) ? (decimal)house.Groundspeed.Value : 1;
        nudAirSpeed.Value = (house.Airspeed.HasValue) ? (decimal)house.Airspeed.Value : 1;
        nudArmor.Value = (house.Armor.HasValue) ? (decimal)house.Armor.Value : 1;
        nudROF.Value = (house.ROF.HasValue) ? (decimal)house.ROF.Value : 1;
        nudCost.Value = (house.Cost.HasValue) ? (decimal)house.Cost.Value : 1;
        nudBuildTime.Value = (house.BuildTime.HasValue) ? (decimal)house.BuildTime.Value : 1;

        if (house.Allies.HasValue)
        {
          List<string> allies = new List<string>(house.Allies.Value);
          for (int i = 0; i < AlliesCheckBoxes.Length; i++)
          {
            AlliesCheckBoxes[i].Checked = allies.Contains(Map.AttachedRules.Houses.GetName(i));
          }
        }
        else
        {
          for (int i = 0; i < AlliesCheckBoxes.Length; i++)
          {
            AlliesCheckBoxes[i].Checked = false;
          }
        }

        bool hasOverride = false;
        if (house.Color.HasValue) { hasOverride = true; cbColor.SelectedItem = ((ColorType)house.Color.Value).ToString(); } else { cbColor.SelectedItem = null; }
        if (house.SecondaryColorScheme.HasValue) { hasOverride = true; cbSecondaryColor.SelectedItem = ((ColorType)house.SecondaryColorScheme.Value).ToString(); } else { cbSecondaryColor.SelectedItem = null; }
        if (house.Country.HasValue) { hasOverride = true; cbCountry.SelectedItem = Map.AttachedRules.Houses.GetHouse(house.Country.Value); } else { cbCountry.SelectedItem = null; }
        if (house.BuildingsGetInstantlyCaptured.HasValue) { hasOverride = true; cbBuildingsInstantCapture.Checked = house.BuildingsGetInstantlyCaptured.Value; } else { cbBuildingsInstantCapture.Checked = false; }
        if (house.NoBuildingCrew.HasValue) { hasOverride = true; cbNoBuildingCrew.Checked = house.NoBuildingCrew.Value; } else { cbNoBuildingCrew.Checked = false; }

        cbEnableIranOverrides.Checked = hasOverride;

        gbAllies.Enabled = true;
        gbIran.Enabled = hasOverride;
        gbMultipliers.Enabled = true;
        gbGeneral.Enabled = true;

        ResetColor(this);
        _suspendDirty = false;
      }
    }

    public bool SaveHouse()
    {
      if (HouseData != null)
      {
        HouseData.TechLevel.Set((int)nudTechLevel.Value);
        HouseData.IQ.Set((int)nudIQ.Value);
        HouseData.Credits.Set((int)nudCredits.Value);
        HouseData.PlayerControl.Set(cbPlayerControl.Checked);

        HouseData.Firepower.Set((float)nudFirepower.Value);
        HouseData.Groundspeed.Set((float)nudGroundSpeed.Value);
        HouseData.Airspeed.Set((float)nudAirSpeed.Value);
        HouseData.Armor.Set((float)nudArmor.Value);
        HouseData.ROF.Set((float)nudROF.Value);
        HouseData.Cost.Set((float)nudCost.Value);
        HouseData.BuildTime.Set((float)nudBuildTime.Value);

        List<string> allies = new List<string>();
        for (int i = 0; i < AlliesCheckBoxes.Length; i++)
        {
          if (AlliesCheckBoxes[i].Checked)
          {
            allies.Add(Map.AttachedRules.Houses.GetName(i));
          }
        }

        if (allies.Count > 1)
        {
          HouseData.Allies.Set(allies);
        }

        if (cbEnableIranOverrides.Checked)
        {
          if (Enum.TryParse(cbColor.Text, out ColorType color)) { HouseData.Color.Set((int)color); } else { HouseData.Color.Clear(); }
          if (Enum.TryParse(cbSecondaryColor.Text, out ColorType seccolor)) { HouseData.SecondaryColorScheme.Set((int)seccolor); } else { HouseData.SecondaryColorScheme.Clear(); }
          int actCountry = Map.AttachedRules.Houses.GetHouseID(cbCountry.Text);
          if (actCountry != -1) { HouseData.Country.Set(actCountry); } else { HouseData.Country.Clear(); }
          HouseData.BuildingsGetInstantlyCaptured.Set(cbBuildingsInstantCapture.Checked);
          HouseData.NoBuildingCrew.Set(cbNoBuildingCrew.Checked);
        }
        else
        {
          HouseData.Color.Clear();
          HouseData.SecondaryColorScheme.Clear();
          HouseData.Country.Clear();
          HouseData.BuildingsGetInstantlyCaptured.Clear();
          HouseData.NoBuildingCrew.Clear();
        }
        Map.Update();
        Map.AttachedRules.ApplyRulesWithMap(Map);
        Map.Dirty = true;
        Map.InvalidateObjectDisplay?.Invoke();
      }
      return true;
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

    private void bOK_Click(object sender, EventArgs e)
    {
      if (SaveHouse())
      {
        Map.Update();
        SetHouse(HouseData);
      }
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      SetHouse(HouseData);
    }

    private void nudTechLevel_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_TechLevel; }
    private void nudIQ_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_IQ; }
    private void nudCredits_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_Credits; }
    private void nudMultipliers_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_Multipliers; }

    private void cbPlayerControl_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_PlayerControl; }
    private void cbColor_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_SecondaryColor; }
    private void cbSecondaryColor_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_Color; }
    private void cbCountry_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_Country; }
    private void cbBuildingsInstantCapture_Enter(object sender, EventArgs e) {  tbHint.Text = Resources.Strings.HouseType_InstantCapture; }
    private void cbNoBuildingCrew_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_NoCrew; }

    private void cbAllies_Enter(object sender, EventArgs e) { tbHint.Text = Resources.Strings.HouseType_Allies; }

  }
}
