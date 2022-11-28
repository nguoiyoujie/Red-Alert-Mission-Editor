
namespace RA_Mission_Editor.UI.UserControls
{
  partial class HousesControl
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
      this.ucHouse = new RA_Mission_Editor.UI.UserControls.HouseControl();
      this.lboxHousesList = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // ucHouse
      // 
      this.ucHouse.Enabled = false;
      this.ucHouse.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.ucHouse.Location = new System.Drawing.Point(197, 6);
      this.ucHouse.Name = "ucHouse";
      this.ucHouse.Size = new System.Drawing.Size(600, 500);
      this.ucHouse.TabIndex = 56;
      // 
      // lboxHousesList
      // 
      this.lboxHousesList.DisplayMember = "Name";
      this.lboxHousesList.FormattingEnabled = true;
      this.lboxHousesList.Location = new System.Drawing.Point(2, 6);
      this.lboxHousesList.Name = "lboxHousesList";
      this.lboxHousesList.Size = new System.Drawing.Size(191, 485);
      this.lboxHousesList.TabIndex = 55;
      this.lboxHousesList.SelectedIndexChanged += new System.EventHandler(this.lboxHouseList_SelectedIndexChanged);
      // 
      // HousesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ucHouse);
      this.Controls.Add(this.lboxHousesList);
      this.Name = "HousesControl";
      this.Size = new System.Drawing.Size(800, 512);
      this.ResumeLayout(false);

    }

    #endregion

    private HouseControl ucHouse;
    private System.Windows.Forms.ListBox lboxHousesList;
  }
}
