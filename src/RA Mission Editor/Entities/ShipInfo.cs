using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;

namespace RA_Mission_Editor.Entities
{
  public class ShipInfo : IValueParsable<ShipInfo>, IEntity<ShipType>, IOwnedEntity, ILocatable
  {
    // INDEX=OWNER,ID,HEALTH,CELL,FACING,MISSION,TAG
    // Example: 0=Greece,CA,256,2,224,Sticky,c1
    public string Owner { get; set; } // Name of owning House
    public string ID { get; set; } // Unit type ID
    public short Health; // 0-255
    public int Cell { get; set; }// cell ID
    public byte Facing; // 256 Direction
    public string Mission; // Mission
    public string Tag; // Trigger attachment

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Ships; } }

    public string GetValueAsString()
    {
      return string.Join(",", Owner
                            , ID
                            , Health
                            , Cell 
                            , Facing
                            , Mission
                            , Tag ?? "None");
    }

    public override string ToString()
    {
      return $"{ID}, {Owner} @ {Cell}";
    }

    public bool Parse(string value)
    {
      string[] tokens = value.Split(',');
      if (tokens.Length < 7)
      {
        return false;
      }
      unchecked
      {
        Owner = tokens[0];
        ID = tokens[1].ToUpperInvariant();
        Health = short.Parse(tokens[2]);
        Cell = int.Parse(tokens[3]);
        Facing = byte.Parse(tokens[4]);
        Mission = tokens[5];
        Tag = tokens[6];
      }
      return true;
    }

    public ShipType GetEntityType(Rules rules)
    {
      return rules.Ships.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
