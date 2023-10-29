﻿using RA_Mission_Editor.Common;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using RA_Mission_Editor.RulesData.Ruleset;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public class UnitType : ITechnoType, IEntityType
	{
		public string ID { get; }
		public string FullName;
		public string TurretName;
		public TurretLocationDelegate[] TurretLocations;
		public int Directions;
		public int TurretDirections;
		public int TurretShpFrame;
		public bool UsePrimaryColor;

		// rules overrides
		public string RulesName;
		public string RulesImage;

		public UnitType(string id)
		{
			ID = id;
			FullName = id;
			TurretName = id;
		}

		public string DisplayName { get => ToString(); }

    public EditorSelectMode SelectMode { get { return EditorSelectMode.Units; } }

    public override string ToString()
		{
			return RulesName ?? FullName ?? ID;
		}

		public Bitmap DrawPreview(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, PlaceEntityInfo preview)
		{
			Bitmap bmp = new Bitmap(Constants.CELL_PIXEL_W * 3, Constants.CELL_PIXEL_H * 3);
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				TechnoTypeRenderer.DrawUnit(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(preview?.Owner), preview?.Facing ?? 128, g, 1, 1, null);
			}
			return bmp;
		}

		public void DrawOnMap(Map map, Rules rules, MapCache cache, VirtualFileSystem vfs, Graphics g, PlaceEntityInfo entity, bool highlight)
		{
			TechnoTypeRenderer.CheckTheatre(map, cache, vfs, out TheaterType tt, out PalFile palFile);
			TechnoTypeRenderer.DrawUnit(map, rules, cache, vfs, tt, palFile, ID, rules.Houses.GetHouse(entity.Owner), entity.Facing, g, entity.X, entity.Y, entity.Tag, highlight);
		}
	}
}
