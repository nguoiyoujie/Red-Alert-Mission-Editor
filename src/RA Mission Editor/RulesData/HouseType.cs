namespace RA_Mission_Editor.RulesData
{
  public class HouseType
	{
		public string Name;
		public ColorType PrimaryColor;
		public ColorType SecondaryColor;

		// rules overrides
		public ColorType RulesPrimaryColor;
		public ColorType RulesSecondaryColor;

		public HouseType(string name, ColorType color = ColorType.YELLOW)
		{
			Name = name;
			PrimaryColor = color;
			SecondaryColor = color;
		}

		public HouseType(string name, ColorType primaryColor, ColorType secondaryColor)
		{
			Name = name;
			PrimaryColor = primaryColor;
			SecondaryColor = secondaryColor;
		}

    public override string ToString()
    {
      return Name;
    }
  }
}
