using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.Renderers
{
  public class MapCache
  {
    internal struct RemapPair<T, U> : IEquatable<RemapPair<T, U>>
    {
      public T TObj;
      public U UObj;

      public RemapPair(T t, U u)
      {
        TObj = t;
        UObj = u;
      }

      public bool Equals(RemapPair<T, U> other)
      {
        return (EqualityComparer<T>.Default.Equals(TObj, other.TObj)) && EqualityComparer<U>.Default.Equals(UObj, other.UObj);
      }

      public override bool Equals(object obj)
      {
        return obj is RemapPair<T, U> rpair && Equals(rpair);
      }

      public override int GetHashCode()
      {
        return TObj.GetHashCode() + 263 * (UObj.GetHashCode() + 17);
      }
    }

    private Dictionary<string, TmpFile> _tmpFileCache = new Dictionary<string, TmpFile>();
    private Dictionary<string, ShpFile> _shpFileCache = new Dictionary<string, ShpFile>();
    private Dictionary<string, PalFile> _palFileCache = new Dictionary<string, PalFile>();
    private Dictionary<IEntityType, Size> _cellSizeCache = new Dictionary<IEntityType, Size>();
    private Dictionary<int, Brush> _brushCache = new Dictionary<int, Brush>();

    private Dictionary<RemapPair<ShpFile, PalFile>, Bitmap[]> _shpFramesCache = new Dictionary<RemapPair<ShpFile, PalFile>, Bitmap[]>();
    private Dictionary<RemapPair<TmpFile, PalFile>, Bitmap> _templateCache = new Dictionary<RemapPair<TmpFile, PalFile>, Bitmap>();
    private Dictionary<RemapPair<TmpFile, PalFile>, Bitmap[]> _templateTileCache = new Dictionary<RemapPair<TmpFile, PalFile>, Bitmap[]>();
    private Dictionary<RemapPair<PalFile, ColorType>, PalFile> _houseRemapPaletteCache = new Dictionary<RemapPair<PalFile, ColorType>, PalFile>();
    private Dictionary<RemapPair<PalFile, string>, PalFile> _swapPaletteCache = new Dictionary<RemapPair<PalFile, string>, PalFile>();

    public bool TryGet(string name, out TmpFile file)
    {
      return _tmpFileCache.TryGetValue(name, out file);
    }

    public bool TryGet(string name, out ShpFile file)
    {
      return _shpFileCache.TryGetValue(name, out file);
    }

    public bool TryGet(string name, out PalFile file)
    {
      return _palFileCache.TryGetValue(name, out file);
    }

    public bool TryGet(IEntityType entityType, out Size cellSize)
    {
      return _cellSizeCache.TryGetValue(entityType, out cellSize);
    }

    public bool TryGet(ShpFile file, PalFile pal, out Bitmap[] frames)
    {
      return _shpFramesCache.TryGetValue(new RemapPair<ShpFile, PalFile>(file, pal), out frames);
    }

    public bool TryGet(TmpFile file, PalFile pal, out Bitmap template)
    {
      return _templateCache.TryGetValue(new RemapPair<TmpFile, PalFile>(file, pal), out template);
    }

    public bool TryGet(TmpFile file, PalFile pal, out Bitmap[] tiles)
    {
      return _templateTileCache.TryGetValue(new RemapPair<TmpFile, PalFile>(file, pal), out tiles);
    }

    public bool TryGet(PalFile file, ColorType color, out PalFile newpal)
    {
      return _houseRemapPaletteCache.TryGetValue(new RemapPair<PalFile, ColorType>(file, color), out newpal);
    }

    public bool TryGet(PalFile file, string swapkey, out PalFile newpal)
    {
      return _swapPaletteCache.TryGetValue(new RemapPair<PalFile, string>(file, swapkey), out newpal);
    }

    public bool TryGet(Color color, out Brush brush)
    {
      return _brushCache.TryGetValue(color.ToArgb(), out brush);
    }

    

    public void Register(string name, TmpFile file)
    {
      _tmpFileCache[name] = file;
    }

    public void Register(string name, ShpFile file)
    {
      _shpFileCache[name] = file;
    }

    public void Register(string name, PalFile file)
    {
      _palFileCache[name] = file;
    }

    public void Register(IEntityType entityType, Size cellSize)
    {
      _cellSizeCache[entityType] = cellSize;
    }

    public void Register(ShpFile file, PalFile pal, Bitmap[] frames)
    {
      if (frames != null)
        foreach (Bitmap b in frames)
          b?.TagAsCached();

      _shpFramesCache[new RemapPair<ShpFile, PalFile>(file, pal)] = frames;
    }

    public void Register(TmpFile file, PalFile pal, Bitmap template)
    {
      template?.TagAsCached();
      _templateCache[new RemapPair<TmpFile, PalFile>(file, pal)] = template;
    }

    public void Register(TmpFile file, PalFile pal, Bitmap[] tiles)
    {
      if (tiles != null)
        foreach (Bitmap b in tiles)
          b?.TagAsCached();
      
      _templateTileCache[new RemapPair<TmpFile, PalFile>(file, pal)] = tiles;
    }

    public void Register(PalFile file, ColorType color, PalFile newpal)
    {
      _houseRemapPaletteCache[new RemapPair<PalFile, ColorType>(file, color)] = newpal;
    }

    public void Register(PalFile file, string swapkey, PalFile newpal)
    {
      _swapPaletteCache[new RemapPair<PalFile, string>(file, swapkey)] = newpal;
    }


    public bool OpenAndRegister(string name, VirtualFileSystem vfs, out ShpFile file)
    {
      file = vfs.OpenFile<ShpFile>(name);
      // also register null files (if file is not found)
      _shpFileCache[name] = file;
      return file != null;
    }

    public bool OpenAndRegister(string name, VirtualFileSystem vfs, out TmpFile file)
    {
      file = vfs.OpenFile<TmpFile>(name);
      // also register null files (if file is not found)
      _tmpFileCache[name] = file;
      return file != null;
    }

    public bool OpenAndRegister(string name, VirtualFileSystem vfs, out PalFile file)
    {
      file = vfs.OpenFile<PalFile>(name);
      // also register null files (if file is not found)
      _palFileCache[name] = file;
      return file != null;
    }

    public bool OpenAndRegister(Color color, out Brush brush)
    {
      brush = new SolidBrush(color);      
      // also register null files (if file is not found)
      _brushCache[color.ToArgb()] = brush;
      return brush != null;
    }

    public bool GetOrOpen(string name, VirtualFileSystem vfs, out ShpFile file)
    {
      return (TryGet(name, out file) || OpenAndRegister(name, vfs, out file)) && file != null;
    }

    public bool GetOrOpen(string name, VirtualFileSystem vfs, out TmpFile file)
    {
      return (TryGet(name, out file) || OpenAndRegister(name, vfs, out file)) && file != null;
    }

    public bool GetOrOpen(string name, VirtualFileSystem vfs, out PalFile file)
    {
      return (TryGet(name, out file) || OpenAndRegister(name, vfs, out file)) && file != null;
    }

    public bool GetOrCreate(Color color, out Brush brush)
    {
      return (TryGet(color, out brush) || OpenAndRegister(color, out brush)) && brush != null;
    }

    public void Clear()
    {
      foreach (Bitmap[] blist in _shpFramesCache.Values)
      {
        if (blist != null)
        {
          foreach (Bitmap b in blist)
          {
            b.ReleaseCachedTag();
          }
        }
      }

      foreach (Bitmap b in _templateCache.Values)
      {
        b.ReleaseCachedTag();
      }

      foreach (Bitmap[] blist in _templateTileCache.Values)
      {
        if (blist != null)
        {
          foreach (Bitmap b in blist)
          {
            b.ReleaseCachedTag();
          }
        }
      }

      foreach (Brush b in _brushCache.Values)
      {
        b.Dispose();
      }

      _tmpFileCache.Clear();
      _shpFileCache.Clear();
      _palFileCache.Clear();
      _shpFramesCache.Clear();
      _templateCache.Clear();
      _templateTileCache.Clear();
      _houseRemapPaletteCache.Clear();
      _swapPaletteCache.Clear();
      _brushCache.Clear();
    }
  }
}
