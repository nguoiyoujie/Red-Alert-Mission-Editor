using RA_Mission_Editor.UI;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      // first argument would be path
      string filePath = null;
      if (args.Length > 0)
      {
        filePath = args[0];
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainEditor editor = new MainEditor();
      editor.InitialFilePath = filePath;
      Application.Run(editor);
    }
  }
}
