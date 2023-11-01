using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class BaseInfo : IEntity<BuildingType>, ILocatable
  {
    // INDEX3=CELL,ID
    // Example: 000=PROC,350
    public int Cell { get; set; } // Cell ID
    public string ID { get; set; } // Unit type ID

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Bases; } }

    public string GetValueAsString()
    {
      return string.Join(",", ID
                            , Cell);
    }

    public override string ToString()
    {
      return $"{ID}";
    }

    public static BaseInfo Parse(string index, string value)
    {
      BaseInfo s = new BaseInfo();
      string[] tokens = value.Split(',');
      if (tokens.Length < 2)
      {
        throw new Exception($"Map Base {index} contains less than expected parameters");
      }
      s.ID = tokens[0].ToUpperInvariant();
      s.Cell = int.Parse(tokens[1]);

      return s;
    }

    public BuildingType GetEntityType(Rules rules)
    {
      return rules.Buildings.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
