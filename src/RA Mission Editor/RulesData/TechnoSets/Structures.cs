using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Structures : TechnoList<StructureType>
	{
		public Structures()
    {
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/BDATA.CPP
			_listType = new List<StructureType>()
			{
				new StructureType("ATEK") { FullName = "Allied Tech Center", BibName = "BIB3" },
				new StructureType("IRON") { FullName = "Iron Curtain" },
				new StructureType("WEAP") { FullName = "War Factory", BibName = "BIB2", SecondImage = "WEAP2" },
				new StructureType("PDOX") { FullName = "Chronosphere" },
				new StructureType("PBOX") { FullName = "Pillbox" },
				new StructureType("HBOX") { FullName = "Camo. Pillbox" },
				new StructureType("DOME") { FullName = "Radar Dome", BibName = "BIB3" },
				new StructureType("GAP") { FullName = "Gap Generator" },
				new StructureType("GUN") { FullName = "Turret", TurretDirections = 32 },
				new StructureType("AGUN") { FullName = "AA Gun", TurretDirections = 32 },
				new StructureType("FTUR") { FullName = "Flame Tower" },
				new StructureType("FACT") { FullName = "Construction Yard", BibName = "BIB2" },
				new StructureType("PROC") { FullName = "Ore Refinery", BibName = "BIB2" },
				new StructureType("SILO") { FullName = "Ore Silo" },
				new StructureType("HPAD") { FullName = "Helipad", BibName = "BIB3" },
				new StructureType("SAM") { FullName = "SAM Site", TurretDirections = 32 },
				new StructureType("AFLD") { FullName = "Airfield", BibName = "BIB2" },
				new StructureType("POWR") { FullName = "Power Plant", BibName = "BIB3" },
				new StructureType("APWR") { FullName = "Adv. Power Plant", BibName = "BIB2" },
				new StructureType("STEK") { FullName = "Soviet Tech Center", BibName = "BIB2" },
				new StructureType("HOSP") { FullName = "Hospital", BibName = "BIB3" },
				new StructureType("BARR") { FullName = "Barracks (Soviet)", BibName = "BIB3" },
				new StructureType("TENT") { FullName = "Barracks (Allied)", BibName = "BIB3" },
				new StructureType("KENN") { FullName = "Kennel" },
				new StructureType("FIX") { FullName = "Service Depot" },
				new StructureType("BIO") { FullName = "Bio-Research Lab", BibName = "BIB3" },
				new StructureType("MISS") { FullName = "Technology Center", BibName = "BIB2" },
				new StructureType("SYRD") { FullName = "Naval Yard" },
				new StructureType("SPEN") { FullName = "Sub Pen" },
				new StructureType("MSLO") { FullName = "Missile Silo" },
				new StructureType("FCOM") { FullName = "Forward Command Post", BibName = "BIB3" },
				new StructureType("TSLA") { FullName = "Tesla Coil" },

				new StructureType("WEAF") { FullName = "Fake War Factory", IsFake = true, TrueID = "WEAP", BibName = "BIB2", SecondImage = "WEAP2" },
				new StructureType("FACF") { FullName = "Fake Const. Yard", IsFake = true, TrueID = "FACT", BibName = "BIB2" },
				new StructureType("SYRF") { FullName = "Fake Naval Yard", IsFake = true, TrueID = "SYRD" },
				new StructureType("SPEF") { FullName = "Fake Sub Pen", IsFake = true, TrueID = "SPEN" },
				new StructureType("DOMF") { FullName = "Fake Radar Dome", IsFake = true, TrueID = "DOME", BibName = "BIB3" },

				new StructureType("SBAG") { FullName = "Sandbags" , UseNeutralRemap = true},
				new StructureType("CYCL") { FullName = "Chain Link Fence" , UseNeutralRemap = true },
				new StructureType("BRIK") { FullName = "Concrete Wall" , UseNeutralRemap = true },
				new StructureType("BARB") { FullName = "Barbwire Fence" , UseNeutralRemap = true },
				new StructureType("WOOD") { FullName = "Wood Fence" , UseNeutralRemap = true },
				new StructureType("FENC") { FullName = "Wire Fence" , UseNeutralRemap = true },

				new StructureType("MINV") { FullName = "Anti-Vehicle Mine" , UseNeutralRemap = true },
				new StructureType("MINP") { FullName = "Anti-Personnel Mine" , UseNeutralRemap = true },

				new StructureType("V01") { FullName = "Church" , UseNeutralRemap = true },
				new StructureType("V02") { FullName = "Han's and Gretel's" , UseNeutralRemap = true },
				new StructureType("V03") { FullName = "Hewitt's Manor" , UseNeutralRemap = true },
				new StructureType("V04") { FullName = "Ricktor's House" , UseNeutralRemap = true },
				new StructureType("V05") { FullName = "Gretchin's House" , UseNeutralRemap = true },
				new StructureType("V06") { FullName = "The Barn" , UseNeutralRemap = true },
				new StructureType("V07") { FullName = "Damon's Pub" , UseNeutralRemap = true },
				new StructureType("V08") { FullName = "Fran's House" , UseNeutralRemap = true },
				new StructureType("V09") { FullName = "Music Factory" , UseNeutralRemap = true },
				new StructureType("V10") { FullName = "Toymaker's" , UseNeutralRemap = true },
				new StructureType("V11") { FullName = "Ludwig's House" , UseNeutralRemap = true },
				new StructureType("V12") { FullName = "Haystacks" , UseNeutralRemap = true },
				new StructureType("V13") { FullName = "Haystack" , UseNeutralRemap = true },
				new StructureType("V14") { FullName = "Wheat Field" , UseNeutralRemap = true },
				new StructureType("V15") { FullName = "Fallow Field" , UseNeutralRemap = true },
				new StructureType("V16") { FullName = "Corn Field" , UseNeutralRemap = true },
				new StructureType("V17") { FullName = "Celery Field" , UseNeutralRemap = true },
				new StructureType("V18") { FullName = "Potato Field" , UseNeutralRemap = true },
				new StructureType("V19") { FullName = "Oil Pump" , UseNeutralRemap = true },

				// other 
				new StructureType("V20") { FullName = "Sala's House" , UseNeutralRemap = true },
				new StructureType("V21") { FullName = "Abdul's House" , UseNeutralRemap = true },
				new StructureType("V22") { FullName = "Pablo's Wicked Pub" , UseNeutralRemap = true },
				new StructureType("V23") { FullName = "Village Well" , UseNeutralRemap = true },
				new StructureType("V24") { FullName = "Camel Trader" , UseNeutralRemap = true },
				new StructureType("V25") { FullName = "Church" , UseNeutralRemap = true },
				new StructureType("V26") { FullName = "Ali's House" , UseNeutralRemap = true },
				new StructureType("V27") { FullName = "Trader Ted's" , UseNeutralRemap = true },
				new StructureType("V28") { FullName = "Menelik's House" , UseNeutralRemap = true },
				new StructureType("V29") { FullName =	"Prestor John's House" , UseNeutralRemap = true },
				new StructureType("V30") { FullName =	"Village Well" , UseNeutralRemap = true },
				new StructureType("V31") { FullName =	"Witch Doctor's Hut" , UseNeutralRemap = true },
				new StructureType("V32") { FullName =	"Rikitikitembo's Hut" , UseNeutralRemap = true },
				new StructureType("V33") { FullName =	"Roarke's Hut" , UseNeutralRemap = true },
				new StructureType("V34") { FullName =	"Mubasa's Hut" , UseNeutralRemap = true },
				new StructureType("V35") { FullName =	"Aksum's Hut" , UseNeutralRemap = true },
				new StructureType("V36") { FullName =	"Mambo's Hut" , UseNeutralRemap = true },
				new StructureType("V37") { FullName = "The Studio" , UseNeutralRemap = true },

				new StructureType("BARL") { FullName = "Barrel" , UseNeutralRemap = true },
				new StructureType("BRL3") { FullName = "Barrels" , UseNeutralRemap = true },

				new StructureType("QUEE") { FullName = "Queen Ant" },
				new StructureType("LAR1") { FullName = "Larva" , UseNeutralRemap = true },
				new StructureType("LAR2") { FullName = "Larvae" , UseNeutralRemap = true },
			};

			string[] lStr = new string[_listType.Count];
			for (int i = 0; i < _listType.Count; i++)
      {
				lStr[i] = _listType[i].ID;
			}
			_listString = new List<string>(lStr);
			_originalRulesEntryCount = _listType.Count;
		}
	}
}
