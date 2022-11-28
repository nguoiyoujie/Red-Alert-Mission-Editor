using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Aircrafts : TechnoList<AircraftType>
	{
		public Aircrafts()
		{
			_listType = new List<AircraftType>()
			{
				new AircraftType("BADR") { FullName = "Badger Bomber", Directions = 16},
				new AircraftType("U2") { FullName = "Spy Plane", Directions = 16},
				new AircraftType("MIG") { FullName = "Mig Attack Plane", Directions = 16},
				new AircraftType("YAK") { FullName = "Yak Attack Plane", Directions = 16},
				new AircraftType("TRAN") { FullName = "Chinook Transport", Directions = 32},
				new AircraftType("HELI") { FullName = "Longbow Attack Helicopter", Directions = 32},
				new AircraftType("HIND") { FullName = "Hind Attack Helicopter", Directions = 32},
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
