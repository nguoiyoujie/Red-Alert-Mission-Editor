
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TeamTypesControl
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
      this.bDuplicate = new System.Windows.Forms.Button();
      this.bSort = new System.Windows.Forms.Button();
      this.bMoveDown = new System.Windows.Forms.Button();
      this.bMoveUp = new System.Windows.Forms.Button();
      this.bDeleteTeamType = new System.Windows.Forms.Button();
      this.bNewTeamType = new System.Windows.Forms.Button();
      this.ttControl = new RA_Mission_Editor.UI.UserControls.TeamTypeControl();
      this.lboxTeamTypeList = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // bDuplicate
      // 
      this.bDuplicate.Enabled = false;
      this.bDuplicate.Location = new System.Drawing.Point(104, 434);
      this.bDuplicate.Name = "bDuplicate";
      this.bDuplicate.Size = new System.Drawing.Size(90, 32);
      this.bDuplicate.TabIndex = 63;
      this.bDuplicate.Text = "Duplicate";
      this.bDuplicate.UseVisualStyleBackColor = true;
      this.bDuplicate.Click += new System.EventHandler(this.bDuplicate_Click);
      // 
      // bSort
      // 
      this.bSort.Location = new System.Drawing.Point(144, 390);
      this.bSort.Name = "bSort";
      this.bSort.Size = new System.Drawing.Size(50, 38);
      this.bSort.TabIndex = 62;
      this.bSort.Text = "Sort All";
      this.bSort.UseVisualStyleBackColor = true;
      this.bSort.Click += new System.EventHandler(this.bSort_Click);
      // 
      // bMoveDown
      // 
      this.bMoveDown.Enabled = false;
      this.bMoveDown.Location = new System.Drawing.Point(59, 390);
      this.bMoveDown.Name = "bMoveDown";
      this.bMoveDown.Size = new System.Drawing.Size(50, 38);
      this.bMoveDown.TabIndex = 61;
      this.bMoveDown.Text = "Move Down";
      this.bMoveDown.UseVisualStyleBackColor = true;
      this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
      // 
      // bMoveUp
      // 
      this.bMoveUp.Enabled = false;
      this.bMoveUp.Location = new System.Drawing.Point(3, 390);
      this.bMoveUp.Name = "bMoveUp";
      this.bMoveUp.Size = new System.Drawing.Size(50, 38);
      this.bMoveUp.TabIndex = 60;
      this.bMoveUp.Text = "Move Up";
      this.bMoveUp.UseVisualStyleBackColor = true;
      this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
      // 
      // bDeleteTeamType
      // 
      this.bDeleteTeamType.Enabled = false;
      this.bDeleteTeamType.Location = new System.Drawing.Point(104, 472);
      this.bDeleteTeamType.Name = "bDeleteTeamType";
      this.bDeleteTeamType.Size = new System.Drawing.Size(90, 32);
      this.bDeleteTeamType.TabIndex = 59;
      this.bDeleteTeamType.Text = "Delete";
      this.bDeleteTeamType.UseVisualStyleBackColor = true;
      this.bDeleteTeamType.Click += new System.EventHandler(this.bDeleteTeamType_Click);
      // 
      // bNewTeamType
      // 
      this.bNewTeamType.Location = new System.Drawing.Point(3, 472);
      this.bNewTeamType.Name = "bNewTeamType";
      this.bNewTeamType.Size = new System.Drawing.Size(95, 32);
      this.bNewTeamType.TabIndex = 58;
      this.bNewTeamType.Text = "New TeamType";
      this.bNewTeamType.UseVisualStyleBackColor = true;
      this.bNewTeamType.Click += new System.EventHandler(this.bNewTeamType_Click);
      // 
      // ttControl
      // 
      this.ttControl.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.ttControl.Location = new System.Drawing.Point(200, 3);
      this.ttControl.Name = "ttControl";
      this.ttControl.Size = new System.Drawing.Size(600, 500);
      this.ttControl.TabIndex = 57;
      // 
      // lboxTeamTypeList
      // 
      this.lboxTeamTypeList.DisplayMember = "Name";
      this.lboxTeamTypeList.FormattingEnabled = true;
      this.lboxTeamTypeList.Location = new System.Drawing.Point(3, 3);
      this.lboxTeamTypeList.Name = "lboxTeamTypeList";
      this.lboxTeamTypeList.Size = new System.Drawing.Size(191, 381);
      this.lboxTeamTypeList.TabIndex = 56;
      this.lboxTeamTypeList.SelectedIndexChanged += new System.EventHandler(this.lboxTeamTypeList_SelectedIndexChanged);
      // 
      // TeamTypesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bDuplicate);
      this.Controls.Add(this.bSort);
      this.Controls.Add(this.bMoveDown);
      this.Controls.Add(this.bMoveUp);
      this.Controls.Add(this.bDeleteTeamType);
      this.Controls.Add(this.bNewTeamType);
      this.Controls.Add(this.ttControl);
      this.Controls.Add(this.lboxTeamTypeList);
      this.Name = "TeamTypesControl";
      this.Size = new System.Drawing.Size(800, 512);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button bDuplicate;
    private System.Windows.Forms.Button bSort;
    private System.Windows.Forms.Button bMoveDown;
    private System.Windows.Forms.Button bMoveUp;
    private System.Windows.Forms.Button bDeleteTeamType;
    private System.Windows.Forms.Button bNewTeamType;
    private TeamTypeControl ttControl;
    private System.Windows.Forms.ListBox lboxTeamTypeList;
  }
}
