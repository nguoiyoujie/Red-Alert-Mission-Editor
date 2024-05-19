using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.UI.Logic;
using System;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class GlobalsControl : UserControl
  {
    public GlobalsControl()
    {
      InitializeComponent();
      nudIndex.Maximum = MaxGlobals - 1;
    }

    public Map Map { get; private set; }
    private const int MaxGlobals = Constants.MAX_GLOBALS;

    public void SetMap(Map map)
    {
      Map = map;
      RefreshText();
      RefreshLine();
    }

    public void RefreshView()
    {
      RefreshText();
    }

    private StringBuilder _sb = new StringBuilder();
    private void RefreshText()
    {
      if (Map != null)
      {
        {
          _sb.Clear();
          for (int i = 0; i < MaxGlobals; i++)
          {
            string extkey = Ext_CommentsSection.GlobalsPrefix + i.ToString();
            _sb.Append(i);
            _sb.Append('\t');
            string comment = Map.Ext_CommentsSection.Get(extkey);
            if (!string.IsNullOrEmpty(comment))
            {
              _sb.AppendLine(comment);
            }
            else
            {
              _sb.AppendLine("<none>");
            }
          }
          tbGlobalList.Text = _sb.ToString();
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
        string extkey = Ext_CommentsSection.GlobalsPrefix + i.ToString();
        tbLine.Text = Map.Ext_CommentsSection.Get(extkey);
        DirtyControlsHandler.ResetDirtyColor(this);
      }
    }

    private void nudIndex_ValueChanged(object sender, EventArgs e)
    {
      RefreshLine();
    }

    private void bSet_Click(object sender, EventArgs e)
    {
      string extkey = Ext_CommentsSection.GlobalsPrefix + ((int)nudIndex.Value).ToString();
      GenericCommentSaveAction action = new GenericCommentSaveAction(Map, extkey, tbLine.Text);
      Map.Ext_CommentsSection.Put(extkey, tbLine.Text);
      Map.Dirty = true;
      Map.TrackedActions.Push(action);
      RefreshText();
      RefreshLine();
    }

    private void bDelete_Click(object sender, EventArgs e)
    {
      string extkey = Ext_CommentsSection.GlobalsPrefix + ((int)nudIndex.Value).ToString();
      GenericCommentSaveAction action = new GenericCommentSaveAction(Map, extkey, null);
      Map.Ext_CommentsSection.Remove(extkey);
      Map.Dirty = true;
      Map.TrackedActions.Push(action);
      RefreshText();
      RefreshLine();
    }
  }
}
