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

  public enum ColorType
  {
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
}
