using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public static class Terrains
	{
		private readonly static List<TerrainType> _listTerrain = new List<TerrainType>();
		private readonly static List<string> _listString = new List<string>();

		static Terrains()
    {
      Point p0_0 = new Point(0, 0);
      Point p1_0 = new Point(1, 0);
      Point p2_0 = new Point(2, 0);
      Point p3_0 = new Point(3, 0);
      Point p0_1 = new Point(0, 1);
      Point p1_1 = new Point(1, 1);
      Point p2_1 = new Point(2, 1);
      Point p3_1 = new Point(3, 1);
      Point p0_2 = new Point(0, 2);
      Point p1_2 = new Point(1, 2);
      Point p2_2 = new Point(2, 2);

      // See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/TDATA.CPP
      _listTerrain = new List<TerrainType>()
			{
				new TerrainType("T01") {Occupancy = { p0_1 } },
				new TerrainType("T02") {Occupancy = { p0_1 } },
				new TerrainType("T03") {Occupancy = { p0_1 } },
				//new TerrainType("T04"), // not present 
				new TerrainType("T05") {Occupancy = { p0_1 } },
				new TerrainType("T06") {Occupancy = { p0_1 } },
				new TerrainType("T07") {Occupancy = { p0_1 } },
				new TerrainType("T08") {Occupancy = { p0_0 } },
				//new TerrainType("T09"), // not present 
				new TerrainType("T10") {Occupancy = { p0_1, p1_1 } },
				new TerrainType("T11") {Occupancy = { p0_1, p1_1 } },
				new TerrainType("T12") {Occupancy = { p0_1 } },
				new TerrainType("T13") {Occupancy = { p0_1 } },
				new TerrainType("T14") {Occupancy = { p0_1, p1_1 } },
				new TerrainType("T15") {Occupancy = { p0_1, p1_1 } },
				new TerrainType("T16") {Occupancy = { p0_1 } },
				new TerrainType("T17") {Occupancy = { p0_1 } },
				// Tree Clusters
				new TerrainType("TC01") {Occupancy = { p0_1, p1_1 } },
				new TerrainType("TC02") {Occupancy = { p1_0, p0_1, p1_1 } },
				new TerrainType("TC03") {Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new TerrainType("TC04") {Occupancy = { p0_1, p1_1, p2_1, p0_2 } },
				new TerrainType("TC05") {Occupancy = { p2_0, p0_1, p1_1, p2_1, p1_2, p2_2 } },
				// Ice Clusters
				new TerrainType("ICE01") {Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new TerrainType("ICE02") {Occupancy = { p0_0, p0_1 } },
				new TerrainType("ICE03") {Occupancy = { p0_0, p1_0 } },
				new TerrainType("ICE04") {Occupancy = { p0_0 } },
				new TerrainType("ICE05") {Occupancy = { p0_0 } },
				// Boxes // limited to interior only?
				new TerrainType("BOXES01") {Occupancy = { p0_0 } },
				new TerrainType("BOXES02") {Occupancy = { p0_0 } },
				new TerrainType("BOXES03") {Occupancy = { p0_0 } },
				new TerrainType("BOXES04") {Occupancy = { p0_0 } },
				new TerrainType("BOXES05") {Occupancy = { p0_0 } },
				new TerrainType("BOXES06") {Occupancy = { p0_0 } },
				new TerrainType("BOXES07") {Occupancy = { p0_0 } },
				new TerrainType("BOXES08") {Occupancy = { p0_0 } },
				new TerrainType("BOXES09") {Occupancy = { p0_0 } },
				// Ore Mine
				new TerrainType("MINE") {Occupancy = { p0_0 } },
			};

			string[] lStr = new string[_listTerrain.Count];
			for (int i = 0; i < _listTerrain.Count; i++)
      {
				lStr[i] = _listTerrain[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static TerrainType[] GetAll()
		{
			return _listTerrain.ToArray();
		}

		public static object[] GetAsObjectList()
		{
			return GetAll(); //.Select((t) => t).ToArray();
		}

		public static TerrainType Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public static TerrainType Get(int id)
		{
			return id >= 0 && id < _listTerrain.Count ? _listTerrain[id] : default;
		}

		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
