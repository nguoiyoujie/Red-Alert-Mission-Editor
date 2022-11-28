using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class InfantryType : ITechnoType, IEntityType
	{
		public string ID { get; }
		public string FullName;
		public int Directions;
		public string RemapOverrideKey;

		// rules overrides
		public string RulesName;
		public string RulesImage;

		public InfantryType(string id)
		{
			ID = id;
			FullName = id;
		}

		public string DisplayName { get => ToString(); }

		public override string ToString()
		{
			return RulesName ?? FullName ?? ID;
		}

		public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			Bitmap bmp = new Bitmap(Constants.CELL_PIXEL_W, Constants.CELL_PIXEL_H);
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				TechnoTypeRenderer.DrawInfantry(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(preview?.Owner), preview?.Facing ?? 128, g, 0, 0, 0, null);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity)
    {
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			TechnoTypeRenderer.DrawInfantry(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(entity.Owner), entity.Facing, g, entity.X, entity.Y, entity.SubCell, entity.Tag);
		}
	}
}
