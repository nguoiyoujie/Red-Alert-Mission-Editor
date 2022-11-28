using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class Missions
	{
		private readonly static List<MissionType> _listMission = new List<MissionType>();
		private readonly static List<string> _listString = new List<string>();

		static Missions()
    {
			// See https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/CONST.CPP
			_listMission = new List<MissionType>()
			{
				new MissionType("Sleep"          ),	 //MISSION_SLEEP,							Do nothing whatsoever.
				new MissionType("Attack"         ),	 //MISSION_ATTACK,						Attack nearest enemy.
				new MissionType("Move"           ),	 //MISSION_MOVE,							Guard location or unit.
				new MissionType("QMove"          ),	 //MISSION_QMOVE,							A queue list movement mission.
				new MissionType("Retreat"        ),	 //MISSION_RETREAT,						Return home for R & R.
				new MissionType("Guard"          ),	 //MISSION_GUARD,							Stay still.
				new MissionType("Sticky"         ),	 //MISSION_STICKY,						Stay still -- never recruit.
				new MissionType("Enter"          ),	 //MISSION_ENTER,							Move into object cooperatively.
				new MissionType("Capture"        ),	 //MISSION_CAPTURE,						Move into in order to capture.
				new MissionType("Harvest"        ),	 //MISSION_HARVEST,						Hunt for and collect nearby Tiberium.
				new MissionType("Area Guard"     ),	 //MISSION_GUARD_AREA,				Active guard of area.
				new MissionType("Return"         ),	 //MISSION_RETURN,						Head back to refinery.
				new MissionType("Stop"           ),	 //MISSION_STOP,							Sit still.
				new MissionType("Ambush"         ),	 //MISSION_AMBUSH,						Wait until discovered.
				new MissionType("Hunt"           ),	 //MISSION_HUNT,							Active search and destroy.
				new MissionType("Unload"         ),	 //MISSION_UNLOAD,						Search for and deliver cargo.
				new MissionType("Sabotage"       ),	 //MISSION_SABOTAGE,					Move into in order to destroy.
				new MissionType("Construction"   ),	 //MISSION_CONSTRUCTION,			Building buildup operation.
				new MissionType("Selling"        ),	 //MISSION_DECONSTRUCTION,		Building builddown operation.
				new MissionType("Repair"         ),	 //MISSION_REPAIR,						Repair process mission.
				new MissionType("Rescue"         ),	 //MISSION_RESCUE,
				new MissionType("Missile"        ),	 //MISSION_MISSILE,
				new MissionType("Harmless"       ),	 //MISSION_HARMLESS,					Sit around and don't appear like a threat.
			};

			string[] lStr = new string[_listMission.Count];
			for (int i = 0; i < _listMission.Count; i++)
      {
				lStr[i] = _listMission[i].Name;
			}
			_listString = new List<string>(lStr);
		}

		public static int GetID(string name)
    {
			return _listString.IndexOf(name);
    }

		public static MissionType[] GetAll()
		{
			return _listMission.ToArray();
		}

		public static object[] GetAsObjectList()
		{
			return GetAll(); //.Select((t) => t).ToArray();
		}

		public static MissionType Get(string name)
		{
			return Get(_listString.IndexOf(name));
		}

		public static MissionType Get(int id)
		{
			return id >= 0 && id < _listMission.Count ? _listMission[id] : default;
		}

		public static string GetName(int id)
    {
			return id >= 0 && id < _listString.Count ? _listString[id] : null;
		}
	}
}
