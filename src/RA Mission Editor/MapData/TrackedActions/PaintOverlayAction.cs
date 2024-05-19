using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class PaintOverlayAction : ITrackedAction, ITrackedSnapshotAction
  {
    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public byte[] OldOverlay;
    public byte[] NewOverlay;

    public PaintOverlayAction(Map map, MapCache cache, VirtualFileSystem vfs)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
      Description = "Paint Overlay";
    }

    public void SnapshotOld()
    {
      OldOverlay = (byte[])Map.OverlayPackSection.Overlay.Clone();
    }

    public void SnapshotNew()
    {
      NewOverlay = (byte[])Map.OverlayPackSection.Overlay.Clone();
    }

    public void Do()
    {
      if (Map.OverlayPackSection.Overlay.Length != NewOverlay.Length)
      {
        Map.OverlayPackSection.Overlay = new byte[NewOverlay.Length];
      }
      NewOverlay.CopyTo(Map.OverlayPackSection.Overlay, 0);
      Map.Dirty = true;
      Map.RebuildOccupancyList(Cache, Vfs);
      Map.InvalidateObjectDisplay?.Invoke();
    }

    public void Undo()
    {
      if (Map.OverlayPackSection.Overlay.Length != OldOverlay.Length)
      {
        Map.OverlayPackSection.Overlay = new byte[OldOverlay.Length];
      }
      OldOverlay.CopyTo(Map.OverlayPackSection.Overlay, 0);
      Map.Dirty = true;
      Map.RebuildOccupancyList(Cache, Vfs);
      Map.InvalidateObjectDisplay?.Invoke();
    }
  }
}