
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TmpFileViewerControl
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
      this.pbSingle = new System.Windows.Forms.PictureBox();
      this.bLoadSrcPalette = new System.Windows.Forms.Button();
      this.lblSrcPal = new System.Windows.Forms.Label();
      this.lblSrcTmp = new System.Windows.Forms.Label();
      this.bOpenTmp = new System.Windows.Forms.Button();
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
      this.bImportImage = new System.Windows.Forms.Button();
      this.pbTileTypes = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbTileType = new System.Windows.Forms.ComboBox();
      this.bSetSingle = new System.Windows.Forms.Button();
      this.bSetAll = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudImage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSingle)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbTileTypes)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(20, 14);
      this.lblTutorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(127, 20);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "Template Viewer";
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(955, 725);
      this.bOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(138, 49);
      this.bOK.TabIndex = 50;
      this.bOK.Text = "Save";
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
      this.bLoadShp.Text = "Load TMP file";
      this.bLoadShp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadShp.UseVisualStyleBackColor = true;
      this.bLoadShp.Click += new System.EventHandler(this.bLoadShp_Click);
      // 
      // pbSrc
      // 
      this.pbSrc.BackColor = System.Drawing.Color.Black;
      this.pbSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbSrc.Location = new System.Drawing.Point(24, 232);
      this.pbSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbSrc.Name = "pbSrc";
      this.pbSrc.Size = new System.Drawing.Size(384, 394);
      this.pbSrc.TabIndex = 61;
      this.pbSrc.TabStop = false;
      // 
      // nudImage
      // 
      this.nudImage.Location = new System.Drawing.Point(871, 272);
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
      this.label1.Location = new System.Drawing.Point(808, 275);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 20);
      this.label1.TabIndex = 63;
      this.label1.Text = "Image";
      // 
      // pbSingle
      // 
      this.pbSingle.BackColor = System.Drawing.Color.Black;
      this.pbSingle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbSingle.Location = new System.Drawing.Point(808, 342);
      this.pbSingle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbSingle.Name = "pbSingle";
      this.pbSingle.Size = new System.Drawing.Size(285, 285);
      this.pbSingle.TabIndex = 64;
      this.pbSingle.TabStop = false;
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
      this.lblSrcTmp.Size = new System.Drawing.Size(103, 20);
      this.lblSrcTmp.TabIndex = 75;
      this.lblSrcTmp.Text = "(source TMP)";
      // 
      // bOpenTmp
      // 
      this.bOpenTmp.Location = new System.Drawing.Point(318, 25);
      this.bOpenTmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenTmp.Name = "bOpenTmp";
      this.bOpenTmp.Size = new System.Drawing.Size(132, 49);
      this.bOpenTmp.TabIndex = 82;
      this.bOpenTmp.Text = "Open TMP";
      this.bOpenTmp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenTmp.UseVisualStyleBackColor = true;
      this.bOpenTmp.Click += new System.EventHandler(this.bOpen_Click);
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
      this.groupBox1.Controls.Add(this.bOpenTmp);
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
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(31, 36);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 20);
      this.label4.TabIndex = 83;
      this.label4.Text = "TMP";
      // 
      // lblBlocks
      // 
      this.lblBlocks.AutoSize = true;
      this.lblBlocks.Location = new System.Drawing.Point(30, 202);
      this.lblBlocks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblBlocks.Name = "lblBlocks";
      this.lblBlocks.Size = new System.Drawing.Size(97, 20);
      this.lblBlocks.TabIndex = 86;
      this.lblBlocks.Text = "Blocks: ? x ?";
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
      this.bExportImage.Location = new System.Drawing.Point(24, 636);
      this.bExportImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportImage.Name = "bExportImage";
      this.bExportImage.Size = new System.Drawing.Size(138, 49);
      this.bExportImage.TabIndex = 89;
      this.bExportImage.Text = "Export Image";
      this.bExportImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportImage.UseVisualStyleBackColor = true;
      this.bExportImage.Click += new System.EventHandler(this.bExportImage_Click);
      // 
      // bImportImage
      // 
      this.bImportImage.Location = new System.Drawing.Point(170, 638);
      this.bImportImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bImportImage.Name = "bImportImage";
      this.bImportImage.Size = new System.Drawing.Size(138, 49);
      this.bImportImage.TabIndex = 90;
      this.bImportImage.Text = "Import Image";
      this.bImportImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bImportImage.UseVisualStyleBackColor = true;
      this.bImportImage.Click += new System.EventHandler(this.bImportImage_Click);
      // 
      // pbTileTypes
      // 
      this.pbTileTypes.BackColor = System.Drawing.Color.Black;
      this.pbTileTypes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbTileTypes.Location = new System.Drawing.Point(416, 232);
      this.pbTileTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbTileTypes.Name = "pbTileTypes";
      this.pbTileTypes.Size = new System.Drawing.Size(384, 394);
      this.pbTileTypes.TabIndex = 91;
      this.pbTileTypes.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(821, 309);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 20);
      this.label2.TabIndex = 93;
      this.label2.Text = "Type";
      // 
      // cbTileType
      // 
      this.cbTileType.FormattingEnabled = true;
      this.cbTileType.Location = new System.Drawing.Point(871, 306);
      this.cbTileType.Name = "cbTileType";
      this.cbTileType.Size = new System.Drawing.Size(115, 28);
      this.cbTileType.TabIndex = 94;
      // 
      // bSetSingle
      // 
      this.bSetSingle.Location = new System.Drawing.Point(994, 291);
      this.bSetSingle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bSetSingle.Name = "bSetSingle";
      this.bSetSingle.Size = new System.Drawing.Size(57, 43);
      this.bSetSingle.TabIndex = 95;
      this.bSetSingle.Text = "Set";
      this.bSetSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bSetSingle.UseVisualStyleBackColor = true;
      this.bSetSingle.Click += new System.EventHandler(this.bSetSingle_Click);
      // 
      // bSetAll
      // 
      this.bSetAll.Location = new System.Drawing.Point(1059, 291);
      this.bSetAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bSetAll.Name = "bSetAll";
      this.bSetAll.Size = new System.Drawing.Size(82, 43);
      this.bSetAll.TabIndex = 96;
      this.bSetAll.Text = "Set All";
      this.bSetAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bSetAll.UseVisualStyleBackColor = true;
      this.bSetAll.Click += new System.EventHandler(this.bSetAll_Click);
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
      // TmpFileViewerControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.bSetAll);
      this.Controls.Add(this.bSetSingle);
      this.Controls.Add(this.cbTileType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pbTileTypes);
      this.Controls.Add(this.bImportImage);
      this.Controls.Add(this.bExportImage);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.nudSrcZoom);
      this.Controls.Add(this.lblBlocks);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lblSrcTmp);
      this.Controls.Add(this.lblSrcPal);
      this.Controls.Add(this.pbSingle);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nudImage);
      this.Controls.Add(this.pbSrc);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.lblTutorial);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "TmpFileViewerControl";
      this.Size = new System.Drawing.Size(1200, 788);
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudImage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSingle)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbTileTypes)).EndInit();
      this.groupBox2.ResumeLayout(false);
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
    private System.Windows.Forms.PictureBox pbSingle;
    private System.Windows.Forms.Button bLoadSrcPalette;
    private System.Windows.Forms.Label lblSrcPal;
    private System.Windows.Forms.Label lblSrcTmp;
    private System.Windows.Forms.Button bOpenTmp;
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
    private System.Windows.Forms.Button bImportImage;
    private System.Windows.Forms.PictureBox pbTileTypes;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbTileType;
    private System.Windows.Forms.Button bSetSingle;
    private System.Windows.Forms.Button bSetAll;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}
