using RA_Mission_Editor.FileFormats;
using System;
using System.IO;

namespace RA_Mission_Editor.Common
{
  public static class MixLoading
  {
    public static VirtualFileSystem LoadRAFileSystem(string gamedir)
    {
      VirtualFileSystem vfs = new VirtualFileSystem();
      LoadRAFileSystem(vfs, gamedir);
      return vfs;
    }

    public static void LoadRAFileSystem(VirtualFileSystem vfs, string gamedir)
    {
      if (gamedir == null) gamedir = @".";

      if (!vfs.AddItem(gamedir))
      {
        throw new Exception($"The directory '{gamedir}' does not exist!");
      }

      // load order according to https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/DLLInterfaceEditor.cpp
      // WW files
      LoadFile(vfs, @"MAIN.MIX", true);
      LoadFile(vfs, @"REDALERT.MIX", true);

      // files added by Iran
      LoadFile(vfs, @"CAMPAIGN.MIX");
      LoadFile(vfs, @"AFTERMATH.MIX");
      LoadFile(vfs, @"COUNTERSTRIKE.MIX");
      //LoadFile(vfs, @"MOVIES-TLF.MIX");
      //LoadFile(vfs, @"MOVIES-10.MIX");
      //LoadFile(vfs, @"MOVIES-9.MIX");
      //LoadFile(vfs, @"MOVIES-8.MIX");
      //LoadFile(vfs, @"MOVIES-7.MIX");
      //LoadFile(vfs, @"MOVIES-6.MIX");
      //LoadFile(vfs, @"MOVIES-5.MIX");
      //LoadFile(vfs, @"MOVIES-4.MIX");
      //LoadFile(vfs, @"MOVIES-3.MIX");
      //LoadFile(vfs, @"MOVIES-2.MIX");
      //LoadFile(vfs, @"MOVIES-1.MIX");
      LoadFile(vfs, @"OOS-FIX.MIX");
      LoadFile(vfs, @"EXPAND9.MIX");
      LoadFile(vfs, @"EXPAND8.MIX");
      LoadFile(vfs, @"EXPAND7.MIX");
      LoadFile(vfs, @"EXPAND6.MIX");
      LoadFile(vfs, @"EXPAND5.MIX");
      LoadFile(vfs, @"EXPAND4.MIX");
      LoadFile(vfs, @"EXPAND3.MIX");

      // continue WW files
      LoadFile(vfs, @"EXPAND2.MIX");
      LoadFile(vfs, @"EXPAND.MIX");
      LoadFile(vfs, @"HIRES1.MIX");
      //LoadFile(vfs, @"LORES1.MIX");
      LoadFile(vfs, @"GENERAL.MIX", true);
      LoadFile(vfs, @"LOCAL.MIX", true);
      LoadFile(vfs, @"HIRES.MIX", true);
      //LoadFile(vfs, @"LORES.MIX");
      LoadFile(vfs, @"NCHIRES.MIX");
      LoadFile(vfs, @"CONQUER.MIX");
      LoadFile(vfs, @"RUSSIAN.MIX");
      LoadFile(vfs, @"ALLIES.MIX");

      // theatre files
      LoadFile(vfs, @"SNOW.MIX", true);
      LoadFile(vfs, @"INTERIOR.MIX", true);
      LoadFile(vfs, @"TEMPERAT.MIX", true);

      // new theatre files
      LoadFile(vfs, @"DESERT.MIX");
      LoadFile(vfs, @"WINTER.MIX");
      LoadFile(vfs, @"JUNGLE.MIX");

      LoadFile(vfs, @"CAVE.MIX");
      LoadFile(vfs, @"BARREN.MIX");


      /*
      LoadFile(vfs, @"MOVIES1.MIX");
      LoadFile(vfs, @"MOVIES2.MIX");
      LoadFile(vfs, @"SCORES.MIX");
      LoadFile(vfs, @"SOUNDS.MIX");
      LoadFile(vfs, @"SPEECH.MIX");
      */

      // expansion files
      foreach (string expfile in Directory.EnumerateFiles(gamedir, @"SC*.MIX"))
      {
        LoadFile(vfs, expfile);
      }

      foreach (string expfile in Directory.EnumerateFiles(gamedir, @"SS*.MIX"))
      {
        LoadFile(vfs, expfile);
      }

      // if conquer.eng is present in the root directory, load it as well
      foreach (string cnqfile in Directory.EnumerateFiles(gamedir, @"conquer.eng"))
      {
        LoadFile(vfs, cnqfile);
      }
    }

    private static void LoadFile(VirtualFileSystem vfs, string path, bool required = false, bool extractFiles = false)
    {
      if (!vfs.AddItem(path) && required)
      {
        throw new Exception($"The RA mixfile '{path}' does not exist!");
      }

      if (extractFiles)
      {
        MixFile file = vfs.OpenFile<MixFile>(path);
        if (file != null)
        {
          string dir = @".\cache\mix\" + Path.GetFileNameWithoutExtension(path);
          foreach (string entry in file.FileNames)
          {
            Directory.CreateDirectory(dir);
            // some formats close the handle after reading, using Ukn disallows specific format handling and thus prevents this
            VirtualFile v = file.OpenFile(entry, FileFormat.Ukn); 
            if (!(v is MixFile))
            {
              try
              {
                using (FileStream fs = File.Create(dir + @"\" + entry))
                  v.CopyTo(fs);
              }
              catch
              {
                Console.WriteLine("Failed to extract " + path + @"\" + entry);
              }
            }
          }
        }
      }
    }
  }
}
