using RA_Mission_Editor.FileFormats;
using System;
using System.IO;

namespace RA_Mission_Editor
{
  public static class Globals
  {
    public static ShpFile UnknownObjectShp;
    public static XccLocalDatabase XCCGlobalDatabase;

    static Globals()
    {
      // UnknownObjectShp
      if (File.Exists(Constants.UnknownObjectSHPLocation))
      {
        VirtualFileSystem tempVfs = new VirtualFileSystem();
        tempVfs.AddItem(Path.GetDirectoryName(Constants.UnknownObjectSHPLocation));
        using (ShpFile f = tempVfs.OpenFile<ShpFile>(Path.GetFileName(Constants.UnknownObjectSHPLocation)))
        {
          UnknownObjectShp = f;
        }
      }

      // XCCGlobalDatabase
      if (File.Exists(Constants.XCCGlobalXCCDatabaseLocation))
      {
        VirtualFileSystem tempVfs = new VirtualFileSystem();
        tempVfs.AddItem(Path.GetDirectoryName(Constants.XCCGlobalXCCDatabaseLocation));
        using (VirtualFile f = tempVfs.OpenFile<VirtualFile>(Path.GetFileName(Constants.XCCGlobalXCCDatabaseLocation)))
        {
          try
          { 
          XCCGlobalDatabase = new XccLocalDatabase(f.BaseStream, false);
          }
          catch (Exception e)
          {
            Console.WriteLine("Failed to read xcc global database: " + e.Message + "\n" + e.StackTrace);
          }
        }
      }
    }
  }
}
