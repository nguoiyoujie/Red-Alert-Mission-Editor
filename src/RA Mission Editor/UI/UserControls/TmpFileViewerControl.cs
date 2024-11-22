using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TmpFileViewerControl : UserControl
  {
    public TmpFileViewerControl()
    {
      InitializeComponent();
      RefreshView();

      foreach (TileType t in Enum.GetValues(typeof(TileType)))
        cbTileType.Items.Add(t);
    }

    private MainModel _model;
    private MapCache _cache = new MapCache();
    private TmpFile _tmp;
    private PalFile _palSrc;
    private Bitmap _palSrcbmp;

    private Dictionary<Color, int> _cacheDefault = new Dictionary<Color, int>();
    static List<int> DefaultExcludeIndex = new List<int> { 0, 1, 2, 3, 4, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95 }; // 0-4 transparent and shadows, 80-95 house remaps

    public void SetModel(MainModel model)
    {
      _model = model;
    }

    public void SetTmpFile(TmpFile tmp)
    {
      // set a copy of the file
      if (tmp != null)
      {
        byte[] data = new byte[(int)tmp.Size];
        tmp.Position = 0; // tmp.BaseOffset;
        tmp.Read(data, 0, data.Length);
        MemoryStream inMemoryCopy = new MemoryStream(data);
        _tmp = new TmpFile(inMemoryCopy, tmp.FileName, 0, (int)tmp.Size, false);
        nudImage.Maximum = Math.Max(1, _tmp.Images.Count);
        lblBlocks.Text = "Blocks: " + _tmp.BlockWidth + " x " + _tmp.BlockHeight;
      }
      else
      {
        _tmp = null;
      }
      _cache.Clear();
      RefreshView();
    }

    public void SetSourcePalette(PalFile pal)
    {
      _palSrc = pal;
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

    public void RefreshView()
    {
      if (_tmp != null && _palSrc != null)
      {
        PalFile phSrc = _palSrc; //RenderUtils.FetchHouseRemapPalette(_cache, _palSrc, color);
        pbSrc.BackgroundImage = RenderUtils.RenderTemplate(_cache, _tmp, phSrc);
        pbTileTypes.BackgroundImage = RenderUtils.RenderTemplate(_cache, _tmp, phSrc, true);
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
        int index = (int)nudImage.Value - 1;
        cbIsClearTemplate.Checked = _tmp.TileTypes.Count == 1 && _tmp.Images.Count > 1;
        cbTileType.SelectedItem = _tmp.TileTypes[index % _tmp.TileTypes.Count];
        pbSingle.BackgroundImage = RenderUtils.RenderTemplate(_cache, _tmp, phSrc, index);
        if (nudSrcZoom.Value != 1 && pbSingle.BackgroundImage != null)
        {
          Bitmap bmp = new Bitmap(pbSingle.BackgroundImage.Width * (int)nudSrcZoom.Value, pbSingle.BackgroundImage.Height * (int)nudSrcZoom.Value);
          using (Graphics g = Graphics.FromImage(bmp))
          {
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImage(pbSingle.BackgroundImage, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, pbSingle.BackgroundImage.Width, pbSingle.BackgroundImage.Height), GraphicsUnit.Pixel);
          }
          pbSingle.BackgroundImage = bmp;
        }
        if (pbSingle.BackgroundImage != null)
        {
          pbSingle.Size = new Size(Math.Max(pbSingle.BackgroundImage.Width, pbSingle.Parent.Size.Width), Math.Max(pbSingle.BackgroundImage.Height, pbSingle.Parent.Size.Height));
        }
        else
        {
          pbSingle.Size = pbSingle.Parent.Size;
        }
        if (nudSrcZoom.Value != 1 && pbTileTypes.BackgroundImage != null)
        {
          Bitmap bmp = new Bitmap(pbTileTypes.BackgroundImage.Width * (int)nudSrcZoom.Value, pbTileTypes.BackgroundImage.Height * (int)nudSrcZoom.Value);
          using (Graphics g = Graphics.FromImage(bmp))
          {
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImage(pbTileTypes.BackgroundImage, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, pbTileTypes.BackgroundImage.Width, pbTileTypes.BackgroundImage.Height), GraphicsUnit.Pixel);
          }
          pbTileTypes.BackgroundImage = bmp;
        }
        if (pbTileTypes.BackgroundImage != null)
        {
          pbTileTypes.Size = new Size(Math.Max(pbTileTypes.BackgroundImage.Width, pbTileTypes.Parent.Size.Width), Math.Max(pbTileTypes.BackgroundImage.Height, pbTileTypes.Parent.Size.Height));
        }
        else
        {
          pbTileTypes.Size = pbTileTypes.Parent.Size;
        }
      }
      else
      {
        pbSrc.BackgroundImage = null;
        pbSrc.Size = pbSrc.Parent.Size;
        pbSingle.BackgroundImage = null;
        pbSingle.Size = pbSrc.Parent.Size;
        pbTileTypes.BackgroundImage = null;
        pbTileTypes.Size = pbSrc.Parent.Size;
      }
      lblSrcTmp.Text = _tmp?.FileName;
      lblSrcPal.Text = _palSrc?.FileName;
    }

    private void bLoadShp_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Open TMP File",
        Filter = "Temperate file|*.tem|Snow file|*.sno|Interior file|*.int|All files (*.*)|*.*",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          VirtualFileSystem vfs = new VirtualFileSystem();
          vfs.AddItem(Path.GetDirectoryName(ofd.FileName));

          TmpFile tmp = vfs.OpenFile<TmpFile>(Path.GetFileName(ofd.FileName), BufferingMode.None);
          SetTmpFile(tmp);
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
      if (_tmp != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save TMP File",
          Filter = "Temperate file|*.tem|Snow file|*.sno|Interior file|*.int|All files (*.*)|*.*",
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          _tmp.Save(sfd.FileName);
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
          SetTmpFile(_model.GameFileSystem.OpenFile<TmpFile>(tbShpRADir.Text));
        }
      }
      catch
      {
        MessageBox.Show("An error has occurred in attempting to load the TMP file");
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
      if (_tmp != null && _palSrc != null)
      {
        SaveFileDialog sfd = new SaveFileDialog()
        {
          Title = "Save Image",
          Filter = "PNG Image file|*.png|All files (*.*)|*.*",
        };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          using (Bitmap bmp = RenderUtils.RenderTemplate(_cache, _tmp, _palSrc))
          {
            bmp.Save(sfd.FileName);
          }
        }
      }
      else
      {
        MessageBox.Show("Please open both a template image, and a palette source.");
      }
    }

    private void bImportImage_Click(object sender, EventArgs e)
    {
      if (_tmp != null && _palSrc != null)
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
            using (Bitmap bmp = new Bitmap(ofd.FileName))
            {
              MemoryStream inMemoryCopy = new MemoryStream();
              TmpFile tmp = new TmpFile(inMemoryCopy, Path.ChangeExtension(Path.GetFileName(ofd.FileName), ".tem"), 0, 40, false);
              tmp.Width = TmpFile.TileSize;
              tmp.Height = TmpFile.TileSize;
              tmp.BlockWidth = ((bmp.Width - 1) / TmpFile.TileSize) + 1;
              tmp.BlockHeight = ((bmp.Height - 1) / TmpFile.TileSize) + 1;

              byte[][] data = new byte[tmp.BlockWidth * tmp.BlockHeight][];
              for (int i = 0; i < data.Length; i++)
              {
                data[i] = new byte[tmp.Width * tmp.Height];
              }
              for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                  Color c = bmp.GetPixel(x, y);
                  int index = x / tmp.Width + y / tmp.Height * tmp.BlockWidth;
                  int ii = x % tmp.Width + (y % tmp.Height) * tmp.Width;
                  if (c.A == 0)
                  {
                    data[index][ii] = 0;
                  }
                  else
                  {
                    data[index][ii] = ClosestIndex(c, _palSrc, _cacheDefault, DefaultExcludeIndex);
                  }
                }

              tmp.Images = new List<TmpFile.TmpImage>();
              tmp.TileTypes = new List<TileType>(tmp.BlockWidth * tmp.BlockHeight);
              tmp.TransData = new List<byte>();

              foreach (byte[] d in data)
              {
                bool hasImage = false;
                foreach (byte b in d)
                {
                  if (b != 0)
                  {
                    hasImage = true;
                    break;
                  }
                }
                if (hasImage)
                {
                  TmpFile.TmpImage img = new TmpFile.TmpImage() { TileData = d };
                  tmp.Images.Add(img);
                  tmp.TransData.Add(0);
                }
                else
                {
                  tmp.Images.Add(null);
                }
              }

              for (int i = 0; i < tmp.BlockWidth * tmp.BlockHeight; i++)
              {
                tmp.TileTypes.Add(TileType.CLEAR_0);
              }

              _tmp = tmp;
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
        MessageBox.Show("Please open both a template image, and a palette source.");
      }
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

    private void bSetSingle_Click(object sender, EventArgs e)
    {
      int index = ((int)nudImage.Value - 1) % _tmp.TileTypes.Count;
      if (_tmp != null)
      {
        if (cbTileType.SelectedItem is TileType t)
        {
          _tmp.TileTypes[index] = t;
        }
        else
        {
          _tmp.TileTypes[index] = TileType.CLEAR_0;
        }
        RefreshView();
      }
    }

    private void bSetAll_Click(object sender, EventArgs e)
    {
      if (_tmp != null)
      {
        if (!(cbTileType.SelectedItem is TileType t))
        {
          t = TileType.CLEAR_0;
        }

        for (int i = 0; i < _tmp.TileTypes.Count; i++)
        {
          _tmp.TileTypes[i] = t;
        }
        RefreshView();
      }
    }

    private void cbIsClearTemplate_CheckedChanged(object sender, EventArgs e)
    {
      if (_tmp != null)
      {
        if (cbIsClearTemplate.Checked)
        {
          if (_tmp.TileTypes.Count > 1)
          {
            TileType t = _tmp.TileTypes[0];
            _tmp.TileTypes.Clear();
            _tmp.TileTypes.Add(t);
            _tmp.BlockWidth = 1;
            _tmp.BlockHeight = 1;
          }
        }
        else
        {
          TileType t = _tmp.TileTypes[0];
          if (_tmp.TileTypes.Count == 1 && _tmp.Images.Count > 1)
          {
            _tmp.TileTypes.Clear();
            for (int i = 0; i < _tmp.Images.Count; i++)
            {
              _tmp.TileTypes.Add(t);
            }

            if (_cache.TryGet(_tmp, _palSrc, out Bitmap bmp) && bmp != null)
            {
              _tmp.BlockWidth = ((bmp.Width - 1) / TmpFile.TileSize) + 1; ;
              _tmp.BlockHeight = ((bmp.Height - 1) / TmpFile.TileSize) + 1;
            }
            else
            {
              _tmp.BlockWidth = _tmp.Images.Count;
              _tmp.BlockHeight = 1;
            }
          }
        }
        RefreshView();
      }
    }
  }
}
