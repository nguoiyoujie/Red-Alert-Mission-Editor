
namespace RA_Mission_Editor.UI.UserControls
{
  partial class ShpFileEditorControl
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
      this.nudImage = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.bLoadSrcPalette = new System.Windows.Forms.Button();
      this.lblSrcPal = new System.Windows.Forms.Label();
      this.lblSrcTmp = new System.Windows.Forms.Label();
      this.bOpenShp = new System.Windows.Forms.Button();
      this.tbShpRADir = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.bOpenPalS = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.tbPalRADir = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.lblBlocks = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.nudSrcZoom = new System.Windows.Forms.NumericUpDown();
      this.bExportImage = new System.Windows.Forms.Button();
      this.bImportImageReplace = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.bImportImageInsertBefore = new System.Windows.Forms.Button();
      this.bImportImageInsertAfter = new System.Windows.Forms.Button();
      this.bDuplicateImage = new System.Windows.Forms.Button();
      this.bMoveImageNext = new System.Windows.Forms.Button();
      this.bMoveImageBack = new System.Windows.Forms.Button();
      this.bImportImageAdd = new System.Windows.Forms.Button();
      this.bDeleteImage = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.cbRemapColor = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudImage)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(20, 14);
      this.lblTutorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(131, 20);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "Shape File Editor";
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(600, 645);
      this.bOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(138, 49);
      this.bOK.TabIndex = 50;
      this.bOK.Text = "Save as SHP";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bSave_Click);
      // 
      // bLoadShp
      // 
      this.bLoadShp.Location = new System.Drawing.Point(7, 25);
      this.bLoadShp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bLoadShp.Name = "bLoadShp";
      this.bLoadShp.Size = new System.Drawing.Size(138, 49);
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
      this.pbSrc.Location = new System.Drawing.Point(0, 0);
      this.pbSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbSrc.Name = "pbSrc";
      this.pbSrc.Size = new System.Drawing.Size(384, 394);
      this.pbSrc.TabIndex = 61;
      this.pbSrc.TabStop = false;
      // 
      // nudImage
      // 
      this.nudImage.Location = new System.Drawing.Point(334, 232);
      this.nudImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.nudImage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudImage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudImage.Name = "nudImage";
      this.nudImage.Size = new System.Drawing.Size(115, 26);
      this.nudImage.TabIndex = 62;
      this.nudImage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudImage.ValueChanged += new System.EventHandler(this.nudFrameSrc_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(271, 235);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 20);
      this.label1.TabIndex = 63;
      this.label1.Text = "Frame";
      // 
      // bLoadSrcPalette
      // 
      this.bLoadSrcPalette.Location = new System.Drawing.Point(7, 84);
      this.bLoadSrcPalette.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bLoadSrcPalette.Name = "bLoadSrcPalette";
      this.bLoadSrcPalette.Size = new System.Drawing.Size(138, 49);
      this.bLoadSrcPalette.TabIndex = 67;
      this.bLoadSrcPalette.Text = "Load Palette";
      this.bLoadSrcPalette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadSrcPalette.UseVisualStyleBackColor = true;
      this.bLoadSrcPalette.Click += new System.EventHandler(this.bLoadSrcPalette_Click);
      // 
      // lblSrcPal
      // 
      this.lblSrcPal.AutoSize = true;
      this.lblSrcPal.Location = new System.Drawing.Point(660, 144);
      this.lblSrcPal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSrcPal.Name = "lblSrcPal";
      this.lblSrcPal.Size = new System.Drawing.Size(120, 20);
      this.lblSrcPal.TabIndex = 69;
      this.lblSrcPal.Text = "(source palette)";
      // 
      // lblSrcTmp
      // 
      this.lblSrcTmp.AutoSize = true;
      this.lblSrcTmp.Location = new System.Drawing.Point(660, 88);
      this.lblSrcTmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSrcTmp.Name = "lblSrcTmp";
      this.lblSrcTmp.Size = new System.Drawing.Size(104, 20);
      this.lblSrcTmp.TabIndex = 75;
      this.lblSrcTmp.Text = "(source SHP)";
      // 
      // bOpenShp
      // 
      this.bOpenShp.Location = new System.Drawing.Point(318, 25);
      this.bOpenShp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenShp.Name = "bOpenShp";
      this.bOpenShp.Size = new System.Drawing.Size(132, 49);
      this.bOpenShp.TabIndex = 82;
      this.bOpenShp.Text = "Open SHP";
      this.bOpenShp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenShp.UseVisualStyleBackColor = true;
      this.bOpenShp.Click += new System.EventHandler(this.bOpen_Click);
      // 
      // tbShpRADir
      // 
      this.tbShpRADir.Location = new System.Drawing.Point(88, 36);
      this.tbShpRADir.Name = "tbShpRADir";
      this.tbShpRADir.Size = new System.Drawing.Size(223, 26);
      this.tbShpRADir.TabIndex = 81;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.bOpenPalS);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.tbPalRADir);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.tbShpRADir);
      this.groupBox1.Controls.Add(this.bOpenShp);
      this.groupBox1.Location = new System.Drawing.Point(24, 49);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(461, 137);
      this.groupBox1.TabIndex = 83;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "RA Directory";
      // 
      // bOpenPalS
      // 
      this.bOpenPalS.Location = new System.Drawing.Point(318, 84);
      this.bOpenPalS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenPalS.Name = "bOpenPalS";
      this.bOpenPalS.Size = new System.Drawing.Size(132, 49);
      this.bOpenPalS.TabIndex = 86;
      this.bOpenPalS.Text = "Open Palette";
      this.bOpenPalS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenPalS.UseVisualStyleBackColor = true;
      this.bOpenPalS.Click += new System.EventHandler(this.bOpenPalS_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(31, 95);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(31, 20);
      this.label5.TabIndex = 85;
      this.label5.Text = "Pal";
      // 
      // tbPalRADir
      // 
      this.tbPalRADir.Location = new System.Drawing.Point(88, 95);
      this.tbPalRADir.Name = "tbPalRADir";
      this.tbPalRADir.Size = new System.Drawing.Size(223, 26);
      this.tbPalRADir.TabIndex = 84;
      this.tbPalRADir.Text = "temperat.pal";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(31, 36);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 20);
      this.label4.TabIndex = 83;
      this.label4.Text = "SHP";
      // 
      // lblBlocks
      // 
      this.lblBlocks.AutoSize = true;
      this.lblBlocks.Location = new System.Drawing.Point(30, 202);
      this.lblBlocks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblBlocks.Name = "lblBlocks";
      this.lblBlocks.Size = new System.Drawing.Size(80, 20);
      this.lblBlocks.TabIndex = 86;
      this.lblBlocks.Text = "Frames: ?";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(276, 197);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 20);
      this.label7.TabIndex = 88;
      this.label7.Text = "Zoom";
      // 
      // nudSrcZoom
      // 
      this.nudSrcZoom.Location = new System.Drawing.Point(334, 196);
      this.nudSrcZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.nudSrcZoom.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.nudSrcZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudSrcZoom.Name = "nudSrcZoom";
      this.nudSrcZoom.Size = new System.Drawing.Size(75, 26);
      this.nudSrcZoom.TabIndex = 87;
      this.nudSrcZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudSrcZoom.ValueChanged += new System.EventHandler(this.nudSrcZoom_ValueChanged);
      // 
      // bExportImage
      // 
      this.bExportImage.Location = new System.Drawing.Point(416, 274);
      this.bExportImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportImage.Name = "bExportImage";
      this.bExportImage.Size = new System.Drawing.Size(157, 76);
      this.bExportImage.TabIndex = 89;
      this.bExportImage.Text = "Export Image";
      this.bExportImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportImage.UseVisualStyleBackColor = true;
      this.bExportImage.Click += new System.EventHandler(this.bExportImage_Click);
      // 
      // bImportImageReplace
      // 
      this.bImportImageReplace.Location = new System.Drawing.Point(416, 360);
      this.bImportImageReplace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bImportImageReplace.Name = "bImportImageReplace";
      this.bImportImageReplace.Size = new System.Drawing.Size(157, 76);
      this.bImportImageReplace.TabIndex = 90;
      this.bImportImageReplace.Text = "Import Image (Replace this)";
      this.bImportImageReplace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bImportImageReplace.UseVisualStyleBackColor = true;
      this.bImportImageReplace.Click += new System.EventHandler(this.bImportImageReplace_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.bLoadShp);
      this.groupBox2.Controls.Add(this.bLoadSrcPalette);
      this.groupBox2.Location = new System.Drawing.Point(491, 49);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(162, 137);
      this.groupBox2.TabIndex = 97;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Load from File";
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pbSrc);
      this.panel1.Location = new System.Drawing.Point(24, 274);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(384, 394);
      this.panel1.TabIndex = 99;
      // 
      // bImportImageInsertBefore
      // 
      this.bImportImageInsertBefore.Location = new System.Drawing.Point(416, 446);
      this.bImportImageInsertBefore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bImportImageInsertBefore.Name = "bImportImageInsertBefore";
      this.bImportImageInsertBefore.Size = new System.Drawing.Size(157, 76);
      this.bImportImageInsertBefore.TabIndex = 91;
      this.bImportImageInsertBefore.Text = "Import Image (Insert before this)";
      this.bImportImageInsertBefore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bImportImageInsertBefore.UseVisualStyleBackColor = true;
      this.bImportImageInsertBefore.Click += new System.EventHandler(this.bImportImageInsertBefore_Click);
      // 
      // bImportImageInsertAfter
      // 
      this.bImportImageInsertAfter.Location = new System.Drawing.Point(416, 532);
      this.bImportImageInsertAfter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bImportImageInsertAfter.Name = "bImportImageInsertAfter";
      this.bImportImageInsertAfter.Size = new System.Drawing.Size(157, 76);
      this.bImportImageInsertAfter.TabIndex = 100;
      this.bImportImageInsertAfter.Text = "Import Image (Insert after this)";
      this.bImportImageInsertAfter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bImportImageInsertAfter.UseVisualStyleBackColor = true;
      this.bImportImageInsertAfter.Click += new System.EventHandler(this.bImportImageInsertAfter_Click);
      // 
      // bDuplicateImage
      // 
      this.bDuplicateImage.Location = new System.Drawing.Point(581, 274);
      this.bDuplicateImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bDuplicateImage.Name = "bDuplicateImage";
      this.bDuplicateImage.Size = new System.Drawing.Size(157, 76);
      this.bDuplicateImage.TabIndex = 101;
      this.bDuplicateImage.Text = "Duplicate Image";
      this.bDuplicateImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDuplicateImage.UseVisualStyleBackColor = true;
      this.bDuplicateImage.Click += new System.EventHandler(this.bDuplicateImage_Click);
      // 
      // bMoveImageNext
      // 
      this.bMoveImageNext.Location = new System.Drawing.Point(580, 446);
      this.bMoveImageNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bMoveImageNext.Name = "bMoveImageNext";
      this.bMoveImageNext.Size = new System.Drawing.Size(157, 76);
      this.bMoveImageNext.TabIndex = 102;
      this.bMoveImageNext.Text = "Move Image Next";
      this.bMoveImageNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bMoveImageNext.UseVisualStyleBackColor = true;
      this.bMoveImageNext.Click += new System.EventHandler(this.bMoveImageNext_Click);
      // 
      // bMoveImageBack
      // 
      this.bMoveImageBack.Location = new System.Drawing.Point(579, 532);
      this.bMoveImageBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bMoveImageBack.Name = "bMoveImageBack";
      this.bMoveImageBack.Size = new System.Drawing.Size(157, 76);
      this.bMoveImageBack.TabIndex = 103;
      this.bMoveImageBack.Text = "Move Image Back";
      this.bMoveImageBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bMoveImageBack.UseVisualStyleBackColor = true;
      this.bMoveImageBack.Click += new System.EventHandler(this.bMoveImageBack_Click);
      // 
      // bImportImageAdd
      // 
      this.bImportImageAdd.Location = new System.Drawing.Point(415, 618);
      this.bImportImageAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bImportImageAdd.Name = "bImportImageAdd";
      this.bImportImageAdd.Size = new System.Drawing.Size(157, 76);
      this.bImportImageAdd.TabIndex = 104;
      this.bImportImageAdd.Text = "Import Image (Add to end)";
      this.bImportImageAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bImportImageAdd.UseVisualStyleBackColor = true;
      this.bImportImageAdd.Click += new System.EventHandler(this.bImportImageAdd_Click);
      // 
      // bDeleteImage
      // 
      this.bDeleteImage.Location = new System.Drawing.Point(580, 360);
      this.bDeleteImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bDeleteImage.Name = "bDeleteImage";
      this.bDeleteImage.Size = new System.Drawing.Size(157, 76);
      this.bDeleteImage.TabIndex = 105;
      this.bDeleteImage.Text = "Delete Image";
      this.bDeleteImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bDeleteImage.UseVisualStyleBackColor = true;
      this.bDeleteImage.Click += new System.EventHandler(this.bDeleteImage_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(449, 198);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 20);
      this.label3.TabIndex = 107;
      this.label3.Text = "Remap";
      // 
      // cbRemapColor
      // 
      this.cbRemapColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRemapColor.FormattingEnabled = true;
      this.cbRemapColor.Location = new System.Drawing.Point(518, 194);
      this.cbRemapColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cbRemapColor.Name = "cbRemapColor";
      this.cbRemapColor.Size = new System.Drawing.Size(218, 28);
      this.cbRemapColor.TabIndex = 106;
      this.cbRemapColor.SelectedIndexChanged += new System.EventHandler(this.cbRemapColor_SelectedIndexChanged);
      // 
      // ShpFileEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbRemapColor);
      this.Controls.Add(this.bDeleteImage);
      this.Controls.Add(this.bImportImageAdd);
      this.Controls.Add(this.bMoveImageBack);
      this.Controls.Add(this.bMoveImageNext);
      this.Controls.Add(this.bDuplicateImage);
      this.Controls.Add(this.bImportImageInsertAfter);
      this.Controls.Add(this.bImportImageInsertBefore);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.bImportImageReplace);
      this.Controls.Add(this.bExportImage);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.nudSrcZoom);
      this.Controls.Add(this.lblBlocks);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lblSrcTmp);
      this.Controls.Add(this.lblSrcPal);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nudImage);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.lblTutorial);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "ShpFileEditorControl";
      this.Size = new System.Drawing.Size(1200, 788);
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudImage)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblTutorial;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bLoadShp;
    private System.Windows.Forms.PictureBox pbSrc;
    private System.Windows.Forms.NumericUpDown nudImage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button bLoadSrcPalette;
    private System.Windows.Forms.Label lblSrcPal;
    private System.Windows.Forms.Label lblSrcTmp;
    private System.Windows.Forms.Button bOpenShp;
    private System.Windows.Forms.TextBox tbShpRADir;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button bOpenPalS;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbPalRADir;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblBlocks;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown nudSrcZoom;
    private System.Windows.Forms.Button bExportImage;
    private System.Windows.Forms.Button bImportImageReplace;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bImportImageInsertBefore;
    private System.Windows.Forms.Button bImportImageInsertAfter;
    private System.Windows.Forms.Button bDuplicateImage;
    private System.Windows.Forms.Button bMoveImageNext;
    private System.Windows.Forms.Button bMoveImageBack;
    private System.Windows.Forms.Button bImportImageAdd;
    private System.Windows.Forms.Button bDeleteImage;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbRemapColor;
  }
}
