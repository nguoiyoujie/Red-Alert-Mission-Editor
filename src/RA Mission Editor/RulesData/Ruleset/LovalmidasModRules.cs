using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Util;
using System;
using System.Drawing;

namespace RA_Mission_Editor.RulesData.Ruleset
{
  public class LovalmidasModRules : IranModRules
  {
    public LovalmidasModRules()
    {
      Houses.ClearRulesAdditions();

      // additional houses, added by lvm
      Houses.Add(new HouseType("Multi9", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi10", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi11", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi12", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi13", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi14", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi15", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi16", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi17", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi18", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi19", ColorType.TRUE_GREY));
      Houses.Add(new HouseType("Multi20", ColorType.TRUE_GREY));
    }

    public override void ApplyRules()
    {
      // new units?
      Buildings.ClearRulesAdditions();
      Vessels.ClearRulesAdditions();
      Units.ClearRulesAdditions();
      Infantries.ClearRulesAdditions();
      Aircrafts.ClearRulesAdditions();

      // mapping of new strings to stringtable
      LanguageFile file = FileSystem.OpenFile<LanguageFile>("conquer.eng");
      int infantryNameIndex = ReadInt("StringTableOffsets", "Infantry", out _, int.MinValue);
      int unitNameIndex = ReadInt("StringTableOffsets", "Unit", out _, int.MinValue);
      int aircraftNameIndex = ReadInt("StringTableOffsets", "Aircraft", out _, int.MinValue);
      int vesselNameIndex = ReadInt("StringTableOffsets", "Vessel", out _, int.MinValue);
      int buildingNameIndex = ReadInt("StringTableOffsets", "Building", out _, int.MinValue);

      // new units according to Iran's additions must be used in the Rules file. They are not read in the Map
      // special additions by lovalmidas over Iran's additions
      int nameindex = buildingNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("BuildingTypes").OrderedEntries)
      {
        var building = new BuildingType(entry.Value.Value);
        // BYTE, 0-8, BSIZE_11, BSIZE_21, BSIZE_12, BSIZE_22, BSIZE_23, BSIZE_32, BSIZE_33, BSIZE_42, BSIZE_55 
        if (GameRules.GetSection(entry.Value.Value)?.ReadBool("Bib", true) ?? true)
        {
          switch (GameRules.GetSection(entry.Value.Value)?.ReadInt("BSize", 3) ?? 3)
          {
            case 1:
            case 3:
            case 4:
              building.BibName = "BIB3";
              break;
            case 5:
            case 6:
              building.BibName = "BIB2";
              break;
            case 7:
              building.BibName = "BIB1";
              break;
            default:
              break;
          }
        }

        if (GameRules.GetSection(entry.Value.Value)?.ReadBool("HasTurret", false) ?? false)
        {
          building.TurretDirections = 32;
        }
        building.FullName = file?.Get(nameindex++);

        string customfoundation = GameRules.GetSection(entry.Value.Value)?.ReadString("CustomFoundationList", "") ?? "";
        if (!string.IsNullOrEmpty(customfoundation))
        {
          building.Occupancy.Clear();
          Point cursor = new Point(0, 0);
          foreach (char c in customfoundation)
          {
            switch (c)
            {
              case 'S':
                cursor = new Point(0, cursor.Y - 1);
                break;
              case 'X':
                building.Occupancy.Add(cursor);
                cursor = new Point(cursor.X + 1, cursor.Y);
                break;
              case 'O':
                cursor = new Point(cursor.X + 1, cursor.Y);
                break;
              case '|':
                cursor = new Point(0, cursor.Y + 1);
                break;
            }
          }
        }

        Buildings.AddRulesObject(building);
      }

