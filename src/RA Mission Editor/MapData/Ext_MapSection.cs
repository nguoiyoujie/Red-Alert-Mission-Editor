using RA_Mission_Editor.FileFormats;

namespace RA_Mission_Editor.MapData
{
  public class Ext_MapSection
  {
    /*
     * [Ext_Map]
     * FullWidth=128
     * FullHeight=128
     */
    public int FullWidth = Constants.MAP_CELL_W; // fixed for RA maps, but could change for other formats?
    public int FullHeight = Constants.MAP_CELL_H; // fixed for RA maps, but could change for other formats?
    public int FullCellCount => FullWidth * FullHeight;

    public void Read(IniFile.IniSection section)
    {
      FullWidth = section.ReadInt("TrueWidth", Constants.MAP_CELL_W);
      FullHeight = section.ReadInt("TrueHeight", Constants.MAP_CELL_H);
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      section.SetValue("TrueWidth", FullWidth.ToString());
      section.SetValue("TrueHeight", FullHeight.ToString());
    }
  }
}
