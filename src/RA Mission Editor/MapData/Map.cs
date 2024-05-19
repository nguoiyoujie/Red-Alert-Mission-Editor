using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;

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
    public ActionDelegate<EditorSelectMode> InvalidateSelectionList;

    public readonly Rules AttachedRules;

    public BasicSection BasicSection = new BasicSection();
    public HouseSection[] HouseSections;
    public MapSection MapSection = new MapSection();
    public MapPack MapPackSection = new MapPack();
    public OverlayPack OverlayPackSection = new OverlayPack();
    public TerrainSection TerrainSection = new TerrainSection();
    public InfantrySection InfantrySection = new InfantrySection();
    public UnitSection UnitSection = new UnitSection();
    public VesselSection VesselSection = new VesselSection();
    public BuildingSection BuildingSection = new BuildingSection();
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
    public int LastClickedCell = -1;

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
      LastClickedCell = -1;
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
      VesselSection.Read(blankSection);
      BuildingSection.Read(blankSection);
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
      VesselSection.Read(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Read(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      BuildingSection.Read(f.GetOrCreateSection("STRUCTURES"));

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
      VesselSection.Update(f.GetOrCreateSection("SHIPS"));

      /* [INFANTRY] */
      InfantrySection.Update(f.GetOrCreateSection("INFANTRY"));

      /* [STRUCTURES] */
      BuildingSection.Update(f.GetOrCreateSection("STRUCTURES"));

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

    public bool VerifyMap(List<string> errors)
    {
      if (errors == null) { errors = new List<string>(128); }
      int initialcount = errors.Count;
      // Verify 
      foreach (var unit in UnitSection.EntityList)
      {
        if (AttachedRules.Units.GetID(unit.ID) == -1)
        {
          errors.Add("Unit '" + unit.ID + "' has invalid ID");
        }
        if (!this.IsCellInMap(unit.Cell))
        {
          errors.Add("Unit '" + unit.ID + "' has invalid cell (" + unit.Cell + ")");
        }
        if (Missions.GetID(unit.Mission) == -1)
        {
          errors.Add("Unit '" + unit.ID + "' has invalid mission (" + unit.Mission + ")");
        }
        if (AttachedRules.Houses.GetHouseID(unit.Owner) == -1)
        {
          errors.Add("Unit '" + unit.ID + "' has invalid owner (" + unit.Owner + ")");
        }
        if (!string.IsNullOrEmpty(unit.Tag) && !"none".Equals(unit.Tag, StringComparison.OrdinalIgnoreCase))
        {
          bool found =false;
          foreach (var trig in TriggerSection.TriggerList)
          {
            if (trig.Name == unit.Tag)
          {
              found = true;
              break;
            }
          }
          if (!found)
          {
            errors.Add("Unit '" + unit.ID + "' has invalid tag (" + unit.Tag + ")");
          }
        }
      }

      foreach (var inft in InfantrySection.EntityList)
      {
        if (AttachedRules.Infantries.GetID(inft.ID) == -1)
        {
          errors.Add("Infantry '" + inft.ID + "' has invalid ID");
        }
        if (!this.IsCellInMap(inft.Cell))
        {
          errors.Add("Infantry '" + inft.ID + "' has invalid cell (" + inft.Cell + ")");
        }
        if (inft.SubCell > 4)
        {
          errors.Add("Infantry '" + inft.ID + "' has invalid subcell (" + inft.SubCell + ")");
        }
        if (Missions.GetID(inft.Mission) == -1)
        {
          errors.Add("Infantry '" + inft.ID + "' has invalid mission (" + inft.Mission + ")");
        }
        if (AttachedRules.Houses.GetHouseID(inft.Owner) == -1)
        {
          errors.Add("Infantry '" + inft.ID + "' has invalid owner (" + inft.Owner + ")");
        }
        if (!string.IsNullOrEmpty(inft.Tag) && !"none".Equals(inft.Tag, StringComparison.OrdinalIgnoreCase))
        {
          bool found = false;
          foreach (var trig in TriggerSection.TriggerList)
          {
            if (trig.Name == inft.Tag)
            {
              found = true;
              break;
            }
          }
          if (!found)
          {
            errors.Add("Infantry '" + inft.ID + "' has invalid tag (" + inft.Tag + ")");
          }
        }
      }

      foreach (var vess in VesselSection.EntityList)
      {
        if (AttachedRules.Vessels.GetID(vess.ID) == -1)
        {
          errors.Add("Vessel '" + vess.ID + "' has invalid ID");
        }
        if (!this.IsCellInMap(vess.Cell))
        {
          errors.Add("Vessel '" + vess.ID + "' has invalid cell (" + vess.Cell + ")");
        }
        if (Missions.GetID(vess.Mission) == -1)
        {
          errors.Add("Vessel '" + vess.ID + "' has invalid mission (" + vess.Mission + ")");
        }
        if (AttachedRules.Houses.GetHouseID(vess.Owner) == -1)
        {
          errors.Add("Vessel '" + vess.ID + "' has invalid owner (" + vess.Owner + ")");
        }
        if (!string.IsNullOrEmpty(vess.Tag) && !"none".Equals(vess.Tag, StringComparison.OrdinalIgnoreCase))
        {
          bool found = false;
          foreach (var trig in TriggerSection.TriggerList)
          {
            if (trig.Name == vess.Tag)
            {
              found = true;
              break;
            }
          }
          if (!found)
          {
            errors.Add("Vessel '" + vess.ID + "' has invalid tag (" + vess.Tag + ")");
          }
        }
      }

      foreach (var bldg in BuildingSection.EntityList)
      {
        if (AttachedRules.Buildings.GetID(bldg.ID) == -1)
        {
          errors.Add("Building '" + bldg.ID + "' has invalid ID");
        }
        if (!this.IsCellInMap(bldg.Cell))
        {
          errors.Add("Building '" + bldg.ID + "' has invalid cell (" + bldg.Cell + ")");
        }
        if (AttachedRules.Houses.GetHouseID(bldg.Owner) == -1)
        {
          errors.Add("Building '" + bldg.ID + "' has invalid owner (" + bldg.Owner + ")");
        }
        if (!string.IsNullOrEmpty(bldg.Tag) && !"none".Equals(bldg.Tag, StringComparison.OrdinalIgnoreCase))
        {
          bool found = false;
          foreach (var trig in TriggerSection.TriggerList)
          {
            if (trig.Name == bldg.Tag)
            {
              found = true;
              break;
            }
          }
          if (!found)
          {
            errors.Add("Building '" + bldg.ID + "' has invalid tag (" + bldg.Tag + ")");
          }
        }
      }

      foreach (var bldg in BaseSection.EntityList)
      {
        if (AttachedRules.Buildings.GetID(bldg.ID) == -1)
        {
          errors.Add("Base '" + bldg.ID + "' has invalid ID");
        }
        if (!this.IsCellInMap(bldg.Cell))
        {
          errors.Add("Base '" + bldg.ID + "' has invalid cell (" + bldg.Cell + ")");
        }
      }
      if (AttachedRules.Houses.GetHouseID(BaseSection.Player) == -1)
      {
        errors.Add("The Base Section has invalid owner (" + BaseSection.Player + ")");
      }

      if (errors.Count == initialcount)
      {
        errors.Add("No errors in map!");
        return true;
      }
      else
      {
        errors.Add((errors.Count - initialcount) + " errors in map!");
        return true;
      }
    }

    public void RebuildOccupancyList(MapCache cache, VirtualFileSystem vfs)
    {
      MapOccupancyList.Rebuild(this, cache, vfs);
    }

    public void ClearTemplateOnCells(List<int> cells)
    {
      foreach (int cell in cells)
      {
        if (!this.IsCellInMap(cell)) { continue; }

        // Map Pack
        MapPackSection.Template[cell] = MapPack.defaultMapPackTemplates[0];
        MapPackSection.Tile[cell] = MapPack.defaultMapPackTiles[0];
      }
      Dirty = true;
      InvalidateTemplateDisplay?.Invoke();
    }


    public void ClearObjectsOnCells(MapCache cache, VirtualFileSystem vfs, List<int> cells)
    {
      foreach (int cell in cells)
      {
        if (!this.IsCellInMap(cell)) { continue; }
        ClearObjectOnCell(UnitSection.EntityList, cell);
        ClearObjectOnCell(InfantrySection.EntityList, cell);
        ClearObjectOnCell(VesselSection.EntityList, cell);
        ClearObjectOnCell(BuildingSection.EntityList, cell);
        ClearObjectOnCell(BaseSection.EntityList, cell);
        ClearObjectOnCell(WaypointSection.WaypointList, cell, true);
        ClearObjectOnCell(TerrainSection.EntityList, cell);
        ClearObjectOnCell(SmudgeSection.EntityList, cell);

        // Overlays
        OverlayPackSection.Overlay[cell] = OverlayPack.defaultOverlayPackOverlays[0];

        // CellTriggers, extra step because CellTriggerInfo has its own Cell variable.
        CellTriggerSection.Triggers[cell] = CellTriggerSection.defaultTriggers[0];
      }
      RebuildOccupancyList(cache, vfs);
      Dirty = true;
      InvalidateObjectDisplay?.Invoke();
    }

    public void Shift(MapCache cache, VirtualFileSystem vfs, int x, int y)
    {
      if (x == 0 && y == 0) { return; }
      Shift(UnitSection.EntityList, x, y);
      Shift(InfantrySection.EntityList, x, y);
      Shift(VesselSection.EntityList, x, y);
      Shift(BuildingSection.EntityList, x, y);
      Shift(BaseSection.EntityList, x, y);
      Shift(WaypointSection.WaypointList, x, y, true);
      Shift(TerrainSection.EntityList, x, y);
      Shift(SmudgeSection.EntityList, x, y);

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

    private void ClearObjectOnCell<T>(List<T> list, int cell, bool isWaypoint = false) where T : ILocatable
    {
      for (int i = list.Count - 1; i >= 0; i--)
      {
        T item = list[i];
        if (item.Cell == cell)
        {
          if (!isWaypoint)
            list.RemoveAt(i);
          else
            item.Cell = -1;
        }
      }
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
      if (entityInfo.Type == null) { return; }

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
        TerrainSection.EntityList.Add(terrain);
        MapOccupancyList.UpdateEntity(this, cache, vfs, terrain);
      }
      else if (entityInfo.Type is SmudgeType smud)
      {
        SmudgeInfo smudge = new SmudgeInfo() { ID = smud.ID, Cell = c };
        SmudgeSection.EntityList.Add(smudge);
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
        InfantrySection.EntityList.Add(infantry);
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
        UnitSection.EntityList.Add(uinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, uinfo);
      }
      else if (entityInfo.Type is VesselType vessel)
      {
        VesselInfo sinfo = new VesselInfo()
        {
          ID = vessel.ID,
          Cell = c,
          Health = entityInfo.Health,
          Facing = entityInfo.Facing,
          Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
          Tag = entityInfo.Tag,
          Mission = entityInfo.Mission.Name
        };
        VesselSection.EntityList.Add(sinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, sinfo);
      }
      else if (entityInfo.Type is BuildingType building)
      {
        if (entityInfo.IsBase)
        {
          BaseInfo binfo = new BaseInfo() { ID = building.ID, Cell = c };
          BaseSection.EntityList.Add(binfo);
          MapOccupancyList.UpdateEntity(this, cache, vfs, binfo);
        }
        else
        {
          BuildingInfo sinfo = new BuildingInfo()
          {
            ID = building.ID,
            Cell = c,
            Health = entityInfo.Health,
            Facing = entityInfo.Facing,
            Owner = AttachedRules.Houses.GetHouse(entityInfo.Owner).Name,
            Tag = entityInfo.Tag,
            AIRepairable = entityInfo.AIRepairable,
            AISellable = entityInfo.AISellable
          };
          BuildingSection.EntityList.Add(sinfo);
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
      else if (entityInfo.Type is ExtractType extr)
      {
        extr.Extract.Paste(this, cx, cy);
        RebuildOccupancyList(cache, vfs);
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
        TerrainSection.EntityList.Remove(terr);
        MapOccupancyList.RemoveEntity(terr);
      }
      else if (entity is SmudgeInfo smud)
      {
        SmudgeSection.EntityList.Remove(smud);
        MapOccupancyList.RemoveEntity(smud);
      }
      else if (entity is InfantryInfo inft)
      {
        InfantrySection.EntityList.Remove(inft);
        MapOccupancyList.RemoveEntity(inft);
      }
      else if (entity is UnitInfo unit)
      {
        UnitSection.EntityList.Remove(unit);
        MapOccupancyList.RemoveEntity(unit);
      }
      else if (entity is VesselInfo vessel)
      {
        VesselSection.EntityList.Remove(vessel);
        MapOccupancyList.RemoveEntity(vessel);
      }
      else if (entity is BaseInfo @base)
      {
        BaseSection.EntityList.Remove(@base);
        MapOccupancyList.RemoveEntity(@base);
      }
      else if (entity is BuildingInfo building)
      {
        BuildingSection.EntityList.Remove(building);
        MapOccupancyList.RemoveEntity(building);
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
