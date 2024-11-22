using RA_Mission_Editor.Entities;
using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.RulesData;
using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.MapData
{
  public class SmudgeSection
  {
    private struct SmudgeCell
    {
      public string ID;
      public int Cell;

      public SmudgeCell(string iD, int cell)
      {
        ID = iD;
        Cell = cell;
      }
    }

    public List<SmudgeInfo> EntityList = new List<SmudgeInfo>();

    public void Read(IniFile.IniSection section)
    {
      EntityList.Clear();
      List<SmudgeCell> createdEntityCell = new List<SmudgeCell>();
      // do not care about indices
      foreach (var kvp in section.OrderedEntries)
      {
        SmudgeInfo u = new SmudgeInfo();
        if (u.Parse(kvp.Value.Value))
        {
          SmudgeInfo v = null;
          if (createdEntityCell.Contains(new SmudgeCell(u.ID, u.Cell)))
          {
            foreach (SmudgeInfo e in EntityList)
            {
              if (e.ID == u.ID && e.Cell == u.Cell)
              {
                v = e; 
                break;
              }
            }
          }

          if (v != null)
          {
            SmudgeType smg = Smudges.Get(v.ID);
            if (v.Data < smg.Images - 1)
              v.Data++;
          }
          else
          {
            EntityList.Add(u);
          }
        }
        else
        {
          // feedback the error
          throw new Exception($"Map Smudge {kvp.Key} contains less than expected parameters");
        }
      }
    }

    public void Update(IniFile.IniSection section)
    {
      section.Clear();
      int index = 0;
      foreach (SmudgeInfo smudge in EntityList)
      {
        for (int i = 0; i <= smudge.Data; i++)
        {
          section.SetValue(index.ToString(), smudge.GetValueAsWrite());
          index++;
        }
      }
    }
  }
}
