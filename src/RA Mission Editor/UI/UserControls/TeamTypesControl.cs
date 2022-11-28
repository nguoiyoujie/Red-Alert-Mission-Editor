using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class TeamTypesControl : UserControl
  {
    public TeamTypesControl()
    {
      InitializeComponent();
      ttControl.TeamTypeUpdated += ResetList;
      ttControl.SetTeamType(null);
    }

    public class AlphabeticalTeamTypeComparer : IComparer<TeamTypeInfo>
    {
      public int Compare(TeamTypeInfo x, TeamTypeInfo y)
      {
        return string.Compare(x.Name, y.Name);
      }
    }

    public Map Map { get; private set; }
    private static AlphabeticalTeamTypeComparer _comparer = new AlphabeticalTeamTypeComparer();

    public void SetMap(Map map)
    {
      Map = map;
      ttControl.SetMap(map);
      ResetList();
    }

    public void ResetList()
    {
      TeamTypeInfo selectedTeamType = lboxTeamTypeList.SelectedItem as TeamTypeInfo;

      lboxTeamTypeList.Items.Clear();
      lboxTeamTypeList.Items.AddRange(Map.TeamTypeSection.TeamTypeList.ToArray());
      lboxTeamTypeList.SelectedItem = selectedTeamType;
    }

    public void ResetSelections()
    {
      ttControl.UpdateTriggerSelections();
    }

    private void lboxTeamTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lboxTeamTypeList.SelectedItem is TeamTypeInfo tinfo)
      {
        ttControl.SetTeamType(tinfo);
      }

      bMoveUp.Enabled = lboxTeamTypeList.SelectedItem != null;
      bMoveDown.Enabled = lboxTeamTypeList.SelectedItem != null;
      bDeleteTeamType.Enabled = lboxTeamTypeList.SelectedItem != null;
      bDuplicate.Enabled = lboxTeamTypeList.SelectedItem != null;
    }

    private void bSort_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        Map.TeamTypeSection.TeamTypeList.Sort(_comparer);
        Map.Dirty = true;
        ResetList();
      }
    }

    private void bMoveUp_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTeamTypeList.SelectedItem is TeamTypeInfo tinfo)
        {
          int index = Map.TeamTypeSection.TeamTypeList.IndexOf(tinfo);
          if (index != -1 && index != 0)
          {
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.TeamTypeSection.TeamTypeList.Insert(index - 1, tinfo);
          }
          Map.Dirty = true;
          ResetList();
          lboxTeamTypeList.SelectedItem = tinfo;
        }
      }
    }

    private void bMoveDown_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTeamTypeList.SelectedItem is TeamTypeInfo tinfo)
        {
          int index = Map.TeamTypeSection.TeamTypeList.IndexOf(tinfo);
          if (index != -1 && index != Map.TeamTypeSection.TeamTypeList.Count - 1)
          {
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.TeamTypeSection.TeamTypeList.Insert(index + 1, tinfo);
          }
          Map.Dirty = true;
          ResetList();
          lboxTeamTypeList.SelectedItem = tinfo;
        }
      }
    }

    private void bNewTeamType_Click(object sender, EventArgs e)
    {
      int runningnum = 0;
      bool available = false;
      string name = "x";
      while (!available)
      {
        name = $"x {runningnum:000}";
        if (Map.TeamTypeSection.TeamTypeList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
        {
          available = true;
        }
        else runningnum++;
      }
      TeamTypeInfo tinfo = new TeamTypeInfo();
      tinfo.Name = name;
      Map.TeamTypeSection.TeamTypeList.Add(tinfo);
      Map.Dirty = true;
      ResetList();
      lboxTeamTypeList.SelectedItem = tinfo;
    }

    private void bDeleteTeamType_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTeamTypeList.SelectedItem is TeamTypeInfo tinfo)
        {
          int index = Map.TeamTypeSection.TeamTypeList.IndexOf(tinfo);
          if (index != -1)
          {
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.Dirty = true;
          }
          ResetList();
          if (index != -1 && index < lboxTeamTypeList.Items.Count)
          {
            lboxTeamTypeList.SelectedIndex = index;
          }
        }
      }
    }

    private void bDuplicate_Click(object sender, EventArgs e)
    {
      if (Map != null)
      {
        if (lboxTeamTypeList.SelectedItem is TeamTypeInfo tinfo)
        {
          string val = tinfo.GetValueAsString(Map);
          TeamTypeInfo dupinfo = new TeamTypeInfo();

          int runningnum = 0;
          bool available = false;
          string name = "x";
          while (!available)
          {
            name = $"x {runningnum:000}";
            if (Map.TeamTypeSection.TeamTypeList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
            {
              available = true;
            }
            else runningnum++;
          }
          dupinfo.Name = name;
          dupinfo.ParseValue(Map, val);
          Map.TeamTypeSection.TeamTypeList.Add(dupinfo);
          Map.Dirty = true;
          ResetList();
          lboxTeamTypeList.SelectedItem = dupinfo;
        }
      }
    }
  }
}
