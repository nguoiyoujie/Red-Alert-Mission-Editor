using System.Collections.Generic;

namespace RA_Mission_Editor.RulesData
{
  public static class ScriptActions
	{
		private readonly static List<ScriptActionType> _listScriptAction = new List<ScriptActionType>();

		static ScriptActions()
    {
			_listScriptAction = new List<ScriptActionType>()
			{
				new ScriptActionType("00 - Attack", "Attack specified quarry type", ScriptParameterType.QUARRY),
				new ScriptActionType("01 - Attack Waypoint", "Attack specified waypoint", ScriptParameterType.WAYPOINT),
				new ScriptActionType("02 - Change Formation", "Change formation of team", ScriptParameterType.FORMATION),
				new ScriptActionType("03 - Move To Waypoint", "Moves to specified waypoint", ScriptParameterType.WAYPOINT),
				new ScriptActionType("04 - Move To Cell", "Moves to specified cell", ScriptParameterType.INTEGER),
				new ScriptActionType("05 - Guard (x 0.1 min)", "Guards at current location", ScriptParameterType.INTEGER),
				new ScriptActionType("06 - Jump to Line", "Jumps to a specified step", ScriptParameterType.INTEGER),
				new ScriptActionType("07 - Attack Tarcom", "Attack Tarcom"),
				new ScriptActionType("08 - Unload", "Unload"),
				new ScriptActionType("09 - Deploy", "Deploy"),
				new ScriptActionType("10 - Follow Friendlies", "Follow nearest friendly unit"),
				new ScriptActionType("11 - Do Mission", "Perform a specified mission", ScriptParameterType.MISSIONTYPE),
				new ScriptActionType("12 - Set Global", "Set a specified global variable", ScriptParameterType.INTEGER),
				new ScriptActionType("13 - Invulnerable", "Provide the Iron Curtain effect"),
				new ScriptActionType("14 - Load Into Transport", "Load team into the first transport unit in the team"),
				new ScriptActionType("15 - Spy At Waypoint", "Infiltrate the building at a specifed waypoint", ScriptParameterType.WAYPOINT),
				new ScriptActionType("16 - Patrol To Waypoint", "Moves to specified waypoint while actively scanning for enemies to engage", ScriptParameterType.WAYPOINT),
			};
		}

		public static ScriptActionType[] GetScriptActions()
		{
			return _listScriptAction.ToArray();
		}

		public static ScriptActionType GetScriptAction(int id)
		{
			return id >= 0 && id < _listScriptAction.Count ? _listScriptAction[id] : _listScriptAction[0];
		}

		public static ScriptActionType GetScriptAction(TActionType id)
		{
			return GetScriptAction((int)id);
		}
	}
}
