using System.Collections.Generic;
using System.Drawing;

namespace RA_Mission_Editor.RulesData
{
  public static class ColorRemaps
  {
    private readonly static Dictionary<ColorType, Color[]> _listHouseRemaps = new Dictionary<ColorType, Color[]>();
    private readonly static Dictionary<string, byte[]> _listOverrideRemaps = new Dictionary<string, byte[]>();
    private readonly static Dictionary<LandType, byte> _landTypeRadarColor = new Dictionary<LandType, byte>();
    private readonly static Dictionary<TileType, byte> _tileTypePassableColor = new Dictionary<TileType, byte>();

    static ColorRemaps()
    {
      _listHouseRemaps.Add(ColorType.YELLOW, new Color[] {
          Color.FromArgb(244, 212, 120), // 0x50
          Color.FromArgb(228, 200, 112), // 0x51
          Color.FromArgb(212, 188, 104), // 0x52
          Color.FromArgb(196, 176, 96),  // 0x53
          Color.FromArgb(180, 164, 88),  // 0x54
          Color.FromArgb(168, 152, 84),  // 0x55
          Color.FromArgb(144, 136, 76),  // 0x56
          Color.FromArgb(144, 116, 64),  // 0x57
          Color.FromArgb(132, 112, 56),  // 0x58
          Color.FromArgb(108, 100, 56),  // 0x59
          Color.FromArgb(88, 84, 44),    // 0x5A
          Color.FromArgb(84, 76, 36),    // 0x5B
          Color.FromArgb(72, 68, 32),    // 0x5C
          Color.FromArgb(56, 52, 28),    // 0x5D
          Color.FromArgb(52, 44, 20),    // 0x5E
          Color.FromArgb(40, 32, 8),     // 0x5F 
        }
      );

      _listHouseRemaps.Add(ColorType.BLUE, new Color[] {
          Color.FromArgb(226, 230, 246), // 0xA0
          Color.FromArgb(206, 210, 234), // 0xA1
          Color.FromArgb(182, 190, 222), // 0xA2
          Color.FromArgb(161, 170, 202), // 0xA3
          Color.FromArgb(141, 149, 186), // 0xA4
          Color.FromArgb(125, 133, 174), // 0xA5
          Color.FromArgb(105, 117, 161), // 0xA6
          Color.FromArgb(89, 105, 149),  // 0xA7
          Color.FromArgb(68, 85, 137),   // 0xA8
          Color.FromArgb(56, 72, 125),   // 0xA9
          Color.FromArgb(48, 64, 117),   // 0xAA
          Color.FromArgb(40, 56, 109),   // 0xAB
          Color.FromArgb(32, 44, 97),    // 0xAC
          Color.FromArgb(24, 44, 85),    // 0xAD
          Color.FromArgb(12, 32, 68),    // 0xAE
          Color.FromArgb(8, 20, 52),     // 0xAF  
				}
      );

      _listHouseRemaps.Add(ColorType.RED, new Color[] {
          Color.FromArgb(255, 93, 0), // 0xE5
          Color.FromArgb(255, 0, 0),  // 0xE6
          Color.FromArgb(238, 0, 0),  // 0xE7
          Color.FromArgb(218, 0, 0),  // 0xE8
          Color.FromArgb(206, 0, 0),  // 0xE9
          Color.FromArgb(190, 0, 0),  // 0xEA
          Color.FromArgb(178, 0, 0),  // 0xEB
          Color.FromArgb(170, 0, 0),  // 0x08
          Color.FromArgb(149, 0, 0),  // 0xEC
          Color.FromArgb(133, 0, 0),  // 0xED
          Color.FromArgb(117, 0, 0),  // 0xEE
          Color.FromArgb(101, 0, 0),  // 0xEF
          Color.FromArgb(93, 8, 0),   // 0xDC
          Color.FromArgb(76, 0, 0),   // 0xDD
          Color.FromArgb(56, 0, 0),   // 0xDE
          Color.FromArgb(56, 0, 0),   // 0xDF 
        }
      );

      _listHouseRemaps.Add(ColorType.GREEN, new Color[] {
          Color.FromArgb(255, 230, 149), // 0xD0
          Color.FromArgb(255, 230, 149), // 0xD0
          Color.FromArgb(198, 230, 133), // 0x90
          Color.FromArgb(178, 210, 125), // 0x91
          Color.FromArgb(157, 190, 117), // 0x92
          Color.FromArgb(137, 174, 109), // 0x93
          Color.FromArgb(121, 153, 101), // 0x94
          Color.FromArgb(104, 137, 93),  // 0x95
          Color.FromArgb(89, 117, 76),   // 0x96
          Color.FromArgb(76, 101, 60),   // 0x97
          Color.FromArgb(60, 85, 48),    // 0x98
          Color.FromArgb(48, 68, 36),    // 0x99
          Color.FromArgb(36, 52, 24),    // 0x9A
          Color.FromArgb(36, 52, 24),    // 0x9A
          Color.FromArgb(24, 36, 16),    // 0x9B
          Color.FromArgb(20, 20, 20),    // 0x8F
				}
      );

      _listHouseRemaps.Add(ColorType.ORANGE, new Color[] {
          Color.FromArgb(255, 230, 149), // 0xD0
          Color.FromArgb(255, 214, 125), // 0xD1
          Color.FromArgb(246, 198, 113), // 0xD2
          Color.FromArgb(238, 174, 85),  // 0xD3
          Color.FromArgb(234, 161, 64),  // 0xD4
          Color.FromArgb(230, 145, 40),  // 0xD5
          Color.FromArgb(214, 121, 16),  // 0xD6
          Color.FromArgb(198, 97, 0),    // 0xD7
          Color.FromArgb(182, 72, 0),    // 0xD8
          Color.FromArgb(165, 56, 0),    // 0xD9
          Color.FromArgb(153, 40, 0),    // 0xDA
          Color.FromArgb(133, 32, 0),    // 0xDB
          Color.FromArgb(109, 16, 0),    // 0xDC
          Color.FromArgb(93, 8, 0),      // 0xDD
          Color.FromArgb(76, 0, 0),      // 0xDE
          Color.FromArgb(56, 0, 0),      // 0xDF
				}
      );

      _listHouseRemaps.Add(ColorType.GREY, new Color[] {
          Color.FromArgb(238, 238, 238), // 0x80
          Color.FromArgb(238, 226, 218), // 0x70
          Color.FromArgb(222, 206, 198), // 0x71
          Color.FromArgb(206, 186, 178), // 0x72
          Color.FromArgb(186, 165, 153), // 0x73
          Color.FromArgb(165, 145, 133), // 0x74
          Color.FromArgb(149, 125, 113), // 0x75
          Color.FromArgb(133, 113, 101), // 0x76
          Color.FromArgb(113, 89, 80),   // 0x77
          Color.FromArgb(93, 72, 64),    // 0x78
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(60, 44, 40),    // 0x7A
          Color.FromArgb(60, 44, 40),    // 0x7A
          Color.FromArgb(44, 28, 24),    // 0x7B
          Color.FromArgb(44, 28, 24),    // 0x7B
				}
      );

      _listHouseRemaps.Add(ColorType.TEAL, new Color[] {
          Color.FromArgb(93, 194, 165), // 0xE0
          Color.FromArgb(93, 194, 165), // 0xE0
          Color.FromArgb(85, 178, 153), // 0xE1
          Color.FromArgb(85, 178, 153), // 0xE1
          Color.FromArgb(76, 161, 137), // 0xE2
          Color.FromArgb(68, 145, 125), // 0xB8
          Color.FromArgb(64, 133, 117), // 0xB9
          Color.FromArgb(56, 117, 109), // 0xBA
          Color.FromArgb(28, 109, 97),  // 0xBB
          Color.FromArgb(24, 89, 76),   // 0xBC
          Color.FromArgb(24, 89, 76),   // 0xBC
          Color.FromArgb(28, 64, 64),   // 0xBD
          Color.FromArgb(12, 52, 52),   // 0xBE
          Color.FromArgb(12, 52, 52),   // 0xBE
          Color.FromArgb(0, 32, 32),    // 0xBF
          Color.FromArgb(0, 32, 32),    // 0xBF
				}
      );

      _listHouseRemaps.Add(ColorType.BROWN, new Color[] {
          Color.FromArgb(210, 153, 125), // 0xC8
          Color.FromArgb(210, 153, 125), // 0xC8
          Color.FromArgb(194, 137, 105), // 0xC9
          Color.FromArgb(182, 113, 85),  // 0xCA
          Color.FromArgb(174, 93, 68),   // 0xCA
          Color.FromArgb(174, 93, 68),   // 0xCB
          Color.FromArgb(153, 76, 56),   // 0xCC
          Color.FromArgb(133, 64, 48),   // 0xCD
          Color.FromArgb(113, 44, 36),   // 0xCD
          Color.FromArgb(113, 44, 36),   // 0xCE
          Color.FromArgb(97, 36, 28),    // 0xCF
          Color.FromArgb(93, 8, 0),      // 0xDD
          Color.FromArgb(76, 0, 0),      // 0xDE
          Color.FromArgb(76, 0, 0),      // 0xDE
          Color.FromArgb(56, 0, 0),      // 0xDF
          Color.FromArgb(56, 0, 0),      // 0xDF
				}
      );

      _listHouseRemaps.Add(ColorType.WHITE, new Color[] {
          Color.FromArgb(255, 255, 255), // 15
          Color.FromArgb(225, 225, 225),  // 15
          Color.FromArgb(238, 238, 238), // 128
          Color.FromArgb(238, 238, 238), // 128
          Color.FromArgb(238, 238, 238), // 128
          Color.FromArgb(174, 174, 174), // 132
          Color.FromArgb(174, 174, 174), // 132
          Color.FromArgb(161, 161, 161),  // 133
          Color.FromArgb(125, 125, 125), // 136
          Color.FromArgb(113, 113, 113), // 137
          Color.FromArgb(101, 101, 101), // 138
          Color.FromArgb(101, 101, 101), // 138
          Color.FromArgb(93, 93, 93), // 139
          Color.FromArgb(93, 93, 93), // 139
          Color.FromArgb(36, 36, 36), // 142
          Color.FromArgb(20, 20, 20), // 143     
				}
      );

      _listHouseRemaps.Add(ColorType.BLACK, new Color[] {
          Color.FromArgb(101, 101, 101), // 138
          Color.FromArgb(93, 93, 93), // 139
          Color.FromArgb(76, 76, 76), // 140
          Color.FromArgb(76, 76, 76), // 140
          Color.FromArgb(56, 56, 56), // 141
          Color.FromArgb(56, 56, 56), // 141
          Color.FromArgb(36, 36, 36), // 142
          Color.FromArgb(36, 36, 36), // 142
          Color.FromArgb(20, 20, 20), // 143
          Color.FromArgb(20, 20, 20), // 143
          Color.FromArgb(32, 28, 28), // 19
          Color.FromArgb(20, 20, 24), // 18
          Color.FromArgb(12, 16, 20), // 17
          Color.FromArgb(12, 16, 20), // 17
          Color.FromArgb(0, 0, 0), // 12
          Color.FromArgb(0, 0, 0), // 12    
				}
      );

      _listHouseRemaps.Add(ColorType.FLAMING_BLUE, new Color[] {
          Color.FromArgb(226, 230, 246), // 160
          Color.FromArgb(206, 210, 234), // 161
          Color.FromArgb(182, 218, 255), // 192
          Color.FromArgb(125, 190, 242), // 193
          Color.FromArgb(68, 149, 230), // 194
          Color.FromArgb(40, 121, 218), // 195
          Color.FromArgb(36, 85, 206), // 196
          Color.FromArgb(24, 68, 192), // 197
          Color.FromArgb(20, 60, 157), // 198
          Color.FromArgb(20, 60, 157), // 198
          Color.FromArgb(16, 48, 137), // 199
          Color.FromArgb(16, 48, 137), // 199
          Color.FromArgb(24, 44, 85), // 173
          Color.FromArgb(12, 32, 58), // 174
          Color.FromArgb(8, 20, 52), // 175
          Color.FromArgb(8, 20, 52), // 175     
				}
      );

      _listHouseRemaps.Add(ColorType.TRUE_GREY, new Color[] {
          Color.FromArgb(172, 172, 172), // 0x84
          Color.FromArgb(160, 160, 160), // 0x85
          Color.FromArgb(148, 148, 148), // 0x86
          Color.FromArgb(136, 136, 136), // 0x87
          Color.FromArgb(124, 124, 124), // 0x88
          Color.FromArgb(112, 112, 112), // 0x89
          Color.FromArgb(100, 100, 100), // 0x8A
          Color.FromArgb(100, 100, 100), // 0x8A
          Color.FromArgb(92, 92, 92),    // 0x8B
          Color.FromArgb(76, 76, 76),    // 0x8C
          Color.FromArgb(56, 56, 56),    // 0x8D
          Color.FromArgb(56, 56, 56),    // 0x8D
          Color.FromArgb(36, 36, 36),    // 0x8E
          Color.FromArgb(36, 36, 36),    // 0x8E
          Color.FromArgb(20, 20, 20),    // 0x8F
          Color.FromArgb(20, 20, 20),    // 0x8F 
				}
      );

      _listHouseRemaps.Add(ColorType.DIRTY_GREEN, new Color[] {
          Color.FromArgb(132, 136, 116), // 0xFE
          Color.FromArgb(124, 128, 104), // 0xFD
          Color.FromArgb(132, 136, 116), // 0xFE
          Color.FromArgb(124, 128, 104), // 0xFD
          Color.FromArgb(116, 120, 92),  // 0xFC
          Color.FromArgb(108, 112, 84),  // 0xFB
          Color.FromArgb(100, 104, 72),  // 0xFA
          Color.FromArgb(92, 96, 64),    // 0xF9
          Color.FromArgb(88, 88, 56),    // 0xF8
          Color.FromArgb(80, 80, 48),    // 0xF7
          Color.FromArgb(72, 72, 40),    // 0xF6
          Color.FromArgb(64, 64, 32),    // 0xF5
          Color.FromArgb(56, 56, 28),    // 0xF4
          Color.FromArgb(48, 48, 20),    // 0xF3
          Color.FromArgb(40, 36, 16),    // 0xF2
          Color.FromArgb(36, 32, 12),    // 0xF1
				}
      );

      _listHouseRemaps.Add(ColorType.DESERT, new Color[] {
          Color.FromArgb(208, 192, 160), // 0x68
          Color.FromArgb(196, 180, 148), // 0x69
          Color.FromArgb(184, 168, 132), // 0x6A
          Color.FromArgb(176, 156, 120), // 0x6B
          Color.FromArgb(164, 144, 108), // 0x6C
          Color.FromArgb(148, 128, 96),  // 0x6D
          Color.FromArgb(136, 108, 80),  // 0x6E
          Color.FromArgb(136, 108, 80),  // 0x6E
          Color.FromArgb(124, 96, 72),   // 0x6F
          Color.FromArgb(113, 89, 80),   // 0x77
          Color.FromArgb(93, 72, 64),    // 0x78
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(60, 44, 40),    // 0x7A
          Color.FromArgb(44, 28, 24),    // 0x7B
          Color.FromArgb(20, 20, 20),    // 0x8F
				}
      );

      _listHouseRemaps.Add(ColorType.STEEL, new Color[] {
          Color.FromArgb(132, 164, 172), // 0xB0
          Color.FromArgb(132, 164, 172), // 0xB0
          Color.FromArgb(116, 148, 156), // 0xB1
          Color.FromArgb(116, 148, 156), // 0xB1
          Color.FromArgb(100, 128, 136), // 0xB2
          Color.FromArgb(100, 128, 136), // 0xB2
          Color.FromArgb(84, 108, 116),  // 0xB3
          Color.FromArgb(84, 108, 116),  // 0xB3
          Color.FromArgb(68, 88, 96),    // 0xB4
          Color.FromArgb(68, 88, 96),    // 0xB4
          Color.FromArgb(56, 72, 76),    // 0xB5
          Color.FromArgb(56, 72, 76),    // 0xB5
          Color.FromArgb(36, 48, 52),    // 0xB6
          Color.FromArgb(36, 48, 52),    // 0xB6
          Color.FromArgb(20, 32, 36),    // 0xB7
          Color.FromArgb(20, 32, 36),    // 0xB7
				}
      );

      _listHouseRemaps.Add(ColorType.NOD_GREY, new Color[] {
          Color.FromArgb(224, 228, 244), // 0xA0
          Color.FromArgb(228, 216, 228), // 0x4F
          Color.FromArgb(216, 212, 216), // 0xE4
          Color.FromArgb(196, 196, 196), // 0xE3
          Color.FromArgb(108, 112, 84),  // 0x4B
          Color.FromArgb(80, 80, 48),    // 0x48
          Color.FromArgb(64, 64, 32),    // 0x3F
          Color.FromArgb(64, 64, 32),    // 0x3F
          Color.FromArgb(100, 128, 136), // 0xB2
          Color.FromArgb(84, 108, 116),  // 0xB3
          Color.FromArgb(68, 88, 96),    // 0xB4
          Color.FromArgb(56, 72, 76),    // 0xB5
          Color.FromArgb(36, 48, 52),    // 0xB6
          Color.FromArgb(44, 52, 52),    // 0x18
          Color.FromArgb(36, 36, 40),    // 0x15
          Color.FromArgb(20, 20, 24),    // 0x12
				}
      );

      _listHouseRemaps.Add(ColorType.PURPLE, new Color[] {
          Color.FromArgb(132, 136, 116), // 0x4F
          Color.FromArgb(124, 128, 104), // 0x4F
          Color.FromArgb(132, 136, 116), // 0x4E
          Color.FromArgb(124, 128, 104), // 0x4D
          Color.FromArgb(108, 112, 84),  // 0x4B
          Color.FromArgb(92, 96, 64),    // 0x49
          Color.FromArgb(80, 80, 48),    // 0x48
          Color.FromArgb(64, 64, 32),    // 0x3F
          Color.FromArgb(68, 85, 137),   // 0xA8
          Color.FromArgb(56, 72, 125),   // 0xA9
          Color.FromArgb(40, 56, 109),   // 0xAB
          Color.FromArgb(32, 44, 97),    // 0xAC
          Color.FromArgb(28, 32, 36),    // 0x14
          Color.FromArgb(32, 28, 28),    // 0x13
          Color.FromArgb(20, 20, 24),    // 0x12
          Color.FromArgb(12, 16, 20),    // 0x11
				}
      );

      _listHouseRemaps.Add(ColorType.DARK_GOLD, new Color[] {
          Color.FromArgb(132, 112, 56),  // 0x58
          Color.FromArgb(108, 100, 56),  // 0x59
          Color.FromArgb(108, 100, 56),  // 0x59
          Color.FromArgb(88, 84, 44),    // 0x5A
          Color.FromArgb(84, 76, 36),    // 0x5B
          Color.FromArgb(84, 76, 36),    // 0x5B
          Color.FromArgb(72, 68, 32),    // 0x5C
          Color.FromArgb(56, 52, 28),    // 0x5D
          Color.FromArgb(56, 52, 28),    // 0x5D
          Color.FromArgb(52, 44, 20),    // 0x5E
          Color.FromArgb(40, 32, 8),     // 0x5F 
          Color.FromArgb(40, 32, 8),     // 0x5F 
          Color.FromArgb(28, 24, 8),     // 0xF0 
          Color.FromArgb(20, 20, 20),    // 0x8F
          Color.FromArgb(12, 16, 20),    // 0x11
          Color.FromArgb(16, 12, 12),    // 0x10
				}
      );

      _listHouseRemaps.Add(ColorType.DARK_BLUE, new Color[] {
          Color.FromArgb(68, 85, 137),   // 0xA8
          Color.FromArgb(68, 85, 137),   // 0xA8
          Color.FromArgb(56, 72, 125),   // 0xA9
          Color.FromArgb(56, 72, 125),   // 0xA9
          Color.FromArgb(48, 64, 117),   // 0xAA
          Color.FromArgb(48, 64, 117),   // 0xAA
          Color.FromArgb(40, 56, 109),   // 0xAB
          Color.FromArgb(40, 56, 109),   // 0xAB
          Color.FromArgb(32, 44, 97),    // 0xAC
          Color.FromArgb(32, 44, 97),    // 0xAC
          Color.FromArgb(24, 44, 85),    // 0xAD
          Color.FromArgb(24, 44, 85),    // 0xAD
          Color.FromArgb(12, 32, 68),    // 0xAE
          Color.FromArgb(12, 32, 68),    // 0xAE
          Color.FromArgb(8, 20, 52),     // 0xAF
          Color.FromArgb(8, 20, 52),     // 0xAF
				}
      );

      _listHouseRemaps.Add(ColorType.DARK_RED, new Color[] {
          Color.FromArgb(190, 0, 0),  // 0xEA
          Color.FromArgb(190, 0, 0),  // 0xEA
          Color.FromArgb(178, 0, 0),  // 0xEB
          Color.FromArgb(170, 0, 0),  // 0x08
          Color.FromArgb(149, 0, 0),  // 0xEC
          Color.FromArgb(149, 0, 0),  // 0xEC
          Color.FromArgb(133, 0, 0),  // 0xED
          Color.FromArgb(133, 0, 0),  // 0xED
          Color.FromArgb(117, 0, 0),  // 0xEE
          Color.FromArgb(117, 0, 0),  // 0xEE
          Color.FromArgb(101, 0, 0),  // 0xEF
          Color.FromArgb(101, 0, 0),  // 0xEF
          Color.FromArgb(56, 0, 0),   // 0xDE
          Color.FromArgb(56, 0, 0),   // 0xDE
          Color.FromArgb(56, 0, 0),   // 0xDF 
          Color.FromArgb(56, 0, 0),   // 0xDF 
				}
      );

      _listHouseRemaps.Add(ColorType.DARK_GREEN, new Color[] {
          Color.FromArgb(104, 137, 93),  // 0x95
          Color.FromArgb(104, 137, 93),  // 0x95
          Color.FromArgb(89, 117, 76),   // 0x96
          Color.FromArgb(89, 117, 76),   // 0x96
          Color.FromArgb(89, 117, 76),   // 0x96
          Color.FromArgb(76, 101, 60),   // 0x97
          Color.FromArgb(76, 101, 60),   // 0x97
          Color.FromArgb(60, 85, 48),    // 0x98
          Color.FromArgb(60, 85, 48),    // 0x98
          Color.FromArgb(48, 68, 36),    // 0x99
          Color.FromArgb(48, 68, 36),    // 0x99
          Color.FromArgb(36, 52, 24),    // 0x9A
          Color.FromArgb(36, 52, 24),    // 0x9A
          Color.FromArgb(24, 36, 16),    // 0x9B
          Color.FromArgb(24, 36, 16),    // 0x9B
          Color.FromArgb(20, 20, 20),    // 0x8F
				}
      );

      _listHouseRemaps.Add(ColorType.DARK_ORANGE, new Color[] {
          Color.FromArgb(182, 72, 0),    // 0xD8
          Color.FromArgb(182, 72, 0),    // 0xD8
          Color.FromArgb(165, 56, 0),    // 0xD9
          Color.FromArgb(165, 56, 0),    // 0xD9
          Color.FromArgb(153, 40, 0),    // 0xDA
          Color.FromArgb(153, 40, 0),    // 0xDA
          Color.FromArgb(133, 32, 0),    // 0xDB
          Color.FromArgb(133, 32, 0),    // 0xDB
          Color.FromArgb(109, 16, 0),    // 0xDC
          Color.FromArgb(109, 16, 0),    // 0xDC
          Color.FromArgb(93, 8, 0),      // 0xDD
          Color.FromArgb(93, 8, 0),      // 0xDD
          Color.FromArgb(76, 0, 0),      // 0xDE
          Color.FromArgb(76, 0, 0),      // 0xDE
          Color.FromArgb(56, 0, 0),      // 0xDF
          Color.FromArgb(56, 0, 0),      // 0xDF
				}
      );

      _listHouseRemaps.Add(ColorType.CHOCOLATE, new Color[] {
          Color.FromArgb(133, 113, 101), // 0x76
          Color.FromArgb(133, 113, 101), // 0x76
          Color.FromArgb(113, 89, 80),   // 0x77
          Color.FromArgb(93, 72, 64),    // 0x78
          Color.FromArgb(93, 72, 64),    // 0x78
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(80, 60, 52),    // 0x79
          Color.FromArgb(60, 44, 40),    // 0x7A
          Color.FromArgb(44, 28, 24),    // 0x7B
          Color.FromArgb(44, 28, 24),    // 0x7B
          Color.FromArgb(36, 36, 40),    // 0x15
          Color.FromArgb(28, 32, 36),    // 0x14
          Color.FromArgb(32, 28, 28),    // 0x13
          Color.FromArgb(20, 20, 24),    // 0x12
          Color.FromArgb(12, 16, 20),    // 0x11
          Color.FromArgb(16, 12, 12),    // 0x10
				}
      );

      _listOverrideRemaps.Add("C2", new byte[256]{
        0,1,2,3,4,5,6,209,8,9,10,11,12,13,12,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,187,188,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,209,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,167, 13,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C4", new byte[256]{
        0,1,2,3,4,5,6,187,8,9,10,11,12,13,14,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,118,110,119,		// 96..111
	      112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,188,207,	// 192..207
	      208,209,182,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C5", new byte[256]{
        0,1,2,3,4,5,6,109,8,9,10,11,131,13,14,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,177,110,178,		// 96..111
	      112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,111,201,202,203,204,205,111,207,	// 192..207
	      208,209,182,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C6", new byte[256]{
        0,1,2,3,4,5,6,120,8,9,10,11,12,13,238,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,236,206,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,111,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C7", new byte[256]{
        0,1,2,3,4,5,6,7,8,9,10,11,12,13,131,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,157,212,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,7,		// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,118,119,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C8", new byte[256]{
        0,1,2,3,4,5,6,182,8,9,10,11,12,13,131,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,215,7,120,121,122,123,124,125,126,127,		// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,182,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,198,199,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,111,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C9", new byte[256]{
        0,1,2,3,4,5,6,7,8,9,10,11,12,13,7,15,										// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,163,165,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,200,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,111,13,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _listOverrideRemaps.Add("C10", new byte[256]{
        0,1,2,3,4,5,6,137,8,9,10,11,12,13,15,15,									// 0..15
	      16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,						// 16..31
	      32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,						// 32..47
	      48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,						// 48..63
	      64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,						// 64..79
	      80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,						// 80..95
	      96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,		// 96..111
	      112,113,114,115,116,117,129,131,120,121,122,123,124,125,126,127,	// 112..127
	      128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,	// 128..143
	      144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,137,	// 144..159
	      160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,	// 160..175
	      176,177,178,179,180,181,182,183,184,185,186,163,165,189,190,191,	// 176..191
	      192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,	// 192..207
	      208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,	// 208..223
	      224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,	// 224..239
	      240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255	// 240..255
      });

      _landTypeRadarColor.Add(LandType.LAND_CLEAR, 141);
      _landTypeRadarColor.Add(LandType.LAND_ROAD, 141);
      _landTypeRadarColor.Add(LandType.LAND_WATER, 172);
      _landTypeRadarColor.Add(LandType.LAND_ROCK, 21);
      _landTypeRadarColor.Add(LandType.LAND_WALL, 21);
      _landTypeRadarColor.Add(LandType.LAND_TIBERIUM, 158);
      _landTypeRadarColor.Add(LandType.LAND_BEACH, 141);
      _landTypeRadarColor.Add(LandType.LAND_ROUGH, 141);
      _landTypeRadarColor.Add(LandType.LAND_RIVER, 174);

      _tileTypePassableColor.Add(TileType.CLEAR_0, 254);
      _tileTypePassableColor.Add(TileType.CLEAR_1, 253);
      _tileTypePassableColor.Add(TileType.CLEAR_2, 252);
      _tileTypePassableColor.Add(TileType.CLEAR_3, 251);
      _tileTypePassableColor.Add(TileType.CLEAR_4, 250);
      _tileTypePassableColor.Add(TileType.CLEAR_5, 249);
      _tileTypePassableColor.Add(TileType.BEACH_6, 211);
      _tileTypePassableColor.Add(TileType.CLEAR_7, 248);
      _tileTypePassableColor.Add(TileType.ROCK_8, 21);
      _tileTypePassableColor.Add(TileType.ROAD_9, 114);
      _tileTypePassableColor.Add(TileType.WATER_A, 172);
      _tileTypePassableColor.Add(TileType.RIVER_B, 165);
      _tileTypePassableColor.Add(TileType.CLEAR_C, 247);
      _tileTypePassableColor.Add(TileType.CLEAR_D, 246);
      _tileTypePassableColor.Add(TileType.ROUGH_E, 119);
      _tileTypePassableColor.Add(TileType.CLEAR_F, 245);
    }

    public static Color[] GetColorRemap(ColorType color)
    {
      _listHouseRemaps.TryGetValue(color, out Color[] rgb);
      return rgb;
    }

    public static byte[] GetOverrideRemap(string key)
    {
      _listOverrideRemaps.TryGetValue(key, out byte[] swaplist);
      return swaplist;
    }

    public static byte GetRadarColor(LandType landType)
    {
      _landTypeRadarColor.TryGetValue(landType, out byte b);
      return b;
    }

    public static byte GetTileColor(TileType tileType)
    {
      _tileTypePassableColor.TryGetValue(tileType, out byte b);
      return b;
    }

    public static Color GetRadarColor(ColorType color)
    {
      Color[] colors = GetColorRemap(color);
      if (colors != null && colors.Length > 5)
      {
        return colors[4]; // index 84
      }
      else
      {
        return Color.FromArgb(180, 164, 88); // use yellow as default
      }
    }
  }
}
