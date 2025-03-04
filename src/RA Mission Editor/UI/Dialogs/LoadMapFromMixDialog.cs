using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class LoadMapFromMixDialog : Form
  {
    public LoadMapFromMixDialog()
    {
      InitializeComponent();
    }

    public class Entry
    {
      public string DisplayName;
      public string Filename;

      public Entry(string displayName, string filename)
      {
        DisplayName = displayName;
        Filename = filename;
      }

      public override string ToString()
      {
        return DisplayName;
      }
    }

    public string Filename;

    public void FetchMapList(VirtualFileSystem filesystem)
    {
      listViewFiles.Items.Clear();
      if (filesystem == null) { return; }

      List<Entry> entries = new List<Entry>(256);
      // search all mixes for possible maps
      foreach (IArchive arch in filesystem.AllArchives)
      {
        if (arch is MixFile mixf)
        {
          AppendList(entries, mixf);
        }
      }

      listViewFiles.Items.AddRange(entries.ToArray());
    }

    private void AppendList(List<Entry> entries, MixFile mix)
    {
      foreach (string fname in mix.FileNames)
      {
        FileFormat fmt = FormatHelper.GuessFormat(fname);
        switch (fmt)
        {
          case FileFormat.Ini:
            IniFile ini = mix.OpenFile(fname, FileFormat.Ini) as IniFile;
            string name = ini.GetSection("Basic")?.ReadString("Name");
            string player = ini.GetSection("Basic")?.ReadString("Player");
            string theater = ini.GetSection("Map")?.ReadString("Theater");
            int w = ini.GetSection("Map")?.ReadInt("Width", 0) ?? 0;
            int h = ini.GetSection("Map")?.ReadInt("Height", 0) ?? 0;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(theater))
            {
              string desc = fname + ": \t" + name.PadRight(60) + "\t " + player + "\t [" + w + " x " + h + " " + theater[0] + theater.Substring(1).ToLowerInvariant() + "]";
              entries.Add(new Entry(desc, fname));
            }

            break;
            // Not required since AllArchives include mixes within mixes. Also, that would cause a crash trying to load the same mix contents twice
            //case FileFormat.Mix:
            //  MixFile mix2 = mix.OpenFile(fname, FileFormat.Mix) as MixFile;
            //  if (mix != null)
            //  {
            //    AppendList(entries, mix2);
            //  }
            //  break;
        }
      }
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      Filename = null;
      if (listViewFiles.SelectedItem is Entry entry)
      {
        Filename = entry.Filename;
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bClose_Click(object sender, EventArgs e)
    {
      Filename = null;
      Close();
    }

    private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      bOK.Enabled = listViewFiles.SelectedItem is Entry entry;
    }
  }
}
