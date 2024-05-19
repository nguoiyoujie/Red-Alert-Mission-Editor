using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class HousesControl : UserControl
  {
    public HousesControl()
    {
      InitializeComponent();
      ucHouse.SetHouse(null);
    }

    public Map Map { get; private set; }

    public void SetMap(Map map)
    {
      Map = map;
      ucHouse.SetMap(map);
      ucHouse.SetHouse(ucHouse.HouseData);
      ResetList();
    }

    private void ResetList()
    {
      lboxHousesList.Items.Clear();
      lboxHousesList.Items.AddRange(Map.AttachedRules.Houses.GetAll());
    }

    private void lboxHouseList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lboxHousesList.SelectedItem is HouseType htype)
      {
        ucHouse.Enabled = true;
        ucHouse.SetHouse(Map.HouseSections[Map.AttachedRules.Houses.GetHouseID(htype.Name)]);
      }
    }
  }
}
