using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Logic
{
  public delegate void OpenFileDelegate(string path);

  public static class RecentFIlesHandler
  {
    private static Keys[] _keys = new Keys[] { Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0 };

    public static void UpdateRecentFileUIList(ToolStripMenuItem menu, List<string> recentFiles, OpenFileDelegate action)
    {
      List<ToolStripItem> tlist = new List<ToolStripItem>();
      foreach (ToolStripItem c in menu.DropDownItems)
      {
        tlist.Add(c);
      }
      menu.DropDownItems.Clear();
      foreach (ToolStripItem c in tlist)
      {
        c.Dispose();
      }

      int index = 0;
      foreach (string s in recentFiles)
      {
        string path = Path.GetFullPath(s);
        ToolStripMenuItem t = new ToolStripMenuItem()
        {
          Text = path,
          Tag = action
        };
        t.Click += RecentFile_Click;
        if (index < _keys.Length)
        {
          t.ShortcutKeys = Keys.Control | _keys[index];
          index++;
        }
        menu.DropDownItems.Add(t);
      }
      menu.Enabled = menu.DropDownItems.Count > 0;
    }

    private static void RecentFile_Click(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem t)
        if (t.Tag != null && t.Tag is OpenFileDelegate action)
        {
          action.Invoke(t.Text);
        }
    }
  }
}
