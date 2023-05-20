
namespace RA_Mission_Editor.UI.UserControls
{
  partial class BasicControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicControl));
      this.tbName = new System.Windows.Forms.TextBox();
      this.cbTimerInherit = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbAction = new System.Windows.Forms.ComboBox();
      this.cbLose = new System.Windows.Forms.ComboBox();
      this.cbWin4 = new System.Windows.Forms.ComboBox();
      this.cbWin3 = new System.Windows.Forms.ComboBox();
      this.cbWin2 = new System.Windows.Forms.ComboBox();
      this.cbWin = new System.Windows.Forms.ComboBox();
      this.cbBrief = new System.Windows.Forms.ComboBox();
      this.cbIntro = new System.Windows.Forms.ComboBox();
      this.lblWin4 = new System.Windows.Forms.Label();
      this.lblWin3 = new System.Windows.Forms.Label();
      this.lblWin2 = new System.Windows.Forms.Label();
      this.lblIntro = new System.Windows.Forms.Label();
      this.lblBrief = new System.Windows.Forms.Label();
      this.lblAction = new System.Windows.Forms.Label();
      this.lblWin = new System.Windows.Forms.Label();
      this.lblLose = new System.Windows.Forms.Label();
      this.tbBriefing = new System.Windows.Forms.TextBox();
      this.nudCarryOverMoney = new System.Windows.Forms.NumericUpDown();
      this.cbSkipMapSelect = new System.Windows.Forms.CheckBox();
      this.cbToCarryOver = new System.Windows.Forms.CheckBox();
      this.cbOneTimeOnly = new System.Windows.Forms.CheckBox();
      this.cbToInherit = new System.Windows.Forms.CheckBox();
      this.lblPercent = new System.Windows.Forms.Label();
      this.cbEndofGame = new System.Windows.Forms.CheckBox();
      this.cbSkipScore = new System.Windows.Forms.CheckBox();
      this.gbInheritance = new System.Windows.Forms.GroupBox();
      this.nudCarryOverCap = new System.Windows.Forms.NumericUpDown();
      this.lblCarryOverCap = new System.Windows.Forms.Label();
      this.lblCarryOverMoney = new System.Windows.Forms.Label();
      this.nudPercent = new System.Windows.Forms.NumericUpDown();
      this.lblBriefing = new System.Windows.Forms.Label();
      this.gbIran = new System.Windows.Forms.GroupBox();
      this.cbUseCustomTutorialText = new System.Windows.Forms.CheckBox();
      this.lblMapSelectC = new System.Windows.Forms.Label();
      this.lblMapSelectB = new System.Windows.Forms.Label();
      this.tbMapSelectC = new System.Windows.Forms.TextBox();
      this.tbMapSelectB = new System.Windows.Forms.TextBox();
      this.tbMapSelectA = new System.Windows.Forms.TextBox();
      this.lblMapSelectA = new System.Windows.Forms.Label();
      this.tbMapSelectAnimation = new System.Windows.Forms.TextBox();
      this.tbNextMission = new System.Windows.Forms.TextBox();
      this.lblMapSelectAnimation = new System.Windows.Forms.Label();
      this.lblNextMission = new System.Windows.Forms.Label();
      this.lblScenarioNumber = new System.Windows.Forms.Label();
      this.nudScenarioNumber = new System.Windows.Forms.NumericUpDown();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.lblName = new System.Windows.Forms.Label();
      this.cbTheme = new System.Windows.Forms.ComboBox();
      this.gbGeneral = new System.Windows.Forms.GroupBox();
      this.cbTruckCrate = new System.Windows.Forms.CheckBox();
      this.cbFillSilos = new System.Windows.Forms.CheckBox();
      this.cbOfficial = new System.Windows.Forms.CheckBox();
      this.cbNoSpyPlane = new System.Windows.Forms.CheckBox();
      this.cbCivEvac = new System.Windows.Forms.CheckBox();
      this.lblNewIniFormat = new System.Windows.Forms.Label();
      this.cbPlayer = new System.Windows.Forms.ComboBox();
      this.lblPlayer = new System.Windows.Forms.Label();
      this.lblTheme = new System.Windows.Forms.Label();
      this.cbNewIniFormat = new System.Windows.Forms.ComboBox();
      this.cbEnableIranOverrides = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCarryOverMoney)).BeginInit();
      this.gbInheritance.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCarryOverCap)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPercent)).BeginInit();
      this.gbIran.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudScenarioNumber)).BeginInit();
      this.gbGeneral.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(105, 18);
      this.tbName.MaxLength = 40;
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(375, 20);
      this.tbName.TabIndex = 27;
      this.tbName.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbTimerInherit
      // 
      this.cbTimerInherit.AutoSize = true;
      this.cbTimerInherit.Location = new System.Drawing.Point(131, 41);
      this.cbTimerInherit.Name = "cbTimerInherit";
      this.cbTimerInherit.Size = new System.Drawing.Size(84, 17);
      this.cbTimerInherit.TabIndex = 25;
      this.cbTimerInherit.Text = "Inherit Timer";
      this.cbTimerInherit.UseVisualStyleBackColor = true;
      this.cbTimerInherit.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbAction);
      this.groupBox1.Controls.Add(this.cbLose);
      this.groupBox1.Controls.Add(this.cbWin4);
      this.groupBox1.Controls.Add(this.cbWin3);
      this.groupBox1.Controls.Add(this.cbWin2);
      this.groupBox1.Controls.Add(this.cbWin);
      this.groupBox1.Controls.Add(this.cbBrief);
      this.groupBox1.Controls.Add(this.cbIntro);
      this.groupBox1.Controls.Add(this.lblWin4);
      this.groupBox1.Controls.Add(this.lblWin3);
      this.groupBox1.Controls.Add(this.lblWin2);
      this.groupBox1.Controls.Add(this.lblIntro);
      this.groupBox1.Controls.Add(this.lblBrief);
      this.groupBox1.Controls.Add(this.lblAction);
      this.groupBox1.Controls.Add(this.lblWin);
      this.groupBox1.Controls.Add(this.lblLose);
      this.groupBox1.Location = new System.Drawing.Point(3, 203);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(174, 237);
      this.groupBox1.TabIndex = 50;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Movies";
      // 
      // cbAction
      // 
      this.cbAction.FormattingEnabled = true;
      this.cbAction.Location = new System.Drawing.Point(59, 208);
      this.cbAction.Name = "cbAction";
      this.cbAction.Size = new System.Drawing.Size(105, 21);
      this.cbAction.TabIndex = 45;
      this.cbAction.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbLose
      // 
      this.cbLose.FormattingEnabled = true;
      this.cbLose.Location = new System.Drawing.Point(59, 181);
      this.cbLose.Name = "cbLose";
      this.cbLose.Size = new System.Drawing.Size(105, 21);
      this.cbLose.TabIndex = 44;
      this.cbLose.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbWin4
      // 
      this.cbWin4.FormattingEnabled = true;
      this.cbWin4.Location = new System.Drawing.Point(59, 154);
      this.cbWin4.Name = "cbWin4";
      this.cbWin4.Size = new System.Drawing.Size(105, 21);
      this.cbWin4.TabIndex = 43;
      this.cbWin4.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbWin3
      // 
      this.cbWin3.FormattingEnabled = true;
      this.cbWin3.Location = new System.Drawing.Point(59, 127);
      this.cbWin3.Name = "cbWin3";
      this.cbWin3.Size = new System.Drawing.Size(105, 21);
      this.cbWin3.TabIndex = 42;
      this.cbWin3.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbWin2
      // 
      this.cbWin2.FormattingEnabled = true;
      this.cbWin2.Location = new System.Drawing.Point(59, 100);
      this.cbWin2.Name = "cbWin2";
      this.cbWin2.Size = new System.Drawing.Size(105, 21);
      this.cbWin2.TabIndex = 41;
      this.cbWin2.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbWin
      // 
      this.cbWin.FormattingEnabled = true;
      this.cbWin.Location = new System.Drawing.Point(59, 73);
      this.cbWin.Name = "cbWin";
      this.cbWin.Size = new System.Drawing.Size(105, 21);
      this.cbWin.TabIndex = 40;
      this.cbWin.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbBrief
      // 
      this.cbBrief.FormattingEnabled = true;
      this.cbBrief.Location = new System.Drawing.Point(59, 46);
      this.cbBrief.Name = "cbBrief";
      this.cbBrief.Size = new System.Drawing.Size(105, 21);
      this.cbBrief.TabIndex = 39;
      this.cbBrief.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbIntro
      // 
      this.cbIntro.FormattingEnabled = true;
      this.cbIntro.Location = new System.Drawing.Point(59, 19);
      this.cbIntro.Name = "cbIntro";
      this.cbIntro.Size = new System.Drawing.Size(105, 21);
      this.cbIntro.TabIndex = 38;
      this.cbIntro.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblWin4
      // 
      this.lblWin4.AutoSize = true;
      this.lblWin4.Location = new System.Drawing.Point(6, 157);
      this.lblWin4.Name = "lblWin4";
      this.lblWin4.Size = new System.Drawing.Size(32, 13);
      this.lblWin4.TabIndex = 37;
      this.lblWin4.Text = "Win4";
      // 
      // lblWin3
      // 
      this.lblWin3.AutoSize = true;
      this.lblWin3.Location = new System.Drawing.Point(6, 130);
      this.lblWin3.Name = "lblWin3";
      this.lblWin3.Size = new System.Drawing.Size(32, 13);
      this.lblWin3.TabIndex = 36;
      this.lblWin3.Text = "Win3";
      // 
      // lblWin2
      // 
      this.lblWin2.AutoSize = true;
      this.lblWin2.Location = new System.Drawing.Point(6, 103);
      this.lblWin2.Name = "lblWin2";
      this.lblWin2.Size = new System.Drawing.Size(32, 13);
      this.lblWin2.TabIndex = 35;
      this.lblWin2.Text = "Win2";
      // 
      // lblIntro
      // 
      this.lblIntro.AutoSize = true;
      this.lblIntro.Location = new System.Drawing.Point(6, 22);
      this.lblIntro.Name = "lblIntro";
      this.lblIntro.Size = new System.Drawing.Size(28, 13);
      this.lblIntro.TabIndex = 34;
      this.lblIntro.Text = "Intro";
      // 
      // lblBrief
      // 
      this.lblBrief.AutoSize = true;
      this.lblBrief.Location = new System.Drawing.Point(6, 49);
      this.lblBrief.Name = "lblBrief";
      this.lblBrief.Size = new System.Drawing.Size(28, 13);
      this.lblBrief.TabIndex = 33;
      this.lblBrief.Text = "Brief";
      // 
      // lblAction
      // 
      this.lblAction.AutoSize = true;
      this.lblAction.Location = new System.Drawing.Point(6, 211);
      this.lblAction.Name = "lblAction";
      this.lblAction.Size = new System.Drawing.Size(37, 13);
      this.lblAction.TabIndex = 32;
      this.lblAction.Text = "Action";
      // 
      // lblWin
      // 
      this.lblWin.AutoSize = true;
      this.lblWin.Location = new System.Drawing.Point(6, 76);
      this.lblWin.Name = "lblWin";
      this.lblWin.Size = new System.Drawing.Size(26, 13);
      this.lblWin.TabIndex = 30;
      this.lblWin.Text = "Win";
      // 
      // lblLose
      // 
      this.lblLose.AutoSize = true;
      this.lblLose.Location = new System.Drawing.Point(6, 184);
      this.lblLose.Name = "lblLose";
      this.lblLose.Size = new System.Drawing.Size(30, 13);
      this.lblLose.TabIndex = 31;
      this.lblLose.Text = "Lose";
      // 
      // tbBriefing
      // 
      this.tbBriefing.Location = new System.Drawing.Point(495, 246);
      this.tbBriefing.Multiline = true;
      this.tbBriefing.Name = "tbBriefing";
      this.tbBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbBriefing.Size = new System.Drawing.Size(297, 194);
      this.tbBriefing.TabIndex = 52;
      this.tbBriefing.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // nudCarryOverMoney
      // 
      this.nudCarryOverMoney.Location = new System.Drawing.Point(131, 134);
      this.nudCarryOverMoney.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
      this.nudCarryOverMoney.Name = "nudCarryOverMoney";
      this.nudCarryOverMoney.Size = new System.Drawing.Size(60, 20);
      this.nudCarryOverMoney.TabIndex = 52;
      this.nudCarryOverMoney.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
      this.nudCarryOverMoney.ValueChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbSkipMapSelect
      // 
      this.cbSkipMapSelect.AutoSize = true;
      this.cbSkipMapSelect.Location = new System.Drawing.Point(6, 42);
      this.cbSkipMapSelect.Name = "cbSkipMapSelect";
      this.cbSkipMapSelect.Size = new System.Drawing.Size(104, 17);
      this.cbSkipMapSelect.TabIndex = 49;
      this.cbSkipMapSelect.Text = "Skip Map Select";
      this.cbSkipMapSelect.UseVisualStyleBackColor = true;
      this.cbSkipMapSelect.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbToCarryOver
      // 
      this.cbToCarryOver.AutoSize = true;
      this.cbToCarryOver.Location = new System.Drawing.Point(6, 19);
      this.cbToCarryOver.Name = "cbToCarryOver";
      this.cbToCarryOver.Size = new System.Drawing.Size(100, 17);
      this.cbToCarryOver.TabIndex = 41;
      this.cbToCarryOver.Text = "Carry Over Map";
      this.cbToCarryOver.UseVisualStyleBackColor = true;
      this.cbToCarryOver.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbOneTimeOnly
      // 
      this.cbOneTimeOnly.AutoSize = true;
      this.cbOneTimeOnly.Location = new System.Drawing.Point(6, 88);
      this.cbOneTimeOnly.Name = "cbOneTimeOnly";
      this.cbOneTimeOnly.Size = new System.Drawing.Size(190, 17);
      this.cbOneTimeOnly.TabIndex = 47;
      this.cbOneTimeOnly.Text = "One Time Only (Exit to Main Menu)";
      this.cbOneTimeOnly.UseVisualStyleBackColor = true;
      this.cbOneTimeOnly.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbToInherit
      // 
      this.cbToInherit.AutoSize = true;
      this.cbToInherit.Location = new System.Drawing.Point(131, 18);
      this.cbToInherit.Name = "cbToInherit";
      this.cbToInherit.Size = new System.Drawing.Size(141, 17);
      this.cbToInherit.TabIndex = 40;
      this.cbToInherit.Text = "Inherit Carried Over Map";
      this.cbToInherit.UseVisualStyleBackColor = true;
      this.cbToInherit.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblPercent
      // 
      this.lblPercent.AutoSize = true;
      this.lblPercent.Location = new System.Drawing.Point(10, 189);
      this.lblPercent.Name = "lblPercent";
      this.lblPercent.Size = new System.Drawing.Size(97, 13);
      this.lblPercent.TabIndex = 42;
      this.lblPercent.Text = "Carry Over Percent";
      // 
      // cbEndofGame
      // 
      this.cbEndofGame.AutoSize = true;
      this.cbEndofGame.Location = new System.Drawing.Point(6, 111);
      this.cbEndofGame.Name = "cbEndofGame";
      this.cbEndofGame.Size = new System.Drawing.Size(159, 17);
      this.cbEndofGame.TabIndex = 43;
      this.cbEndofGame.Text = "End of Game (Show Credits)";
      this.cbEndofGame.UseVisualStyleBackColor = true;
      this.cbEndofGame.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbSkipScore
      // 
      this.cbSkipScore.AutoSize = true;
      this.cbSkipScore.Location = new System.Drawing.Point(6, 65);
      this.cbSkipScore.Name = "cbSkipScore";
      this.cbSkipScore.Size = new System.Drawing.Size(78, 17);
      this.cbSkipScore.TabIndex = 46;
      this.cbSkipScore.Text = "Skip Score";
      this.cbSkipScore.UseVisualStyleBackColor = true;
      this.cbSkipScore.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // gbInheritance
      // 
      this.gbInheritance.Controls.Add(this.nudCarryOverMoney);
      this.gbInheritance.Controls.Add(this.cbSkipMapSelect);
      this.gbInheritance.Controls.Add(this.cbToCarryOver);
      this.gbInheritance.Controls.Add(this.cbOneTimeOnly);
      this.gbInheritance.Controls.Add(this.cbToInherit);
      this.gbInheritance.Controls.Add(this.lblPercent);
      this.gbInheritance.Controls.Add(this.cbEndofGame);
      this.gbInheritance.Controls.Add(this.cbSkipScore);
      this.gbInheritance.Controls.Add(this.cbTimerInherit);
      this.gbInheritance.Controls.Add(this.nudCarryOverCap);
      this.gbInheritance.Controls.Add(this.lblCarryOverCap);
      this.gbInheritance.Controls.Add(this.lblCarryOverMoney);
      this.gbInheritance.Controls.Add(this.nudPercent);
      this.gbInheritance.Location = new System.Drawing.Point(183, 204);
      this.gbInheritance.Name = "gbInheritance";
      this.gbInheritance.Size = new System.Drawing.Size(306, 237);
      this.gbInheritance.TabIndex = 51;
      this.gbInheritance.TabStop = false;
      this.gbInheritance.Text = "Inheritance and Progression";
      // 
      // nudCarryOverCap
      // 
      this.nudCarryOverCap.Location = new System.Drawing.Point(131, 160);
      this.nudCarryOverCap.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
      this.nudCarryOverCap.Name = "nudCarryOverCap";
      this.nudCarryOverCap.Size = new System.Drawing.Size(60, 20);
      this.nudCarryOverCap.TabIndex = 19;
      this.nudCarryOverCap.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
      this.nudCarryOverCap.ValueChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblCarryOverCap
      // 
      this.lblCarryOverCap.AutoSize = true;
      this.lblCarryOverCap.Location = new System.Drawing.Point(34, 162);
      this.lblCarryOverCap.Name = "lblCarryOverCap";
      this.lblCarryOverCap.Size = new System.Drawing.Size(79, 13);
      this.lblCarryOverCap.TabIndex = 37;
      this.lblCarryOverCap.Text = "Carry Over Cap";
      // 
      // lblCarryOverMoney
      // 
      this.lblCarryOverMoney.AutoSize = true;
      this.lblCarryOverMoney.Location = new System.Drawing.Point(22, 136);
      this.lblCarryOverMoney.Name = "lblCarryOverMoney";
      this.lblCarryOverMoney.Size = new System.Drawing.Size(92, 13);
      this.lblCarryOverMoney.TabIndex = 36;
      this.lblCarryOverMoney.Text = "Carry Over Money";
      // 
      // nudPercent
      // 
      this.nudPercent.Location = new System.Drawing.Point(131, 186);
      this.nudPercent.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.nudPercent.Name = "nudPercent";
      this.nudPercent.Size = new System.Drawing.Size(60, 20);
      this.nudPercent.TabIndex = 18;
      this.nudPercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudPercent.ValueChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblBriefing
      // 
      this.lblBriefing.AutoSize = true;
      this.lblBriefing.Location = new System.Drawing.Point(501, 230);
      this.lblBriefing.Name = "lblBriefing";
      this.lblBriefing.Size = new System.Drawing.Size(42, 13);
      this.lblBriefing.TabIndex = 53;
      this.lblBriefing.Text = "Briefing";
      // 
      // gbIran
      // 
      this.gbIran.Controls.Add(this.cbUseCustomTutorialText);
      this.gbIran.Controls.Add(this.lblMapSelectC);
      this.gbIran.Controls.Add(this.lblMapSelectB);
      this.gbIran.Controls.Add(this.tbMapSelectC);
      this.gbIran.Controls.Add(this.tbMapSelectB);
      this.gbIran.Controls.Add(this.tbMapSelectA);
      this.gbIran.Controls.Add(this.lblMapSelectA);
      this.gbIran.Controls.Add(this.tbMapSelectAnimation);
      this.gbIran.Controls.Add(this.tbNextMission);
      this.gbIran.Controls.Add(this.lblMapSelectAnimation);
      this.gbIran.Controls.Add(this.lblNextMission);
      this.gbIran.Controls.Add(this.lblScenarioNumber);
      this.gbIran.Controls.Add(this.nudScenarioNumber);
      this.gbIran.Location = new System.Drawing.Point(495, 24);
      this.gbIran.Name = "gbIran";
      this.gbIran.Size = new System.Drawing.Size(297, 203);
      this.gbIran.TabIndex = 48;
      this.gbIran.TabStop = false;
      this.gbIran.Text = "Iran\'s INI Overrides";
      // 
      // cbUseCustomTutorialText
      // 
      this.cbUseCustomTutorialText.AutoSize = true;
      this.cbUseCustomTutorialText.Location = new System.Drawing.Point(16, 176);
      this.cbUseCustomTutorialText.Name = "cbUseCustomTutorialText";
      this.cbUseCustomTutorialText.Size = new System.Drawing.Size(145, 17);
      this.cbUseCustomTutorialText.TabIndex = 48;
      this.cbUseCustomTutorialText.Text = "Use Custom Tutorial Text";
      this.cbUseCustomTutorialText.UseVisualStyleBackColor = true;
      this.cbUseCustomTutorialText.CheckedChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblMapSelectC
      // 
      this.lblMapSelectC.AutoSize = true;
      this.lblMapSelectC.Location = new System.Drawing.Point(6, 153);
      this.lblMapSelectC.Name = "lblMapSelectC";
      this.lblMapSelectC.Size = new System.Drawing.Size(109, 13);
      this.lblMapSelectC.TabIndex = 35;
      this.lblMapSelectC.Text = "Map Select Mission C";
      // 
      // lblMapSelectB
      // 
      this.lblMapSelectB.AutoSize = true;
      this.lblMapSelectB.Location = new System.Drawing.Point(6, 127);
      this.lblMapSelectB.Name = "lblMapSelectB";
      this.lblMapSelectB.Size = new System.Drawing.Size(109, 13);
      this.lblMapSelectB.TabIndex = 34;
      this.lblMapSelectB.Text = "Map Select Mission B";
      // 
      // tbMapSelectC
      // 
      this.tbMapSelectC.Location = new System.Drawing.Point(151, 150);
      this.tbMapSelectC.Name = "tbMapSelectC";
      this.tbMapSelectC.Size = new System.Drawing.Size(134, 20);
      this.tbMapSelectC.TabIndex = 33;
      this.tbMapSelectC.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // tbMapSelectB
      // 
      this.tbMapSelectB.Location = new System.Drawing.Point(151, 124);
      this.tbMapSelectB.Name = "tbMapSelectB";
      this.tbMapSelectB.Size = new System.Drawing.Size(134, 20);
      this.tbMapSelectB.TabIndex = 32;
      this.tbMapSelectB.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // tbMapSelectA
      // 
      this.tbMapSelectA.Location = new System.Drawing.Point(151, 98);
      this.tbMapSelectA.Name = "tbMapSelectA";
      this.tbMapSelectA.Size = new System.Drawing.Size(134, 20);
      this.tbMapSelectA.TabIndex = 31;
      this.tbMapSelectA.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblMapSelectA
      // 
      this.lblMapSelectA.AutoSize = true;
      this.lblMapSelectA.Location = new System.Drawing.Point(6, 101);
      this.lblMapSelectA.Name = "lblMapSelectA";
      this.lblMapSelectA.Size = new System.Drawing.Size(109, 13);
      this.lblMapSelectA.TabIndex = 30;
      this.lblMapSelectA.Text = "Map Select Mission A";
      // 
      // tbMapSelectAnimation
      // 
      this.tbMapSelectAnimation.Location = new System.Drawing.Point(151, 72);
      this.tbMapSelectAnimation.Name = "tbMapSelectAnimation";
      this.tbMapSelectAnimation.Size = new System.Drawing.Size(134, 20);
      this.tbMapSelectAnimation.TabIndex = 29;
      this.tbMapSelectAnimation.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // tbNextMission
      // 
      this.tbNextMission.Location = new System.Drawing.Point(151, 19);
      this.tbNextMission.Name = "tbNextMission";
      this.tbNextMission.Size = new System.Drawing.Size(134, 20);
      this.tbNextMission.TabIndex = 28;
      this.tbNextMission.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblMapSelectAnimation
      // 
      this.lblMapSelectAnimation.AutoSize = true;
      this.lblMapSelectAnimation.Location = new System.Drawing.Point(6, 76);
      this.lblMapSelectAnimation.Name = "lblMapSelectAnimation";
      this.lblMapSelectAnimation.Size = new System.Drawing.Size(110, 13);
      this.lblMapSelectAnimation.TabIndex = 4;
      this.lblMapSelectAnimation.Text = "Map Select Animation";
      // 
      // lblNextMission
      // 
      this.lblNextMission.AutoSize = true;
      this.lblNextMission.Location = new System.Drawing.Point(6, 22);
      this.lblNextMission.Name = "lblNextMission";
      this.lblNextMission.Size = new System.Drawing.Size(67, 13);
      this.lblNextMission.TabIndex = 2;
      this.lblNextMission.Text = "Next Mission";
      // 
      // lblScenarioNumber
      // 
      this.lblScenarioNumber.AutoSize = true;
      this.lblScenarioNumber.Location = new System.Drawing.Point(6, 49);
      this.lblScenarioNumber.Name = "lblScenarioNumber";
      this.lblScenarioNumber.Size = new System.Drawing.Size(86, 13);
      this.lblScenarioNumber.TabIndex = 3;
      this.lblScenarioNumber.Text = "ScenarioNumber";
      // 
      // nudScenarioNumber
      // 
      this.nudScenarioNumber.Location = new System.Drawing.Point(151, 46);
      this.nudScenarioNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudScenarioNumber.Name = "nudScenarioNumber";
      this.nudScenarioNumber.Size = new System.Drawing.Size(60, 20);
      this.nudScenarioNumber.TabIndex = 26;
      this.nudScenarioNumber.ValueChanged += new System.EventHandler(this.Value_Changed);
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(3, 446);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.Size = new System.Drawing.Size(598, 63);
      this.tbHint.TabIndex = 46;
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(607, 477);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 45;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(705, 477);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 44;
      this.bCancel.Text = "Revert";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(6, 21);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(35, 13);
      this.lblName.TabIndex = 28;
      this.lblName.Text = "Name";
      // 
      // cbTheme
      // 
      this.cbTheme.FormattingEnabled = true;
      this.cbTheme.Location = new System.Drawing.Point(105, 98);
      this.cbTheme.Name = "cbTheme";
      this.cbTheme.Size = new System.Drawing.Size(121, 21);
      this.cbTheme.TabIndex = 19;
      this.cbTheme.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // gbGeneral
      // 
      this.gbGeneral.Controls.Add(this.cbTruckCrate);
      this.gbGeneral.Controls.Add(this.cbFillSilos);
      this.gbGeneral.Controls.Add(this.cbOfficial);
      this.gbGeneral.Controls.Add(this.cbNoSpyPlane);
      this.gbGeneral.Controls.Add(this.cbCivEvac);
      this.gbGeneral.Controls.Add(this.cbTheme);
      this.gbGeneral.Controls.Add(this.lblNewIniFormat);
      this.gbGeneral.Controls.Add(this.cbPlayer);
      this.gbGeneral.Controls.Add(this.lblPlayer);
      this.gbGeneral.Controls.Add(this.lblTheme);
      this.gbGeneral.Controls.Add(this.cbNewIniFormat);
      this.gbGeneral.Controls.Add(this.lblName);
      this.gbGeneral.Controls.Add(this.tbName);
      this.gbGeneral.Location = new System.Drawing.Point(3, 3);
      this.gbGeneral.Name = "gbGeneral";
      this.gbGeneral.Size = new System.Drawing.Size(486, 195);
      this.gbGeneral.TabIndex = 49;
      this.gbGeneral.TabStop = false;
      this.gbGeneral.Text = "General";
      // 
      // cbTruckCrate
      // 
      this.cbTruckCrate.AutoSize = true;
      this.cbTruckCrate.Location = new System.Drawing.Point(233, 171);
      this.cbTruckCrate.Name = "cbTruckCrate";
      this.cbTruckCrate.Size = new System.Drawing.Size(126, 17);
      this.cbTruckCrate.TabIndex = 51;
      this.cbTruckCrate.Text = "Truck Contains Crate";
      this.cbTruckCrate.UseVisualStyleBackColor = true;
      this.cbTruckCrate.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbFillSilos
      // 
      this.cbFillSilos.AutoSize = true;
      this.cbFillSilos.Location = new System.Drawing.Point(233, 148);
      this.cbFillSilos.Name = "cbFillSilos";
      this.cbFillSilos.Size = new System.Drawing.Size(83, 17);
      this.cbFillSilos.TabIndex = 50;
      this.cbFillSilos.Text = "Fill Ore Silos";
      this.cbFillSilos.UseVisualStyleBackColor = true;
      this.cbFillSilos.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbOfficial
      // 
      this.cbOfficial.AutoSize = true;
      this.cbOfficial.Location = new System.Drawing.Point(105, 125);
      this.cbOfficial.Name = "cbOfficial";
      this.cbOfficial.Size = new System.Drawing.Size(58, 17);
      this.cbOfficial.TabIndex = 48;
      this.cbOfficial.Text = "Official";
      this.cbOfficial.UseVisualStyleBackColor = true;
      this.cbOfficial.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbNoSpyPlane
      // 
      this.cbNoSpyPlane.AutoSize = true;
      this.cbNoSpyPlane.Location = new System.Drawing.Point(233, 125);
      this.cbNoSpyPlane.Name = "cbNoSpyPlane";
      this.cbNoSpyPlane.Size = new System.Drawing.Size(91, 17);
      this.cbNoSpyPlane.TabIndex = 45;
      this.cbNoSpyPlane.Text = "No Spy Plane";
      this.cbNoSpyPlane.UseVisualStyleBackColor = true;
      this.cbNoSpyPlane.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbCivEvac
      // 
      this.cbCivEvac.AutoSize = true;
      this.cbCivEvac.Location = new System.Drawing.Point(105, 148);
      this.cbCivEvac.Name = "cbCivEvac";
      this.cbCivEvac.Size = new System.Drawing.Size(69, 17);
      this.cbCivEvac.TabIndex = 44;
      this.cbCivEvac.Text = "Civ Evac";
      this.cbCivEvac.UseVisualStyleBackColor = true;
      this.cbCivEvac.CheckStateChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblNewIniFormat
      // 
      this.lblNewIniFormat.AutoSize = true;
      this.lblNewIniFormat.Location = new System.Drawing.Point(6, 47);
      this.lblNewIniFormat.Name = "lblNewIniFormat";
      this.lblNewIniFormat.Size = new System.Drawing.Size(72, 13);
      this.lblNewIniFormat.TabIndex = 35;
      this.lblNewIniFormat.Text = "NewIniFormat";
      // 
      // cbPlayer
      // 
      this.cbPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPlayer.FormattingEnabled = true;
      this.cbPlayer.Location = new System.Drawing.Point(105, 71);
      this.cbPlayer.Name = "cbPlayer";
      this.cbPlayer.Size = new System.Drawing.Size(121, 21);
      this.cbPlayer.TabIndex = 34;
      this.cbPlayer.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblPlayer
      // 
      this.lblPlayer.AutoSize = true;
      this.lblPlayer.Location = new System.Drawing.Point(6, 74);
      this.lblPlayer.Name = "lblPlayer";
      this.lblPlayer.Size = new System.Drawing.Size(36, 13);
      this.lblPlayer.TabIndex = 33;
      this.lblPlayer.Text = "Player";
      // 
      // lblTheme
      // 
      this.lblTheme.AutoSize = true;
      this.lblTheme.Location = new System.Drawing.Point(6, 101);
      this.lblTheme.Name = "lblTheme";
      this.lblTheme.Size = new System.Drawing.Size(40, 13);
      this.lblTheme.TabIndex = 32;
      this.lblTheme.Text = "Theme";
      // 
      // cbNewIniFormat
      // 
      this.cbNewIniFormat.Enabled = false;
      this.cbNewIniFormat.FormattingEnabled = true;
      this.cbNewIniFormat.Location = new System.Drawing.Point(105, 44);
      this.cbNewIniFormat.Name = "cbNewIniFormat";
      this.cbNewIniFormat.Size = new System.Drawing.Size(121, 21);
      this.cbNewIniFormat.TabIndex = 29;
      this.cbNewIniFormat.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      // 
      // cbEnableIranOverrides
      // 
      this.cbEnableIranOverrides.AutoSize = true;
      this.cbEnableIranOverrides.Location = new System.Drawing.Point(504, 3);
      this.cbEnableIranOverrides.Name = "cbEnableIranOverrides";
      this.cbEnableIranOverrides.Size = new System.Drawing.Size(152, 17);
      this.cbEnableIranOverrides.TabIndex = 47;
      this.cbEnableIranOverrides.Text = "Enable Iran\'s INI Overrides";
      this.cbEnableIranOverrides.UseVisualStyleBackColor = true;
      this.cbEnableIranOverrides.CheckedChanged += new System.EventHandler(this.cbEnableIranOverrides_CheckedChanged);
      // 
      // BasicControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.tbBriefing);
      this.Controls.Add(this.gbInheritance);
      this.Controls.Add(this.lblBriefing);
      this.Controls.Add(this.gbIran);
      this.Controls.Add(this.tbHint);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.gbGeneral);
      this.Controls.Add(this.cbEnableIranOverrides);
      this.Name = "BasicControl";
      this.Size = new System.Drawing.Size(800, 512);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCarryOverMoney)).EndInit();
      this.gbInheritance.ResumeLayout(false);
      this.gbInheritance.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCarryOverCap)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPercent)).EndInit();
      this.gbIran.ResumeLayout(false);
      this.gbIran.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudScenarioNumber)).EndInit();
      this.gbGeneral.ResumeLayout(false);
      this.gbGeneral.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.CheckBox cbTimerInherit;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox cbAction;
    private System.Windows.Forms.ComboBox cbLose;
    private System.Windows.Forms.ComboBox cbWin4;
    private System.Windows.Forms.ComboBox cbWin3;
    private System.Windows.Forms.ComboBox cbWin2;
    private System.Windows.Forms.ComboBox cbWin;
    private System.Windows.Forms.ComboBox cbBrief;
    private System.Windows.Forms.ComboBox cbIntro;
    private System.Windows.Forms.Label lblWin4;
    private System.Windows.Forms.Label lblWin3;
    private System.Windows.Forms.Label lblWin2;
    private System.Windows.Forms.Label lblIntro;
    private System.Windows.Forms.Label lblBrief;
    private System.Windows.Forms.Label lblAction;
    private System.Windows.Forms.Label lblWin;
    private System.Windows.Forms.Label lblLose;
    private System.Windows.Forms.TextBox tbBriefing;
    private System.Windows.Forms.NumericUpDown nudCarryOverMoney;
    private System.Windows.Forms.CheckBox cbSkipMapSelect;
    private System.Windows.Forms.CheckBox cbToCarryOver;
    private System.Windows.Forms.CheckBox cbOneTimeOnly;
    private System.Windows.Forms.CheckBox cbToInherit;
    private System.Windows.Forms.Label lblPercent;
    private System.Windows.Forms.CheckBox cbEndofGame;
    private System.Windows.Forms.CheckBox cbSkipScore;
    private System.Windows.Forms.GroupBox gbInheritance;
    private System.Windows.Forms.NumericUpDown nudCarryOverCap;
    private System.Windows.Forms.Label lblCarryOverCap;
    private System.Windows.Forms.Label lblCarryOverMoney;
    private System.Windows.Forms.NumericUpDown nudPercent;
    private System.Windows.Forms.Label lblBriefing;
    private System.Windows.Forms.GroupBox gbIran;
    private System.Windows.Forms.Label lblMapSelectC;
    private System.Windows.Forms.Label lblMapSelectB;
    private System.Windows.Forms.TextBox tbMapSelectC;
    private System.Windows.Forms.TextBox tbMapSelectB;
    private System.Windows.Forms.TextBox tbMapSelectA;
    private System.Windows.Forms.Label lblMapSelectA;
    private System.Windows.Forms.TextBox tbMapSelectAnimation;
    private System.Windows.Forms.TextBox tbNextMission;
    private System.Windows.Forms.Label lblMapSelectAnimation;
    private System.Windows.Forms.Label lblNextMission;
    private System.Windows.Forms.Label lblScenarioNumber;
    private System.Windows.Forms.NumericUpDown nudScenarioNumber;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.ComboBox cbTheme;
    private System.Windows.Forms.GroupBox gbGeneral;
    private System.Windows.Forms.CheckBox cbTruckCrate;
    private System.Windows.Forms.CheckBox cbFillSilos;
    private System.Windows.Forms.CheckBox cbOfficial;
    private System.Windows.Forms.CheckBox cbNoSpyPlane;
    private System.Windows.Forms.CheckBox cbCivEvac;
    private System.Windows.Forms.Label lblNewIniFormat;
    private System.Windows.Forms.ComboBox cbPlayer;
    private System.Windows.Forms.Label lblPlayer;
    private System.Windows.Forms.Label lblTheme;
    private System.Windows.Forms.ComboBox cbNewIniFormat;
    private System.Windows.Forms.CheckBox cbEnableIranOverrides;
    private System.Windows.Forms.CheckBox cbUseCustomTutorialText;
  }
}
