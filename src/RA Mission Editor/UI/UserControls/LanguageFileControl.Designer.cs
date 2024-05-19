
namespace RA_Mission_Editor.UI.UserControls
{
  partial class LanguageFileControl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.bOK = new System.Windows.Forms.Button();
      this.bOpen = new System.Windows.Forms.Button();
      this.bOpenRADir = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbLine
      // 
      this.tbLine.Location = new System.Drawing.Point(190, 38);
      this.tbLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tbLine.Name = "tbLine";
      this.tbLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLine.Size = new System.Drawing.Size(806, 26);
      this.tbLine.TabIndex = 54;
      this.tbLine.WordWrap = false;
      this.tbLine.TextChanged += new System.EventHandler(this.Value_Changed);
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(20, 14);
      this.lblTutorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(59, 20);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "Strings";
      // 
      // nudIndex
      // 
      this.nudIndex.Location = new System.Drawing.Point(4, 38);
      this.nudIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
      this.nudIndex.Size = new System.Drawing.Size(177, 26);
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
      this.tbTutorialList.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tbTutorialList.Location = new System.Drawing.Point(0, 81);
      this.tbTutorialList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tbTutorialList.Multiline = true;
      this.tbTutorialList.Name = "tbTutorialList";
      this.tbTutorialList.ReadOnly = true;
      this.tbTutorialList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTutorialList.Size = new System.Drawing.Size(1200, 641);
      this.tbTutorialList.TabIndex = 57;
      this.tbTutorialList.WordWrap = false;
      // 
      // bSet
      // 
      this.bSet.Location = new System.Drawing.Point(1008, 38);
      this.bSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bSet.Name = "bSet";
      this.bSet.Size = new System.Drawing.Size(92, 31);
      this.bSet.TabIndex = 58;
      this.bSet.Text = "Set";
      this.bSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bSet.UseVisualStyleBackColor = true;
      this.bSet.Click += new System.EventHandler(this.bSet_Click);
      // 
      // bDelete
      // 
      this.bDelete.Location = new System.Drawing.Point(1104, 38);
      this.bDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(92, 31);
      this.bDelete.TabIndex = 59;
      this.bDelete.Text = "Delete";
      this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDelete.UseVisualStyleBackColor = true;
      this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.bOpenRADir);
      this.panel1.Controls.Add(this.bOK);
      this.panel1.Controls.Add(this.bOpen);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 722);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1200, 66);
      this.panel1.TabIndex = 60;
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(1049, 10);
      this.bOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(138, 49);
      this.bOK.TabIndex = 50;
      this.bOK.Text = "Save";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bOpen
      // 
      this.bOpen.Location = new System.Drawing.Point(232, 10);
      this.bOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpen.Name = "bOpen";
      this.bOpen.Size = new System.Drawing.Size(138, 49);
      this.bOpen.TabIndex = 49;
      this.bOpen.Text = "Open";
      this.bOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpen.UseVisualStyleBackColor = true;
      this.bOpen.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // bOpenRADir
      // 
      this.bOpenRADir.Location = new System.Drawing.Point(24, 10);
      this.bOpenRADir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenRADir.Name = "bOpenRADir";
      this.bOpenRADir.Size = new System.Drawing.Size(200, 49);
      this.bOpenRADir.TabIndex = 51;
      this.bOpenRADir.Text = "Open conquer.eng";
      this.bOpenRADir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenRADir.UseVisualStyleBackColor = true;
      this.bOpenRADir.Click += new System.EventHandler(this.bOpenRADir_Click);
      // 
      // LanguageFileControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bDelete);
      this.Controls.Add(this.bSet);
      this.Controls.Add(this.tbTutorialList);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.nudIndex);
      this.Controls.Add(this.tbLine);
      this.Controls.Add(this.lblTutorial);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "LanguageFileControl";
      this.Size = new System.Drawing.Size(1200, 788);
      ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
      this.panel1.ResumeLayout(false);
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
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bOpen;
    private System.Windows.Forms.Button bOpenRADir;
  }
}
