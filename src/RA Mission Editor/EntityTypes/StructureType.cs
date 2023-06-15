using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class StructureType : ITechnoType, IEntityType
	{
		public string ID { get; }
		public string FullName;
		public bool IsFake;
		public string SecondImage; // for WEAP2
		public string TrueID;
		public int TurretDirections; // use 0 for no Turret
		public string BibName;
		public bool UseNeutralRemap;

		// rules overrides
		public string RulesName;
		public string RulesImage;

		public StructureType(string id)
		{
			ID = id;
			FullName = id;
			TrueID = id;
		}

		public string DisplayName { get => ToString(); }

		public override string ToString()
		{
			return RulesName ?? FullName ?? ID;
		}

		public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			TechnoTypeRenderer.GetStructureSizeInPixels(rules, cache, vfs, tt, ID, out int x, out int y);
			Bitmap bmp = new Bitmap(x, y);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				TechnoTypeRenderer.DrawStructure(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(preview.Owner), preview.Health, preview.Facing, g, 0, 0, null, -1, false);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
		{
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			TechnoTypeRenderer.DrawStructureBib(map, rules, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, entity.IsBase, highlight);
			TechnoTypeRenderer.DrawStructure(map, rules, cache, vfs, tt, palFile, ID, entity.IsBase ? rules.Houses.GetHouse(map.BaseSection.Player) : rules.Houses.GetHouse(entity.Owner), entity.IsBase ? 256 : entity.Health, entity.IsBase ? 0 : entity.Facing, g, entity.X, entity.Y, entity.Tag, entity.IsBase ? entity.BaseNumber : -1, entity.IsBase, highlight);
		}
	}
}
