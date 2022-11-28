namespace RA_Mission_Editor.RulesData
{
	public class MissionType
	{
		public string Name { get; }

		public MissionType(string id)
		{
			Name = id;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
