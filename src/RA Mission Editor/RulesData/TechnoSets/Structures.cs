using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Structures : TechnoList<StructureType>
	{
		public Structures()
    {
			Point p0_0 = new Point(0, 0);
      Point p1_0 = new Point(1, 0);
      Point p2_0 = new Point(2, 0);
      Point p3_0 = new Point(3, 0);
      Point p0_1 = new Point(0, 1);
      Point p1_1 = new Point(1, 1);
      Point p2_1 = new Point(2, 1);
      Point p3_1 = new Point(3, 1);
      Point p0_2 = new Point(0, 2);
      Point p1_2 = new Point(1, 2);
      Point p2_2 = new Point(2, 2);

      // See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/BDATA.CPP
      _listType = new List<StructureType>()
			{
				new StructureType("ATEK") { FullName = "Allied Tech Center", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("IRON") { FullName = "Iron Curtain",  Occupancy = { p0_0, p1_0 } },
				new StructureType("WEAP") { FullName = "War Factory", BibName = "BIB2", SecondImage = "WEAP2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("PDOX") { FullName = "Chronosphere", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("PBOX") { FullName = "Pillbox", Occupancy = { p0_0 } },
				new StructureType("HBOX") { FullName = "Camo. Pillbox", Occupancy = { p0_0 } },
				new StructureType("DOME") { FullName = "Radar Dome", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("GAP") { FullName = "Gap Generator", Occupancy = { p0_1 } },
				new StructureType("GUN") { FullName = "Turret", TurretDirections = 32, Occupancy = { p0_0 } },
				new StructureType("AGUN") { FullName = "AA Gun", TurretDirections = 32, Occupancy = { p0_1 } },
				new StructureType("FTUR") { FullName = "Flame Tower", Occupancy = { p0_0 } },
				new StructureType("FACT") { FullName = "Construction Yard", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("PROC") { FullName = "Ore Refinery", BibName = "BIB2", Occupancy = { p1_0, p0_1, p1_1, p2_1, p2_2 } },
				new StructureType("SILO") { FullName = "Ore Silo", Occupancy = { p0_0 } },
				new StructureType("HPAD") { FullName = "Helipad", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("SAM") { FullName = "SAM Site", TurretDirections = 32, Occupancy = { p0_0, p1_0 } },
				new StructureType("AFLD") { FullName = "Airfield", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("POWR") { FullName = "Power Plant", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("APWR") { FullName = "Adv. Power Plant", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("STEK") { FullName = "Soviet Tech Center", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("HOSP") { FullName = "Hospital", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("BARR") { FullName = "Barracks (Soviet)", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("TENT") { FullName = "Barracks (Allied)", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("KENN") { FullName = "Kennel", Occupancy = { p0_0 } },
				new StructureType("FIX") { FullName = "Service Depot", Occupancy = { p1_0, p0_1, p1_1, p2_1, p1_2 } },
				new StructureType("BIO") { FullName = "Bio-Research Lab", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("MISS") { FullName = "Technology Center", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("SYRD") { FullName = "Naval Yard", IsNaval = true, Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("SPEN") { FullName = "Sub Pen", IsNaval = true, Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("MSLO") { FullName = "Missile Silo", Occupancy = { p0_0, p1_0 } },
				new StructureType("FCOM") { FullName = "Forward Command Post", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new StructureType("TSLA") { FullName = "Tesla Coil", Occupancy = { p0_1 } },

				new StructureType("WEAF") { FullName = "Fake War Factory", IsFake = true, TrueID = "WEAP", BibName = "BIB2", SecondImage = "WEAP2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new StructureType("FACF") { FullName = "Fake Const. Yard", IsFake = true, TrueID = "FACT", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("SYRF") { FullName = "Fake Naval Yard", IsNaval = true, IsFake = true, TrueID = "SYRD", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("SPEF") { FullName = "Fake Sub Pen", IsNaval = true, IsFake = true, TrueID = "SPEN", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new StructureType("DOMF") { FullName = "Fake Radar Dome", IsFake = true, TrueID = "DOME", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },

				new StructureType("SBAG") { FullName = "Sandbags" , UseNeutralRemap = true, Occupancy = { p0_0 }},
				new StructureType("CYCL") { FullName = "Chain Link Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("BRIK") { FullName = "Concrete Wall" , UseNeutralRemap = true, Occupancy = { p0_0 }},
				new StructureType("BARB") { FullName = "Barbwire Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("WOOD") { FullName = "Wood Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("FENC") { FullName = "Wire Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new StructureType("MINV") { FullName = "Anti-Vehicle Mine" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("MINP") { FullName = "Anti-Personnel Mine" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new StructureType("V01") { FullName = "Church" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new StructureType("V02") { FullName = "Han's and Gretel's" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new StructureType("V03") { FullName = "Hewitt's Manor" , UseNeutralRemap = true, Occupancy = { p1_0, p0_1, p1_1 } },
				new StructureType("V04") { FullName = "Ricktor's House" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new StructureType("V05") { FullName = "Gretchin's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V06") { FullName = "The Barn" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V07") { FullName = "Damon's Pub" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V08") { FullName = "Fran's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V09") { FullName = "Music Factory" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V10") { FullName = "Toymaker's" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V11") { FullName = "Ludwig's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V12") { FullName = "Haystacks" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V13") { FullName = "Haystack" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V14") { FullName = "Wheat Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V15") { FullName = "Fallow Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V16") { FullName = "Corn Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V17") { FullName = "Celery Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V18") { FullName = "Potato Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V19") { FullName = "Oil Pump" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				// other 
				new StructureType("V20") { FullName = "Sala's House" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new StructureType("V21") { FullName = "Abdul's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0, p1_1 } },
				new StructureType("V22") { FullName = "Pablo's Wicked Pub" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V23") { FullName = "Village Well" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V24") { FullName = "Camel Trader" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new StructureType("V25") { FullName = "Church" , UseNeutralRemap = true, Occupancy = { p1_0, p0_1, p1_1 } },
				new StructureType("V26") { FullName = "Ali's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V27") { FullName = "Trader Ted's" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V28") { FullName = "Menelik's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V29") { FullName =	"Prestor John's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V30") { FullName =	"Village Well" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 }},
				new StructureType("V31") { FullName =	"Witch Doctor's Hut" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V32") { FullName =	"Rikitikitembo's Hut" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new StructureType("V33") { FullName =	"Roarke's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V34") { FullName =	"Mubasa's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V35") { FullName =	"Aksum's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V36") { FullName =	"Mambo's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("V37") { FullName = "The Studio" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0, p2_0, p3_0, p0_1, p1_1, p2_1, p3_1 } },

				new StructureType("BARL") { FullName = "Barrel" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("BRL3") { FullName = "Barrels" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new StructureType("QUEE") { FullName = "Queen Ant", Occupancy = { p0_0, p1_0 } },
				new StructureType("LAR1") { FullName = "Larva" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new StructureType("LAR2") { FullName = "Larvae" , UseNeutralRemap = true, Occupancy = { p0_0 } },
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
