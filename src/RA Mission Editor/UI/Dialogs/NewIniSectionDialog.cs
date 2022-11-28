using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class NewIniSectionDialog : Form
  {
    public NewIniSectionDialog()
    {
      InitializeComponent();
    }

    public List<string> ForbiddenKeys;
    public string Section;

    private void bOK_Click(object sender, EventArgs e)
    {
      Section = tbHeader.Text;
      if (ForbiddenKeys != null && ForbiddenKeys.Contains(Section))
      {
        MessageBox.Show($"The section '{Section}' already exists!\nPlease enter a unique section header name.");
        return;
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
