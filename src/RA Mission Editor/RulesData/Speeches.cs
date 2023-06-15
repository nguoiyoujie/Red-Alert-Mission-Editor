using System;
using System.Collections.Generic;
using System.Linq;

namespace RA_Mission_Editor.RulesData
{
	public class Speeches
  {
    private readonly Dictionary<VoxType, SpeechType> _listSpeeches = new Dictionary<VoxType, SpeechType>();
    private readonly SpeechType _nullSound = new SpeechType(VoxType.VOX_NONE, "none"); 
    public readonly int Count;

    public Speeches()
    {
      _listSpeeches.Add(VoxType.VOX_NONE, _nullSound);

      _listSpeeches.Add(VoxType.VOX_ACCOMPLISHED, new SpeechType(VoxType.VOX_ACCOMPLISHED, "MISNWON1"));
      _listSpeeches.Add(VoxType.VOX_FAIL, new SpeechType(VoxType.VOX_FAIL, "MISNLST1"));
      _listSpeeches.Add(VoxType.VOX_NO_FACTORY, new SpeechType(VoxType.VOX_NO_FACTORY, "PROGRES1"));
      _listSpeeches.Add(VoxType.VOX_CONSTRUCTION, new SpeechType(VoxType.VOX_CONSTRUCTION, "CONSCMP1"));
      _listSpeeches.Add(VoxType.VOX_UNIT_READY, new SpeechType(VoxType.VOX_UNIT_READY, "UNITRDY1"));
      _listSpeeches.Add(VoxType.VOX_NEW_CONSTRUCT, new SpeechType(VoxType.VOX_NEW_CONSTRUCT, "NEWOPT1"));
      _listSpeeches.Add(VoxType.VOX_DEPLOY, new SpeechType(VoxType.VOX_DEPLOY, "NODEPLY1"));
      _listSpeeches.Add(VoxType.VOX_STRUCTURE_DESTROYED, new SpeechType(VoxType.VOX_STRUCTURE_DESTROYED, "STRCKIL1"));
      _listSpeeches.Add(VoxType.VOX_INSUFFICIENT_POWER, new SpeechType(VoxType.VOX_INSUFFICIENT_POWER, "NOPOWR1"));
      _listSpeeches.Add(VoxType.VOX_NO_CASH, new SpeechType(VoxType.VOX_NO_CASH, "NOFUNDS1"));
      _listSpeeches.Add(VoxType.VOX_CONTROL_EXIT, new SpeechType(VoxType.VOX_CONTROL_EXIT, "BCT1"));
      _listSpeeches.Add(VoxType.VOX_REINFORCEMENTS, new SpeechType(VoxType.VOX_REINFORCEMENTS, "REINFOR1"));
      _listSpeeches.Add(VoxType.VOX_CANCELED, new SpeechType(VoxType.VOX_CANCELED, "CANCLD1"));
      _listSpeeches.Add(VoxType.VOX_BUILDING, new SpeechType(VoxType.VOX_BUILDING, "ABLDGIN1"));
      _listSpeeches.Add(VoxType.VOX_LOW_POWER, new SpeechType(VoxType.VOX_LOW_POWER, "LOPOWER1"));
      _listSpeeches.Add(VoxType.VOX_NEED_MO_MONEY, new SpeechType(VoxType.VOX_NEED_MO_MONEY, "NOFUNDS1"));
      _listSpeeches.Add(VoxType.VOX_BASE_UNDER_ATTACK, new SpeechType(VoxType.VOX_BASE_UNDER_ATTACK, "BASEATK1"));
      _listSpeeches.Add(VoxType.VOX_UNABLE_TO_BUILD, new SpeechType(VoxType.VOX_UNABLE_TO_BUILD, "NOBUILD1"));
      _listSpeeches.Add(VoxType.VOX_PRIMARY_SELECTED, new SpeechType(VoxType.VOX_PRIMARY_SELECTED, "PRIBLDG1"));
      _listSpeeches.Add(VoxType.VOX_MADTANK_DEPLOYED, new SpeechType(VoxType.VOX_MADTANK_DEPLOYED, "TANK01"));
      _listSpeeches.Add(VoxType.VOX_none4, new SpeechType(VoxType.VOX_none4, "none"));
      _listSpeeches.Add(VoxType.VOX_UNIT_LOST, new SpeechType(VoxType.VOX_UNIT_LOST, "UNITLST1"));
      _listSpeeches.Add(VoxType.VOX_SELECT_TARGET, new SpeechType(VoxType.VOX_SELECT_TARGET, "SLCTTGT1"));
      _listSpeeches.Add(VoxType.VOX_PREPARE, new SpeechType(VoxType.VOX_PREPARE, "ENMYAPP1"));
      _listSpeeches.Add(VoxType.VOX_NEED_MO_CAPACITY, new SpeechType(VoxType.VOX_NEED_MO_CAPACITY, "SILOND1"));
      _listSpeeches.Add(VoxType.VOX_SUSPENDED, new SpeechType(VoxType.VOX_SUSPENDED, "ONHOLD1"));
      _listSpeeches.Add(VoxType.VOX_REPAIRING, new SpeechType(VoxType.VOX_REPAIRING, "REPAIR1"));
      _listSpeeches.Add(VoxType.VOX_none5, new SpeechType(VoxType.VOX_none5, "none"));
      _listSpeeches.Add(VoxType.VOX_none6, new SpeechType(VoxType.VOX_none6, "none"));
      _listSpeeches.Add(VoxType.VOX_AIRCRAFT_LOST, new SpeechType(VoxType.VOX_AIRCRAFT_LOST, "AUNITL1"));
      _listSpeeches.Add(VoxType.VOX_none7, new SpeechType(VoxType.VOX_none7, "none"));
      _listSpeeches.Add(VoxType.VOX_ALLIED_FORCES_APPROACHING, new SpeechType(VoxType.VOX_ALLIED_FORCES_APPROACHING, "AAPPRO1"));
      _listSpeeches.Add(VoxType.VOX_ALLIED_APPROACHING, new SpeechType(VoxType.VOX_ALLIED_APPROACHING, "AARRIVE1"));
      _listSpeeches.Add(VoxType.VOX_none8, new SpeechType(VoxType.VOX_none8, "none"));
      _listSpeeches.Add(VoxType.VOX_none9, new SpeechType(VoxType.VOX_none9, "none"));
      _listSpeeches.Add(VoxType.VOX_BUILDING_INFILTRATED, new SpeechType(VoxType.VOX_BUILDING_INFILTRATED, "BLDGINF1"));
      _listSpeeches.Add(VoxType.VOX_CHRONO_CHARGING, new SpeechType(VoxType.VOX_CHRONO_CHARGING, "CHROCHR1"));
      _listSpeeches.Add(VoxType.VOX_CHRONO_READY, new SpeechType(VoxType.VOX_CHRONO_READY, "CHRORDY1"));
      _listSpeeches.Add(VoxType.VOX_CHRONO_TEST, new SpeechType(VoxType.VOX_CHRONO_TEST, "CHROYES1"));
      _listSpeeches.Add(VoxType.VOX_HQ_UNDER_ATTACK, new SpeechType(VoxType.VOX_HQ_UNDER_ATTACK, "CMDCNTR1"));
      _listSpeeches.Add(VoxType.VOX_CENTER_DEACTIVATED, new SpeechType(VoxType.VOX_CENTER_DEACTIVATED, "CNTLDED1"));
      _listSpeeches.Add(VoxType.VOX_CONVOY_APPROACHING, new SpeechType(VoxType.VOX_CONVOY_APPROACHING, "CONVYAP1"));
      _listSpeeches.Add(VoxType.VOX_CONVOY_UNIT_LOST, new SpeechType(VoxType.VOX_CONVOY_UNIT_LOST, "CONVLST1"));
      _listSpeeches.Add(VoxType.VOX_EXPLOSIVE_PLACED, new SpeechType(VoxType.VOX_EXPLOSIVE_PLACED, "XPLOPLC1"));
      _listSpeeches.Add(VoxType.VOX_MONEY_STOLEN, new SpeechType(VoxType.VOX_MONEY_STOLEN, "CREDIT1"));
      _listSpeeches.Add(VoxType.VOX_SHIP_LOST, new SpeechType(VoxType.VOX_SHIP_LOST, "NAVYLST1"));
      _listSpeeches.Add(VoxType.VOX_SATALITE_LAUNCHED, new SpeechType(VoxType.VOX_SATALITE_LAUNCHED, "SATLNCH1"));
      _listSpeeches.Add(VoxType.VOX_SONAR_AVAILABLE, new SpeechType(VoxType.VOX_SONAR_AVAILABLE, "PULSE1"));
      _listSpeeches.Add(VoxType.VOX_none10, new SpeechType(VoxType.VOX_none10, "none"));
      _listSpeeches.Add(VoxType.VOX_SOVIET_FORCES_APPROACHING, new SpeechType(VoxType.VOX_SOVIET_FORCES_APPROACHING, "SOVFAPP1"));
      _listSpeeches.Add(VoxType.VOX_SOVIET_REINFORCEMENTS, new SpeechType(VoxType.VOX_SOVIET_REINFORCEMENTS, "SOVREIN1"));
      _listSpeeches.Add(VoxType.VOX_TRAINING, new SpeechType(VoxType.VOX_TRAINING, "TRAIN1"));
      _listSpeeches.Add(VoxType.VOX_ABOMB_READY, new SpeechType(VoxType.VOX_ABOMB_READY, "AREADY1"));
      _listSpeeches.Add(VoxType.VOX_ABOMB_LAUNCH, new SpeechType(VoxType.VOX_ABOMB_LAUNCH, "ALAUNCH1"));
      _listSpeeches.Add(VoxType.VOX_ALLIES_N, new SpeechType(VoxType.VOX_ALLIES_N, "AARRIVN1"));
      _listSpeeches.Add(VoxType.VOX_ALLIES_S, new SpeechType(VoxType.VOX_ALLIES_S, "AARRIVS1"));
      _listSpeeches.Add(VoxType.VOX_ALLIES_E, new SpeechType(VoxType.VOX_ALLIES_E, "AARIVE1"));
      _listSpeeches.Add(VoxType.VOX_ALLIES_W, new SpeechType(VoxType.VOX_ALLIES_W, "AARRIVW1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE1, new SpeechType(VoxType.VOX_OBJECTIVE1, "1OBJMET1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE2, new SpeechType(VoxType.VOX_OBJECTIVE2, "2OBJMET1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE3, new SpeechType(VoxType.VOX_OBJECTIVE3, "3OBJMET1"));
      _listSpeeches.Add(VoxType.VOX_IRON_CHARGING, new SpeechType(VoxType.VOX_IRON_CHARGING, "IRONCHG1"));
      _listSpeeches.Add(VoxType.VOX_IRON_READY, new SpeechType(VoxType.VOX_IRON_READY, "IRONRDY1"));
      _listSpeeches.Add(VoxType.VOX_RESCUED, new SpeechType(VoxType.VOX_RESCUED, "KOSYRES1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE_NOT, new SpeechType(VoxType.VOX_OBJECTIVE_NOT, "OBJNMET1"));
      _listSpeeches.Add(VoxType.VOX_SIGNAL_N, new SpeechType(VoxType.VOX_SIGNAL_N, "FLAREN1"));
      _listSpeeches.Add(VoxType.VOX_SIGNAL_S, new SpeechType(VoxType.VOX_SIGNAL_S, "FLARES1"));
      _listSpeeches.Add(VoxType.VOX_SIGNAL_E, new SpeechType(VoxType.VOX_SIGNAL_E, "FLAREE1"));
      _listSpeeches.Add(VoxType.VOX_SIGNAL_W, new SpeechType(VoxType.VOX_SIGNAL_W, "FLAREW1"));
      _listSpeeches.Add(VoxType.VOX_SPY_PLANE, new SpeechType(VoxType.VOX_SPY_PLANE, "SPYPLN1"));
      _listSpeeches.Add(VoxType.VOX_FREED, new SpeechType(VoxType.VOX_FREED, "TANYAF1"));
      _listSpeeches.Add(VoxType.VOX_UPGRADE_ARMOR, new SpeechType(VoxType.VOX_UPGRADE_ARMOR, "ARMORUP1"));
      _listSpeeches.Add(VoxType.VOX_UPGRADE_FIREPOWER, new SpeechType(VoxType.VOX_UPGRADE_FIREPOWER, "FIREPO1"));
      _listSpeeches.Add(VoxType.VOX_UPGRADE_SPEED, new SpeechType(VoxType.VOX_UPGRADE_SPEED, "UNITSPD1"));
      _listSpeeches.Add(VoxType.VOX_MISSION_TIMER, new SpeechType(VoxType.VOX_MISSION_TIMER, "MTIMEIN1"));
      _listSpeeches.Add(VoxType.VOX_UNIT_FULL, new SpeechType(VoxType.VOX_UNIT_FULL, "UNITFUL1"));
      _listSpeeches.Add(VoxType.VOX_UNIT_REPAIRED, new SpeechType(VoxType.VOX_UNIT_REPAIRED, "UNITREP1"));
      _listSpeeches.Add(VoxType.VOX_TIME_40, new SpeechType(VoxType.VOX_TIME_40, "40MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_30, new SpeechType(VoxType.VOX_TIME_30, "30MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_20, new SpeechType(VoxType.VOX_TIME_20, "20MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_10, new SpeechType(VoxType.VOX_TIME_10, "10MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_5, new SpeechType(VoxType.VOX_TIME_5, "5MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_4, new SpeechType(VoxType.VOX_TIME_4, "4MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_3, new SpeechType(VoxType.VOX_TIME_3, "3MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_2, new SpeechType(VoxType.VOX_TIME_2, "2MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_1, new SpeechType(VoxType.VOX_TIME_1, "1MINR"));
      _listSpeeches.Add(VoxType.VOX_TIME_STOP, new SpeechType(VoxType.VOX_TIME_STOP, "TIMERNO1"));
      _listSpeeches.Add(VoxType.VOX_UNIT_SOLD, new SpeechType(VoxType.VOX_UNIT_SOLD, "UNITSLD1"));
      _listSpeeches.Add(VoxType.VOX_TIMER_STARTED, new SpeechType(VoxType.VOX_TIMER_STARTED, "TIMERGO1"));
      _listSpeeches.Add(VoxType.VOX_TARGET_RESCUED, new SpeechType(VoxType.VOX_TARGET_RESCUED, "TARGRES1"));
      _listSpeeches.Add(VoxType.VOX_TARGET_FREED, new SpeechType(VoxType.VOX_TARGET_FREED, "TARGFRE1"));
      _listSpeeches.Add(VoxType.VOX_TANYA_RESCUED, new SpeechType(VoxType.VOX_TANYA_RESCUED, "TANYAR1"));
      _listSpeeches.Add(VoxType.VOX_STRUCTURE_SOLD, new SpeechType(VoxType.VOX_STRUCTURE_SOLD, "STRUSLD1"));
      _listSpeeches.Add(VoxType.VOX_SOVIET_FORCES_FALLEN, new SpeechType(VoxType.VOX_SOVIET_FORCES_FALLEN, "SOVFORC1"));
      _listSpeeches.Add(VoxType.VOX_SOVIET_SELECTED, new SpeechType(VoxType.VOX_SOVIET_SELECTED, "SOVEMP1"));
      _listSpeeches.Add(VoxType.VOX_SOVIET_EMPIRE_FALLEN, new SpeechType(VoxType.VOX_SOVIET_EMPIRE_FALLEN, "SOVEFAL1"));
      _listSpeeches.Add(VoxType.VOX_OPERATION_TERMINATED, new SpeechType(VoxType.VOX_OPERATION_TERMINATED, "OPTERM1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE_REACHED, new SpeechType(VoxType.VOX_OBJECTIVE_REACHED, "OBJRCH1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE_NOT_REACHED, new SpeechType(VoxType.VOX_OBJECTIVE_NOT_REACHED, "OBJNRCH1"));
      _listSpeeches.Add(VoxType.VOX_OBJECTIVE_MET, new SpeechType(VoxType.VOX_OBJECTIVE_MET, "OBJMET1"));
      _listSpeeches.Add(VoxType.VOX_MERCENARY_RESCUED, new SpeechType(VoxType.VOX_MERCENARY_RESCUED, "MERCR1"));
      _listSpeeches.Add(VoxType.VOX_MERCENARY_FREED, new SpeechType(VoxType.VOX_MERCENARY_FREED, "MERCF1"));
      _listSpeeches.Add(VoxType.VOX_KOSOYGEN_FREED, new SpeechType(VoxType.VOX_KOSOYGEN_FREED, "KOSYFRE1"));
      _listSpeeches.Add(VoxType.VOX_FLARE_DETECTED, new SpeechType(VoxType.VOX_FLARE_DETECTED, "FLARE1"));
      _listSpeeches.Add(VoxType.VOX_COMMANDO_RESCUED, new SpeechType(VoxType.VOX_COMMANDO_RESCUED, "COMNDOR1"));
      _listSpeeches.Add(VoxType.VOX_COMMANDO_FREED, new SpeechType(VoxType.VOX_COMMANDO_FREED, "COMNDOF1"));
      _listSpeeches.Add(VoxType.VOX_BUILDING_IN_PROGRESS, new SpeechType(VoxType.VOX_BUILDING_IN_PROGRESS, "BLDGPRG1"));
      _listSpeeches.Add(VoxType.VOX_ATOM_PREPPING, new SpeechType(VoxType.VOX_ATOM_PREPPING, "ATPREP1"));
      _listSpeeches.Add(VoxType.VOX_ALLIED_SELECTED, new SpeechType(VoxType.VOX_ALLIED_SELECTED, "ASELECT1"));
      _listSpeeches.Add(VoxType.VOX_ABOMB_PREPPING, new SpeechType(VoxType.VOX_ABOMB_PREPPING, "APREP1"));
      _listSpeeches.Add(VoxType.VOX_ATOM_LAUNCHED, new SpeechType(VoxType.VOX_ATOM_LAUNCHED, "ATLNCH1"));
      _listSpeeches.Add(VoxType.VOX_ALLIED_FORCES_FALLEN, new SpeechType(VoxType.VOX_ALLIED_FORCES_FALLEN, "AFALLEN1"));
      _listSpeeches.Add(VoxType.VOX_ABOMB_AVAILABLE, new SpeechType(VoxType.VOX_ABOMB_AVAILABLE, "AAVAIL1"));
      _listSpeeches.Add(VoxType.VOX_ALLIED_REINFORCEMENTS, new SpeechType(VoxType.VOX_ALLIED_REINFORCEMENTS, "AARRIVE1"));
      _listSpeeches.Add(VoxType.VOX_SAVE1, new SpeechType(VoxType.VOX_SAVE1, "SAVE1"));
      _listSpeeches.Add(VoxType.VOX_LOAD1, new SpeechType(VoxType.VOX_LOAD1, "LOAD1"));

      Count = _listSpeeches.Count;
    }

    public SpeechType[] GetAll()
    {
      return _listSpeeches.Values.ToArray();
    }

    public VoxType GetVoxType(string name)
    {
      if (name == null) return VoxType.VOX_NONE;
      foreach (KeyValuePair<VoxType, SpeechType> stype in _listSpeeches)
      {
        if (stype.Value.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
          return stype.Key;
      }
      return VoxType.VOX_NONE;
    }

    public SpeechType GetSpeech(VoxType id)
    {
      if (_listSpeeches.ContainsKey(id))
        return _listSpeeches[id];

      return _nullSound;

    }

    public SpeechType GetSpeech(string name)
    {
      return GetSpeech(GetVoxType(name));
    }
  }
}
