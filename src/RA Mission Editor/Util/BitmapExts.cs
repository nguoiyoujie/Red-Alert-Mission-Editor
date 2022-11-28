using System.Drawing;

namespace RA_Mission_Editor.Util
{
  public static class BitmapExts
  {
    // used to differentiate between cached images and those that are generated on the fly
    private static object _cachedTag = new object();

    public static void TagAsCached(this Image image)
    {
      image.Tag = _cachedTag;
    }

    public static void ReleaseCachedTag(this Image image)
    {
      image.Tag = null;
    }

    public static bool DisposeIfNotCached(this Image image)
    {
      if (image.Tag != _cachedTag)
      {
        image.Dispose();
        return true;
      }
      return false;
    }
  }
}
