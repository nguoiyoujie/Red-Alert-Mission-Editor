using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.MapData
{
  public class Map
  {
    public IniFile SourceFile;
    public string FilePath;
    private bool _dirty;
    public bool Dirty
    {
      get { return _dirty; }
      set
      {
        if (value != _dirty)
        {
          _dirty = value;
          if (MapDirtyChanged != null)
          {
            MapDirtyChanged.Invoke();
          }
        }
      }
    }
    public VoidDelegate MapDirtyChanged;
    public VoidDelegate InvalidateObjectDisplay;
    public VoidDelegate InvalidateTemplateDisplay;
    public ActionDelegate<Type> InvalidateSelectionList;

    public readonly Rules AttachedRules;

    public BasicSection BasicSection = new BasicSection();
    public HouseSection[] HouseSections;
    public MapSection MapSection = new MapSection();
    public MapPack MapPackSection = new MapPack();
    public OverlayPack OverlayPackSection = new OverlayPack();
    public TerrainSection TerrainSection = new TerrainSection();
    public InfantrySection InfantrySection = new InfantrySection();
    public UnitSection UnitSection = new UnitSection();
    public ShipSection ShipSection = new ShipSection();
    public StructureSection StructureSection = new StructureSection();
    public BaseSection BaseSection = new BaseSection();
    public SmudgeSection SmudgeSection = new SmudgeSection();
    public TeamTypeSection TeamTypeSection = new TeamTypeSection();
    public TriggerSection TriggerSection = new TriggerSection();
    public WaypointSection WaypointSection = new WaypointSection();
    public CellTriggerSection CellTriggerSection = new CellTriggerSection();
    public BriefingSection BriefingSection = new BriefingSection();
    public TutorialSection TutorialSection = new TutorialSection();

    // extended custom sections
    public Ext_MapSection Ext_MapSection = new Ext_MapSection();
    //public Ext_GlobalsSection GlobalNamesSection = Ext_GlobalsSection.Default;
    public Ext_CommentsSection Ext_CommentsSection = new Ext_CommentsSection();

    // a performance measure to store the cell occupancy list for all IEntity objects, to avoid expensive lookup
    public MapOccupancyList MapOccupancyList = new MapOccupancyList();

    /*
    public enum ReplaceOption
    {
      // ask the user
      ASK,

      // add the object over the existing object
      ADD,

      // remove the old object and add the new object in its space
      REPLACE,

      // do not add the new object
      ABORT
    }
    */
    public Map(Rules rules)
    {
      AttachedRules = rules;
      HouseSections = new HouseSection[rules.Houses.Count];
      for (int i = 0; i < HouseSections.Length; i++)
      {
        HouseSections[i] = new HouseSection();
      }
    }

    public void Clear()
    {
      SourceFile = null;
      WriteDefaultSections();
      Dirty = false;
    }

    private void WriteDefaultSections()
    {
      IniFile.IniSection blankSection = new IniFile.IniSection();
      BasicSection.Read(blankSection);
      for (int i = 0; i < HouseSections.Length; i++)
      {
        HouseSections[i].Read(blankSection);
      }
      MapSection.Read(blankSection);
      MapPackSection.Read(blankSection);
      OverlayPackSection.Read(blankSection);
      TerrainSection.Read(blankSection);
      InfantrySection.Read(blankSection);
      UnitSection.Read(blankSection);
      ShipSection.Read(blankSection);
      StructureSection.Read(blankSection);
      BaseSection.Read(this, blankSection);
      SmudgeSection.Read(blankSection);
      TeamTypeSection.ReadFirst(blankSection);
      TriggerSection.Read(this, blankSection);
      TeamTypeSection.ReadNext(this, blankSection);
      WaypointSection.Read(this, blankSection);
      CellTriggerSection.Read(this, blankSection);
      BriefingSection.Read(blankSection);
      TutorialSection.Read(blankSection);

      Ext_MapSection.Read(blankSection);
      Ext_CommentsSection.Read(blankSection);
    }

    public void Load(IniFile f, string path = null)
    {
      SourceFile = f;
      FilePath = path;

      // try to follow the same order as Read_Scenario_INI() in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/SCENARIO.CPP

      /* [Basic] */
      BasicSection.Read(f.GetOrCreateSection("Basic"));

      /* Houses */
      for (int i = 0; i < HouseSections.Length; i++)
      {
        string hname = AttachedRules.Houses.GetName(i);
        IniFile.IniSection section = f.GetSection(hname);
        if (section != null)
        {
          HouseSections[i].Read(section);
        }
      }

      /* [TeamTypes] !!! Split loading to two parts because TeamTypes can reference Triggers */
      TeamTypeSection.ReadFirst(f.GetOrCreateSection("TeamTypes"));

      /* [Trigs] */
      TriggerSection.Read(this, f.GetOrCreateSection("Trigs"));

      /* [TeamTypes] !!! Split loading to two parts because TeamTypes can reference Triggers */
      TeamTypeSection.ReadNext(this, f.GetOrCreateSection("TeamTypes"));

      /* [MAP] */
      MapSection.Read(f.GetOrCreateSection("Map"));

      /* [TERRAIN] */
      TerrainSection.Read(f.GetOrCreateSection("TERRAIN"));

      /* [MapPack] */
      MapPackSection.Read(f.GetOrCreateSection("MapPack"));

      /* [UNITS] */
      UnitSection.Read(f.GetOrCreateSection("UNITS"));

      /* [AIRCRAFT] */
      // bugged, don't use

      /* [SHIPS] */
      ShipSection.Read(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Read(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      StructureSection.Read(f.GetOrCreateSection("STRUCTURES"));

      /* [Base] */
      BaseSection.Read(this, f.GetOrCreateSection("Base"));

      /* [OverlayPack] */
      OverlayPackSection.Read(f.GetOrCreateSection("OverlayPack"));

      /* [SMUDGE] */
      SmudgeSection.Read(f.GetOrCreateSection("SMUDGE"));

      /* [Waypoints] */
      WaypointSection.Read(this, f.GetOrCreateSection("Waypoints"));

      /* [CellTriggers] */
      CellTriggerSection.Read(this, f.GetOrCreateSection("CellTriggers"));

      /* [Tutorial] (original: use Mission.ini) */
      TutorialSection.Read(f.GetOrCreateSection("Tutorial"));

      /* [Briefing] */
      BriefingSection.Read(f.GetOrCreateSection("Briefing"));

      // extensions (begin with Ext_)
      Ext_MapSection.Read(f.GetOrCreateSection("Ext_Map"));
      Ext_CommentsSection.Read(f.GetOrCreateSection("Ext_Comments"));

      MapOccupancyList.Reset(Ext_MapSection.FullCellCount);
    }

    public void Update(bool keepExtensions = true)
    {
      IniFile f = SourceFile;

      // try to follow the same order as Read_Scenario_INI() in https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/SCENARIO.CPP

      /* [Basic] */
      BasicSection.Update(f.GetOrCreateSection("Basic"));

      /* Houses */
      for (int i = 0; i < HouseSections.Length; i++)
      {
        string hname = AttachedRules.Houses.GetName(i);
        HouseSections[i].Update(f.GetOrCreateSection(hname));
      }

      /* [TeamTypes] */
      TeamTypeSection.Update(this, f.GetOrCreateSection("TeamTypes"));

      /* [Trigs] */
      TriggerSection.Update(this, f.GetOrCreateSection("Trigs"));

      /* [MAP] */
      MapSection.Update(f.GetOrCreateSection("Map"));

      /* [TERRAIN] */
      TerrainSection.Update(f.GetOrCreateSection("TERRAIN"));

      /* [MapPack] */
      MapPackSection.Update(f.GetOrCreateSection("MapPack"));

      /* [UNITS] */
      UnitSection.Update(f.GetOrCreateSection("UNITS"));

      /* [AIRCRAFT] */
      // bugged, don't use

      /* [SHIPS] */
      ShipSection.Update(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Update(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      StructureSection.Update(f.GetOrCreateSection("STRUCTURES"));

      /* [Base] */
      BaseSection.Update(this, f.GetOrCreateSection("Base"));

      /* [OverlayPack] */
      OverlayPackSection.Update(f.GetOrCreateSection("OverlayPack"));

      /* [SMUDGE] */
      SmudgeSection.Update(f.GetOrCreateSection("SMUDGE"));

      /* [Waypoints] */
      WaypointSection.Update(f.GetOrCreateSection("Waypoints"));

      /* [CellTriggers] */
      CellTriggerSection.Update(f.GetOrCreateSection("CellTriggers"));

      /* [Tutorial] (original: use Mission.ini) */
      TutorialSection.Update(f.GetOrCreateSection("Tutorial"));

      /* [Briefing] */
      BriefingSection.Update(f.GetOrCreateSection("Briefing"));

      // extensions (begin with Ext_)
      if (keepExtensions)
      {
        Ext_MapSection.Update(f.GetOrCreateSection("Ext_Map"));
        Ext_CommentsSection.Update(f.GetOrCreateSection("Ext_Comments"));
      }
    }

    public void Save(string path, bool keepExtensions = true)
    {
      IniFile f = SourceFile;
      Update(keepExtensions);
      f.Save(path);

      // Reload
      //using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      //{
      //  Load(new IniFile(fs, Path.GetFileName(path), 0, (int)fs.Length));
      //}
      Dirty = false;
    }

    public void RebuildOccupancyList(MapCache cache, VirtualFileSystem vfs)
    {
      MapOccupancyList.Rebuild(this, cache, vfs);
    }

    public void Shift(MapCache cache, VirtualFileSystem vfs, int x, int y)
    {
      if (x == 0 && y == 0) { return; }
      Shift(UnitSection.UnitList, x, y);
      Shift(InfantrySection.InfantryList, x, y);
      Shift(ShipSection.ShipList, x, y);
      Shift(StructureSection.StructureList, x, y);
      Shift(BaseSection.BaseList, x, y);
      Shift(WaypointSection.WaypointList, x, y, true);
      Shift(TerrainSection.TerrainList, x, y);
      Shift(SmudgeSection.SmudgeList, x, y);

      // Templates
      Shift(MapPackSection.Template, MapPack.defaultMapPackTemplates, x, y);
      Shift(MapPackSection.Tile, MapPack.defaultMapPackTiles, x, y);

      // Overlays
      Shift(OverlayPackSection.Overlay, OverlayPack.defaultOverlayPackOverlays, x, y);

      // CellTriggers, extra step because CellTriggerInfo has its own Cell variable.
      Shift(CellTriggerSection.Triggers, CellTriggerSection.defaultTriggers, x, y);
      for (int i = 0; i < CellTriggerSection.Triggers.Length; i++)
      {
        CellTriggerInfo ctrig = CellTriggerSection.Triggers[i];
        if (ctrig != null)
        {
          ctrig.Cell = i;
        }
      }

      RebuildOccupancyList(cache, vfs);
      Dirty = true;
      InvalidateObjectDisplay?.Invoke();
      InvalidateTemplateDisplay?.Invoke();
    }

    private void Shift<T>(List<T> list, int x, int y, bool isWaypoint = false) where T : ILocatable
    {
      for (int i = list.Count - 1; i >= 0; i--)
      {
        T item = list[i];
        if (!isWaypoint || item.Cell != -1)
        {
          int cx = this.CellX(item.Cell) + x;
          int cy = this.CellY(item.Cell) + y;
          if (this.IsCellInMap(cx, cy))
          {
            item.Cell = this.CellNumber(cx, cy);
          }
          else
          {
            if (!isWaypoint)
              list.RemoveAt(i);
            else
              item.Cell = -1;
          }
        }
      }
    }

    private void Shift<T>(T[] list, T[] defaultList, int x, int y)
    {
      T[] copy = new T[list.Length];

      if (defaultList != null)
      {
        int pos = 0;
        while (pos < copy.Length)
        {
          int len = Math.Min(defaultList.Length, copy.Length - pos);
          Array.Copy(defaultList, 0, copy, pos, len);
          pos += len;
        }
      }

      for (int i = 0; i < list.Length; i++)
      {
        int cx = this.CellX(i) + x;
        int cy = this.CellY(i) + y;
        if (this.IsCellInMap(cx, cy))
        {
          copy[this.CellNumber(cx, cy)] = list[i];
        }
      }

      Array.Copy(copy, 0, list, 0, copy.Length);
    }

    public List<IEntity> Pick(int x, int y)
    {
      return MapOccupancyList.Pick(this, x, y);
    }

    public void InsertEntity(MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo entityInfo)
    {
      int cx = entityInfo.X;
      int cy = entityInfo.Y;
      int c = this.CellNumber(cx, cy);

      EnvironmentRenderer.CheckTheatre(this, cache, vfs, out TheaterType tt, out PalFile _);

      if (entityInfo.Type is TemplateType tem)
      {
        if (cache.GetOrOpen(tem.ID + tt.Extension, vfs, out TmpFile tmpFile))
        {
          if (entityInfo.TemplateCell == 0xFF)
          {
            byte tile = 0;
            for (int yd = 0; yd < tmpFile.BlockHeight; yd++)
              for (int xd = 0; xd < tmpFile.BlockWidth; xd++)
              {
                if (tmpFile.Images[tile] != null) // only replace tiles if there is an image
                {
                  if (cx + xd < Ext_MapSection.FullWidth && cy + yd < Ext_MapSection.FullHeight) // only paint within the map
                  {
                    MapPackSection.Template[this.CellNumber(cx + xd, cy + yd)] = (ushort)Templates.GetID(tem.ID);
                    MapPackSection.Tile[this.CellNumber(cx + xd, cy + yd)] = tile;
                  }
                }
                tile++;
              }
          }
          else
          {
            // place just a single cell
            if (entityInfo.TemplateCell < tmpFile.Images.Count && tmpFile.Images[entityInfo.TemplateCell] != null) // only replace tiles if there is an image
            {
              MapPackSection.Template[this.CellNumber(cx, cy)] = (ushort)Templates.GetID(tem.ID);
              MapPackSection.Tile[this.CellNumber(cx, cy)] = entityInfo.TemplateCell;
            }
          }
          MapOccupancyList.UpdateEntity(this, cache, vfs, tem);
        }
      }
      else if (entityInfo.Type is OverlayType ovl)
      {
        int id = Overlays.GetID(ovl.ID);
        if (id >= 0)
        {
          OverlayPackSection.Overlay[c] = (byte)id;
          MapOccupancyList.UpdateEntity(this, cache, vfs, ovl);
        }
      }
      else if (entityInfo.Type is TerrainType terr)
      {
        TerrainInfo terrain = new TerrainInfo() { ID = terr.ID, Cell = c };
        TerrainSection.TerrainList.Add(terrain);
        MapOccupancyList.UpdateEntity(this, cache, vfs, terrain);
      }
      else if (entityInfo.Type is SmudgeType smud)
      {
        SmudgeInfo smudge = new SmudgeInfo() { ID = smud.ID, Cell = c };
        SmudgeSection.SmudgeList.Add(smudge);
        MapOccupancyList.UpdateEntity(this, cache, vfs, smudge);
      }
      else if (entityInfo.Type is InfantryType inft)
      {
        InfantryInfo infantry = new InfantryInfo()
        {
          ID = inft.ID,
          Cell = c,
          Health = entityInfo.Health,
          Facing = entityInfo.Facing,
          Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
          Tag = entityInfo.Tag,
          Mission = entityInfo.Mission.Name,
          SubCell = entityInfo.SubCell
        };
        InfantrySection.InfantryList.Add(infantry);
        MapOccupancyList.UpdateEntity(this, cache, vfs, infantry);
      }
      else if (entityInfo.Type is UnitType unit)
      {
        UnitInfo uinfo = new UnitInfo()
        {
          ID = unit.ID,
          Cell = c,
          Health = entityInfo.Health,
          Facing = entityInfo.Facing,
          Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
          Tag = entityInfo.Tag,
          Mission = entityInfo.Mission.Name
        };
        UnitSection.UnitList.Add(uinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, uinfo);
      }
      else if (entityInfo.Type is ShipType ship)
      {
        ShipInfo sinfo = new ShipInfo()
        {
          ID = ship.ID,
          Cell = c,
          Health = entityInfo.Health,
          Facing = entityInfo.Facing,
          Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
          Tag = entityInfo.Tag,
          Mission = entityInfo.Mission.Name
        };
        ShipSection.ShipList.Add(sinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, sinfo);
      }
      else if (entityInfo.Type is StructureType stru)
      {
        if (entityInfo.IsBase)
        {
          BaseInfo binfo = new BaseInfo() { ID = stru.ID, Cell = c };
          BaseSection.BaseList.Add(binfo);
          MapOccupancyList.UpdateEntity(this, cache, vfs, binfo);
        }
        else
        {
          StructureInfo sinfo = new StructureInfo()
          {
            ID = stru.ID,
            Cell = c,
            Health = entityInfo.Health,
            Facing = entityInfo.Facing,
            Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
            Tag = entityInfo.Tag,
            AIRepairable = entityInfo.AIRepairable,
            AISellable = entityInfo.AISellable
          };
          StructureSection.StructureList.Add(sinfo);
          MapOccupancyList.UpdateEntity(this, cache, vfs, sinfo);
        }
      }
      else if (entityInfo.Type is WaypointInfo wayp)
      {
        wayp.Cell = c;
        MapOccupancyList.UpdateEntity(this, cache, vfs, wayp);
      }
      else if (entityInfo.Type is CellTriggerInfo celt)
      {

        CellTriggerInfo ncelt = new CellTriggerInfo(this)
        {
           ID = celt.ID,
           Cell = c
        };
        CellTriggerSection.Set(ncelt);
        MapOccupancyList.UpdateEntity(this, cache, vfs, ncelt);
      }
      Dirty = true;
    }

    public void OnEntityModified(MapCache cache, VirtualFileSystem vfs, IEntity entity)
    {
      MapOccupancyList.UpdateEntity(this, cache, vfs, entity);
      Dirty = true;
    }

    public void DeleteEntity(MapCache cache, VirtualFileSystem vfs, IEntity entity, int x = 0, int y = 0)
    {
      if (entity == null) { return; }
      int c = this.CellNumber(x, y);

      if (entity is TemplateType tmpl)
      {
        // set to clear 
        MapPackSection.Template[c] = 0xFFFF;
        MapOccupancyList.UpdateEntity(this, cache, vfs, tmpl);
      }
      else if (entity is OverlayType ovly)
      {
        OverlayPackSection.Overlay[c] = 0xFF;
        MapOccupancyList.UpdateEntity(this, cache, vfs, ovly);
      }
      else if (entity is TerrainInfo terr)
      {
        TerrainSection.TerrainList.Remove(terr);
        MapOccupancyList.RemoveEntity(terr);
      }
      else if (entity is SmudgeInfo smud)
      {
        SmudgeSection.SmudgeList.Remove(smud);
        MapOccupancyList.RemoveEntity(smud);
      }
      else if (entity is InfantryInfo inft)
      {
        InfantrySection.InfantryList.Remove(inft);
        MapOccupancyList.RemoveEntity(inft);
      }
      else if (entity is UnitInfo unit)
      {
        UnitSection.UnitList.Remove(unit);
        MapOccupancyList.RemoveEntity(unit);
      }
      else if (entity is ShipInfo ship)
      {
        ShipSection.ShipList.Remove(ship);
        MapOccupancyList.RemoveEntity(ship);
      }
      else if (entity is BaseInfo @base)
      {
        BaseSection.BaseList.Remove(@base);
        MapOccupancyList.RemoveEntity(@base);
      }
      else if (entity is StructureInfo stru)
      {
        StructureSection.StructureList.Remove(stru);
        MapOccupancyList.RemoveEntity(stru);
      }
      else if (entity is WaypointInfo wayp)
      {
        wayp.Cell = -1;
        MapOccupancyList.RemoveEntity(wayp);
      }
      else if (entity is CellTriggerInfo celt)
      {
        CellTriggerSection.Remove(celt.Cell);
        MapOccupancyList.RemoveEntity(celt);
      }

      Dirty = true;
    }
  }
}
