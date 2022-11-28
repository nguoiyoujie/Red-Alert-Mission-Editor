using RA_Mission_Editor.MapData;
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
      foreach (Entities.StructureInfo building in map.StructureSection.StructureList)
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

      foreach (Entities.UnitInfo unit in map.UnitSection.UnitList)
      {
        if (unit.Owner == house.Name)
        {
          numUnits++;
          int v = rules.ReadInt(unit.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.InfantryInfo infantry in map.InfantrySection.InfantryList)
      {
        if (infantry.Owner == house.Name)
        {
          numInfantry++;
          int v = rules.ReadInt(infantry.ID, "Cost", out _, 0, map?.SourceFile);
          value += v;
        }
      }

      foreach (Entities.ShipInfo ship in map.ShipSection.ShipList)
      {
        if (ship.Owner == house.Name)
        {
          numVessel++;
          int v = rules.ReadInt(ship.ID, "Cost", out _, 0, map?.SourceFile);
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

      gbHouse.Text = house.Name;
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
