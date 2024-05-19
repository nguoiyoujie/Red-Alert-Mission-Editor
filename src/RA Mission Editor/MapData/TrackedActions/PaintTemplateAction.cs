using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class PaintTemplateAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public ushort[] OldTemplate;
    public ushort[] NewTemplate;
    public byte[] OldTile;
    public byte[] NewTile;

    public PaintTemplateAction(Map map, MapCache cache, VirtualFileSystem vfs)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Description = "Paint Template";
    }

    public void SnapshotOld()
    {
      OldTemplate = (ushort[])Map.MapPackSection.Template.Clone();
      OldTile = (byte[])Map.MapPackSection.Tile.Clone();
    }

    public void SnapshotNew()
    {
      NewTemplate = (ushort[])Map.MapPackSection.Template.Clone();
      NewTile = (byte[])Map.MapPackSection.Tile.Clone();
    }

    public void Do()
    {
      if (Map.MapPackSection.Template.Length != NewTemplate.Length)
      {
        Map.MapPackSection.Template = new ushort[NewTemplate.Length];
      }
      if (Map.MapPackSection.Tile.Length != NewTile.Length)
      {
        Map.MapPackSection.Tile = new byte[NewTile.Length];
      }
      NewTemplate.CopyTo(Map.MapPackSection.Template, 0);
      NewTile.CopyTo(Map.MapPackSection.Tile, 0);
      Map.Dirty = true;
      Map.RebuildOccupancyList(Cache, Vfs);
      Map.InvalidateTemplateDisplay?.Invoke();
    }

    public void Undo()
    {
      if (Map.MapPackSection.Template.Length != OldTemplate.Length)
      {
        Map.MapPackSection.Template = new ushort[OldTemplate.Length];
      }
      if (Map.MapPackSection.Tile.Length != OldTile.Length)
      {
        Map.MapPackSection.Tile = new byte[OldTile.Length];
      }
      OldTemplate.CopyTo(Map.MapPackSection.Template, 0);
      OldTile.CopyTo(Map.MapPackSection.Tile, 0);
      Map.Dirty = true;
      Map.RebuildOccupancyList(Cache, Vfs);
      Map.InvalidateTemplateDisplay?.Invoke();
    }
  }
}