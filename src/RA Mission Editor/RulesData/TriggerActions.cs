using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class TriggerActions
	{
		private readonly static TriggerActionType _default = new TriggerActionType("-1 - -Invalid-", "This action does nothing");
		private readonly static List<TriggerActionType> _listTriggerAction = new List<TriggerActionType>();
		private readonly static List<string> _listString = new List<string>();

		static TriggerActions()
    {
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/TACTION.CPP
			_listTriggerAction = new List<TriggerActionType>()
			{
				new TriggerActionType("00 - -No Action-", "This action does nothing"),
				new TriggerActionType("01 - Winner is", "The specified HOUSE wins the scenario", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("02 - Loser is", "The specified HOUSE loses the scenario", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("03 - Production Begins", "The specified HOUSE begins production of buildings and units", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("04 - Create Team", "Creates an instance of a TEAMTYPE. The house of the team members is specified by the TEAMTYPE", p1Type: TriggerParameterFlag.TEAMTYPE),
				new TriggerActionType("05 - Destroy All Teams", "Destroys all active instances of a TEAMTYPE", p1Type: TriggerParameterFlag.TEAMTYPE),
				new TriggerActionType("06 - All to Hunt", "The specified HOUSE sets all its units to Hunt", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("07 - Reinforcement (team)", "Spawns an instance of a TEAMTYPE. Spawning rules: Infantries can spawn from transports and buildings on the waypoint. Otherwise, seek the closest cell from the edge of the map. The house of the team members and their spawn location is specified by the TEAMTYPE", p1Type: TriggerParameterFlag.TEAMTYPE),
				new TriggerActionType("08 - Drop Zone Flare (waypoint)", "Drops a flare at a WAYPOINT and reveals the immediate area around it", p3Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("09 - Fire Sale", "The specified HOUSE sells all its buildings and sets its AI to endgame mode, which constantly hunts", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("00 - Play Movie", "Plays the specified MOVIE. Gameplay is suspended while the movie is playing", p3Type: TriggerParameterFlag.MOVIE),
				new TriggerActionType("11 - Text Trigger (ID num)", "Displays the text MESSAGE string, using COLOR pattette (0 = YELLOW, 1 = BLUE, 2 = RED, 3 = GREEN, 4 = ORANGE, 5 = TEAL, 6 = GREY, 7 = BROWN), defaults to GREEN. The COLOR customization is supported only by Lovalmidas' modified game executable", p2Type: TriggerParameterFlag.COLOR, p3Type: TriggerParameterFlag.MESSAGE),
				new TriggerActionType("12 - Destroy Trigger", "Destroys the specified TRIGGER", p2Type: TriggerParameterFlag.TRIGGER),
				new TriggerActionType("13 - Autocreate Begins", "The specified HOUSE begins the periodic selection of teams for creation", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("14 - ~DEACTIVATED~", "Used to be the Capture=Win,Destroy=Lose action in TD, but deactivated in RA. Use the Parallel event type with two Actions to achieve the same effect"),
				new TriggerActionType("15 - Allow Win", "The game maintains a count of triggers per house with this action to block the respective house's win condition. The affected house is the house that owns the trigger. Only if all such triggers have been destroyed shall the blocking mechanism for the house be released. Note that Force Trigger can revive destroyed triggers, and persistently repeating triggers need to be destroyed manually"),
				new TriggerActionType("16 - Reveal all map", "Reveals the entire map to the player"),
				new TriggerActionType("17 - Reveal around waypoint", "Reveals the area around a WAYPOINT to the player", p3Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("18 - Reveal zone of waypoint", "Reveals the zone around a WAYPOINT to the player. The zone is specified by the contiguous zone that is accessible/inaccessible to the Crusher movement type. Zones may be updated if the terrain is changed, such as the destruction of a bridge. Note that Concrete Walls are not Crushable and so may impact zone calculations", p3Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("19 - Play sound effect", "Plays the specified SOUND effect", p3Type: TriggerParameterFlag.SOUND),
				new TriggerActionType("20 - Play music theme", "Plays the specified music THEME", p3Type: TriggerParameterFlag.THEME),
				new TriggerActionType("21 - Play speech", "Plays the specified SPEECH", p3Type: TriggerParameterFlag.SPEECH),
				new TriggerActionType("22 - Force Trigger", "Forces the execution of the specified TRIGGER.", p2Type: TriggerParameterFlag.TRIGGER),
				new TriggerActionType("23 - Timer Start", "Starts the mission timer"),
				new TriggerActionType("24 - Timer Stop", "Pauses the mission timer. The timer will no longer be displayed"),
				new TriggerActionType("25 - Timer Extend (1/10th min)", "Extends the mission timer by the specified TIME. A value of 10 indicates one in-game minute", p3Type: TriggerParameterFlag.TIME),
				new TriggerActionType("26 - Timer Shorten (1/10th min)", "Reduces the mission timer by the specified TIME. A value of 10 indicates one in-game minute", p3Type: TriggerParameterFlag.TIME),
				new TriggerActionType("27 - Timer Set (1/10th min)", "Sets the mission timer to the specified TIME. A value of 10 indicates one in-game minute", p3Type: TriggerParameterFlag.TIME),
				new TriggerActionType("28 - Global Set", "Sets the specified GLOBAL variable", p3Type: TriggerParameterFlag.GLOBALS),
				new TriggerActionType("29 - Global Clear", "Clears the specified GLOBAL variable", p3Type: TriggerParameterFlag.GLOBALS),
				new TriggerActionType("30 - Auto Base Building", "The specified HOUSE begins automatic base building, according to skirmish AI rules", p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("31 - Grow shroud one 'step'", "The shroud enroaches upon the map by one cell"),
				new TriggerActionType("32 - Destroy attached objects", "Destroys buildings, units and infantry that this trigger is attached to. This trigger may also be used to destroy bridges, but only if the trigger is activated on a cell (via the condition event, such as 'Entered By House', or if the trigger is forced and the first Cell Trigger is on the bridge. Each trigger reduces the bridge by one state (normal->damaged->destroyed), so double the triggers to ensure full destruction of the bridge"),
				new TriggerActionType("33 - Add 1-time special weapon", "The trigger house receives a single instance of a SPECIAL WEAPON", p3Type: TriggerParameterFlag.SWTYPE),
				new TriggerActionType("34 - Add repeating special weapon", "The trigger house receives a persistent instance of a SPECIAL WEAPON", p3Type: TriggerParameterFlag.SWTYPE),
				new TriggerActionType("35 - Preferred target ~INEFFECTIVE~", "Supposedly, the trigger house set its preferred target for purpose of using its special weapons. However, the special weapon is hardcoded to consider the most valuable building as its target, so this actually does nothing", p3Type: TriggerParameterFlag.QUARRY),
				new TriggerActionType("36 - Launch nukes", "All Missile Silo provide the appearance of launcing a nuke each"),
				
				// Intentionally left blank
				new TriggerActionType("37 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("38 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("39 - ~UNUSED~", "This action does nothing"),


				// Additional actions added by Iran
				new TriggerActionType("40 - Add credits", "Adds specified amount of CREDITS to the specified HOUSE. Negative amounts subtract instead", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.INTEGER),
				new TriggerActionType("41 - Add vehicle type to sidebar", "Adds UNITTYPE to the trigger house's sidebar, bypassing prerequisites", p1Type: TriggerParameterFlag.UNITTYPE),
				new TriggerActionType("42 - Add infantry type to sidebar", "Adds INFANTRYTYPE to the trigger house's sidebar, bypassing prerequisites", p1Type: TriggerParameterFlag.INFANTRYTYPE),
				new TriggerActionType("43 - Add building type to sidebar", "Adds BUILDINGTYPE to the trigger house's sidebar, bypassing prerequisites", p1Type: TriggerParameterFlag.BUILDINGTYPE),
				new TriggerActionType("44 - Add aircraft type to sidebar", "Adds AIRCRAFTTYPE to the trigger house's sidebar, bypassing prerequisites", p1Type: TriggerParameterFlag.AIRCRAFTTYPE),
				new TriggerActionType("45 - Add vessel type to sidebar", "Adds VESSELTYPE to the trigger house's sidebar, bypassing prerequisites", p1Type: TriggerParameterFlag.VESSELTYPE),
				new TriggerActionType("46 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("47 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("48 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("49 - ~UNUSED~", "This action does nothing"),
				new TriggerActionType("50 - Center view at", "Centers the trigger house's viewport around a waypoint", p1Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("51 - Set house player control", "Sets player control for a HOUSE. Use 1 to enable player control, 0 to disable", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.INTEGER),
				new TriggerActionType("52 - Set house primary color", "Sets primary house COLOR for a HOUSE", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.COLOR),
				new TriggerActionType("53 - Set house secondary color", "Sets secondary house COLOR for a HOUSE", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.COLOR),
				new TriggerActionType("54 - Set house tech level", "Sets TECH LEVEL for a HOUSE", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.INTEGER),
				new TriggerActionType("55 - Set house IQ level", "Sets IQ for a HOUSE", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.INTEGER),
				new TriggerActionType("56 - Set house ally", "Forces one HOUSE to ally another HOUSE. This works one way, so you may want to set two actions to ensure mutual alliance", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("57 - Set house enemy", "Forces one HOUSE to unally another HOUSE. This works one way, so you may want to set two actions to ensure mutual enemity (TO BE TESTED)", p1Type: TriggerParameterFlag.HOUSE, p2Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("58 - Create chrono vortex at", "Creates a Chrono Vortex at a WAYPOINT", p1Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("59 - Nuke strike at", "Drops a nuke at a WAYPOINT", p1Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("60 - Capture attached objects", "Sets the HOUSE for buildings, units and infantry that this trigger is attached to. Capturing buildings only work for Capturable buildings", p1Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("61 - Iron Curtain attached objects", "Applies the Iron Curtain effect on buildings, units and infantry that this trigger is attached to. Use -1 value to use the default Iron Curtain setting, otherwise the VALUE represents the number of frames the effect lasts", p1Type: TriggerParameterFlag.INTEGER),
				new TriggerActionType("62 - Create building at", "Creates a BUILDING for a HOUSE at a WAYPOINT. This mimics the building placement process, so if the terrain is blocked, the structure will not be created", p1Type: TriggerParameterFlag.BUILDINGTYPE, p2Type: TriggerParameterFlag.WAYPOINT, p3Type: TriggerParameterFlag.HOUSE),
				new TriggerActionType("63 - Set mission of attached objects", "Sets the mission of attached objects. Only certain missions have a real effect.", p1Type: TriggerParameterFlag.MISSIONTYPE),
				new TriggerActionType("64 - Repair attached objects", "Toggles the repair on buildings. Only has an effect on buildings"),
				new TriggerActionType("65 - Chronoshift attached objects", "Chronoshifts the attached objects to a WAYPOINT.", p1Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("66 - Chronoshift trigger object", "Chronoshifts the activating object to a WAYPOINT.", p1Type: TriggerParameterFlag.WAYPOINT),
				new TriggerActionType("67 - Iron Curtain trigger object", "Iron Curtains the activating object for a number of FRAMES.", p1Type: TriggerParameterFlag.INTEGER, p1Name: "Frames"),

				// Additional actions added by Lovalmidas
        new TriggerActionType("68 - Set map dimensions", "Set the dimensions of the map", p1Type: TriggerParameterFlag.INTEGER, p1Name: "Cell", p2Type: TriggerParameterFlag.INTEGER, p2Name: "Width", p3Type: TriggerParameterFlag.INTEGER, p3Name: "Height"),
      };

			string[] lStr = new string[_listTriggerAction.Count];
			for (int i = 0; i < _listTriggerAction.Count; i++)
      {
				lStr[i] = _listTriggerAction[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetTriggerActionID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static TriggerActionType[] GetTriggerActions()
		{
			return _listTriggerAction.ToArray();
		}

		public static TriggerActionType GetTriggerAction(string name)
		{
			return _listTriggerAction[_listString.IndexOf(name)];
		}

		public static TriggerActionType GetTriggerAction(int id)
		{
			return id >= 0 && id < _listTriggerAction.Count ? _listTriggerAction[id] : _default;
		}

		public static TriggerActionType GetTriggerAction(TActionType id)
		{
			return GetTriggerAction((int)id);
		}


		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
