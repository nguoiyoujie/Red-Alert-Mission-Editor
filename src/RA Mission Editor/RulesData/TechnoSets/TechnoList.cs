using System.Collections.Generic;
using System.Linq;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class TechnoList<T> 
		where T : ITechnoType
	{
		protected List<T> _listType = new List<T>();
		protected List<string> _listString = new List<string>();
		protected int _originalRulesEntryCount;

		public virtual void CreateOriginalEntries() 
		{
			_listType.Clear();
			_listString.Clear();
		}

		public void ClearRulesAdditions()
		{
			if (_listType.Count > _originalRulesEntryCount)
				_listType.RemoveRange(_originalRulesEntryCount, _listType.Count - _originalRulesEntryCount);

			if (_listString.Count > _originalRulesEntryCount)
				_listString.RemoveRange(_originalRulesEntryCount, _listString.Count - _originalRulesEntryCount);
		}

		public void AddRulesObject(T obj)
		{
			_listType.Add(obj);
			_listString.Add(obj.ID);
		}

		public int GetID(string name)
    {
			return _listString.IndexOf(name);
    }

		public T[] GetAll()
		{
			return _listType.ToArray();
		}

		public object[] GetAsObjectList()
		{
			return GetAll().Select<T, object>((t) => t).ToArray();
		}

		public T Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public T Get(int id)
		{
			return id >= 0 && id < _listType.Count ? _listType[id] : default;
		}

		public string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
