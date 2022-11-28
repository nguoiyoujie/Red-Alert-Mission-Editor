using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using System;

namespace RA_Mission_Editor.MapData
{
  public class CellTriggerSection
  {
    internal static CellTriggerInfo[] defaultTriggers = new CellTriggerInfo[Constants.MAP_CELL_NUM];

    // one cell can only have one celltrigger, so we adopt the same layout as MapPack and OverlayPack
    public CellTriggerInfo[] Triggers;

    public CellTriggerSection(int cells = Constants.MAP_CELL_NUM)
    {
      Triggers = new CellTriggerInfo[cells];
      Reset();
    }

    public void Reset()
    {
      int pos = 0;
      while (pos < Triggers.Length)
      {
        int len = Math.Min(defaultTriggers.Length, Triggers.Length - pos);
        Array.Copy(defaultTriggers, 0, Triggers, pos, len);
        pos += len;
      }
    }

    public void Set(CellTriggerInfo c)
    {
      if (c.Cell >= 0 && c.Cell < Triggers.Length)
      {
        Triggers[c.Cell] = c;
      }
    }

    public void Remove(int cell)
    {
      if (cell >= 0 && cell < Triggers.Length)
      {
        Triggers[cell] = null;
      }
    }

    public void Read(Map map, IniFile.IniSection section)
    {
      Reset();
      foreach (var kvp in section.OrderedEntries)
      {
        CellTriggerInfo c = CellTriggerInfo.Parse(map, kvp.Key, kvp.Value.Value);
        Set(c);
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      foreach (CellTriggerInfo celltrig in Triggers)
      {
        if (celltrig != null)
          section.SetValue(celltrig.GetKeyAsString(), celltrig.GetValueAsString());
      }
    }
  }
}
