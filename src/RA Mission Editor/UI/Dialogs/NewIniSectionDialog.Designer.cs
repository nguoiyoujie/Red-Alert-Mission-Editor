
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class NewIniSectionDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewIniSectionDialog));
      this.label4 = new System.Windows.Forms.Label();
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.tbHeader = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(371, 19);
      this.label4.TabIndex = 60;
      this.label4.Text = "Enter the header name for the new Section";
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(193, 57);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 62;
      this.bOK.Text = "Create";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(291, 57);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 61;
      this.bCancel.Text = "Cancel";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // tbHeader
      // 
      this.tbHeader.Location = new System.Drawing.Point(12, 31);
      this.tbHeader.Name = "tbHeader";
      this.tbHeader.Size = new System.Drawing.Size(371, 20);
      this.tbHeader.TabIndex = 63;
      // 
      // NewIniSectionDialog
      // 
      this.AcceptButton = this.bOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(395, 98);
      this.Controls.Add(this.tbHeader);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.label4);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "NewIniSectionDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add INI Section";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.TextBox tbHeader;
  }
}