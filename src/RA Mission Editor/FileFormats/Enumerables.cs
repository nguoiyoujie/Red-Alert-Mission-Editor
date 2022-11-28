namespace RA_Mission_Editor.FileFormats
{
  public enum EncodingFormat { Format20 = 0x20, Format40 = 0x40, Format80 = 0x80 }

  /// <summary>Values that represent FileFormat.</summary>
  public enum FileFormat
  {
    /// <summary>Ini file.</summary>
    Ini,

    /// <summary>Mix file container.</summary>
    Mix,

    /// <summary>Palette file.</summary>
    Pal,

    /// <summary>SHP file, for buildings and infantry.</summary>
    Shp,

    /// <summary>Tile file used for the map's terrain.</summary>
    Tmp,

    /// <summary>Language file (English).</summary>
    Eng,

    /// <summary>Open RA bin type.</summary>
    OpenRABin,

    /// <summary>Unknown file type.</summary>
    Ukn,

    /// <summary>No specific type.</summary>
    None
  }

}
