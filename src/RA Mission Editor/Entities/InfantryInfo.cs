using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;

namespace RA_Mission_Editor.Entities
{
  public class InfantryInfo : IValueParsable<InfantryInfo>, IEntity<InfantryType>, IOwnedEntity, ILocatable
  {
    // INDEX=OWNER,ID,HEALTH,CELL,FACING,MISSION,TAG
    // Example: 5=Turkey,SHOK,256,9369,4,Area Guard,96,None
    public string Owner { get; set; } // Name of owning House
    public string ID { get; set; } // Unit type ID
    public short Health; // 0-255
    public int Cell { get; set; }// cell ID
    public byte SubCell; // 0-4
    public string Mission; // Mission
    public byte Facing; // 256 Direction
    public string Tag; // Trigger attachment

    public string GetValueAsString()
    {
      return string.Join(",", Owner
                            , ID
                            , Health
                            , Cell 
                            , SubCell
                            , Mission
                            , Facing
                            , Tag ?? "None");
    }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Infantry; } }

    public override string ToString()
    {
      return $"{ID}, {Owner} @ {Cell}";
    }

    public bool Parse(string value)
    {
      string[] tokens = value.Split(',');
      if (tokens.Length < 8)
      {
        return false;
      }
      unchecked
      {
        Owner = tokens[0];
        ID = tokens[1];
        Health = short.Parse(tokens[2]);
        Cell = int.Parse(tokens[3]);
        SubCell = byte.Parse(tokens[4]);
        Mission = tokens[5];
        Facing = byte.Parse(tokens[6]);
        Tag = tokens[7];
      }
      return true;
    }

    public InfantryType GetEntityType(Rules rules)
    {
      return rules.Infantries.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
