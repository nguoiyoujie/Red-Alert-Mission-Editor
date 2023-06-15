using RA_Mission_Editor.Entities;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public delegate void UpdateSelectModeDelegate(EditorSelectMode selectMode);

  public partial class MapPickDialog : Form
  {
    public MapPickDialog()
    {
      InitializeComponent();
    }

    public UpdateSelectModeDelegate ModeSelected;
    public EditorSelectMode EditorSelectMode = EditorSelectMode.Ignore;

    public int Set(MainModel model)
    {
      bTemplate.Visible = false; // true
      bTerrain.Visible = false;
      bOverlay.Visible = false;
      bSmudge.Visible = false;
      bInfantry.Visible = false;
      bUnit.Visible = false;
      bVessel.Visible = false;
      bBuilding.Visible = false;
      bBase.Visible = false;
      bWaypoint.Visible = false;
      bCellTrigger.Visible = false;

      long bitfield = 0;
      foreach (IEntity pick in model.PickCache)
      {
        switch (pick.SelectMode)
        {
          case EditorSelectMode.Templates:
            //bTemplate.Visible = true; 
            //bitfield |= 1 << (int)EditorSelectMode.Templates;
            break;
          case EditorSelectMode.Overlays:
            bOverlay.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Overlays;
            break;
          case EditorSelectMode.Terrain:
            bTerrain.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Terrain;
            break;
          case EditorSelectMode.Smudges:
            bSmudge.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Smudges;
            break;
          case EditorSelectMode.Infantry:
            bInfantry.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Infantry;
            break;
          case EditorSelectMode.Units:
            bUnit.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Units;
            break;
          case EditorSelectMode.Ships:
            bVessel.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Ships;
            break;
          case EditorSelectMode.Structures:
            bBuilding.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Structures;
            break;
          case EditorSelectMode.Bases:
            bBase.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Bases;
            break;
          case EditorSelectMode.CellTriggers:
            bCellTrigger.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.CellTriggers;
            break;
          case EditorSelectMode.Waypoints:
            bWaypoint.Visible = true;
            bitfield |= 1 << (int)EditorSelectMode.Waypoints;
            break;
        }
      }
      int count = 0;
      for (int i = 0; i < 64; i++)
      {
        if ((1L << i & bitfield) > 0)
        {
          count++;
        }
      }
      return count;
    }

    private void bTemplate_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Templates;
      Close();
    }

    private void bOverlay_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Overlays;
      Close();
    }

    private void bTerrain_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Terrain;
      Close();
    }

    private void bSmudge_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Smudges;
      Close();
    }

    private void bInfantry_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Infantry;
      Close();
    }

    private void bUnit_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Units;
      Close();
    }

    private void bVessel_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Ships;
      Close();
    }

    private void bBuilding_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Structures;
      Close();
    }

    private void bBase_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Bases;
      Close();
    }

    private void bWaypoint_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.Waypoints;
      Close();
    }

    private void bCellTrigger_Click(object sender, EventArgs e)
    {
      EditorSelectMode = EditorSelectMode.CellTriggers;
      Close();
    }

    private void MapPickDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      ModeSelected?.Invoke(EditorSelectMode);
    }

    private void MapPickDialog_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        Close();
      }
    }
  }
}
