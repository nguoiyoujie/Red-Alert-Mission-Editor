namespace RA_Mission_Editor.RulesData
{
  public class SpeechType
  {
		public VoxType ID { get; }
		public string Name { get; }

		public SpeechType(VoxType id, string name)
		{
			ID = id;
      Name = name;
		}

		public override string ToString()
		{
			return Name ?? ID.ToString();
		}
	}
}
