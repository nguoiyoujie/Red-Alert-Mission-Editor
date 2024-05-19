using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class OtherEditorDialog : Form
  {
    public OtherEditorDialog(MainEditor form)
    {
      InitializeComponent();
      Form = form;
    }

    public MainEditor Form { get; }


    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (base.ProcessCmdKey(ref msg, keyData))
      {
        return true;
      }
      return Form?.ProcessCmdKeyFromChildForm(ref msg, keyData) ?? false;
    }

    private void tabSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshTab();
    }

    public void SetModel(MainModel model)
    {
      languageFileControl1.SetModel(model);
      shpPaletteConverterControl1.SetModel(model);
      tmpFileViewerControl1.SetModel(model);
    }

    private void RefreshTab()
    { 
      if (pageTmpViewer.SelectedTab == pageLanguageFile)
      {
        //ttControl_Basic.ResetList();
      }
    }
  }
}
