using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class FullMapReplaceAction : ITrackedAction, ITrackedSnapshotAction
  {
    // only use for actions that do not undo easily, such as map shifts

    public Map Map;
    public MapCache Cache;
    public VirtualFileSystem Vfs;
    public string Description { get; set; }
    public IniFile OldMap;
    public IniFile NewMap;

    public FullMapReplaceAction(Map map, MapCache cache, VirtualFileSystem vfs)
    {
      Map = map;
      Cache = cache;
      Vfs = vfs;
    }

    public void SnapshotOld()
    {
      OldMap = new IniFile(null, null, 0, 0);
      Map.Update(OldMap);
    }

    public void SnapshotNew()
    {
      NewMap = new IniFile(null, null, 0, 0);
      Map.Update(NewMap);
    }

    public void Do()
    {
      if (NewMap != null)
      {
        IniFile f = Map.SourceFile;
        string path = Map.FilePath;
        Map.Load(NewMap);
        Map.SourceFile = f;
        Map.FilePath = path;
        Map.Dirty = true;
        Map.RebuildOccupancyList(Cache, Vfs);
        Map.InvalidateTemplateDisplay?.Invoke();
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }

    public void Undo()
    {
      if (OldMap != null)
      {
        IniFile f = Map.SourceFile;
        string path = Map.FilePath;
        Map.Load(OldMap);
        Map.SourceFile = f;
        Map.FilePath = path;
        Map.Dirty = true;
        Map.RebuildOccupancyList(Cache, Vfs);
        Map.InvalidateTemplateDisplay?.Invoke();
        Map.InvalidateObjectDisplay?.Invoke();
      }
    }
  }
}