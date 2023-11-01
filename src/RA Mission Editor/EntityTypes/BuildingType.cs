using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class BuildingType : ITechnoType, IEntityType, IOccupancyType
	{
		public string ID { get; }
		public string FullName;
		public bool IsFake;
		public string SecondImage; // for WEAP2
		public string TrueID;
		public int TurretDirections; // use 0 for no Turret
		public string BibName;
		public bool UseNeutralRemap;
    public bool IsNaval;
    public List<Point> Occupancy { get; } = new List<Point>(); // only care for actual occupancy, ignore visual refresh areas

    // rules overrides
    public string RulesName;
		public string RulesImage;

		public BuildingType(string id)
		{
			ID = id;
			FullName = id;
			TrueID = id;
		}

		public string DisplayName { get => ToString(); }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Buildings; } }

    public override string ToString()
    {
      string name = RulesName ?? FullName;
      return !string.IsNullOrEmpty(name) ? ID + " - " + name : name;
    }

    public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			TechnoTypeRenderer.GetBuildingSizeInPixels(rules, cache, vfs, tt, ID, out int x, out int y);
			Bitmap bmp = new Bitmap(x, y);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				TechnoTypeRenderer.DrawBuilding(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(preview.Owner), preview.Health, preview.Facing, g, 0, 0, null, -1, false);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
		{
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
      TechnoTypeRenderer.DrawBuildingBib(map, rules, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, entity.IsBase, highlight);
			TechnoTypeRenderer.DrawBuilding(map, rules, cache, vfs, tt, palFile, ID, entity.IsBase ? rules.Houses.GetHouse(map.BaseSection.Player) : rules.Houses.GetHouse(entity.Owner), entity.IsBase ? 256 : entity.Health, entity.IsBase ? 0 : entity.Facing, g, entity.X, entity.Y, entity.Tag, entity.IsBase ? entity.BaseNumber : -1, entity.IsBase, highlight);
      TechnoTypeRenderer.DrawPlacementGrid(map, rules, cache, vfs, tt, palFile, ID, g, entity.X, entity.Y, true);
    }
  }
}
