using RA_Mission_Editor.Entities;
using RA_Mission_Editor.Renderers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public delegate void RequestDrawDelegate();
  public delegate void CoordUpdateDelegate(int x, int y, int subcell, MouseButtons button);
  public delegate void CoordClickDelegate(int x, int y, int subcell, MouseButtons button, IEntity selectedEntity);

  public class MapCanvasControl : Control
  {
    public MapCanvas Renderer { get; private set; }
    public float Zoom { get { return _zoom; } set { if (_zoom != value) { _zoom = value; Invalidate(); } } }
    private float _zoom = 1;
    private int _hover_x = -1;
    private int _hover_y = -1;
    private int _hover_subcell = -1;
    private bool _mouseDown = false;

    public RequestDrawDelegate RequestDraw;
    public CoordUpdateDelegate UpdateCoordinate;
    public CoordUpdateDelegate UpdateMouseDown;
    public CoordUpdateDelegate UpdateMouseUp;
    public CoordClickDelegate ClickCoordinate;
    public CoordUpdateDelegate DoubleClickCoordinate;

    public MapCanvasControl()
    {
      InitializeComponent();
      SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      //SelectCellNumber = -1;
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // MapCanvasControl
      // 
      this.DoubleClick += new EventHandler(this.MapCanvasControl_DoubleClick);
      this.MouseClick += new MouseEventHandler(this.MapCanvasControl_MouseClick);
      this.MouseDown += new MouseEventHandler(this.MapCanvasControl_MouseDown);
      this.MouseMove += new MouseEventHandler(this.MapCanvasControl_MouseMove);
      this.MouseUp += new MouseEventHandler(this.MapCanvasControl_MouseUp);
      this.ResumeLayout(false);

    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      if (!DesignMode)
      {
        Renderer = new MapCanvas();
        Renderer.MapDirtied += () => { Invalidate(); };
        Renderer.MapUpdated += () => { Invalidate(); };
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
        Size expectedSize = new Size((int)(image.Size.Width * Zoom), (int)(image.Size.Height * Zoom));
        if (Size != expectedSize)
        {
          Size = expectedSize;
        }
        if (Renderer.Dirty || Renderer.TemplateDirty)
        {
          if (RequestDraw != null)
          {
            RequestDraw.Invoke();
          }
        }
        pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        pe.Graphics.SmoothingMode = SmoothingMode.None;
        pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        pe.Graphics.CompositingMode = CompositingMode.SourceCopy;
        pe.Graphics.DrawImage(image, new Rectangle(0, 0, Width, Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
      }
    }

    private Point[] _subCellC =
      new Point[]
      {
        new Point(Constants.CELL_PIXEL_W / 2, Constants.CELL_PIXEL_H / 2),
        new Point(Constants.CELL_PIXEL_W / 5, Constants.CELL_PIXEL_H / 5),
        new Point(Constants.CELL_PIXEL_W * 4 / 5, Constants.CELL_PIXEL_H / 5),
        new Point(Constants.CELL_PIXEL_W / 5, Constants.CELL_PIXEL_H * 4 / 5),
        new Point(Constants.CELL_PIXEL_W * 4 / 5, Constants.CELL_PIXEL_H * 4 / 5),
      };

    private void GetCoord(int x, int y, out int cx, out int cy, out int subcell)
    {
      cx = x / Constants.CELL_PIXEL_W;
      cy = y / Constants.CELL_PIXEL_H;
      int sx = x % Constants.CELL_PIXEL_W;
      int sy = y % Constants.CELL_PIXEL_H;

      subcell = 0;
      int subCellD = 99;
      for (int i = 0; i < _subCellC.Length; i++)
      {
        // find closest
        int d = Math.Abs(sx - _subCellC[i].X) + Math.Abs(sy - _subCellC[i].Y);
        if (d < subCellD)
        {
          subcell = i;
          subCellD = d;
        }
      }
    }

    private void UpdateCoord(int x, int y, MouseButtons button)
    {
      GetCoord(x, y, out int cx, out int cy, out int subcell);
      if (_hover_x != cx || _hover_y != cy || _hover_subcell != subcell)
      {
        _hover_x = cx;
        _hover_y = cy;
        _hover_subcell = subcell;
        UpdateCoordinate?.Invoke(cx, cy, subcell, button);
      }
    }

    private void MapCanvasControl_MouseMove(object sender, MouseEventArgs e)
    {
      UpdateCoord((int)(e.X / Zoom), (int)(e.Y / Zoom), e.Button);
    }

    private void MapCanvasControl_MouseClick(object sender, MouseEventArgs e)
    {
      UpdateCoord((int)(e.X / Zoom), (int)(e.Y / Zoom), e.Button);
      ClickCoordinate?.Invoke(_hover_x, _hover_y, _hover_subcell, e.Button, null);
    }

    private void MapCanvasControl_DoubleClick(object sender, EventArgs e)
    {
      DoubleClickCoordinate?.Invoke(_hover_x, _hover_y, _hover_subcell, default);
    }

    private void MapCanvasControl_MouseDown(object sender, MouseEventArgs e)
    {
      _mouseDown = true;
      UpdateMouseDown?.Invoke(_hover_x, _hover_y, _hover_subcell, e.Button);
    }

    private void MapCanvasControl_MouseUp(object sender, MouseEventArgs e)
    {
      if (_mouseDown) // closing a dialog box may trigger mouse up even if user did not previously click over the canvas itself
      {
        _mouseDown = false;
        UpdateMouseUp?.Invoke(_hover_x, _hover_y, _hover_subcell, e.Button);
      }
    }
  }
}
