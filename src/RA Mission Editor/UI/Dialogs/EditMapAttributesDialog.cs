using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.RulesData;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class EditMapAttributesDialog : Form
  {
    public EditMapAttributesDialog()
    {
      InitializeComponent();
      foreach (var th in Theaters.GetTheaters())
      {
        cbTheater.Items.Add(th);
      }
      cbTheater.SelectedIndex = 0;
    }

    public void SetMap(Map map)
    {
      Map = map;
      MapSection = Map.MapSection;
      try
      {
        nudX.Value = MapSection.X;
        nudY.Value = MapSection.Y;
        nudW.Value = MapSection.Width;
        nudH.Value = MapSection.Height;
        cbTheater.SelectedItem = Theaters.GetTheater(MapSection.Theater);
      }
      catch
      {

      }
    }

    internal Map Map;
    internal MapSection MapSection;

    private void nudXY_ValueChanged(object sender, EventArgs e)
    {
      // X + W and Y + H must not exceed 127 each (X, Y, W, H is minimum 1)
      nudW.Value = Math.Min(127 - nudX.Value, nudW.Value);
      nudW.Maximum = 127 - nudX.Value;

      nudH.Value = Math.Min(127 - nudY.Value, nudH.Value);
      nudH.Maximum = 127 - nudY.Value;
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      if (MapSection == null) { MapSection = new MapSection(); }
      bool modified = false;
      MapSectionUpdateAction action = null;
      if (Map != null)
      {
        action = new MapSectionUpdateAction(Map);
        action.SnapshotOld();
      }
      if (MapSection.Theater != ((TheaterType)cbTheater.SelectedItem).Name)
      {
        MapSection.Theater = ((TheaterType)cbTheater.SelectedItem).Name;
        modified = true;
      }
      if (MapSection.X != (int)nudX.Value)
      {
        MapSection.X = (int)nudX.Value;
        modified = true;
      }
      if (MapSection.Y != (int)nudY.Value)
      {
        MapSection.Y = (int)nudY.Value; 
        modified = true;
      }
      if (MapSection.Width != (int)nudW.Value)
      {
        MapSection.Width = (int)nudW.Value;
        modified = true;
      }
      if (MapSection.Height != (int)nudH.Value)
      {
        MapSection.Height = (int)nudH.Value;
        modified = true;
      }
      if (modified && Map != null)
      {
        Map.Dirty = true;
        Map.InvalidateTemplateDisplay?.Invoke();
        action.SnapshotNew();
        Map.TrackedActions.Push(action);
      }
      Close();
    }

    private void EditMapAttributesDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = cbTheater;
    }
  }
}
