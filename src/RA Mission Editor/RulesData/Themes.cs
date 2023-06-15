using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public class Themes
  {
		private readonly List<string> _listThemes = new List<string>();
    public readonly int Count;

    public Themes()
    {
      _listThemes.Add("BIGF226M");
      _listThemes.Add("CRUS226M");
      _listThemes.Add("FAC1226M");
      _listThemes.Add("FAC2226M");
      _listThemes.Add("HELL226M");
      _listThemes.Add("RUN1226M");
      _listThemes.Add("SMSH226M");
      _listThemes.Add("TREN226M");
      _listThemes.Add("WORK226M");
      _listThemes.Add("AWAIT");
      _listThemes.Add("DENSE_R");
      _listThemes.Add("FOGGER1A");
      _listThemes.Add("MUD1A");
      _listThemes.Add("RADIO2");
      _listThemes.Add("ROLLOUT");
      _listThemes.Add("SNAKE");
      _listThemes.Add("TERMINAT");
      _listThemes.Add("TWIN");
      _listThemes.Add("VECTOR1A");
      _listThemes.Add("MAP");
      _listThemes.Add("SCORE");
      _listThemes.Add("INTRO");
      _listThemes.Add("CREDITS");
      _listThemes.Add("2ND_HAND");
      _listThemes.Add("ARAZOID");
      _listThemes.Add("BACKSTAB");
      _listThemes.Add("CHAOS2");
      _listThemes.Add("SHUT_IT");
      _listThemes.Add("TWINMIX1");
      _listThemes.Add("UNDER3");
      _listThemes.Add("VR2");
      _listThemes.Add("BOG");
      _listThemes.Add("FLOAT_V2");
      _listThemes.Add("GLOOM");
      _listThemes.Add("GRNDWIRE");
      _listThemes.Add("RPT");
      _listThemes.Add("SEARCH");
      _listThemes.Add("TRACTION");
      _listThemes.Add("WASTELND");

      Count = _listThemes.Count;
    }               
                                            
		public string[] GetAll()             
		{
			return _listThemes.ToArray();         
		}                                       


		public string GetTheme(int id)
		{
      return id >= 0 && id < _listThemes.Count ? _listThemes[id] : default;
    }

    public int GetID(string name)
    {
      return _listThemes.IndexOf(name);
    }
  }
}
