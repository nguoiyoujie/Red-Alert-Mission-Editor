using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;

namespace RA_Mission_Editor.Entities
{
  public class TerrainInfo : IKeyValueParsable<TerrainInfo>, IEntity<TerrainType>, ILocatable
  {
    // CELL=ID
    // Example: 4061=TC01
    public int Cell { get; set; } // Cell ID
    public string ID { get; set; } // Terrain type ID

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Terrain; } }

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

    public bool Parse(string key, string value)
    {
      Cell = int.Parse(key);
      string[] tokens = value.Split(',');
      if (tokens.Length < 1)
      {
        return false;
      }
      ID = tokens[0];

      return true;
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
