using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class Overlays
  {
		private readonly static List<OverlayType> _listOverlay = new List<OverlayType>();
		private readonly static List<string> _listString = new List<string>();

		static Overlays()
    {
			_listOverlay = new List<OverlayType>()
			{
				new OverlayType("SBAG", OverlaySubType.WALL),
				new OverlayType("CYCL", OverlaySubType.WALL), 
				new OverlayType("BRIK", OverlaySubType.WALL),
				new OverlayType("BARB", OverlaySubType.WALL),
				new OverlayType("WOOD", OverlaySubType.WALL),
				new OverlayType("GOLD01", OverlaySubType.GOLD),
				new OverlayType("GOLD02", OverlaySubType.GOLD),
				new OverlayType("GOLD03", OverlaySubType.GOLD),
				new OverlayType("GOLD04", OverlaySubType.GOLD),
				new OverlayType("GEM01", OverlaySubType.GEM),
				new OverlayType("GEM02", OverlaySubType.GEM),
				new OverlayType("GEM03", OverlaySubType.GEM),
				new OverlayType("GEM04", OverlaySubType.GEM),

				new OverlayType("V12"),
				new OverlayType("V13"),
				new OverlayType("V14"),
				new OverlayType("V15"),
				new OverlayType("V16"),
				new OverlayType("V17"),
				new OverlayType("V18"),
				new OverlayType("FPLS"),
				new OverlayType("WCRATE"),
				new OverlayType("SCRATE"),
				new OverlayType("FENC", OverlaySubType.WALL),
				new OverlayType("WWCRATE"),
			};

			string[] lStr = new string[_listOverlay.Count];
			for (int i = 0; i < _listOverlay.Count; i++)
      {
				lStr[i] = _listOverlay[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static OverlayType[] GetAll()
		{
			return _listOverlay.ToArray();
		}

		public static object[] GetAsObjectList()
		{
			return GetAll(); //.Select((t) => t).ToArray();
		}

		public static int GetID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static OverlayType Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public static OverlayType Get(int id)
		{
			return id >= 0 && id < _listOverlay.Count ? _listOverlay[id] : default;
		}

		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
