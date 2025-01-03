using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
	public class Houses
	{
		private readonly List<HouseType> _listHouses = new List<HouseType>();
		public int Count { get { return _listHouses.Count; } }
    protected int _originalEntryCount;

    public Houses()
		{
			_listHouses.Add(new HouseType("Spain", ColorType.YELLOW));
			_listHouses.Add(new HouseType("Greece", ColorType.BLUE));
			_listHouses.Add(new HouseType("USSR", ColorType.RED));
			_listHouses.Add(new HouseType("England", ColorType.GREEN));
			_listHouses.Add(new HouseType("Ukraine", ColorType.ORANGE));
			_listHouses.Add(new HouseType("Germany", ColorType.GREY));
			_listHouses.Add(new HouseType("France", ColorType.TEAL));
			_listHouses.Add(new HouseType("Turkey", ColorType.BROWN));
			_listHouses.Add(new HouseType("GoodGuy", ColorType.BLUE));
			_listHouses.Add(new HouseType("BadGuy", ColorType.RED));
			_listHouses.Add(new HouseType("Neutral", ColorType.YELLOW));
			_listHouses.Add(new HouseType("Special", ColorType.YELLOW));
			// multiplayer houses, but usable in scenario like in TD
			_listHouses.Add(new HouseType("Multi1", ColorType.YELLOW));
			_listHouses.Add(new HouseType("Multi2", ColorType.BLUE));
			_listHouses.Add(new HouseType("Multi3", ColorType.RED));
			_listHouses.Add(new HouseType("Multi4", ColorType.GREEN));
			_listHouses.Add(new HouseType("Multi5", ColorType.ORANGE));
			_listHouses.Add(new HouseType("Multi6", ColorType.GREY));
			_listHouses.Add(new HouseType("Multi7", ColorType.TEAL));
			_listHouses.Add(new HouseType("Multi8", ColorType.BROWN));

      _originalEntryCount = _listHouses.Count;
		}

    public void ClearRulesAdditions()
    {
			if (_listHouses.Count > _originalEntryCount)
				_listHouses.RemoveRange(_originalEntryCount, _listHouses.Count - _originalEntryCount);
    }

    public void Add(HouseType house)
    {
      _listHouses.Add(house);
    }


    public HouseType[] GetAll()
		{
			return _listHouses.ToArray();
		}

		public int GetHouseID(string name)
		{
			if (name == null) return -1;
			for (int i = 0; i < _listHouses.Count; i++)
      {
				if (_listHouses[i].Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
					return i;
      }
			return -1;
		}

		public string GetName(int id)
		{
			return id >= 0 && id < _listHouses.Count ? _listHouses[id].Name : "Unknown House " + id;
		}

		public HouseType GetHouse(int id)
		{
			return id >= 0 && id < _listHouses.Count ? _listHouses[id] : _listHouses[0];
		}

		public HouseType GetNeutralHouse()
		{
			return GetHouse("Neutral");
		}

		public HouseType GetHouse(string name)
		{
			return GetHouse(GetHouseID(name));
		}
	}
}
