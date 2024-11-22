using Ookii.Dialogs.WinForms;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class AssetExporterControl : UserControl
  {
    public AssetExporterControl()
    {
      InitializeComponent();
    }

    private MainModel _model;

    public void ExportTmp(string dirpath)
    {
      Directory.CreateDirectory(dirpath); 
      if (_model != null)
      {
        foreach (var theater in Theaters.GetTheaters())
        {
          string dirttpath = Path.Combine(dirpath, theater.Name);
          Directory.CreateDirectory(dirttpath);
          string tpal = theater.ShortName + ".pal";
          _model.Cache.GetOrOpen(tpal, _model.GameFileSystem, out PalFile palFile);
          {
            foreach (var template in Templates.GetAll())
            {
              string name = template.ID + theater.Extension;
              _model.Cache.GetOrOpen(name, _model.GameFileSystem, out TmpFile tmpFile);
              if (tmpFile != null)
              {
                tmpFile.Save(Path.Combine(dirttpath, name));
                if (palFile != null)
                {
                  Bitmap bmp = RenderUtils.RenderTemplate(_model.Cache, tmpFile, palFile);
                  if (bmp != null)
                  {
                    bmp.Save(Path.Combine(dirttpath, template.ID + ".PNG"));
                  }
                }
              }
            }
          }
        }
      }
    }

    private List<string> GetShpIDs()
    {
      List<string> list = new List<string>(2048);
      foreach (var t in Terrains.GetAll())
      {
        list.Add(t.ID);
      }
      foreach (var o in Overlays.GetAll())
      {
        list.Add(o.ID);
      }
      if (_model != null && _model.CurrentMap != null)
      {
        foreach (var i in _model.CurrentMap.AttachedRules.Buildings.GetAll())
        {
          list.Add(i.ID);
          list.Add(i.ID + "MAKE");
          list.Add(i.ID + "ICON");
          if (i.SecondImage != null)
          {
            list.Add(i.SecondImage);
          }
        }
        foreach (var i in _model.CurrentMap.AttachedRules.Infantries.GetAll())
        {
          list.Add(i.ID);
          list.Add(i.ID + "ICON");
        }
        foreach (var i in _model.CurrentMap.AttachedRules.Units.GetAll())
        {
          list.Add(i.ID);
          list.Add(i.ID + "ICON");
        }
        foreach (var i in _model.CurrentMap.AttachedRules.Aircrafts.GetAll())
        {
          list.Add(i.ID);
          list.Add(i.ID + "ICON");
        }
        foreach (var i in _model.CurrentMap.AttachedRules.Vessels.GetAll())
        {
          list.Add(i.ID);
          list.Add(i.ID + "ICON");
          if (i.TurretName != null)
          {
            list.Add(i.TurretName);
          }
        }
      }
      return list.Distinct().ToList();
    }

    public void ExportShp(string dirpath)
    {
      Directory.CreateDirectory(dirpath);
      if (_model != null)
      {
        List<string> shpids = GetShpIDs();
        // theater 'shps'
        foreach (var theater in Theaters.GetTheaters())
        {
          string dirttpath = Path.Combine(dirpath, theater.Name);
          Directory.CreateDirectory(dirttpath);
          string tpal = theater.ShortName + ".pal";
          _model.Cache.GetOrOpen(tpal, _model.GameFileSystem, out PalFile tpalFile);
          {
            foreach (var id in shpids)
            {
              string name = id + theater.Extension;
              _model.Cache.GetOrOpen(name, _model.GameFileSystem, out ShpFile shpFile);
              if (shpFile != null)
              {
                shpFile.Save(Path.Combine(dirttpath, name));
                if (tpalFile != null)
                {
                  for (int i = 0; i < shpFile.NumImages; i++)
                  {
                    Bitmap bmp = RenderUtils.RenderShp(_model.Cache, shpFile, tpalFile, i);
                    if (bmp != null)
                    {
                      bmp.Save(Path.Combine(dirttpath, id + string.Format("_{0:0000}.PNG", i)));
                    }
                  }
                }
              }
            }
          }
        }
        // pure shps
        string dirnpath = Path.Combine(dirpath, "SHP");
        Directory.CreateDirectory(dirnpath);
        _model.Cache.GetOrOpen("TEMPERAT.PAL", _model.GameFileSystem, out PalFile palFile);
        {
          foreach (var id in shpids)
          {
            string name = id + ".SHP";
            _model.Cache.GetOrOpen(name, _model.GameFileSystem, out ShpFile shpFile);
            if (shpFile != null)
            {
              shpFile.Save(Path.Combine(dirnpath, name));
              if (palFile != null)
              {
                for (int i = 0; i < shpFile.NumImages; i++)
                {
                  Bitmap bmp = RenderUtils.RenderShp(_model.Cache, shpFile, palFile, i);
                  if (bmp != null)
                  {
                    bmp.Save(Path.Combine(dirnpath, id + string.Format("_{0:0000}.PNG", i)));
                  }
                }
              }
            }
          }
        }
      }
    }

    public void ExtractMix(string dirpath, MixFile mix, bool includeUnidentifiedFiles)
    {
      Directory.CreateDirectory(Path.Combine(dirpath, Path.GetFileNameWithoutExtension(mix.FileName)));
      foreach (MixFile.MixEntry mentry in mix.Index.Values)
      {
        string filename = includeUnidentifiedFiles ? mentry.Hash.ToString("X8") : null;
        foreach (string fss in mix.FileNames)
        {
          if (MixFile.MixEntry.HashFilename(fss) == mentry.Hash)
          {
            filename = fss;
            break;
          }
        }
        if (filename != null)
        {
          Stream s = mix.GetContent(mentry);
          using (FileStream fs = File.Create(Path.Combine(dirpath, Path.GetFileNameWithoutExtension(mix.FileName), filename), (int)s.Length, FileOptions.SequentialScan))
          {
            s.CopyTo(fs);
          }
        }
      }
    }

    public void SetModel(MainModel model)
    {
      _model = model;
      cbExportMixList.Items.Clear();
      if (_model != null)
      {
        foreach (IArchive mix in _model.GameFileSystem.AllArchives)
        {
          if (mix is MixFile)
          {
            cbExportMixList.Items.Add(mix);
          }
        }
      }
    }

    private async void bExportShps_Click(object sender, EventArgs e)
    {
      VistaFolderBrowserDialog sfd = new VistaFolderBrowserDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        await Task.Factory.StartNew(() => ExportShp(sfd.SelectedPath));
        MessageBox.Show("SHP files extracted!");
      }
    }

    private async void bExportTmps_Click(object sender, EventArgs e)
    {
      VistaFolderBrowserDialog sfd = new VistaFolderBrowserDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        await Task.Factory.StartNew(() => ExportTmp(sfd.SelectedPath));
        MessageBox.Show("TMP files extracted!");
      }
    }

    private async void bExportMix_Click(object sender, EventArgs e)
    {
      if (cbExportMixList.SelectedItem is MixFile mix)
      {
        VistaFolderBrowserDialog sfd = new VistaFolderBrowserDialog();
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          await Task.Factory.StartNew(() => ExtractMix(sfd.SelectedPath, mix, cboxExportMixWithHashNames.Checked));
          MessageBox.Show("Files extracted!");
        }
      }
    }

    private void bExportMixPath_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Filter = "Mix file|*.mix|All files (*.*)|*.*"
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        tbExportMixPath.Text = ofd.FileName;
      }  
    }

    private async void bExportMixExt_Click(object sender, EventArgs e)
    {
      try
      {
        string path = tbExportMixPath.Text;
        if (File.Exists(path))
        {
          MixFile mix = new MixFile(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read), Path.GetFileName(path));
          VistaFolderBrowserDialog sfd = new VistaFolderBrowserDialog();
          if (sfd.ShowDialog() == DialogResult.OK)
          {
            await Task.Factory.StartNew(() => ExtractMix(sfd.SelectedPath, mix, cboxExportMixPathWithHashNames.Checked));
            MessageBox.Show("Files extracted!");
          }
        }
        else   
        {
          MessageBox.Show("File does not exist!");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error reading file!" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
      }
    }
  }
}
