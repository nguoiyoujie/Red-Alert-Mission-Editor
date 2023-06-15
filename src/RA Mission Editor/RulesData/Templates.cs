using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RA_Mission_Editor.RulesData
{
  public static class Templates
  {
		private readonly static List<TemplateType> _listTemplate = new List<TemplateType>();
		private readonly static List<string> _listString = new List<string>();

		static Templates()
    {
			_listTemplate = new List<TemplateType>()
			{
				/* Default clear land */
				new TemplateType(LandType.LAND_CLEAR, "CLEAR1"),
				/* Water */
				new TemplateType(LandType.LAND_WATER, "W1"), 
				new TemplateType(LandType.LAND_WATER, "W2"),
				/* Shores */
				new TemplateType(LandType.LAND_BEACH, "SH01"),
				new TemplateType(LandType.LAND_BEACH, "SH02"),
				new TemplateType(LandType.LAND_BEACH, "SH03"),
				new TemplateType(LandType.LAND_BEACH, "SH04"),
				new TemplateType(LandType.LAND_BEACH, "SH05"),
				new TemplateType(LandType.LAND_BEACH, "SH06"),
				new TemplateType(LandType.LAND_BEACH, "SH07"),
				new TemplateType(LandType.LAND_BEACH, "SH08"),
				new TemplateType(LandType.LAND_BEACH, "SH09"),
				new TemplateType(LandType.LAND_BEACH, "SH10"),
				new TemplateType(LandType.LAND_BEACH, "SH11"),
				new TemplateType(LandType.LAND_BEACH, "SH12"),
				new TemplateType(LandType.LAND_BEACH, "SH13"),
				new TemplateType(LandType.LAND_BEACH, "SH14"),
				new TemplateType(LandType.LAND_BEACH, "SH15"),
				new TemplateType(LandType.LAND_BEACH, "SH16"),
				new TemplateType(LandType.LAND_BEACH, "SH17"),
				new TemplateType(LandType.LAND_BEACH, "SH18"),
				new TemplateType(LandType.LAND_BEACH, "SH19"),
				new TemplateType(LandType.LAND_BEACH, "SH20"),
				new TemplateType(LandType.LAND_BEACH, "SH21"),
				new TemplateType(LandType.LAND_BEACH, "SH22"),
				new TemplateType(LandType.LAND_BEACH, "SH23"),
				new TemplateType(LandType.LAND_BEACH, "SH24"),
				new TemplateType(LandType.LAND_BEACH, "SH25"),
				new TemplateType(LandType.LAND_BEACH, "SH26"),
				new TemplateType(LandType.LAND_BEACH, "SH27"),
				new TemplateType(LandType.LAND_BEACH, "SH28"),
				new TemplateType(LandType.LAND_BEACH, "SH29"),
				new TemplateType(LandType.LAND_BEACH, "SH30"),
				new TemplateType(LandType.LAND_BEACH, "SH31"),
				new TemplateType(LandType.LAND_BEACH, "SH32"),
				new TemplateType(LandType.LAND_BEACH, "SH33"),
				new TemplateType(LandType.LAND_BEACH, "SH34"),
				new TemplateType(LandType.LAND_BEACH, "SH35"),
				new TemplateType(LandType.LAND_BEACH, "SH36"),
				new TemplateType(LandType.LAND_BEACH, "SH37"),
				new TemplateType(LandType.LAND_BEACH, "SH38"),
				new TemplateType(LandType.LAND_BEACH, "SH39"),
				new TemplateType(LandType.LAND_BEACH, "SH40"),
				new TemplateType(LandType.LAND_BEACH, "SH41"),
				new TemplateType(LandType.LAND_BEACH, "SH42"),
				new TemplateType(LandType.LAND_BEACH, "SH43"),
				new TemplateType(LandType.LAND_BEACH, "SH44"),
				new TemplateType(LandType.LAND_BEACH, "SH45"),
				new TemplateType(LandType.LAND_BEACH, "SH46"),
				new TemplateType(LandType.LAND_BEACH, "SH47"),
				new TemplateType(LandType.LAND_BEACH, "SH48"),
				new TemplateType(LandType.LAND_BEACH, "SH49"),
				new TemplateType(LandType.LAND_BEACH, "SH50"),
				new TemplateType(LandType.LAND_BEACH, "SH51"),
				new TemplateType(LandType.LAND_BEACH, "SH52"),
				new TemplateType(LandType.LAND_BEACH, "SH53"),
				new TemplateType(LandType.LAND_BEACH, "SH54"),
				new TemplateType(LandType.LAND_BEACH, "SH55"),
				new TemplateType(LandType.LAND_BEACH, "SH56"),
				/* Shore Cliffs */
				new TemplateType(LandType.LAND_ROCK, "WC01"),
				new TemplateType(LandType.LAND_ROCK, "WC02"),
				new TemplateType(LandType.LAND_ROCK, "WC03"),
				new TemplateType(LandType.LAND_ROCK, "WC04"),
				new TemplateType(LandType.LAND_ROCK, "WC05"),
				new TemplateType(LandType.LAND_ROCK, "WC06"),
				new TemplateType(LandType.LAND_ROCK, "WC07"),
				new TemplateType(LandType.LAND_ROCK, "WC08"),
				new TemplateType(LandType.LAND_ROCK, "WC09"),
				new TemplateType(LandType.LAND_ROCK, "WC10"),
				new TemplateType(LandType.LAND_ROCK, "WC11"),
				new TemplateType(LandType.LAND_ROCK, "WC12"),
				new TemplateType(LandType.LAND_ROCK, "WC13"),
				new TemplateType(LandType.LAND_ROCK, "WC14"),
				new TemplateType(LandType.LAND_ROCK, "WC15"),
				new TemplateType(LandType.LAND_ROCK, "WC16"),
				new TemplateType(LandType.LAND_ROCK, "WC17"),
				new TemplateType(LandType.LAND_ROCK, "WC18"),
				new TemplateType(LandType.LAND_ROCK, "WC19"),
				new TemplateType(LandType.LAND_ROCK, "WC20"),
				new TemplateType(LandType.LAND_ROCK, "WC21"),
				new TemplateType(LandType.LAND_ROCK, "WC22"),
				new TemplateType(LandType.LAND_ROCK, "WC23"),
				new TemplateType(LandType.LAND_ROCK, "WC24"),
				new TemplateType(LandType.LAND_ROCK, "WC25"),
				new TemplateType(LandType.LAND_ROCK, "WC26"),
				new TemplateType(LandType.LAND_ROCK, "WC27"),
				new TemplateType(LandType.LAND_ROCK, "WC28"),
				new TemplateType(LandType.LAND_ROCK, "WC29"),
				new TemplateType(LandType.LAND_ROCK, "WC30"),
				new TemplateType(LandType.LAND_ROCK, "WC31"),
				new TemplateType(LandType.LAND_ROCK, "WC32"),
				new TemplateType(LandType.LAND_ROCK, "WC33"),
				new TemplateType(LandType.LAND_ROCK, "WC34"),
				new TemplateType(LandType.LAND_ROCK, "WC35"),
				new TemplateType(LandType.LAND_ROCK, "WC36"),
				new TemplateType(LandType.LAND_ROCK, "WC37"),
				new TemplateType(LandType.LAND_ROCK, "WC38"),
				/* Boulders (6 are defined though only 3 have assets */
				new TemplateType(LandType.LAND_ROCK, "B1"),
				new TemplateType(LandType.LAND_ROCK, "B2"),
				new TemplateType(LandType.LAND_ROCK, "B3"),
				new TemplateType(LandType.LAND_ROCK, "B4"),
				new TemplateType(LandType.LAND_ROCK, "B5"),
				new TemplateType(LandType.LAND_ROCK, "B6"),
				/* Patches (note some missing numbers */
				new TemplateType(LandType.LAND_ROUGH, "P01"),
				new TemplateType(LandType.LAND_ROUGH, "P02"),
				new TemplateType(LandType.LAND_ROUGH, "P03"),
				new TemplateType(LandType.LAND_ROUGH, "P04"),
				new TemplateType(LandType.LAND_ROUGH, "P07"),
				new TemplateType(LandType.LAND_ROUGH, "P08"),
				new TemplateType(LandType.LAND_ROUGH, "P13"),
				new TemplateType(LandType.LAND_ROUGH, "P14"),
				new TemplateType(LandType.LAND_ROUGH, "P15"),
				/* Rivers */
				new TemplateType(LandType.LAND_RIVER, "RV01"),
				new TemplateType(LandType.LAND_RIVER, "RV02"),
				new TemplateType(LandType.LAND_RIVER, "RV03"),
				new TemplateType(LandType.LAND_RIVER, "RV04"),
				new TemplateType(LandType.LAND_RIVER, "RV05"),
				new TemplateType(LandType.LAND_RIVER, "RV06"),
				new TemplateType(LandType.LAND_RIVER, "RV07"),
				new TemplateType(LandType.LAND_RIVER, "RV08"),
				new TemplateType(LandType.LAND_RIVER, "RV09"),
				new TemplateType(LandType.LAND_RIVER, "RV10"),
				new TemplateType(LandType.LAND_RIVER, "RV11"),
				new TemplateType(LandType.LAND_RIVER, "RV12"),
				new TemplateType(LandType.LAND_RIVER, "RV13"),
				/* Falls */
				new TemplateType(LandType.LAND_RIVER, "FALLS1"),
				new TemplateType(LandType.LAND_RIVER, "FALLS1A"),
				new TemplateType(LandType.LAND_RIVER, "FALLS2"),
				new TemplateType(LandType.LAND_RIVER, "FALLS2A"),
				/* Fords */
				new TemplateType(LandType.LAND_BEACH, "FORD1"),
				new TemplateType(LandType.LAND_BEACH, "FORD2"),
				/* Bridges */
				new TemplateType(LandType.LAND_RIVER, "BRIDGE1"),
				new TemplateType(LandType.LAND_RIVER, "BRIDGE1D"),
				new TemplateType(LandType.LAND_RIVER, "BRIDGE2"),
				new TemplateType(LandType.LAND_RIVER, "BRIDGE2D"),
				/* Slopes (Cliffs) */
				new TemplateType(LandType.LAND_ROCK, "S01"),
				new TemplateType(LandType.LAND_ROCK, "S02"),
				new TemplateType(LandType.LAND_ROCK, "S03"),
				new TemplateType(LandType.LAND_ROCK, "S04"),
				new TemplateType(LandType.LAND_ROCK, "S05"),
				new TemplateType(LandType.LAND_ROCK, "S06"),
				new TemplateType(LandType.LAND_ROCK, "S07"),
				new TemplateType(LandType.LAND_ROCK, "S08"),
				new TemplateType(LandType.LAND_ROCK, "S09"),
				new TemplateType(LandType.LAND_ROCK, "S10"),
				new TemplateType(LandType.LAND_ROCK, "S11"),
				new TemplateType(LandType.LAND_ROCK, "S12"),
				new TemplateType(LandType.LAND_ROCK, "S13"),
				new TemplateType(LandType.LAND_ROCK, "S14"),
				new TemplateType(LandType.LAND_ROCK, "S15"),
				new TemplateType(LandType.LAND_ROCK, "S16"),
				new TemplateType(LandType.LAND_ROCK, "S17"),
				new TemplateType(LandType.LAND_ROCK, "S18"),
				new TemplateType(LandType.LAND_ROCK, "S19"),
				new TemplateType(LandType.LAND_ROCK, "S20"),
				new TemplateType(LandType.LAND_ROCK, "S21"),
				new TemplateType(LandType.LAND_ROCK, "S22"),
				new TemplateType(LandType.LAND_ROCK, "S23"),
				new TemplateType(LandType.LAND_ROCK, "S24"),
				new TemplateType(LandType.LAND_ROCK, "S25"),
				new TemplateType(LandType.LAND_ROCK, "S26"),
				new TemplateType(LandType.LAND_ROCK, "S27"),
				new TemplateType(LandType.LAND_ROCK, "S28"),
				new TemplateType(LandType.LAND_ROCK, "S29"),
				new TemplateType(LandType.LAND_ROCK, "S30"),
				new TemplateType(LandType.LAND_ROCK, "S31"),
				new TemplateType(LandType.LAND_ROCK, "S32"),
				new TemplateType(LandType.LAND_ROCK, "S33"),
				new TemplateType(LandType.LAND_ROCK, "S34"),
				new TemplateType(LandType.LAND_ROCK, "S35"),
				new TemplateType(LandType.LAND_ROCK, "S36"),
				new TemplateType(LandType.LAND_ROCK, "S37"),
				new TemplateType(LandType.LAND_ROCK, "S38"),
				/* Dirt Roads */
				new TemplateType(LandType.LAND_ROAD, "D01"),
				new TemplateType(LandType.LAND_ROAD, "D02"),
				new TemplateType(LandType.LAND_ROAD, "D03"),
				new TemplateType(LandType.LAND_ROAD, "D04"),
				new TemplateType(LandType.LAND_ROAD, "D05"),
				new TemplateType(LandType.LAND_ROAD, "D06"),
				new TemplateType(LandType.LAND_ROAD, "D07"),
				new TemplateType(LandType.LAND_ROAD, "D08"),
				new TemplateType(LandType.LAND_ROAD, "D09"),
				new TemplateType(LandType.LAND_ROAD, "D10"),
				new TemplateType(LandType.LAND_ROAD, "D11"),
				new TemplateType(LandType.LAND_ROAD, "D12"),
				new TemplateType(LandType.LAND_ROAD, "D13"),
				new TemplateType(LandType.LAND_ROAD, "D14"),
				new TemplateType(LandType.LAND_ROAD, "D15"),
				new TemplateType(LandType.LAND_ROAD, "D16"),
				new TemplateType(LandType.LAND_ROAD, "D17"),
				new TemplateType(LandType.LAND_ROAD, "D18"),
				new TemplateType(LandType.LAND_ROAD, "D19"),
				new TemplateType(LandType.LAND_ROAD, "D20"),
				new TemplateType(LandType.LAND_ROAD, "D21"),
				new TemplateType(LandType.LAND_ROAD, "D22"),
				new TemplateType(LandType.LAND_ROAD, "D23"),
				new TemplateType(LandType.LAND_ROAD, "D24"),
				new TemplateType(LandType.LAND_ROAD, "D25"),
				new TemplateType(LandType.LAND_ROAD, "D26"),
				new TemplateType(LandType.LAND_ROAD, "D27"),
				new TemplateType(LandType.LAND_ROAD, "D28"),
				new TemplateType(LandType.LAND_ROAD, "D29"),
				new TemplateType(LandType.LAND_ROAD, "D30"),
				new TemplateType(LandType.LAND_ROAD, "D31"),
				new TemplateType(LandType.LAND_ROAD, "D32"),
				new TemplateType(LandType.LAND_ROAD, "D33"),
				new TemplateType(LandType.LAND_ROAD, "D34"),
				new TemplateType(LandType.LAND_ROAD, "D35"),
				new TemplateType(LandType.LAND_ROAD, "D36"),
				new TemplateType(LandType.LAND_ROAD, "D37"),
				new TemplateType(LandType.LAND_ROAD, "D38"),
				new TemplateType(LandType.LAND_ROAD, "D39"),
				new TemplateType(LandType.LAND_ROAD, "D40"),
				new TemplateType(LandType.LAND_ROAD, "D41"),
				new TemplateType(LandType.LAND_ROAD, "D42"),
				new TemplateType(LandType.LAND_ROAD, "D43"),
				/* Rough */
				new TemplateType(LandType.LAND_ROAD, "RF01"),
				new TemplateType(LandType.LAND_ROAD, "RF02"),
				new TemplateType(LandType.LAND_ROAD, "RF03"),
				new TemplateType(LandType.LAND_ROAD, "RF04"),
				new TemplateType(LandType.LAND_ROAD, "RF05"),
				new TemplateType(LandType.LAND_ROAD, "RF06"),
				new TemplateType(LandType.LAND_ROAD, "RF07"),
				new TemplateType(LandType.LAND_ROAD, "RF08"),
				new TemplateType(LandType.LAND_ROAD, "RF09"),
				new TemplateType(LandType.LAND_ROAD, "RF10"),
				new TemplateType(LandType.LAND_ROAD, "RF11"),
				/* More Dirt Roads */
				new TemplateType(LandType.LAND_ROAD, "D44"),
				new TemplateType(LandType.LAND_ROAD, "D45"),
				/* More Rivers */
				new TemplateType(LandType.LAND_RIVER, "RV14"),
				new TemplateType(LandType.LAND_RIVER, "RV15"),
				/* River Cliffs */
				new TemplateType(LandType.LAND_ROCK, "RC01"),
				new TemplateType(LandType.LAND_ROCK, "RC02"),
				new TemplateType(LandType.LAND_ROCK, "RC03"),
				new TemplateType(LandType.LAND_ROCK, "RC04"),
				/* Big Bridges */
				new TemplateType(LandType.LAND_RIVER, "BR1A"),
				new TemplateType(LandType.LAND_RIVER, "BR1B"),
				new TemplateType(LandType.LAND_RIVER, "BR1C"),
				new TemplateType(LandType.LAND_RIVER, "BR2A"),
				new TemplateType(LandType.LAND_RIVER, "BR2B"),
				new TemplateType(LandType.LAND_RIVER, "BR2C"),
				new TemplateType(LandType.LAND_RIVER, "BR3A"),
				new TemplateType(LandType.LAND_RIVER, "BR3B"),
				new TemplateType(LandType.LAND_RIVER, "BR3C"),
				new TemplateType(LandType.LAND_RIVER, "BR3D"),
				new TemplateType(LandType.LAND_RIVER, "BR3E"),
				new TemplateType(LandType.LAND_RIVER, "BR3F"),
				/* Big Fords */
				new TemplateType(LandType.LAND_BEACH, "F01"),
				new TemplateType(LandType.LAND_BEACH, "F02"),
				new TemplateType(LandType.LAND_BEACH, "F03"),
				new TemplateType(LandType.LAND_BEACH, "F04"),
				new TemplateType(LandType.LAND_BEACH, "F05"),
				new TemplateType(LandType.LAND_BEACH, "F06"),
				/* Interior Pieces */
				/* Arrow on the ground */
				new TemplateType(LandType.LAND_CLEAR, "ARRO0001"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0002"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0003"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0004"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0005"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0006"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0007"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0008"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0009"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0010"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0011"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0012"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0013"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0014"),
				new TemplateType(LandType.LAND_CLEAR, "ARRO0015"),
				/* Floor */
				new TemplateType(LandType.LAND_CLEAR, "FLOR0001"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0002"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0003"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0004"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0005"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0006"),
				new TemplateType(LandType.LAND_CLEAR, "FLOR0007"),
				/* Grey Floor */
				new TemplateType(LandType.LAND_CLEAR, "GFLR0001"),
				new TemplateType(LandType.LAND_CLEAR, "GFLR0002"),
				new TemplateType(LandType.LAND_CLEAR, "GFLR0003"),
				new TemplateType(LandType.LAND_CLEAR, "GFLR0004"),
				new TemplateType(LandType.LAND_CLEAR, "GFLR0005"),
				/* Grey Floor with Strip */
				new TemplateType(LandType.LAND_CLEAR, "GSTR0001"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0002"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0003"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0004"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0005"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0006"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0007"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0008"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0009"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0010"),
				new TemplateType(LandType.LAND_CLEAR, "GSTR0011"),
				/* Low Wall */
				new TemplateType(LandType.LAND_ROCK, "LWAL0001"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0002"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0003"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0004"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0005"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0006"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0007"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0008"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0009"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0010"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0011"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0012"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0013"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0014"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0015"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0016"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0017"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0018"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0019"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0020"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0021"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0022"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0023"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0024"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0025"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0026"),
				new TemplateType(LandType.LAND_ROCK, "LWAL0027"),
				/* Floor with Strip */
				new TemplateType(LandType.LAND_CLEAR, "STRP0001"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0002"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0003"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0004"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0005"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0006"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0007"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0008"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0009"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0010"),
				new TemplateType(LandType.LAND_CLEAR, "STRP0011"),
				/* Wall */
				new TemplateType(LandType.LAND_ROCK, "WALL0001"),
				new TemplateType(LandType.LAND_ROCK, "WALL0002"),
				new TemplateType(LandType.LAND_ROCK, "WALL0003"),
				new TemplateType(LandType.LAND_ROCK, "WALL0004"),
				new TemplateType(LandType.LAND_ROCK, "WALL0005"),
				new TemplateType(LandType.LAND_ROCK, "WALL0006"),
				new TemplateType(LandType.LAND_ROCK, "WALL0007"),
				new TemplateType(LandType.LAND_ROCK, "WALL0008"),
				new TemplateType(LandType.LAND_ROCK, "WALL0009"),
				new TemplateType(LandType.LAND_ROCK, "WALL0010"),
				new TemplateType(LandType.LAND_ROCK, "WALL0011"),
				new TemplateType(LandType.LAND_ROCK, "WALL0012"),
				new TemplateType(LandType.LAND_ROCK, "WALL0013"),
				new TemplateType(LandType.LAND_ROCK, "WALL0014"),
				new TemplateType(LandType.LAND_ROCK, "WALL0015"),
				new TemplateType(LandType.LAND_ROCK, "WALL0016"),
				new TemplateType(LandType.LAND_ROCK, "WALL0017"),
				new TemplateType(LandType.LAND_ROCK, "WALL0018"),
				new TemplateType(LandType.LAND_ROCK, "WALL0019"),
				new TemplateType(LandType.LAND_ROCK, "WALL0020"),
				new TemplateType(LandType.LAND_ROCK, "WALL0021"),
				new TemplateType(LandType.LAND_ROCK, "WALL0022"),
				new TemplateType(LandType.LAND_ROCK, "WALL0023"),
				new TemplateType(LandType.LAND_ROCK, "WALL0024"),
				new TemplateType(LandType.LAND_ROCK, "WALL0025"),
				new TemplateType(LandType.LAND_ROCK, "WALL0026"),
				new TemplateType(LandType.LAND_ROCK, "WALL0027"),
				new TemplateType(LandType.LAND_ROCK, "WALL0028"),
				new TemplateType(LandType.LAND_ROCK, "WALL0029"),
				new TemplateType(LandType.LAND_ROCK, "WALL0030"),
				new TemplateType(LandType.LAND_ROCK, "WALL0031"),
				new TemplateType(LandType.LAND_ROCK, "WALL0032"),
				new TemplateType(LandType.LAND_ROCK, "WALL0033"),
				new TemplateType(LandType.LAND_ROCK, "WALL0034"),
				new TemplateType(LandType.LAND_ROCK, "WALL0035"),
				new TemplateType(LandType.LAND_ROCK, "WALL0036"),
				new TemplateType(LandType.LAND_ROCK, "WALL0037"),
				new TemplateType(LandType.LAND_ROCK, "WALL0038"),
				new TemplateType(LandType.LAND_ROCK, "WALL0039"),
				new TemplateType(LandType.LAND_ROCK, "WALL0040"),
				new TemplateType(LandType.LAND_ROCK, "WALL0041"),
				new TemplateType(LandType.LAND_ROCK, "WALL0042"),
				new TemplateType(LandType.LAND_ROCK, "WALL0043"),
				new TemplateType(LandType.LAND_ROCK, "WALL0044"),
				new TemplateType(LandType.LAND_ROCK, "WALL0045"),
				new TemplateType(LandType.LAND_ROCK, "WALL0046"),
				new TemplateType(LandType.LAND_ROCK, "WALL0047"),
				new TemplateType(LandType.LAND_ROCK, "WALL0048"),
				new TemplateType(LandType.LAND_ROCK, "WALL0049"),
				/* Non-Interior Pieces */
				/* More Bridges */
				new TemplateType(LandType.LAND_BEACH, "BRIDGE1H"),
				new TemplateType(LandType.LAND_BEACH, "BRIDGE2H"),
				new TemplateType(LandType.LAND_BEACH, "BR1X"),
				new TemplateType(LandType.LAND_BEACH, "BR2X"),
				new TemplateType(LandType.LAND_BEACH, "BRIDGE1X"),
				new TemplateType(LandType.LAND_BEACH, "BRIDGE2X"),
				/* Interior Pieces */
				/* Extra Pieces */
				new TemplateType(LandType.LAND_ROCK, "XTRA0001"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0002"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0003"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0004"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0005"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0006"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0007"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0008"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0009"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0010"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0011"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0012"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0013"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0014"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0015"),
				new TemplateType(LandType.LAND_ROCK, "XTRA0016"),
				/* Non-Interior Pieces */
				/* Ant Hill */
				new TemplateType(LandType.LAND_ROCK, "HILL01"),
			};

			string[] lStr = new string[_listTemplate.Count];
			for (int i = 0; i < _listTemplate.Count; i++)
      {
				lStr[i] = _listTemplate[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static TemplateType[] GetAll()
		{
			return _listTemplate.ToArray();
		}

		public static object[] GetAsObjectList()
		{
			return GetAll(); //.Select((t) => t).ToArray();
		}

		public static TemplateType Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public static TemplateType Get(int id)
		{
			return id >= 0 && id < _listTemplate.Count ? _listTemplate[id] : default;
		}

		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}

		public static void Extract(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, string dirpath)
		{
			Directory.CreateDirectory(Path.Combine(dirpath, map.MapSection.Theater.ToUpperInvariant()));
			foreach (TemplateType tem in GetAll())
			{
				using (Bitmap bmp = tem.DrawPreview(map, rules, cache, vfs, new Common.PlaceEntityInfo()))
				{
					bmp?.Save(Path.Combine(dirpath, map.MapSection.Theater.ToUpperInvariant(), tem.ID + ".png"));
				}
			}
		}
	}
}
