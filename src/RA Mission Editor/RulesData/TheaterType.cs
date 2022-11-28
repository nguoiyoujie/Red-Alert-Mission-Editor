namespace RA_Mission_Editor.RulesData
{
	public class TheaterType
	{
		public string Name;
    public string ShortName; // use for pal
    public string Extension;

    public TheaterType(string name, string shortName, string extension)
    {
      Name = name;
      ShortName = shortName;
      Extension = extension;
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
