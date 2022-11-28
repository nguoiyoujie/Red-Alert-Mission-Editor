using RA_Mission_Editor.MapData;

namespace RA_Mission_Editor.RulesData.Ruleset
{
  public class IranModRules : VanillaRules
  {
    public override void ApplyRulesWithMap(Map map)
    {
      base.ApplyRulesWithMap(map);

      // new units according to Iran's additions must be used in the Rules file. They are not read in the Map
      foreach (var entry in GameRules.GetOrCreateSection("BuildingTypes").OrderedEntries)
      {
        // like ATEK
        Structures.AddRulesObject(new StructureType(entry.Value.Value) { BibName = "BIB3" });
      }

      foreach (var entry in GameRules.GetOrCreateSection("InfantryTypes").OrderedEntries)
      {
        // like E1
        Infantries.AddRulesObject(new InfantryType(entry.Value.Value) { Directions = 8 });
      }

      foreach (var entry in GameRules.GetOrCreateSection("UnitTypes").OrderedEntries)
      {
        // like 2TNK
        Units.AddRulesObject(new UnitType(entry.Value.Value) { Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = Units.DefaultTurretLocations });
      }

      foreach (var entry in GameRules.GetOrCreateSection("VesselTypes").OrderedEntries)
      {
        // like SS
        Ships.AddRulesObject(new ShipType(entry.Value.Value) { Directions = 16 });
      }

      foreach (var entry in GameRules.GetOrCreateSection("AircraftTypes").OrderedEntries)
      {
        // like HELI
        Aircrafts.AddRulesObject(new AircraftType(entry.Value.Value) { Directions = 32 });
      }

      UpdateTechnoTypeNames(map);

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
