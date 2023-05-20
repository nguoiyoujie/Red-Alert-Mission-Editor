using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;

namespace RA_Mission_Editor.RulesData.Ruleset
{
  public class LovalmidasModRules : IranModRules
  {
    public override void ApplyRulesWithMap(Map map)
    {
      // new units?
      Structures.ClearRulesAdditions();
      Ships.ClearRulesAdditions();
      Units.ClearRulesAdditions();
      Infantries.ClearRulesAdditions();
      Aircrafts.ClearRulesAdditions();

      // mapping of new strings to stringtable
      LanguageFile file = FileSystem.OpenFile<LanguageFile>("conquer.eng");
      int infantryNameIndex = ReadInt("StringTableOffsets", "Infantry", out _, int.MinValue);
      int unitNameIndex = ReadInt("StringTableOffsets", "Units", out _, int.MinValue);
      int aircraftNameIndex = ReadInt("StringTableOffsets", "Aircrafts", out _, int.MinValue);
      int shipNameIndex = ReadInt("StringTableOffsets", "Vessels", out _, int.MinValue);
      int structureNameIndex = ReadInt("StringTableOffsets", "Buildings", out _, int.MinValue);

      // new units according to Iran's additions must be used in the Rules file. They are not read in the Map
      // special additions by lovalmidas over Iran's additions
      int nameindex = structureNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("BuildingTypes").OrderedEntries)
      {
        var structure = new StructureType(entry.Value.Value);
        // BYTE, 0-8, BSIZE_11, BSIZE_21, BSIZE_12, BSIZE_22, BSIZE_23, BSIZE_32, BSIZE_33, BSIZE_42, BSIZE_55 
        if (GameRules.GetSection(entry.Value.Value).ReadBool("Bib", true))
        {
          switch (GameRules.GetSection(entry.Value.Value).ReadInt("BSize", 3))
          {
            case 3:
            case 4:
              structure.BibName = "BIB3";
              break;
            case 5:
            case 6:
              structure.BibName = "BIB2";
              break;
            case 7:
              structure.BibName = "BIB1";
              break;
            default:
              break;
          }

          if (GameRules.GetSection(entry.Value.Value).ReadBool("HasTurret", false))
          {
            structure.TurretDirections = 32;
          }
        }
        structure.FullName = file?.Get(nameindex++);
        Structures.AddRulesObject(structure);
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
        if (GameRules.GetSection(entry.Value.Value).ReadBool("HasTurret", true))
        {
          // like 2TNK
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = Units.DefaultTurretLocations });
        }
        else if(GameRules.GetSection(entry.Value.Value).ReadBool("HasRotatingTurret", true))
        {
          int turrstart = GameRules.GetSection(entry.Value.Value).ReadInt("TurretFrameStart", 32);
          int turrcount = GameRules.GetSection(entry.Value.Value).ReadInt("TurretFrameCount", 32);
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32, TurretDirections = turrstart, TurretShpFrame = turrcount, TurretLocations = Units.DefaultTurretLocations });
        }
        else
            {
          // no turret
          Units.AddRulesObject(new UnitType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32 });
        }
      }

      nameindex = shipNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("VesselTypes").OrderedEntries)
      {
        // like SS
        Ships.AddRulesObject(new ShipType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 16 });
      }

      nameindex = aircraftNameIndex + 1;
      foreach (var entry in GameRules.GetOrCreateSection("AircraftTypes").OrderedEntries)
      {
        // like HELI
        Aircrafts.AddRulesObject(new AircraftType(entry.Value.Value) { FullName = file?.Get(nameindex++), Directions = 32 });
      }

      // apply Name= etc.
      foreach (var s in Structures.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.IsFake ? s.TrueID : s.ID, map?.SourceFile);
        s.SecondImage = ReadString(s.ID, "WarFactoryOverlayAnim", out _, s.SecondImage, map?.SourceFile);
      }

      foreach (var s in Ships.GetAll())
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
        s.RulesPrimaryColor = (ColorType)ReadInt(s.Name, "Color", out _, (int)s.PrimaryColor, map?.SourceFile);
        s.RulesSecondaryColor = (ColorType)ReadInt(s.Name, "SecondaryColorScheme", out RulesSource src, (int)s.SecondaryColor, map?.SourceFile);
        if (src == RulesSource.NONE)
        {
          // if 'SecondaryColorScheme' is not defined, fallback to PrimaryColor
          s.RulesSecondaryColor = s.RulesPrimaryColor;
        }
      }
    }
  }
}
