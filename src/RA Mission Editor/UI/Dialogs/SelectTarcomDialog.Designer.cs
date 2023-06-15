
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class SelectTarcomDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTarcomDialog));
      this.label4 = new System.Windows.Forms.Label();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.nudID = new System.Windows.Forms.NumericUpDown();
      this.cbRTTI = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudID)).BeginInit();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(371, 19);
      this.label4.TabIndex = 60;
      this.label4.Text = "Select Target by its RTTIType and ID";
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(193, 56);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 62;
      this.bOK.Text = "Select";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(291, 56);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 61;
      this.bCancel.Text = "Cancel";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 34);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 65;
      this.label1.Text = "RTTI";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(243, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(19, 13);
      this.label2.TabIndex = 66;
      this.label2.Text = "ID";
      // 
      // nudID
      // 
      this.nudID.Location = new System.Drawing.Point(291, 30);
      this.nudID.Maximum = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
      this.nudID.Name = "nudID";
      this.nudID.Size = new System.Drawing.Size(92, 20);
      this.nudID.TabIndex = 67;
      // 
      // cbRTTI
      // 
      this.cbRTTI.FormattingEnabled = true;
      this.cbRTTI.Location = new System.Drawing.Point(60, 30);
      this.cbRTTI.Name = "cbRTTI";
      this.cbRTTI.Size = new System.Drawing.Size(155, 21);
      this.cbRTTI.TabIndex = 68;
      // 
      // SelectTarcomDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(395, 96);
      this.Controls.Add(this.cbRTTI);
      this.Controls.Add(this.nudID);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.label4);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "SelectTarcomDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Target";
      this.Shown += new System.EventHandler(this.NewIniKeyDialog_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.nudID)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown nudID;
    private System.Windows.Forms.ComboBox cbRTTI;
  }
}