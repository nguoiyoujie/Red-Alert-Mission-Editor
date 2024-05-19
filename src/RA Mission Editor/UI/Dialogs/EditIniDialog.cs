using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class EditIniDialog : Form
  {
    public EditIniDialog()
    {
      InitializeComponent();
    }

    public Map Map { get; private set; }

    public void SetMap(Map map)
    {
      cbSection.Items.Clear();
      lboxKeys.Items.Clear();
      // update the tags from the map
      Map = map;
      //map.SourceFile.Sections.Sort();
      cbSection.Items.AddRange(map.SourceFile.Sections.ToArray());
    }

    private void cbSection_SelectedIndexChanged(object sender, EventArgs e)
    {
      lboxKeys.Items.Clear();
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      if (section != null)
      {
        foreach (var entry in section.OrderedEntries)
          lboxKeys.Items.Add(entry.Key);

        bAddKey.Enabled = true;
      }
      else
      {
        bAddKey.Enabled = false;
        bDeleteKey.Enabled = false;
        bSetValue.Enabled = false;
      }
    }

    private void lboxKeys_SelectedIndexChanged(object sender, EventArgs e)
    {
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      string key = lboxKeys.SelectedItem as string;
      if (key != null && section != null)
      {
        tbValue.Text = section.ReadString(key);
        tbValue.ForeColor = SystemColors.ControlText;
        bDeleteKey.Enabled = true;
        bSetValue.Enabled = true;
      }
      else
      {
        bDeleteKey.Enabled = false;
        bSetValue.Enabled = false;
      }
    }

    private void tbValue_TextChanged(object sender, EventArgs e)
    {
      tbValue.ForeColor = Color.Red;
    }

    private void bSetValue_Click(object sender, EventArgs e)
    {
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      string key = lboxKeys.SelectedItem as string;
      if (key != null && section != null)
      {
        GenericIniSectionSaveAction action = new GenericIniSectionSaveAction(Map, GenericIniSectionSaveAction.ModifyType.SETKEY, section.Name, key, tbValue.Text);
        section.SetValue(key, tbValue.Text);
        Map.Dirty = true;
        Map.TrackedActions.Push(action);
      }
      tbValue.ForeColor = SystemColors.ControlText;
    }

    private void bAddSection_Click(object sender, EventArgs e)
    {
      NewIniSectionDialog nsd = new NewIniSectionDialog();
      nsd.ForbiddenKeys = new List<string>(Map.SourceFile.Sections.Select((s) => s.Name));
      if (nsd.ShowDialog() == DialogResult.OK)
      {
        GenericIniSectionSaveAction action = new GenericIniSectionSaveAction(Map, GenericIniSectionSaveAction.ModifyType.ADDSECTION, nsd.Section);
        Map.SourceFile.GetOrCreateSection(nsd.Section);
        Map.Dirty = true;
        Map.TrackedActions.Push(action);
        SetMap(Map);
        cbSection.SelectedItem = Map.SourceFile.GetSection(nsd.Section);
      }
    }

    private void bAddKey_Click(object sender, EventArgs e)
    {
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      if (section != null)
      {
        NewIniKeyDialog nkd = new NewIniKeyDialog();
        nkd.ForbiddenKeys = new List<string>(section.SortedEntries.Keys);
        if (nkd.ShowDialog() == DialogResult.OK)
        {
          GenericIniSectionSaveAction action = new GenericIniSectionSaveAction(Map, GenericIniSectionSaveAction.ModifyType.SETKEY, section.Name, nkd.Key, nkd.Value);
          section.SetValue(nkd.Key, nkd.Value);
          Map.Dirty = true;
          Map.TrackedActions.Push(action);
          cbSection_SelectedIndexChanged(null, null);
          lboxKeys.SelectedItem = nkd.Key;
        }
      }
    }

    private void bDeleteSection_Click(object sender, EventArgs e)
    {
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      if (section != null)
      {
        if (MessageBox.Show("Are you sure you want to delete this section?", "Delete INI Section", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          GenericIniSectionSaveAction action = new GenericIniSectionSaveAction(Map, GenericIniSectionSaveAction.ModifyType.REMOVESECTION, section.Name);
          Map.SourceFile.Sections.Remove(section);
          Map.Dirty = true;
          Map.TrackedActions.Push(action);
          SetMap(Map);
          cbSection.SelectedItem = null;
        }
      }
    }

    private void bDeleteKey_Click(object sender, EventArgs e)
    {
      IniFile.IniSection section = cbSection.SelectedItem as IniFile.IniSection;
      string key = lboxKeys.SelectedItem as string;
      if (section != null && key != null)
      {
        if (MessageBox.Show("Are you sure you want to delete this key?", "Delete INI Key", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          GenericIniSectionSaveAction action = new GenericIniSectionSaveAction(Map, GenericIniSectionSaveAction.ModifyType.REMOVEKEY, section.Name, key);
          section.RemoveValue(key);
          Map.Dirty = true;
          Map.TrackedActions.Push(action);
          SetMap(Map);
          cbSection_SelectedIndexChanged(null, null);
        }
      }
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void EditIniDialog_Shown(object sender, EventArgs e)
    {
      this.ActiveControl = cbSection;
    }
  }
}
