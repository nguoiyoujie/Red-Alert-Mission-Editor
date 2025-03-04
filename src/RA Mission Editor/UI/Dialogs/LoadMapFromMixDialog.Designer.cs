namespace RA_Mission_Editor.UI.Dialogs
{
  partial class LoadMapFromMixDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadMapFromMixDialog));
      this.listViewFiles = new System.Windows.Forms.ListBox();
      this.bOK = new System.Windows.Forms.Button();
      this.bClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listViewFiles
      // 
      this.listViewFiles.HorizontalScrollbar = true;
      this.listViewFiles.ItemHeight = 20;
      this.listViewFiles.Location = new System.Drawing.Point(16, 6);
      this.listViewFiles.Name = "listViewFiles";
      this.listViewFiles.Size = new System.Drawing.Size(850, 684);
      this.listViewFiles.TabIndex = 1;
      this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
      // 
      // bOK
      // 
      this.bOK.Enabled = false;
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(660, 700);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(100, 32);
      this.bOK.TabIndex = 49;
      this.bOK.Text = "Load";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bClose
      // 
      this.bClose.Location = new System.Drawing.Point(766, 700);
      this.bClose.Name = "bClose";
      this.bClose.Size = new System.Drawing.Size(100, 32);
      this.bClose.TabIndex = 50;
      this.bClose.Text = "Close";
      this.bClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bClose.UseVisualStyleBackColor = true;
      this.bClose.Click += new System.EventHandler(this.bClose_Click);
      // 
      // LoadMapFromMixDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(878, 744);
      this.Controls.Add(this.bClose);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.listViewFiles);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "LoadMapFromMixDialog";
      this.Text = "Load Map from Mix";
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ListBox listViewFiles;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bClose;
  }
}