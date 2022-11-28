using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class Terrains
	{
		private readonly static List<TerrainType> _listTerrain = new List<TerrainType>();
		private readonly static List<string> _listString = new List<string>();

		static Terrains()
    {
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/TDATA.CPP
			_listTerrain = new List<TerrainType>()
			{
				new TerrainType("T01"),
				new TerrainType("T02"),
				new TerrainType("T03"),
				//new TerrainType("T04"), // not present 
				new TerrainType("T05"),
				new TerrainType("T06"),
				new TerrainType("T07"),
				new TerrainType("T08"),
				//new TerrainType("T09"), // not present 
				new TerrainType("T10"),
				new TerrainType("T11"),
				new TerrainType("T12"),
				new TerrainType("T13"),
				new TerrainType("T14"),
				new TerrainType("T15"),
				new TerrainType("T16"),
				new TerrainType("T17"),
				// Tree Clusters
				new TerrainType("TC01"),
				new TerrainType("TC02"),
				new TerrainType("TC03"),
				new TerrainType("TC04"),
				new TerrainType("TC05"),
				// Ice Clusters
				new TerrainType("ICE01"),
				new TerrainType("ICE02"),
				new TerrainType("ICE03"),
				new TerrainType("ICE04"),
				new TerrainType("ICE05"),
				// Boxes // limited to interior only?
				new TerrainType("BOX01"),
				new TerrainType("BOX02"),
				new TerrainType("BOX03"),
				new TerrainType("BOX04"),
				new TerrainType("BOX05"),
				new TerrainType("BOX06"),
				new TerrainType("BOX07"),
				new TerrainType("BOX08"),
				new TerrainType("BOX09"),
				// Ore Mine
				new TerrainType("MINE"),
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
