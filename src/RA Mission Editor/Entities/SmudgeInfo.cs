using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class SmudgeInfo : IEntity<SmudgeType>, ILocatable
  {
    // INDEX=ID,CELL,IGNORE
    // Example: 4061=TC01,4061,0
    public int Cell { get; set; } // Cell ID
    public string ID { get; set; } // Terrain type ID
    public bool Ignore; // set to anything other than 0 to ignore creation (for some reason)

    public string GetValueAsString()
    {
      return string.Join(",", ID
                            , Cell
                            , Ignore ? "1" : "0");
    }

    public override string ToString()
    {
      return $"{ID} @ {Cell}";
    }

    public static SmudgeInfo Parse(string index, string value)
    {
      SmudgeInfo s = new SmudgeInfo();
      string[] tokens = value.Split(',');
      if (tokens.Length < 3)
      {
        throw new Exception($"Map Smudge {index} contains less than expected parameters");
      }
      s.ID = tokens[0];
      s.Cell = int.Parse(tokens[1]);
      s.Ignore = tokens[2] != "0";

      return s;
    }

    public SmudgeType GetEntityType(Rules rules)
    {
      return Smudges.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
