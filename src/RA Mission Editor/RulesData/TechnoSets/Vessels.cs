using RA_Mission_Editor.Util;
using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Vessels : TechnoList<VesselType>
	{
		public Vessels()
    {
			_listType = new List<VesselType>()
			{
				new VesselType("SS")
				{
					FullName = "Submarine", 
					Directions = 16
				},
				new VesselType("DD")
				{
					FullName = "Destroyer",
					TurretName = "SSAM",
					TurretLocations = new TurretLocationDelegate[] { (id, fac) => { MapHelper.MoveCoord(0, 0, -8, 128 - fac, out int x, out int y); return new Point(x, y - 4); } },
					Directions = 16,
					TurretDirections = 32,
					TurretShpFrame = 0
				},
				new VesselType("CA") 
				{
					FullName = "Cruiser",
					TurretName = "TURR", 
					TurretLocations = new TurretLocationDelegate[] { (id, fac) => { MapHelper.MoveCoord(0, 0, 22, 128 - fac, out int x, out int y); return new Point(x, y - 4); }, (id, fac) => { MapHelper.MoveCoord(0, 0, -22, 128 - fac, out int x, out int y); return new Point(x, y - 4); } },
					Directions = 16,
					TurretDirections = 32,
					TurretShpFrame = 0
				},
				new VesselType("LST") { FullName = "Transport" },
        new VesselType("PT")
        {
          FullName = "Gunboat",
          TurretName = "MGUN",
          TurretLocations = new TurretLocationDelegate[] { (id, fac) => { MapHelper.MoveCoord(0, 0, 14, 128 - fac, out int x, out int y); return new Point(x, y + 1); } },
          Directions = 16,
          TurretDirections = 32,
          TurretShpFrame = 0
        },
        new VesselType("MSUB")
				{
					FullName = "Missile Sub",
					Directions = 16
				},
				new VesselType("CARR") { FullName = "Helicarrier" },
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
