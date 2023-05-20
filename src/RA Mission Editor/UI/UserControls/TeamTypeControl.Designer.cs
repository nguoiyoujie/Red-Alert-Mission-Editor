
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TeamTypeControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamTypeControl));
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.cbScriptParameter = new System.Windows.Forms.ComboBox();
      this.lblWaypoint = new System.Windows.Forms.Label();
      this.cbScriptType = new System.Windows.Forms.ComboBox();
      this.lblInitNum = new System.Windows.Forms.Label();
      this.cbTechnoType1 = new System.Windows.Forms.ComboBox();
      this.lblMax = new System.Windows.Forms.Label();
      this.cbTrigger = new System.Windows.Forms.ComboBox();
      this.cbOwner = new System.Windows.Forms.ComboBox();
      this.lblName = new System.Windows.Forms.Label();
      this.lblPriority = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.lblOwner = new System.Windows.Forms.Label();
      this.lblTrigger = new System.Windows.Forms.Label();
      this.nudPriority = new System.Windows.Forms.NumericUpDown();
      this.lboxTeamMissions = new System.Windows.Forms.ListBox();
      this.cbAvoidThreats = new System.Windows.Forms.CheckBox();
      this.cbSuicide = new System.Windows.Forms.CheckBox();
      this.cbAutocreate = new System.Windows.Forms.CheckBox();
      this.cbPrebuild = new System.Windows.Forms.CheckBox();
      this.cbReinforce = new System.Windows.Forms.CheckBox();
      this.nudMax = new System.Windows.Forms.NumericUpDown();
      this.nudInitNum = new System.Windows.Forms.NumericUpDown();
      this.cbWaypoint = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.gbScript = new System.Windows.Forms.GroupBox();
      this.bScriptInsertReplace = new System.Windows.Forms.Button();
      this.bScriptDelete = new System.Windows.Forms.Button();
      this.bScriptMoveDown = new System.Windows.Forms.Button();
      this.bScriptMoveUp = new System.Windows.Forms.Button();
      this.bScriptInsertAfter = new System.Windows.Forms.Button();
      this.bScriptInsertBefore = new System.Windows.Forms.Button();
      this.gbMembers = new System.Windows.Forms.GroupBox();
      this.bTechnoType5 = new System.Windows.Forms.Button();
      this.bTechnoType4 = new System.Windows.Forms.Button();
      this.bTechnoType3 = new System.Windows.Forms.Button();
      this.bTechnoType2 = new System.Windows.Forms.Button();
      this.bTechnoType1 = new System.Windows.Forms.Button();
      this.nudTechnoNum5 = new System.Windows.Forms.NumericUpDown();
      this.cbTechnoType5 = new System.Windows.Forms.ComboBox();
      this.nudTechnoNum4 = new System.Windows.Forms.NumericUpDown();
      this.cbTechnoType4 = new System.Windows.Forms.ComboBox();
      this.nudTechnoNum3 = new System.Windows.Forms.NumericUpDown();
      this.cbTechnoType3 = new System.Windows.Forms.ComboBox();
      this.nudTechnoNum2 = new System.Windows.Forms.NumericUpDown();
      this.cbTechnoType2 = new System.Windows.Forms.ComboBox();
      this.nudTechnoNum1 = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.tbComment = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbRaw = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudInitNum)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.gbScript.SuspendLayout();
      this.gbMembers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum1)).BeginInit();
      this.SuspendLayout();
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(363, 454);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 48;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(505, 454);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 47;
      this.bCancel.Text = "Revert";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(9, 368);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbHint.Size = new System.Drawing.Size(588, 80);
      this.tbHint.TabIndex = 92;
      // 
      // cbScriptParameter
      // 
      this.cbScriptParameter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbScriptParameter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbScriptParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbScriptParameter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbScriptParameter.FormattingEnabled = true;
      this.cbScriptParameter.Location = new System.Drawing.Point(266, 130);
      this.cbScriptParameter.Name = "cbScriptParameter";
      this.cbScriptParameter.Size = new System.Drawing.Size(125, 21);
      this.cbScriptParameter.TabIndex = 85;
      this.cbScriptParameter.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      // 
      // lblWaypoint
      // 
      this.lblWaypoint.AutoSize = true;
      this.lblWaypoint.Location = new System.Drawing.Point(129, 100);
      this.lblWaypoint.Name = "lblWaypoint";
      this.lblWaypoint.Size = new System.Drawing.Size(55, 13);
      this.lblWaypoint.TabIndex = 84;
      this.lblWaypoint.Text = "Waypoint";
      // 
      // cbScriptType
      // 
      this.cbScriptType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbScriptType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbScriptType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbScriptType.FormattingEnabled = true;
      this.cbScriptType.Location = new System.Drawing.Point(6, 130);
      this.cbScriptType.Name = "cbScriptType";
      this.cbScriptType.Size = new System.Drawing.Size(254, 21);
      this.cbScriptType.TabIndex = 77;
      this.cbScriptType.SelectedIndexChanged += new System.EventHandler(this.cbScriptType_SelectedIndexChanged);
      this.cbScriptType.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      // 
      // lblInitNum
      // 
      this.lblInitNum.AutoSize = true;
      this.lblInitNum.Location = new System.Drawing.Point(129, 73);
      this.lblInitNum.Name = "lblInitNum";
      this.lblInitNum.Size = new System.Drawing.Size(49, 13);
      this.lblInitNum.TabIndex = 69;
      this.lblInitNum.Text = "InitNum";
      // 
      // cbTechnoType1
      // 
      this.cbTechnoType1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTechnoType1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTechnoType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTechnoType1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTechnoType1.FormattingEnabled = true;
      this.cbTechnoType1.Location = new System.Drawing.Point(6, 19);
      this.cbTechnoType1.Margin = new System.Windows.Forms.Padding(1);
      this.cbTechnoType1.Name = "cbTechnoType1";
      this.cbTechnoType1.Size = new System.Drawing.Size(157, 21);
      this.cbTechnoType1.TabIndex = 74;
      this.cbTechnoType1.SelectedIndexChanged += new System.EventHandler(this.cbTechnoType_SelectedIndexChanged);
      this.cbTechnoType1.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbTechnoType1.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // lblMax
      // 
      this.lblMax.AutoSize = true;
      this.lblMax.Location = new System.Drawing.Point(129, 47);
      this.lblMax.Name = "lblMax";
      this.lblMax.Size = new System.Drawing.Size(25, 13);
      this.lblMax.TabIndex = 73;
      this.lblMax.Text = "Max";
      // 
      // cbTrigger
      // 
      this.cbTrigger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTrigger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTrigger.DisplayMember = "Name";
      this.cbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTrigger.FormattingEnabled = true;
      this.cbTrigger.Location = new System.Drawing.Point(389, 3);
      this.cbTrigger.Name = "cbTrigger";
      this.cbTrigger.Size = new System.Drawing.Size(208, 21);
      this.cbTrigger.TabIndex = 67;
      this.cbTrigger.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbTrigger.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbTrigger.Enter += new System.EventHandler(this.cbTrigger_Enter);
      // 
      // cbOwner
      // 
      this.cbOwner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbOwner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbOwner.FormattingEnabled = true;
      this.cbOwner.Location = new System.Drawing.Point(200, 3);
      this.cbOwner.Name = "cbOwner";
      this.cbOwner.Size = new System.Drawing.Size(121, 21);
      this.cbOwner.TabIndex = 66;
      this.cbOwner.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbOwner.Enter += new System.EventHandler(this.cbOwner_Enter);
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(9, 6);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(31, 13);
      this.lblName.TabIndex = 60;
      this.lblName.Text = "Name";
      // 
      // lblPriority
      // 
      this.lblPriority.AutoSize = true;
      this.lblPriority.Location = new System.Drawing.Point(129, 21);
      this.lblPriority.Name = "lblPriority";
      this.lblPriority.Size = new System.Drawing.Size(55, 13);
      this.lblPriority.TabIndex = 65;
      this.lblPriority.Text = "Priority";
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(50, 3);
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(100, 20);
      this.tbName.TabIndex = 61;
      this.tbName.TextChanged += new System.EventHandler(this.Value_Changed);
      this.tbName.Enter += new System.EventHandler(this.tbName_Enter);
      // 
      // lblOwner
      // 
      this.lblOwner.AutoSize = true;
      this.lblOwner.Location = new System.Drawing.Point(156, 6);
      this.lblOwner.Name = "lblOwner";
      this.lblOwner.Size = new System.Drawing.Size(37, 13);
      this.lblOwner.TabIndex = 62;
      this.lblOwner.Text = "Owner";
      // 
      // lblTrigger
      // 
      this.lblTrigger.AutoSize = true;
      this.lblTrigger.Location = new System.Drawing.Point(327, 6);
      this.lblTrigger.Name = "lblTrigger";
      this.lblTrigger.Size = new System.Drawing.Size(49, 13);
      this.lblTrigger.TabIndex = 63;
      this.lblTrigger.Text = "Trigger";
      // 
      // nudPriority
      // 
      this.nudPriority.Location = new System.Drawing.Point(193, 19);
      this.nudPriority.Name = "nudPriority";
      this.nudPriority.Size = new System.Drawing.Size(120, 20);
      this.nudPriority.TabIndex = 93;
      this.nudPriority.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudPriority.Enter += new System.EventHandler(this.nudPriority_Enter);
      // 
      // lboxTeamMissions
      // 
      this.lboxTeamMissions.FormattingEnabled = true;
      this.lboxTeamMissions.Location = new System.Drawing.Point(6, 19);
      this.lboxTeamMissions.Name = "lboxTeamMissions";
      this.lboxTeamMissions.Size = new System.Drawing.Size(573, 82);
      this.lboxTeamMissions.TabIndex = 94;
      this.lboxTeamMissions.SelectedIndexChanged += new System.EventHandler(this.lboxTeamMissions_SelectedIndexChanged);
      // 
      // cbAvoidThreats
      // 
      this.cbAvoidThreats.AutoSize = true;
      this.cbAvoidThreats.Location = new System.Drawing.Point(6, 19);
      this.cbAvoidThreats.Name = "cbAvoidThreats";
      this.cbAvoidThreats.Size = new System.Drawing.Size(104, 17);
      this.cbAvoidThreats.TabIndex = 95;
      this.cbAvoidThreats.Text = "Avoid Threats";
      this.cbAvoidThreats.UseVisualStyleBackColor = true;
      this.cbAvoidThreats.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbAvoidThreats.Enter += new System.EventHandler(this.cbAvoidThreats_Enter);
      // 
      // cbSuicide
      // 
      this.cbSuicide.AutoSize = true;
      this.cbSuicide.Location = new System.Drawing.Point(6, 42);
      this.cbSuicide.Name = "cbSuicide";
      this.cbSuicide.Size = new System.Drawing.Size(68, 17);
      this.cbSuicide.TabIndex = 96;
      this.cbSuicide.Text = "Suicide";
      this.cbSuicide.UseVisualStyleBackColor = true;
      this.cbSuicide.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbSuicide.Enter += new System.EventHandler(this.cbSuicide_Enter);
      // 
      // cbAutocreate
      // 
      this.cbAutocreate.AutoSize = true;
      this.cbAutocreate.Location = new System.Drawing.Point(6, 65);
      this.cbAutocreate.Name = "cbAutocreate";
      this.cbAutocreate.Size = new System.Drawing.Size(86, 17);
      this.cbAutocreate.TabIndex = 97;
      this.cbAutocreate.Text = "Autocreate";
      this.cbAutocreate.UseVisualStyleBackColor = true;
      this.cbAutocreate.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbAutocreate.Enter += new System.EventHandler(this.cbAutocreate_Enter);
      // 
      // cbPrebuild
      // 
      this.cbPrebuild.AutoSize = true;
      this.cbPrebuild.Location = new System.Drawing.Point(6, 88);
      this.cbPrebuild.Name = "cbPrebuild";
      this.cbPrebuild.Size = new System.Drawing.Size(74, 17);
      this.cbPrebuild.TabIndex = 98;
      this.cbPrebuild.Text = "Prebuild";
      this.cbPrebuild.UseVisualStyleBackColor = true;
      this.cbPrebuild.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbPrebuild.Enter += new System.EventHandler(this.cbPrebuild_Enter);
      // 
      // cbReinforce
      // 
      this.cbReinforce.AutoSize = true;
      this.cbReinforce.Location = new System.Drawing.Point(6, 111);
      this.cbReinforce.Name = "cbReinforce";
      this.cbReinforce.Size = new System.Drawing.Size(80, 17);
      this.cbReinforce.TabIndex = 99;
      this.cbReinforce.Text = "Reinforce";
      this.cbReinforce.UseVisualStyleBackColor = true;
      this.cbReinforce.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbReinforce.Enter += new System.EventHandler(this.cbReinforce_Enter);
      // 
      // nudMax
      // 
      this.nudMax.Location = new System.Drawing.Point(193, 45);
      this.nudMax.Name = "nudMax";
      this.nudMax.Size = new System.Drawing.Size(120, 20);
      this.nudMax.TabIndex = 100;
      this.nudMax.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudMax.Enter += new System.EventHandler(this.nudMax_Enter);
      // 
      // nudInitNum
      // 
      this.nudInitNum.Location = new System.Drawing.Point(193, 71);
      this.nudInitNum.Name = "nudInitNum";
      this.nudInitNum.Size = new System.Drawing.Size(120, 20);
      this.nudInitNum.TabIndex = 101;
      this.nudInitNum.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudInitNum.Enter += new System.EventHandler(this.nudInitNum_Enter);
      // 
      // cbWaypoint
      // 
      this.cbWaypoint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbWaypoint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbWaypoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbWaypoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbWaypoint.FormattingEnabled = true;
      this.cbWaypoint.Location = new System.Drawing.Point(193, 97);
      this.cbWaypoint.Name = "cbWaypoint";
      this.cbWaypoint.Size = new System.Drawing.Size(120, 21);
      this.cbWaypoint.TabIndex = 102;
      this.cbWaypoint.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbWaypoint.Enter += new System.EventHandler(this.cbWaypoint_Enter);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbAvoidThreats);
      this.groupBox1.Controls.Add(this.cbSuicide);
      this.groupBox1.Controls.Add(this.cbAutocreate);
      this.groupBox1.Controls.Add(this.cbWaypoint);
      this.groupBox1.Controls.Add(this.cbPrebuild);
      this.groupBox1.Controls.Add(this.nudInitNum);
      this.groupBox1.Controls.Add(this.cbReinforce);
      this.groupBox1.Controls.Add(this.nudMax);
      this.groupBox1.Controls.Add(this.lblPriority);
      this.groupBox1.Controls.Add(this.nudPriority);
      this.groupBox1.Controls.Add(this.lblMax);
      this.groupBox1.Controls.Add(this.lblInitNum);
      this.groupBox1.Controls.Add(this.lblWaypoint);
      this.groupBox1.Location = new System.Drawing.Point(278, 31);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(319, 139);
      this.groupBox1.TabIndex = 103;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "AI Modifiers";
      // 
      // gbScript
      // 
      this.gbScript.Controls.Add(this.bScriptInsertReplace);
      this.gbScript.Controls.Add(this.bScriptDelete);
      this.gbScript.Controls.Add(this.bScriptMoveDown);
      this.gbScript.Controls.Add(this.bScriptMoveUp);
      this.gbScript.Controls.Add(this.bScriptInsertAfter);
      this.gbScript.Controls.Add(this.bScriptInsertBefore);
      this.gbScript.Controls.Add(this.lboxTeamMissions);
      this.gbScript.Controls.Add(this.cbScriptType);
      this.gbScript.Controls.Add(this.cbScriptParameter);
      this.gbScript.Location = new System.Drawing.Point(12, 176);
      this.gbScript.Name = "gbScript";
      this.gbScript.Size = new System.Drawing.Size(585, 158);
      this.gbScript.TabIndex = 104;
      this.gbScript.TabStop = false;
      this.gbScript.Text = "Team Script";
      // 
      // bScriptInsertReplace
      // 
      this.bScriptInsertReplace.Enabled = false;
      this.bScriptInsertReplace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptInsertReplace.Location = new System.Drawing.Point(457, 128);
      this.bScriptInsertReplace.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptInsertReplace.Name = "bScriptInsertReplace";
      this.bScriptInsertReplace.Size = new System.Drawing.Size(60, 22);
      this.bScriptInsertReplace.TabIndex = 100;
      this.bScriptInsertReplace.Text = "Replace";
      this.bScriptInsertReplace.UseVisualStyleBackColor = true;
      this.bScriptInsertReplace.Click += new System.EventHandler(this.bScriptInsertReplace_Click);
      // 
      // bScriptDelete
      // 
      this.bScriptDelete.Enabled = false;
      this.bScriptDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptDelete.Location = new System.Drawing.Point(170, 105);
      this.bScriptDelete.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptDelete.Name = "bScriptDelete";
      this.bScriptDelete.Size = new System.Drawing.Size(80, 21);
      this.bScriptDelete.TabIndex = 99;
      this.bScriptDelete.Text = "Delete";
      this.bScriptDelete.UseVisualStyleBackColor = true;
      this.bScriptDelete.Click += new System.EventHandler(this.bScriptDelete_Click);
      // 
      // bScriptMoveDown
      // 
      this.bScriptMoveDown.Enabled = false;
      this.bScriptMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptMoveDown.Location = new System.Drawing.Point(88, 105);
      this.bScriptMoveDown.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptMoveDown.Name = "bScriptMoveDown";
      this.bScriptMoveDown.Size = new System.Drawing.Size(80, 21);
      this.bScriptMoveDown.TabIndex = 98;
      this.bScriptMoveDown.Text = "Move Down";
      this.bScriptMoveDown.UseVisualStyleBackColor = true;
      this.bScriptMoveDown.Click += new System.EventHandler(this.bScriptMoveDown_Click);
      // 
      // bScriptMoveUp
      // 
      this.bScriptMoveUp.Enabled = false;
      this.bScriptMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptMoveUp.Location = new System.Drawing.Point(6, 105);
      this.bScriptMoveUp.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptMoveUp.Name = "bScriptMoveUp";
      this.bScriptMoveUp.Size = new System.Drawing.Size(80, 21);
      this.bScriptMoveUp.TabIndex = 97;
      this.bScriptMoveUp.Text = "Move Up";
      this.bScriptMoveUp.UseVisualStyleBackColor = true;
      this.bScriptMoveUp.Click += new System.EventHandler(this.bScriptMoveUp_Click);
      // 
      // bScriptInsertAfter
      // 
      this.bScriptInsertAfter.Enabled = false;
      this.bScriptInsertAfter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptInsertAfter.Location = new System.Drawing.Point(519, 128);
      this.bScriptInsertAfter.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptInsertAfter.Name = "bScriptInsertAfter";
      this.bScriptInsertAfter.Size = new System.Drawing.Size(60, 22);
      this.bScriptInsertAfter.TabIndex = 96;
      this.bScriptInsertAfter.Text = "After";
      this.bScriptInsertAfter.UseVisualStyleBackColor = true;
      this.bScriptInsertAfter.Click += new System.EventHandler(this.bScriptInsertAfter_Click);
      // 
      // bScriptInsertBefore
      // 
      this.bScriptInsertBefore.Enabled = false;
      this.bScriptInsertBefore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bScriptInsertBefore.Location = new System.Drawing.Point(395, 128);
      this.bScriptInsertBefore.Margin = new System.Windows.Forms.Padding(1);
      this.bScriptInsertBefore.Name = "bScriptInsertBefore";
      this.bScriptInsertBefore.Size = new System.Drawing.Size(60, 22);
      this.bScriptInsertBefore.TabIndex = 95;
      this.bScriptInsertBefore.Text = "Before";
      this.bScriptInsertBefore.UseVisualStyleBackColor = true;
      this.bScriptInsertBefore.Click += new System.EventHandler(this.bScriptInsertBefore_Click);
      // 
      // gbMembers
      // 
      this.gbMembers.Controls.Add(this.bTechnoType5);
      this.gbMembers.Controls.Add(this.bTechnoType4);
      this.gbMembers.Controls.Add(this.bTechnoType3);
      this.gbMembers.Controls.Add(this.bTechnoType2);
      this.gbMembers.Controls.Add(this.bTechnoType1);
      this.gbMembers.Controls.Add(this.nudTechnoNum5);
      this.gbMembers.Controls.Add(this.cbTechnoType5);
      this.gbMembers.Controls.Add(this.nudTechnoNum4);
      this.gbMembers.Controls.Add(this.cbTechnoType4);
      this.gbMembers.Controls.Add(this.nudTechnoNum3);
      this.gbMembers.Controls.Add(this.cbTechnoType3);
      this.gbMembers.Controls.Add(this.nudTechnoNum2);
      this.gbMembers.Controls.Add(this.cbTechnoType2);
      this.gbMembers.Controls.Add(this.nudTechnoNum1);
      this.gbMembers.Controls.Add(this.cbTechnoType1);
      this.gbMembers.Location = new System.Drawing.Point(12, 29);
      this.gbMembers.Name = "gbMembers";
      this.gbMembers.Size = new System.Drawing.Size(260, 141);
      this.gbMembers.TabIndex = 106;
      this.gbMembers.TabStop = false;
      this.gbMembers.Text = "Members";
      // 
      // bTechnoType5
      // 
      this.bTechnoType5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bTechnoType5.Location = new System.Drawing.Point(211, 107);
      this.bTechnoType5.Margin = new System.Windows.Forms.Padding(1);
      this.bTechnoType5.Name = "bTechnoType5";
      this.bTechnoType5.Size = new System.Drawing.Size(45, 20);
      this.bTechnoType5.TabIndex = 115;
      this.bTechnoType5.Text = "Add";
      this.bTechnoType5.UseVisualStyleBackColor = true;
      this.bTechnoType5.Click += new System.EventHandler(this.bTechnoType5_Click);
      // 
      // bTechnoType4
      // 
      this.bTechnoType4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bTechnoType4.Location = new System.Drawing.Point(211, 85);
      this.bTechnoType4.Margin = new System.Windows.Forms.Padding(1);
      this.bTechnoType4.Name = "bTechnoType4";
      this.bTechnoType4.Size = new System.Drawing.Size(45, 20);
      this.bTechnoType4.TabIndex = 114;
      this.bTechnoType4.Text = "Add";
      this.bTechnoType4.UseVisualStyleBackColor = true;
      this.bTechnoType4.Click += new System.EventHandler(this.bTechnoType4_Click);
      // 
      // bTechnoType3
      // 
      this.bTechnoType3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bTechnoType3.Location = new System.Drawing.Point(211, 64);
      this.bTechnoType3.Margin = new System.Windows.Forms.Padding(1);
      this.bTechnoType3.Name = "bTechnoType3";
      this.bTechnoType3.Size = new System.Drawing.Size(45, 20);
      this.bTechnoType3.TabIndex = 113;
      this.bTechnoType3.Text = "Add";
      this.bTechnoType3.UseVisualStyleBackColor = true;
      this.bTechnoType3.Click += new System.EventHandler(this.bTechnoType3_Click);
      // 
      // bTechnoType2
      // 
      this.bTechnoType2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bTechnoType2.Location = new System.Drawing.Point(211, 42);
      this.bTechnoType2.Margin = new System.Windows.Forms.Padding(1);
      this.bTechnoType2.Name = "bTechnoType2";
      this.bTechnoType2.Size = new System.Drawing.Size(45, 20);
      this.bTechnoType2.TabIndex = 112;
      this.bTechnoType2.Text = "Add";
      this.bTechnoType2.UseVisualStyleBackColor = true;
      this.bTechnoType2.Click += new System.EventHandler(this.bTechnoType2_Click);
      // 
      // bTechnoType1
      // 
      this.bTechnoType1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bTechnoType1.Location = new System.Drawing.Point(211, 19);
      this.bTechnoType1.Margin = new System.Windows.Forms.Padding(1);
      this.bTechnoType1.Name = "bTechnoType1";
      this.bTechnoType1.Size = new System.Drawing.Size(45, 20);
      this.bTechnoType1.TabIndex = 111;
      this.bTechnoType1.Text = "Add";
      this.bTechnoType1.UseVisualStyleBackColor = true;
      this.bTechnoType1.Click += new System.EventHandler(this.bTechnoType1_Click);
      // 
      // nudTechnoNum5
      // 
      this.nudTechnoNum5.Location = new System.Drawing.Point(165, 108);
      this.nudTechnoNum5.Margin = new System.Windows.Forms.Padding(1);
      this.nudTechnoNum5.Name = "nudTechnoNum5";
      this.nudTechnoNum5.Size = new System.Drawing.Size(44, 20);
      this.nudTechnoNum5.TabIndex = 110;
      this.nudTechnoNum5.ValueChanged += new System.EventHandler(this.TechnoNum_ValueChanged);
      this.nudTechnoNum5.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // cbTechnoType5
      // 
      this.cbTechnoType5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTechnoType5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTechnoType5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTechnoType5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTechnoType5.FormattingEnabled = true;
      this.cbTechnoType5.Location = new System.Drawing.Point(6, 107);
      this.cbTechnoType5.Margin = new System.Windows.Forms.Padding(1);
      this.cbTechnoType5.Name = "cbTechnoType5";
      this.cbTechnoType5.Size = new System.Drawing.Size(157, 21);
      this.cbTechnoType5.TabIndex = 109;
      this.cbTechnoType5.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // nudTechnoNum4
      // 
      this.nudTechnoNum4.Location = new System.Drawing.Point(165, 86);
      this.nudTechnoNum4.Margin = new System.Windows.Forms.Padding(1);
      this.nudTechnoNum4.Name = "nudTechnoNum4";
      this.nudTechnoNum4.Size = new System.Drawing.Size(44, 20);
      this.nudTechnoNum4.TabIndex = 108;
      this.nudTechnoNum4.ValueChanged += new System.EventHandler(this.TechnoNum_ValueChanged);
      this.nudTechnoNum4.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // cbTechnoType4
      // 
      this.cbTechnoType4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTechnoType4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTechnoType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTechnoType4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTechnoType4.FormattingEnabled = true;
      this.cbTechnoType4.Location = new System.Drawing.Point(6, 85);
      this.cbTechnoType4.Margin = new System.Windows.Forms.Padding(1);
      this.cbTechnoType4.Name = "cbTechnoType4";
      this.cbTechnoType4.Size = new System.Drawing.Size(157, 21);
      this.cbTechnoType4.TabIndex = 107;
      this.cbTechnoType4.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // nudTechnoNum3
      // 
      this.nudTechnoNum3.Location = new System.Drawing.Point(165, 64);
      this.nudTechnoNum3.Margin = new System.Windows.Forms.Padding(1);
      this.nudTechnoNum3.Name = "nudTechnoNum3";
      this.nudTechnoNum3.Size = new System.Drawing.Size(44, 20);
      this.nudTechnoNum3.TabIndex = 106;
      this.nudTechnoNum3.ValueChanged += new System.EventHandler(this.TechnoNum_ValueChanged);
      this.nudTechnoNum3.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // cbTechnoType3
      // 
      this.cbTechnoType3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTechnoType3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTechnoType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTechnoType3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTechnoType3.FormattingEnabled = true;
      this.cbTechnoType3.Location = new System.Drawing.Point(6, 63);
      this.cbTechnoType3.Margin = new System.Windows.Forms.Padding(1);
      this.cbTechnoType3.Name = "cbTechnoType3";
      this.cbTechnoType3.Size = new System.Drawing.Size(157, 21);
      this.cbTechnoType3.TabIndex = 105;
      this.cbTechnoType3.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // nudTechnoNum2
      // 
      this.nudTechnoNum2.Location = new System.Drawing.Point(165, 42);
      this.nudTechnoNum2.Margin = new System.Windows.Forms.Padding(1);
      this.nudTechnoNum2.Name = "nudTechnoNum2";
      this.nudTechnoNum2.Size = new System.Drawing.Size(44, 20);
      this.nudTechnoNum2.TabIndex = 104;
      this.nudTechnoNum2.ValueChanged += new System.EventHandler(this.TechnoNum_ValueChanged);
      this.nudTechnoNum2.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // cbTechnoType2
      // 
      this.cbTechnoType2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTechnoType2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTechnoType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTechnoType2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTechnoType2.FormattingEnabled = true;
      this.cbTechnoType2.Location = new System.Drawing.Point(6, 41);
      this.cbTechnoType2.Margin = new System.Windows.Forms.Padding(1);
      this.cbTechnoType2.Name = "cbTechnoType2";
      this.cbTechnoType2.Size = new System.Drawing.Size(157, 21);
      this.cbTechnoType2.TabIndex = 103;
      this.cbTechnoType2.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // nudTechnoNum1
      // 
      this.nudTechnoNum1.Location = new System.Drawing.Point(165, 20);
      this.nudTechnoNum1.Margin = new System.Windows.Forms.Padding(1);
      this.nudTechnoNum1.Name = "nudTechnoNum1";
      this.nudTechnoNum1.Size = new System.Drawing.Size(44, 20);
      this.nudTechnoNum1.TabIndex = 102;
      this.nudTechnoNum1.ValueChanged += new System.EventHandler(this.TechnoNum_ValueChanged);
      this.nudTechnoNum1.Enter += new System.EventHandler(this.nudTechno_Enter);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 345);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 108;
      this.label1.Text = "Comment";
      // 
      // tbComment
      // 
      this.tbComment.Location = new System.Drawing.Point(77, 342);
      this.tbComment.Name = "tbComment";
      this.tbComment.Size = new System.Drawing.Size(520, 20);
      this.tbComment.TabIndex = 107;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 454);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(25, 13);
      this.label2.TabIndex = 110;
      this.label2.Text = "Raw";
      // 
      // tbRaw
      // 
      this.tbRaw.Location = new System.Drawing.Point(50, 451);
      this.tbRaw.Name = "tbRaw";
      this.tbRaw.ReadOnly = true;
      this.tbRaw.Size = new System.Drawing.Size(307, 20);
      this.tbRaw.TabIndex = 109;
      // 
      // TeamTypeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbRaw);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbComment);
      this.Controls.Add(this.gbMembers);
      this.Controls.Add(this.gbScript);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.tbHint);
      this.Controls.Add(this.cbTrigger);
      this.Controls.Add(this.cbOwner);
      this.Controls.Add(this.lblName);
      this.Controls.Add(this.tbName);
      this.Controls.Add(this.lblOwner);
      this.Controls.Add(this.lblTrigger);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.Name = "TeamTypeControl";
      this.Size = new System.Drawing.Size(600, 500);
      ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudInitNum)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.gbScript.ResumeLayout(false);
      this.gbMembers.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTechnoNum1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.ComboBox cbScriptParameter;
    private System.Windows.Forms.Label lblWaypoint;
    private System.Windows.Forms.ComboBox cbScriptType;
    private System.Windows.Forms.Label lblInitNum;
    private System.Windows.Forms.ComboBox cbTechnoType1;
    private System.Windows.Forms.Label lblMax;
    private System.Windows.Forms.ComboBox cbTrigger;
    private System.Windows.Forms.ComboBox cbOwner;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblPriority;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Label lblOwner;
    private System.Windows.Forms.Label lblTrigger;
    private System.Windows.Forms.NumericUpDown nudPriority;
    private System.Windows.Forms.ListBox lboxTeamMissions;
    private System.Windows.Forms.CheckBox cbAvoidThreats;
    private System.Windows.Forms.CheckBox cbSuicide;
    private System.Windows.Forms.CheckBox cbAutocreate;
    private System.Windows.Forms.CheckBox cbPrebuild;
    private System.Windows.Forms.CheckBox cbReinforce;
    private System.Windows.Forms.NumericUpDown nudMax;
    private System.Windows.Forms.NumericUpDown nudInitNum;
    private System.Windows.Forms.ComboBox cbWaypoint;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox gbScript;
    private System.Windows.Forms.GroupBox gbMembers;
    private System.Windows.Forms.NumericUpDown nudTechnoNum5;
    private System.Windows.Forms.ComboBox cbTechnoType5;
    private System.Windows.Forms.NumericUpDown nudTechnoNum4;
    private System.Windows.Forms.ComboBox cbTechnoType4;
    private System.Windows.Forms.NumericUpDown nudTechnoNum3;
    private System.Windows.Forms.ComboBox cbTechnoType3;
    private System.Windows.Forms.NumericUpDown nudTechnoNum2;
    private System.Windows.Forms.ComboBox cbTechnoType2;
    private System.Windows.Forms.NumericUpDown nudTechnoNum1;
    private System.Windows.Forms.Button bScriptInsertBefore;
    private System.Windows.Forms.Button bScriptDelete;
    private System.Windows.Forms.Button bScriptMoveDown;
    private System.Windows.Forms.Button bScriptMoveUp;
    private System.Windows.Forms.Button bScriptInsertAfter;
    private System.Windows.Forms.Button bTechnoType5;
    private System.Windows.Forms.Button bTechnoType4;
    private System.Windows.Forms.Button bTechnoType3;
    private System.Windows.Forms.Button bTechnoType2;
    private System.Windows.Forms.Button bTechnoType1;
    private System.Windows.Forms.Button bScriptInsertReplace;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbComment;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbRaw;
  }
}
