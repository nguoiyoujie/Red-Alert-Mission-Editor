using RA_Mission_Editor.MapData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class VerifyDialog : Form
  {
    public VerifyDialog()
    {
      InitializeComponent();
    }

    public void VerifyMap(Map map) 
    {
      List<string> errors = new List<string>(128);
      map.VerifyMap(errors);
      listViewErrors.Items.Clear();
      foreach (string error in errors)
      {
        listViewErrors.Items.Add(error);
      }
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
