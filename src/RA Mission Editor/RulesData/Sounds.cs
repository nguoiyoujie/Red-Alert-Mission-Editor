using System;
using System.Collections.Generic;
using System.Linq;

namespace RA_Mission_Editor.RulesData
{
	public class Sounds
  {
		private readonly Dictionary<VocType, SoundType> _listSounds = new Dictionary<VocType, SoundType>();
    private readonly SoundType _nullSound = new SoundType(VocType.VOC_NONE, "none", -1, false);
    public readonly int Count;

    public Sounds()
    {
      _listSounds.Add(VocType.VOC_NONE, _nullSound);

      _listSounds.Add(VocType.VOC_GIRL_OKAY, new SoundType(VocType.VOC_GIRL_OKAY, "GIRLOKAY", 20, false));
      _listSounds.Add(VocType.VOC_GIRL_YEAH, new SoundType(VocType.VOC_GIRL_YEAH, "GIRLYEAH", 20, false));
      _listSounds.Add(VocType.VOC_GUY_OKAY, new SoundType(VocType.VOC_GUY_OKAY, "GUYOKAY1", 20, false));
      _listSounds.Add(VocType.VOC_GUY_YEAH, new SoundType(VocType.VOC_GUY_YEAH, "GUYYEAH1", 20, false));
      _listSounds.Add(VocType.VOC_MINELAY1, new SoundType(VocType.VOC_MINELAY1, "MINELAY1", 5, true));
      _listSounds.Add(VocType.VOC_ACKNOWL, new SoundType(VocType.VOC_ACKNOWL, "ACKNO", 20, true));
      _listSounds.Add(VocType.VOC_AFFIRM, new SoundType(VocType.VOC_AFFIRM, "AFFIRM1", 20, true));
      _listSounds.Add(VocType.VOC_AWAIT, new SoundType(VocType.VOC_AWAIT, "AWAIT1", 20, true));
      _listSounds.Add(VocType.VOC_ENG_AFFIRM, new SoundType(VocType.VOC_ENG_AFFIRM, "EAFFIRM1", 20, false));
      _listSounds.Add(VocType.VOC_ENG_ENG, new SoundType(VocType.VOC_ENG_ENG, "EENGIN1", 20, false));
      _listSounds.Add(VocType.VOC_NO_PROB, new SoundType(VocType.VOC_NO_PROB, "NOPROB", 20, true));
      _listSounds.Add(VocType.VOC_READY, new SoundType(VocType.VOC_READY, "READY", 20, true));
      _listSounds.Add(VocType.VOC_REPORT, new SoundType(VocType.VOC_REPORT, "REPORT1", 20, true));
      _listSounds.Add(VocType.VOC_RIGHT_AWAY, new SoundType(VocType.VOC_RIGHT_AWAY, "RITAWAY", 20, true));
      _listSounds.Add(VocType.VOC_ROGER, new SoundType(VocType.VOC_ROGER, "ROGER", 20, true));
      _listSounds.Add(VocType.VOC_UGOTIT, new SoundType(VocType.VOC_UGOTIT, "UGOTIT", 20, true));
      _listSounds.Add(VocType.VOC_VEHIC, new SoundType(VocType.VOC_VEHIC, "VEHIC1", 20, true));
      _listSounds.Add(VocType.VOC_YESSIR, new SoundType(VocType.VOC_YESSIR, "YESSIR1", 20, true));
      _listSounds.Add(VocType.VOC_SCREAM1, new SoundType(VocType.VOC_SCREAM1, "DEDMAN1", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM3, new SoundType(VocType.VOC_SCREAM3, "DEDMAN2", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM4, new SoundType(VocType.VOC_SCREAM4, "DEDMAN3", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM5, new SoundType(VocType.VOC_SCREAM5, "DEDMAN4", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM6, new SoundType(VocType.VOC_SCREAM6, "DEDMAN5", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM7, new SoundType(VocType.VOC_SCREAM7, "DEDMAN6", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM10, new SoundType(VocType.VOC_SCREAM10, "DEDMAN7", 10, false));
      _listSounds.Add(VocType.VOC_SCREAM11, new SoundType(VocType.VOC_SCREAM11, "DEDMAN8", 10, false));
      _listSounds.Add(VocType.VOC_YELL1, new SoundType(VocType.VOC_YELL1, "DEDMAN10", 10, false));
      _listSounds.Add(VocType.VOC_CHRONO, new SoundType(VocType.VOC_CHRONO, "CHRONO2", 5, false));
      _listSounds.Add(VocType.VOC_CANNON1, new SoundType(VocType.VOC_CANNON1, "CANNON1", 1, false));
      _listSounds.Add(VocType.VOC_CANNON2, new SoundType(VocType.VOC_CANNON2, "CANNON2", 1, false));
      _listSounds.Add(VocType.VOC_IRON1, new SoundType(VocType.VOC_IRON1, "IRONCUR9", 10, false));
      _listSounds.Add(VocType.VOC_ENG_MOVEOUT, new SoundType(VocType.VOC_ENG_MOVEOUT, "EMOVOUT1", 20, false));
      _listSounds.Add(VocType.VOC_SONAR, new SoundType(VocType.VOC_SONAR, "SONPULSE", 10, false));
      _listSounds.Add(VocType.VOC_SANDBAG, new SoundType(VocType.VOC_SANDBAG, "SANDBAG2", 5, false));
      _listSounds.Add(VocType.VOC_MINEBLOW, new SoundType(VocType.VOC_MINEBLOW, "MINEBLO1", 5, false));
      _listSounds.Add(VocType.VOC_CHUTE1, new SoundType(VocType.VOC_CHUTE1, "CHUTE1", 1, false));
      _listSounds.Add(VocType.VOC_DOG_BARK, new SoundType(VocType.VOC_DOG_BARK, "DOGY1", 5, false));
      _listSounds.Add(VocType.VOC_DOG_WHINE, new SoundType(VocType.VOC_DOG_WHINE, "DOGW5", 10, false));
      _listSounds.Add(VocType.VOC_DOG_GROWL2, new SoundType(VocType.VOC_DOG_GROWL2, "DOGG5P", 10, false));
      _listSounds.Add(VocType.VOC_FIRE_LAUNCH, new SoundType(VocType.VOC_FIRE_LAUNCH, "FIREBL3", 1, false));
      _listSounds.Add(VocType.VOC_FIRE_EXPLODE, new SoundType(VocType.VOC_FIRE_EXPLODE, "FIRETRT1", 1, false));
      _listSounds.Add(VocType.VOC_GRENADE_TOSS, new SoundType(VocType.VOC_GRENADE_TOSS, "GRENADE1", 1, false));
      _listSounds.Add(VocType.VOC_GUN_5, new SoundType(VocType.VOC_GUN_5, "GUN11", 1, false));
      _listSounds.Add(VocType.VOC_GUN_7, new SoundType(VocType.VOC_GUN_7, "GUN13", 1, false));
      _listSounds.Add(VocType.VOC_ENG_YES, new SoundType(VocType.VOC_ENG_YES, "EYESSIR1", 20, false));
      _listSounds.Add(VocType.VOC_GUN_RIFLE, new SoundType(VocType.VOC_GUN_RIFLE, "GUN27", 1, false));
      _listSounds.Add(VocType.VOC_HEAL, new SoundType(VocType.VOC_HEAL, "HEAL2", 1, false));
      _listSounds.Add(VocType.VOC_DOOR, new SoundType(VocType.VOC_DOOR, "HYDROD1", 1, false));
      _listSounds.Add(VocType.VOC_INVULNERABLE, new SoundType(VocType.VOC_INVULNERABLE, "INVUL2", 1, false));
      _listSounds.Add(VocType.VOC_KABOOM1, new SoundType(VocType.VOC_KABOOM1, "KABOOM1", 1, false));
      _listSounds.Add(VocType.VOC_KABOOM12, new SoundType(VocType.VOC_KABOOM12, "KABOOM12", 1, false));
      _listSounds.Add(VocType.VOC_KABOOM15, new SoundType(VocType.VOC_KABOOM15, "KABOOM15", 1, false));
      _listSounds.Add(VocType.VOC_SPLASH, new SoundType(VocType.VOC_SPLASH, "SPLASH9", 5, false));
      _listSounds.Add(VocType.VOC_KABOOM22, new SoundType(VocType.VOC_KABOOM22, "KABOOM22", 1, false));
      _listSounds.Add(VocType.VOC_AACANON3, new SoundType(VocType.VOC_AACANON3, "AACANON3", 1, false));
      _listSounds.Add(VocType.VOC_TANYA_DIE, new SoundType(VocType.VOC_TANYA_DIE, "TANDETH1", 10, false));
      _listSounds.Add(VocType.VOC_GUN_5F, new SoundType(VocType.VOC_GUN_5F, "MGUNINF1", 1, false));
      _listSounds.Add(VocType.VOC_MISSILE_1, new SoundType(VocType.VOC_MISSILE_1, "MISSILE1", 1, false));
      _listSounds.Add(VocType.VOC_MISSILE_2, new SoundType(VocType.VOC_MISSILE_2, "MISSILE6", 1, false));
      _listSounds.Add(VocType.VOC_MISSILE_3, new SoundType(VocType.VOC_MISSILE_3, "MISSILE7", 1, false));
      _listSounds.Add(VocType.VOC_x6, new SoundType(VocType.VOC_x6, "x", 1, false));
      _listSounds.Add(VocType.VOC_GUN_5R, new SoundType(VocType.VOC_GUN_5R, "PILLBOX1", 1, false));
      _listSounds.Add(VocType.VOC_BEEP, new SoundType(VocType.VOC_BEEP, "RABEEP1", 1, false));
      _listSounds.Add(VocType.VOC_CLICK, new SoundType(VocType.VOC_CLICK, "RAMENU1", 1, false));
      _listSounds.Add(VocType.VOC_SILENCER, new SoundType(VocType.VOC_SILENCER, "SILENCER", 1, false));
      _listSounds.Add(VocType.VOC_CANNON6, new SoundType(VocType.VOC_CANNON6, "TANK5", 1, false));
      _listSounds.Add(VocType.VOC_CANNON7, new SoundType(VocType.VOC_CANNON7, "TANK6", 1, false));
      _listSounds.Add(VocType.VOC_TORPEDO, new SoundType(VocType.VOC_TORPEDO, "TORPEDO1", 1, false));
      _listSounds.Add(VocType.VOC_CANNON8, new SoundType(VocType.VOC_CANNON8, "TURRET1", 1, false));
      _listSounds.Add(VocType.VOC_TESLA_POWER_UP, new SoundType(VocType.VOC_TESLA_POWER_UP, "TSLACHG2", 10, false));
      _listSounds.Add(VocType.VOC_TESLA_ZAP, new SoundType(VocType.VOC_TESLA_ZAP, "TESLA1", 10, false));
      _listSounds.Add(VocType.VOC_SQUISH, new SoundType(VocType.VOC_SQUISH, "SQUISHY2", 10, false));
      _listSounds.Add(VocType.VOC_SCOLD, new SoundType(VocType.VOC_SCOLD, "SCOLDY1", 10, false));
      _listSounds.Add(VocType.VOC_RADAR_ON, new SoundType(VocType.VOC_RADAR_ON, "RADARON2", 20, false));
      _listSounds.Add(VocType.VOC_RADAR_OFF, new SoundType(VocType.VOC_RADAR_OFF, "RADARDN1", 10, false));
      _listSounds.Add(VocType.VOC_PLACE_BUILDING_DOWN, new SoundType(VocType.VOC_PLACE_BUILDING_DOWN, "PLACBLDG", 10, false));
      _listSounds.Add(VocType.VOC_KABOOM30, new SoundType(VocType.VOC_KABOOM30, "KABOOM30", 1, false));
      _listSounds.Add(VocType.VOC_KABOOM25, new SoundType(VocType.VOC_KABOOM25, "KABOOM25", 10, false));
      _listSounds.Add(VocType.VOC_x7, new SoundType(VocType.VOC_x7, "x", 10, false));
      _listSounds.Add(VocType.VOC_DOG_HURT, new SoundType(VocType.VOC_DOG_HURT, "DOGW7", 10, false));
      _listSounds.Add(VocType.VOC_DOG_YES, new SoundType(VocType.VOC_DOG_YES, "DOGW3PX", 10, false));
      _listSounds.Add(VocType.VOC_CRUMBLE, new SoundType(VocType.VOC_CRUMBLE, "CRMBLE2", 10, false));
      _listSounds.Add(VocType.VOC_MONEY_UP, new SoundType(VocType.VOC_MONEY_UP, "CASHUP1", 10, false));
      _listSounds.Add(VocType.VOC_MONEY_DOWN, new SoundType(VocType.VOC_MONEY_DOWN, "CASHDN1", 10, false));
      _listSounds.Add(VocType.VOC_CONSTRUCTION, new SoundType(VocType.VOC_CONSTRUCTION, "BUILD5", 10, false));
      _listSounds.Add(VocType.VOC_GAME_CLOSED, new SoundType(VocType.VOC_GAME_CLOSED, "BLEEP9", 10, false));
      _listSounds.Add(VocType.VOC_INCOMING_MESSAGE, new SoundType(VocType.VOC_INCOMING_MESSAGE, "BLEEP6", 10, false));
      _listSounds.Add(VocType.VOC_SYS_ERROR, new SoundType(VocType.VOC_SYS_ERROR, "BLEEP5", 10, false));
      _listSounds.Add(VocType.VOC_OPTIONS_CHANGED, new SoundType(VocType.VOC_OPTIONS_CHANGED, "BLEEP17", 10, false));
      _listSounds.Add(VocType.VOC_GAME_FORMING, new SoundType(VocType.VOC_GAME_FORMING, "BLEEP13", 10, false));
      _listSounds.Add(VocType.VOC_PLAYER_LEFT, new SoundType(VocType.VOC_PLAYER_LEFT, "BLEEP12", 10, false));
      _listSounds.Add(VocType.VOC_PLAYER_JOINED, new SoundType(VocType.VOC_PLAYER_JOINED, "BLEEP11", 10, false));
      _listSounds.Add(VocType.VOC_DEPTH_CHARGE, new SoundType(VocType.VOC_DEPTH_CHARGE, "H2OBOMB2", 10, false));
      _listSounds.Add(VocType.VOC_CASHTURN, new SoundType(VocType.VOC_CASHTURN, "CASHTURN", 10, false));
      _listSounds.Add(VocType.VOC_TANYA_CHEW, new SoundType(VocType.VOC_TANYA_CHEW, "TUFFGUY1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_ROCK, new SoundType(VocType.VOC_TANYA_ROCK, "ROKROLL1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_LAUGH, new SoundType(VocType.VOC_TANYA_LAUGH, "LAUGH1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_SHAKE, new SoundType(VocType.VOC_TANYA_SHAKE, "CMON1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_CHING, new SoundType(VocType.VOC_TANYA_CHING, "BOMBIT1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_GOT, new SoundType(VocType.VOC_TANYA_GOT, "GOTIT1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_KISS, new SoundType(VocType.VOC_TANYA_KISS, "KEEPEM1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_THERE, new SoundType(VocType.VOC_TANYA_THERE, "ONIT1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_GIVE, new SoundType(VocType.VOC_TANYA_GIVE, "LEFTY1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_YEA, new SoundType(VocType.VOC_TANYA_YEA, "YEAH1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_YES, new SoundType(VocType.VOC_TANYA_YES, "YES1", 20, false));
      _listSounds.Add(VocType.VOC_TANYA_WHATS, new SoundType(VocType.VOC_TANYA_WHATS, "YO1", 20, false));
      _listSounds.Add(VocType.VOC_WALLKILL2, new SoundType(VocType.VOC_WALLKILL2, "WALLKIL2", 5, false));
      _listSounds.Add(VocType.VOC_x8, new SoundType(VocType.VOC_x8, "x", 10, false));
      _listSounds.Add(VocType.VOC_TRIPLE_SHOT, new SoundType(VocType.VOC_TRIPLE_SHOT, "GUN5", 5, false));
      _listSounds.Add(VocType.VOC_SUBSHOW, new SoundType(VocType.VOC_SUBSHOW, "SUBSHOW1", 5, false));
      _listSounds.Add(VocType.VOC_E_AH, new SoundType(VocType.VOC_E_AH, "EINAH1", 20, false));
      _listSounds.Add(VocType.VOC_E_OK, new SoundType(VocType.VOC_E_OK, "EINOK1", 20, false));
      _listSounds.Add(VocType.VOC_E_YES, new SoundType(VocType.VOC_E_YES, "EINYES1", 20, false));
      _listSounds.Add(VocType.VOC_TRIP_MINE, new SoundType(VocType.VOC_TRIP_MINE, "MINE1", 10, false));
      _listSounds.Add(VocType.VOC_SPY_COMMANDER, new SoundType(VocType.VOC_SPY_COMMANDER, "SCOMND1", 20, false));
      _listSounds.Add(VocType.VOC_SPY_YESSIR, new SoundType(VocType.VOC_SPY_YESSIR, "SYESSIR1", 20, false));
      _listSounds.Add(VocType.VOC_SPY_INDEED, new SoundType(VocType.VOC_SPY_INDEED, "SINDEED1", 20, false));
      _listSounds.Add(VocType.VOC_SPY_ONWAY, new SoundType(VocType.VOC_SPY_ONWAY, "SONWAY1", 20, false));
      _listSounds.Add(VocType.VOC_SPY_KING, new SoundType(VocType.VOC_SPY_KING, "SKING1", 20, false));
      _listSounds.Add(VocType.VOC_MED_REPORTING, new SoundType(VocType.VOC_MED_REPORTING, "MRESPON1", 20, false));
      _listSounds.Add(VocType.VOC_MED_YESSIR, new SoundType(VocType.VOC_MED_YESSIR, "MYESSIR1", 20, false));
      _listSounds.Add(VocType.VOC_MED_AFFIRM, new SoundType(VocType.VOC_MED_AFFIRM, "MAFFIRM1", 20, false));
      _listSounds.Add(VocType.VOC_MED_MOVEOUT, new SoundType(VocType.VOC_MED_MOVEOUT, "MMOVOUT1", 20, false));
      _listSounds.Add(VocType.VOC_BEEP_SELECT, new SoundType(VocType.VOC_BEEP_SELECT, "BEEPSLCT", 10, false));
      _listSounds.Add(VocType.VOC_THIEF_YEA, new SoundType(VocType.VOC_THIEF_YEA, "SYEAH1", 20, false));
      _listSounds.Add(VocType.VOC_ANTDIE, new SoundType(VocType.VOC_ANTDIE, "ANTDIE", 20, false));
      _listSounds.Add(VocType.VOC_ANTBITE, new SoundType(VocType.VOC_ANTBITE, "ANTBITE", 20, false));
      _listSounds.Add(VocType.VOC_THIEF_MOVEOUT, new SoundType(VocType.VOC_THIEF_MOVEOUT, "SMOUT1", 20, false));
      _listSounds.Add(VocType.VOC_THIEF_OKAY, new SoundType(VocType.VOC_THIEF_OKAY, "SOKAY1", 20, false));
      _listSounds.Add(VocType.VOC_x11, new SoundType(VocType.VOC_x11, "x", 20, false));
      _listSounds.Add(VocType.VOC_THIEF_WHAT, new SoundType(VocType.VOC_THIEF_WHAT, "SWHAT1", 20, false));
      _listSounds.Add(VocType.VOC_THIEF_AFFIRM, new SoundType(VocType.VOC_THIEF_AFFIRM, "SAFFIRM1", 20, false));
      _listSounds.Add(VocType.VOC_STAVCMDR, new SoundType(VocType.VOC_STAVCMDR, "STAVCMDR", 20, false));
      _listSounds.Add(VocType.VOC_STAVCRSE, new SoundType(VocType.VOC_STAVCRSE, "STAVCRSE", 20, false));
      _listSounds.Add(VocType.VOC_STAVYES, new SoundType(VocType.VOC_STAVYES, "STAVYES", 20, false));
      _listSounds.Add(VocType.VOC_STAVMOV, new SoundType(VocType.VOC_STAVMOV, "STAVMOV", 20, false));
      _listSounds.Add(VocType.VOC_BUZZY1, new SoundType(VocType.VOC_BUZZY1, "BUZZY1", 20, false));
      _listSounds.Add(VocType.VOC_RAMBO1, new SoundType(VocType.VOC_RAMBO1, "RAMBO1", 20, false));
      _listSounds.Add(VocType.VOC_RAMBO2, new SoundType(VocType.VOC_RAMBO2, "RAMBO2", 20, false));
      _listSounds.Add(VocType.VOC_RAMBO3, new SoundType(VocType.VOC_RAMBO3, "RAMBO3", 20, false));
      _listSounds.Add(VocType.VOC_MECHYES1, new SoundType(VocType.VOC_MECHYES1, "MYES1", 20, false));
      _listSounds.Add(VocType.VOC_MECHHOWDY1, new SoundType(VocType.VOC_MECHHOWDY1, "MHOWDY1", 20, false));
      _listSounds.Add(VocType.VOC_MECHRISE1, new SoundType(VocType.VOC_MECHRISE1, "MRISE1", 20, false));
      _listSounds.Add(VocType.VOC_MECHHUH1, new SoundType(VocType.VOC_MECHHUH1, "MHUH1", 20, false));
      _listSounds.Add(VocType.VOC_MECHHEAR1, new SoundType(VocType.VOC_MECHHEAR1, "MHEAR1", 20, false));
      _listSounds.Add(VocType.VOC_MECHLAFF1, new SoundType(VocType.VOC_MECHLAFF1, "MLAFF1", 20, false));
      _listSounds.Add(VocType.VOC_MECHBOSS1, new SoundType(VocType.VOC_MECHBOSS1, "MBOSS1", 20, false));
      _listSounds.Add(VocType.VOC_MECHYEEHAW1, new SoundType(VocType.VOC_MECHYEEHAW1, "MYEEHAW1", 20, false));
      _listSounds.Add(VocType.VOC_MECHHOTDIG1, new SoundType(VocType.VOC_MECHHOTDIG1, "MHOTDIG1", 20, false));
      _listSounds.Add(VocType.VOC_MECHWRENCH1, new SoundType(VocType.VOC_MECHWRENCH1, "MWRENCH1", 20, false));
      _listSounds.Add(VocType.VOC_STBURN1, new SoundType(VocType.VOC_STBURN1, "JBURN1", 20, false));
      _listSounds.Add(VocType.VOC_STCHRGE1, new SoundType(VocType.VOC_STCHRGE1, "JCHRGE1", 20, false));
      _listSounds.Add(VocType.VOC_STCRISP1, new SoundType(VocType.VOC_STCRISP1, "JCRISP1", 20, false));
      _listSounds.Add(VocType.VOC_STDANCE1, new SoundType(VocType.VOC_STDANCE1, "JDANCE1", 20, false));
      _listSounds.Add(VocType.VOC_STJUICE1, new SoundType(VocType.VOC_STJUICE1, "JJUICE1", 20, false));
      _listSounds.Add(VocType.VOC_STJUMP1, new SoundType(VocType.VOC_STJUMP1, "JJUMP1", 20, false));
      _listSounds.Add(VocType.VOC_STLIGHT1, new SoundType(VocType.VOC_STLIGHT1, "JLIGHT1", 20, false));
      _listSounds.Add(VocType.VOC_STPOWER1, new SoundType(VocType.VOC_STPOWER1, "JPOWER1", 20, false));
      _listSounds.Add(VocType.VOC_STSHOCK1, new SoundType(VocType.VOC_STSHOCK1, "JSHOCK1", 20, false));
      _listSounds.Add(VocType.VOC_STYES1, new SoundType(VocType.VOC_STYES1, "JYES1", 20, false));
      _listSounds.Add(VocType.VOC_CHRONOTANK1, new SoundType(VocType.VOC_CHRONOTANK1, "CHROTNK1", 20, false));
      _listSounds.Add(VocType.VOC_MECH_FIXIT1, new SoundType(VocType.VOC_MECH_FIXIT1, "FIXIT1", 20, false));
      _listSounds.Add(VocType.VOC_MAD_CHARGE, new SoundType(VocType.VOC_MAD_CHARGE, "MADCHRG2", 20, false));
      _listSounds.Add(VocType.VOC_MAD_EXPLODE, new SoundType(VocType.VOC_MAD_EXPLODE, "MADEXPLO", 20, false));
      _listSounds.Add(VocType.VOC_SHOCK_TROOP1, new SoundType(VocType.VOC_SHOCK_TROOP1, "SHKTROP1", 20, false));
      _listSounds.Add(VocType.VOC_BEACON, new SoundType(VocType.VOC_BEACON, "BEACON", 10, false));

      Count = _listSounds.Count;
    }                                
                                            
		public SoundType[] GetAll()             
		{
			return _listSounds.Values.ToArray();         
		}                                       
                                            
		public VocType GetVocType(string name)      
		{                                       
			if (name == null) return VocType.VOC_NONE;
			foreach (KeyValuePair<VocType, SoundType> stype in  _listSounds)
      {
				if (stype.Value.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
					return stype.Key;
      }
			return VocType.VOC_NONE;
		}

		public SoundType GetSound(VocType id)
		{
      if (_listSounds.ContainsKey(id)) 
        return _listSounds[id];

      return _nullSound;

    }

		public SoundType GetSound(string name)
		{
			return GetSound(GetVocType(name));
		}
	}
}
