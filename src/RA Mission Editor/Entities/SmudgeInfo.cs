using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;

namespace RA_Mission_Editor.Entities
{
  public class SmudgeInfo : IValueParsable<SmudgeInfo>, IEntity<SmudgeType>, ILocatable
  {
    // INDEX=ID,CELL,IGNORE
    // Example: 4061=TC01,4061,0
    public int Cell { get; set; } // Cell ID
    public string ID { get; set; } // Terrain type ID
    public bool Ignore; // set to anything other than 0 to ignore creation (for some reason)

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Smudges; } }

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

    public bool Parse(string value)
    {
      string[] tokens = value.Split(',');
      if (tokens.Length < 3)
      {
        return false;
      }
      ID = tokens[0];
      Cell = int.Parse(tokens[1]);
      Ignore = tokens[2] != "0";

      return true;
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
