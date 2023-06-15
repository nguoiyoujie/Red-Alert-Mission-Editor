
namespace RA_Mission_Editor.UI.UserControls
{
  partial class ReferenceControl
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
      this.tbRef = new System.Windows.Forms.TextBox();
      this.lblTutorial = new System.Windows.Forms.Label();
      this.cbCategory = new System.Windows.Forms.ComboBox();
      this.cbItem = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // tbRef
      // 
      this.tbRef.Location = new System.Drawing.Point(3, 51);
      this.tbRef.Multiline = true;
      this.tbRef.Name = "tbRef";
      this.tbRef.ReadOnly = true;
      this.tbRef.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbRef.Size = new System.Drawing.Size(794, 458);
      this.tbRef.TabIndex = 63;
      this.tbRef.WordWrap = false;
      // 
      // lblTutorial
      // 
      this.lblTutorial.AutoSize = true;
      this.lblTutorial.Location = new System.Drawing.Point(13, 9);
      this.lblTutorial.Name = "lblTutorial";
      this.lblTutorial.Size = new System.Drawing.Size(62, 13);
      this.lblTutorial.TabIndex = 61;
      this.lblTutorial.Text = "References";
      // 
      // cbCategory
      // 
      this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCategory.FormattingEnabled = true;
      this.cbCategory.Items.AddRange(new object[] {
            "Waypoint",
            "Trigger",
            "TeamType",
            "Global",
            "Mission Text"});
      this.cbCategory.Location = new System.Drawing.Point(3, 25);
      this.cbCategory.Name = "cbCategory";
      this.cbCategory.Size = new System.Drawing.Size(240, 21);
      this.cbCategory.TabIndex = 64;
      this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
      // 
      // cbItem
      // 
      this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbItem.FormattingEnabled = true;
      this.cbItem.Location = new System.Drawing.Point(249, 25);
      this.cbItem.Name = "cbItem";
      this.cbItem.Size = new System.Drawing.Size(548, 21);
      this.cbItem.TabIndex = 65;
      this.cbItem.SelectedIndexChanged += new System.EventHandler(this.UpdateView);
      this.cbItem.SelectedValueChanged += new System.EventHandler(this.UpdateView);
      // 
      // ReferenceControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cbItem);
      this.Controls.Add(this.cbCategory);
      this.Controls.Add(this.tbRef);
      this.Controls.Add(this.lblTutorial);
      this.Name = "ReferenceControl";
      this.Size = new System.Drawing.Size(800, 512);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox tbRef;
    private System.Windows.Forms.Label lblTutorial;
    private System.Windows.Forms.ComboBox cbCategory;
    private System.Windows.Forms.ComboBox cbItem;
  }
}
