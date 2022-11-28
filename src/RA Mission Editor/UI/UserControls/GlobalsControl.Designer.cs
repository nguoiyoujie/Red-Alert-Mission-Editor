
namespace RA_Mission_Editor.UI.UserControls
{
  partial class GlobalsControl
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
      this.bDelete = new System.Windows.Forms.Button();
      this.bOK = new System.Windows.Forms.Button();
      this.tbGlobalList = new System.Windows.Forms.TextBox();
      this.nudIndex = new System.Windows.Forms.NumericUpDown();
      this.tbLine = new System.Windows.Forms.TextBox();
      this.lblTutorial = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
      this.SuspendLayout();
      // 
      // bDelete
      // 
      this.bDelete.Location = new System.Drawing.Point(736, 25);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(61, 20);
      this.bDelete.TabIndex = 65;
      this.bDelete.Text = "Delete";
      this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDelete.UseVisualStyleBackColor = true;
      this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(672, 25);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(61, 20);
      this.bOK.TabIndex = 64;
      this.bOK.Text = "Set";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bSet_Click);
      // 
      // tbGlobalList
      // 
      this.tbGlobalList.Location = new System.Drawing.Point(3, 51);
      this.tbGlobalList.Multiline = true;
      this.tbGlobalList.Name = "tbGlobalList";
      this.tbGlobalList.ReadOnly = true;
      this.tbGlobalList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbGlobalList.Size = new System.Drawing.Size(794, 458);
      this.tbGlobalList.TabIndex = 63;
      this.tbGlobalList.WordWrap = false;
      // 
      // nudIndex
      // 
      this.nudIndex.Location = new System.Drawing.Point(3, 25);
      this.nudIndex.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
      this.nudIndex.Name = "nudIndex";
      this.nudIndex.Size = new System.Drawing.Size(118, 20);
      this.nudIndex.TabIndex = 62;
      this.nudIndex.ValueChanged += new System.EventHandler(this.nudIndex_ValueChanged);
      // 
      // tbLine
      // 
      this.tbLine.Location = new System.Drawing.Point(127, 25);
      this.tbLine.Name = "tbLine";
      this.tbLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLine.Size = new System.Drawing.Size(539, 20);
      this.tbLine.TabIndex = 60;
      this.tbLine.WordWrap = false;
      this.tbLine.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(13, 9);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(83, 13);
      this.lblTutorial.TabIndex = 61;
      this.lblTutorial.Text = "Global Variables";
      // 
      // GlobalsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bDelete);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.tbGlobalList);
      this.Controls.Add(this.nudIndex);
      this.Controls.Add(this.tbLine);
      this.Controls.Add(this.lblTutorial);
      this.Name = "GlobalsControl";
      this.Size = new System.Drawing.Size(800, 512);
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bDelete;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.TextBox tbGlobalList;
    private System.Windows.Forms.NumericUpDown nudIndex;
    private System.Windows.Forms.TextBox tbLine;
    private System.Windows.Forms.Label lblTutorial;
  }
}
