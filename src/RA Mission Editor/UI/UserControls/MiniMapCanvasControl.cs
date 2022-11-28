using RA_Mission_Editor.Renderers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public class MiniMapCanvasControl : Control
  {
    public MinimapCanvas Renderer { get; private set; }

    public CoordClickDelegate ClickCoordinate;

    private Point _offsetPoint;

    public MiniMapCanvasControl()
    {
      InitializeComponent();
      SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // MapCanvasControl
      // 
      this.MouseClick += new MouseEventHandler(this.MapCanvasControl_MouseClick);
      this.ResumeLayout(false);

    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      if (!DesignMode)
      {
        Renderer = new MinimapCanvas();
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      if (Renderer == null || Renderer.Image == null || DesignMode)
      {
        base.OnPaint(pe);
      }
      else
      {
        Bitmap image = Renderer.Image;
        Size imageSize = image.Size;  //Zoom ? new Size(image.Size.Width * 2, image.Size.Height * 2) : image.Size;
        if (Size != imageSize)
        {
          _offsetPoint = new Point(Math.Max(0, (Size.Width - imageSize.Width) / 2), Math.Max(0, (Size.Height - imageSize.Height) / 2));
        }
        else
        {
          _offsetPoint = Point.Empty;
        }

        pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        pe.Graphics.SmoothingMode = SmoothingMode.None;
        pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        pe.Graphics.CompositingMode = CompositingMode.SourceCopy;
        pe.Graphics.DrawImage(image, new Rectangle(_offsetPoint.X, _offsetPoint.Y, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
      }
    }

    private void MapCanvasControl_MouseClick(object sender, MouseEventArgs e)
    {
      ClickCoordinate?.Invoke(e.X - _offsetPoint.X, e.Y - _offsetPoint.Y, 0, e.Button, null);
    }
  }
}
