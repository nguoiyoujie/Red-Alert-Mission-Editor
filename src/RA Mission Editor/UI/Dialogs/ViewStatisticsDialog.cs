using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class ViewStatisticsDialog : Form
  {
    public ViewStatisticsDialog()
    {
      InitializeComponent();
    }

    public void SetMap(Map map, Rules rules)
    {
      hsc1.SetHouse(map, rules, rules.Houses.GetHouse(0));
      hsc2.SetHouse(map, rules, rules.Houses.GetHouse(1));
      hsc3.SetHouse(map, rules, rules.Houses.GetHouse(2));
      hsc4.SetHouse(map, rules, rules.Houses.GetHouse(3));
      hsc5.SetHouse(map, rules, rules.Houses.GetHouse(4));
      hsc6.SetHouse(map, rules, rules.Houses.GetHouse(5));
      hsc7.SetHouse(map, rules, rules.Houses.GetHouse(6));
      hsc8.SetHouse(map, rules, rules.Houses.GetHouse(7));
      hsc9.SetHouse(map, rules, rules.Houses.GetHouse(8));
      hsc10.SetHouse(map, rules, rules.Houses.GetHouse(9));
      hsc11.SetHouse(map, rules, rules.Houses.GetHouse(10));
      hsc12.SetHouse(map, rules, rules.Houses.GetHouse(11));
      hsc13.SetHouse(map, rules, rules.Houses.GetHouse(12));
      hsc14.SetHouse(map, rules, rules.Houses.GetHouse(13));
      hsc15.SetHouse(map, rules, rules.Houses.GetHouse(14));
      hsc16.SetHouse(map, rules, rules.Houses.GetHouse(15));
      hsc17.SetHouse(map, rules, rules.Houses.GetHouse(16));
      hsc18.SetHouse(map, rules, rules.Houses.GetHouse(17));
      hsc19.SetHouse(map, rules, rules.Houses.GetHouse(18));
      hsc20.SetHouse(map, rules, rules.Houses.GetHouse(19));
      hsc21.SetHouse(map, rules, rules.Houses.GetHouse(20));
      hsc22.SetHouse(map, rules, rules.Houses.GetHouse(21));
      hsc23.SetHouse(map, rules, rules.Houses.GetHouse(22));
      hsc24.SetHouse(map, rules, rules.Houses.GetHouse(23));
      hsc25.SetHouse(map, rules, rules.Houses.GetHouse(24));
      hsc26.SetHouse(map, rules, rules.Houses.GetHouse(25));
      hsc27.SetHouse(map, rules, rules.Houses.GetHouse(26));
      hsc28.SetHouse(map, rules, rules.Houses.GetHouse(27));
      hsc29.SetHouse(map, rules, rules.Houses.GetHouse(28));
      hsc30.SetHouse(map, rules, rules.Houses.GetHouse(29));
      hsc31.SetHouse(map, rules, rules.Houses.GetHouse(30));
      hsc32.SetHouse(map, rules, rules.Houses.GetHouse(31));
    }

    private void bClose_Click(object sender, System.EventArgs e)
    {
      Close();
    }
  }
}
