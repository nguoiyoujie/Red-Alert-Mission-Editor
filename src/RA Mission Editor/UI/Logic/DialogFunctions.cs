using RA_Mission_Editor.UI.Dialogs;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Logic
{
  public static class DialogFunctions
  {
    public static EditorDialog GetEditorDialog()
    {
      foreach (Form f in Application.OpenForms)
      {
        if (f is EditorDialog d)
        {
          return d;
        }
      }
      return null;
    }
  }
}
