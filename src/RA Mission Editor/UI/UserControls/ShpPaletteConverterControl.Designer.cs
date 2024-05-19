
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.bOpenPalD = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.tbPalDRADir = new System.Windows.Forms.TextBox();
      this.bOpenPalRA = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.tbPalRADir = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tbShpRADir = new System.Windows.Forms.TextBox();
      this.bOpenShpRA = new System.Windows.Forms.Button();
      this.nudSrcZoom = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.nudDstZoom = new System.Windows.Forms.NumericUpDown();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameSrc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameDst)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDst)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrcPal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDstPal)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDstZoom)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(20, 14);
      this.lblTutorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(169, 20);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "SHP Palette Converter";
      // 
      // bOK
      // 
      this.bOK.Location = new System.Drawing.Point(1042, 731);
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
      this.bLoadShp.Location = new System.Drawing.Point(7, 27);
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
      this.pbSrc.Location = new System.Drawing.Point(24, 306);
      this.pbSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbSrc.Name = "pbSrc";
      this.pbSrc.Size = new System.Drawing.Size(384, 394);
      this.pbSrc.TabIndex = 61;
      this.pbSrc.TabStop = false;
      // 
      // nudFrameSrc
      // 
      this.nudFrameSrc.Location = new System.Drawing.Point(87, 266);
      this.nudFrameSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
      this.nudFrameSrc.Size = new System.Drawing.Size(180, 26);
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
      this.label1.Location = new System.Drawing.Point(24, 269);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 20);
      this.label1.TabIndex = 63;
      this.label1.Text = "Frame";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(796, 269);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 20);
      this.label2.TabIndex = 66;
      this.label2.Text = "Frame";
      // 
      // nudFrameDst
      // 
      this.nudFrameDst.Location = new System.Drawing.Point(860, 266);
      this.nudFrameDst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
      this.nudFrameDst.Size = new System.Drawing.Size(180, 26);
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
      this.pbDst.Location = new System.Drawing.Point(796, 306);
      this.pbDst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pbDst.Name = "pbDst";
      this.pbDst.Size = new System.Drawing.Size(384, 394);
      this.pbDst.TabIndex = 64;
      this.pbDst.TabStop = false;
      // 
      // bLoadSrcPalette
      // 
      this.bLoadSrcPalette.Location = new System.Drawing.Point(7, 86);
      this.bLoadSrcPalette.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bLoadSrcPalette.Name = "bLoadSrcPalette";
      this.bLoadSrcPalette.Size = new System.Drawing.Size(138, 49);
      this.bLoadSrcPalette.TabIndex = 67;
      this.bLoadSrcPalette.Text = "Load Palette";
      this.bLoadSrcPalette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadSrcPalette.UseVisualStyleBackColor = true;
      this.bLoadSrcPalette.Click += new System.EventHandler(this.bLoadSrcPalette_Click);
      // 
      // bLoadDestPal
      // 
      this.bLoadDestPal.Location = new System.Drawing.Point(7, 142);
      this.bLoadDestPal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bLoadDestPal.Name = "bLoadDestPal";
      this.bLoadDestPal.Size = new System.Drawing.Size(138, 57);
      this.bLoadDestPal.TabIndex = 68;
      this.bLoadDestPal.Text = "Load Target Palette";
      this.bLoadDestPal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bLoadDestPal.UseVisualStyleBackColor = true;
      this.bLoadDestPal.Click += new System.EventHandler(this.bLoadDestPal_Click);
      // 
      // lblSrcPal
      // 
      this.lblSrcPal.AutoSize = true;
      this.lblSrcPal.Location = new System.Drawing.Point(652, 149);
      this.lblSrcPal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSrcPal.Name = "lblSrcPal";
      this.lblSrcPal.Size = new System.Drawing.Size(120, 20);
      this.lblSrcPal.TabIndex = 69;
      this.lblSrcPal.Text = "(source palette)";
      // 
      // lblDstPal
      // 
      this.lblDstPal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDstPal.AutoSize = true;
      this.lblDstPal.Location = new System.Drawing.Point(652, 208);
      this.lblDstPal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDstPal.Name = "lblDstPal";
      this.lblDstPal.Size = new System.Drawing.Size(150, 20);
      this.lblDstPal.TabIndex = 70;
      this.lblDstPal.Text = "(destination palette)";
      // 
      // cbPreserveHouseColors
      // 
      this.cbPreserveHouseColors.AutoSize = true;
      this.cbPreserveHouseColors.Checked = true;
      this.cbPreserveHouseColors.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPreserveHouseColors.Location = new System.Drawing.Point(422, 350);
      this.cbPreserveHouseColors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cbPreserveHouseColors.Name = "cbPreserveHouseColors";
      this.cbPreserveHouseColors.Size = new System.Drawing.Size(197, 24);
      this.cbPreserveHouseColors.TabIndex = 71;
      this.cbPreserveHouseColors.Text = "Preserve House Colors";
      this.cbPreserveHouseColors.UseVisualStyleBackColor = true;
      this.cbPreserveHouseColors.CheckedChanged += new System.EventHandler(this.cbPreserveHouseColors_CheckedChanged);
      // 
      // cbRemapColor
      // 
      this.cbRemapColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRemapColor.FormattingEnabled = true;
      this.cbRemapColor.Location = new System.Drawing.Point(796, 710);
      this.cbRemapColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cbRemapColor.Name = "cbRemapColor";
      this.cbRemapColor.Size = new System.Drawing.Size(218, 28);
      this.cbRemapColor.TabIndex = 72;
      this.cbRemapColor.SelectedIndexChanged += new System.EventHandler(this.cbRemapColor_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(726, 715);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 20);
      this.label3.TabIndex = 73;
      this.label3.Text = "Remap";
      // 
      // cbPalSrcTD
      // 
      this.cbPalSrcTD.AutoSize = true;
      this.cbPalSrcTD.Checked = true;
      this.cbPalSrcTD.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPalSrcTD.Location = new System.Drawing.Point(422, 386);
      this.cbPalSrcTD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cbPalSrcTD.Name = "cbPalSrcTD";
      this.cbPalSrcTD.Size = new System.Drawing.Size(170, 24);
      this.cbPalSrcTD.TabIndex = 74;
      this.cbPalSrcTD.Text = "Palette is Tib Dawn";
      this.cbPalSrcTD.UseVisualStyleBackColor = true;
      this.cbPalSrcTD.CheckedChanged += new System.EventHandler(this.cbPalSrcTD_CheckedChanged);
      // 
      // lblSrcShp
      // 
      this.lblSrcShp.AutoSize = true;
      this.lblSrcShp.Location = new System.Drawing.Point(652, 87);
      this.lblSrcShp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSrcShp.Name = "lblSrcShp";
      this.lblSrcShp.Size = new System.Drawing.Size(104, 20);
      this.lblSrcShp.TabIndex = 75;
      this.lblSrcShp.Text = "(source SHP)";
      // 
      // lblProgressText
      // 
      this.lblProgressText.AutoSize = true;
      this.lblProgressText.BackColor = System.Drawing.Color.Black;
      this.lblProgressText.ForeColor = System.Drawing.Color.Yellow;
      this.lblProgressText.Location = new System.Drawing.Point(810, 321);
      this.lblProgressText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblProgressText.Name = "lblProgressText";
      this.lblProgressText.Size = new System.Drawing.Size(81, 20);
      this.lblProgressText.TabIndex = 76;
      this.lblProgressText.Text = "(progress)";
      // 
      // pbSrcPal
      // 
      this.pbSrcPal.BackColor = System.Drawing.Color.Black;
      this.pbSrcPal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbSrcPal.Location = new System.Drawing.Point(412, 477);
      this.pbSrcPal.Margin = new System.Windows.Forms.Padding(0);
      this.pbSrcPal.Name = "pbSrcPal";
      this.pbSrcPal.Size = new System.Drawing.Size(180, 185);
      this.pbSrcPal.TabIndex = 77;
      this.pbSrcPal.TabStop = false;
      // 
      // pbDstPal
      // 
      this.pbDstPal.BackColor = System.Drawing.Color.Black;
      this.pbDstPal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbDstPal.Location = new System.Drawing.Point(612, 477);
      this.pbDstPal.Margin = new System.Windows.Forms.Padding(0);
      this.pbDstPal.Name = "pbDstPal";
      this.pbDstPal.Size = new System.Drawing.Size(180, 185);
      this.pbDstPal.TabIndex = 78;
      this.pbDstPal.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.bOpenPalD);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.tbPalDRADir);
      this.groupBox1.Controls.Add(this.bOpenPalRA);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.tbPalRADir);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.tbShpRADir);
      this.groupBox1.Controls.Add(this.bOpenShpRA);
      this.groupBox1.Location = new System.Drawing.Point(24, 48);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(459, 206);
      this.groupBox1.TabIndex = 84;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "RA Directory";
      // 
      // bOpenPalD
      // 
      this.bOpenPalD.Location = new System.Drawing.Point(318, 143);
      this.bOpenPalD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenPalD.Name = "bOpenPalD";
      this.bOpenPalD.Size = new System.Drawing.Size(127, 56);
      this.bOpenPalD.TabIndex = 92;
      this.bOpenPalD.Text = "Open Target Palette";
      this.bOpenPalD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenPalD.UseVisualStyleBackColor = true;
      this.bOpenPalD.Click += new System.EventHandler(this.bOpenPalD_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 157);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(81, 20);
      this.label6.TabIndex = 91;
      this.label6.Text = "Target Pal";
      // 
      // tbPalDRADir
      // 
      this.tbPalDRADir.Location = new System.Drawing.Point(88, 155);
      this.tbPalDRADir.Name = "tbPalDRADir";
      this.tbPalDRADir.Size = new System.Drawing.Size(223, 26);
      this.tbPalDRADir.TabIndex = 90;
      // 
      // bOpenPalRA
      // 
      this.bOpenPalRA.Location = new System.Drawing.Point(318, 84);
      this.bOpenPalRA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenPalRA.Name = "bOpenPalRA";
      this.bOpenPalRA.Size = new System.Drawing.Size(127, 49);
      this.bOpenPalRA.TabIndex = 86;
      this.bOpenPalRA.Text = "Open Palette";
      this.bOpenPalRA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenPalRA.UseVisualStyleBackColor = true;
      this.bOpenPalRA.Click += new System.EventHandler(this.bOpenPalRA_Click);
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
      this.label4.Size = new System.Drawing.Size(42, 20);
      this.label4.TabIndex = 83;
      this.label4.Text = "SHP";
      // 
      // tbShpRADir
      // 
      this.tbShpRADir.Location = new System.Drawing.Point(88, 36);
      this.tbShpRADir.Name = "tbShpRADir";
      this.tbShpRADir.Size = new System.Drawing.Size(223, 26);
      this.tbShpRADir.TabIndex = 81;
      // 
      // bOpenShpRA
      // 
      this.bOpenShpRA.Location = new System.Drawing.Point(318, 25);
      this.bOpenShpRA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bOpenShpRA.Name = "bOpenShpRA";
      this.bOpenShpRA.Size = new System.Drawing.Size(127, 49);
      this.bOpenShpRA.TabIndex = 82;
      this.bOpenShpRA.Text = "Open SHP";
      this.bOpenShpRA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOpenShpRA.UseVisualStyleBackColor = true;
      this.bOpenShpRA.Click += new System.EventHandler(this.bOpenShpRA_Click);
      // 
      // nudSrcZoom
      // 
      this.nudSrcZoom.Location = new System.Drawing.Point(333, 267);
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
      this.nudSrcZoom.TabIndex = 85;
      this.nudSrcZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudSrcZoom.ValueChanged += new System.EventHandler(this.nubSrcZoom_ValueChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(275, 268);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 20);
      this.label7.TabIndex = 86;
      this.label7.Text = "Zoom";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(1048, 266);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(50, 20);
      this.label8.TabIndex = 88;
      this.label8.Text = "Zoom";
      // 
      // nudDstZoom
      // 
      this.nudDstZoom.Location = new System.Drawing.Point(1106, 265);
      this.nudDstZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.nudDstZoom.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.nudDstZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDstZoom.Name = "nudDstZoom";
      this.nudDstZoom.Size = new System.Drawing.Size(75, 26);
      this.nudDstZoom.TabIndex = 87;
      this.nudDstZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDstZoom.ValueChanged += new System.EventHandler(this.nudDstZoom_ValueChanged);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.bLoadSrcPalette);
      this.groupBox2.Controls.Add(this.bLoadShp);
      this.groupBox2.Controls.Add(this.bLoadDestPal);
      this.groupBox2.Location = new System.Drawing.Point(489, 48);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(156, 206);
      this.groupBox2.TabIndex = 98;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Load from File";
      // 
      // ShpPaletteConverterControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.nudDstZoom);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.nudSrcZoom);
      this.Controls.Add(this.groupBox1);
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
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nudFrameDst);
      this.Controls.Add(this.pbDst);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nudFrameSrc);
      this.Controls.Add(this.pbSrc);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.lblTutorial);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "ShpPaletteConverterControl";
      this.Size = new System.Drawing.Size(1200, 788);
      ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameSrc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFrameDst)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDst)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbSrcPal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDstPal)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrcZoom)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDstZoom)).EndInit();
      this.groupBox2.ResumeLayout(false);
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
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button bOpenPalRA;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbPalRADir;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbShpRADir;
    private System.Windows.Forms.Button bOpenShpRA;
    private System.Windows.Forms.Button bOpenPalD;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tbPalDRADir;
    private System.Windows.Forms.NumericUpDown nudSrcZoom;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.NumericUpDown nudDstZoom;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}
