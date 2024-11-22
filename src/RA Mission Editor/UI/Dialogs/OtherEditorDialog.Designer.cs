
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class OtherEditorDialog
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
      this.pageShpConverter = new System.Windows.Forms.TabPage();
      this.shpPaletteConverterControl1 = new RA_Mission_Editor.UI.UserControls.ShpPaletteConverterControl();
      this.pageLanguageFile = new System.Windows.Forms.TabPage();
      this.languageFileControl1 = new RA_Mission_Editor.UI.UserControls.LanguageFileControl();
      this.pageTmpViewer = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tmpFileViewerControl1 = new RA_Mission_Editor.UI.UserControls.TmpFileViewerControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.assetExporterControl1 = new RA_Mission_Editor.UI.UserControls.AssetExporterControl();
      this.pageShpConverter.SuspendLayout();
      this.pageLanguageFile.SuspendLayout();
      this.pageTmpViewer.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // pageShpConverter
      // 
      this.pageShpConverter.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageShpConverter.Controls.Add(this.shpPaletteConverterControl1);
      this.pageShpConverter.Location = new System.Drawing.Point(4, 29);
      this.pageShpConverter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageShpConverter.Name = "pageShpConverter";
      this.pageShpConverter.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageShpConverter.Size = new System.Drawing.Size(1204, 796);
      this.pageShpConverter.TabIndex = 0;
      this.pageShpConverter.Text = "Shp Palette Converter";
      // 
      // shpPaletteConverterControl1
      // 
      this.shpPaletteConverterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.shpPaletteConverterControl1.Location = new System.Drawing.Point(4, 5);
      this.shpPaletteConverterControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
      this.shpPaletteConverterControl1.Name = "shpPaletteConverterControl1";
      this.shpPaletteConverterControl1.Size = new System.Drawing.Size(1196, 786);
      this.shpPaletteConverterControl1.TabIndex = 0;
      // 
      // pageLanguageFile
      // 
      this.pageLanguageFile.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageLanguageFile.Controls.Add(this.languageFileControl1);
      this.pageLanguageFile.Location = new System.Drawing.Point(4, 29);
      this.pageLanguageFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageLanguageFile.Name = "pageLanguageFile";
      this.pageLanguageFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageLanguageFile.Size = new System.Drawing.Size(1204, 796);
      this.pageLanguageFile.TabIndex = 2;
      this.pageLanguageFile.Text = "Strings Editor";
      // 
      // languageFileControl1
      // 
      this.languageFileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.languageFileControl1.Location = new System.Drawing.Point(4, 5);
      this.languageFileControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
      this.languageFileControl1.Name = "languageFileControl1";
      this.languageFileControl1.Size = new System.Drawing.Size(1196, 786);
      this.languageFileControl1.TabIndex = 0;
      // 
      // pageTmpViewer
      // 
      this.pageTmpViewer.Controls.Add(this.pageLanguageFile);
      this.pageTmpViewer.Controls.Add(this.pageShpConverter);
      this.pageTmpViewer.Controls.Add(this.tabPage1);
      this.pageTmpViewer.Controls.Add(this.tabPage2);
      this.pageTmpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pageTmpViewer.Location = new System.Drawing.Point(0, 0);
      this.pageTmpViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageTmpViewer.Name = "pageTmpViewer";
      this.pageTmpViewer.SelectedIndex = 0;
      this.pageTmpViewer.Size = new System.Drawing.Size(1212, 829);
      this.pageTmpViewer.TabIndex = 0;
      this.pageTmpViewer.SelectedIndexChanged += new System.EventHandler(this.tabSelection_SelectedIndexChanged);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.tmpFileViewerControl1);
      this.tabPage1.Location = new System.Drawing.Point(4, 29);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1204, 796);
      this.tabPage1.TabIndex = 3;
      this.tabPage1.Text = "Template Viewer";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tmpFileViewerControl1
      // 
      this.tmpFileViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tmpFileViewerControl1.Location = new System.Drawing.Point(3, 3);
      this.tmpFileViewerControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tmpFileViewerControl1.Name = "tmpFileViewerControl1";
      this.tmpFileViewerControl1.Size = new System.Drawing.Size(1198, 790);
      this.tmpFileViewerControl1.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.assetExporterControl1);
      this.tabPage2.Location = new System.Drawing.Point(4, 29);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1204, 796);
      this.tabPage2.TabIndex = 4;
      this.tabPage2.Text = "Asset Exporter";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // assetExporterControl1
      // 
      this.assetExporterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.assetExporterControl1.Location = new System.Drawing.Point(3, 3);
      this.assetExporterControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.assetExporterControl1.Name = "assetExporterControl1";
      this.assetExporterControl1.Size = new System.Drawing.Size(1198, 790);
      this.assetExporterControl1.TabIndex = 0;
      // 
      // OtherEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1212, 829);
      this.Controls.Add(this.pageTmpViewer);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "OtherEditorDialog";
      this.Text = "Editor";
      this.pageShpConverter.ResumeLayout(false);
      this.pageLanguageFile.ResumeLayout(false);
      this.pageTmpViewer.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage pageShpConverter;
    private UserControls.ShpPaletteConverterControl shpPaletteConverterControl1;
    private System.Windows.Forms.TabPage pageLanguageFile;
    private UserControls.LanguageFileControl languageFileControl1;
    private System.Windows.Forms.TabControl pageTmpViewer;
    private System.Windows.Forms.TabPage tabPage1;
    private UserControls.TmpFileViewerControl tmpFileViewerControl1;
    private System.Windows.Forms.TabPage tabPage2;
    private UserControls.AssetExporterControl assetExporterControl1;
  }
}