      nameindex = infantryNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("InfantryTypes").OrderedEntries)
      {
        // like E1
        Infantries.AddRulesObject(new InfantryType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 8 });
      }

      nameindex = unitNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("UnitTypes").OrderedEntries)
      {
        int turretstart = 32;
        if (GameRules.GetSection(entry.Value.Value)?.ReadBool("HasAPCDoor", false) ?? false)
        {
          turretstart = 38;
        }

        if (GameRules.GetSection(entry.Value.Value)?.ReadBool("HasTurret", true) ?? false)
        {
          // like 2TNK
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32, TurretDirections = 32, TurretShpFrame = turretstart, TurretLocations = Units.DefaultTurretLocations });
        }
        else if (GameRules.GetSection(entry.Value.Value)?.ReadBool("HasRotatingTurret", false) ?? false)
        {
          int turrstart = GameRules.GetSection(entry.Value.Value).ReadInt("TurretFrameStart", turretstart);
          int turrcount = GameRules.GetSection(entry.Value.Value).ReadInt("TurretFrameCount", 32);
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32, TurretDirections = turrstart, TurretShpFrame = turrcount, TurretLocations = Units.DefaultTurretLocations });
        }
        else
        {
          // no turret
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32 });
        }
      }

      nameindex = vesselNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("VesselTypes").OrderedEntries)
      {
        // like SS
        var vessel = new VesselType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 16 };
        if (GameRules.GetSection(entry.Value.Value).HasKey("HasTurret"))
        {
          if (!GameRules.GetSection(entry.Value.Value).ReadBool("HasTurret", false))
          {
            vessel.TurretLocations = new TurretLocationDelegate[0];
          }
          else
          {
            int offset = GameRules.GetSection(entry.Value.Value).ReadInt("TurretOffset");
            int adjustY = GameRules.GetSection(entry.Value.Value).ReadInt("TurretAdjustY");
            if (GameRules.GetSection(entry.Value.Value).ReadBool("HasSecondTurret", false))
            {
              vessel.TurretLocations = new TurretLocationDelegate[] { (id, fac) => { MapHelper.MoveCoord(0, 0, offset, 128 - fac, out int x, out int y); return new Point(x, y + adjustY); }, (id, fac) => { MapHelper.MoveCoord(0, 0, -offset, 128 - fac, out int x, out int y); return new Point(x, y + adjustY); } };
            }
            else
            {
              vessel.TurretLocations = new TurretLocationDelegate[] { (id, fac) => { MapHelper.MoveCoord(0, 0, offset, 128 - fac, out int x, out int y); return new Point(x, y + adjustY); } };
            }
            vessel.TurretDirections = 32;
          }
          vessel.TurretName = GameRules.GetSection(entry.Value.Value).ReadString("TurretName", vessel.TurretName);

        }
        Vessels.AddRulesObject(vessel);
      }

      nameindex = aircraftNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("AircraftTypes").OrderedEntries)
      {
        // like HELI
        Aircrafts.AddRulesObject(new AircraftType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32 });
      }


    }

    public override void ApplyRulesWithMap(Map map)
    {
      // apply Name= etc.
      foreach (var s in Buildings.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.IsFake ? s.TrueID : s.ID, map?.SourceFile);
        s.SecondImage = ReadString(s.ID, "WarFactoryOverlayAnim", out _, s.SecondImage, map?.SourceFile);
        bool oldbib = s.BibName != null;
        bool bib = ReadBool(s.ID, "Bib", out _, oldbib, map?.SourceFile);

        if (oldbib != bib)
        {
          if (bib)
          {
            switch (GameRules.GetSection(s.ID).ReadInt("BSize", 0)) // BSize not read in map
            {
              case 3:
              case 4:
                s.BibName = "BIB3";
                break;
              case 5:
              case 6:
                s.BibName = "BIB2";
                break;
              case 7:
                s.BibName = "BIB1";
                break;
              default:
                break;
            }
          }
          else
          {
            s.BibName = null;
          }
        }
      }

      foreach (var s in Vessels.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Units.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Infantries.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Aircrafts.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Houses.GetAll())
      {
        s.RulesPrimaryColor = GetColorFromIntOrString(s.Name, "Color", out _, s.PrimaryColor, map?.SourceFile);
        s.RulesSecondaryColor = GetColorFromIntOrString(s.Name, "SecondaryColorScheme", out RulesSource src, s.SecondaryColor, map?.SourceFile);
        if (src == RulesSource.NONE)
        {
          // if 'SecondaryColorScheme' is not defined, fallback to PrimaryColor
          s.RulesSecondaryColor = s.RulesPrimaryColor;
        }
      }
    }

    public ColorType GetColorFromIntOrString(string section, string key, out RulesSource source, ColorType defaultValue = default, IniFile mapFile = null)
    {
      string str = ReadString(section, key, out source, null, mapFile);
      if (source != RulesSource.NONE)
      {
        if (int.TryParse(str, out int icolor))
          return (ColorType)icolor;
        else if (Enum.TryParse(str, true, out ColorType colr))
          return colr;
      }
      return defaultValue;
    }
  }
}
