using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class NewIniKeyDialog : Form
  {
    public NewIniKeyDialog()
    {
      InitializeComponent();
    }

    public List<string> ForbiddenKeys;
    public string Key;
    public string Value;

    private void bOK_Click(object sender, EventArgs e)
    {
      Key = tbKey.Text;
      Value = tbValue.Text;
      if (ForbiddenKeys != null && ForbiddenKeys.Contains(Key))
      {
        MessageBox.Show($"The key '{Key}' already exists!\nPlease enter a unique key name.");
        return;
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void tbKey_TextChanged(object sender, EventArgs e)
    {
      string text = tbKey.Text;
      int index = text.IndexOf('=');
      if (index > -1)
      {
        tbKey.Text = text.Substring(0, index);
        tbValue.Text = text.Substring(index + 1, text.Length - index - 1);
      }
    }

    private void NewIniKeyDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = tbKey;
    }
  }
}
