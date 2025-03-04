using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
	public class Units : TechnoList<UnitType>
	{
		internal readonly TurretLocationDelegate[] DefaultTurretLocations = new TurretLocationDelegate[] { (id, fac) => { return new Point(0, 0); } };

		public Units()
		{
			_listType = new List<UnitType>()
			{
				new UnitType("4TNK") { FullName = "Mammoth Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("3TNK") { FullName = "Heavy Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("2TNK") { FullName = "Medium Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("1TNK") { FullName = "Light Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("APC") { FullName =  "APC", Directions = 32 },
				new UnitType("MNLY") { FullName = "Minelayer", Directions = 32 },
				new UnitType("JEEP") { FullName = "Ranger", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = new TurretLocationDelegate[] { (id, fac) => { return new Point(0, -4); } } },
				new UnitType("HARV") { FullName = "Ore Truck", Directions = 32, UsePrimaryColor = true },
				new UnitType("ARTY") { FullName = "Artillery", Directions = 32 },
				new UnitType("MRJ") { FullName =  "Mobile Radar Jammer", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("MGG") { FullName =  "Mobile Gap Generator", Directions = 32, TurretDirections = 8, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("MCV") { FullName =  "Mobile Construction Vehicle", Directions = 32, UsePrimaryColor = true },
				new UnitType("V2RL") { FullName = "V2 Rocket Launcher", Directions = 32 },
				new UnitType("TRUK") { FullName = "Supply Truck", Directions = 32 },
				new UnitType("ANT1") { FullName = "Ant 1", Directions = 8 },
				new UnitType("ANT2") { FullName = "Ant 2", Directions = 8 },
				new UnitType("ANT3") { FullName = "Ant 3", Directions = 8 },
				new UnitType("CTNK") { FullName = "Chrono Tank", Directions = 32 },
				new UnitType("TTNK") { FullName = "Tesla Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 32, TurretLocations = DefaultTurretLocations },
				new UnitType("QTNK") { FullName = "MAD Tank", Directions = 32 },
				new UnitType("DTRK") { FullName = "Demolition Truck", Directions = 32 },
				new UnitType("STNK") { FullName = "Phase Tank", Directions = 32, TurretDirections = 32, TurretShpFrame = 38 },
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
