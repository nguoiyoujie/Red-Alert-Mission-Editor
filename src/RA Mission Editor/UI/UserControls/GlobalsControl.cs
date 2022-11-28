﻿using RA_Mission_Editor.MapData;
using System;
using System.Drawing;
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
    private const int MaxGlobals = 30;

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
        return IsDirtyColor(this);
      }
    }

    public bool IsDirtyColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        if (c.ForeColor == Color.Red || IsDirtyColor(c))
          return true;
      }
      return false;
    }

    public void ResetColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        c.ForeColor = Color.Black;
        ResetColor(c);
      }
    }

    private void Value_Changed(object sender, EventArgs e)
    {
      if (sender is Control c)
      {
        c.ForeColor = Color.Red;
        if (c.Tag is Control d)
        {
          d.ForeColor = Color.Red;
        }
      }
    }

    private void RefreshLine()
    {
      if (Map != null)
      {
        int i = (int)nudIndex.Value;
        string extkey = Ext_CommentsSection.GlobalsPrefix + i.ToString();
        tbLine.Text = Map.Ext_CommentsSection.Get(extkey);
        ResetColor(this);
      }
    }

    private void nudIndex_ValueChanged(object sender, EventArgs e)
    {
      RefreshLine();
    }

    private void bSet_Click(object sender, EventArgs e)
    {
      string extkey = Ext_CommentsSection.GlobalsPrefix + ((int)nudIndex.Value).ToString();
      Map.Ext_CommentsSection.Put(extkey, tbLine.Text);
      Map.Dirty = true;
      RefreshText();
      RefreshLine();
    }

    private void bDelete_Click(object sender, EventArgs e)
    {
      string extkey = Ext_CommentsSection.GlobalsPrefix + ((int)nudIndex.Value).ToString();
      Map.Ext_CommentsSection.Remove(extkey);
      Map.Dirty = true;
      RefreshText();
      RefreshLine();
    }
  }
}
