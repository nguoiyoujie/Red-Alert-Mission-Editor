using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

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
    public VoidDelegate UndoRedoChanged;
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

    public TrackedActionsList TrackedActions;

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
      TrackedActions = new TrackedActionsList(this);
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
      TrackedActions.Clear();
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
      Update(SourceFile, keepExtensions);
    }

    public void Update(IniFile f, bool keepExtensions = true)
    {
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
            if (unit.Tag.Equals(trig.Name, StringComparison.OrdinalIgnoreCase))
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
            if (inft.Tag.Equals(trig.Name, StringComparison.OrdinalIgnoreCase))
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
            if (vess.Tag.Equals(trig.Name, StringComparison.OrdinalIgnoreCase))
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
            if (bldg.Tag.Equals(trig.Name, StringComparison.OrdinalIgnoreCase))
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

      List<string> blgs = new List<string>(4);
      for (int c = 0; c < MapOccupancyList.OccupancyList.Length; c++)
      {
        // check if any two buildings are occupying the same cell
        List<IEntity> list = MapOccupancyList.OccupancyList[c];
        if (list != null)
        {
          blgs.Clear();
          foreach (IEntity entity in list)
          {
            if (entity is BuildingInfo bldg)
            {
              // OccupancyList is only for image refresh. Check the building (excluding the bib) actually occupies the cell
              BuildingType btype = bldg.GetEntityType(AttachedRules);
              foreach (Point p in btype.Occupancy)
              {
                if (MapHelper.CellNumber(this, MapHelper.CellX(this, bldg.Cell) + p.X, MapHelper.CellY(this, bldg.Cell) + p.Y) == c)
                {
                  blgs.Add(bldg.ID); // the cell is actually occupied by the building
                  break;
                }
              }
            }
          }

          if (blgs.Count > 1)
          {
            string sblgs = string.Join(", ", blgs);
            errors.Add("Cell @ {" + MapHelper.CellX(this, c) + "," + MapHelper.CellY(this, c) + "} has multiple overlapping buildings (" + sblgs + ")");
          }
        }
      }

      foreach (var trigger in CellTriggerSection.Triggers)
      {
        if (trigger != null && trigger.ID != null)
        {
          bool found = false;
          foreach (var trig in TriggerSection.TriggerList)
          {
            if (trigger.ID.Equals(trig.Name, StringComparison.OrdinalIgnoreCase))
            {
              found = true;
              break;
            }
          }
          if (!found)
          {
            errors.Add("Cell Trigger @ {" + MapHelper.CellX(this, trigger.Cell) + "," + MapHelper.CellY(this, trigger.Cell) + "} has invalid tag (" + trigger.ID + ")");
          }
        }
      }

      foreach (var team in TeamTypeSection.TeamTypeList)
      {
        if (team.ScriptList.Count > 17) // experimented. It crashes at 18
        {
          errors.Add("Teamtype '" + team.Name + "' exceeds allowed script count of 17! (" + team.ScriptList.Count  + ")");
        }

        if (team.TechnoList.Count > 5)
        {
          errors.Add("Teamtype '" + team.Name + "' exceeds allowed techno count of 5! (" + team.TechnoList.Count + ")");
        }

        int line = 0;
        foreach (var step in team.ScriptList)
        {
          if (step.ScriptType == 4 && step.Parameter.Value is int c) // "04 - Move To Cell"
          {
            if (!MapHelper.IsCellInMap(this, c))
            {
              errors.Add("Teamtype '" + team.Name + "': Script step " + line + " references an invalid cell number! (" + c + ")");
            }
          }
          line++;
        }
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

    public void ClearTemplateOnCells(MapCache cache, VirtualFileSystem vfs, List<int> cells)
    {
      PaintTemplateAction action = new PaintTemplateAction(this, cache, vfs);
      action.Description = "Clear Template Cells";
      action.SnapshotOld();
      int change = 0;
      foreach (int cell in cells)
      {
        if (this.IsCellInMap(cell))
        {
          // Map Pack
          MapPackSection.Template[cell] = MapPack.defaultMapPackTemplates[0];
          MapPackSection.Tile[cell] = MapPack.defaultMapPackTiles[0];
          change++;
        }
      }
      if (change > 0)
      {
        Dirty = true;
        InvalidateTemplateDisplay?.Invoke();
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
    }

    public void ClearObjectsOnCells(MapCache cache, VirtualFileSystem vfs, List<int> cells)
    {
      FullMapReplaceAction action = new FullMapReplaceAction(this, cache, vfs);
      action.Description = "Clear Objects";
      action.SnapshotOld();
      int change = 0;
      foreach (int cell in cells)
      {
        if (!this.IsCellInMap(cell)) { continue; }
        change += ClearObjectOnCell(UnitSection.EntityList, cell);
        change += ClearObjectOnCell(InfantrySection.EntityList, cell);
        change += ClearObjectOnCell(VesselSection.EntityList, cell);
        change += ClearObjectOnCell(BuildingSection.EntityList, cell);
        change += ClearObjectOnCell(BaseSection.EntityList, cell);
        change += ClearObjectOnCell(WaypointSection.WaypointList, cell, true);
        change += ClearObjectOnCell(TerrainSection.EntityList, cell);
        change += ClearObjectOnCell(SmudgeSection.EntityList, cell);

        // Overlays
        if (OverlayPackSection.Overlay[cell] != OverlayPack.defaultOverlayPackOverlays[0])
        {
          OverlayPackSection.Overlay[cell] = OverlayPack.defaultOverlayPackOverlays[0];
          change++;
        }

        // CellTriggers, extra step because CellTriggerInfo has its own Cell variable.
        if (CellTriggerSection.Triggers[cell] != CellTriggerSection.defaultTriggers[0])
        {
          CellTriggerSection.Triggers[cell] = CellTriggerSection.defaultTriggers[0];
          change++;
        }
      }
      if (change > 0)
      {
        RebuildOccupancyList(cache, vfs);
        Dirty = true;
        InvalidateObjectDisplay?.Invoke();
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
    }

    public void Shift(MapCache cache, VirtualFileSystem vfs, int x, int y)
    {
      if (x == 0 && y == 0) { return; }
      FullMapReplaceAction action = new FullMapReplaceAction(this, cache, vfs);
      action.Description = "Map Shift X" + (x >= 0 ? "+" : "-") + x + " Y" + (y >= 0 ? "+" : "-") + y;
      action.SnapshotOld();
      // will always change
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

      foreach (var team in TeamTypeSection.TeamTypeList)
      {
        for (int i = 0; i < team.ScriptList.Count; i++)
        {
          if (team.ScriptList[i].ScriptType == 4 && team.ScriptList[i].Parameter.Value is int c) // hardcoded: "04 - Move To Cell"
          {
            int xs = this.CellX(c) + x;
            int ys = this.CellY(c) + y;
            int cs = this.CellNumber(xs, ys);

            TeamTypeInfo.ScriptInfo sinfo = new TeamTypeInfo.ScriptInfo { ScriptType = team.ScriptList[i].ScriptType, Parameter = TeamTypeInfo.SelectParameterInfo(ScriptParameterType.INTEGER) };
            sinfo.Parameter.UpdateValue(cs, this);
            team.ScriptList[i] = sinfo;
          }
        }
      }

      MapSection.X = Math.Max(0, MapSection.X + x);
      MapSection.Y = Math.Max(0, MapSection.Y + y);
      MapSection.Width = Math.Min(127 - MapSection.X, MapSection.Width);
      MapSection.Height = Math.Min(127 - MapSection.Y, MapSection.Height);

      RebuildOccupancyList(cache, vfs);
      Dirty = true;
      InvalidateObjectDisplay?.Invoke();
      InvalidateTemplateDisplay?.Invoke();
      action.SnapshotNew();
      TrackedActions.Push(action);
    }

    private int ClearObjectOnCell<T>(List<T> list, int cell, bool isWaypoint = false) where T : ILocatable
    {
      int count = 0;
      for (int i = list.Count - 1; i >= 0; i--)
      {
        T item = list[i];
        if (item.Cell == cell)
        {
          if (!isWaypoint)
          {
            list.RemoveAt(i);
            count++;
          }
          else
          {
            if (item.Cell != -1)
            {
              item.Cell = -1;
              count++;
            }
          }
        }
      }
      return count;
    }

    private int Shift<T>(List<T> list, int x, int y, bool isWaypoint = false) where T : ILocatable
    {
      int count = 0;
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
            count++;
          }
          else
          {
            if (!isWaypoint)
            {
              list.RemoveAt(i);
              count++;
            }
            else
            {
              if (item.Cell != -1)
              {
                item.Cell = -1;
                count++;
              }
            }
          }
        }
      }
      return count;
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

    public List<IEntity> Pick(int x, int y, int subcell)
    {
      return MapOccupancyList.Pick(this, x, y, subcell);
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
          bool changed = false;
          PaintTemplateAction action = new PaintTemplateAction(this, cache, vfs);
          action.Description = "Paint Template '" + tem.ID + "'";
          action.SnapshotOld();
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
                    if (MapPackSection.Template[this.CellNumber(cx + xd, cy + yd)] != (ushort)Templates.GetID(tem.ID)
                      || MapPackSection.Tile[this.CellNumber(cx + xd, cy + yd)] != tile)
                    {
                      MapPackSection.Template[this.CellNumber(cx + xd, cy + yd)] = (ushort)Templates.GetID(tem.ID);
                      MapPackSection.Tile[this.CellNumber(cx + xd, cy + yd)] = tile;
                      changed = true;
                    }
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
              if (MapPackSection.Template[this.CellNumber(cx, cy)] != (ushort)Templates.GetID(tem.ID)
               || MapPackSection.Tile[this.CellNumber(cx, cy)] != entityInfo.TemplateCell)
              {
                MapPackSection.Template[this.CellNumber(cx, cy)] = (ushort)Templates.GetID(tem.ID);
                MapPackSection.Tile[this.CellNumber(cx, cy)] = entityInfo.TemplateCell;
                changed = true;
              }
            }
          }
          if (changed)
          {
            MapOccupancyList.UpdateEntity(this, cache, vfs, tem);
            action.SnapshotNew();
            TrackedActions.Push(action);
          }
        }
      }
      else if (entityInfo.Type is OverlayType ovl)
      {
        int id = Overlays.GetID(ovl.ID);
        if (id >= 0 && OverlayPackSection.Overlay[c] != (byte)id)
        {
          PaintOverlayAction action = new PaintOverlayAction(this, cache, vfs);
          action.Description = "Paint Overlay '" + ovl.ID + "'";
          action.SnapshotOld();
          OverlayPackSection.Overlay[c] = (byte)id;
          MapOccupancyList.UpdateEntity(this, cache, vfs, ovl);
          action.SnapshotNew();
          TrackedActions.Push(action);
        }
      }
      else if (entityInfo.Type is TerrainType terr)
      {
        TerrainInfo terrain = new TerrainInfo() { ID = terr.ID, Cell = c };
        InsertEntityAction<TerrainInfo> action = new InsertEntityAction<TerrainInfo>(this, cache, vfs, terrain, TerrainSection.EntityList);
        TerrainSection.EntityList.Add(terrain);
        MapOccupancyList.UpdateEntity(this, cache, vfs, terrain);
        TrackedActions.Push(action);
      }
      else if (entityInfo.Type is SmudgeType smud)
      {
        // check if there is any smudge with the same ID
        bool upgradeSmudge = false;
        if (smud.Images > 1)
        {
          // possible crater upgrade
          SmudgeInfo smd = null;
          foreach (var e in MapOccupancyList.Pick(this, entityInfo.X, entityInfo.Y))
          {
            if (e is SmudgeInfo sm && sm.ID == smud.ID)
            {
              smd = sm;
              break;
            }
          }

          if (smd != null)
          {
            upgradeSmudge = true;
            // attempt upgrade
            if (smd.Data < smud.Images - 1)
            {
              smd.Data++;
              ModifyEntityAction<SmudgeInfo> action = new ModifyEntityAction<SmudgeInfo>(this, smd, SmudgeSection.EntityList);
              action.SnapshotOld();
              MapOccupancyList.UpdateEntity(this, cache, vfs, smd);
              action.SnapshotNew();
              TrackedActions.Push(action);
            }
          }
        }
        if (!upgradeSmudge)
        {
          // add new smudge
          SmudgeInfo smudge = new SmudgeInfo() { ID = smud.ID, Cell = c };
          InsertEntityAction<SmudgeInfo> action = new InsertEntityAction<SmudgeInfo>(this, cache, vfs, smudge, SmudgeSection.EntityList);
          SmudgeSection.EntityList.Add(smudge);
          MapOccupancyList.UpdateEntity(this, cache, vfs, smudge);
          TrackedActions.Push(action);
        }
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
        InsertEntityAction<InfantryInfo> action = new InsertEntityAction<InfantryInfo>(this, cache, vfs, infantry, InfantrySection.EntityList);
        InfantrySection.EntityList.Add(infantry);
        MapOccupancyList.UpdateEntity(this, cache, vfs, infantry);
        TrackedActions.Push(action);
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
        InsertEntityAction<UnitInfo> action = new InsertEntityAction<UnitInfo>(this, cache, vfs, uinfo, UnitSection.EntityList);
        UnitSection.EntityList.Add(uinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, uinfo);
        TrackedActions.Push(action);
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
        InsertEntityAction<VesselInfo> action = new InsertEntityAction<VesselInfo>(this, cache, vfs, sinfo, VesselSection.EntityList);
        VesselSection.EntityList.Add(sinfo);
        MapOccupancyList.UpdateEntity(this, cache, vfs, sinfo);
        TrackedActions.Push(action);
      }
      else if (entityInfo.Type is BuildingType building)
      {
        if (entityInfo.IsBase)
        {
          BaseInfo binfo = new BaseInfo() { ID = building.ID, Cell = c };
          // theoretically, during undo the target BaseInfo should be at the last of the list, so no reordering of other BaseInfo is needed.
          // if this fails, use BaseSectionSaveAction instead
          InsertEntityAction<BaseInfo> action = new InsertEntityAction<BaseInfo>(this, cache, vfs, binfo, BaseSection.EntityList);
          BaseSection.EntityList.Add(binfo);
          MapOccupancyList.UpdateEntity(this, cache, vfs, binfo);
          TrackedActions.Push(action);
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
          InsertEntityAction<BuildingInfo> action = new InsertEntityAction<BuildingInfo>(this, cache, vfs, sinfo, BuildingSection.EntityList);
          BuildingSection.EntityList.Add(sinfo);
          MapOccupancyList.UpdateEntity(this, cache, vfs, sinfo);
          TrackedActions.Push(action);
        }
      }
      else if (entityInfo.Type is WaypointInfo wayp)
      {
        MoveEntityAction<WaypointInfo> action = new MoveEntityAction<WaypointInfo>(this, cache, vfs, wayp, WaypointSection.WaypointList);
        action.SnapshotOld();
        wayp.Cell = c;
        MapOccupancyList.UpdateEntity(this, cache, vfs, wayp);
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
      else if (entityInfo.Type is CellTriggerInfo celt)
      {
        string oldid = CellTriggerSection.Triggers[c]?.ID ?? null;
        if (oldid != celt.ID)
        {
          SetCellTriggerAction action = new SetCellTriggerAction(this, cache, vfs, c, oldid, celt.ID);
          CellTriggerInfo ncelt = new CellTriggerInfo(this)
          {
            ID = celt.ID,
            Cell = c
          };
          CellTriggerSection.Set(ncelt);
          // remove existing celltrigger on same location
          List<IEntity> rm = new List<IEntity>();
          foreach (IEntity e in MapOccupancyList.Pick(this, MapHelper.CellX(this, c), MapHelper.CellY(this, c)))
          {
            if (e is CellTriggerInfo)
            {
              rm.Add(e);
            }
          }
          foreach (IEntity e in rm)
          {
            MapOccupancyList.RemoveEntity(e);
          }
          MapOccupancyList.UpdateEntity(this, cache, vfs, ncelt);
          TrackedActions.Push(action);
        }
      }
      else if (entityInfo.Type is ExtractType extr)
      {
        FullMapReplaceAction action = new FullMapReplaceAction(this, cache, vfs);
        action.Description = "Paste Map Extract " + extr.ID;
        action.SnapshotOld();
        extr.Extract.Paste(this, cx, cy);
        RebuildOccupancyList(cache, vfs);
        action.SnapshotNew();
        TrackedActions.Push(action);
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
        PaintTemplateAction action = new PaintTemplateAction(this, cache, vfs);
        action.Description = "Clear Template";
        action.SnapshotOld();
        MapPackSection.Template[c] = 0xFFFF;
        MapOccupancyList.UpdateEntity(this, cache, vfs, tmpl);
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
      else if (entity is OverlayType ovly)
      {
        PaintOverlayAction action = new PaintOverlayAction(this, cache, vfs);
        action.Description = "Remove Overlay";
        action.SnapshotOld();
        OverlayPackSection.Overlay[c] = 0xFF;
        MapOccupancyList.UpdateEntity(this, cache, vfs, ovly);
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
      else if (entity is TerrainInfo terr)
      {
        RemoveEntityAction<TerrainInfo> action = new RemoveEntityAction<TerrainInfo>(this, cache, vfs, terr, TerrainSection.EntityList);
        TerrainSection.EntityList.Remove(terr);
        MapOccupancyList.RemoveEntity(terr);
        TrackedActions.Push(action);
      }
      else if (entity is SmudgeInfo smud)
      {
        RemoveEntityAction<SmudgeInfo> action = new RemoveEntityAction<SmudgeInfo>(this, cache, vfs, smud, SmudgeSection.EntityList);
        SmudgeSection.EntityList.Remove(smud);
        MapOccupancyList.RemoveEntity(smud);
        TrackedActions.Push(action);
      }
      else if (entity is InfantryInfo inft)
      {
        RemoveEntityAction<InfantryInfo> action = new RemoveEntityAction<InfantryInfo>(this, cache, vfs, inft, InfantrySection.EntityList);
        InfantrySection.EntityList.Remove(inft);
        MapOccupancyList.RemoveEntity(inft);
        TrackedActions.Push(action);
      }
      else if (entity is UnitInfo unit)
      {
        RemoveEntityAction<UnitInfo> action = new RemoveEntityAction<UnitInfo>(this, cache, vfs, unit, UnitSection.EntityList);
        UnitSection.EntityList.Remove(unit);
        MapOccupancyList.RemoveEntity(unit);
        TrackedActions.Push(action);
      }
      else if (entity is VesselInfo vessel)
      {
        RemoveEntityAction<VesselInfo> action = new RemoveEntityAction<VesselInfo>(this, cache, vfs, vessel, VesselSection.EntityList);
        VesselSection.EntityList.Remove(vessel);
        MapOccupancyList.RemoveEntity(vessel);
        TrackedActions.Push(action);
      }
      else if (entity is BaseInfo @base)
      {
        RemoveEntityAction<BaseInfo> action = new RemoveEntityAction<BaseInfo>(this, cache, vfs, @base, BaseSection.EntityList);
        BaseSection.EntityList.Remove(@base);
        MapOccupancyList.RemoveEntity(@base);
        TrackedActions.Push(action);
      }
      else if (entity is BuildingInfo building)
      {
        RemoveEntityAction<BuildingInfo> action = new RemoveEntityAction<BuildingInfo>(this, cache, vfs, building, BuildingSection.EntityList);
        BuildingSection.EntityList.Remove(building);
        MapOccupancyList.RemoveEntity(building);
        TrackedActions.Push(action);
      }
      else if (entity is WaypointInfo wayp)
      {
        MoveEntityAction<WaypointInfo> action = new MoveEntityAction<WaypointInfo>(this, cache, vfs, wayp, WaypointSection.WaypointList);
        action.SnapshotOld();
        wayp.Cell = -1;
        MapOccupancyList.RemoveEntity(wayp);
        action.SnapshotNew();
        TrackedActions.Push(action);
      }
      else if (entity is CellTriggerInfo celt)
      {
        SetCellTriggerAction action = new SetCellTriggerAction(this, cache, vfs, celt.Cell, celt.ID, null);
        CellTriggerSection.Remove(celt.Cell);
        MapOccupancyList.RemoveEntity(celt);
        TrackedActions.Push(action);
      }
      Dirty = true;
    }
  }
}
