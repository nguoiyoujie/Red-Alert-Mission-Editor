using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class Smudges
	{
		private readonly static List<SmudgeType> _listSmudge = new List<SmudgeType>();
		private readonly static List<string> _listString = new List<string>();

		static Smudges()
		{
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/TDATA.CPP
			_listSmudge = new List<SmudgeType>()
			{
				new SmudgeType("CR1") { Images = 4 },
				new SmudgeType("CR2") { Images = 4 },
				new SmudgeType("CR3") { Images = 4 },
				new SmudgeType("CR4") { Images = 4 },
				new SmudgeType("CR5") { Images = 4 },
				new SmudgeType("CR6") { Images = 4 },
				new SmudgeType("SC1"),
				new SmudgeType("SC2"),
				new SmudgeType("SC3"),
				new SmudgeType("SC4"),
				new SmudgeType("SC5"),
				new SmudgeType("SC6"),
				// Bibs
				new SmudgeType("BIB1") { BlockWidth = 4, BlockHeight = 2 },
				new SmudgeType("BIB2") { BlockWidth = 3, BlockHeight = 2 },
				new SmudgeType("BIB3") { BlockWidth = 2, BlockHeight = 2 },
			};

			string[] lStr = new string[_listSmudge.Count];
			for (int i = 0; i < _listSmudge.Count; i++)
			{
				lStr[i] = _listSmudge[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetID(string name)
		{
			return _listString.IndexOf(name);
		}

		public static SmudgeType[] GetAll()
		{
			return _listSmudge.ToArray();
		}

		public static object[] GetAsObjectList()
		{
			return GetAll(); //.Select((t) => t).ToArray();
		}

		public static SmudgeType Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public static SmudgeType Get(int id)
		{
			return id >= 0 && id < _listSmudge.Count ? _listSmudge[id] : default;
		}

		public static string GetName(int id)
		{
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
