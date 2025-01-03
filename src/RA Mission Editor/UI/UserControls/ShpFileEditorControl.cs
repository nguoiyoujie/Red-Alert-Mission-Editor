using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class ShpFileEditorControl : UserControl
  {
    public ShpFileEditorControl()
    {
      InitializeComponent();
      cbRemapColor.Items.AddRange(Enum.GetNames(typeof(ColorType)));
      cbRemapColor.SelectedIndex = 0;

      RefreshView();
    }

    private MainModel _model;
    private MapCache _cache = new MapCache();
    private ShpFile _shp;
    private PalFile _palSrc;
    private Bitmap _palSrcbmp;

    private Dictionary<Color, int> _cacheDefault = new Dictionary<Color, int>();
    //static List<int> DefaultExcludeIndex = new List<int> { 0, 1, 2, 3, 4, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95 }; // 0-4 transparent and shadows, 80-95 house remaps

    public void SetModel(MainModel model)
    {
      _model = model;
    }

    public void SetShpFile(ShpFile shp)
    {
      // set a copy of the file
      if (shp != null)
      {
        byte[] data = new byte[(int)shp.Size];
        shp.Position = 0; // tmp.BaseOffset;
        shp.Read(data, 0, data.Length);
        MemoryStream inMemoryCopy = new MemoryStream(data);
        _shp = new ShpFile(inMemoryCopy, shp.FileName, 0, (int)shp.Size, false);
        nudImage.Maximum = Math.Max(1, _shp.Images.Count);
        lblBlocks.Text = "Frames: " + _shp.Images.Count;
      }
      else
      {
        _shp = null;
      }
      _cache.Clear();
      RefreshView();
    }

    public void SetSourcePalette(PalFile pal)
    {
      if (pal != null)
      {
        byte[] data = new byte[(int)pal.Size];
        pal.Position = 0; // tmp.BaseOffset;
        pal.Read(data, 0, data.Length);
        MemoryStream inMemoryCopy = new MemoryStream(data);
        _palSrc = new PalFile(inMemoryCopy, pal.FileName, 0, (int)pal.Size, false);
        _palSrc.Parse(false);
      }
      else
      {
        _palSrc = null;
      }
      using (Bitmap bmp = pal?.GenerateColorPreview())
      {
        if (bmp != null)
        {
          if (_palSrcbmp == null || _palSrcbmp.Width != pbSrc.Width || _palSrcbmp.Height != pbSrc.Height)
          {
            _palSrcbmp = new Bitmap(pbSrc.Width, pbSrc.Height);
          }
          using (Graphics g = Graphics.FromImage(_palSrcbmp))
          {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            Rectangle rd = new Rectangle(0, 0, _palSrcbmp.Width, _palSrcbmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
          }
        }
      }

      _cache.Clear();
      RefreshView();
    }

    public void RefreshImageCount()
    {
      if (_shp != null)
      {
        nudImage.Maximum = Math.Max(1, _shp.Images.Count);
        lblBlocks.Text = "Frames: " + _shp.Images.Count;
      }
    }

    public void RefreshView()
    {
      ColorType color = ColorType.YELLOW;
      Enum.TryParse(cbRemapColor.Text, out color);

      if (_shp != null && _palSrc != null)
      {
        PalFile phSrc = RenderUtils.FetchHouseRemapPalette(_cache, _palSrc, color, false);
        int index = (int)nudImage.Value - 1;
        pbSrc.BackgroundImage = RenderUtils.RenderShp(_cache, _shp, phSrc, index);
        if (nudSrcZoom.Value != 1 && pbSrc.BackgroundImage != null)
        {
          Bitmap bmp = new Bitmap(pbSrc.BackgroundImage.Width * (int)nudSrcZoom.Value, pbSrc.BackgroundImage.Height * (int)nudSrcZoom.Value);
          using (Graphics g = Graphics.FromImage(bmp))
          {
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImage(pbSrc.BackgroundImage, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, pbSrc.BackgroundImage.Width, pbSrc.BackgroundImage.Height), GraphicsUnit.Pixel);
          }
          pbSrc.BackgroundImage = bmp;
        }
        if (pbSrc.BackgroundImage != null)
        {
          pbSrc.Size = new Size(Math.Max(pbSrc.BackgroundImage.Width, pbSrc.Parent.Size.Width), Math.Max(pbSrc.BackgroundImage.Height, pbSrc.Parent.Size.Height));
        }
        else
        {
          pbSrc.Size = pbSrc.Parent.Size;
        }
      }
      else
      {
        pbSrc.BackgroundImage = null;
        pbSrc.Size = pbSrc.Parent.Size;
      }
      lblSrcTmp.Text = _shp?.FileName;
      lblSrcPal.Text = _palSrc?.FileName;
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

    private void bSave_Click(object sender, EventArgs e)
    {
      if (_shp != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save SHP File",
          Filter = "SHP file|*.shp|All files (*.*)|*.*",
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          _shp.Save(sfd.FileName);
        }
      }
    }

    private void nudFrameSrc_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void bOpen_Click(object sender, EventArgs e)
    {
      try
      {
        if (_model != null)
        {
          SetShpFile(_model.GameFileSystem.OpenFile<ShpFile>(tbShpRADir.Text));
        }
      }
      catch
      {
        MessageBox.Show("An error has occurred in attempting to load the SHP file");
      }
    }

    private void bOpenPalS_Click(object sender, EventArgs e)
    {
      try
      {
        if (_model != null)
        {
          SetSourcePalette(_model.GameFileSystem.OpenFile<PalFile>(tbPalRADir.Text));
        }
      }
      catch
      {
        MessageBox.Show("An error has occurred in attempting to load the SHP file");
      }
    }

    private void nudSrcZoom_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void bExportImage_Click(object sender, EventArgs e)
    {
      if (_shp != null && _palSrc != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          int index = (int)nudImage.Value - 1;
          using (Bitmap bmp = RenderUtils.RenderShp(_cache, _shp, _palSrc, index))
          {
            bmp.Save(sfd.FileName);
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a shape file, and a palette source.");
      }
    }

    private void bImportImageReplace_Click(object sender, EventArgs e)
    {
      if (_shp != null && _palSrc != null)
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Import Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
          CheckFileExists = true
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            int index = (int)nudImage.Value - 1;
            using (Bitmap bmp = new Bitmap(ofd.FileName))
            {
              if (_shp.Images.Count > 1 && (bmp.Width != _shp.Width || bmp.Height != _shp.Height))
              {
                MessageBox.Show("Import image must be in the same dimensions as the other images in the shape file! (" + _shp.Width + " x " + _shp.Height + ")");
                return;
              }
              else if (_shp.Images.Count <= 1)
              {
                // the only image being replaced
                _shp.Width = (ushort)bmp.Width;
                _shp.Height = (ushort)bmp.Height;
              }

              _shp.Images[index] = GetImageFromBitmap(bmp);
              _cache.Clear();
              RefreshView();
            }
          }
          catch
          {
            MessageBox.Show("Unable to open the file as an image.");
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a shape file, and a palette source.");
      }
    }

    private ShpFile.ShpImage GetImageFromBitmap(Bitmap bmp)
    {
      byte[] data = new byte[bmp.Width * bmp.Height];
      for (int x = 0; x < bmp.Width; x++)
        for (int y = 0; y < bmp.Height; y++)
        {
          Color c = bmp.GetPixel(x, y);
          int ii = x + y * _shp.Width;
          if (c.A == 0)
          {
            data[ii] = 0;
          }
          else
          {
            data[ii] = ClosestIndex(c, _palSrc, _cacheDefault, null);
          }
        }

      return new ShpFile.ShpImage() { Image = data };
    }

    private byte ClosestIndex(Color color, PalFile pal, Dictionary<Color, int> cache, List<int> exclude)
    {
      if (cache != null && cache.TryGetValue(color, out int value))
      {
        return (byte)value;
      }
      int ret = pal.ClosestIndex(color, exclude);
      cache?.Add(color, ret);
      return (byte)ret;
    }

    private void bImportImageInsertBefore_Click(object sender, EventArgs e)
    {
      if (_shp != null && _palSrc != null)
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Import Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
          CheckFileExists = true,
          Multiselect = true
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            int index = (int)nudImage.Value - 1;
            foreach (string filename in ofd.FileNames)
            {
              using (Bitmap bmp = new Bitmap(filename))
              {
                if (_shp.Images.Count > 1 && (bmp.Width != _shp.Width || bmp.Height != _shp.Height))
                {
                  MessageBox.Show("Import image must be in the same dimensions as the other images in the shape file! (" + _shp.Width + " x " + _shp.Height + ")");
                  return;
                }

                _shp.Images.Insert(index, GetImageFromBitmap(bmp));
                _shp.NumImages = (ushort)_shp.Images.Count;
                _cache.Clear();
                index++;
              }
            }
            RefreshImageCount();
            RefreshView();
          }
          catch
          {
            MessageBox.Show("Unable to open the file as an image.");
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a shape file, and a palette source.");
      }
    }

    private void bImportImageInsertAfter_Click(object sender, EventArgs e)
    {
      if (_shp != null && _palSrc != null)
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Import Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
          CheckFileExists = true,
          Multiselect = true
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            int index = (int)nudImage.Value - 1;
            foreach (string filename in ofd.FileNames)
            {
              using (Bitmap bmp = new Bitmap(filename))
              {
                if (_shp.Images.Count > 1 && (bmp.Width != _shp.Width || bmp.Height != _shp.Height))
                {
                  MessageBox.Show("Import image must be in the same dimensions as the other images in the shape file! (" + _shp.Width + " x " + _shp.Height + ")");
                  return;
                }

                _shp.Images.Insert(index + 1, GetImageFromBitmap(bmp));
                _shp.NumImages = (ushort)_shp.Images.Count;
                _cache.Clear();
                index++;
              }
            }
            RefreshImageCount();
            nudImage.Value++;
            RefreshView();
          }
          catch
          {
            MessageBox.Show("Unable to open the file as an image.");
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a shape file, and a palette source.");
      }
    }

    private void bImportImageAdd_Click(object sender, EventArgs e)
    {
      if (_shp != null && _palSrc != null)
      {
        OpenFileDialog ofd = new OpenFileDialog()
        {
          Title = "Import Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
          CheckFileExists = true,
          Multiselect = true
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            int shapes = _shp.Images.Count;
            foreach (string filename in ofd.FileNames)
            {
              using (Bitmap bmp = new Bitmap(filename))
              {
                if (_shp.Images.Count > 1 && (bmp.Width != _shp.Width || bmp.Height != _shp.Height))
                {
                  MessageBox.Show("Import image must be in the same dimensions as the other images in the shape file! (" + _shp.Width + " x " + _shp.Height + ")");
                  return;
                }

                _shp.Images.Add(GetImageFromBitmap(bmp));
                _shp.NumImages = (ushort)_shp.Images.Count;
                _cache.Clear();
              }
            }
            RefreshImageCount();
            nudImage.Value = shapes + 1;
            RefreshView();
          }
          catch
          {
            MessageBox.Show("Unable to open the file as an image.");
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a shape file, and a palette source.");
      }
    }

    private void bDuplicateImage_Click(object sender, EventArgs e)
    {
      int index = (int)nudImage.Value - 1;
      _shp.Images.Insert(index + 1, new ShpFile.ShpImage() { Image = (byte[])_shp.Images[index].Image.Clone() });
      _cache.Clear();
      RefreshImageCount();
      RefreshView();
    }

    private void bDeleteImage_Click(object sender, EventArgs e)
    {
      if (_shp.Images.Count <= 1)
      {
        MessageBox.Show("Cannot delete the last image. Replace it instead.");
        return;
      }

      if (MessageBox.Show("This will remove the image. Confirm?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        int index = (int)nudImage.Value - 1;
        _shp.Images.RemoveAt(index);
        _cache.Clear();
        RefreshImageCount();
        RefreshView();
      }
    }

    private void bMoveImageNext_Click(object sender, EventArgs e)
    {
      int index = (int)nudImage.Value - 1;
      if (index < _shp.Images.Count - 1)
      {
        ShpFile.ShpImage shp0 = _shp.Images[index];
        ShpFile.ShpImage shp1 = _shp.Images[index + 1];
        _shp.Images[index] = shp1;
        _shp.Images[index + 1] = shp0;
        _cache.Clear();
        RefreshView();
      }
    }

    private void bMoveImageBack_Click(object sender, EventArgs e)
    {
      int index = (int)nudImage.Value - 1;
      if (index > 0)
      {
        ShpFile.ShpImage shp0 = _shp.Images[index - 1];
        ShpFile.ShpImage shp1 = _shp.Images[index];
        _shp.Images[index - 1] = shp1;
        _shp.Images[index] = shp0;
        _cache.Clear();
        RefreshView();
      }
    }

    private void cbRemapColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshView();
    }
  }
}
