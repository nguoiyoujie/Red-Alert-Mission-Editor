using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
	public class ExtractType : IEntityType
	{
		public string ID { get; }
		public MapExtract Extract;

		public ExtractType(MapExtract extract)
		{
			ID = extract.DisplayName;
			Extract = extract;
		}

		public string DisplayName { get => ID; }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.None; } }

    public override string ToString()
		{
			return ID;
		}

		public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			Bitmap bmp = new Bitmap(Constants.CELL_PIXEL_W * (Extract.Ext_MapSection.FullWidth + 2), Constants.CELL_PIXEL_H * (Extract.Ext_MapSection.FullHeight + 2));
			using (Graphics g = Graphics.FromImage(bmp))
			{
				EnvironmentRenderer.DrawTemplates(map, Extract, 1, 1, cache, vfs, g);
				TechnoTypeRenderer.DrawBuildingBibs(map, Extract, 1, 1, rules, cache, vfs, g);
				EnvironmentRenderer.DrawOverlays(map, Extract, 1, 1, cache, vfs, g);
				EnvironmentRenderer.DrawSmudges(map, Extract, 1, 1, cache, vfs, g);
				EnvironmentRenderer.DrawTerrain(map, Extract, 1, 1, cache, vfs, g);
				TechnoTypeRenderer.DrawBuildings(map, Extract, 1, 1, rules, cache, vfs, g);
				TechnoTypeRenderer.DrawUnits(map, Extract, 1, 1, rules, cache, vfs, g);
				TechnoTypeRenderer.DrawVessels(map, Extract, 1, 1, rules, cache, vfs, g);
				TechnoTypeRenderer.DrawInfantries(map, Extract, 1, 1, rules, cache, vfs, g);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
		{
			EnvironmentRenderer.DrawTemplates(map, Extract, entity.X, entity.Y, cache, vfs, g);
			TechnoTypeRenderer.DrawBuildingBibs(map, Extract, entity.X, entity.Y, rules, cache, vfs, g);
			EnvironmentRenderer.DrawOverlays(map, Extract, entity.X, entity.Y, cache, vfs, g);
			EnvironmentRenderer.DrawSmudges(map, Extract, entity.X, entity.Y, cache, vfs, g);
			EnvironmentRenderer.DrawTerrain(map, Extract, entity.X, entity.Y, cache, vfs, g);
			TechnoTypeRenderer.DrawBuildings(map, Extract, entity.X, entity.Y, rules, cache, vfs, g);
			TechnoTypeRenderer.DrawUnits(map, Extract, entity.X, entity.Y, rules, cache, vfs, g);
			TechnoTypeRenderer.DrawVessels(map, Extract, entity.X, entity.Y, rules, cache, vfs, g);
			TechnoTypeRenderer.DrawInfantries(map, Extract, entity.X, entity.Y, rules, cache, vfs, g);
		}
	}
}
