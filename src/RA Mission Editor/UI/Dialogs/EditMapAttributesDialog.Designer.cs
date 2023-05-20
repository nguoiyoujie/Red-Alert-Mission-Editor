
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class EditMapAttributesDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMapAttributesDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.cbTheater = new System.Windows.Forms.ComboBox();
      this.nudX = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.nudY = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.nudW = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.nudH = new System.Windows.Forms.NumericUpDown();
      this.bCancel = new System.Windows.Forms.Button();
      this.bOK = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudW)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(12, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "Theater";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cbTheater
      // 
      this.cbTheater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTheater.FormattingEnabled = true;
      this.cbTheater.Location = new System.Drawing.Point(121, 6);
      this.cbTheater.Name = "cbTheater";
      this.cbTheater.Size = new System.Drawing.Size(150, 21);
      this.cbTheater.TabIndex = 1;
      // 
      // nudX
      // 
      this.nudX.Location = new System.Drawing.Point(15, 47);
      this.nudX.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
      this.nudX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudX.Name = "nudX";
      this.nudX.Size = new System.Drawing.Size(60, 20);
      this.nudX.TabIndex = 4;
      this.nudX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudX.ValueChanged += new System.EventHandler(this.nudXY_ValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 31);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(13, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "X";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(83, 30);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(13, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Y";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nudY
      // 
      this.nudY.Location = new System.Drawing.Point(81, 47);
      this.nudY.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
      this.nudY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudY.Name = "nudY";
      this.nudY.Size = new System.Drawing.Size(60, 20);
      this.nudY.TabIndex = 4;
      this.nudY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudY.ValueChanged += new System.EventHandler(this.nudXY_ValueChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(144, 30);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Width";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nudW
      // 
      this.nudW.Location = new System.Drawing.Point(147, 47);
      this.nudW.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
      this.nudW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudW.Name = "nudW";
      this.nudW.Size = new System.Drawing.Size(60, 20);
      this.nudW.TabIndex = 4;
      this.nudW.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(208, 31);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(43, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "Height";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nudH
      // 
      this.nudH.Location = new System.Drawing.Point(211, 47);
      this.nudH.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
      this.nudH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudH.Name = "nudH";
      this.nudH.Size = new System.Drawing.Size(60, 20);
      this.nudH.TabIndex = 4;
      this.nudH.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = global::RA_Mission_Editor.Properties.Resources.button_cancel;
      this.bCancel.Location = new System.Drawing.Point(179, 73);
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
      this.bOK.Location = new System.Drawing.Point(12, 73);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 8;
      this.bOK.Text = "Create!";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // EditMapAttributesDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(286, 112);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.nudY);
      this.Controls.Add(this.nudH);
      this.Controls.Add(this.nudW);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.nudX);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbTheater);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "EditMapAttributesDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Set Map Attributes";
      this.Shown += new System.EventHandler(this.EditMapAttributesDialog_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudW)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbTheater;
    private System.Windows.Forms.NumericUpDown nudX;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown nudY;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown nudW;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown nudH;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Button bOK;
  }
}