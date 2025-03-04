using RA_Mission_Editor.MapData;
using RA_Mission_Editor.RulesData;
using System.IO;

namespace RA_Mission_Editor.FileFormats
{
	class TDBinFile : VirtualTextFile
	{
		// TD maps are always 64x64, with 2 bytes per tile: Template and Tile.
		// The size is fixed at 0x2000 bytes
		public MapPack MapPack;
    private int Width = 64;
    private int Height = 64;

    public TDBinFile(Stream baseStream, string filename, int baseOffset, long fileSize, bool isBuffered = true)
			: base(baseStream, filename, baseOffset, fileSize, isBuffered)
		{
			Parse();
		}

		private void Parse()
		{
			long pos = Position;
			MapPack = new MapPack(Width * Height);

			Position = pos;
			for (int i = 0; i < Width * Height; i++)
			{
				MapPack.Template[i] = ReadByte();
				//if (MapPack.Template[i]== 0xFF) { MapPack.Template[i] = 0xFFFF; }
				MapPack.Tile[i] = ReadByte();
			}
		}

		public void ImportIntoMap(Map map)
		{
			for (int x = 0; x < Width; x++)
				for (int y = 0; y < Height; y++)
				{
					int tgtX = x;
					int tgtY = y;
					int tgtCell = Util.MapHelper.CellNumber(map, tgtX, tgtY);
					if ((tgtX >= 0 && tgtX < map.Ext_MapSection.FullWidth)
					 && (tgtY >= 0 && tgtY < map.Ext_MapSection.FullHeight))
					{
						int srcCell = y + x * Height;
						map.MapPackSection.Template[tgtCell] = MapPack.Template[srcCell]; // ConvertTemplate(map, MapPack.Template[srcCell]);
						map.MapPackSection.Tile[tgtCell] = MapPack.Tile[srcCell];
					}
				}
		}

		private ushort ConvertTemplate(Map map, ushort template)
		{
			if (map.MapSection.Theater == "DESERT")
			{
				// OpenRA uses very different tileset for desert, some tiles just won't exist.
				switch (template)
				{
					default:
					case 255:
						return 0xFFFF;
					case 256:
						return (ushort)Templates.GetID("W1");
					case 257:
						return (ushort)Templates.GetID("SH17");
					case 258:
						return (ushort)Templates.GetID("SH18");
					case 180:
						return (ushort)Templates.GetID("S01");
					case 181:
						return (ushort)Templates.GetID("S02");
					case 182:
						return (ushort)Templates.GetID("S03");
					case 183:
						return (ushort)Templates.GetID("S04");
					case 184:
						return (ushort)Templates.GetID("S05");
					case 185:
						return (ushort)Templates.GetID("S06");
					case 186:
						return (ushort)Templates.GetID("S07");
					case 187:
						return (ushort)Templates.GetID("S08");
					case 188:
						return (ushort)Templates.GetID("S09");
					case 189:
						return (ushort)Templates.GetID("S10");
					case 190:
						return (ushort)Templates.GetID("S11");
					case 191:
						return (ushort)Templates.GetID("S12");
					case 192:
						return (ushort)Templates.GetID("S13");
					case 193:
						return (ushort)Templates.GetID("S14");
					case 194:
						return (ushort)Templates.GetID("S15");
					case 195:
						return (ushort)Templates.GetID("S16");
					case 196:
						return (ushort)Templates.GetID("S17");
					case 197:
						return (ushort)Templates.GetID("S18");
					case 198:
						return (ushort)Templates.GetID("S19");
					case 199:
						return (ushort)Templates.GetID("S20");
					case 200:
						return (ushort)Templates.GetID("S21");
					case 202:
						return (ushort)Templates.GetID("S22");
					case 203:
						return (ushort)Templates.GetID("S23");
					case 204:
						return (ushort)Templates.GetID("S24");
					case 205:
						return (ushort)Templates.GetID("S25");
					case 206:
						return (ushort)Templates.GetID("S26");
					case 207:
						return (ushort)Templates.GetID("S27");
					case 208:
						return (ushort)Templates.GetID("S28");
					case 209:
						return (ushort)Templates.GetID("S29");
					case 210:
						return (ushort)Templates.GetID("S30");
					case 211:
						return (ushort)Templates.GetID("S31");
					case 212:
						return (ushort)Templates.GetID("S32");
					case 213:
						return (ushort)Templates.GetID("S33");
					case 214:
						return (ushort)Templates.GetID("S34");
					case 215:
						return (ushort)Templates.GetID("S35");
					case 216:
						return (ushort)Templates.GetID("S36");
					case 217:
						return (ushort)Templates.GetID("S37");
					case 218:
						return (ushort)Templates.GetID("S38");
					case 2:
						return (ushort)Templates.GetID("B01");
					case 3:
						return (ushort)Templates.GetID("B02");
					case 4:
						return (ushort)Templates.GetID("B03");
					case 5:
						return (ushort)Templates.GetID("B04");
					case 6:
						return (ushort)Templates.GetID("B05");
					case 7:
						return (ushort)Templates.GetID("B06");
					case 14:
						return (ushort)Templates.GetID("BR01");
					case 15:
						return (ushort)Templates.GetID("BR02");
					case 16:
						return (ushort)Templates.GetID("BR03");
					case 17:
						return (ushort)Templates.GetID("BR04");
					case 18:
						return (ushort)Templates.GetID("BR05");
					case 19:
						return (ushort)Templates.GetID("BR06");
					case 20:
						return (ushort)Templates.GetID("BR07");
					case 21:
						return (ushort)Templates.GetID("BR08");
					case 22:
						return (ushort)Templates.GetID("BR09");
					case 23:
						return (ushort)Templates.GetID("BR10");
					case 35:
						return (ushort)Templates.GetID("P01");
					case 36:
						return (ushort)Templates.GetID("P02");
					case 37:
						return (ushort)Templates.GetID("P03");
					case 38:
						return (ushort)Templates.GetID("P04");
					case 39:
						return (ushort)Templates.GetID("P05");
					case 40:
						return (ushort)Templates.GetID("P06");
					case 41:
						return (ushort)Templates.GetID("P07");
					case 42:
						return (ushort)Templates.GetID("P08");
					case 43:
						return (ushort)Templates.GetID("P09");
					case 44:
						return (ushort)Templates.GetID("P10");
					case 73:
						return (ushort)Templates.GetID("RV26");
					case 74:
						return (ushort)Templates.GetID("RV27");
					// ...

				}
			}
			return template;
		}
	}
}
