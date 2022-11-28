
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TutorialControl
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
      this.tbLine = new System.Windows.Forms.TextBox();
      this.lblTutorial = new System.Windows.Forms.Label();
      this.nudIndex = new System.Windows.Forms.NumericUpDown();
      this.tbTutorialList = new System.Windows.Forms.TextBox();
      this.bSet = new System.Windows.Forms.Button();
      this.bDelete = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
      this.SuspendLayout();
      // 
      // tbLine
      // 
      this.tbLine.Location = new System.Drawing.Point(127, 25);
      this.tbLine.Name = "tbLine";
      this.tbLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLine.Size = new System.Drawing.Size(539, 20);
      this.tbLine.TabIndex = 54;
      this.tbLine.WordWrap = false;
      this.tbLine.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(13, 9);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(66, 13);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "Mission Text";
      // 
      // nudIndex
      // 
      this.nudIndex.Location = new System.Drawing.Point(3, 25);
      this.nudIndex.Maximum = new decimal(new int[] {
            1028,
            0,
            0,
            0});
      this.nudIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudIndex.Name = "nudIndex";
      this.nudIndex.Size = new System.Drawing.Size(118, 20);
      this.nudIndex.TabIndex = 56;
      this.nudIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudIndex.ValueChanged += new System.EventHandler(this.nudIndex_ValueChanged);
      // 
      // tbTutorialList
      // 
      this.tbTutorialList.Location = new System.Drawing.Point(3, 51);
      this.tbTutorialList.Multiline = true;
      this.tbTutorialList.Name = "tbTutorialList";
      this.tbTutorialList.ReadOnly = true;
      this.tbTutorialList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTutorialList.Size = new System.Drawing.Size(794, 458);
      this.tbTutorialList.TabIndex = 57;
      this.tbTutorialList.WordWrap = false;
      // 
      // bSet
      // 
      this.bSet.Location = new System.Drawing.Point(672, 25);
      this.bSet.Name = "bSet";
      this.bSet.Size = new System.Drawing.Size(61, 20);
      this.bSet.TabIndex = 58;
      this.bSet.Text = "Set";
      this.bSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bSet.UseVisualStyleBackColor = true;
      this.bSet.Click += new System.EventHandler(this.bSet_Click);
      // 
      // bDelete
      // 
      this.bDelete.Location = new System.Drawing.Point(736, 25);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(61, 20);
      this.bDelete.TabIndex = 59;
      this.bDelete.Text = "Delete";
      this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDelete.UseVisualStyleBackColor = true;
      this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
      // 
      // TutorialControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bDelete);
      this.Controls.Add(this.bSet);
      this.Controls.Add(this.tbTutorialList);
      this.Controls.Add(this.nudIndex);
      this.Controls.Add(this.tbLine);
      this.Controls.Add(this.lblTutorial);
      this.Name = "TutorialControl";
      this.Size = new System.Drawing.Size(800, 512);
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbLine;
    private System.Windows.Forms.Label lblTutorial;
    private System.Windows.Forms.NumericUpDown nudIndex;
    private System.Windows.Forms.TextBox tbTutorialList;
    private System.Windows.Forms.Button bSet;
    private System.Windows.Forms.Button bDelete;
  }
}
