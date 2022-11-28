using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.MapData
{
  public class MapPack
  {
    internal static ushort[] defaultMapPackTemplates = new ushort[Constants.MAP_CELL_NUM];
    internal static byte[] defaultMapPackTiles = new byte[Constants.MAP_CELL_NUM];
    static MapPack()
    {
      for (int i = 0; i < defaultMapPackTemplates.Length; i++)
      {
        defaultMapPackTemplates[i] = 0xFFFF;
      }
    }

    // template tile
    public ushort[] Template;
    public byte[] Tile;

    public MapPack(int cells = Constants.MAP_CELL_NUM)
    {
      Template = new ushort[cells];
      Tile = new byte[cells];
      Reset();
    }

    public void Reset()
    {
      int pos = 0;
      while (pos < Template.Length)
      {
        int len = Math.Min(defaultMapPackTemplates.Length, Template.Length - pos);
        Array.Copy(defaultMapPackTemplates, 0, Template, pos, len);
        pos += len;
      }

      pos = 0;
      while (pos < Tile.Length)
      {
        int len = Math.Min(defaultMapPackTiles.Length, Tile.Length - pos);
        Array.Copy(defaultMapPackTiles, 0, Tile, pos, len);
        pos += len;
      }
    }

    public void Parse(IEnumerable<string> values)
    {
      MemoryStream m = PackedSectionHelper.GetPackedSection(values);
      FastByteReader byteReader = new FastByteReader(m.GetBuffer());

      for (int i = 0; i < Constants.MAP_CELL_NUM && !byteReader.Done(); i++)
      {
        Template[i] = byteReader.ReadWord();
      }

      for (int i = 0; i < Constants.MAP_CELL_NUM && !byteReader.Done(); i++)
      {
        Tile[i] = byteReader.ReadByte();
      }
    }

    public IEnumerable<string> Write()
    {
      MemoryStream m = new MemoryStream();
      BinaryWriter bw = new BinaryWriter(m);
      for (int i = 0; i < Template.Length; i++)
      {
        // write word (ushort)
        TemplateType t = Templates.Get(Template[i]);
        if (t != null)
        {
          bw.Write(Template[i]);
        }
        else
        {
          bw.Write(ushort.MaxValue);
        }
      }

      for (int i = 0; i < Tile.Length; i++)
      {
        TemplateType t = Templates.Get(Template[i]);
        if (t != null)
        {
          bw.Write(Tile[i]);
        }
        else
        {
          bw.Write(byte.MaxValue);
        }
      }
      m.Position = 0;
      return PackedSectionHelper.RepackSection(m);
    }

    public void Read(IniFile.IniSection section)
    {
      Reset();
      List<string> val = new List<string>(section.OrderedEntries.Count);
      foreach (var kvp in section.OrderedEntries)
      {
        val.Add(kvp.Value.Value);
      }
      Parse(val);
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 1; // start from 1
      foreach (string v in Write())
      {
        section.SetValue(index.ToString(), v);
        index++;
      }
    }
  }
}