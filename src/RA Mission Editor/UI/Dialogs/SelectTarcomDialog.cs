using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class SelectTarcomDialog : Form
  {
    public SelectTarcomDialog()
    {
      InitializeComponent();
      cbRTTI.DropDownStyle = ComboBoxStyle.DropDownList;
      cbRTTI.Items.AddRange(Enum.GetNames(typeof(RTTIType)));
    }

    public int Target;

    public void Set(int target)
    {
      if (target < 0) { return; }
      
      cbRTTI.SelectedIndex = Math.Min(cbRTTI.Items.Count, (target / (1 << 24)) & 0xFF);
      nudID.Value = target % (1 << 24);
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      if (cbRTTI.SelectedIndex < 0)
      {
        Target = GetTarget(0, (int)nudID.Value);
      }
      else
      {
        Target = GetTarget((byte)cbRTTI.SelectedIndex, (int)nudID.Value);
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void NewIniKeyDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = cbRTTI;
    }

    private int GetTarget(byte rttitype, int id)
    {
      return (rttitype << 24) + id;
    }
  }
}
