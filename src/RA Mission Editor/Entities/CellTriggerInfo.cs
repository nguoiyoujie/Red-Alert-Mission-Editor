using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Drawing;

namespace RA_Mission_Editor.Entities
{
  public class CellTriggerInfo : IEntity<CellTriggerInfo>, IEntityType, ILocatable
  {
    public readonly Map Map;

    public CellTriggerInfo(Map owner)
    {
      Map = owner;
    }

    // CELL=ID
    // Example: 4061=TC01
    public string ID { get; set; } // Trigger ID
    public int Cell { get; set; } // Cell ID

    public EditorSelectMode SelectMode { get { return EditorSelectMode.CellTriggers; } }

    public string GetKeyAsString()
    {
      return Cell.ToString();
    }

    public string GetValueAsString()
    {
      return ID;
    }

    public string DisplayName { get => ID; }

    public override string ToString()
    {
      return $"{ID} @ {{{MapHelper.CellX(Map, Cell)}, {MapHelper.CellY(Map, Cell)}}}";
    }

    public static CellTriggerInfo Parse(Map map, string index, string value)
    {
      CellTriggerInfo s = new CellTriggerInfo(map);
      s.Cell = int.Parse(index);
      string[] tokens = value.Split(',');
      if (tokens.Length < 1)
      {
        throw new Exception($"Map CellTrigger {index} contains less than expected parameters");
      }
      s.ID = tokens[0];

      return s;
    }

    public CellTriggerInfo GetEntityType(Rules rules)
    {
      return this;
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
    {
      Bitmap bmp = new Bitmap(Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        WidgetsRenderer.DrawCellTrigger(g, ID, 0, 0);
      }
      return bmp;
    }

    public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity)
    {
      WidgetsRenderer.DrawCellTrigger(g, ID, entity.X, entity.Y);
    }
  }
}
