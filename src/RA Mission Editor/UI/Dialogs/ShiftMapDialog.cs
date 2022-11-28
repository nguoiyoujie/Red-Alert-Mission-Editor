using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class ShiftMapDialog : Form
  {
    public ShiftMapDialog()
    {
      InitializeComponent();
    }

    public int ShiftX = 0;
    public int ShiftY = 0;

    private void bCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      // shifting requires a rebuild of the occupancy list. Let's have the caller code do that.
      DialogResult = DialogResult.OK;
      ShiftX = (int)nudX.Value;
      ShiftY = (int)nudY.Value;
      Close();
    }
  }
}
