using RA_Mission_Editor.Entities;
using RA_Mission_Editor.MapData;
using RA_Mission_Editor.MapData.TrackedActions;
using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.UI.Logic;
using RA_Mission_Editor.Util;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.UserControls
{
  public partial class BasicControl : UserControl
  {
    public BasicControl()
    {
      InitializeComponent();
      MapUserThemes.SetRAFont(this);

      cbEnableIranOverrides.CheckedChanged += cbEnableIranOverrides_CheckedChanged;

      tbName.Tag = lblName;
      cbNewIniFormat.Tag = lblNewIniFormat;
      cbPlayer.Tag = lblPlayer;
      cbTheme.Tag = lblTheme;
      cbIntro.Tag = lblIntro;
      cbBrief.Tag = lblBrief;
      cbWin.Tag = lblWin;
      cbWin2.Tag = lblWin2;
      cbWin3.Tag = lblWin3;
      cbWin4.Tag = lblWin4;
      cbLose.Tag = lblLose;
      cbAction.Tag = lblAction;
      nudCarryOverMoney.Tag = lblCarryOverMoney;
      nudCarryOverCap.Tag = lblCarryOverCap;
      nudPercent.Tag = lblPercent;
      tbNextMission.Tag = lblNextMission;
      tbMapSelectAnimation.Tag = lblMapSelectAnimation;
      tbMapSelectA.Tag = lblMapSelectA;
      tbMapSelectB.Tag = lblMapSelectB;
      tbMapSelectC.Tag = lblMapSelectC;
      nudScenarioNumber.Tag = lblScenarioNumber;
      tbBriefing.Tag = lblBriefing;

      cbEnableIranOverrides_CheckedChanged(null, null);
    }

    public IEntity StoredInfo;
    public Map Map { get; private set; }
    private bool _suspendDirty = false;

    public void SetMap(Map map)
    {
      _suspendDirty = true;
      Map = map;
      BasicSection s = map.BasicSection;

      tbName.Text = s.Name.HasValue ? s.Name.Value : "No Name";
      cbPlayer.Items.Clear();
      cbPlayer.Items.AddRange(Map.AttachedRules.Houses.GetAll());
      cbPlayer.SelectedItem = s.Player.HasValue ? Map.AttachedRules.Houses.GetHouse(s.Player.Value) : Map.AttachedRules.Houses.GetHouse(0);

      cbTheme.Items.Clear();
      cbTheme.Items.AddRange(Map.AttachedRules.Themes.GetAll());
      //cbTheme.SelectedItem = s.Theme.HasValue ? Map.AttachedRules.Houses.GetHouse(s.Theme.Value) : null;
      cbTheme.Text = s.Theme.HasValue ? s.Theme.Value : null;

      cbNewIniFormat.Text = s.NewINIFormat.HasValue ? s.NewINIFormat.Value.ToString() : "3";
      cbIntro.Text = s.Intro.HasValue ? s.Intro.Value?.ToString() : "<none>";
      cbBrief.Text = s.Brief.HasValue ? s.Brief.Value?.ToString() : "<none>";
      cbWin.Text = s.Win.HasValue ? s.Win.Value?.ToString() : "<none>";
      cbWin2.Text = s.Win2.HasValue ? s.Win2.Value?.ToString() : "<none>";
      cbWin3.Text = s.Win3.HasValue ? s.Win3.Value?.ToString() : "<none>";
      cbWin4.Text = s.Win4.HasValue ? s.Win4.Value?.ToString() : "<none>";
      cbLose.Text = s.Lose.HasValue ? s.Lose.Value?.ToString() : "<none>";
      cbAction.Text = s.Action.HasValue ? s.Action.Value?.ToString() : "<none>";

      cbToCarryOver.Checked = s.ToCarryOver.HasValue && s.ToCarryOver.Value;
      cbToInherit.Checked = s.ToInherit.HasValue && s.ToInherit.Value;
      cbTimerInherit.Checked = s.TimerInherit.HasValue && s.TimerInherit.Value;
      cbSkipScore.Checked = s.SkipScore.HasValue && s.SkipScore.Value;
      cbSkipMapSelect.Checked = s.SkipMapSelect.HasValue && s.SkipMapSelect.Value;
      cbOneTimeOnly.Checked = s.OneTimeOnly.HasValue && s.OneTimeOnly.Value;
      cbEndofGame.Checked = s.EndOfGame.HasValue && s.EndOfGame.Value;
      nudCarryOverMoney.Value = s.CarryOverMoney.HasValue ? s.CarryOverMoney.Value : 0;
      nudCarryOverCap.Value = s.CarryOverCap.HasValue ? s.CarryOverCap.Value : 0;
      nudPercent.Value = s.Percent.HasValue ? s.Percent.Value : 0;

      cbOfficial.Checked = s.Official.HasValue && s.Official.Value;
      cbCivEvac.Checked = s.CivEvac.HasValue && s.CivEvac.Value;
      cbNoSpyPlane.Checked = s.NoSpyPlane.HasValue && s.NoSpyPlane.Value;
      cbFillSilos.Checked = s.FillSilos.HasValue && s.FillSilos.Value;
      cbTruckCrate.Checked = s.TruckCrate.HasValue && s.TruckCrate.Value;

      tbBriefing.Text = map.BriefingSection.Briefing;

      tbNextMission.Text = s.NextMissionInCampaign.HasValue ? s.NextMissionInCampaign.Value : string.Empty;
      nudScenarioNumber.Value = s.ScenarioNumber.HasValue ? s.ScenarioNumber.Value : 0;
      tbMapSelectAnimation.Text = s.MapSelectionAnimation.HasValue ? s.MapSelectionAnimation.Value : string.Empty;
      tbMapSelectA.Text = s.MapSelectA.HasValue ? s.MapSelectA.Value : string.Empty;
      tbMapSelectB.Text = s.MapSelectB.HasValue ? s.MapSelectB.Value : string.Empty;
      tbMapSelectC.Text = s.MapSelectC.HasValue ? s.MapSelectC.Value : string.Empty;
      cbUseCustomTutorialText.Checked = s.UseCustomTutorialText.HasValue && s.UseCustomTutorialText.Value;

      cbEnableIranOverrides.Checked = s.NextMissionInCampaign.HasValue || s.ScenarioNumber.HasValue || s.MapSelectionAnimation.HasValue || s.MapSelectA.HasValue || s.MapSelectB.HasValue || s.MapSelectC.HasValue || s.UseCustomTutorialText.HasValue;

      DirtyControlsHandler.ResetDirtyColor(this);
      _suspendDirty = false;
      bCancel.Enabled = false;
    }

    public void Save()
    {
      BasicSectionSaveAction action = new BasicSectionSaveAction(Map);
      action.SnapshotOld();
      BasicSection s = Map.BasicSection;

      s.Name.Set(tbName.Text);
      if (cbPlayer.SelectedItem is HouseType htype) { s.Player.Set(htype.Name); } else { s.Player.Set(Map.AttachedRules.Houses.GetHouse(0).Name); }
      if (cbTheme.SelectedItem is string sTheme) { s.Theme.Set(sTheme); } else { s.Theme.Clear(); }

      if (int.TryParse(cbNewIniFormat.Text, out int iNewIniFormat)) { s.NewINIFormat.Set(iNewIniFormat); } else { s.NewINIFormat.Set(3); }
      if (string.IsNullOrWhiteSpace(cbIntro.Text)) { s.Intro.Set(cbIntro.Text); } else { s.Intro.Clear(); }
      if (string.IsNullOrWhiteSpace(cbBrief.Text)) { s.Brief.Set(cbBrief.Text); } else { s.Brief.Clear(); }
      if (string.IsNullOrWhiteSpace(cbWin.Text)) { s.Win.Set(cbWin.Text); } else { s.Win.Clear(); }
      if (string.IsNullOrWhiteSpace(cbWin2.Text)) { s.Win2.Set(cbWin2.Text); } else { s.Win2.Clear(); }
      if (string.IsNullOrWhiteSpace(cbWin3.Text)) { s.Win3.Set(cbWin3.Text); } else { s.Win3.Clear(); }
      if (string.IsNullOrWhiteSpace(cbWin4.Text)) { s.Win4.Set(cbWin4.Text); } else { s.Win4.Clear(); }
      if (string.IsNullOrWhiteSpace(cbLose.Text)) { s.Lose.Set(cbLose.Text); } else { s.Lose.Clear(); }
      if (string.IsNullOrWhiteSpace(cbAction.Text)) { s.Action.Set(cbAction.Text); } else { s.Action.Clear(); }

      s.ToCarryOver.Set(cbToCarryOver.Checked);
      s.ToInherit.Set(cbToInherit.Checked);
      s.TimerInherit.Set(cbTimerInherit.Checked);
      s.SkipScore.Set(cbSkipScore.Checked);
      s.SkipMapSelect.Set(cbSkipMapSelect.Checked);
      s.OneTimeOnly.Set(cbOneTimeOnly.Checked);
      s.EndOfGame.Set(cbEndofGame.Checked);
      s.CarryOverMoney.Set((int)nudCarryOverMoney.Value);
      s.CarryOverCap.Set((int)nudCarryOverCap.Value);
      s.Percent.Set((int)nudPercent.Value);

      s.Official.Set(cbOfficial.Checked);
      s.CivEvac.Set(cbCivEvac.Checked);
      s.NoSpyPlane.Set(cbNoSpyPlane.Checked);
      s.FillSilos.Set(cbFillSilos.Checked);
      s.TruckCrate.Set(cbTruckCrate.Checked);

      if (cbEnableIranOverrides.Checked)
      {
        if (string.IsNullOrWhiteSpace(tbNextMission.Text)) { s.NextMissionInCampaign.Set(tbNextMission.Text); } else { s.NextMissionInCampaign.Clear(); }
        s.ScenarioNumber.Set((int)nudScenarioNumber.Value);
        if (string.IsNullOrWhiteSpace(tbMapSelectAnimation.Text)) { s.MapSelectionAnimation.Set(tbMapSelectAnimation.Text); } else { s.MapSelectionAnimation.Clear(); }
        if (string.IsNullOrWhiteSpace(tbMapSelectA.Text)) { s.MapSelectA.Set(tbMapSelectA.Text); } else { s.MapSelectA.Clear(); }
        if (string.IsNullOrWhiteSpace(tbMapSelectB.Text)) { s.MapSelectB.Set(tbMapSelectB.Text); } else { s.MapSelectB.Clear(); }
        if (string.IsNullOrWhiteSpace(tbMapSelectC.Text)) { s.MapSelectC.Set(tbMapSelectC.Text); } else { s.MapSelectC.Clear(); }
        s.UseCustomTutorialText.Set(cbUseCustomTutorialText.Checked);
      }
      else
      {
        s.NextMissionInCampaign.Clear();
        s.ScenarioNumber.Clear();
        s.MapSelectionAnimation.Clear();
        s.MapSelectA.Clear();
        s.MapSelectB.Clear();
        s.MapSelectC.Clear();
        s.UseCustomTutorialText.Clear();
      }

      Map.BriefingSection.Briefing = tbBriefing.Text;
      Map.Dirty = true;

      action.SnapshotNew();
      Map.TrackedActions.Push(action);
    }

    private void bCancel_Click(object sender, EventArgs e)
    {
      SetMap(Map);
    }

    private void bOK_Click(object sender, EventArgs e)
    {
      Save();
      Map.Update();
      SetMap(Map);
    }

    private void cbEnableIranOverrides_CheckedChanged(object sender, EventArgs e)
    {
      gbIran.Enabled = cbEnableIranOverrides.Checked;
    }

    private void Value_Changed(object sender, EventArgs e)
    {
      if (!_suspendDirty && sender is Control c)
      {
        DirtyControlsHandler.SetDirtyColor(c);
        bCancel.Enabled = true;
      }
    }
  }
}
