namespace RA_Mission_Editor.UI.Dialogs
{
  partial class VerifyDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyDialog));
      this.listViewErrors = new System.Windows.Forms.ListBox();
      this.bOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listViewErrors
      // 
      this.listViewErrors.HorizontalScrollbar = true;
      this.listViewErrors.ItemHeight = 20;
      this.listViewErrors.Location = new System.Drawing.Point(16, 6);
      this.listViewErrors.Name = "listViewErrors";
      this.listViewErrors.Size = new System.Drawing.Size(850, 484);
      this.listViewErrors.TabIndex = 1;
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(766, 500);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(100, 32);
      this.bOK.TabIndex = 49;
      this.bOK.Text = "Close";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // VerifyDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(878, 544);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.listViewErrors);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "VerifyDialog";
      this.Text = "Verify Map";
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ListBox listViewErrors;
    private System.Windows.Forms.Button bOK;
  }
}