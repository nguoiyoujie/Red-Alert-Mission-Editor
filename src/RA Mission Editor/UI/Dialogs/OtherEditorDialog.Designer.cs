
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
      this.pageEditor = new System.Windows.Forms.TabControl();
      this.pageTmpEditor = new System.Windows.Forms.TabPage();
      this.tmpFileEditorControl1 = new RA_Mission_Editor.UI.UserControls.TmpFileEditorControl();
      this.pageAssetExporter = new System.Windows.Forms.TabPage();
      this.assetExporterControl1 = new RA_Mission_Editor.UI.UserControls.AssetExporterControl();
      this.pageShpEditor = new System.Windows.Forms.TabPage();
      this.shpFileEditorControl1 = new RA_Mission_Editor.UI.UserControls.ShpFileEditorControl();
      this.pageShpConverter.SuspendLayout();
      this.pageLanguageFile.SuspendLayout();
      this.pageEditor.SuspendLayout();
      this.pageTmpEditor.SuspendLayout();
      this.pageAssetExporter.SuspendLayout();
      this.pageShpEditor.SuspendLayout();
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
      // pageEditor
      // 
      this.pageEditor.Controls.Add(this.pageLanguageFile);
      this.pageEditor.Controls.Add(this.pageShpConverter);
      this.pageEditor.Controls.Add(this.pageTmpEditor);
      this.pageEditor.Controls.Add(this.pageShpEditor);
      this.pageEditor.Controls.Add(this.pageAssetExporter);
      this.pageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pageEditor.Location = new System.Drawing.Point(0, 0);
      this.pageEditor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.pageEditor.Name = "pageEditor";
      this.pageEditor.SelectedIndex = 0;
      this.pageEditor.Size = new System.Drawing.Size(1212, 829);
      this.pageEditor.TabIndex = 0;
      this.pageEditor.SelectedIndexChanged += new System.EventHandler(this.tabSelection_SelectedIndexChanged);
      // 
      // pageTmpEditor
      // 
      this.pageTmpEditor.Controls.Add(this.tmpFileEditorControl1);
      this.pageTmpEditor.Location = new System.Drawing.Point(4, 29);
      this.pageTmpEditor.Name = "pageTmpEditor";
      this.pageTmpEditor.Padding = new System.Windows.Forms.Padding(3);
      this.pageTmpEditor.Size = new System.Drawing.Size(1204, 796);
      this.pageTmpEditor.TabIndex = 3;
      this.pageTmpEditor.Text = "Template Editor";
      this.pageTmpEditor.UseVisualStyleBackColor = true;
      // 
      // tmpFileEditorControl1
      // 
      this.tmpFileEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tmpFileEditorControl1.Location = new System.Drawing.Point(3, 3);
      this.tmpFileEditorControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tmpFileEditorControl1.Name = "tmpFileEditorControl1";
      this.tmpFileEditorControl1.Size = new System.Drawing.Size(1198, 790);
      this.tmpFileEditorControl1.TabIndex = 0;
      // 
      // pageAssetExporter
      // 
      this.pageAssetExporter.Controls.Add(this.assetExporterControl1);
      this.pageAssetExporter.Location = new System.Drawing.Point(4, 29);
      this.pageAssetExporter.Name = "pageAssetExporter";
      this.pageAssetExporter.Padding = new System.Windows.Forms.Padding(3);
      this.pageAssetExporter.Size = new System.Drawing.Size(1204, 796);
      this.pageAssetExporter.TabIndex = 4;
      this.pageAssetExporter.Text = "Asset Exporter";
      this.pageAssetExporter.UseVisualStyleBackColor = true;
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
      // pageShpEditor
      // 
      this.pageShpEditor.Controls.Add(this.shpFileEditorControl1);
      this.pageShpEditor.Location = new System.Drawing.Point(4, 29);
      this.pageShpEditor.Name = "pageShpEditor";
      this.pageShpEditor.Padding = new System.Windows.Forms.Padding(3);
      this.pageShpEditor.Size = new System.Drawing.Size(1204, 796);
      this.pageShpEditor.TabIndex = 5;
      this.pageShpEditor.Text = "Shape File Editor";
      this.pageShpEditor.UseVisualStyleBackColor = true;
      // 
      // shpFileEditorControl1
      // 
      this.shpFileEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.shpFileEditorControl1.Location = new System.Drawing.Point(3, 3);
      this.shpFileEditorControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.shpFileEditorControl1.Name = "shpFileEditorControl1";
      this.shpFileEditorControl1.Size = new System.Drawing.Size(1198, 790);
      this.shpFileEditorControl1.TabIndex = 0;
      // 
      // OtherEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1212, 829);
      this.Controls.Add(this.pageEditor);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "OtherEditorDialog";
      this.Text = "Editor";
      this.pageShpConverter.ResumeLayout(false);
      this.pageLanguageFile.ResumeLayout(false);
      this.pageEditor.ResumeLayout(false);
      this.pageTmpEditor.ResumeLayout(false);
      this.pageAssetExporter.ResumeLayout(false);
      this.pageShpEditor.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage pageShpConverter;
    private UserControls.ShpPaletteConverterControl shpPaletteConverterControl1;
    private System.Windows.Forms.TabPage pageLanguageFile;
    private UserControls.LanguageFileControl languageFileControl1;
    private System.Windows.Forms.TabControl pageEditor;
    private System.Windows.Forms.TabPage pageTmpEditor;
    private UserControls.TmpFileEditorControl tmpFileEditorControl1;
    private System.Windows.Forms.TabPage pageAssetExporter;
    private UserControls.AssetExporterControl assetExporterControl1;
    private System.Windows.Forms.TabPage pageShpEditor;
    private UserControls.ShpFileEditorControl shpFileEditorControl1;
  }
}