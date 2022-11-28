using RA_Mission_Editor.FileFormats;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class HouseSection
  {
    /*
     * [<HouseName>]
     * TechLevel=1
     * IQ=3
     * Allies=Greece,Spain,Multi1
     * Credits=100
     * Firepower=1.0
     * Groundspeed=1.0
     * Airspeed=1.0
     * Armor=1.0
     * ROF=1.0
     * Cost=1.0
     * BuildTime=1.0
     * PlayerControl=yes
     * 
     * Added by Iran
     * Color=1
     * Country=1
     * SecondaryColorScheme=6
     * 
     */

    /// <summary>Name of the House, this will also be the header</summary>
    public string Name { get; private set; }
    public StoredIniValue<int> TechLevel = StoredIniValueExt.CreateIniLink_Int(nameof(TechLevel), 10);
    public StoredIniValue<int> IQ = StoredIniValueExt.CreateIniLink_Int(nameof(IQ));
    public StoredIniValue<List<string>> Allies = StoredIniValueExt.CreateIniLink_List(nameof(Allies));
    public StoredIniValue<bool> PlayerControl = StoredIniValueExt.CreateIniLink_Bool(nameof(PlayerControl));

    public StoredIniValue<int> Credits = StoredIniValueExt.CreateIniLink_Int(nameof(Credits));
    public StoredIniValue<float> Firepower = StoredIniValueExt.CreateIniLink_Float(nameof(Firepower));
    public StoredIniValue<float> Groundspeed = StoredIniValueExt.CreateIniLink_Float(nameof(Groundspeed));
    public StoredIniValue<float> Airspeed = StoredIniValueExt.CreateIniLink_Float(nameof(Airspeed));
    public StoredIniValue<float> Armor = StoredIniValueExt.CreateIniLink_Float(nameof(Armor));
    public StoredIniValue<float> ROF = StoredIniValueExt.CreateIniLink_Float(nameof(ROF));
    public StoredIniValue<float> Cost = StoredIniValueExt.CreateIniLink_Float(nameof(Cost));
    public StoredIniValue<float> BuildTime = StoredIniValueExt.CreateIniLink_Float(nameof(BuildTime));

    // Iran's additions
    public StoredIniValue<int> Color = StoredIniValueExt.CreateIniLink_Int(nameof(Color));
    public StoredIniValue<int> Country = StoredIniValueExt.CreateIniLink_Int(nameof(Country));
    public StoredIniValue<int> SecondaryColorScheme = StoredIniValueExt.CreateIniLink_Int(nameof(SecondaryColorScheme));
    public StoredIniValue<bool> BuildingsGetInstantlyCaptured = StoredIniValueExt.CreateIniLink_Bool(nameof(BuildingsGetInstantlyCaptured));
    public StoredIniValue<bool> NoBuildingCrew = StoredIniValueExt.CreateIniLink_Bool(nameof(NoBuildingCrew));

    public void Read(IniFile.IniSection section)
    {
      TechLevel.Read(section);
      IQ.Read(section);
      Allies.Read(section);
      PlayerControl.Read(section);

      Credits.Read(section);
      Firepower.Read(section);
      Groundspeed.Read(section);
      Airspeed.Read(section);
      Armor.Read(section);
      ROF.Read(section);
      Cost.Read(section);
      BuildTime.Read(section);

      Color.Read(section);
      Country.Read(section);
      SecondaryColorScheme.Read(section);
      BuildingsGetInstantlyCaptured.Read(section);
      NoBuildingCrew.Read(section);
    }

    public void Update(IniFile.IniSection section)
    {
      // don't clear, just replace
      //section.Clear();
      TechLevel.Update(section);
      IQ.Update(section);
      Allies.Update(section);
      PlayerControl.Update(section);

      Credits.Update(section);
      Firepower.Update(section);
      Groundspeed.Update(section);
      Airspeed.Update(section);
      Armor.Update(section);
      ROF.Update(section);
      Cost.Update(section);
      BuildTime.Update(section);

      Color.Update(section);
      Country.Update(section);
      SecondaryColorScheme.Update(section);
      BuildingsGetInstantlyCaptured.Update(section);
      NoBuildingCrew.Update(section);
    }
  }
}
