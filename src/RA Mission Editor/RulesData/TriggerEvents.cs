using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class TriggerEvents
	{
		private readonly static TriggerEventType _default = new TriggerEventType("-1 - -Invalid-", "This event cannot be activated");
		private readonly static List<TriggerEventType> _listTriggerEvent = new List<TriggerEventType>();
		private readonly static List<string> _listString = new List<string>();

		static TriggerEvents()
		{
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/TEVENT.CPP
			_listTriggerEvent = new List<TriggerEventType>()
			{
				new TriggerEventType("00 - -No Event-", "This event cannot be activated"),
				new TriggerEventType("01 - Entered by", "An object belonging to the specified HOUSE enters the attached cell or building", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("02 - Spied by", "A unit with Infiltrate=yes belonging to the specified HOUSE enters the attached building", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("03 - Thieved by ~INEFFECTIVE~", "Check logic is present, but the game never fires the event, so this is ineffective", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("04 - Attached object discovered", "The player discovers the object from the fog of war"),
				new TriggerEventType("05 - House Discovered", "The player discovers the specified HOUSE from the fog of war", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("06 - Attached object attacked", "The attached object has been attacked by anybody"),
				new TriggerEventType("07 - Attached object destroyed", "The attached object has been destroyed by anybody"),
				new TriggerEventType("08 - Any Event", "This event fires immediately"),
				new TriggerEventType("09 - Destroyed Units All", "All units, excepting insignificant civilian objects, belonging to the specified HOUSE, has been destroyed", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("00 - Destroyed Buildings All", "All buildings, excepting insignificant civilian objects, belonging to the specified HOUSE, has been destroyed", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("11 - Destroyed All", "All objects, excepting insignificant civilian objects, belonging to the specified HOUSE, has been destroyed", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("12 - Credits exceed (x100)", "The trigger house has at least this many CREDITS", p2Type: TriggerParameterFlag.INTEGER),
				new TriggerEventType("13 - Elapsed Time (1/10th min)", "This amount of time has elapsed", p2Type: TriggerParameterFlag.TIME),
				new TriggerEventType("14 - Mission Timer Expired", "This global mission timer has expired"),
				new TriggerEventType("15 - Destroyed Buildings #", "The specified NUMBER of units, including civilian objects, belonging to the trigger house, has been destroyed", p2Type: TriggerParameterFlag.INTEGER),
				new TriggerEventType("16 - Destroyed Units #", "The specified NUMBER of buildings, including civilian objects, belonging to the trigger house, has been destroyed", p2Type: TriggerParameterFlag.INTEGER),
				new TriggerEventType("17 - No Factories left", "The trigger house has no factories left"),
				new TriggerEventType("18 - Civilians Evacuated", "At least one civilian belonging to the trigger house has been evacuated"),
				new TriggerEventType("19 - Build Building Type", "The player has placed the BUILDINGTYPE on the map", p2Type: TriggerParameterFlag.BUILDINGTYPE),
				new TriggerEventType("20 - Build Unit Type", "The player has built the UNIT on the map", p2Type: TriggerParameterFlag.UNITTYPE),
				new TriggerEventType("21 - Build Infantry Type", "The player has built the INFANTRY on the map", p2Type: TriggerParameterFlag.INFANTRYTYPE),
				new TriggerEventType("22 - Build Aircraft Type", "The player has built the AIRCRAFT on the map", p2Type: TriggerParameterFlag.AIRCRAFTTYPE),
				new TriggerEventType("23 - Leaves map (team)", "At least one member of the TEAM has left the map", p2Type: TriggerParameterFlag.TEAMTYPE),
				new TriggerEventType("24 - Zone Entry by", "The specified HOUSE has entered the zone indicated by the attached cell trigger", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("25 - Crosses Horizontal Line", "The specified HOUSE has entered the horizontal line indicated by the attached cell trigger", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("26 - Crosses Vertical Line", "The specified HOUSE has entered the vertical line indicated by the attached cell trigger", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("27 - Global is set", "Sets the specified GLOBAL variable", p2Type: TriggerParameterFlag.GLOBALS),
				new TriggerEventType("28 - Global is clear", "Clears the specified GLOBAL variable", p2Type: TriggerParameterFlag.GLOBALS),
				new TriggerEventType("29 - Destroyed Fakes All ~INEFFECTIVE~", "The event fires without any checks, so this is ineffective"),
				new TriggerEventType("30 - Low Power", "The specified HOUSE has less than 100% power satisfaction", p2Type: TriggerParameterFlag.HOUSE),
				new TriggerEventType("31 - All bridges destroyed", "All bridges on the map has been destroyed"),
				new TriggerEventType("32 - Building exists", "The trigger house owns the specified BUILDINGTYPE on the map", p2Type: TriggerParameterFlag.BUILDINGTYPE),
			};

			string[] lStr = new string[_listTriggerEvent.Count];
			for (int i = 0; i < _listTriggerEvent.Count; i++)
			{
				lStr[i] = _listTriggerEvent[i].ID;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetTriggerEventID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static TriggerEventType[] GetTriggerEvents()
		{
			return _listTriggerEvent.ToArray();
		}

		public static TriggerEventType GetTriggerEvent(string name)
		{
			return _listTriggerEvent[_listString.IndexOf(name)];
		}

		public static TriggerEventType GetTriggerEvent(int id)
		{
			return id >= 0 && id < _listTriggerEvent.Count ? _listTriggerEvent[id] : _default;
		}

		public static TriggerEventType GetTriggerEvent(TActionType id)
		{
			return GetTriggerEvent((int)id);
		}


		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
