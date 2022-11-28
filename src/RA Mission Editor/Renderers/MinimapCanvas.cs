using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using System.Drawing;

namespace RA_Mission_Editor.Renderers
{
  public class MinimapCanvas
  {
    public Bitmap Image;

    public MinimapCanvas()
    {
      // one time init
      Reset();
    }

    public void Reset(Map map = null)
    {
      int width = Constants.MAP_CELL_W;
      int height = Constants.MAP_CELL_H;
      if (map != null && map.Ext_MapSection.FullWidth > 0 && map.Ext_MapSection.FullHeight > 0)
      {
        width = map.Ext_MapSection.FullWidth * Constants.CELL_PIXEL_W;
        height = map.Ext_MapSection.FullHeight * Constants.CELL_PIXEL_H;
      }

      if (Image == null || Image.Size != new Size(width, height))
      {
        Image?.Dispose();
        Image = new Bitmap(width, height);
      }

      using (Graphics g = Graphics.FromImage(Image)) { g.Clear(Color.Black); }
    }

    public void Clear()
    {
      using (Graphics g = Graphics.FromImage(Image))
      {
        g.Clear(Color.Black);
      }
    }

    public void Draw(Map map, MapCache cache, VirtualFileSystem vfs)
    {
      using (Graphics g = Graphics.FromImage(Image))
      {
        MinimapRenderer.DrawMinimap(map, cache, vfs, g);
      }
    }
  }
}
