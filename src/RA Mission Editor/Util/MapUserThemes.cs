using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace RA_Mission_Editor.Util
{
  public static class MapUserThemes
  {
    static MapUserThemes()
    {
      // set defaults
      Grid = Color.AliceBlue;
      Selection = Color.Goldenrod;
      LastSelection = Color.LimeGreen;
      Waypoint = Color.IndianRed;
      CellTrigger = Color.GreenYellow;
      TechnoTypeTag = Color.ForestGreen;
      TechnoTypeFake = Color.White;
      BaseNumber = Color.Salmon;

      // attempt to load local font
      try
      {
        if (File.Exists(Constants.FontLocation))
        {
          raFont.AddFontFile(Constants.FontLocation);

          TechnoTypeFakeFont = new Font(raFont.Families[0], TechnoTypeFakeFont.Size);
          TechnoTypeTagFont = new Font(raFont.Families[0], TechnoTypeTagFont.Size);
          BaseNumberFont = new Font(raFont.Families[0], BaseNumberFont.Size);
          CellTriggerFont = new Font(raFont.Families[0], CellTriggerFont.Size);
          WaypointFont = new Font(raFont.Families[0], WaypointFont.Size);
          ControlTextFont = new Font(raFont.Families[0], WaypointFont.Size);

          IsRAFontLoaded = true;
        }
      }
      catch { }
    }

    private static PrivateFontCollection raFont = new PrivateFontCollection();
    public static bool IsRAFontLoaded = false;

    public static Color Grid { get => _grid; set { GridBrush?.Dispose(); GridPen?.Dispose(); GridBrush = new SolidBrush(value); GridPen = new Pen(value, 2); _grid = value; } }
    public static Color Selection { get => _selection; set { SelectionBrush?.Dispose(); SelectionPen?.Dispose(); SelectionBrush = new HatchBrush(HatchStyle.BackwardDiagonal, value, Color.Transparent); SelectionPen = new Pen(value, 2); _selection = value; } }
    public static Color LastSelection { get => _lastselection; set { LastSelectionBrush?.Dispose(); LastSelectionPen?.Dispose(); LastSelectionBrush = new HatchBrush(HatchStyle.BackwardDiagonal, value, Color.Transparent); LastSelectionPen = new Pen(value, 2); _lastselection = value; } }
    public static Color Waypoint { get => _waypoint; set { WaypointBrush?.Dispose(); WaypointPen?.Dispose(); WaypointBrush = new SolidBrush(value); WaypointPen = new Pen(value); _waypoint = value; } }
    public static Color CellTrigger { get => _cellTrigger; set { CellTriggerBrush?.Dispose(); CellTriggerPen?.Dispose(); CellTriggerBrush = new SolidBrush(value); CellTriggerPen = new Pen(value); _cellTrigger = value; } }
    public static Color TechnoTypeTag { get => _technoTypeTag; set { TechnoTypeTagBrush?.Dispose(); TechnoTypeTagPen?.Dispose(); TechnoTypeTagBrush = new SolidBrush(value); TechnoTypeTagPen = new Pen(value); _technoTypeTag = value; } }
    public static Color TechnoTypeFake { get => _technoTypeFake; set { TechnoTypeFakeBrush?.Dispose(); TechnoTypeFakePen?.Dispose(); TechnoTypeFakeBrush = new SolidBrush(value); TechnoTypeFakePen = new Pen(value); _technoTypeFake = value; } }
    public static Color BaseNumber { get => _baseNumber; set { BaseNumberBrush?.Dispose(); BaseNumberPen?.Dispose(); BaseNumberBrush = new SolidBrush(value); BaseNumberPen = new Pen(value); _baseNumber = value; } }

    private static Color _grid;
    private static Color _selection;
    private static Color _lastselection;
    private static Color _waypoint;
    private static Color _cellTrigger;
    private static Color _technoTypeTag;
    private static Color _technoTypeFake;
    private static Color _baseNumber;

    public static Brush GridBrush { get; private set; }
    public static Brush SelectionBrush { get; private set; }
    public static Brush LastSelectionBrush { get; private set; }
    public static Brush WaypointBrush { get; private set; }
    public static Brush CellTriggerBrush { get; private set; }
    public static Brush TechnoTypeTagBrush { get; private set; }
    public static Brush TechnoTypeFakeBrush { get; private set; }
    public static Brush BaseNumberBrush { get; private set; }

    public static Pen GridPen { get; private set; }
    public static Pen SelectionPen { get; private set; }
    public static Pen LastSelectionPen { get; private set; }
    public static Pen WaypointPen { get; private set; }
    public static Pen CellTriggerPen { get; private set; }
    public static Pen TechnoTypeTagPen { get; private set; }
    public static Pen TechnoTypeFakePen { get; private set; }
    public static Pen BaseNumberPen { get; private set; }

    public static Font TechnoTypeFakeFont = new Font("Consolas", 10);
    public static Font TechnoTypeTagFont = new Font("Consolas", 7);
    public static Font BaseNumberFont = new Font("Consolas", 6.5f);
    public static Font CellTriggerFont = new Font("Consolas", 7);
    public static Font WaypointFont = new Font("Consolas", 12);

    public static Font ControlTextFont = new Font("Consolas", 10);

    public static int MinRAFontSize = 10;

    public static void SetRAFont(Control f, bool includeSelf = false)
    {
      if (IsRAFontLoaded)
      {
        if (includeSelf)
        {
          if (f.Font.FontFamily != ControlTextFont.FontFamily)
            f.Font = new Font(ControlTextFont.FontFamily, f.Font.Size < MinRAFontSize ? MinRAFontSize : f.Font.Size);
        }
        foreach (Control c in f.Controls)
        {
          // RA font is smaller, and looks good only at 10pt, most controls are set to 8pt
          if (f.Font.FontFamily != ControlTextFont.FontFamily)
            c.Font = new Font(ControlTextFont.FontFamily, f.Font.Size < MinRAFontSize ? MinRAFontSize : f.Font.Size);
          SetRAFont(c, false);
        }
        if (f is StatusStrip ss)
        {
          foreach (object obj in ss.Items)
          {
            if (obj is ToolStripItem tsi)
            {
              if (f.Font.FontFamily != ControlTextFont.FontFamily)
                tsi.Font = new Font(ControlTextFont.FontFamily, f.Font.Size < MinRAFontSize ? MinRAFontSize : f.Font.Size);
            }
          }
        }
      }
    }
  }
}
