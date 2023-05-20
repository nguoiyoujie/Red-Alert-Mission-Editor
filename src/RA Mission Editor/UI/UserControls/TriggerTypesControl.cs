using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TriggerTypesControl : UserControl
  {
    public TriggerTypesControl()
    {
      InitializeComponent();
      ttControl.TriggerTypeUpdated += ResetList;
      ttControl.SetTrigger(null);
    }

    public class AlphabeticalTriggerComparer : IComparer<TriggerInfo>
    {
      public int Compare(TriggerInfo x, TriggerInfo y)
      {
        return string.Compare(x.Name, y.Name);
      }
    }

    public Map Map { get; private set; }
    private static AlphabeticalTriggerComparer _comparer = new AlphabeticalTriggerComparer();

    public void SetMap(Map map)
    {
      Map = map;
      ttControl.SetMap(map);
      ResetList();
    }

    public void ResetList()
    {
      TriggerInfo selectedTrigger = lboxTriggerList.SelectedItem as TriggerInfo;

      lboxTriggerList.Items.Clear();
      lboxTriggerList.Items.AddRange(Map.TriggerSection.TriggerList.ToArray());
      lboxTriggerList.SelectedItem = selectedTrigger;
      ttControl.UpdateTriggerSelections();
    }

    public void ResetSelections()
    {
      ttControl.UpdateTriggerSelections();
    }

    private void lboxTriggerList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lboxTriggerList.SelectedItem is TriggerInfo tinfo)
      {
        ttControl.SetTrigger(tinfo);
      }

      bMoveUp.Enabled = lboxTriggerList.SelectedItem != null;
      bMoveDown.Enabled = lboxTriggerList.SelectedItem != null;
      bDeleteTrigger.Enabled = lboxTriggerList.SelectedItem != null;
      bDuplicate.Enabled = lboxTriggerList.SelectedItem != null;
    }

    private void bSort_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        Map.TriggerSection.TriggerList.Sort(_comparer);
        Map.Dirty = true;
        Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
        ResetList();
      }
    }

    private void bMoveUp_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTriggerList.SelectedItem is TriggerInfo tinfo)
        {
          int index = Map.TriggerSection.TriggerList.IndexOf(tinfo);
          if (index != -1 && index != 0)
          {
            Map.TriggerSection.TriggerList.RemoveAt(index);
            Map.TriggerSection.TriggerList.Insert(index - 1, tinfo);
            Map.Dirty = true;
            Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
          }
          ResetList();
          lboxTriggerList.SelectedItem = tinfo;
        }
      }
    }

    private void bMoveDown_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTriggerList.SelectedItem is TriggerInfo tinfo)
        {
          int index = Map.TriggerSection.TriggerList.IndexOf(tinfo);
          if (index != -1 && index != Map.TriggerSection.TriggerList.Count - 1)
          {
            Map.TriggerSection.TriggerList.RemoveAt(index);
            Map.TriggerSection.TriggerList.Insert(index + 1, tinfo);
            Map.Dirty = true;
            Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
          }
          ResetList();
          lboxTriggerList.SelectedItem = tinfo;
        }
      }
    }

    private void bNewTrigger_Click(object sender, EventArgs e)
    {
      int runningnum = 0;
      bool available = false;
      string name = "x";
      while (!available)
      {
        name = $"x {runningnum:000}";
        if (Map.TriggerSection.TriggerList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
        {
          available = true;
        }
        else runningnum++;
      }
      TriggerInfo tinfo = new TriggerInfo() { Name = name };
      Map.TriggerSection.TriggerList.Add(tinfo);
      Map.Dirty = true;
      Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
      ResetList();
      lboxTriggerList.SelectedItem = tinfo;
    }

    private void bDeleteTrigger_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTriggerList.SelectedItem is TriggerInfo tinfo)
        {
          int index = Map.TriggerSection.TriggerList.IndexOf(tinfo);
          if (index != -1)
          {
            Map.TriggerSection.TriggerList.RemoveAt(index);
            Map.Dirty = true;
            Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
          }
          ResetList();
          if (index != -1 && index < lboxTriggerList.Items.Count)
          {
            lboxTriggerList.SelectedIndex = index;
          }
        }
      }
    }

    private void bDuplicate_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTriggerList.SelectedItem is TriggerInfo tinfo)
        {
          string val = tinfo.GetValueAsString(Map);
          TriggerInfo dupinfo = new TriggerInfo();

          int runningnum = 0;
          bool available = false;
          string name = "x";
          while (!available)
          {
            name = $"x {runningnum:000}";
            if (Map.TriggerSection.TriggerList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
            {
              available = true;
            }
            else runningnum++;
          }
          dupinfo.Name = name;
          dupinfo.ParseValue(Map, val);
          Map.TriggerSection.TriggerList.Add(dupinfo);
          Map.Dirty = true;
          Map.InvalidateSelectionList?.Invoke(EditorSelectMode.CellTriggers);
          ResetList();
          lboxTriggerList.SelectedItem = dupinfo;
        }
      }
    }
  }
}
