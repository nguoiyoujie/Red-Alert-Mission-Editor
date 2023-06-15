namespace RA_Mission_Editor.RulesData
{
  public class ScriptActionType
	{
		public string ID { get; }
		public string Description { get; }
		public ScriptParameterType ParameterType { get; }

		public ScriptActionType(string id, string description = null, ScriptParameterType paramType = default)
		{
			ID = id;
			Description = description ?? string.Empty;
			ParameterType = paramType;
		}

		public override string ToString()
		{
			return ID;
		}
	}

	public enum ScriptParameterType
	{
		NONE = 0,
		INTEGER,
		QUARRY,
		WAYPOINT,
		FORMATION,
		MISSIONTYPE,
    GLOBALS,
    TARGET
  }
}
