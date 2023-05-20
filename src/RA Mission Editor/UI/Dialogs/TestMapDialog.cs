using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class TestMapDialog : Form
  {
    public TestMapDialog()
    {
      InitializeComponent();
    }

    public enum DifficultyChoice { EASY, NORMAL, HARD }

    public DifficultyChoice Difficulty;

    private void bOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Difficulty = rbEasy.Checked ? DifficultyChoice.EASY : rbHard.Checked ? DifficultyChoice.HARD : DifficultyChoice.NORMAL;
      Close();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void TestMapDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = rbNormal;
    }
  }
}
