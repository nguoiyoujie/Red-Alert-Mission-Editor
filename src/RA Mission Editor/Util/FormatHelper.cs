
using RA_Mission_Editor.FileFormats;
using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.Util
{
  /// <summary>Format helper functions.</summary>
  public static class FormatHelper
  {
    public static readonly Dictionary<string, FileFormat> ExtensionMapping = new Dictionary<string, FileFormat>()
    {
      { ".ini", FileFormat.Ini },
      { ".mix", FileFormat.Mix },
      { ".pal", FileFormat.Pal },
      { ".shp", FileFormat.Shp },
      // language
      { ".eng", FileFormat.Eng },
      // templates
      { ".tmp", FileFormat.Tmp }, // Temperate
      { ".sno", FileFormat.Tmp }, // Snow
      { ".int", FileFormat.Tmp }, // Interior
      // new templates by Iran
      { ".win", FileFormat.Tmp }, // Winter
      { ".des", FileFormat.Tmp }, // Desert
      { ".jun", FileFormat.Tmp }, // Jungle

    };

    public static FileFormat GuessFormat(string filename)
    {
      string extension = Path.GetExtension(filename).ToLower();
      if (!ExtensionMapping.TryGetValue(extension, out FileFormat f))
        return FileFormat.Ukn;
      return f;
    }

    public static FileFormat GetFormatFromTypeclass(Type t)
    {
      if (t == typeof(IniFile)) return FileFormat.Ini;
      if (t == typeof(MixFile)) return FileFormat.Mix;
      if (t == typeof(PalFile)) return FileFormat.Pal;
      if (t == typeof(ShpFile)) return FileFormat.Shp;
      if (t == typeof(TmpFile)) return FileFormat.Tmp;
      if (t == typeof(LanguageFile)) return FileFormat.Eng;
      if (t == typeof(OpenRABinFile)) return FileFormat.OpenRABin;
      return FileFormat.Ukn;
    }

    public static VirtualFile OpenAsFormat(Stream baseStream, string filename, int offset = 0, int length = -1, FileFormat format = FileFormat.None, CacheMethod m = CacheMethod.Default)
    {
      if (length == -1) length = (int)baseStream.Length;
      if (format == FileFormat.None)
      {
        format = GuessFormat(filename);
      }

      switch (format)
      {
        case FileFormat.Ini:
          return new IniFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.Mix:
          return new MixFile(baseStream, filename, offset, length, m == CacheMethod.Cache);
        case FileFormat.Pal:
          return new PalFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.Shp:
          return new ShpFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.Tmp:
          return new TmpFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.Eng:
          return new LanguageFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.OpenRABin:
          return new OpenRABinFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
        case FileFormat.Ukn:
        default:
          return new VirtualFile(baseStream, filename, offset, length, m != CacheMethod.NoCache);
      }
    }
  }
}
