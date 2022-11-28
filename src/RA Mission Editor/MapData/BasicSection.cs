using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;

namespace RA_Mission_Editor.MapData
{
  public class BasicSection
  {
    /*
     * [Basic]
     * Name=(A14) - Destiny Calling
     * Intro=<none>
     * Brief=<none>
     * Win=<none>
     * Lose=<none>
     * Action=<none>
     * Player=Greece
     * Theme=No theme
     * CarryOverMoney=0
     * ToCarryOver=no
     * ToInherit=no
     * TimerInherit=no
     * CivEvac=no
     * NewINIFormat=3
     * CarryOverCap=0
     * EndOfGame=yes
     * NoSpyPlane=yes
     * SkipScore=no
     * OneTimeOnly=no
     * SkipMapSelect=no
     * Official=yes
     * FillSilos=no
     * TruckCrate=no
     * Percent=0
     * 
     * Added by Iran
     * UseCustomTutorialText=yes
     */

    /// <summary>Name of the map, as shown in the mission screen</summary>
    public StoredIniValue<string> Name = StoredIniValueExt.CreateIniLink_String(nameof(Name), "No name");

    /// <summary>Movie to play at the start of the game (when played the first time)</summary>
    public StoredIniValue<string> Intro = StoredIniValueExt.CreateIniLink_String(nameof(Intro));

    /// <summary>Movie to play in the briefing before the game</summary>
    public StoredIniValue<string> Brief = StoredIniValueExt.CreateIniLink_String(nameof(Brief));

    /// <summary>Movie to play after completing the game</summary>
    public StoredIniValue<string> Win = StoredIniValueExt.CreateIniLink_String(nameof(Win));

    /// <summary>Movie to play after completing the game</summary>
    public StoredIniValue<string> Win2 = StoredIniValueExt.CreateIniLink_String(nameof(Win2));

    /// <summary>Movie to play after completing the game</summary>
    public StoredIniValue<string> Win3 = StoredIniValueExt.CreateIniLink_String(nameof(Win3));

    /// <summary>Movie to play after completing the game</summary>
    public StoredIniValue<string> Win4 = StoredIniValueExt.CreateIniLink_String(nameof(Win4));

    /// <summary>Movie to play after losing the game</summary>
    public StoredIniValue<string> Lose = StoredIniValueExt.CreateIniLink_String(nameof(Lose));

    /// <summary>Movie to play before starting the game</summary>
    public StoredIniValue<string> Action = StoredIniValueExt.CreateIniLink_String(nameof(Action));

    /// <summary>The House assigned to the player</summary>
    public StoredIniValue<string> Player = StoredIniValueExt.CreateIniLink_String(nameof(Player));

    /// <summary>Theme to play at the start of the game</summary>
    public StoredIniValue<string> Theme = StoredIniValueExt.CreateIniLink_String(nameof(Theme));

    /// <summary>Amount of money from previous scenario. Not useful in an editor as this is adjusted by the game when a mission ends</summary>
    public StoredIniValue<int> CarryOverMoney = StoredIniValueExt.CreateIniLink_Int(nameof(CarryOverMoney), 0);

    /// <summary>Maximum Amount of money carried over from previous scenario</summary>
    public StoredIniValue<int> CarryOverCap = StoredIniValueExt.CreateIniLink_Int(nameof(CarryOverCap), 0);

    /// <summary>INI Map Format. TD=1, RA=2, RA with Aftermath=3, TS and RA2=4. Best to not change this</summary>
    public StoredIniValue<int> NewINIFormat = StoredIniValueExt.CreateIniLink_Int(nameof(NewINIFormat), 3);

    /// <summary>Whether objects in this map is to be carried over to a future map with ToInherit=yes</summary>
    public StoredIniValue<bool> ToCarryOver = StoredIniValueExt.CreateIniLink_Bool(nameof(ToCarryOver), false);

    /// <summary>Whether objects in the previous map is carried over from previous scenario</summary>
    public StoredIniValue<bool> ToInherit = StoredIniValueExt.CreateIniLink_Bool(nameof(ToInherit), false);

    /// <summary>Whether the mission timer in the previous map is carried over from previous scenario</summary>
    public StoredIniValue<bool> TimerInherit = StoredIniValueExt.CreateIniLink_Bool(nameof(TimerInherit), false);

    /// <summary>Whether Transport helicopters takeoff when Tanya or a civilian enters it</summary>
    // Apparently this is used to evacuate Tanya: https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/SCENARIO.CPP
    public StoredIniValue<bool> CivEvac = StoredIniValueExt.CreateIniLink_Bool(nameof(CivEvac), false);

    /// <summary>Whether the end movie and credits are played after the mission</summary>
    public StoredIniValue<bool> EndOfGame = StoredIniValueExt.CreateIniLink_Bool(nameof(EndOfGame), false);

    /// <summary>Whether the SpyPlane support power is disabled</summary>
    public StoredIniValue<bool> NoSpyPlane = StoredIniValueExt.CreateIniLink_Bool(nameof(NoSpyPlane), false);

    /// <summary>Whether the score screen is skipped</summary>
    public StoredIniValue<bool> SkipScore = StoredIniValueExt.CreateIniLink_Bool(nameof(SkipScore), false);

    /// <summary>Whether the game returns to the main menu after the mission (like expansion missions)</summary>
    public StoredIniValue<bool> OneTimeOnly = StoredIniValueExt.CreateIniLink_Bool(nameof(OneTimeOnly), false);

