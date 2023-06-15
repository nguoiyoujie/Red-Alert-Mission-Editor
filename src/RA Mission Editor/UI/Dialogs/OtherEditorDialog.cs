using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class OtherEditorDialog : Form
  {
    public OtherEditorDialog()
    {
      InitializeComponent();
    }

    private void tabSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshTab();
    }

    private void RefreshTab()
    { 
      if (tabSelection.SelectedTab == pageLanguageFile)
      {
        //ttControl_Basic.ResetList();
      }
    }
  }
}
