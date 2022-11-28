using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class InfantryInfo : IEntity<InfantryType>, IOwnedEntity, ILocatable
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

    public override string ToString()
    {
      return $"{ID}, {Owner} @ {Cell}";
    }

    public static InfantryInfo Parse(string index, string value)
    {
      InfantryInfo s = new InfantryInfo();
      string[] tokens = value.Split(',');
      if (tokens.Length < 8)
      {
        throw new Exception($"Map Infantry {index} contains less than expected parameters");
      }
      unchecked
      {
        s.Owner = tokens[0];
        s.ID = tokens[1];
        s.Health = short.Parse(tokens[2]);
        s.Cell = int.Parse(tokens[3]);
        s.SubCell = byte.Parse(tokens[4]);
        s.Mission = tokens[5];
        s.Facing = byte.Parse(tokens[6]);
        s.Tag = tokens[7];
      }
      return s;
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
