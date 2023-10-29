namespace RA_Mission_Editor
{
  /// <summary>The persistence mode for a Map Trigger</summary>
  public enum PersistantType : byte
  {
    /// <summary>Fires once after activation by any element, then destroys itself</summary>
    FIRE_ONCE_ANY = 0,

    /// <summary>Fires once after activation by all attached elements, then destroys itself</summary>
    FIRE_ONCE_ALL = 1,

    /// <summary>Fires after activation by any element, but remains available for repeated activations</summary>
    FIRE_REPEATING = 2
  }

  /// <summary>The logical style applied to two Events or Actions in a Map Trigger</summary>
  public enum MultiStyleType : byte
  {
    /// <summary>Only the first member is checked</summary>
    FIRST_ONLY = 0,

    /// <summary>Both first and second members are checked, the result being the AND combination of the two</summary>
    FIRST_AND_SECOND = 1,

    /// <summary>Both first and second members are checked, the result being the OR combination of the two</summary>
    FIRST_OR_SECOND = 2,

    /// <summary>Special case for the two events and actions be treated as independent event-action pairs sharing the same trigger</summary>
    PARALLEL_LINK = 3
  }

  /// <summary>The supported Event types for a Map Trigger</summary>
  public enum TEventType
  {
    /// <summary>Null Event</summary>
    TEVENT_INVALID = -1,

    ///<summary>Nothing</summary>
    TEVENT_NONE = 0,

    ///<summary>Player enters this square</summary>
    TEVENT_ENTERED = 1,

    ///<summary>Spied by</summary>
    TEVENT_SPIED = 2,

    ///<summary>Thieved by (raided or stolen vehicle)</summary>
    TEVENT_THIEVED = 3,

    ///<summary>Player discovers this object</summary>
    TEVENT_DISCOVERED = 4,

    ///<summary>Player discovers this House</summary>
    TEVENT_HOUSE_DISCOVERED = 5,

    ///<summary>The attached object has been attacked</summary>
    TEVENT_ATTACKED = 6,

    ///<summary>The attached object has been destroyed</summary>
    TEVENT_DESTROYED = 7,

    ///<summary>Any object event will cause the trigger</summary>
    TEVENT_ANY = 8,

    ///<summary>all house's units destroyed</summary>
    TEVENT_UNITS_DESTROYED = 9,

    ///<summary>all house's buildings destroyed</summary>
    TEVENT_BUILDINGS_DESTROYED = 10,

    ///<summary>all house's units & buildings destroyed</summary>
    TEVENT_ALL_DESTROYED = 11,

    ///<summary>house reaches this many credits</summary>
    TEVENT_CREDITS = 11,

    ///<summary>Scenario elapsed time from start</summary>
    TEVENT_TIME = 12,

    ///<summary>Pre expired mission timer</summary>
    TEVENT_MISSION_TIMER_EXPIRED = 13,

    ///<summary>Number of buildings destroyed</summary>
    TEVENT_NBUILDINGS_DESTROYED = 14,

    ///<summary>Number of units destroyed</summary>
    TEVENT_NUNITS_DESTROYED = 15,

    ///<summary>No factories left</summary>
    TEVENT_NOFACTORIES = 16,

    ///<summary>Civilian has been evacuated</summary>
    TEVENT_EVAC_CIVILIAN = 17,

    ///<summary>Specified building has been built</summary>
    TEVENT_BUILD_STRUCTURE = 18,

    ///<summary>Specified unit has been built</summary>
    TEVENT_BUILD_UNIT = 19,

    ///<summary>Specified infantry has been built</summary>
    TEVENT_BUILD_INFANTRY = 20,

    ///<summary>Specified aircraft has been built</summary>
    TEVENT_BUILD_AIRCRAFT = 21,

    ///<summary>Specified team member leaves map</summary>
    TEVENT_LEAVES_MAP = 22,

    ///<summary>Enters same zone as waypoint 'x</summary>
    TEVENT_ENTERS_ZONE = 23,

    ///<summary>Crosses horizontal trigger line</summary>
    TEVENT_CROSS_HORIZONTAL = 24,

    ///<summary>Crosses vertical trigger line</summary>
    TEVENT_CROSS_VERTICAL = 25,

    ///<summary>If specified global has been set</summary>
    TEVENT_GLOBAL_SET = 26,

    ///<summary>If specified global has been cleared</summary>
    TEVENT_GLOBAL_CLEAR = 27,

    ///<summary>If all fake structures are gone</summary>
    TEVENT_FAKES_DESTROYED = 28,

    ///<summary>When power drops below 100</summary>
    TEVENT_LOW_POWER = 29,

    ///<summary>All bridges destroyed</summary>
    TEVENT_ALL_BRIDGES_DESTROYED = 30,

    ///<summary>Check for building existing</summary>
    TEVENT_BUILDING_EXISTS = 31,
  }

  /// <summary>The supported Action types for a Map Trigger</summary>
  public enum TActionType
  {
    /// <summary>Null Action</summary>
    TACTION_INVALID = -1,

    /// <summary>No Action</summary>
    TACTION_NONE = 0,

    /// <summary>Player wins</summary>
    TACTION_WIN = 1,

    /// <summary>Player loses</summary>
    TACTION_LOSE = 2,

    /// <summary>Owner House begins production</summary>
    TACTION_BEGIN_PRODUCTION = 3,

    /// <summary>Creates a team</summary>
    TACTION_CREATE_TEAM = 4,

    /// <summary>Destroys a team</summary>
    TACTION_DESTROY_TEAM = 5,

    /// <summary>Owner House sends all units to Hunt</summary>
    TACTION_ALL_HUNT = 6,

    /// <summary>Creates reinforcement units on the map</summary>
    TACTION_REINFORCEMENTS = 7,

    /// <summary>Applies a dropzone flare on the map</summary>
    TACTION_DROPZONE_FLARE = 8,

    /// <summary>Owner House sell all buildings and sends all units to Hunt</summary>
    TACTION_FIRE_SALE = 9,

    /// <summary>Plays a movie</summary>
    TACTION_PLAY_MOVIE = 10,

    /// <summary>Displays text</summary>
    TACTION_TEXT_TRIGGER = 11,

    /// <summary>Destroy a trigger</summary>
    TACTION_DESTROY_TRIGGER = 12,

    /// <summary>Owner House begins auto-creation of teams</summary>
    TACTION_AUTOCREATE = 13,

    /// <summary>Win if attached object is captured, but lose if it is destroyed. However this is disabled in RA</summary>
    TACTION_WINLOSE = 14,

    /// <summary>Allow win if triggered</summary>
    TACTION_ALLOWWIN = 15,

    /// <summary>Reveals the entire map</summary>
    TACTION_REVEAL_ALL = 16,

    /// <summary>Reveals the immediate area around a waypoint</summary>
    TACTION_REVEAL_SOME = 17,

    /// <summary>Reveals the area of the same zone as the cell covered by the waypoint</summary>
    TACTION_REVEAL_ZONE = 18,

    /// <summary>Plays a sound</summary>
    TACTION_PLAY_SOUND = 19,

    /// <summary>Plays a music</summary>
    TACTION_PLAY_MUSIC = 20,

    /// <summary>Plays an EVA speech</summary>
    TACTION_PLAY_SPEECH = 21,

    /// <summary>Force a trigger to activate</summary>
    TACTION_FORCE_TRIGGER = 22,

    /// <summary>Starts the mission timer</summary>
    TACTION_START_TIMER = 23,

    /// <summary>Stops the mission timer</summary>
    TACTION_STOP_TIMER = 24,

    /// <summary>Increments the mission timer time</summary>
    TACTION_ADD_TIMER = 25,

    /// <summary>Decrements the mission timer time</summary>
    TACTION_SUB_TIMER = 26,

    /// <summary>Sets and starts the mission timer</summary>
    TACTION_SET_TIMER = 27,

    /// <summary>Sets global variable</summary>
    TACTION_SET_GLOBAL = 28,

    /// <summary>Clears global variable</summary>
    TACTION_CLEAR_GLOBAL = 29,

    /// <summary>Triggers skirmish AI base planning</summary>
    TACTION_AI_BASE_BUILDING = 30,

    /// <summary>Grows shroud by one cell</summary>
    TACTION_CREEP_SHROUD = 31,

    /// <summary>Destroys the object this trigger is attached to</summary>
    TACTION_DESTROY_OBJECT = 32,

    /// <summary>Add a one-time special weapon ability to house</summary>
    TACTION_ONCE_SPECIAL = 33,

    /// <summary>Add a repeating special weapon ability to house</summary>
    TACTION_FULL_SPECIAL = 34,

    /// <summary>Designates preferred target for house</summary>
    TACTION_PREFERRED_TARGET = 35,

    /// <summary>Causes silo buildings to launch nukes. Appearance only</summary>
    TACTION_LAUNCH_NUKES = 36,


    // Additional action types by Iran start from ID 40

    /// <summary>Adds specified amount of credits to a House. Negative amounts subtract instead</summary>
    TACTION_ADD_CREDITS = 40,

    /// <summary>Adds vehicle to the Owner's sidebar, without checking for prerequisites</summary>
    TACTION_ADD_VEHICLE_TO_SIDEBAR = 41,

    /// <summary>Adds infantry to the Owner's sidebar, without checking for prerequisites</summary>
    TACTION_ADD_INFANTRY_TO_SIDEBAR = 42,

    /// <summary>Adds structure to the Owner's sidebar, without checking for prerequisites</summary>
    TACTION_ADD_STRUCTURE_TO_SIDEBAR = 43,

    /// <summary>Adds aircraft to the Owner's sidebar, without checking for prerequisites</summary>
    TACTION_ADD_AIRCRAFT_TO_SIDEBAR = 44,

    /// <summary>Adds ship to the Owner's sidebar, without checking for prerequisites</summary>
    TACTION_ADD_SHIP_TO_SIDEBAR = 45,

    /// <summary>Center Owner's viewport around a waypoint</summary>
    TACTION_SET_VIEWPORT = 50,

    /// <summary>Set player control for a House</summary>
    TACTION_SET_PLAYER_CONTROL = 51,

    /// <summary>Set a House primary color</summary>
    TACTION_SET_HOUSE_PRIMARY_COLOR = 52,

    /// <summary>Set a House secondary color</summary>
    TACTION_SET_HOUSE_SECONDARY_COLOR = 53,

    /// <summary>Set a House techlevel</summary>
    TACTION_SET_HOUSE_TECHLEVEL = 54,

    /// <summary>Set a House IQ</summary>
    TACTION_SET_HOUSE_IQ = 55,


    /// <summary>Set one House to ally another House</summary>
    TACTION_MAKE_ALLY = 56,

    /// <summary>Set one House to unally another House</summary>
    TACTION_MAKE_ENEMY = 57,

    /// <summary>Create Chrono vortex at a waypoint</summary>
    TACTION_CREATE_CHRONO_VORTEX = 58,

    /// <summary>Fire a nuke at a waypoint</summary>
    TACTION_NUKE_STRIKE = 59,

    /// <summary>Captures the object this trigger is attached to. Buildings with Capturable=false will ignore this trigger</summary>
    TACTION_CAPTURE_OBJECT = 60,

    /// <summary>Applies the iron curtain effect on the object this trigger is attached to</summary>
    TACTION_IRONCURTAIN_ATTACHED_OBJECT = 61,

    /// <summary>Create a building at a waypoint</summary>
    TACTION_CREATE_STRUCTURE = 62,

    /// <summary>Sets the mission for the object this trigger is attached to</summary>
    TACTION_SET_OBJECT_MISSION = 63,

    /// <summary>Sets repair for the object this trigger is attached to. Applies to buildings</summary>
    TACTION_REPAIR_OBJECT = 64,

    /// <summary>Chronoshifts the object this trigger is attached to</summary>
    TACTION_CHRONOSHIFT_ATTACHED_OBJECT = 65,

    /// <summary>Chronoshifts the object that activates this trigger (e.g. Entered By)</summary>
    TACTION_CHRONOSHIFT_TRIGGER_OBJECT = 66,

    /// <summary>Chronoshifts the object this activates this trigger (e.g. Entered By)</summary>
    TACTION_IRONCURTAIN_TRIGGER_OBJECT = 67,

  }

  /// <summary>The type of Land on the map</summary>
  public enum LandType : byte
  {
    ///<summary></summary> "Clear" terrain.</summary>
    LAND_CLEAR,

    ///<summary> Road terrain.</summary>
    LAND_ROAD,

    ///<summary> Water.</summary>
    LAND_WATER,

    ///<summary> Impassable rock.</summary>
    LAND_ROCK,

    ///<summary> Wall (blocks movement).</summary>
    LAND_WALL,

    ///<summary> Tiberium field.</summary>
    LAND_TIBERIUM,

    ///<summary>	Beach terrain.</summary>
    LAND_BEACH,

    ///<summary> Rocky terrain.</summary>
    LAND_ROUGH,

    ///<summary> Rocky riverbed.</summary>
    LAND_RIVER,
  }

  public enum TileType
  {
    CLEAR_0 = 0,
    CLEAR_1 = 1,
    CLEAR_2 = 2,
    CLEAR_3 = 3,
    CLEAR_4 = 4,
    CLEAR_5 = 5,
    BEACH_6 = 6,
    CLEAR_7 = 7,
    ROCK_8 = 8,
    ROAD_9 = 9,
    WATER_A = 10,
    RIVER_B = 11,
    CLEAR_C = 12,
    CLEAR_D = 13,
    ROUGH_E = 14,
    CLEAR_F = 15
  }

  /// <summary>Special behavior for the overlay</summary>
  public enum OverlaySubType
  {
    /// <summary>No special behavior</summary>
    NONE,

    /// <summary>Overlay is a wall</summary>
    WALL,

    /// <summary>Overlay is ore</summary>
    GOLD,

    /// <summary>Overlay is gems</summary>
    GEM
  }

  public enum QuarryType
  {
    NONE,
    ANYTHING,
    BUILDINGS,
    HARVESTERS,
    INFANTRY,
    VEHICLES,
    SHIPS,
    FACTORIES,
    BASE_DEFENSES,
    BASE_THREATS,
    POWER_PLANTS,
    FAKE_STRUCTURES
  }

  public enum RTTIType
  {
    NONE,
    AIRCRAFT,
    AIRCRAFTTYPE,
    ANIM,
    ANIMTYPE,
    BUILDING,
    BUILDINGTYPE,
    BULLET,
    BULLETTYPE,
    CELL,
    FACTORY,
    HOUSE,
    HOUSETYPE,
    INFANTRY,
    INFANTRYTYPE,
    OVERLAY,
    OVERLAYTYPE,
    SMUDGE,
    SMUDGETYPE,
    SPECIAL,
    TEAM,
    TEAMTYPE,
    TEMPLATE,
    TEMPLATETYPE,
    TERRAIN,
    TERRAINTYPE,
    TRIGGER,
    TRIGGERTYPE,
    UNIT,
    UNITTYPE,
    VESSEL,
    VESSELTYPE
  }


  public enum ColorType
  {
    NONE = -1,
    YELLOW = 0,
    BLUE = 1,
    RED = 2,
    GREEN = 3,
    ORANGE = 4,
    GREY = 5,
    TEAL = 6,
    BROWN = 7,
    // added colors by Iran
    WHITE = 8,
    BLACK = 9,
    FLAMING_BLUE = 10,
    // added colors by lovalmidas
    TRUE_GREY = 11,
    DIRTY_GREEN = 12
  }

  public enum RulesSource
  {
    NONE = 0,
    RULES_FILE = 1,
    MAP_FILE = 2
  }

  public enum EditorSelectMode
  {
    Any = -2, // No change
    Ignore = -1, // No change
    None = 0,
    Templates,
    Overlays,
    Terrain,
    Smudges,
    // Technotypes
    Infantry,
    Units,
    Ships,
    Structures,
    Bases,
    // Widgets
    CellTriggers,
    Waypoints,
    Extracts
  }

  public enum VocType : short
  {
    VOC_NONE = -1,

    VOC_GIRL_OKAY,      // "okay"
    VOC_GIRL_YEAH,      // "yeah?"
    VOC_GUY_OKAY,     //	"okay"
    VOC_GUY_YEAH,     // "yeah?"
    VOC_MINELAY1,     // mine layer sound
    VOC_ACKNOWL,      //	"acknowledged"
    VOC_AFFIRM,       //	"affirmative"
    VOC_AWAIT,        //	"awaiting orders"
    VOC_ENG_AFFIRM,   // Engineer: "affirmative"
    VOC_ENG_ENG,      // Engineer: "engineering"
    VOC_NO_PROB,      //	"not a problem"
    VOC_READY,        //	"ready and waiting"
    VOC_REPORT,       //	"reporting"
    VOC_RIGHT_AWAY,   //	"right away sir"
    VOC_ROGER,        //	"roger"
    VOC_UGOTIT,       //	"you got it"
    VOC_VEHIC,        //	"vehicle reporting"
    VOC_YESSIR,       //	"yes sir"

    VOC_SCREAM1,      //	short infantry scream
    VOC_SCREAM3,      //	short infantry scream
    VOC_SCREAM4,      //	short infantry scream
    VOC_SCREAM5,      //	short infantry scream
    VOC_SCREAM6,      //	short infantry scream
    VOC_SCREAM7,      //	short infantry scream
    VOC_SCREAM10,     //	short infantry scream
    VOC_SCREAM11,     //	short infantry scream
    VOC_YELL1,        //	long infantry scream

    VOC_CHRONO,       //	Chronosphere sound.
    VOC_CANNON1,      // Cannon sound (medium).
    VOC_CANNON2,      // Cannon sound (short).
    VOC_IRON1,
    VOC_ENG_MOVEOUT,    // Engineer: "movin' out"
    VOC_SONAR,        // sonar pulse
    VOC_SANDBAG,      // sand bag crunch
    VOC_MINEBLOW,
    VOC_CHUTE1,       // wind swoosh sound
    VOC_DOG_BARK,     // dog bark
    VOC_DOG_WHINE,      // dog whine
    VOC_DOG_GROWL2,   // strong dog growl
    VOC_FIRE_LAUNCH,    // fireball launch sound
    VOC_FIRE_EXPLODE,   // fireball explode sound
    VOC_GRENADE_TOSS,   // grenade toss
    VOC_GUN_5,        // 5 round gun burst (slow).
    VOC_GUN_7,        // 7 round gun burst (fast).
    VOC_ENG_YES,      // Engineer: "yes sir"
    VOC_GUN_RIFLE,      // Rifle shot.
    VOC_HEAL,       // Healing effect.
    VOC_DOOR,       // Hyrdrolic door.
    VOC_INVULNERABLE,   // Invulnerability effect.
    VOC_KABOOM1,      // Long explosion (muffled).
    VOC_KABOOM12,     // Very long explosion (muffled).
    VOC_KABOOM15,     // Very long explosion (muffled).
    VOC_SPLASH,       // Water splash
    VOC_KABOOM22,     // Long explosion (sharp).
    VOC_AACANON3,     // AA-Cannon
    VOC_TANYA_DIE,      // Tanya: scream
    VOC_GUN_5F,       // 5 round gun burst (fast).
    VOC_MISSILE_1,      // Missile with high tech effect.
    VOC_MISSILE_2,      // Long missile launch.
    VOC_MISSILE_3,      // Short missile launch.
    VOC_x6,
    VOC_GUN_5R,       // 5 round gun burst (rattles).
    VOC_BEEP,       // Generic beep sound.
    VOC_CLICK,        //	Generic click sound.
    VOC_SILENCER,     // Silencer.
    VOC_CANNON6,      // Long muffled cannon shot.
    VOC_CANNON7,      // Sharp mechanical cannon fire.
    VOC_TORPEDO,      // Torpedo launch.
    VOC_CANNON8,      // Sharp cannon fire.
    VOC_TESLA_POWER_UP, // Hum charge up.
    VOC_TESLA_ZAP,      // Tesla zap effect.
    VOC_SQUISH,       // Squish effect.
    VOC_SCOLD,        // Scold bleep.
    VOC_RADAR_ON,     // Powering up electronics.
    VOC_RADAR_OFF,      // B movie power down effect.
    VOC_PLACE_BUILDING_DOWN,  // Building slam down sound.
    VOC_KABOOM30,     // Short explosion (HE).
    VOC_KABOOM25,     // Short growling explosion.
    VOC_x7,
    VOC_DOG_HURT,     //	Dog whine.
    VOC_DOG_YES,      // Dog 'yes sir'.
    VOC_CRUMBLE,      // Building crumble.
    VOC_MONEY_UP,     // Rising money tick.
    VOC_MONEY_DOWN,   // Falling money tick.
    VOC_CONSTRUCTION,   // Building construction sound.
    VOC_GAME_CLOSED,    // Long bleep.
    VOC_INCOMING_MESSAGE, // Soft happy warble.
    VOC_SYS_ERROR,      // Sharp soft warble.
    VOC_OPTIONS_CHANGED,  // Mid range soft warble.
    VOC_GAME_FORMING,   // Long warble.
    VOC_PLAYER_LEFT,    // Chirp sequence.
    VOC_PLAYER_JOINED,  // Reverse chirp sequence.
    VOC_DEPTH_CHARGE,   // Distant explosion sound.
    VOC_CASHTURN,     // Airbrake.

    VOC_TANYA_CHEW,   // Tanya: "Chew on this"
    VOC_TANYA_ROCK,   // Tanya: "Let's rock"
    VOC_TANYA_LAUGH,    // Tanya: "ha ha ha"
    VOC_TANYA_SHAKE,    // Tanya: "Shake it baby"
    VOC_TANYA_CHING,    // Tanya: "Cha Ching"
    VOC_TANYA_GOT,      // Tanya: "That's all you got"
    VOC_TANYA_KISS,   // Tanya: "Kiss it bye bye"
    VOC_TANYA_THERE,    // Tanya: "I'm there"
    VOC_TANYA_GIVE,   // Tanya: "Give it to me"
    VOC_TANYA_YEA,      // Tanya: "Yea?"
    VOC_TANYA_YES,      // Tanya: "Yes sir?"
    VOC_TANYA_WHATS,    // Tanya: "What's up."
    VOC_WALLKILL2,      // Crushing wall sound.
    VOC_x8,
    VOC_TRIPLE_SHOT,    // Three quick shots in succession.
    VOC_SUBSHOW,      // Submarine surfacing.
    VOC_E_AH,       // Einstein "ah"
    VOC_E_OK,       // Einstein "ok"
    VOC_E_YES,        // Einstein "yes"
    VOC_TRIP_MINE,      // mine explosion sound

    VOC_SPY_COMMANDER,  // Spy: "commander?"
    VOC_SPY_YESSIR,   // Spy: "yes sir"
    VOC_SPY_INDEED,   // Spy: "indeed"
    VOC_SPY_ONWAY,      // Spy: "on my way"
    VOC_SPY_KING,     // Spy: "for king and country"
    VOC_MED_REPORTING,  // Medic: "reporting"
    VOC_MED_YESSIR,   // Medic: "yes sir"
    VOC_MED_AFFIRM,   // Medic: "affirmative"
    VOC_MED_MOVEOUT,    // Medic: "movin' out"
    VOC_BEEP_SELECT,    // map selection beep

    VOC_THIEF_YEA,      // Thief: "yea?"

    VOC_ANTDIE,
    VOC_ANTBITE,

    VOC_THIEF_MOVEOUT,  // Thief: "movin' out"
    VOC_THIEF_OKAY,   // Thief: "ok"
    VOC_x11,
    VOC_THIEF_WHAT,   // Thief: "what"
    VOC_THIEF_AFFIRM,   // Thief: "affirmative"
    VOC_STAVCMDR,
    VOC_STAVCRSE,
    VOC_STAVYES,
    VOC_STAVMOV,
    VOC_BUZZY1,
    VOC_RAMBO1,
    VOC_RAMBO2,
    VOC_RAMBO3,
    VOC_MECHYES1,
    VOC_MECHHOWDY1,
    VOC_MECHRISE1,
    VOC_MECHHUH1,
    VOC_MECHHEAR1,
    VOC_MECHLAFF1,
    VOC_MECHBOSS1,
    VOC_MECHYEEHAW1,
    VOC_MECHHOTDIG1,
    VOC_MECHWRENCH1,
    VOC_STBURN1,
    VOC_STCHRGE1,
    VOC_STCRISP1,
    VOC_STDANCE1,
    VOC_STJUICE1,
    VOC_STJUMP1,
    VOC_STLIGHT1,
    VOC_STPOWER1,
    VOC_STSHOCK1,
    VOC_STYES1,
    VOC_CHRONOTANK1,
    VOC_MECH_FIXIT1,
    VOC_MAD_CHARGE,
    VOC_MAD_EXPLODE,
    VOC_SHOCK_TROOP1,
    VOC_BEACON
  }

  public enum VoxType : short
  {
    VOX_NONE = -1,
    VOX_ACCOMPLISHED,         //	mission accomplished
    VOX_FAIL,             //	your mission has failed
    VOX_NO_FACTORY,         //	unable to comply, building in progress
    VOX_CONSTRUCTION,         //	construction complete
    VOX_UNIT_READY,         // unit ready
    VOX_NEW_CONSTRUCT,        //	new construction options
    VOX_DEPLOY,             //	cannot deploy here
    VOX_STRUCTURE_DESTROYED,    // structure destroyed
    VOX_INSUFFICIENT_POWER,     // insufficient power
    VOX_NO_CASH,            //	insufficient funds
    VOX_CONTROL_EXIT,         //	battle control terminated
    VOX_REINFORCEMENTS,       //	reinforcements have arrived
    VOX_CANCELED,           //	canceled
    VOX_BUILDING,           //	building
    VOX_LOW_POWER,            //	low power
    VOX_NEED_MO_MONEY,        //	need more funds
    VOX_BASE_UNDER_ATTACK,      //	our base is under attack
    VOX_UNABLE_TO_BUILD,        //	unable to build more
    VOX_PRIMARY_SELECTED,     //	primary building selected
    VOX_MADTANK_DEPLOYED,     // M.A.D. Tank Deployed
    VOX_none4,
    VOX_UNIT_LOST,            //	unit lost
    VOX_SELECT_TARGET,        // select target
    VOX_PREPARE,            //	enemy approaching
    VOX_NEED_MO_CAPACITY,     //	silos needed
    VOX_SUSPENDED,            //	on hold
    VOX_REPAIRING,            //	repairing
    VOX_none5,
    VOX_none6,
    VOX_AIRCRAFT_LOST,
    VOX_none7,
    VOX_ALLIED_FORCES_APPROACHING,
    VOX_ALLIED_APPROACHING,
    VOX_none8,
    VOX_none9,
    VOX_BUILDING_INFILTRATED,
    VOX_CHRONO_CHARGING,
    VOX_CHRONO_READY,
    VOX_CHRONO_TEST,
    VOX_HQ_UNDER_ATTACK,
    VOX_CENTER_DEACTIVATED,
    VOX_CONVOY_APPROACHING,
    VOX_CONVOY_UNIT_LOST,
    VOX_EXPLOSIVE_PLACED,
    VOX_MONEY_STOLEN,
    VOX_SHIP_LOST,
    VOX_SATALITE_LAUNCHED,
    VOX_SONAR_AVAILABLE,
    VOX_none10,
    VOX_SOVIET_FORCES_APPROACHING,
    VOX_SOVIET_REINFORCEMENTS,
    VOX_TRAINING,
    VOX_ABOMB_READY,
    VOX_ABOMB_LAUNCH,
    VOX_ALLIES_N,
    VOX_ALLIES_S,
    VOX_ALLIES_E,
    VOX_ALLIES_W,
    VOX_OBJECTIVE1,
    VOX_OBJECTIVE2,
    VOX_OBJECTIVE3,
    VOX_IRON_CHARGING,
    VOX_IRON_READY,
    VOX_RESCUED,
    VOX_OBJECTIVE_NOT,
    VOX_SIGNAL_N,
    VOX_SIGNAL_S,
    VOX_SIGNAL_E,
    VOX_SIGNAL_W,
    VOX_SPY_PLANE,
    VOX_FREED,
    VOX_UPGRADE_ARMOR,
    VOX_UPGRADE_FIREPOWER,
    VOX_UPGRADE_SPEED,
    VOX_MISSION_TIMER,
    VOX_UNIT_FULL,
    VOX_UNIT_REPAIRED,
    VOX_TIME_40,
    VOX_TIME_30,
    VOX_TIME_20,
    VOX_TIME_10,
    VOX_TIME_5,
    VOX_TIME_4,
    VOX_TIME_3,
    VOX_TIME_2,
    VOX_TIME_1,
    VOX_TIME_STOP,
    VOX_UNIT_SOLD,
    VOX_TIMER_STARTED,
    VOX_TARGET_RESCUED,
    VOX_TARGET_FREED,
    VOX_TANYA_RESCUED,
    VOX_STRUCTURE_SOLD,
    VOX_SOVIET_FORCES_FALLEN,
    VOX_SOVIET_SELECTED,
    VOX_SOVIET_EMPIRE_FALLEN,
    VOX_OPERATION_TERMINATED,
    VOX_OBJECTIVE_REACHED,
    VOX_OBJECTIVE_NOT_REACHED,
    VOX_OBJECTIVE_MET,
    VOX_MERCENARY_RESCUED,
    VOX_MERCENARY_FREED,
    VOX_KOSOYGEN_FREED,
    VOX_FLARE_DETECTED,
    VOX_COMMANDO_RESCUED,
    VOX_COMMANDO_FREED,
    VOX_BUILDING_IN_PROGRESS,
    VOX_ATOM_PREPPING,
    VOX_ALLIED_SELECTED,
    VOX_ABOMB_PREPPING,
    VOX_ATOM_LAUNCHED,
    VOX_ALLIED_FORCES_FALLEN,
    VOX_ABOMB_AVAILABLE,
    VOX_ALLIED_REINFORCEMENTS,
    VOX_SAVE1,
    VOX_LOAD1
  }
}
