
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
      this.pageGlobals = new System.Windows.Forms.TabPage();
      this.pageTeamTypes = new System.Windows.Forms.TabPage();
      this.pageShpConverter = new System.Windows.Forms.TabPage();
      this.pageLanguageFile = new System.Windows.Forms.TabPage();
      this.languageFileControl1 = new RA_Mission_Editor.UI.UserControls.LanguageFileControl();
      this.tabSelection = new System.Windows.Forms.TabControl();
      this.shpPaletteConverterControl1 = new RA_Mission_Editor.UI.UserControls.ShpPaletteConverterControl();
      this.pageShpConverter.SuspendLayout();
      this.pageLanguageFile.SuspendLayout();
      this.tabSelection.SuspendLayout();
      this.SuspendLayout();
      // 
      // pageGlobals
      // 
      this.pageGlobals.Location = new System.Drawing.Point(4, 22);
      this.pageGlobals.Name = "pageGlobals";
      this.pageGlobals.Padding = new System.Windows.Forms.Padding(3);
      this.pageGlobals.Size = new System.Drawing.Size(800, 513);
      this.pageGlobals.TabIndex = 5;
      this.pageGlobals.Text = "Global Variables";
      this.pageGlobals.UseVisualStyleBackColor = true;
      // 
      // pageTeamTypes
      // 
      this.pageTeamTypes.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageTeamTypes.Location = new System.Drawing.Point(4, 22);
      this.pageTeamTypes.Name = "pageTeamTypes";
      this.pageTeamTypes.Padding = new System.Windows.Forms.Padding(3);
      this.pageTeamTypes.Size = new System.Drawing.Size(800, 513);
      this.pageTeamTypes.TabIndex = 1;
      this.pageTeamTypes.Text = "TeamTypes";
      // 
      // pageShpConverter
      // 
      this.pageShpConverter.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageShpConverter.Controls.Add(this.shpPaletteConverterControl1);
      this.pageShpConverter.Location = new System.Drawing.Point(4, 22);
      this.pageShpConverter.Name = "pageShpConverter";
      this.pageShpConverter.Padding = new System.Windows.Forms.Padding(3);
      this.pageShpConverter.Size = new System.Drawing.Size(800, 513);
      this.pageShpConverter.TabIndex = 0;
      this.pageShpConverter.Text = "Shp Palette Converter";
      // 
      // pageLanguageFile
      // 
      this.pageLanguageFile.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageLanguageFile.Controls.Add(this.languageFileControl1);
      this.pageLanguageFile.Location = new System.Drawing.Point(4, 22);
      this.pageLanguageFile.Name = "pageLanguageFile";
      this.pageLanguageFile.Padding = new System.Windows.Forms.Padding(3);
      this.pageLanguageFile.Size = new System.Drawing.Size(800, 513);
      this.pageLanguageFile.TabIndex = 2;
      this.pageLanguageFile.Text = "Strings Editor";
      // 
      // languageFileControl1
      // 
      this.languageFileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.languageFileControl1.Location = new System.Drawing.Point(3, 3);
      this.languageFileControl1.Name = "languageFileControl1";
      this.languageFileControl1.Size = new System.Drawing.Size(794, 507);
      this.languageFileControl1.TabIndex = 0;
      // 
      // tabSelection
      // 
      this.tabSelection.Controls.Add(this.pageLanguageFile);
      this.tabSelection.Controls.Add(this.pageShpConverter);
      this.tabSelection.Controls.Add(this.pageTeamTypes);
      this.tabSelection.Controls.Add(this.pageGlobals);
      this.tabSelection.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabSelection.Location = new System.Drawing.Point(0, 0);
      this.tabSelection.Name = "tabSelection";
      this.tabSelection.SelectedIndex = 0;
      this.tabSelection.Size = new System.Drawing.Size(808, 539);
      this.tabSelection.TabIndex = 0;
      this.tabSelection.SelectedIndexChanged += new System.EventHandler(this.tabSelection_SelectedIndexChanged);
      // 
      // shpPaletteConverterControl1
      // 
      this.shpPaletteConverterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.shpPaletteConverterControl1.Location = new System.Drawing.Point(3, 3);
      this.shpPaletteConverterControl1.Name = "shpPaletteConverterControl1";
      this.shpPaletteConverterControl1.Size = new System.Drawing.Size(794, 507);
      this.shpPaletteConverterControl1.TabIndex = 0;
      // 
      // OtherEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(808, 539);
      this.Controls.Add(this.tabSelection);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "OtherEditorDialog";
      this.Text = "Editor";
      this.pageShpConverter.ResumeLayout(false);
      this.pageLanguageFile.ResumeLayout(false);
      this.tabSelection.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage pageGlobals;
    private System.Windows.Forms.TabPage pageTeamTypes;
    private System.Windows.Forms.TabPage pageShpConverter;
    private System.Windows.Forms.TabPage pageLanguageFile;
    private System.Windows.Forms.TabControl tabSelection;
    private UserControls.LanguageFileControl languageFileControl1;
    private UserControls.ShpPaletteConverterControl shpPaletteConverterControl1;
  }
}