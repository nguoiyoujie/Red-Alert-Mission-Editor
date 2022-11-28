using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Infantries : TechnoList<InfantryType>
	{
		public Infantries()
    {
			_listType = new List<InfantryType>()
			{
				new InfantryType("E1") { FullName = "Rifle Infantry", Directions = 8 },
				new InfantryType("E2") { FullName = "Grenadier", Directions = 8 },
				new InfantryType("E3") { FullName = "Rocket Soldier", Directions = 8 },
				new InfantryType("E4") { FullName = "Flame Thrower", Directions = 8 },
				new InfantryType("E6") { FullName = "Engineer", Directions = 8 },
				new InfantryType("E7") { FullName = "Tanya", Directions = 8 },
				new InfantryType("SPY") { FullName = "Spy", Directions = 8 },
				new InfantryType("THF") { FullName = "Thief", Directions = 8 },
				new InfantryType("MEDI") { FullName = "Medic", Directions = 8 },
				new InfantryType("GNRL") { FullName = "General", Directions = 8 },
				new InfantryType("DOG") { FullName = "Attack Dog", Directions = 8 },

				new InfantryType("C1") { FullName = "Civilian 1 (Joe)", Directions = 8 },
				new InfantryType("C2") { FullName = "Civilian 2 (Barry)", Directions = 8, RemapOverrideKey = "C2" },
				new InfantryType("C3") { FullName = "Civilian 3 (Shelly)", Directions = 8 },
				new InfantryType("C4") { FullName = "Civilian 4 (Maria)", Directions = 8, RemapOverrideKey = "C4" },
				new InfantryType("C5") { FullName = "Civilian 5 (Karen)", Directions = 8, RemapOverrideKey = "C5" },
				new InfantryType("C6") { FullName = "Civilian 6 (Steve)", Directions = 8, RemapOverrideKey = "C6" },
				new InfantryType("C7") { FullName = "Civilian 7 (Phil)", Directions = 8, RemapOverrideKey = "C7" },
				new InfantryType("C8") { FullName = "Civilian 8 (Dwight)", Directions = 8, RemapOverrideKey = "C8" },
				new InfantryType("C9") { FullName = "Civilian 9 (Erik)", Directions = 8 , RemapOverrideKey = "C9" },
				new InfantryType("C10") { FullName = "Nikoomba", Directions = 8, RemapOverrideKey = "C10" },
				new InfantryType("EINSTEIN") { FullName = "Prof. Einstein", Directions = 8 },
				new InfantryType("DELPHI") { FullName = "Agent Delphi", Directions = 8 },
				new InfantryType("CHAN") { FullName = "Dr. Chan", Directions = 8 },
				new InfantryType("SHOK") { FullName = "Shock Trooper", Directions = 8 },
				new InfantryType("MECH") { FullName = "Mechanic", Directions = 8 },
			};

			string[] lStr = new string[_listType.Count];
			for (int i = 0; i < _listType.Count; i++)
      {
				lStr[i] = _listType[i].ID;
			}
			_listString = new List<string>(lStr);
			_originalRulesEntryCount = _listType.Count;
		}
	}
}
