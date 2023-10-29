
namespace RA_Mission_Editor.UI.UserControls
{
  partial class ShpPaletteConverterControl
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
      this.lblTutorial = new System.Windows.Forms.Label();
      this.bOK = new System.Windows.Forms.Button();
      this.bLoadShp = new System.Windows.Forms.Button();
      this.pbSrc = new System.Windows.Forms.PictureBox();
      this.nudFrameSrc = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.nudFrameDst = new System.Windows.Forms.NumericUpDown();
      this.pbDst = new System.Windows.Forms.PictureBox();
      this.bLoadSrcPalette = new System.Windows.Forms.Button();
      this.bLoadDestPal = new System.Windows.Forms.Button();
      this.lblSrcPal = new System.Windows.Forms.Label();
      this.lblDstPal = new System.Windows.Forms.Label();
      this.cbPreserveHouseColors = new System.Windows.Forms.CheckBox();
      this.cbRemapColor = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbPalSrcTD = new System.Windows.Forms.CheckBox();
      this.lblSrcShp = new System.Windows.Forms.Label();
      this.lblProgressText = new System.Windows.Forms.Label();
      this.pbSrcPal = new System.Windows.Forms.PictureBox();
      this.pbDstPal = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameDst)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDst)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrcPal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDstPal)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(13, 9);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(114, 13);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "SHP Palette Converter";
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(695, 362);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 50;
      this.bOK.Text = "Save";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bSave_Click);
      // 
      // bLoadShp
      // 
      this.bLoadShp.Location = new System.Drawing.Point(16, 36);
      this.bLoadShp.Name = "bLoadShp";
      this.bLoadShp.Size = new System.Drawing.Size(92, 32);
      this.bLoadShp.TabIndex = 49;
      this.bLoadShp.Text = "Load SHP file";
      this.bLoadShp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadShp.UseVisualStyleBackColor = true;
      this.bLoadShp.Click += new System.EventHandler(this.bLoadShp_Click);
      // 
      // pbSrc
      // 
      this.pbSrc.BackColor = System.Drawing.Color.Black;
      this.pbSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbSrc.Location = new System.Drawing.Point(16, 100);
      this.pbSrc.Name = "pbSrc";
      this.pbSrc.Size = new System.Drawing.Size(256, 256);
      this.pbSrc.TabIndex = 61;
      this.pbSrc.TabStop = false;
      // 
      // nudFrameSrc
      // 
      this.nudFrameSrc.Location = new System.Drawing.Point(58, 74);
      this.nudFrameSrc.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameSrc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameSrc.Name = "nudFrameSrc";
      this.nudFrameSrc.Size = new System.Drawing.Size(120, 20);
      this.nudFrameSrc.TabIndex = 62;
      this.nudFrameSrc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameSrc.ValueChanged += new System.EventHandler(this.nudFrameSrc_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 76);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 63;
      this.label1.Text = "Frame";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(531, 76);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 13);
      this.label2.TabIndex = 66;
      this.label2.Text = "Frame";
      // 
      // nudFrameDst
      // 
      this.nudFrameDst.Location = new System.Drawing.Point(573, 74);
      this.nudFrameDst.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameDst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameDst.Name = "nudFrameDst";
      this.nudFrameDst.Size = new System.Drawing.Size(120, 20);
      this.nudFrameDst.TabIndex = 65;
      this.nudFrameDst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudFrameDst.ValueChanged += new System.EventHandler(this.nudFrameDst_ValueChanged);
      // 
      // pbDst
      // 
      this.pbDst.BackColor = System.Drawing.Color.Black;
      this.pbDst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbDst.Location = new System.Drawing.Point(531, 100);
      this.pbDst.Name = "pbDst";
      this.pbDst.Size = new System.Drawing.Size(256, 256);
      this.pbDst.TabIndex = 64;
      this.pbDst.TabStop = false;
      // 
      // bLoadSrcPalette
      // 
      this.bLoadSrcPalette.Location = new System.Drawing.Point(180, 36);
      this.bLoadSrcPalette.Name = "bLoadSrcPalette";
      this.bLoadSrcPalette.Size = new System.Drawing.Size(92, 32);
      this.bLoadSrcPalette.TabIndex = 67;
      this.bLoadSrcPalette.Text = "Load Palette";
      this.bLoadSrcPalette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadSrcPalette.UseVisualStyleBackColor = true;
      this.bLoadSrcPalette.Click += new System.EventHandler(this.bLoadSrcPalette_Click);
      // 
      // bLoadDestPal
      // 
      this.bLoadDestPal.Location = new System.Drawing.Point(531, 36);
      this.bLoadDestPal.Name = "bLoadDestPal";
      this.bLoadDestPal.Size = new System.Drawing.Size(92, 32);
      this.bLoadDestPal.TabIndex = 68;
      this.bLoadDestPal.Text = "Load Palette";
      this.bLoadDestPal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadDestPal.UseVisualStyleBackColor = true;
      this.bLoadDestPal.Click += new System.EventHandler(this.bLoadDestPal_Click);
      // 
      // lblSrcPal
      // 
      this.lblSrcPal.AutoSize = true;
      this.lblSrcPal.Location = new System.Drawing.Point(278, 100);
      this.lblSrcPal.Name = "lblSrcPal";
      this.lblSrcPal.Size = new System.Drawing.Size(80, 13);
      this.lblSrcPal.TabIndex = 69;
      this.lblSrcPal.Text = "(source palette)";
      // 
      // lblDstPal
      // 
      this.lblDstPal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDstPal.AutoSize = true;
      this.lblDstPal.Location = new System.Drawing.Point(426, 343);
      this.lblDstPal.Name = "lblDstPal";
      this.lblDstPal.Size = new System.Drawing.Size(99, 13);
      this.lblDstPal.TabIndex = 70;
      this.lblDstPal.Text = "(destination palette)";
      // 
      // cbPreserveHouseColors
      // 
      this.cbPreserveHouseColors.AutoSize = true;
      this.cbPreserveHouseColors.Checked = true;
      this.cbPreserveHouseColors.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPreserveHouseColors.Location = new System.Drawing.Point(281, 129);
      this.cbPreserveHouseColors.Name = "cbPreserveHouseColors";
      this.cbPreserveHouseColors.Size = new System.Drawing.Size(134, 17);
      this.cbPreserveHouseColors.TabIndex = 71;
      this.cbPreserveHouseColors.Text = "Preserve House Colors";
      this.cbPreserveHouseColors.UseVisualStyleBackColor = true;
      this.cbPreserveHouseColors.CheckedChanged += new System.EventHandler(this.cbPreserveHouseColors_CheckedChanged);
      // 
      // cbRemapColor
      // 
      this.cbRemapColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRemapColor.FormattingEnabled = true;
      this.cbRemapColor.Location = new System.Drawing.Point(531, 364);
      this.cbRemapColor.Name = "cbRemapColor";
      this.cbRemapColor.Size = new System.Drawing.Size(147, 21);
      this.cbRemapColor.TabIndex = 72;
      this.cbRemapColor.SelectedIndexChanged += new System.EventHandler(this.cbRemapColor_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(484, 367);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 13);
      this.label3.TabIndex = 73;
      this.label3.Text = "Remap";
      // 
      // cbPalSrcTD
      // 
      this.cbPalSrcTD.AutoSize = true;
      this.cbPalSrcTD.Checked = true;
      this.cbPalSrcTD.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPalSrcTD.Location = new System.Drawing.Point(281, 152);
      this.cbPalSrcTD.Name = "cbPalSrcTD";
      this.cbPalSrcTD.Size = new System.Drawing.Size(118, 17);
      this.cbPalSrcTD.TabIndex = 74;
      this.cbPalSrcTD.Text = "Palette is Tib Dawn";
      this.cbPalSrcTD.UseVisualStyleBackColor = true;
      this.cbPalSrcTD.CheckedChanged += new System.EventHandler(this.cbPalSrcTD_CheckedChanged);
      // 
      // lblSrcShp
      // 
      this.lblSrcShp.AutoSize = true;
      this.lblSrcShp.Location = new System.Drawing.Point(278, 76);
      this.lblSrcShp.Name = "lblSrcShp";
      this.lblSrcShp.Size = new System.Drawing.Size(70, 13);
      this.lblSrcShp.TabIndex = 75;
      this.lblSrcShp.Text = "(source SHP)";
      // 
      // lblProgressText
      // 
      this.lblProgressText.AutoSize = true;
      this.lblProgressText.BackColor = System.Drawing.Color.Black;
      this.lblProgressText.ForeColor = System.Drawing.Color.Yellow;
      this.lblProgressText.Location = new System.Drawing.Point(540, 110);
      this.lblProgressText.Name = "lblProgressText";
      this.lblProgressText.Size = new System.Drawing.Size(53, 13);
      this.lblProgressText.TabIndex = 76;
      this.lblProgressText.Text = "(progress)";
      // 
      // pbSrcPal
      // 
      this.pbSrcPal.BackColor = System.Drawing.Color.Black;
      this.pbSrcPal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbSrcPal.Location = new System.Drawing.Point(275, 211);
      this.pbSrcPal.Margin = new System.Windows.Forms.Padding(0);
      this.pbSrcPal.Name = "pbSrcPal";
      this.pbSrcPal.Size = new System.Drawing.Size(120, 120);
      this.pbSrcPal.TabIndex = 77;
      this.pbSrcPal.TabStop = false;
      // 
      // pbDstPal
      // 
      this.pbDstPal.BackColor = System.Drawing.Color.Black;
      this.pbDstPal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbDstPal.Location = new System.Drawing.Point(408, 211);
      this.pbDstPal.Margin = new System.Windows.Forms.Padding(0);
      this.pbDstPal.Name = "pbDstPal";
      this.pbDstPal.Size = new System.Drawing.Size(120, 120);
      this.pbDstPal.TabIndex = 78;
      this.pbDstPal.TabStop = false;
      // 
      // ShpPaletteConverterControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pbDstPal);
      this.Controls.Add(this.pbSrcPal);
      this.Controls.Add(this.lblProgressText);
      this.Controls.Add(this.lblSrcShp);
      this.Controls.Add(this.cbPalSrcTD);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbRemapColor);
      this.Controls.Add(this.cbPreserveHouseColors);
      this.Controls.Add(this.lblDstPal);
      this.Controls.Add(this.lblSrcPal);
      this.Controls.Add(this.bLoadDestPal);
      this.Controls.Add(this.bLoadSrcPalette);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nudFrameDst);
      this.Controls.Add(this.pbDst);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nudFrameSrc);
      this.Controls.Add(this.pbSrc);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bLoadShp);
      this.Controls.Add(this.lblTutorial);
      this.Name = "ShpPaletteConverterControl";
      this.Size = new System.Drawing.Size(800, 512);
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameDst)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDst)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrcPal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDstPal)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblTutorial;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bLoadShp;
    private System.Windows.Forms.PictureBox pbSrc;
    private System.Windows.Forms.NumericUpDown nudFrameSrc;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown nudFrameDst;
    private System.Windows.Forms.PictureBox pbDst;
    private System.Windows.Forms.Button bLoadSrcPalette;
    private System.Windows.Forms.Button bLoadDestPal;
    private System.Windows.Forms.Label lblSrcPal;
    private System.Windows.Forms.Label lblDstPal;
    private System.Windows.Forms.CheckBox cbPreserveHouseColors;
    private System.Windows.Forms.ComboBox cbRemapColor;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox cbPalSrcTD;
    private System.Windows.Forms.Label lblSrcShp;
    private System.Windows.Forms.Label lblProgressText;
    private System.Windows.Forms.PictureBox pbSrcPal;
    private System.Windows.Forms.PictureBox pbDstPal;
  }
}
