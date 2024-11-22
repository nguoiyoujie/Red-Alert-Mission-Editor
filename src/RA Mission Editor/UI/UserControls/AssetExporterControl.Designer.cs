
namespace RA_Mission_Editor.UI.UserControls
{
  partial class AssetExporterControl
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
      this.bExportTmps = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.bExportShps = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.cbExportMixList = new System.Windows.Forms.ComboBox();
      this.cboxExportMixWithHashNames = new System.Windows.Forms.CheckBox();
      this.bExportMix = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.cboxExportMixPathWithHashNames = new System.Windows.Forms.CheckBox();
      this.bExportMixExt = new System.Windows.Forms.Button();
      this.tbExportMixPath = new System.Windows.Forms.TextBox();
      this.bExportMixPath = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(20, 14);
      this.lblTutorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(114, 20);
      this.lblTutorial.TabIndex = 55;
      this.lblTutorial.Text = "Asset Exporter";
      // 
      // bExportTmps
      // 
      this.bExportTmps.Location = new System.Drawing.Point(7, 27);
      this.bExportTmps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportTmps.Name = "bExportTmps";
      this.bExportTmps.Size = new System.Drawing.Size(132, 49);
      this.bExportTmps.TabIndex = 82;
      this.bExportTmps.Text = "Export TMPs";
      this.bExportTmps.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportTmps.UseVisualStyleBackColor = true;
      this.bExportTmps.Click += new System.EventHandler(this.bExportTmps_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.bExportShps);
      this.groupBox1.Controls.Add(this.bExportTmps);
      this.groupBox1.Location = new System.Drawing.Point(24, 49);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(298, 93);
      this.groupBox1.TabIndex = 83;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "RA Directory";
      // 
      // bExportShps
      // 
      this.bExportShps.Location = new System.Drawing.Point(147, 27);
      this.bExportShps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportShps.Name = "bExportShps";
      this.bExportShps.Size = new System.Drawing.Size(132, 49);
      this.bExportShps.TabIndex = 86;
      this.bExportShps.Text = "Export SHPs";
      this.bExportShps.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportShps.UseVisualStyleBackColor = true;
      this.bExportShps.Click += new System.EventHandler(this.bExportShps_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.cbExportMixList);
      this.groupBox2.Controls.Add(this.cboxExportMixWithHashNames);
      this.groupBox2.Controls.Add(this.bExportMix);
      this.groupBox2.Location = new System.Drawing.Point(24, 157);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(453, 101);
      this.groupBox2.TabIndex = 84;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Mix Extractor";
      // 
      // cbExportMixList
      // 
      this.cbExportMixList.FormattingEnabled = true;
      this.cbExportMixList.Location = new System.Drawing.Point(147, 60);
      this.cbExportMixList.Name = "cbExportMixList";
      this.cbExportMixList.Size = new System.Drawing.Size(288, 28);
      this.cbExportMixList.TabIndex = 84;
      // 
      // cboxExportMixWithHashNames
      // 
      this.cboxExportMixWithHashNames.AutoSize = true;
      this.cboxExportMixWithHashNames.Location = new System.Drawing.Point(147, 25);
      this.cboxExportMixWithHashNames.Name = "cboxExportMixWithHashNames";
      this.cboxExportMixWithHashNames.Size = new System.Drawing.Size(289, 24);
      this.cboxExportMixWithHashNames.TabIndex = 83;
      this.cboxExportMixWithHashNames.Text = "Include unknown (hash-only) names";
      this.cboxExportMixWithHashNames.UseVisualStyleBackColor = true;
      // 
      // bExportMix
      // 
      this.bExportMix.Location = new System.Drawing.Point(7, 27);
      this.bExportMix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportMix.Name = "bExportMix";
      this.bExportMix.Size = new System.Drawing.Size(132, 49);
      this.bExportMix.TabIndex = 82;
      this.bExportMix.Text = "Export";
      this.bExportMix.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportMix.UseVisualStyleBackColor = true;
      this.bExportMix.Click += new System.EventHandler(this.bExportMix_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.bExportMixPath);
      this.groupBox3.Controls.Add(this.tbExportMixPath);
      this.groupBox3.Controls.Add(this.cboxExportMixPathWithHashNames);
      this.groupBox3.Controls.Add(this.bExportMixExt);
      this.groupBox3.Location = new System.Drawing.Point(24, 264);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(453, 101);
      this.groupBox3.TabIndex = 85;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Mix Extractor (External)";
      // 
      // cboxExportMixPathWithHashNames
      // 
      this.cboxExportMixPathWithHashNames.AutoSize = true;
      this.cboxExportMixPathWithHashNames.Location = new System.Drawing.Point(147, 25);
      this.cboxExportMixPathWithHashNames.Name = "cboxExportMixPathWithHashNames";
      this.cboxExportMixPathWithHashNames.Size = new System.Drawing.Size(289, 24);
      this.cboxExportMixPathWithHashNames.TabIndex = 83;
      this.cboxExportMixPathWithHashNames.Text = "Include unknown (hash-only) names";
      this.cboxExportMixPathWithHashNames.UseVisualStyleBackColor = true;
      // 
      // bExportMixExt
      // 
      this.bExportMixExt.Location = new System.Drawing.Point(7, 27);
      this.bExportMixExt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.bExportMixExt.Name = "bExportMixExt";
      this.bExportMixExt.Size = new System.Drawing.Size(132, 49);
      this.bExportMixExt.TabIndex = 82;
      this.bExportMixExt.Text = "Export";
      this.bExportMixExt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bExportMixExt.UseVisualStyleBackColor = true;
      this.bExportMixExt.Click += new System.EventHandler(this.bExportMixExt_Click);
      // 
      // tbExportMixPath
      // 
      this.tbExportMixPath.Location = new System.Drawing.Point(146, 55);
      this.tbExportMixPath.Name = "tbExportMixPath";
      this.tbExportMixPath.Size = new System.Drawing.Size(257, 26);
      this.tbExportMixPath.TabIndex = 84;
      // 
      // bExportMixPath
      // 
      this.bExportMixPath.Location = new System.Drawing.Point(409, 55);
      this.bExportMixPath.Name = "bExportMixPath";
      this.bExportMixPath.Size = new System.Drawing.Size(33, 28);
      this.bExportMixPath.TabIndex = 85;
      this.bExportMixPath.Text = "..";
      this.bExportMixPath.UseVisualStyleBackColor = true;
      this.bExportMixPath.Click += new System.EventHandler(this.bExportMixPath_Click);
      // 
      // AssetExporterControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lblTutorial);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "AssetExporterControl";
      this.Size = new System.Drawing.Size(1200, 788);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblTutorial;
    private System.Windows.Forms.Button bExportTmps;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button bExportShps;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox cbExportMixList;
    private System.Windows.Forms.CheckBox cboxExportMixWithHashNames;
    private System.Windows.Forms.Button bExportMix;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button bExportMixPath;
    private System.Windows.Forms.TextBox tbExportMixPath;
    private System.Windows.Forms.CheckBox cboxExportMixPathWithHashNames;
    private System.Windows.Forms.Button bExportMixExt;
  }
}
