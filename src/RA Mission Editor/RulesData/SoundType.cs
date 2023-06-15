namespace RA_Mission_Editor.RulesData
{
  public class SoundType
  {
		public VocType ID { get; }
		public string Name { get; }
    public int Priority { get; }
    public bool IsVariant { get; }

    public SoundType(VocType iD, string name, int priority, bool isVariant)
    {
      ID = iD;
      Name = name;
      Priority = priority;
      IsVariant = isVariant;
    }

		public override string ToString()
		{
			return Name ?? ID.ToString();
		}
	}
}
