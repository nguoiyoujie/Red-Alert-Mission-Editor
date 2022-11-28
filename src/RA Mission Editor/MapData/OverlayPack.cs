using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.MapData
{
  public class OverlayPack
  {
    internal static byte[] defaultOverlayPackOverlays = new byte[Constants.MAP_CELL_NUM];
    static OverlayPack()
    {
      for (int i = 0; i < defaultOverlayPackOverlays.Length; i++)
      {
        defaultOverlayPackOverlays[i] = 0xFF;
      }
    }

    // template tile
    public byte[] Overlay;

    public OverlayPack(int cells = Constants.MAP_CELL_NUM)
    {
      Overlay = new byte[cells];
      Reset();
    }

    public void Reset()
    {
      int pos = 0;
      while (pos < Overlay.Length)
      {
        int len = Math.Min(defaultOverlayPackOverlays.Length, Overlay.Length - pos);
        Array.Copy(defaultOverlayPackOverlays, 0, Overlay, pos, len);
        pos += len;
      }
    }


    public void Parse(IEnumerable<string> values)
    {
      //OverlayPack t = new OverlayPack(Constants.MAP_CELL_NUM);
      MemoryStream m = PackedSectionHelper.GetPackedSection(values);
      FastByteReader byteReader = new FastByteReader(m.GetBuffer());

      for (int i = 0; i < Constants.MAP_CELL_NUM && !byteReader.Done(); i++)
      {
        Overlay[i] = byteReader.ReadByte();
      }
    }

    public IEnumerable<string> Write()
    {
      MemoryStream m = new MemoryStream();
      for (int i = 0; i < Overlay.Length; i++)
      {
        OverlayType t = Overlays.Get(Overlay[i]);
        if (t != null)
        {
          m.WriteByte(Overlay[i]);
        }
        else
        {
          m.WriteByte(byte.MaxValue);
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