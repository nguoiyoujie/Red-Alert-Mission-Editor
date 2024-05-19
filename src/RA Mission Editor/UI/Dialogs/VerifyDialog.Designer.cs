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
      this.label1 = new System.Windows.Forms.Label();
      this.listViewErrors = new System.Windows.Forms.ListBox();
      this.bOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(105, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Verifying Map";
      // 
      // listViewErrors
      // 
      this.listViewErrors.Location = new System.Drawing.Point(16, 46);
      this.listViewErrors.Name = "listViewErrors";
      this.listViewErrors.Size = new System.Drawing.Size(539, 298);
      this.listViewErrors.TabIndex = 1;
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(455, 350);
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
      this.ClientSize = new System.Drawing.Size(578, 394);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.listViewErrors);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "VerifyDialog";
      this.Text = "Verify Map";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox listViewErrors;
    private System.Windows.Forms.Button bOK;
  }
}