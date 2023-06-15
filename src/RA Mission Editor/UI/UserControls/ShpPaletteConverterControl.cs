using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.UI.Logic;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class ShpPaletteConverterControl : UserControl
  {
    public ShpPaletteConverterControl()
    {
      InitializeComponent();
      cbRemapColor.Items.AddRange(Enum.GetNames(typeof(ColorType)));
      cbRemapColor.SelectedIndex = 0;

      for (int i = 0; i < 256; i++)
      {
        if (!DefaultHouseColorIndex.Contains(i))
        {
          ExcludeHouseColorIndex.Add(i);
        }
      }

      RefreshView();
    }

    private MapCache _cache = new MapCache();
    private ShpFile _shp;
    private PalFile _palSrc;
    private ShpFile _shpConverted;
    private PalFile _palDst;

    static List<int> DefaultExcludeIndex = new List<int>{ 0, 1, 2, 3, 4 }; // transparent and shadows
    static List<int> DefaultHouseColorIndex = new List<int> { 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95 };
    static List<int> DefaultTDHouseColorIndex = new List<int> { 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191 };
    static List<int> ExcludeHouseColorIndex = new List<int> { };

    public void SetShpFile(ShpFile shp)
    {
      _shp = shp;
      _cache.Clear();
      nudFrameSrc.Maximum = Math.Max(1, (int)_shp.NumImages);
      nudFrameDst.Maximum = Math.Max(1, (int)_shp.NumImages);
      Convert();
      RefreshView();
    }

    public void SetSourcePalette(PalFile pal)
    {
      _palSrc = pal;
      _cache.Clear();
      Convert();
      RefreshView();
    }

    public void SetDestinationPalette(PalFile pal)
    {
      _palDst = pal;
      _cache.Clear();
      Convert();
      RefreshView();
    }

    public void RefreshView()
    {
      ColorType color = ColorType.YELLOW;
      Enum.TryParse(cbRemapColor.Text, out color);

      if (_shp != null && _palSrc != null)
      {
        PalFile phSrc = RenderUtils.FetchHouseRemapPalette(_cache, _palSrc, color);
        pbSrc.BackgroundImage = RenderUtils.RenderShp(_cache, _shp, phSrc, (int)(nudFrameSrc.Value - 1));
      }
      else
      {
        pbSrc.BackgroundImage = null;
      }

      if (_shpConverted != null && _palDst != null)
      {
        PalFile phDst = RenderUtils.FetchHouseRemapPalette(_cache, _palDst, color);
        pbDst.BackgroundImage = RenderUtils.RenderShp(_cache, _shpConverted, phDst, (int)(nudFrameDst.Value - 1));
      }
      else
      {
        pbDst.BackgroundImage = null;
      }

      lblSrcShp.Text = _shp?.FileName;
      lblSrcPal.Text = _palSrc?.FileName;
      lblDstPal.Text = _palDst?.FileName;
    }


    public void Convert()
    {
      if (_shp != null && _palSrc != null && _palDst != null)
      {
        try
        {
          MemoryStream inMemoryCopy = new MemoryStream();
          //_shp.CopyTo(inMemoryCopy);
          ShpFile convert = new ShpFile(inMemoryCopy, _shp.FileName, _shp.BaseOffset, (int)_shp.Size, false);
          convert.Width = _shp.Width;
          convert.Height = _shp.Height;

          List<int> exclude = new List<int>(DefaultExcludeIndex);
          if (cbPreserveHouseColors.Checked)
          {
            exclude.AddRange(DefaultHouseColorIndex);
          }

          Dictionary<int, int> remap = new Dictionary<int, int>();
          convert.Images = new List<ShpFile.ShpImage>(_shp.NumImages);
          for (int n = 0; n < _shp.NumImages; n++)
          {
            convert.Images.Add(new ShpFile.ShpImage() { Image = new byte[_shp.Images[n].Image.Length] });
            if (_shp.Images[n].Image != null)
            {
              for (int i = 0; i < _shp.Images[n].Image.Length; i++)
              {
                int src = _shp.Images[n].Image[i];
                if (DefaultExcludeIndex.Contains(src))
                {
                  continue;
                }
                else if (cbPreserveHouseColors.Checked)
                {
                  if ((!cbPalSrcTD.Checked && DefaultHouseColorIndex.Contains(src)) || (cbPalSrcTD.Checked && DefaultTDHouseColorIndex.Contains(src)))
                  {
                    convert.Images[n].Image[i] = (byte)_palDst.ClosestIndex(_palSrc.GetColor(src), ExcludeHouseColorIndex);
                  }
                  else
                  {
                    convert.Images[n].Image[i] = (byte)_palDst.ClosestIndex(_palSrc.GetColor(src), exclude);
                  }
                }
                else
                {
                  convert.Images[n].Image[i] = (byte)_palDst.ClosestIndex(_palSrc.GetColor(src), exclude);
                }
              }
            }
          }
          _shpConverted = convert;
        }
        catch
        {
          _shpConverted = null;
        }
      }
      else
      {
        _shpConverted = null;
      }
    }

    private void bLoadShp_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Open SHP File",
        Filter = "SHP file|*.shp|All files (*.*)|*.*",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          VirtualFileSystem vfs = new VirtualFileSystem();
          vfs.AddItem(Path.GetDirectoryName(ofd.FileName));

          ShpFile shp = vfs.OpenFile<ShpFile>(Path.GetFileName(ofd.FileName), BufferingMode.None);
          SetShpFile(shp);
        }
        catch
        {
          MessageBox.Show("An error has occurred in attempting to load the SHP file");
        }
      }
    }

    private void bLoadSrcPalette_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Open Palette File",
        Filter = "Palette file|*.pal|All files (*.*)|*.*",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          VirtualFileSystem vfs = new VirtualFileSystem();
          vfs.AddItem(Path.GetDirectoryName(ofd.FileName));

          PalFile pal = vfs.OpenFile<PalFile>(Path.GetFileName(ofd.FileName));
          SetSourcePalette(pal);
        }
        catch
        {
          MessageBox.Show("An error has occurred in attempting to load the palette file");
        }
      }
    }

    private void bLoadDestPal_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Open Palette File",
        Filter = "Palette file|*.pal|All files (*.*)|*.*",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          VirtualFileSystem vfs = new VirtualFileSystem();
          vfs.AddItem(Path.GetDirectoryName(ofd.FileName));

          PalFile pal = vfs.OpenFile<PalFile>(Path.GetFileName(ofd.FileName));
          SetDestinationPalette(pal);
        }
        catch
        {
          MessageBox.Show("An error has occurred in attempting to load the palette file");
        }
      }
    }

    private void bSave_Click(object sender, EventArgs e)
    {
      if (_shpConverted != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save SHP File",
          Filter = "SHP file|*.shp|All files (*.*)|*.*"
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          _shpConverted.Save(sfd.FileName);
      }
      }
    }

    private void nudFrameSrc_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void nudFrameDst_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void cbRemapColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void cbPalSrcTD_CheckedChanged(object sender, EventArgs e)
    {
      Convert();
      RefreshView();
    }

    private void cbPreserveHouseColors_CheckedChanged(object sender, EventArgs e)
    {
      Convert();
      RefreshView();
    }
  }
}
