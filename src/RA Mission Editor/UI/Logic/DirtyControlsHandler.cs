using System.Drawing;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Logic
{
  public static class DirtyControlsHandler
  {
    private static Color _dirtyForeColor = Color.Red;
    private static Color _normForeColor = Color.Black;

    public static bool IsDirtyColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        if (c.ForeColor == _dirtyForeColor || IsDirtyColor(c))
          return true;
      }
      return false;
    }

    public static void ResetDirtyColor(Control f)
    {
      foreach (Control c in f.Controls)
      {
        c.ForeColor = _normForeColor;
        ResetDirtyColor(c);
      }
    }

    public static void SetDirtyColor(Control f)
    {
      f.ForeColor = _dirtyForeColor;
      if (f.Tag is Control d)
      {
        d.ForeColor = _dirtyForeColor;
      }
    }
  }
}
