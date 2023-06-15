using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.UI.Logic;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class LanguageFileControl : UserControl
  {
    public LanguageFileControl()
    {
      InitializeComponent();
      nudIndex.Maximum = 1028;
      RefreshEditable();
    }

    public LanguageFile LanguageFile { get; private set; }

    public void SetLanguageFile(LanguageFile lang)
    {
      LanguageFile = lang;
      RefreshText();
      RefreshLine();
      RefreshEditable();
    }

    public void RefreshEditable()
    {
      if (LanguageFile == null)
      {
        tbLine.Enabled = false;
        bSet.Enabled = false;
        bDelete.Enabled = false;
        nudIndex.Enabled = false;
        tbLine.Text = string.Empty;
      }
      else
      {
        tbLine.Enabled = true;
        bSet.Enabled = true;
        bDelete.Enabled = true;
        nudIndex.Enabled = true;
      }
    }

    public void RefreshView()
    {
      RefreshText();
      RefreshEditable();
    }

    private StringBuilder _sb = new StringBuilder();
    private void RefreshText()
    {
      if (LanguageFile != null)
      {
        _sb.Clear();
        for (int i = 1; i <= LanguageFile.Count; i++)
        {
          _sb.Append(i);
          _sb.Append('\t');
          _sb.AppendLine(LanguageFile.Get(i) ?? string.Empty);
        }
        tbTutorialList.Text = _sb.ToString();
      }
    }

    public bool IsDirty
    {
      get
      {
        return DirtyControlsHandler.IsDirtyColor(this);
      }
    }

    private void Value_Changed(object sender, EventArgs e)
    {
      if (sender is Control c)
      {
        DirtyControlsHandler.SetDirtyColor(c);
      }
    }

    private void RefreshLine()
    {
      if (LanguageFile != null)
      {
        int i = (int)nudIndex.Value;
        tbLine.Text = LanguageFile.Get(i) ?? string.Empty;
        DirtyControlsHandler.ResetDirtyColor(this);
      }
    }

    private void nudIndex_ValueChanged(object sender, EventArgs e)
    {
      RefreshLine();
    }

    private void bSet_Click(object sender, EventArgs e)
    {
      LanguageFile?.Set((int)nudIndex.Value, tbLine.Text);
      RefreshText();
      RefreshLine();
    }

    private void bDelete_Click(object sender, EventArgs e)
    {
      LanguageFile?.Set((int)nudIndex.Value, string.Empty);
      RefreshText();
      RefreshLine();
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Open Language File",
        Filter = "English language file|*.eng|All files (*.*)|*.*",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          VirtualFileSystem vfs = new VirtualFileSystem();
          vfs.AddItem(Path.GetDirectoryName(ofd.FileName));

          LanguageFile lang = vfs.OpenFile<LanguageFile>(Path.GetFileName(ofd.FileName));
          SetLanguageFile(lang);
        }
        catch
        {
          MessageBox.Show("An error has occurred in attempting to load the language file");
        }
      }
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      if (LanguageFile != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save Language File",
          Filter = "English language file|*.eng|All files (*.*)|*.*",
          CheckFileExists = true
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          LanguageFile.Save(sfd.FileName);
      }
      }
    }
  }
}
