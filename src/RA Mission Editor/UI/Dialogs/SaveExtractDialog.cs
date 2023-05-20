using System;
using System.IO;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class SaveExtractDialog : Form
  {
    public SaveExtractDialog()
    {
      InitializeComponent();
    }

    public string Key;

    private void bOK_Click(object sender, EventArgs e)
    {
      Key = tbKey.Text;
      if (Key.Length == 0)
      {
        MessageBox.Show($"Please enter a name.");
        return;
      }
      else
      {
        foreach (char c in Path.GetInvalidFileNameChars())
        {
          if (Key.Contains(c.ToString()))
          {
            MessageBox.Show($"Invalid character '{c}' detected. Please enter a different name.");
            return;
          }
        }
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void SaveExtractDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = tbKey;
    }
  }
}
