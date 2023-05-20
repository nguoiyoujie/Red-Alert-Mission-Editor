using System;
using System.Xml.Linq;

namespace RA_Mission_Editor.RulesData
{
	public class TriggerActionType
	{
		public string ID { get; }
		public string Description { get; }
		public TriggerParameterFlag P1Type { get; }
		public TriggerParameterFlag P2Type { get; }
		public TriggerParameterFlag P3Type { get; }
    public string P1Name { get; }
    public string P2Name { get; }
    public string P3Name { get; }

    public TriggerActionType(string id, string description = null, TriggerParameterFlag p1Type = default, string p1Name = null, TriggerParameterFlag p2Type = default, string p2Name = null, TriggerParameterFlag p3Type = default, string p3Name = null)
		{
			ID = id;
			Description = description ?? string.Empty;
			P1Type = p1Type;
			P2Type = p2Type;
			P3Type = p3Type;
			P1Name = p1Name ?? p1Type.ToString();
      P2Name = p2Name ?? p2Type.ToString();
      P3Name = p3Name ?? p3Type.ToString();

    }

    public override string ToString()
		{
			return ID;
		}
	}

	[Flags]
	public enum TriggerParameterFlag
	{
		// applicable for both Actions and Events
		NONE = 0, // disable and set to -1

		// things that can be satisfied with a number, or do not belong to other categories
		INTEGER = 1 << 0,

		// Can only support using integer IDs.
		TIME = 1 << 1,
		MESSAGE = 1 << 2,
		SPEECH = 1 << 3,
		SOUND = 1 << 4,
		MOVIE = 1 << 5,
		THEME = 1 << 6,
		WAYPOINT = 1 << 7,
		GLOBALS = 1 << 8,

		// populate a list, append if more than one flag is indicated 
		HOUSE = 1 << 9,
		TRIGGER = 1 << 10,
		TEAMTYPE = 1 << 11,

		// TechnoTypes
		STRUCTURETYPE = 1 << 12,
		UNITTYPE = 1 << 13,
		SHIPTYPE = 1 << 14,
		AIRCRAFTTYPE = 1 << 15,
		INFANTRYTYPE = 1 << 16,

		// Superweapon
		SWTYPE = 1 << 17,

		// Special, targeting
		QUARRY = 1 << 18,

		// Only used in Iran's additions
		COLOR = 1 << 19,
		MISSIONTYPE = 1 << 20,
	}

	public static class TriggerParameterExt
	{
		public static bool Contains(this TriggerParameterFlag flag, TriggerParameterFlag subflag)
    {
			return (flag | subflag) == subflag;
    }
	}
}
