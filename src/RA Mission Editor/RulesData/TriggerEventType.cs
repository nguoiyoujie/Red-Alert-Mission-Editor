namespace RA_Mission_Editor.RulesData
{
  public class TriggerEventType
	{
		public string ID { get; }
		public string Description { get; }
		public TriggerParameterFlag P1Type { get; }
		public TriggerParameterFlag P2Type { get; }

		public TriggerEventType(string id, string description = null, TriggerParameterFlag p1Type = default, TriggerParameterFlag p2Type = default)
		{
			ID = id;
			Description = description ?? string.Empty;
			P1Type = p1Type;
			P2Type = p2Type;
		}

		public override string ToString()
		{
			return ID;
		}
	}
}
