
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class ShiftMapDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftMapDialog));
      this.nudX = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.nudY = new System.Windows.Forms.NumericUpDown();
      this.bCancel = new System.Windows.Forms.Button();
      this.bOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
      this.SuspendLayout();
      // 
      // nudX
      // 
      this.nudX.Location = new System.Drawing.Point(18, 76);
      this.nudX.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
      this.nudX.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
      this.nudX.Name = "nudX";
      this.nudX.Size = new System.Drawing.Size(60, 20);
      this.nudX.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(13, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "X";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(86, 59);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(13, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Y";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nudY
      // 
      this.nudY.Location = new System.Drawing.Point(84, 76);
      this.nudY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
      this.nudY.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
      this.nudY.Name = "nudY";
      this.nudY.Size = new System.Drawing.Size(60, 20);
      this.nudY.TabIndex = 4;
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = global::RA_Mission_Editor.Properties.Resources.button_cancel;
      this.bCancel.Location = new System.Drawing.Point(182, 102);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 7;
      this.bCancel.Text = "Cancel";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(15, 102);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 8;
      this.bOK.Text = "OK";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(205, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Shift map along these directions.";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      this.label4.ForeColor = System.Drawing.Color.DarkRed;
      this.label4.Location = new System.Drawing.Point(12, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(262, 35);
      this.label4.TabIndex = 9;
      this.label4.Text = "Note: Objects and terrain shifted past the playable border will be deleted!";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ShiftMapDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(286, 146);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.nudY);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.nudX);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "ShiftMapDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Shift Map";
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.NumericUpDown nudX;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown nudY;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
  }
}