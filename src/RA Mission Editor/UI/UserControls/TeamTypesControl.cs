using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.Renderers;
using System;
using System.Collections.Generic;
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
    public void AttachRenderer(MapCanvas canvas)
    {
      ttControl.AttachRenderer(canvas);
    }

    public void ResetList()
    {
      TeamTypeInfo selectedTeamType = lboxTeamTypeList.SelectedItem as TeamTypeInfo;

      lboxTeamTypeList.Items.Clear();
      lboxTeamTypeList.Items.AddRange(Map.TeamTypeSection.TeamTypeList.ToArray());
      if (selectedTeamType != null)
      {
        foreach (TeamTypeInfo item in Map.TeamTypeSection.TeamTypeList)
        {
          if (selectedTeamType.Name == item.Name)
          {
            selectedTeamType = item;
          }
        }
      }
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
        TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
        action.Description = "Resort Teamtypes";
        action.SnapshotOld();
        Map.TeamTypeSection.TeamTypeList.Sort(_comparer);
        Map.Dirty = true;
        action.SnapshotNew();
        Map.TrackedActions.Push(action);
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
            TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
            action.Description = "Move Up Teamtype " + tinfo.Name;
            action.SnapshotOld();
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.TeamTypeSection.TeamTypeList.Insert(index - 1, tinfo);
            action.SnapshotNew();
            Map.TrackedActions.Push(action);
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
            TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
            action.Description = "Move Down Teamtype " + tinfo.Name;
            action.SnapshotOld();
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.TeamTypeSection.TeamTypeList.Insert(index + 1, tinfo);
            action.SnapshotNew();
            Map.TrackedActions.Push(action);
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
        name = $"x_{runningnum:000}";
        if (Map.TeamTypeSection.TeamTypeList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
        {
          available = true;
        }
        else runningnum++;
      }
      TeamTypeInfo tinfo = new TeamTypeInfo();
      tinfo.Name = name;
      TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
      action.Description = "New Teamtype " + tinfo.Name;
      action.SnapshotOld();
      Map.TeamTypeSection.TeamTypeList.Add(tinfo);
      Map.Dirty = true;
      action.SnapshotNew();
      Map.TrackedActions.Push(action);
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
            TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
            action.Description = "Delete Teamtype " + tinfo.Name;
            action.SnapshotOld();
            Map.TeamTypeSection.TeamTypeList.RemoveAt(index);
            Map.Dirty = true;
            action.SnapshotNew();
            Map.TrackedActions.Push(action);
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
            name = $"x_{runningnum:000}";
            if (Map.TeamTypeSection.TeamTypeList.FindIndex((t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) == -1)
            {
              available = true;
            }
            else runningnum++;
          }
          dupinfo.Name = name;
          dupinfo.ParseValue(Map, val);
          TeamTypeSectionUpdateAction action = new TeamTypeSectionUpdateAction(Map);
          action.Description = "Duplicate Teamtype " + name;
          action.SnapshotOld();
          Map.TeamTypeSection.TeamTypeList.Add(dupinfo);
          Map.Dirty = true;
          ResetList();
          lboxTeamTypeList.SelectedItem = dupinfo;
          action.SnapshotNew();
          Map.TrackedActions.Push(action);
        }
      }
    }
  }
}
