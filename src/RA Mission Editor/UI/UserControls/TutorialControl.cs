using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.UI.Logic;
using System;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TutorialControl : UserControl
  {
    public TutorialControl()
    {
      InitializeComponent();
      nudIndex.Maximum = MaxTutorials;
    }

    public Map Map { get; private set; }
    private const int MaxTutorials = 1028;

    public void SetMap(Map map)
    {
      Map = map;
      RefreshText();
      RefreshLine();
      RefreshEditable();
    }

    public void RefreshEditable()
    {
      if (Map == null)
      {
        tbLine.Enabled = false;
        bSet.Enabled = false;
        bDelete.Enabled = false;
        nudIndex.Enabled = false;
        tbLine.Text = string.Empty;
      }
      else
      {
        if (!Map.BasicSection.UseCustomTutorialText.Value)
        {
          tbLine.Enabled = false;
          bSet.Enabled = false;
          bDelete.Enabled = false;
          nudIndex.Enabled = false;
          tbLine.Text = "[Basic] UseCustomTutorialText is not set; strings from conquer.eng";
          DirtyControlsHandler.ResetDirtyColor(this);
        }
        else
        {
          tbLine.Enabled = true;
          bSet.Enabled = true;
          bDelete.Enabled = true;
          nudIndex.Enabled = true;
        }
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
      if (Map != null)
      {
        if (Map.BasicSection.UseCustomTutorialText.Value)
        {
          _sb.Clear();
          for (int i = 1; i <= MaxTutorials; i++)
          {
            _sb.Append(i);
            _sb.Append('\t');
            if (Map.TutorialSection.Messages.ContainsKey(i))
            {
              _sb.AppendLine(Map.TutorialSection.Messages[i]);
            }
            else
            {
              _sb.AppendLine("<none>");
            }
          }
          tbTutorialList.Text = _sb.ToString();
        }
        else
        {
          _sb.Clear();
          if (Map.AttachedRules.LanguageText != null)
          {
            int max = Map.AttachedRules.LanguageText.Count;
            for (int i = 1; i <= max; i++)
            {
              _sb.Append(i);
              _sb.Append('\t');
              _sb.AppendLine(Map.AttachedRules.LanguageText.Get(i));
            }
          }
          tbTutorialList.Text = _sb.ToString();
        }
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
      if (Map != null)
      {
        int i = (int)nudIndex.Value;
        if (Map.TutorialSection.Messages.ContainsKey(i))
        {
          tbLine.Text = Map.TutorialSection.Messages[i];
        }
        else
        {
          tbLine.Text = string.Empty;
        }
        DirtyControlsHandler.ResetDirtyColor(this);
      }
    }

    private void nudIndex_ValueChanged(object sender, EventArgs e)
    {
      RefreshLine();
    }

    private void bSet_Click(object sender, EventArgs e)
    {
      Map.TutorialSection.Messages[(int)nudIndex.Value] = tbLine.Text;
      Map.Dirty = true;
      RefreshText();
      RefreshLine();
    }

    private void bDelete_Click(object sender, EventArgs e)
    {
      if (Map.TutorialSection.Messages.ContainsKey((int)nudIndex.Value))
      {
        Map.TutorialSection.Messages.Remove((int)nudIndex.Value);
        Map.Dirty = true;
      }
      RefreshText();
      RefreshLine();
    }
  }
}
