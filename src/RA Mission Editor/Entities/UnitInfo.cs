using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class UnitInfo : IEntity<UnitType>, IOwnedEntity, ILocatable
  {
    // INDEX=OWNER,ID,HEALTH,CELL,FACING,MISSION,TAG
    // Example: 0=Turkey,JEEP,256,4585,128,Guard,des0
    public string Owner { get; set; } // Name of owning House
    public string ID { get; set; } // Unit type ID
    public short Health; // 0-255
    public int Cell { get; set; }// cell ID
    public byte Facing; // 256 Direction
    public string Mission; // Mission
    public string Tag; // Trigger attachment

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

    public static UnitInfo Parse(string index, string value)
    {
      UnitInfo s = new UnitInfo();
      string[] tokens = value.Split(',');
      if (tokens.Length < 7)
      {
        throw new Exception($"Map Unit {index} contains less than expected parameters");
      }
      s.Owner = tokens[0];
      s.ID = tokens[1];
      s.Health = short.Parse(tokens[2]);
      s.Cell = int.Parse(tokens[3]);
      s.Facing = byte.Parse(tokens[4]);
      s.Mission = tokens[5];
      s.Tag = tokens[6];

      return s;
    }

    public UnitType GetEntityType(Rules rules)
    {
      return rules.Units.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
