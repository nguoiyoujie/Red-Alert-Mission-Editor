
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class EditPreplaceEntityDialog
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPreplaceEntityDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.cbOwner = new System.Windows.Forms.ComboBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.nudStrength = new System.Windows.Forms.NumericUpDown();
      this.nudFacing = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbMission = new System.Windows.Forms.ComboBox();
      this.tbType = new System.Windows.Forms.TextBox();
      this.cbSellable = new System.Windows.Forms.CheckBox();
      this.cbRepairable = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFacing)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Owner";
      // 
      // cbOwner
      // 
      this.cbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbOwner.FormattingEnabled = true;
      this.cbOwner.Location = new System.Drawing.Point(107, 6);
      this.cbOwner.Name = "cbOwner";
      this.cbOwner.Size = new System.Drawing.Size(121, 21);
      this.cbOwner.TabIndex = 2;
      this.cbOwner.MouseEnter += new System.EventHandler(this.cbOwner_MouseEnter);
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(11, 463);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 10;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(135, 463);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 9;
      this.bCancel.Text = "Cancel";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // nudStrength
      // 
      this.nudStrength.Location = new System.Drawing.Point(107, 60);
      this.nudStrength.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.nudStrength.Name = "nudStrength";
      this.nudStrength.Size = new System.Drawing.Size(120, 20);
      this.nudStrength.TabIndex = 11;
      this.nudStrength.MouseEnter += new System.EventHandler(this.nudStrength_MouseEnter);
      // 
      // nudFacing
      // 
      this.nudFacing.Location = new System.Drawing.Point(107, 86);
      this.nudFacing.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudFacing.Name = "nudFacing";
      this.nudFacing.Size = new System.Drawing.Size(120, 20);
      this.nudFacing.TabIndex = 14;
      this.nudFacing.MouseEnter += new System.EventHandler(this.nudFacing_MouseEnter);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 36);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "Type";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 62);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 13);
      this.label3.TabIndex = 18;
      this.label3.Text = "Strength";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 88);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(91, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "Facing (0-255)";
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(11, 162);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.Size = new System.Drawing.Size(216, 295);
      this.tbHint.TabIndex = 22;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 115);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(49, 13);
      this.label7.TabIndex = 26;
      this.label7.Text = "Mission";
      // 
      // cbMission
      // 
      this.cbMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbMission.FormattingEnabled = true;
      this.cbMission.Location = new System.Drawing.Point(107, 112);
      this.cbMission.Name = "cbMission";
      this.cbMission.Size = new System.Drawing.Size(121, 21);
      this.cbMission.TabIndex = 25;
      this.cbMission.MouseEnter += new System.EventHandler(this.cbMission_MouseEnter);
      // 
      // tbType
      // 
      this.tbType.Location = new System.Drawing.Point(107, 33);
      this.tbType.Name = "tbType";
      this.tbType.ReadOnly = true;
      this.tbType.Size = new System.Drawing.Size(120, 20);
      this.tbType.TabIndex = 33;
      // 
      // cbSellable
      // 
      this.cbSellable.AutoSize = true;
      this.cbSellable.Location = new System.Drawing.Point(107, 139);
      this.cbSellable.Name = "cbSellable";
      this.cbSellable.Size = new System.Drawing.Size(92, 17);
      this.cbSellable.TabIndex = 35;
      this.cbSellable.Text = "AI Sellable";
      this.cbSellable.UseVisualStyleBackColor = true;
      this.cbSellable.MouseEnter += new System.EventHandler(this.cbSellable_MouseEnter);
      // 
      // cbRepairable
      // 
      this.cbRepairable.AutoSize = true;
      this.cbRepairable.Location = new System.Drawing.Point(21, 139);
      this.cbRepairable.Name = "cbRepairable";
      this.cbRepairable.Size = new System.Drawing.Size(80, 17);
      this.cbRepairable.TabIndex = 34;
      this.cbRepairable.Text = "AI Repair";
      this.cbRepairable.UseVisualStyleBackColor = true;
      this.cbRepairable.MouseEnter += new System.EventHandler(this.cbRepairable_MouseEnter);
      // 
      // EditPreplaceEntityDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(243, 507);
      this.Controls.Add(this.cbSellable);
      this.Controls.Add(this.cbRepairable);
      this.Controls.Add(this.tbType);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.cbMission);
      this.Controls.Add(this.tbHint);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nudFacing);
      this.Controls.Add(this.nudStrength);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.cbOwner);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.Name = "EditPreplaceEntityDialog";
      this.Text = "Set Entity Properties";
      this.Shown += new System.EventHandler(this.EditPreplaceEntityDialog_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFacing)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbOwner;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.NumericUpDown nudStrength;
    private System.Windows.Forms.NumericUpDown nudFacing;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbMission;
    private System.Windows.Forms.TextBox tbType;
    private System.Windows.Forms.CheckBox cbSellable;
    private System.Windows.Forms.CheckBox cbRepairable;
  }
}