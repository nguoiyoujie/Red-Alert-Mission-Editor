using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;
using System;

namespace RA_Mission_Editor.Entities
{
  public class StructureInfo : IEntity<StructureType>, IOwnedEntity, ILocatable
  {
    // INDEX=OWNER,ID,HEALTH,CELL,FACING,TAG,AI_SELLABLE,AI_REBUILDABLE
    // Example: 3=USSR,SILO,256,436,0,None,0,1

    public string Owner { get; set; } // Name of owning House
    public string ID { get; set; } // Structure type ID
    public short Health; // 0-255
    public int Cell { get; set; }// cell ID
    public byte Facing; // 256 Direction
    public string Tag; // Trigger attachment

    // Red Alert (not in Tiberian Dawn)
    public bool AISellable; // allow Sell, if owning House has the required AI levels
    public bool AIRepairable; // allow Repair, if owning House has the required AI levels

    public string GetValueAsString()
    {
      return string.Join(",", Owner
                            , ID
                            , Health
                            , Cell 
                            , Facing 
                            , Tag ?? "None"
                            , AISellable ? "1" : "0"
                            , AIRepairable ? "1" : "0") ;
    }

    public override string ToString()
    {
      return $"{ID}, {Owner} @ {Cell}";
    }

    public static StructureInfo Parse(string index, string value)
    {
      StructureInfo s = new StructureInfo();
      string[] tokens = value.Split(',');
      if (tokens.Length < 8)
      {
        throw new Exception($"Map Structure {index} contains less than expected parameters");
      }
      unchecked
      {
        s.Owner = tokens[0];
        s.ID = tokens[1];
        s.Health = short.Parse(tokens[2]);
        s.Cell = int.Parse(tokens[3]);
        s.Facing = byte.Parse(tokens[4]);
        s.Tag = tokens[5];

        s.AISellable = tokens[6] != "0";
        s.AIRepairable = tokens[7] != "0";
      }
      return s;
    }

    public StructureType GetEntityType(Rules rules)
    {
      return rules.Structures.Get(ID);
    }

    IEntityType IEntity.GetEntityType(Rules rules)
    {
      return GetEntityType(rules);
    }
  }
}
