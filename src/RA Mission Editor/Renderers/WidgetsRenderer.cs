using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.UI;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace RA_Mission_Editor.Renderers
{
  public static class WidgetsRenderer
  {
    private static StringFormat _textStringFormat = StringFormat.GenericTypographic;

    static WidgetsRenderer()
    {
      _textStringFormat.Alignment = StringAlignment.Center;
      _textStringFormat.LineAlignment = StringAlignment.Center;
      _textStringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip;
    }

    public static void DrawWaypoints(Map map, PlaceEntityInfo placeEntity, Graphics g)
    {
      foreach (var wInfo in map.WaypointSection.WaypointList)
      {
        int c = wInfo.Cell;
        int x = map.CellX(c);
        int y = map.CellY(c);
        bool selected = placeEntity != null && placeEntity.Type is WaypointInfo wpt && wpt.ID.Equals(wInfo.ID, StringComparison.OrdinalIgnoreCase);

        DrawWaypoint(map, g, wInfo.ID, x, y, selected);
      }
    }

    public static void DrawWaypoint(Map map, Graphics g, string id, int x, int y, bool selected)
    {
      int c = map.CellNumber(x, y);
      if (!map.IsCellInMap(c)) { return; }

      // draw rectangle
      int xt = x * Constants.CELL_PIXEL_W;
      int yt = y * Constants.CELL_PIXEL_H;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
      g.DrawRectangle(selected ? MapUserThemes.SelectedWaypointPen : MapUserThemes.WaypointPen, xt, yt, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);

      // draw text
      Rectangle r = new Rectangle(xt, yt, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      g.DrawString(id.ToUpperInvariant(), MapUserThemes.WaypointFont, selected ? MapUserThemes.SelectedWaypointBrush : MapUserThemes.WaypointBrush, r, _textStringFormat);
    }

    private static float[] _dash_pattern = new float[] { 1, 5 };
    public static void DrawWaypointTransferLine(Map map, Graphics g, int x, int y, int x2, int y2)
    {
      int c = map.CellNumber(x, y);
      int c2 = map.CellNumber(x2, y2);
      if (!map.IsCellInMap(c) || !map.IsCellInMap(c2)) { return; }

      // draw lines
      int xt = x * Constants.CELL_PIXEL_W;
      int yt = y * Constants.CELL_PIXEL_H;
      int x2t = x2 * Constants.CELL_PIXEL_W;
      int y2t = y2 * Constants.CELL_PIXEL_H;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
      // use dotted style
      System.Drawing.Drawing2D.DashStyle dstyle = MapUserThemes.SelectedWaypointPen.DashStyle;
      MapUserThemes.SelectedWaypointPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
      MapUserThemes.SelectedWaypointPen.DashPattern = _dash_pattern;

      g.DrawLine(MapUserThemes.SelectedWaypointPen, xt, yt, x2t, y2t);
      g.DrawLine(MapUserThemes.SelectedWaypointPen, xt + Constants.CELL_PIXEL_W, yt, x2t + Constants.CELL_PIXEL_W, y2t);
      g.DrawLine(MapUserThemes.SelectedWaypointPen, xt, yt + Constants.CELL_PIXEL_H, x2t, y2t + Constants.CELL_PIXEL_H);
      g.DrawLine(MapUserThemes.SelectedWaypointPen, xt + Constants.CELL_PIXEL_W, yt + Constants.CELL_PIXEL_H, x2t + Constants.CELL_PIXEL_W, y2t + Constants.CELL_PIXEL_H);
      // restore style
      MapUserThemes.SelectedWaypointPen.DashStyle = dstyle;
    }

    public static void DrawCellTriggers(Map map, PlaceEntityInfo placeEntity, Graphics g)
    {
      foreach (var wInfo in map.CellTriggerSection.Triggers)
      {
        if (wInfo != null)
        {
          int c = wInfo.Cell;
          int x = map.CellX(c);
          int y = map.CellY(c);
          bool selected = placeEntity != null && placeEntity.Type is CellTriggerInfo ctrig && ctrig.ID.Equals(wInfo.ID, StringComparison.OrdinalIgnoreCase); 

          DrawCellTrigger(g, wInfo.ID.ToString(), x, y, selected);
        }
      }
    }

    public static void DrawCellTrigger(Graphics g, string id, int x, int y, bool selected)
    {
      // draw rectangle
      int xt = x * Constants.CELL_PIXEL_W + 1;
      int yt = y * Constants.CELL_PIXEL_H + 1;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
      g.DrawRectangle(selected ? MapUserThemes.SelectedCellTriggerPen : MapUserThemes.CellTriggerPen, xt, yt, Constants.CELL_PIXEL_W - 2, Constants.CELL_PIXEL_H - 2);

      // draw text
      Rectangle r = new Rectangle(xt, yt, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      g.DrawString(id.ToUpperInvariant(), MapUserThemes.CellTriggerFont, selected ? MapUserThemes.SelectedCellTriggerBrush : MapUserThemes.CellTriggerBrush, r, _textStringFormat);
    }

    public static void DrawCellTargets(Map map, Graphics g)
    {
      foreach (var team in map.TeamTypeSection.TeamTypeList)
      {
        foreach (var step in team.ScriptList)
        {
          if (step.ScriptType == 4 && step.Parameter.Value is int c) // hardcoded: "04 - Move To Cell"
          {
            int x = map.CellX(c);
            int y = map.CellY(c);
            DrawCellTarget(g, team.Name, x, y);
          }
        }
      }
    }

    public static void DrawCellTarget(Graphics g, string id, int x, int y)
    {
      // draw rectangle
      int xt = x * Constants.CELL_PIXEL_W + 1;
      int yt = y * Constants.CELL_PIXEL_H + 1;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
      g.DrawRectangle(MapUserThemes.CellTargetPen, xt, yt, Constants.CELL_PIXEL_W - 2, Constants.CELL_PIXEL_H - 2);

      // draw text
      Rectangle r = new Rectangle(xt, yt, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      g.DrawString(id.ToUpperInvariant(), MapUserThemes.CellTriggerFont, MapUserThemes.CellTargetBrush, r, _textStringFormat);
    }


    public static void DrawBounds(Map map, Graphics g)
    {
      
      // draw bound lines
      int x0 = map.MapSection.X * Constants.CELL_PIXEL_W;
      int y0 = map.MapSection.Y * Constants.CELL_PIXEL_H;
      int x1 = (map.MapSection.X + map.MapSection.Width) * Constants.CELL_PIXEL_W;
      int y1 = (map.MapSection.Y + map.MapSection.Height) * Constants.CELL_PIXEL_H;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
      g.DrawLine(MapUserThemes.GridPen, x0, 0, x0, map.Ext_MapSection.FullHeight * Constants.CELL_PIXEL_H);
      g.DrawLine(MapUserThemes.GridPen, x1, 0, x1, map.Ext_MapSection.FullHeight * Constants.CELL_PIXEL_H);
      g.DrawLine(MapUserThemes.GridPen, 0, y0, map.Ext_MapSection.FullWidth * Constants.CELL_PIXEL_W, y0);
      g.DrawLine(MapUserThemes.GridPen, 0, y1, map.Ext_MapSection.FullWidth * Constants.CELL_PIXEL_W, y1);
    }

    public static void DrawSelection(MainModel model, Map map, Graphics g)
    {
      List<int> cells = model.SelectedCellsList;
      int scell = map.LastClickedCell;
      foreach (int cell in cells)
      {
        if (map.IsCellInMap(cell))
        {
          // draw bound lines
          int x0 = map.CellX(cell) * Constants.CELL_PIXEL_W;
          int y0 = map.CellY(cell) * Constants.CELL_PIXEL_H;
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
          g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
          g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
          g.DrawRectangle(MapUserThemes.SelectionPen, x0, y0, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
          g.FillRectangle(MapUserThemes.SelectionBrush, x0, y0, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
        }
      }
      if (map.IsCellInMap(scell))
      {
        // draw bound lines
        int x0 = map.CellX(scell) * Constants.CELL_PIXEL_W;
        int y0 = map.CellY(scell) * Constants.CELL_PIXEL_H;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        g.DrawRectangle(MapUserThemes.LastSelectionPen, x0, y0, Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      }
    }

    public static void DrawGrid(Map map, Graphics g)
    {
      for (int c = 0; c < map.Ext_MapSection.FullCellCount; c++)
      {
        // draw point
        int x = map.CellX(c) * Constants.CELL_PIXEL_W;
        int y = map.CellY(c) * Constants.CELL_PIXEL_H;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        g.FillRectangle(MapUserThemes.GridBrush, x, y, 1, 1);
      }
    }
  }
}
