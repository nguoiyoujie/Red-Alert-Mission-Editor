using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class Theaters
	{
		private readonly static List<TheaterType> _listTheater = new List<TheaterType>();
		private readonly static List<string> _listString = new List<string>();

		static Theaters()
		{
			_listTheater = new List<TheaterType>()
			{
				new TheaterType("TEMPERATE", "TEMPERAT", ".TEM"),
				new TheaterType("SNOW", "SNOW",".SNO"),
				new TheaterType("INTERIOR", "INTERIOR",".INT"),

				// added by Iran
				new TheaterType("WINTER", "WINTER",  ".WIN"),
				new TheaterType("DESERT", "DESERT", ".DES"),
				new TheaterType("JUNGLE", "JUNGLE", ".JUN"),

				// additional? 
				new TheaterType("CAVE", "CAVE", ".CAV"),
				new TheaterType("BARREN", "BARREN", ".BAR"),

        new TheaterType("CUSTOM1", "CUSTOM1", ".CM1"),
        new TheaterType("CUSTOM2", "CUSTOM2", ".CM2"),
        new TheaterType("CUSTOM3", "CUSTOM3", ".CM3"),
        new TheaterType("CUSTOM4", "CUSTOM4", ".CM4"),
      };

			string[] lStr = new string[_listTheater.Count];
			for (int i = 0; i < _listTheater.Count; i++)
			{
				lStr[i] = _listTheater[i].Name;
			}
			_listString = new List<string>(lStr);
		}

		public static TheaterType[] GetTheaters()
		{
			return _listTheater.ToArray();
		}

		public static int GetTheaterID(string name)
		{
			return _listString.IndexOf(name);
		}

		public static TheaterType GetTheater(string name)
		{
			return _listTheater[_listString.IndexOf(name)];
		}

		public static TheaterType GetTheater(int id)
		{
			return id >= 0 && id < _listTheater.Count ? _listTheater[id] : default;
		}

		public static string GetName(int id)
		{
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
