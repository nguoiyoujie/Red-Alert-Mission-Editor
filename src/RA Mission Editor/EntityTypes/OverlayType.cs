using RA_Mission_Editor.Common;
using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
	// overlay is its own entity
	public class OverlayType : IEntityType, IEntity
	{
		public string ID { get; }

    public OverlaySubType SubType;

		public OverlayType(string id, OverlaySubType subType = OverlaySubType.NONE)
		{
			ID = id;
			SubType = subType;
		}

		public string DisplayName { get => ToString(); }

		public EditorSelectMode SelectMode { get { return EditorSelectMode.Overlays; } }

		public override string ToString()
		{
			return ID;
		}

    public IEntityType GetEntityType(Rules rules)
    {
			return this;
		}

		public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			Bitmap bmp = null;
			EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);

			if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
					cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
			{
				bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity)
		{
			EnvironmentRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			Bitmap bmp = null;
			if (cache.GetOrOpen(ID + tt.Extension, vfs, out ShpFile shpFile) ||
					cache.GetOrOpen(ID + ".SHP", vfs, out shpFile))
			{
				bmp = RenderUtils.RenderShp(cache, shpFile, palFile, 0);
			}
			if (bmp != null)
			{
				g.DrawImage(bmp, entity.X * Constants.CELL_PIXEL_W, entity.Y * Constants.CELL_PIXEL_H);
			}
		}
	}
}
