namespace RA_Mission_Editor
{
  public class Constants
  {
    public const int MAX_GLOBALS = 30;

    public const int TEAMTYPE_MAX_TECHNOLIST = 5;
    public const int TEAMTYPE_MAX_SCRIPTLIST = 20;

    public const int MAP_CELL_W = 128;
    public const int MAP_CELL_H = 128;
    public const int MAP_CELL_NUM = MAP_CELL_W * MAP_CELL_H;

    public const int CELL_PIXEL_W = 24;
    public const int CELL_PIXEL_H = 24;

    public const string FontLocation = @".\assets\fonts\C&C_RA_font.ttf";

    public const string UnknownObjectSHPLocation = @".\assets\shps\uobj.shp";
    public const string XCCGlobalXCCDatabaseLocation = @".\assets\cache\global mix database.dat";
  }

  public delegate void VoidDelegate();

  public delegate void ActionDelegate<T>(T param);
}
