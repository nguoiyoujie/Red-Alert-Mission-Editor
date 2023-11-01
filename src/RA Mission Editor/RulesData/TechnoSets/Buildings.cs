using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData.TechnoSets
{
  public class Buildings : TechnoList<BuildingType>
	{
		public Buildings()
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
      _listType = new List<BuildingType>()
			{
				new BuildingType("ATEK") { FullName = "Allied Tech Center", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("IRON") { FullName = "Iron Curtain",  Occupancy = { p0_1, p1_1 } },
				new BuildingType("WEAP") { FullName = "War Factory", BibName = "BIB2", SecondImage = "WEAP2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new BuildingType("PDOX") { FullName = "Chronosphere", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("PBOX") { FullName = "Pillbox", Occupancy = { p0_0 } },
				new BuildingType("HBOX") { FullName = "Camo. Pillbox", Occupancy = { p0_0 } },
				new BuildingType("DOME") { FullName = "Radar Dome", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("GAP") { FullName = "Gap Generator", Occupancy = { p0_1 } },
				new BuildingType("GUN") { FullName = "Turret", TurretDirections = 32, Occupancy = { p0_0 } },
				new BuildingType("AGUN") { FullName = "AA Gun", TurretDirections = 32, Occupancy = { p0_1 } },
				new BuildingType("FTUR") { FullName = "Flame Tower", Occupancy = { p0_0 } },
				new BuildingType("FACT") { FullName = "Construction Yard", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("PROC") { FullName = "Ore Refinery", BibName = "BIB2", Occupancy = { p1_0, p0_1, p1_1, p2_1, p2_2 } },
				new BuildingType("SILO") { FullName = "Ore Silo", Occupancy = { p0_0 } },
				new BuildingType("HPAD") { FullName = "Helipad", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("SAM") { FullName = "SAM Site", TurretDirections = 32, Occupancy = { p0_0, p1_0 } },
				new BuildingType("AFLD") { FullName = "Airfield", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new BuildingType("POWR") { FullName = "Power Plant", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("APWR") { FullName = "Adv. Power Plant", BibName = "BIB2", Occupancy = { p0_1, p1_1, p2_1, p0_2, p1_2, p2_2 } },
				new BuildingType("STEK") { FullName = "Soviet Tech Center", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new BuildingType("HOSP") { FullName = "Hospital", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("BARR") { FullName = "Barracks (Soviet)", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("TENT") { FullName = "Barracks (Allied)", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("KENN") { FullName = "Kennel", Occupancy = { p0_0 } },
				new BuildingType("FIX") { FullName = "Service Depot", Occupancy = { p1_0, p0_1, p1_1, p2_1, p1_2 } },
				new BuildingType("BIO") { FullName = "Bio-Research Lab", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("MISS") { FullName = "Technology Center", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new BuildingType("SYRD") { FullName = "Naval Yard", IsNaval = true, Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("SPEN") { FullName = "Sub Pen", IsNaval = true, Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("MSLO") { FullName = "Missile Silo", Occupancy = { p0_0, p1_0 } },
				new BuildingType("FCOM") { FullName = "Forward Command Post", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },
				new BuildingType("TSLA") { FullName = "Tesla Coil", Occupancy = { p0_1 } },

				new BuildingType("WEAF") { FullName = "Fake War Factory", IsFake = true, TrueID = "WEAP", BibName = "BIB2", SecondImage = "WEAP2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1 } },
				new BuildingType("FACF") { FullName = "Fake Const. Yard", IsFake = true, TrueID = "FACT", BibName = "BIB2", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("SYRF") { FullName = "Fake Naval Yard", IsNaval = true, IsFake = true, TrueID = "SYRD", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("SPEF") { FullName = "Fake Sub Pen", IsNaval = true, IsFake = true, TrueID = "SPEN", Occupancy = { p0_0, p1_0, p2_0, p0_1, p1_1, p2_1, p0_2, p1_2 , p2_2 } },
				new BuildingType("DOMF") { FullName = "Fake Radar Dome", IsFake = true, TrueID = "DOME", BibName = "BIB3", Occupancy = { p0_0, p1_0, p0_1, p1_1 } },

				new BuildingType("SBAG") { FullName = "Sandbags" , UseNeutralRemap = true, Occupancy = { p0_0 }},
				new BuildingType("CYCL") { FullName = "Chain Link Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("BRIK") { FullName = "Concrete Wall" , UseNeutralRemap = true, Occupancy = { p0_0 }},
				new BuildingType("BARB") { FullName = "Barbwire Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("WOOD") { FullName = "Wood Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("FENC") { FullName = "Wire Fence" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new BuildingType("MINV") { FullName = "Anti-Vehicle Mine" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("MINP") { FullName = "Anti-Personnel Mine" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new BuildingType("V01") { FullName = "Church" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new BuildingType("V02") { FullName = "Han's and Gretel's" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new BuildingType("V03") { FullName = "Hewitt's Manor" , UseNeutralRemap = true, Occupancy = { p1_0, p0_1, p1_1 } },
				new BuildingType("V04") { FullName = "Ricktor's House" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new BuildingType("V05") { FullName = "Gretchin's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V06") { FullName = "The Barn" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V07") { FullName = "Damon's Pub" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V08") { FullName = "Fran's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V09") { FullName = "Music Factory" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V10") { FullName = "Toymaker's" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V11") { FullName = "Ludwig's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V12") { FullName = "Haystacks" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V13") { FullName = "Haystack" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V14") { FullName = "Wheat Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V15") { FullName = "Fallow Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V16") { FullName = "Corn Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V17") { FullName = "Celery Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V18") { FullName = "Potato Field" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V19") { FullName = "Oil Pump" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				// other 
				new BuildingType("V20") { FullName = "Sala's House" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new BuildingType("V21") { FullName = "Abdul's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0, p1_1 } },
				new BuildingType("V22") { FullName = "Pablo's Wicked Pub" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V23") { FullName = "Village Well" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V24") { FullName = "Camel Trader" , UseNeutralRemap = true, Occupancy = { p0_1, p1_1 } },
				new BuildingType("V25") { FullName = "Church" , UseNeutralRemap = true, Occupancy = { p1_0, p0_1, p1_1 } },
				new BuildingType("V26") { FullName = "Ali's House" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V27") { FullName = "Trader Ted's" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V28") { FullName = "Menelik's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V29") { FullName =	"Prestor John's House" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V30") { FullName =	"Village Well" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 }},
				new BuildingType("V31") { FullName =	"Witch Doctor's Hut" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V32") { FullName =	"Rikitikitembo's Hut" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0 } },
				new BuildingType("V33") { FullName =	"Roarke's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V34") { FullName =	"Mubasa's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V35") { FullName =	"Aksum's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V36") { FullName =	"Mambo's Hut" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("V37") { FullName = "The Studio" , UseNeutralRemap = true, Occupancy = { p0_0, p1_0, p2_0, p3_0, p0_1, p1_1, p2_1, p3_1 } },

				new BuildingType("BARL") { FullName = "Barrel" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("BRL3") { FullName = "Barrels" , UseNeutralRemap = true, Occupancy = { p0_0 } },

				new BuildingType("QUEE") { FullName = "Queen Ant", Occupancy = { p0_0, p1_0 } },
				new BuildingType("LAR1") { FullName = "Larva" , UseNeutralRemap = true, Occupancy = { p0_0 } },
				new BuildingType("LAR2") { FullName = "Larvae" , UseNeutralRemap = true, Occupancy = { p0_0 } },
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
