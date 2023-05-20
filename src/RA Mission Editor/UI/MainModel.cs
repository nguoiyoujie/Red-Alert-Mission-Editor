using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.SettingsData;
using RA_Mission_Editor.UI.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI
{
  public delegate void NotifyDelegate();

  public class MainModel
  {
    public readonly Settings ApplicationSettings = new Settings();
    public readonly VirtualFileSystem GameFileSystem = new VirtualFileSystem();
    public readonly Map CurrentMap;
    public readonly MapCache Cache = new MapCache();
    public int LastClickedCell = -1;
    public List<int> SelectedCellsList = new List<int>();
    public readonly List<IEntity> PickCache = new List<IEntity>();
    public readonly PlaceEntityInfo PreplaceEntity = new PlaceEntityInfo(); // pick types for insert
    public string ExecutablePath { get; private set; }
    public IEntity PickEntity = null;

    public MainModel(RulesType ruleType)
    {
      switch (ruleType)
      {
        case RulesType.BASE_GAME:
        default:
          CurrentMap = new Map(new VanillaRules());
          break;
        case RulesType.IRAN_EXTENSION:
          CurrentMap = new Map(new IranModRules());
          break;
        case RulesType.LOVALMIDAS_EXTENSION:
          CurrentMap = new Map(new LovalmidasModRules());
          break;
      }
    }

    public bool IsMapLoaded { get => CurrentMap.SourceFile != null; }
    public string MapFilePath { get => CurrentMap.FilePath; }

    //public ErrorDelegate OnExeLoadError;
    public ErrorDelegate OnError;
    public NotifyDelegate OnMapChanged;
    public NotifyDelegate OnClose;
    public NotifyDelegate OnMapTemplateLayerChanged;
    public NotifyDelegate OnMapLayerChanged;

    public void Initialize()
    {
      ApplicationSettings.Load();
      MapExtractSet.Reload();
      // simulate map set to update the UI
      OnMapChanged?.Invoke();

      string exePath = ApplicationSettings.CacheSection.ExePath;
      bool exeSkip = false;
      if (string.IsNullOrWhiteSpace(exePath))
      {
        if (!NotifyExeError("The path of the Red Alert executable is not set.", out exePath))
        {
          OnClose?.Invoke();
          exeSkip = true;
        }
      }

      while (!exeSkip)
      {
        try
        {
          LoadExe(exePath);
          break;
        }
        catch (Exception ex)
        {
          if (!NotifyExeError(ex.Message, out exePath))
          {
            OnClose?.Invoke();
            exeSkip = true;
          }
          else
          {
            continue; 
          }
        }
      }
    }

    public void LoadMap(string mapPath)
    {
      if (mapPath == null)
      {
        LoadMap(null as IniFile);
      }
      else
      {
        if (!File.Exists(mapPath))
        {
          OnError?.Invoke($"The file '{mapPath}' is not found!", ErrorType.WARNING, false);
          return;
        }

        VirtualFileSystem tempVfs = new VirtualFileSystem();
        tempVfs.AddItem(Path.GetDirectoryName(mapPath));
        using (IniFile f = tempVfs.OpenFile<IniFile>(Path.GetFileName(mapPath)))
        {
          if (f == null)
          {
            OnError?.Invoke($"The file '{mapPath}' is cannot be opened! Another application may be using it.", ErrorType.WARNING, false);
            return;
          }

          try
          {
            ApplicationSettings.CacheSection.SetRecentFile(mapPath);
            ApplicationSettings.Save();
            LoadMap(f, mapPath);
          }
          catch (Exception e)
          {
            OnError?.Invoke($"TError encountered: {e.Message}", ErrorType.WARNING, false);
          }
        }
      }
    }

    public void LoadMap(IniFile mapFile, string mapPath = null, MapSection mapSection = default)
    {
      if (mapFile == null)
      {
        // clear map
        CurrentMap.Clear();
        CurrentMap.AttachedRules.Clear();
        CurrentMap.AttachedRules.LoadRules(GameFileSystem);
        CurrentMap.AttachedRules.ApplyRulesWithMap(CurrentMap);
        CurrentMap.Dirty = false;
        OnMapChanged?.Invoke();
        LastClickedCell = -1;
        SelectedCellsList.Clear();
        Cache.Clear();
      }
      else
      {
        CurrentMap.Clear();
        CurrentMap.AttachedRules.Clear();
        CurrentMap.AttachedRules.LoadRules(GameFileSystem);
        CurrentMap.Load(mapFile, mapPath);
        CurrentMap.AttachedRules.ApplyRulesWithMap(CurrentMap);
        CurrentMap.RebuildOccupancyList(Cache, GameFileSystem);
        CurrentMap.Dirty = false;

        if (mapSection != null)
        {
          CurrentMap.MapSection = mapSection;
        }

        OnMapChanged?.Invoke();
      }
    }

    public void ImportMapFromOpenRABin(string binPath)
    {
      if (binPath == null)
      {
        LoadMap(null as IniFile);
      }
      else
      {
        if (!File.Exists(binPath))
        {
          OnError?.Invoke($"The file '{binPath}' is not found!", ErrorType.WARNING, false);
          return;
        }

        VirtualFileSystem tempVfs = new VirtualFileSystem();
        tempVfs.AddItem(Path.GetDirectoryName(binPath));
        using (IniFile f = tempVfs.OpenFile<IniFile>(Path.GetFileName(binPath)))
        {
          if (f == null)
          {
            OnError?.Invoke($"The file '{binPath}' is cannot be opened! Another application may be using it.", ErrorType.WARNING, false);
            return;
          }

          try
          {
            ApplicationSettings.CacheSection.SetRecentFile(binPath);
            ApplicationSettings.Save();
            LoadMap(f, binPath);
          }
          catch (Exception e)
          {
            OnError?.Invoke($"TError encountered: {e.Message}", ErrorType.WARNING, false);
          }
        }
      }
    }

    public void SaveMap(string mapPath)
    {
      try
      { 
      CurrentMap.Save(mapPath);
        // reload
        //LoadMap(mapPath);
      }
      catch (Exception e)
      {
        OnError?.Invoke($"TError encountered: {e.Message}", ErrorType.WARNING, false);
      }
    }

    public void LoadExe(string gameexePath)
    {
      GameFileSystem.AllArchives.Clear();
      MixLoading.LoadRAFileSystem(GameFileSystem, Path.GetDirectoryName(gameexePath));

      // update rules
      LastClickedCell = -1;
      SelectedCellsList.Clear();
      Cache.Clear();

      // save this setting
      ApplicationSettings.CacheSection.ExePath = gameexePath;
      ApplicationSettings.Save();

      ExecutablePath = gameexePath;
    }

    internal bool NotifyExeError(string reason, out string newPath)
    {
      OnError($"This program requires files from the Red Alert game to function.\n{reason}\nPlease set the location of the Red Alert executable.", ErrorType.PROMPT, false);

      OpenFileDialog ofd = new OpenFileDialog()
      {
        Title = "Find Red Alert Executable",
        Filter = "Red Alert executable|RA95.exe|All files (*.*)|*.*",
        CheckPathExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        newPath = ofd.FileName;
        return true;
      }
      newPath = null;
      return false;
    }


    public Bitmap FetchEntityTypeBitmap(IEntityType etype, MapCanvas canvas)
    {
      Bitmap bmp;
      EnvironmentRenderer.CheckTheatre(CurrentMap, Cache, GameFileSystem, out TheaterType tt, out PalFile palFile);
      if (etype == null)
      {
        return null;
      }
      else
      {
        bmp = etype.DrawPreview(CurrentMap, CurrentMap.AttachedRules, Cache, GameFileSystem, PreplaceEntity);
      }
      return bmp;
    }

    public void DrawMap(MapCanvas canvas)
    {
      { if (CurrentMap.SourceFile != null) { canvas.Draw(this, CurrentMap, CurrentMap.AttachedRules, Cache, GameFileSystem, PreplaceEntity); } else { canvas.Clear(); } };
    }

    public void DrawMinimap(MinimapCanvas canvas)
    {
      { if (CurrentMap.SourceFile != null) { canvas.Draw(CurrentMap, Cache, GameFileSystem); } else { canvas.Clear(); } };
    }

    public IEnumerable<IEntity> DoPick(int x, int y)
    {
      PickCache.Clear();
      PickCache.AddRange(CurrentMap.Pick(x, y));
      return PickCache;
    }

    public IEntity DoSelectFromPick(IEntityType entityType)
    {
      if (entityType == null) { PickEntity = null; return null; }
      foreach (IEntity e in PickCache)
      {
        IEntityType etype = e.GetEntityType(CurrentMap.AttachedRules);
        if (etype != null && entityType.GetType() == etype.GetType())
        {
          PickEntity = e; 
          return e;
        }
      }
      PickEntity = null; 
      return null;
    }

    public IEntity DoSelectFromPick()
    {
      IEntity last = null;
      foreach (IEntity e in PickCache)
      {
        if (e != null) //&& !(e is TemplateType))
        {
          // any type other than template is movable, but allow pick
          last = e;
        }
      }
      PickEntity = last;
      return last;
    }

    public IEntity DoPeekFromPick(Type entitytype)
    {
      IEntity last = null;
      foreach (IEntity e in PickCache)
      {
        if (e != null)
        {
          IEntityType etype = e.GetEntityType(CurrentMap.AttachedRules);
          if (etype != null && etype.GetType() == entitytype)
          {
            last = e;
          }
        }
      }
      return last;
    }

    public void PaintEntity(PlaceEntityMode placeMode, PlaceEntityInfo placeEntity)
    {
      if ((placeMode & PlaceEntityMode.PAINTING) != PlaceEntityMode.PAINTING) { return; }
      bool delete = (placeMode & PlaceEntityMode.DELETE) == PlaceEntityMode.DELETE;

      if (placeEntity.Type == null)
      {
        // do nothing
      }
      if (placeEntity.Type is TemplateType)
      {
        if (delete)
        {
          CurrentMap.InsertEntity(Cache, GameFileSystem, new PlaceEntityInfo(Templates.Get(0), placeEntity.X, placeEntity.Y, placeEntity.TemplateCell));
        }
        else
        {
          CurrentMap.InsertEntity(Cache, GameFileSystem, placeEntity);
        }
        OnMapTemplateLayerChanged?.Invoke();
      }
      else if (placeEntity.Type is OverlayType)
      {
        bool proceed = true;
        foreach (var p in PickCache)
        {
          // don't paint over existing overlays
          if (p is OverlayType)
          {
            if (delete)
            {
              CurrentMap.DeleteEntity(Cache, GameFileSystem, p, placeEntity.X, placeEntity.Y);
              OnMapLayerChanged?.Invoke();
            }
            proceed = false;
          }
        }
        if (proceed && !delete)
        {
          CurrentMap.InsertEntity(Cache, GameFileSystem, placeEntity);
          OnMapLayerChanged?.Invoke();
        }
      }
      else
      {
        bool proceed = true;
        foreach (var p in PickCache)
        {
          // don't paint over existing objects of the same type
          IEntityType etype = p.GetEntityType(CurrentMap.AttachedRules);
          if (placeEntity.Type != null && etype != null && etype.GetType() == placeEntity.Type.GetType())
          {
            if (delete)
            {
              CurrentMap.DeleteEntity(Cache, GameFileSystem, p, placeEntity.X, placeEntity.Y);
              OnMapLayerChanged?.Invoke();
            }
            proceed = false;
          }
        }
        if (proceed && !delete)
        {
          CurrentMap.InsertEntity(Cache, GameFileSystem, placeEntity);
          if (placeEntity.Type is ExtractType)
          {
            OnMapTemplateLayerChanged?.Invoke();
          }
          OnMapLayerChanged?.Invoke();
        }
      }
    }

    public void PlaceEntity(PlaceEntityMode placeMode, PlaceEntityInfo placeEntity)
    {
      bool delete = (placeMode & PlaceEntityMode.DELETE) == PlaceEntityMode.DELETE;
      if (delete)
      {
        foreach (var p in PickCache)
        {
          IEntityType etype = p.GetEntityType(CurrentMap.AttachedRules);
          if (placeEntity.Type != null && etype != null && etype.GetType() == placeEntity.Type.GetType())
          {
            CurrentMap.DeleteEntity(Cache, GameFileSystem, p, placeEntity.X, placeEntity.Y);
            if (placeEntity.Type is TemplateType)
            {
              OnMapTemplateLayerChanged?.Invoke();
            }
            else if (placeEntity.Type is ExtractType)
            {
              OnMapTemplateLayerChanged?.Invoke();
              OnMapLayerChanged?.Invoke();
            }
            else
            {
              OnMapLayerChanged?.Invoke();
            }
          }
        }
      }
      else
      {
        CurrentMap.InsertEntity(Cache, GameFileSystem, placeEntity);
        if (placeEntity.Type is ExtractType || placeEntity.Type is TemplateType)
        {
          OnMapTemplateLayerChanged?.Invoke();
        }
        else
        {
          OnMapLayerChanged?.Invoke();
        }
      }
    }

    //public void SelectCell(int cell)
    //{
    //  SelectedCellsList.Add(cell);
    //}

    public void DeleteEntity(IEntity entity)
    {
      CurrentMap.DeleteEntity(Cache, GameFileSystem, entity);
    }

    public void OnEntityModified(IEntity entity)
    {
      CurrentMap.OnEntityModified(Cache, GameFileSystem, entity);
    }
  }
}
