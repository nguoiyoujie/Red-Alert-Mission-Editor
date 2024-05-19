namespace RA_Mission_Editor.Util
{
  public static class BoolExts
  {
    // Reference: https://github.com/electronicarts/CnC_Remastered_Collection/blob/7d496e8a633a8bbf8a14b65f490b4d21fa32ca03/REDALERT/INI.CPP
    /* The boolean value is interpreted using the standard boolean conventions.
     * e.g., "Yes", "Y", "1", "True", "T" are all considered to be a TRUE boolean value.
     */
    public static bool GetAsBool(this string s, bool defaultValue)
    {
      if (string.IsNullOrEmpty(s))
        return defaultValue;
      switch (s[0])
      {
        case 'Y':
        case 'T':
        case 'y':
        case 't':
        case '1':
          return true;

        case 'N':
        case 'F':
        case 'n':
        case 'f':
        case '0':
          return false;

        default:
          return defaultValue;
      }
    }
  }
}
