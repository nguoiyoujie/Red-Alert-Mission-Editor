using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public class SpecialWeapons
  {
		private readonly List<string> _listSpecialWeapons = new List<string>();
    public readonly int Count;

    public SpecialWeapons()
    {
      _listSpecialWeapons.Add("Sonar Pulse");
      _listSpecialWeapons.Add("Nuclear Bomb");
      _listSpecialWeapons.Add("Chronosphere");
      _listSpecialWeapons.Add("Parabomb");
      _listSpecialWeapons.Add("Paratroopers");
      _listSpecialWeapons.Add("Spy Plane");
      _listSpecialWeapons.Add("Iron Curtain");
      _listSpecialWeapons.Add("GPS Satellite");

      Count = _listSpecialWeapons.Count;
    }               
                                            
		public string[] GetAll()             
		{
			return _listSpecialWeapons.ToArray();         
		}                                       


		public string GetSpecialWeapon(int id)
		{
      return id >= 0 && id < _listSpecialWeapons.Count ? _listSpecialWeapons[id] : default;
    }

    public int GetID(string name)
    {
      return _listSpecialWeapons.IndexOf(name);
    }
  }
}
