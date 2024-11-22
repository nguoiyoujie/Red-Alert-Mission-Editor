using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
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

      _bwConvert = new BackgroundWorker();
      _bwConvert.WorkerSupportsCancellation = true;
      _bwConvert.WorkerReportsProgress = true;
      _bwConvert.ProgressChanged += _bwConvert_ProgressChanged;
      _bwConvert.DoWork += _bwConvert_DoWork;
      _bwConvert.RunWorkerCompleted += _bwConvert_RunWorkerCompleted;
      RefreshView();
    }

    private MainModel _model;
    private MapCache _cache = new MapCache();
    private ShpFile _shp;
    private PalFile _palSrc;
    private Bitmap _palSrcbmp;
    private ShpFile _shpConverted;
    private PalFile _palDst;
    private Bitmap _palDstbmp;
    private string _progressText;
    private Dictionary<Color, int> _cacheDefault = new Dictionary<Color, int>();
    private Dictionary<Color, int> _cacheExcludeHouseColor = new Dictionary<Color, int>();

    private BackgroundWorker _bwConvert;

    static List<int> DefaultExcludeIndex = new List<int>{ 0, 1, 2, 3, 4 }; // transparent and shadows
    static List<int> DefaultHouseColorIndex = new List<int> { 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95 };
    static List<int> DefaultTDHouseColorIndex = new List<int> { 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191 };
    static List<int> ExcludeHouseColorIndex = new List<int> { };

    public void SetModel(MainModel model)
    {
      _model = model;
    }

    public void SetShpFile(ShpFile shp)
    {
      _shp = shp;
      _cache.Clear();
      if (shp != null)
      {
        nudFrameSrc.Maximum = Math.Max(1, (int)_shp.NumImages);
        nudFrameDst.Maximum = Math.Max(1, (int)_shp.NumImages);
      }
      StartConvert();
      RefreshView();
    }

    public void SetSourcePalette(PalFile pal)
    {
      _palSrc = pal;
      using (Bitmap bmp = pal?.GenerateColorPreview())
      {
        if (bmp != null)
        {
          if (_palSrcbmp == null || _palSrcbmp.Width != pbSrcPal.Width || _palSrcbmp.Height != pbSrcPal.Height)
          {
            _palSrcbmp = new Bitmap(pbSrcPal.Width, pbSrcPal.Height);
          }
          using (Graphics g = Graphics.FromImage(_palSrcbmp))
          {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            Rectangle rd = new Rectangle(0,0, _palSrcbmp.Width, _palSrcbmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
          }
        }
      }

      _cache.Clear();
      StartConvert();
      RefreshView();
    }

    public void SetDestinationPalette(PalFile pal)
    {
      _palDst = pal;
      using (Bitmap bmp = pal?.GenerateColorPreview())
      {
        if (bmp != null)
        {
          if (_palDstbmp == null || _palDstbmp.Width != pbDstPal.Width || _palDstbmp.Height != pbDstPal.Height)
          {
            _palDstbmp = new Bitmap(pbDstPal.Width, pbDstPal.Height);
          }
          using (Graphics g = Graphics.FromImage(_palDstbmp))
          {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            Rectangle rd = new Rectangle(0, 0, _palDstbmp.Width, _palDstbmp.Height);
            g.DrawImage(bmp, rd, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
          }
        }
      }

      _cache.Clear();
      StartConvert();
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
        pbSrcPal.BackgroundImage = _palSrcbmp;
      }
      else
      {
        pbSrc.BackgroundImage = null;
        pbSrc.Size = pbSrc.Parent.Size;
        pbSrcPal.BackgroundImage = null;
      }

      if (_shpConverted != null && _palDst != null)
      {
        lblProgressText.Text = null;
        PalFile phDst = RenderUtils.FetchHouseRemapPalette(_cache, _palDst, color);
        pbDst.BackgroundImage = RenderUtils.RenderShp(_cache, _shpConverted, phDst, (int)(nudFrameDst.Value - 1));
        if (nudDstZoom.Value != 1)
        {
          Bitmap bmp = new Bitmap(pbDst.BackgroundImage.Width * (int)nudDstZoom.Value, pbDst.BackgroundImage.Height * (int)nudDstZoom.Value);
          using (Graphics g = Graphics.FromImage(bmp))
          {
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImage(pbDst.BackgroundImage, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, pbDst.BackgroundImage.Width, pbDst.BackgroundImage.Height), GraphicsUnit.Pixel);
          }
          pbDst.BackgroundImage = bmp;
        }
        if (pbDst.BackgroundImage != null)
        {
          pbDst.Size = new Size(Math.Max(pbDst.BackgroundImage.Width, pbDst.Parent.Size.Width), Math.Max(pbDst.BackgroundImage.Height, pbDst.Parent.Size.Height));
        }
        pbDstPal.BackgroundImage = _palDstbmp;
      }
      else
      {
        lblProgressText.Text = _progressText;
        pbDst.BackgroundImage = null;
        pbDst.Size = pbDst.Parent.Size;
        pbDstPal.BackgroundImage = null;
      }

      lblSrcShp.Text = _shp?.FileName;
      lblSrcPal.Text = _palSrc?.FileName;
      lblDstPal.Text = _palDst?.FileName;
    }

    public void StartConvert()
    {
      if (_bwConvert.IsBusy)
      {
        _bwConvert.CancelAsync();
        Thread.Sleep(500);
      }
      _bwConvert.RunWorkerAsync();
    }

    private void _bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (e.UserState is string state)
      {
        _progressText = state;
        Invoke(new Action(RefreshView));
      }
    }

    private void _bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      _progressText = null;
      Invoke(new Action(RefreshView));
    }


    private void _bwConvert_DoWork(object sender, DoWorkEventArgs e)
    {
      if (_shp != null && _palSrc != null && _palDst != null)
      {
        try
        {
          _shpConverted = null;
          _cacheDefault.Clear();
          _cacheExcludeHouseColor.Clear();
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
            if (e.Cancel) { break; }
            _bwConvert?.ReportProgress((int)(n * 100 / _shp.NumImages), string.Format("Generating frame {0} of {1}", n, _shp.NumImages));
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
                    convert.Images[n].Image[i] = ClosestIndex(_palSrc.GetColor(src), _palDst, _cacheExcludeHouseColor, ExcludeHouseColorIndex);
                  }
                  else
                  {
                    convert.Images[n].Image[i] = ClosestIndex(_palSrc.GetColor(src), _palDst, _cacheDefault, exclude);
                  }
                }
                else
                {
                  convert.Images[n].Image[i] = ClosestIndex(_palSrc.GetColor(src), _palDst, _cacheDefault, exclude);
                }
              }
            }
          }
          if (!e.Cancel)
          {
            _shpConverted = convert;
          }
          else
          {
            _shpConverted = null;
          }
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

    private void nubSrcZoom_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void nudDstZoom_ValueChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void cbRemapColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshView();
    }

    private void cbPalSrcTD_CheckedChanged(object sender, EventArgs e)
    {
      StartConvert();
      RefreshView();
    }

    private void cbPreserveHouseColors_CheckedChanged(object sender, EventArgs e)
    {
      StartConvert();
      RefreshView();
    }

    private void bOpenShpRA_Click(object sender, EventArgs e)
    {
      try
      {
        SetShpFile(_model.GameFileSystem.OpenFile<ShpFile>(tbShpRADir.Text));
      }
      catch
      {
        MessageBox.Show("An error has occurred in attempting to load the SHP file");
      }
    }

    private void bOpenPalRA_Click(object sender, EventArgs e)
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

    private void bOpenPalD_Click(object sender, EventArgs e)
    {
      try
      {
        if (_model != null)
        {
          SetDestinationPalette(_model.GameFileSystem.OpenFile<PalFile>(tbPalDRADir.Text));
        }
      }
      catch
      {
        MessageBox.Show("An error has occurred in attempting to load the SHP file");
      }
    }
  }
}
