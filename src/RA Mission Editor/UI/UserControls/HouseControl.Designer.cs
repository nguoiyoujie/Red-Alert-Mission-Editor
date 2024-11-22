
namespace RA_Mission_Editor.UI.UserControls
{
  partial class HouseControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HouseControl));
      this.lblColor = new System.Windows.Forms.Label();
      this.lblSecondaryColor = new System.Windows.Forms.Label();
      this.lblCountry = new System.Windows.Forms.Label();
      this.lblGroundSpeed = new System.Windows.Forms.Label();
      this.cbNoBuildingCrew = new System.Windows.Forms.CheckBox();
      this.cbBuildingsInstantCapture = new System.Windows.Forms.CheckBox();
      this.cbEnableIranOverrides = new System.Windows.Forms.CheckBox();
      this.lblBuildTime = new System.Windows.Forms.Label();
      this.lblFirepower = new System.Windows.Forms.Label();
      this.lblCost = new System.Windows.Forms.Label();
      this.lblROF = new System.Windows.Forms.Label();
      this.lblAirSpeed = new System.Windows.Forms.Label();
      this.lblArmor = new System.Windows.Forms.Label();
      this.gbMultipliers = new System.Windows.Forms.GroupBox();
      this.nudBuildTime = new System.Windows.Forms.NumericUpDown();
      this.nudCost = new System.Windows.Forms.NumericUpDown();
      this.nudROF = new System.Windows.Forms.NumericUpDown();
      this.nudArmor = new System.Windows.Forms.NumericUpDown();
      this.nudAirSpeed = new System.Windows.Forms.NumericUpDown();
      this.nudGroundSpeed = new System.Windows.Forms.NumericUpDown();
      this.nudFirepower = new System.Windows.Forms.NumericUpDown();
      this.gbIran = new System.Windows.Forms.GroupBox();
      this.cbCountry = new System.Windows.Forms.ComboBox();
      this.cbSecondaryColor = new System.Windows.Forms.ComboBox();
      this.cbColor = new System.Windows.Forms.ComboBox();
      this.nudTechLevel = new System.Windows.Forms.NumericUpDown();
      this.nudCredits = new System.Windows.Forms.NumericUpDown();
      this.lblTechLevel = new System.Windows.Forms.Label();
      this.lblCredits = new System.Windows.Forms.Label();
      this.lblIQ = new System.Windows.Forms.Label();
      this.cbPlayerControl = new System.Windows.Forms.CheckBox();
      this.nudIQ = new System.Windows.Forms.NumericUpDown();
      this.gbAllies = new System.Windows.Forms.GroupBox();
      this.gbGeneral = new System.Windows.Forms.GroupBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.nudMaxVessels = new System.Windows.Forms.NumericUpDown();
      this.nudMaxUnits = new System.Windows.Forms.NumericUpDown();
      this.nudMaxInfantry = new System.Windows.Forms.NumericUpDown();
      this.nudMaxBuildings = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.gbMultipliers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudBuildTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudROF)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudArmor)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAirSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGroundSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFirepower)).BeginInit();
      this.gbIran.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechLevel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIQ)).BeginInit();
      this.gbGeneral.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxVessels)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxUnits)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxInfantry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxBuildings)).BeginInit();
      this.SuspendLayout();
      // 
      // lblColor
      // 
      this.lblColor.AutoSize = true;
      this.lblColor.Location = new System.Drawing.Point(6, 22);
      this.lblColor.Name = "lblColor";
      this.lblColor.Size = new System.Drawing.Size(54, 20);
      this.lblColor.TabIndex = 2;
      this.lblColor.Text = "Color";
      // 
      // lblSecondaryColor
      // 
      this.lblSecondaryColor.AutoSize = true;
      this.lblSecondaryColor.Location = new System.Drawing.Point(6, 49);
      this.lblSecondaryColor.Name = "lblSecondaryColor";
      this.lblSecondaryColor.Size = new System.Drawing.Size(144, 20);
      this.lblSecondaryColor.TabIndex = 3;
      this.lblSecondaryColor.Text = "Secondary Color";
      // 
      // lblCountry
      // 
      this.lblCountry.AutoSize = true;
      this.lblCountry.Location = new System.Drawing.Point(6, 76);
      this.lblCountry.Name = "lblCountry";
      this.lblCountry.Size = new System.Drawing.Size(135, 20);
      this.lblCountry.TabIndex = 4;
      this.lblCountry.Text = "Act as Country";
      // 
      // lblGroundSpeed
      // 
      this.lblGroundSpeed.AutoSize = true;
      this.lblGroundSpeed.Location = new System.Drawing.Point(6, 47);
      this.lblGroundSpeed.Name = "lblGroundSpeed";
      this.lblGroundSpeed.Size = new System.Drawing.Size(117, 20);
      this.lblGroundSpeed.TabIndex = 5;
      this.lblGroundSpeed.Text = "Ground Speed";
      // 
      // cbNoBuildingCrew
      // 
      this.cbNoBuildingCrew.AutoSize = true;
      this.cbNoBuildingCrew.Location = new System.Drawing.Point(9, 123);
      this.cbNoBuildingCrew.Name = "cbNoBuildingCrew";
      this.cbNoBuildingCrew.Size = new System.Drawing.Size(179, 24);
      this.cbNoBuildingCrew.TabIndex = 7;
      this.cbNoBuildingCrew.Text = "No Building Crew";
      this.cbNoBuildingCrew.UseVisualStyleBackColor = true;
      this.cbNoBuildingCrew.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbNoBuildingCrew.MouseEnter += new System.EventHandler(this.cbNoBuildingCrew_MouseEnter);
      // 
      // cbBuildingsInstantCapture
      // 
      this.cbBuildingsInstantCapture.AutoSize = true;
      this.cbBuildingsInstantCapture.Location = new System.Drawing.Point(9, 100);
      this.cbBuildingsInstantCapture.Name = "cbBuildingsInstantCapture";
      this.cbBuildingsInstantCapture.Size = new System.Drawing.Size(323, 24);
      this.cbBuildingsInstantCapture.TabIndex = 8;
      this.cbBuildingsInstantCapture.Text = "Buildings Get Instantly Captured";
      this.cbBuildingsInstantCapture.UseVisualStyleBackColor = true;
      this.cbBuildingsInstantCapture.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbBuildingsInstantCapture.MouseEnter += new System.EventHandler(this.cbBuildingsInstantCapture_MouseEnter);
      // 
      // cbEnableIranOverrides
      // 
      this.cbEnableIranOverrides.AutoSize = true;
      this.cbEnableIranOverrides.Location = new System.Drawing.Point(9, 127);
      this.cbEnableIranOverrides.Name = "cbEnableIranOverrides";
      this.cbEnableIranOverrides.Size = new System.Drawing.Size(278, 24);
      this.cbEnableIranOverrides.TabIndex = 9;
      this.cbEnableIranOverrides.Text = "Enable Iran\'s INI Overrides";
      this.cbEnableIranOverrides.UseVisualStyleBackColor = true;
      this.cbEnableIranOverrides.CheckedChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblBuildTime
      // 
      this.lblBuildTime.AutoSize = true;
      this.lblBuildTime.Location = new System.Drawing.Point(6, 176);
      this.lblBuildTime.Name = "lblBuildTime";
      this.lblBuildTime.Size = new System.Drawing.Size(99, 20);
      this.lblBuildTime.TabIndex = 10;
      this.lblBuildTime.Text = "Build Time";
      // 
      // lblFirepower
      // 
      this.lblFirepower.AutoSize = true;
      this.lblFirepower.Location = new System.Drawing.Point(6, 21);
      this.lblFirepower.Name = "lblFirepower";
      this.lblFirepower.Size = new System.Drawing.Size(90, 20);
      this.lblFirepower.TabIndex = 11;
      this.lblFirepower.Text = "Firepower";
      // 
      // lblCost
      // 
      this.lblCost.AutoSize = true;
      this.lblCost.Location = new System.Drawing.Point(7, 151);
      this.lblCost.Name = "lblCost";
      this.lblCost.Size = new System.Drawing.Size(45, 20);
      this.lblCost.TabIndex = 12;
      this.lblCost.Text = "Cost";
      // 
      // lblROF
      // 
      this.lblROF.AutoSize = true;
      this.lblROF.Location = new System.Drawing.Point(6, 125);
      this.lblROF.Name = "lblROF";
      this.lblROF.Size = new System.Drawing.Size(117, 20);
      this.lblROF.TabIndex = 13;
      this.lblROF.Text = "Rate of Fire";
      // 
      // lblAirSpeed
      // 
      this.lblAirSpeed.AutoSize = true;
      this.lblAirSpeed.Location = new System.Drawing.Point(7, 73);
      this.lblAirSpeed.Name = "lblAirSpeed";
      this.lblAirSpeed.Size = new System.Drawing.Size(90, 20);
      this.lblAirSpeed.TabIndex = 14;
      this.lblAirSpeed.Text = "Air Speed";
      // 
      // lblArmor
      // 
      this.lblArmor.AutoSize = true;
      this.lblArmor.Location = new System.Drawing.Point(7, 99);
      this.lblArmor.Name = "lblArmor";
      this.lblArmor.Size = new System.Drawing.Size(117, 20);
      this.lblArmor.TabIndex = 15;
      this.lblArmor.Text = "Damage Taken";
      // 
      // gbMultipliers
      // 
      this.gbMultipliers.Controls.Add(this.nudBuildTime);
      this.gbMultipliers.Controls.Add(this.nudCost);
      this.gbMultipliers.Controls.Add(this.nudROF);
      this.gbMultipliers.Controls.Add(this.nudArmor);
      this.gbMultipliers.Controls.Add(this.nudAirSpeed);
      this.gbMultipliers.Controls.Add(this.nudGroundSpeed);
      this.gbMultipliers.Controls.Add(this.nudFirepower);
      this.gbMultipliers.Controls.Add(this.lblGroundSpeed);
      this.gbMultipliers.Controls.Add(this.lblROF);
      this.gbMultipliers.Controls.Add(this.lblAirSpeed);
      this.gbMultipliers.Controls.Add(this.lblBuildTime);
      this.gbMultipliers.Controls.Add(this.lblArmor);
      this.gbMultipliers.Controls.Add(this.lblFirepower);
      this.gbMultipliers.Controls.Add(this.lblCost);
      this.gbMultipliers.Location = new System.Drawing.Point(250, 3);
      this.gbMultipliers.Name = "gbMultipliers";
      this.gbMultipliers.Size = new System.Drawing.Size(176, 200);
      this.gbMultipliers.TabIndex = 16;
      this.gbMultipliers.TabStop = false;
      this.gbMultipliers.Text = "Multipliers";
      // 
      // nudBuildTime
      // 
      this.nudBuildTime.DecimalPlaces = 2;
      this.nudBuildTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudBuildTime.Location = new System.Drawing.Point(105, 174);
      this.nudBuildTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudBuildTime.Name = "nudBuildTime";
      this.nudBuildTime.Size = new System.Drawing.Size(60, 27);
      this.nudBuildTime.TabIndex = 22;
      this.nudBuildTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudBuildTime.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudBuildTime.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudCost
      // 
      this.nudCost.DecimalPlaces = 2;
      this.nudCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudCost.Location = new System.Drawing.Point(105, 149);
      this.nudCost.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudCost.Name = "nudCost";
      this.nudCost.Size = new System.Drawing.Size(60, 27);
      this.nudCost.TabIndex = 21;
      this.nudCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCost.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudCost.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudROF
      // 
      this.nudROF.DecimalPlaces = 2;
      this.nudROF.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudROF.Location = new System.Drawing.Point(105, 123);
      this.nudROF.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudROF.Name = "nudROF";
      this.nudROF.Size = new System.Drawing.Size(60, 27);
      this.nudROF.TabIndex = 20;
      this.nudROF.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudROF.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudROF.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudArmor
      // 
      this.nudArmor.DecimalPlaces = 2;
      this.nudArmor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudArmor.Location = new System.Drawing.Point(105, 97);
      this.nudArmor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudArmor.Name = "nudArmor";
      this.nudArmor.Size = new System.Drawing.Size(60, 27);
      this.nudArmor.TabIndex = 19;
      this.nudArmor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudArmor.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudArmor.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudAirSpeed
      // 
      this.nudAirSpeed.DecimalPlaces = 2;
      this.nudAirSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudAirSpeed.Location = new System.Drawing.Point(105, 71);
      this.nudAirSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudAirSpeed.Name = "nudAirSpeed";
      this.nudAirSpeed.Size = new System.Drawing.Size(60, 27);
      this.nudAirSpeed.TabIndex = 18;
      this.nudAirSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudAirSpeed.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudAirSpeed.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudGroundSpeed
      // 
      this.nudGroundSpeed.DecimalPlaces = 2;
      this.nudGroundSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudGroundSpeed.Location = new System.Drawing.Point(105, 45);
      this.nudGroundSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudGroundSpeed.Name = "nudGroundSpeed";
      this.nudGroundSpeed.Size = new System.Drawing.Size(60, 27);
      this.nudGroundSpeed.TabIndex = 17;
      this.nudGroundSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudGroundSpeed.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudGroundSpeed.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // nudFirepower
      // 
      this.nudFirepower.DecimalPlaces = 2;
      this.nudFirepower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudFirepower.Location = new System.Drawing.Point(105, 19);
      this.nudFirepower.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudFirepower.Name = "nudFirepower";
      this.nudFirepower.Size = new System.Drawing.Size(60, 27);
      this.nudFirepower.TabIndex = 16;
      this.nudFirepower.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFirepower.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudFirepower.MouseEnter += new System.EventHandler(this.nudMultipliers_MouseEnter);
      // 
      // gbIran
      // 
      this.gbIran.Controls.Add(this.cbCountry);
      this.gbIran.Controls.Add(this.cbSecondaryColor);
      this.gbIran.Controls.Add(this.cbColor);
      this.gbIran.Controls.Add(this.cbNoBuildingCrew);
      this.gbIran.Controls.Add(this.cbBuildingsInstantCapture);
      this.gbIran.Controls.Add(this.lblCountry);
      this.gbIran.Controls.Add(this.lblColor);
      this.gbIran.Controls.Add(this.lblSecondaryColor);
      this.gbIran.Location = new System.Drawing.Point(3, 150);
      this.gbIran.Name = "gbIran";
      this.gbIran.Size = new System.Drawing.Size(236, 145);
      this.gbIran.TabIndex = 17;
      this.gbIran.TabStop = false;
      this.gbIran.Text = "Iran\'s INI Overrides";
      // 
      // cbCountry
      // 
      this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCountry.FormattingEnabled = true;
      this.cbCountry.Location = new System.Drawing.Point(109, 73);
      this.cbCountry.Name = "cbCountry";
      this.cbCountry.Size = new System.Drawing.Size(121, 28);
      this.cbCountry.TabIndex = 20;
      this.cbCountry.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbCountry.TextChanged += new System.EventHandler(this.Value_Changed);
      this.cbCountry.MouseEnter += new System.EventHandler(this.cbCountry_MouseEnter);
      // 
      // cbSecondaryColor
      // 
      this.cbSecondaryColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSecondaryColor.FormattingEnabled = true;
      this.cbSecondaryColor.Location = new System.Drawing.Point(109, 46);
      this.cbSecondaryColor.Name = "cbSecondaryColor";
      this.cbSecondaryColor.Size = new System.Drawing.Size(121, 28);
      this.cbSecondaryColor.TabIndex = 19;
      this.cbSecondaryColor.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbSecondaryColor.TextChanged += new System.EventHandler(this.Value_Changed);
      this.cbSecondaryColor.MouseEnter += new System.EventHandler(this.cbSecondaryColor_MouseEnter);
      // 
      // cbColor
      // 
      this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbColor.FormattingEnabled = true;
      this.cbColor.Location = new System.Drawing.Point(109, 19);
      this.cbColor.Name = "cbColor";
      this.cbColor.Size = new System.Drawing.Size(121, 28);
      this.cbColor.TabIndex = 18;
      this.cbColor.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbColor.TextChanged += new System.EventHandler(this.Value_Changed);
      this.cbColor.MouseEnter += new System.EventHandler(this.cbColor_MouseEnter);
      // 
      // nudTechLevel
      // 
      this.nudTechLevel.Location = new System.Drawing.Point(128, 19);
      this.nudTechLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.nudTechLevel.Name = "nudTechLevel";
      this.nudTechLevel.Size = new System.Drawing.Size(60, 27);
      this.nudTechLevel.TabIndex = 18;
      this.nudTechLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudTechLevel.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudTechLevel.MouseEnter += new System.EventHandler(this.nudTechLevel_MouseEnter);
      // 
      // nudCredits
      // 
      this.nudCredits.Location = new System.Drawing.Point(128, 71);
      this.nudCredits.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.nudCredits.Name = "nudCredits";
      this.nudCredits.Size = new System.Drawing.Size(60, 27);
      this.nudCredits.TabIndex = 19;
      this.nudCredits.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
      this.nudCredits.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudCredits.MouseEnter += new System.EventHandler(this.nudCredits_MouseEnter);
      // 
      // lblTechLevel
      // 
      this.lblTechLevel.AutoSize = true;
      this.lblTechLevel.Location = new System.Drawing.Point(6, 21);
      this.lblTechLevel.Name = "lblTechLevel";
      this.lblTechLevel.Size = new System.Drawing.Size(90, 20);
      this.lblTechLevel.TabIndex = 20;
      this.lblTechLevel.Text = "TechLevel";
      // 
      // lblCredits
      // 
      this.lblCredits.AutoSize = true;
      this.lblCredits.Location = new System.Drawing.Point(6, 73);
      this.lblCredits.Name = "lblCredits";
      this.lblCredits.Size = new System.Drawing.Size(135, 20);
      this.lblCredits.TabIndex = 23;
      this.lblCredits.Text = "Credits (x100)";
      // 
      // lblIQ
      // 
      this.lblIQ.AutoSize = true;
      this.lblIQ.Location = new System.Drawing.Point(6, 47);
      this.lblIQ.Name = "lblIQ";
      this.lblIQ.Size = new System.Drawing.Size(27, 20);
      this.lblIQ.TabIndex = 24;
      this.lblIQ.Text = "IQ";
      // 
      // cbPlayerControl
      // 
      this.cbPlayerControl.AutoSize = true;
      this.cbPlayerControl.Location = new System.Drawing.Point(6, 97);
      this.cbPlayerControl.Name = "cbPlayerControl";
      this.cbPlayerControl.Size = new System.Drawing.Size(161, 24);
      this.cbPlayerControl.TabIndex = 25;
      this.cbPlayerControl.Text = "Player Control";
      this.cbPlayerControl.UseVisualStyleBackColor = true;
      this.cbPlayerControl.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbPlayerControl.MouseEnter += new System.EventHandler(this.cbPlayerControl_MouseEnter);
      // 
      // nudIQ
      // 
      this.nudIQ.Location = new System.Drawing.Point(128, 45);
      this.nudIQ.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.nudIQ.Name = "nudIQ";
      this.nudIQ.Size = new System.Drawing.Size(60, 27);
      this.nudIQ.TabIndex = 26;
      this.nudIQ.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudIQ.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudIQ.MouseEnter += new System.EventHandler(this.nudIQ_MouseEnter);
      // 
      // gbAllies
      // 
      this.gbAllies.Location = new System.Drawing.Point(432, 3);
      this.gbAllies.Name = "gbAllies";
      this.gbAllies.Size = new System.Drawing.Size(165, 447);
      this.gbAllies.TabIndex = 27;
      this.gbAllies.TabStop = false;
      this.gbAllies.Text = "Allies";
      // 
      // gbGeneral
      // 
      this.gbGeneral.Controls.Add(this.lblTechLevel);
      this.gbGeneral.Controls.Add(this.lblIQ);
      this.gbGeneral.Controls.Add(this.nudIQ);
      this.gbGeneral.Controls.Add(this.nudCredits);
      this.gbGeneral.Controls.Add(this.lblCredits);
      this.gbGeneral.Controls.Add(this.cbPlayerControl);
      this.gbGeneral.Controls.Add(this.nudTechLevel);
      this.gbGeneral.Location = new System.Drawing.Point(3, 3);
      this.gbGeneral.Name = "gbGeneral";
      this.gbGeneral.Size = new System.Drawing.Size(194, 121);
      this.gbGeneral.TabIndex = 28;
      this.gbGeneral.TabStop = false;
      this.gbGeneral.Text = "General";
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(363, 456);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 50;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(505, 456);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 49;
      this.bCancel.Text = "Revert";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(3, 341);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbHint.Size = new System.Drawing.Size(423, 109);
      this.tbHint.TabIndex = 93;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.nudMaxVessels);
      this.groupBox1.Controls.Add(this.nudMaxUnits);
      this.groupBox1.Controls.Add(this.nudMaxInfantry);
      this.groupBox1.Controls.Add(this.nudMaxBuildings);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Location = new System.Drawing.Point(250, 209);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(176, 126);
      this.groupBox1.TabIndex = 94;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Maximums";
      // 
      // nudMaxVessels
      // 
      this.nudMaxVessels.Location = new System.Drawing.Point(105, 97);
      this.nudMaxVessels.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.nudMaxVessels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.nudMaxVessels.Name = "nudMaxVessels";
      this.nudMaxVessels.Size = new System.Drawing.Size(60, 27);
      this.nudMaxVessels.TabIndex = 19;
      this.nudMaxVessels.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      // 
      // nudMaxUnits
      // 
      this.nudMaxUnits.Location = new System.Drawing.Point(105, 71);
      this.nudMaxUnits.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.nudMaxUnits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.nudMaxUnits.Name = "nudMaxUnits";
      this.nudMaxUnits.Size = new System.Drawing.Size(60, 27);
      this.nudMaxUnits.TabIndex = 18;
      this.nudMaxUnits.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      // 
      // nudMaxInfantry
      // 
      this.nudMaxInfantry.Location = new System.Drawing.Point(105, 45);
      this.nudMaxInfantry.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.nudMaxInfantry.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.nudMaxInfantry.Name = "nudMaxInfantry";
      this.nudMaxInfantry.Size = new System.Drawing.Size(60, 27);
      this.nudMaxInfantry.TabIndex = 17;
      this.nudMaxInfantry.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      // 
      // nudMaxBuildings
      // 
      this.nudMaxBuildings.Location = new System.Drawing.Point(105, 19);
      this.nudMaxBuildings.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.nudMaxBuildings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.nudMaxBuildings.Name = "nudMaxBuildings";
      this.nudMaxBuildings.Size = new System.Drawing.Size(60, 27);
      this.nudMaxBuildings.TabIndex = 16;
      this.nudMaxBuildings.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(117, 20);
      this.label1.TabIndex = 5;
      this.label1.Text = "Max Infantry";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(81, 20);
      this.label3.TabIndex = 14;
      this.label3.Text = "Max Unit";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(7, 99);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(99, 20);
      this.label5.TabIndex = 15;
      this.label5.Text = "Max Vessel";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 21);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(117, 20);
      this.label6.TabIndex = 11;
      this.label6.Text = "Max Building";
      // 
      // HouseControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.tbHint);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.gbGeneral);
      this.Controls.Add(this.gbAllies);
      this.Controls.Add(this.gbIran);
      this.Controls.Add(this.gbMultipliers);
      this.Controls.Add(this.cbEnableIranOverrides);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.Name = "HouseControl";
      this.Size = new System.Drawing.Size(600, 500);
      this.gbMultipliers.ResumeLayout(false);
      this.gbMultipliers.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudBuildTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudROF)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudArmor)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAirSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGroundSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFirepower)).EndInit();
      this.gbIran.ResumeLayout(false);
      this.gbIran.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechLevel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIQ)).EndInit();
      this.gbGeneral.ResumeLayout(false);
      this.gbGeneral.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxVessels)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxUnits)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxInfantry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxBuildings)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblColor;
    private System.Windows.Forms.Label lblSecondaryColor;
    private System.Windows.Forms.Label lblCountry;
    private System.Windows.Forms.Label lblGroundSpeed;
    private System.Windows.Forms.CheckBox cbNoBuildingCrew;
    private System.Windows.Forms.CheckBox cbBuildingsInstantCapture;
    private System.Windows.Forms.CheckBox cbEnableIranOverrides;
    private System.Windows.Forms.Label lblBuildTime;
    private System.Windows.Forms.Label lblFirepower;
    private System.Windows.Forms.Label lblCost;
    private System.Windows.Forms.Label lblROF;
    private System.Windows.Forms.Label lblAirSpeed;
    private System.Windows.Forms.Label lblArmor;
    private System.Windows.Forms.GroupBox gbMultipliers;
    private System.Windows.Forms.NumericUpDown nudBuildTime;
    private System.Windows.Forms.NumericUpDown nudCost;
    private System.Windows.Forms.NumericUpDown nudROF;
    private System.Windows.Forms.NumericUpDown nudArmor;
    private System.Windows.Forms.NumericUpDown nudAirSpeed;
    private System.Windows.Forms.NumericUpDown nudGroundSpeed;
    private System.Windows.Forms.NumericUpDown nudFirepower;
    private System.Windows.Forms.GroupBox gbIran;
    private System.Windows.Forms.ComboBox cbCountry;
    private System.Windows.Forms.ComboBox cbSecondaryColor;
    private System.Windows.Forms.ComboBox cbColor;
    private System.Windows.Forms.NumericUpDown nudTechLevel;
    private System.Windows.Forms.NumericUpDown nudCredits;
    private System.Windows.Forms.Label lblTechLevel;
    private System.Windows.Forms.Label lblCredits;
    private System.Windows.Forms.Label lblIQ;
    private System.Windows.Forms.CheckBox cbPlayerControl;
    private System.Windows.Forms.NumericUpDown nudIQ;
    private System.Windows.Forms.GroupBox gbAllies;
    private System.Windows.Forms.GroupBox gbGeneral;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown nudMaxVessels;
    private System.Windows.Forms.NumericUpDown nudMaxUnits;
    private System.Windows.Forms.NumericUpDown nudMaxInfantry;
    private System.Windows.Forms.NumericUpDown nudMaxBuildings;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
  }
}
