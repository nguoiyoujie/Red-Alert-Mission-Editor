﻿using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class HouseStatsControl : UserControl
  {
    public HouseStatsControl()
    {
      InitializeComponent();
    }

    public void SetHouse(Map map, Rules rules, HouseType house)
    {
      int numBuildings = 0;
      int numUnits = 0;
      int numInfantry = 0;
      int numVessel = 0;
      //int numAircraft = 0;
      int numTeams = 0;
      int power = 0;
      int drain = 0;
      int value = 0;
      string actlike = rules.ReadString(house.Name, "Country", out _, null, map?.SourceFile);
      if (!string.IsNullOrEmpty(actlike) && int.TryParse(actlike, out int actlikei))
      {
        actlike = rules.Houses.GetName(actlikei);
      }

      foreach (Entities.BuildingInfo building in map.BuildingSection.EntityList)
      {
        if (building.Owner == house.Name)
        {
          numBuildings++;
          int p = rules.ReadInt(building.ID, "Power", out _, 0, map?.SourceFile);
          if (p < 0) { drain -= p; } else { power += p * building.Health / 256; }
          int v = rules.ReadInt(building.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.UnitInfo unit in map.UnitSection.EntityList)
      {
        if (unit.Owner == house.Name)
        {
          numUnits++;
          int v = rules.ReadInt(unit.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.InfantryInfo infantry in map.InfantrySection.EntityList)
      {
        if (infantry.Owner == house.Name)
        {
          numInfantry++;
          int v = rules.ReadInt(infantry.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.VesselInfo vessel in map.VesselSection.EntityList)
      {
        if (vessel.Owner == house.Name)
        {
          numVessel++;
          int v = rules.ReadInt(vessel.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.TeamTypeInfo team in map.TeamTypeSection.TeamTypeList)
      {
        if (team.Owner == rules.Houses.GetHouseID(house.Name))
        {
          numTeams++;
        }
      }

      Color colors1 = ColorRemaps.GetRadarColor(house.RulesPrimaryColor);
      Color colors2 = ColorRemaps.GetRadarColor(house.RulesSecondaryColor);

      if (numBuildings == 0 && numUnits == 0 && numInfantry == 0 && numVessel == 0 && numTeams == 0)
      {
        Visible = false;
      }
      else
      {
        Visible = true;
        gbHouse.Text = (string.IsNullOrEmpty(actlike)) ? house.Name : (house.Name + "/" + actlike);
        lblBuildings.Text = numBuildings.ToString();
        lblUnits.Text = numUnits.ToString();
        lblInfantry.Text = numInfantry.ToString();
        lblVessels.Text = numVessel.ToString();
        lblTeams.Text = numTeams.ToString();
        lblPower.Text = drain.ToString() + " / " + power.ToString();
        lblPower.ForeColor = power >= drain ? Color.ForestGreen : power >= drain * 0.5f ? Color.Goldenrod : Color.Red;
        lblAssetValue.Text = value.ToString();
        pColor1.BackColor = colors1;
        pColor2.BackColor = colors2;
      }
    }
  }
}
