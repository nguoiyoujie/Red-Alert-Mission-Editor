using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class TerrainInfo : IEntity<TerrainType>, ILocatable
  {
    // CELL=ID
    // Example: 4061=TC01
    public int Cell { get; set; } // Cell ID
    public string ID { get; set; } // Terrain type ID

    public string GetKeyAsString()
    {
      return Cell.ToString();
    }

    public string GetValueAsString()
    {
      return ID;
    }

    public override string ToString()
    {
      return $"{ID} @ {Cell}";
    }

    public static TerrainInfo Parse(string index, string value)
    {
      TerrainInfo s = new TerrainInfo();
      s.Cell = int.Parse(index);
      string[] tokens = value.Split(',');
      if (tokens.Length < 1)
      {
        throw new Exception($"Map Terrain {index} contains less than expected parameters");
      }
      s.ID = tokens[0];

      return s;
    }

    public TerrainType GetEntityType(Rules rules)
    {
      return Terrains.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