    /// <summary>Whether the map selection screen for the next scenario is skipped</summary>
    public StoredIniValue<bool> SkipMapSelect = StoredIniValueExt.CreateIniLink_Bool(nameof(SkipMapSelect), false);

    /// <summary>Whether the map is an official WW map (used for LAN transfer to differentiate WW maps from user maps</summary>
    public StoredIniValue<bool> Official = StoredIniValueExt.CreateIniLink_Bool(nameof(Official), false);

    /// <summary>Whether initial cash is given as Cash or Ore / Tiberium stored in silos</summary>
    public StoredIniValue<bool> FillSilos = StoredIniValueExt.CreateIniLink_Bool(nameof(FillSilos), false);

    /// <summary>Whether cargo trucks drop a wood crate after destruction</summary>
    public StoredIniValue<bool> TruckCrate = StoredIniValueExt.CreateIniLink_Bool(nameof(TruckCrate), false);

    /// <summary>The percentage of money that the player had remaining at the end of the previous mission that will be carried into this one</summary>
    public StoredIniValue<int> Percent = StoredIniValueExt.CreateIniLink_Int(nameof(Percent), 0);

    /// <summary>Iran's addition: Whether this mission reads its mission text from the [Tutorial] section in-file instead of the Tutorial.ini file</summary>
    public StoredIniValue<bool> UseCustomTutorialText = StoredIniValueExt.CreateIniLink_Bool(nameof(UseCustomTutorialText));

    /// <summary>Iran's addition: The next mission filename, with file extension</summary>
    public StoredIniValue<string> NextMissionInCampaign = StoredIniValueExt.CreateIniLink_String(nameof(NextMissionInCampaign));

    /// <summary>Iran's addition: Scenario number, used for scoring and other internal calculations</summary>
    public StoredIniValue<int> ScenarioNumber = StoredIniValueExt.CreateIniLink_Int(nameof(ScenarioNumber));

    /// <summary>Iran's addition: Map selection animation filename for this mission (WITH file extension)</summary>
    public StoredIniValue<string> MapSelectionAnimation = StoredIniValueExt.CreateIniLink_String(nameof(MapSelectionAnimation));

    /// <summary>Iran's addition: Map selection choice A mission filename (WITH file extension)</summary>
    public StoredIniValue<string> MapSelectA = StoredIniValueExt.CreateIniLink_String(nameof(MapSelectA));

    /// <summary>Iran's addition: Map selection choice B mission filename (WITH file extension)</summary>
    public StoredIniValue<string> MapSelectB = StoredIniValueExt.CreateIniLink_String(nameof(MapSelectB));

    /// <summary>Iran's addition: Map selection choice C mission filename (WITH file extension)</summary>
    public StoredIniValue<string> MapSelectC = StoredIniValueExt.CreateIniLink_String(nameof(MapSelectC));

    public void Read(IniFile.IniSection section)
    {
      Name.Read(section);
      Intro.Read(section);
      Brief.Read(section);
      Win.Read(section);
      Win2.Read(section);
      Win3.Read(section);
      Win4.Read(section);
      Lose.Read(section);
      Action.Read(section);
      Player.Read(section);
      Theme.Read(section);
      CarryOverMoney.Read(section);
      CarryOverCap.Read(section);
      NewINIFormat.Read(section);
      ToCarryOver.Read(section);
      ToInherit.Read(section);
      TimerInherit.Read(section);
      CivEvac.Read(section);
      EndOfGame.Read(section);
      NoSpyPlane.Read(section);
      SkipScore.Read(section);
      OneTimeOnly.Read(section);
      SkipMapSelect.Read(section);
      Official.Read(section);
      FillSilos.Read(section);
      TruckCrate.Read(section);
      Percent.Read(section);

      UseCustomTutorialText.Read(section);
      NextMissionInCampaign.Read(section);
      ScenarioNumber.Read(section);
      MapSelectionAnimation.Read(section);
      MapSelectA.Read(section);
      MapSelectB.Read(section);
      MapSelectC.Read(section);
    }

    public void Update(IniFile.IniSection section)
    {
      // don't clear, just replace
      //section.Clear();
      Name.Update(section);
      Intro.Update(section);
      Brief.Update(section);
      Win.Update(section);
      Win2.Update(section);
      Win3.Update(section);
      Win4.Update(section);
      Lose.Update(section);
      Action.Update(section);
      Player.Update(section);
      Theme.Update(section);
      CarryOverMoney.Update(section);
      CarryOverCap.Update(section);
      NewINIFormat.Update(section);
      ToCarryOver.Update(section);
      ToInherit.Update(section);
      TimerInherit.Update(section);
      CivEvac.Update(section);
      EndOfGame.Update(section);
      NoSpyPlane.Update(section);
      SkipScore.Update(section);
      OneTimeOnly.Update(section);
      SkipMapSelect.Update(section);
      Official.Update(section);
      FillSilos.Update(section);
      TruckCrate.Update(section);
      Percent.Update(section);

      UseCustomTutorialText.Update(section);
      NextMissionInCampaign.Update(section);
      ScenarioNumber.Update(section);
      MapSelectionAnimation.Update(section);
      MapSelectA.Update(section);
      MapSelectB.Update(section);
      MapSelectC.Update(section);
    }
  }
}