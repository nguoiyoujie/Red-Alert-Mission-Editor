
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class TestMapDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestMapDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rbHard = new System.Windows.Forms.RadioButton();
      this.rbNormal = new System.Windows.Forms.RadioButton();
      this.rbEasy = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(411, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "You are about to run the map on RA95. Please choose the game settings to continue" +
    ".";
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(245, 69);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 0;
      this.bOK.Text = "Play!";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(343, 69);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 1;
      this.bCancel.Text = "Cancel";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rbHard);
      this.groupBox1.Controls.Add(this.rbNormal);
      this.groupBox1.Controls.Add(this.rbEasy);
      this.groupBox1.Location = new System.Drawing.Point(12, 25);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(422, 38);
      this.groupBox1.TabIndex = 53;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Difficulty";
      // 
      // rbHard
      // 
      this.rbHard.AutoSize = true;
      this.rbHard.Location = new System.Drawing.Point(363, 15);
      this.rbHard.Name = "rbHard";
      this.rbHard.Size = new System.Drawing.Size(48, 17);
      this.rbHard.TabIndex = 2;
      this.rbHard.Text = "Hard";
      this.rbHard.UseVisualStyleBackColor = true;
      // 
      // rbNormal
      // 
      this.rbNormal.AutoSize = true;
      this.rbNormal.Checked = true;
      this.rbNormal.Location = new System.Drawing.Point(177, 15);
      this.rbNormal.Name = "rbNormal";
      this.rbNormal.Size = new System.Drawing.Size(58, 17);
      this.rbNormal.TabIndex = 1;
      this.rbNormal.TabStop = true;
      this.rbNormal.Text = "Normal";
      this.rbNormal.UseVisualStyleBackColor = true;
      // 
      // rbEasy
      // 
      this.rbEasy.AutoSize = true;
      this.rbEasy.Location = new System.Drawing.Point(6, 15);
      this.rbEasy.Name = "rbEasy";
      this.rbEasy.Size = new System.Drawing.Size(48, 17);
      this.rbEasy.TabIndex = 0;
      this.rbEasy.Text = "Easy";
      this.rbEasy.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.ForeColor = System.Drawing.Color.DarkRed;
      this.label2.Location = new System.Drawing.Point(9, 69);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(230, 35);
      this.label2.TabIndex = 54;
      this.label2.Text = "Note: Only the modified game executable by lovalmidas can preload the mission.";
      // 
      // TestMapDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(447, 113);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.label1);
      this.Name = "TestMapDialog";
      this.Text = "Test Map";
      this.Shown += new System.EventHandler(this.TestMapDialog_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton rbHard;
    private System.Windows.Forms.RadioButton rbNormal;
    private System.Windows.Forms.RadioButton rbEasy;
    private System.Windows.Forms.Label label2;
  }
}