using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class MapSection
  {
    /*
     * [Map]
     * Theater=SNOW
     * X=1
     * Y=1
     * Width=126
     * Height=126
     * 
     */
    public string Theater;
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public void Read(IniFile.IniSection section)
    {
      Theater = section.ReadString("Theater", "TEMPERATE");
      X = section.ReadInt("X", 1);
      Y = section.ReadInt("Y", 1);
      Width = section.ReadInt("Width", 126);
      Height = section.ReadInt("Height", 126);
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      section.SetValue("Theater", Theater);
      section.SetValue("X", X.ToString());
      section.SetValue("Y", Y.ToString());
      section.SetValue("Width", Width.ToString());
      section.SetValue("Height", Height.ToString());
    }
  }
}
