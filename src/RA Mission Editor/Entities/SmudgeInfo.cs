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
    public int Data;

    // Note: Due to RA loading pecularities, Data doesn't mean anything. To mark a crater to its 2nd stage, two copies of a crater should exist on the cell.
    // However, this cannot be easily drawn on the map editor, so we use Data to store this info.
    // When saving or loading the map, the conversion should be made to show the equivalent behavior on the game

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Smudges; } }

    public string GetValueAsString()
    {
      return string.Join(",", ID
                            , Cell
                            , Data);
    }

    public string GetValueAsWrite()
    {
      return string.Join(",", ID
                            , Cell
                            , "0");
    }

    public override string ToString()
    {
      return $"{ID}:{Data} @ {Cell}";
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
      Data = int.Parse(tokens[2]);

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
