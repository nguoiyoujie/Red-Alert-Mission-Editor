using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class TDOverlays
  {
    private readonly static Dictionary<string, string> _RemapOverlays = new Dictionary<string, string>();

    static TDOverlays()
    {
			_RemapOverlays = new Dictionary<string, string>()
			{
				{"ROAD", null },
				{"CONC", "CONC" },
				{"SBAG", "SBAG" },
				{"CYCL", "CYCL" },
				{"BRIK", "BRIK" },
				{"BARB", "BARB" },
				{"WOOD", "WOOD" },
				{"T1", "GOLD01" },
				{"T2", "GOLD01" },
				{"T3", "GOLD01" },
				{"T4", "GOLD02" },
				{"T5", "GOLD02" },
				{"T6", "GOLD02" },
				{"T7", "GOLD03" },
				{"T8", "GOLD03" },
				{"T9", "GOLD03" },
				{"T10", "GOLD04" },
				{"T11", "GOLD04" },
				{"T12", "GOLD04" },
				{"V12", "V12" },
				{"V13", "V13" },
				{"V14", "V14" },
				{"V15", "V15" },
				{"V16", "V16" },
				{"V17", "V17" },
				{"V18", "V18" },
				{"FPLS", "FPLS" },
				{"WCRATE", "WCRATE" },
				{"SCRATE", "SCRATE" },
			};
		}

		public static OverlayType GetOverlay(string name)
		{
			if (name == null || !_RemapOverlays.ContainsKey(name)) { return null; }
			string remap = _RemapOverlays[name];
			if (remap == null) { return null; }

      return Overlays.Get(remap);
		}

		public static void ConvertTDOverlapMap(Map map, IniFile tdmap)
		{
			var section = tdmap.GetSection("Overlays");
			if (section == null) { return; }

      foreach (var entry in section.OrderedEntries)
			{
				if (int.TryParse(entry.Key, out int cell))
				{
					OverlayType olay = GetOverlay(entry.Value.Value ?? null);
					if (olay != null && cell >= 0 && cell < 64*64)
					{
						map.OverlayPackSection.Overlay[cell] = (byte)Overlays.GetID(olay.DisplayName);
					}
        }
			}
		}
	}
}
