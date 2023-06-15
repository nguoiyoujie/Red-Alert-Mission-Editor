
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TechnoTypeControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TechnoTypeControl));
      this.pBottom = new System.Windows.Forms.Panel();
      this.bDelete = new System.Windows.Forms.Button();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.pTop = new System.Windows.Forms.Panel();
      this.bShowHide = new System.Windows.Forms.Button();
      this.lblEntity = new System.Windows.Forms.Label();
      this.lblXY = new System.Windows.Forms.Label();
      this.lblStrength = new System.Windows.Forms.Label();
      this.lblType = new System.Windows.Forms.Label();
      this.cbSellable = new System.Windows.Forms.CheckBox();
      this.cbRepairable = new System.Windows.Forms.CheckBox();
      this.nudY = new System.Windows.Forms.NumericUpDown();
      this.nudX = new System.Windows.Forms.NumericUpDown();
      this.nudStrength = new System.Windows.Forms.NumericUpDown();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.cbOwner = new System.Windows.Forms.ComboBox();
      this.lblOwner = new System.Windows.Forms.Label();
      this.pCommon1 = new System.Windows.Forms.Panel();
      this.pInfantry = new System.Windows.Forms.Panel();
      this.rbBR = new System.Windows.Forms.RadioButton();
      this.rbBL = new System.Windows.Forms.RadioButton();
      this.rbTR = new System.Windows.Forms.RadioButton();
      this.rbC = new System.Windows.Forms.RadioButton();
      this.lblSubcell = new System.Windows.Forms.Label();
      this.rbTL = new System.Windows.Forms.RadioButton();
      this.pCommon2 = new System.Windows.Forms.Panel();
      this.nudFacing = new System.Windows.Forms.NumericUpDown();
      this.lblTag = new System.Windows.Forms.Label();
      this.cbTag = new System.Windows.Forms.ComboBox();
      this.lblFacing = new System.Windows.Forms.Label();
      this.pMission = new System.Windows.Forms.Panel();
      this.lblMission = new System.Windows.Forms.Label();
      this.cbMission = new System.Windows.Forms.ComboBox();
      this.pStructure = new System.Windows.Forms.Panel();
      this.pBlack = new System.Windows.Forms.Panel();
      this.pBottom.SuspendLayout();
      this.pTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).BeginInit();
      this.pCommon1.SuspendLayout();
      this.pInfantry.SuspendLayout();
      this.pCommon2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudFacing)).BeginInit();
      this.pMission.SuspendLayout();
      this.pStructure.SuspendLayout();
      this.SuspendLayout();
      // 
      // pBottom
      // 
      this.pBottom.Controls.Add(this.bDelete);
      this.pBottom.Controls.Add(this.tbHint);
      this.pBottom.Controls.Add(this.bOK);
      this.pBottom.Controls.Add(this.bCancel);
      this.pBottom.Dock = System.Windows.Forms.DockStyle.Top;
      this.pBottom.Location = new System.Drawing.Point(0, 329);
      this.pBottom.Name = "pBottom";
      this.pBottom.Size = new System.Drawing.Size(240, 247);
      this.pBottom.TabIndex = 0;
      // 
      // bDelete
      // 
      this.bDelete.Location = new System.Drawing.Point(173, 209);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(64, 32);
      this.bDelete.TabIndex = 59;
      this.bDelete.Text = "Delete";
      this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDelete.UseVisualStyleBackColor = true;
      this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(3, 3);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbHint.Size = new System.Drawing.Size(234, 200);
      this.tbHint.TabIndex = 58;
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(3, 209);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(76, 32);
      this.bOK.TabIndex = 46;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(85, 209);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(82, 32);
      this.bCancel.TabIndex = 45;
      this.bCancel.Text = "Revert";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // pTop
      // 
      this.pTop.Controls.Add(this.bShowHide);
      this.pTop.Controls.Add(this.lblEntity);
      this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pTop.Location = new System.Drawing.Point(0, 0);
      this.pTop.Name = "pTop";
      this.pTop.Size = new System.Drawing.Size(240, 28);
      this.pTop.TabIndex = 1;
      // 
      // bShowHide
      // 
      this.bShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bShowHide.Location = new System.Drawing.Point(192, -2);
      this.bShowHide.Name = "bShowHide";
      this.bShowHide.Size = new System.Drawing.Size(48, 30);
      this.bShowHide.TabIndex = 43;
      this.bShowHide.Text = "Show";
      this.bShowHide.UseVisualStyleBackColor = true;
      this.bShowHide.Click += new System.EventHandler(this.bShowHide_Click);
      // 
      // lblEntity
      // 
      this.lblEntity.AutoSize = true;
      this.lblEntity.Font = new System.Drawing.Font("Consolas", 10F);
      this.lblEntity.Location = new System.Drawing.Point(5, 3);
      this.lblEntity.Name = "lblEntity";
      this.lblEntity.Size = new System.Drawing.Size(56, 17);
      this.lblEntity.TabIndex = 42;
      this.lblEntity.Text = "Entity";
      // 
      // lblXY
      // 
      this.lblXY.AutoSize = true;
      this.lblXY.Location = new System.Drawing.Point(6, 88);
      this.lblXY.Name = "lblXY";
      this.lblXY.Size = new System.Drawing.Size(91, 13);
      this.lblXY.TabIndex = 55;
      this.lblXY.Text = "Position (X,Y)";
      // 
      // lblStrength
      // 
      this.lblStrength.AutoSize = true;
      this.lblStrength.Location = new System.Drawing.Point(6, 62);
      this.lblStrength.Name = "lblStrength";
      this.lblStrength.Size = new System.Drawing.Size(55, 13);
      this.lblStrength.TabIndex = 54;
      this.lblStrength.Text = "Strength";
      // 
      // lblType
      // 
      this.lblType.AutoSize = true;
      this.lblType.Location = new System.Drawing.Point(6, 36);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(31, 13);
      this.lblType.TabIndex = 53;
      this.lblType.Text = "Type";
      // 
      // cbSellable
      // 
      this.cbSellable.AutoSize = true;
      this.cbSellable.Location = new System.Drawing.Point(101, 29);
      this.cbSellable.Name = "cbSellable";
      this.cbSellable.Size = new System.Drawing.Size(92, 17);
      this.cbSellable.TabIndex = 52;
      this.cbSellable.Text = "AI Sellable";
      this.cbSellable.UseVisualStyleBackColor = true;
      this.cbSellable.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbSellable.MouseEnter += new System.EventHandler(this.cbSellable_MouseEnter);
      // 
      // cbRepairable
      // 
      this.cbRepairable.AutoSize = true;
      this.cbRepairable.Location = new System.Drawing.Point(101, 6);
      this.cbRepairable.Name = "cbRepairable";
      this.cbRepairable.Size = new System.Drawing.Size(80, 17);
      this.cbRepairable.TabIndex = 51;
      this.cbRepairable.Text = "AI Repair";
      this.cbRepairable.UseVisualStyleBackColor = true;
      this.cbRepairable.CheckedChanged += new System.EventHandler(this.Value_Changed);
      this.cbRepairable.MouseEnter += new System.EventHandler(this.cbRepairable_MouseEnter);
      // 
      // nudY
      // 
      this.nudY.Location = new System.Drawing.Point(163, 86);
      this.nudY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
      this.nudY.Name = "nudY";
      this.nudY.Size = new System.Drawing.Size(58, 20);
      this.nudY.TabIndex = 49;
      this.nudY.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudY.MouseEnter += new System.EventHandler(this.nudXY_MouseEnter);
      // 
      // nudX
      // 
      this.nudX.Location = new System.Drawing.Point(101, 86);
      this.nudX.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
      this.nudX.Name = "nudX";
      this.nudX.Size = new System.Drawing.Size(58, 20);
      this.nudX.TabIndex = 48;
      this.nudX.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudX.MouseEnter += new System.EventHandler(this.nudXY_MouseEnter);
      // 
      // nudStrength
      // 
      this.nudStrength.Location = new System.Drawing.Point(101, 60);
      this.nudStrength.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.nudStrength.Name = "nudStrength";
      this.nudStrength.Size = new System.Drawing.Size(120, 20);
      this.nudStrength.TabIndex = 47;
      this.nudStrength.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudStrength.MouseEnter += new System.EventHandler(this.nudStrength_MouseEnter);
      // 
      // cbType
      // 
      this.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbType.Location = new System.Drawing.Point(101, 33);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(121, 21);
      this.cbType.TabIndex = 43;
      this.cbType.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbType.MouseEnter += new System.EventHandler(this.cbType_MouseEnter);
      // 
      // cbOwner
      // 
      this.cbOwner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbOwner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbOwner.Location = new System.Drawing.Point(101, 6);
      this.cbOwner.Name = "cbOwner";
      this.cbOwner.Size = new System.Drawing.Size(121, 21);
      this.cbOwner.TabIndex = 42;
      this.cbOwner.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbOwner.MouseEnter += new System.EventHandler(this.cbOwner_MouseEnter);
      // 
      // lblOwner
      // 
      this.lblOwner.AutoSize = true;
      this.lblOwner.Location = new System.Drawing.Point(6, 9);
      this.lblOwner.Name = "lblOwner";
      this.lblOwner.Size = new System.Drawing.Size(37, 13);
      this.lblOwner.TabIndex = 41;
      this.lblOwner.Text = "Owner";
      // 
      // pCommon1
      // 
      this.pCommon1.Controls.Add(this.cbOwner);
      this.pCommon1.Controls.Add(this.lblOwner);
      this.pCommon1.Controls.Add(this.cbType);
      this.pCommon1.Controls.Add(this.lblXY);
      this.pCommon1.Controls.Add(this.nudStrength);
      this.pCommon1.Controls.Add(this.lblStrength);
      this.pCommon1.Controls.Add(this.nudX);
      this.pCommon1.Controls.Add(this.lblType);
      this.pCommon1.Controls.Add(this.nudY);
      this.pCommon1.Dock = System.Windows.Forms.DockStyle.Top;
      this.pCommon1.Location = new System.Drawing.Point(0, 28);
      this.pCommon1.Name = "pCommon1";
      this.pCommon1.Size = new System.Drawing.Size(240, 108);
      this.pCommon1.TabIndex = 2;
      // 
      // pInfantry
      // 
      this.pInfantry.Controls.Add(this.rbBR);
      this.pInfantry.Controls.Add(this.rbBL);
      this.pInfantry.Controls.Add(this.rbTR);
      this.pInfantry.Controls.Add(this.rbC);
      this.pInfantry.Controls.Add(this.lblSubcell);
      this.pInfantry.Controls.Add(this.rbTL);
      this.pInfantry.Dock = System.Windows.Forms.DockStyle.Top;
      this.pInfantry.Location = new System.Drawing.Point(0, 136);
      this.pInfantry.Name = "pInfantry";
      this.pInfantry.Size = new System.Drawing.Size(240, 58);
      this.pInfantry.TabIndex = 2;
      // 
      // rbBR
      // 
      this.rbBR.AutoSize = true;
      this.rbBR.Location = new System.Drawing.Point(121, 41);
      this.rbBR.Name = "rbBR";
      this.rbBR.Size = new System.Drawing.Size(14, 13);
      this.rbBR.TabIndex = 38;
      this.rbBR.TabStop = true;
      this.rbBR.UseVisualStyleBackColor = true;
      this.rbBR.MouseEnter += new System.EventHandler(this.cbSubcell_MouseEnter);
      // 
      // rbBL
      // 
      this.rbBL.AutoSize = true;
      this.rbBL.Location = new System.Drawing.Point(101, 41);
      this.rbBL.Name = "rbBL";
      this.rbBL.Size = new System.Drawing.Size(14, 13);
      this.rbBL.TabIndex = 37;
      this.rbBL.TabStop = true;
      this.rbBL.UseVisualStyleBackColor = true;
      this.rbBL.MouseEnter += new System.EventHandler(this.cbSubcell_MouseEnter);
      // 
      // rbTR
      // 
      this.rbTR.AutoSize = true;
      this.rbTR.Location = new System.Drawing.Point(121, 3);
      this.rbTR.Name = "rbTR";
      this.rbTR.Size = new System.Drawing.Size(14, 13);
      this.rbTR.TabIndex = 36;
      this.rbTR.TabStop = true;
      this.rbTR.UseVisualStyleBackColor = true;
      this.rbTR.MouseEnter += new System.EventHandler(this.cbSubcell_MouseEnter);
      // 
      // rbC
      // 
      this.rbC.AutoSize = true;
      this.rbC.Location = new System.Drawing.Point(111, 22);
      this.rbC.Name = "rbC";
      this.rbC.Size = new System.Drawing.Size(14, 13);
      this.rbC.TabIndex = 35;
      this.rbC.TabStop = true;
      this.rbC.UseVisualStyleBackColor = true;
      this.rbC.MouseEnter += new System.EventHandler(this.cbSubcell_MouseEnter);
      // 
      // lblSubcell
      // 
      this.lblSubcell.AutoSize = true;
      this.lblSubcell.Location = new System.Drawing.Point(6, 12);
      this.lblSubcell.Name = "lblSubcell";
      this.lblSubcell.Size = new System.Drawing.Size(49, 13);
      this.lblSubcell.TabIndex = 34;
      this.lblSubcell.Text = "Subcell";
      // 
      // rbTL
      // 
      this.rbTL.AutoSize = true;
      this.rbTL.Location = new System.Drawing.Point(101, 3);
      this.rbTL.Name = "rbTL";
      this.rbTL.Size = new System.Drawing.Size(14, 13);
      this.rbTL.TabIndex = 33;
      this.rbTL.UseVisualStyleBackColor = false;
      this.rbTL.MouseEnter += new System.EventHandler(this.cbSubcell_MouseEnter);
      // 
      // pCommon2
      // 
      this.pCommon2.Controls.Add(this.nudFacing);
      this.pCommon2.Controls.Add(this.lblTag);
      this.pCommon2.Controls.Add(this.cbTag);
      this.pCommon2.Controls.Add(this.lblFacing);
      this.pCommon2.Dock = System.Windows.Forms.DockStyle.Top;
      this.pCommon2.Location = new System.Drawing.Point(0, 194);
      this.pCommon2.Name = "pCommon2";
      this.pCommon2.Size = new System.Drawing.Size(240, 56);
      this.pCommon2.TabIndex = 2;
      // 
      // nudFacing
      // 
      this.nudFacing.Location = new System.Drawing.Point(101, 6);
      this.nudFacing.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudFacing.Name = "nudFacing";
      this.nudFacing.Size = new System.Drawing.Size(120, 20);
      this.nudFacing.TabIndex = 50;
      this.nudFacing.ValueChanged += new System.EventHandler(this.Value_Changed);
      this.nudFacing.MouseEnter += new System.EventHandler(this.nudFacing_MouseEnter);
      // 
      // lblTag
      // 
      this.lblTag.AutoSize = true;
      this.lblTag.Location = new System.Drawing.Point(6, 35);
      this.lblTag.Name = "lblTag";
      this.lblTag.Size = new System.Drawing.Size(73, 13);
      this.lblTag.TabIndex = 57;
      this.lblTag.Text = "Trigger Tag";
      // 
      // cbTag
      // 
      this.cbTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTag.Location = new System.Drawing.Point(101, 32);
      this.cbTag.Name = "cbTag";
      this.cbTag.Size = new System.Drawing.Size(121, 21);
      this.cbTag.TabIndex = 44;
      this.cbTag.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbTag.MouseEnter += new System.EventHandler(this.cbTag_MouseEnter);
      // 
      // lblFacing
      // 
      this.lblFacing.AutoSize = true;
      this.lblFacing.Location = new System.Drawing.Point(6, 8);
      this.lblFacing.Name = "lblFacing";
      this.lblFacing.Size = new System.Drawing.Size(91, 13);
      this.lblFacing.TabIndex = 56;
      this.lblFacing.Text = "Facing (0-255)";
      // 
      // pMission
      // 
      this.pMission.Controls.Add(this.lblMission);
      this.pMission.Controls.Add(this.cbMission);
      this.pMission.Dock = System.Windows.Forms.DockStyle.Top;
      this.pMission.Location = new System.Drawing.Point(0, 250);
      this.pMission.Name = "pMission";
      this.pMission.Size = new System.Drawing.Size(240, 32);
      this.pMission.TabIndex = 3;
      // 
      // lblMission
      // 
      this.lblMission.AutoSize = true;
      this.lblMission.Location = new System.Drawing.Point(6, 9);
      this.lblMission.Name = "lblMission";
      this.lblMission.Size = new System.Drawing.Size(49, 13);
      this.lblMission.TabIndex = 28;
      this.lblMission.Text = "Mission";
      // 
      // cbMission
      // 
      this.cbMission.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbMission.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbMission.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbMission.Location = new System.Drawing.Point(101, 6);
      this.cbMission.Name = "cbMission";
      this.cbMission.Size = new System.Drawing.Size(121, 21);
      this.cbMission.TabIndex = 27;
      this.cbMission.SelectedIndexChanged += new System.EventHandler(this.Value_Changed);
      this.cbMission.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbMission.MouseEnter += new System.EventHandler(this.cbMission_MouseEnter);
      // 
      // pStructure
      // 
      this.pStructure.Controls.Add(this.cbRepairable);
      this.pStructure.Controls.Add(this.cbSellable);
      this.pStructure.Dock = System.Windows.Forms.DockStyle.Top;
      this.pStructure.Location = new System.Drawing.Point(0, 282);
      this.pStructure.Name = "pStructure";
      this.pStructure.Size = new System.Drawing.Size(240, 47);
      this.pStructure.TabIndex = 4;
      // 
      // pBlack
      // 
      this.pBlack.BackColor = System.Drawing.Color.Black;
      this.pBlack.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pBlack.Location = new System.Drawing.Point(0, 764);
      this.pBlack.Name = "pBlack";
      this.pBlack.Size = new System.Drawing.Size(240, 2);
      this.pBlack.TabIndex = 5;
      // 
      // TechnoTypeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pBlack);
      this.Controls.Add(this.pBottom);
      this.Controls.Add(this.pStructure);
      this.Controls.Add(this.pMission);
      this.Controls.Add(this.pCommon2);
      this.Controls.Add(this.pInfantry);
      this.Controls.Add(this.pCommon1);
      this.Controls.Add(this.pTop);
      this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "TechnoTypeControl";
      this.Size = new System.Drawing.Size(240, 766);
      this.pBottom.ResumeLayout(false);
      this.pBottom.PerformLayout();
      this.pTop.ResumeLayout(false);
      this.pTop.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).EndInit();
      this.pCommon1.ResumeLayout(false);
      this.pCommon1.PerformLayout();
      this.pInfantry.ResumeLayout(false);
      this.pInfantry.PerformLayout();
      this.pCommon2.ResumeLayout(false);
      this.pCommon2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudFacing)).EndInit();
      this.pMission.ResumeLayout(false);
      this.pMission.PerformLayout();
      this.pStructure.ResumeLayout(false);
      this.pStructure.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pBottom;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.Label lblXY;
    private System.Windows.Forms.Label lblStrength;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.CheckBox cbSellable;
    private System.Windows.Forms.CheckBox cbRepairable;
    private System.Windows.Forms.NumericUpDown nudY;
    private System.Windows.Forms.NumericUpDown nudX;
    private System.Windows.Forms.NumericUpDown nudStrength;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.ComboBox cbOwner;
    private System.Windows.Forms.Label lblOwner;
    private System.Windows.Forms.Panel pTop;
    private System.Windows.Forms.Panel pCommon1;
    private System.Windows.Forms.Panel pInfantry;
    private System.Windows.Forms.RadioButton rbBR;
    private System.Windows.Forms.RadioButton rbBL;
    private System.Windows.Forms.RadioButton rbTR;
    private System.Windows.Forms.RadioButton rbC;
    private System.Windows.Forms.Label lblSubcell;
    private System.Windows.Forms.RadioButton rbTL;
    private System.Windows.Forms.Panel pCommon2;
    private System.Windows.Forms.NumericUpDown nudFacing;
    private System.Windows.Forms.Label lblTag;
    private System.Windows.Forms.ComboBox cbTag;
    private System.Windows.Forms.Label lblFacing;
    private System.Windows.Forms.Panel pMission;
    private System.Windows.Forms.Panel pStructure;
    private System.Windows.Forms.Label lblMission;
    private System.Windows.Forms.ComboBox cbMission;
    private System.Windows.Forms.Label lblEntity;
    private System.Windows.Forms.Button bShowHide;
    private System.Windows.Forms.Panel pBlack;
    private System.Windows.Forms.Button bDelete;
  }
}
