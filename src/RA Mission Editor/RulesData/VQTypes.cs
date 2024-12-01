using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public class VQTypes
  {
    private readonly List<string> _listVQs = new List<string>();
    public readonly int Count;

    public VQTypes()
    {
      _listVQs.Add("AAGUN");
      _listVQs.Add("MIG");
      _listVQs.Add("SFROZEN");
      _listVQs.Add("AIRFIELD");
      _listVQs.Add("BATTLE");
      _listVQs.Add("BMAP");
      _listVQs.Add("BOMBRUN");
      _listVQs.Add("DPTHCHRG");
      _listVQs.Add("GRVESTNE");
      _listVQs.Add("MONTPASS");
      _listVQs.Add("MTNKFACT");
      _listVQs.Add("CRONTEST");
      _listVQs.Add("OILDRUM");
      _listVQs.Add("ALLIEND");
      _listVQs.Add("RADRRAID");
      _listVQs.Add("SHIPYARD");
      _listVQs.Add("SHORBOMB");
      _listVQs.Add("SITDUCK");
      _listVQs.Add("SLNTSRVC");
      _listVQs.Add("SNOWBASE");
      _listVQs.Add("EXECUTE");
      _listVQs.Add("REDINTRO");
      _listVQs.Add("NUKESTOK");
      _listVQs.Add("V2ROCKET");
      _listVQs.Add("SEARCH");
      _listVQs.Add("BINOC");
      _listVQs.Add("ELEVATOR");
      _listVQs.Add("FROZEN");
      _listVQs.Add("MCV");
      _listVQs.Add("SHIPSINK");
      _listVQs.Add("SOVMCV");
      _listVQs.Add("TRINITY");
      _listVQs.Add("ALLYMORF");
      _listVQs.Add("APCESCPE");
      _listVQs.Add("BRDGTILT");
      _listVQs.Add("CRONFAIL");
      _listVQs.Add("STRAFE");
      _listVQs.Add("DESTROYR");
      _listVQs.Add("DOUBLE");
      _listVQs.Add("FLARE");
      _listVQs.Add("SNSTRAFE");
      _listVQs.Add("LANDING");
      _listVQs.Add("ONTHPRWL");
      _listVQs.Add("OVERRUN");
      _listVQs.Add("SNOWBOMB");
      _listVQs.Add("SOVCEMET");
      _listVQs.Add("TAKE_OFF");
      _listVQs.Add("TESLA");
      _listVQs.Add("SOVIET8");
      _listVQs.Add("SPOTTER");
      _listVQs.Add("ALLY1");
      _listVQs.Add("ALLY2");
      _listVQs.Add("ALLY4");
      _listVQs.Add("SOVFINAL");
      _listVQs.Add("ASSESS");
      _listVQs.Add("SOVIET10");
      _listVQs.Add("DUD");
      _listVQs.Add("MCV_LAND");
      _listVQs.Add("MCVBRDGE");
      _listVQs.Add("PERISCOP");
      _listVQs.Add("SHORBOM1");
      _listVQs.Add("SHORBOM2");
      _listVQs.Add("SOVBATL");
      _listVQs.Add("SOVTSTAR");
      _listVQs.Add("AFTRMATH");
      _listVQs.Add("SOVIET11");
      _listVQs.Add("MASASSLT");
      _listVQs.Add("ENGLISH");
      _listVQs.Add("SOVIET1");
      _listVQs.Add("SOVIET2");
      _listVQs.Add("SOVIET3");
      _listVQs.Add("SOVIET4");
      _listVQs.Add("SOVIET5");
      _listVQs.Add("SOVIET6");
      _listVQs.Add("SOVIET7");
      _listVQs.Add("PROLOG");
      _listVQs.Add("AVERTED");
      _listVQs.Add("COUNTDWN");
      _listVQs.Add("MOVINGIN");
      _listVQs.Add("ALLY10");
      _listVQs.Add("ALLY12");
      _listVQs.Add("ALLY5");
      _listVQs.Add("ALLY6");
      _listVQs.Add("ALLY8");
      _listVQs.Add("TANYA1");
      _listVQs.Add("TANYA2");
      _listVQs.Add("ALLY10B");
      _listVQs.Add("ALLY11");
      _listVQs.Add("ALLY14");
      _listVQs.Add("ALLY9");
      _listVQs.Add("SPY");
      _listVQs.Add("TOOFAR");
      _listVQs.Add("SOVIET12");
      _listVQs.Add("SOVIET13");
      _listVQs.Add("SOVIET9");
      _listVQs.Add("BEACHEAD");
      _listVQs.Add("SOVIET14");
      _listVQs.Add("SIZZLE");
      _listVQs.Add("SIZZLE2");
      _listVQs.Add("ANTEND");
      _listVQs.Add("ANTINTRO");

      Count = _listVQs.Count;
    }    
                                            
		public string[] GetAll()             
		{
			return _listVQs.ToArray();         
		}                                       


		public string GetVQ(int id)
		{
      return id >= 0 && id < _listVQs.Count ? _listVQs[id] : default;
    }

    public int GetID(string name)
    {
      return _listVQs.IndexOf(name);
    }
  }
}
