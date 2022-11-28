
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TriggerTypesControl
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
      this.bDeleteTrigger = new System.Windows.Forms.Button();
      this.bNewTrigger = new System.Windows.Forms.Button();
      this.ttControl = new RA_Mission_Editor.UI.UserControls.TriggerTypeControl();
      this.lboxTriggerList = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // bDuplicate
      // 
      this.bDuplicate.Enabled = false;
      this.bDuplicate.Location = new System.Drawing.Point(104, 434);
      this.bDuplicate.Name = "bDuplicate";
      this.bDuplicate.Size = new System.Drawing.Size(90, 32);
      this.bDuplicate.TabIndex = 64;
      this.bDuplicate.Text = "Duplicate";
      this.bDuplicate.UseVisualStyleBackColor = true;
      this.bDuplicate.Click += new System.EventHandler(this.bDuplicate_Click);
      // 
      // bSort
      // 
      this.bSort.Location = new System.Drawing.Point(144, 377);
      this.bSort.Name = "bSort";
      this.bSort.Size = new System.Drawing.Size(50, 50);
      this.bSort.TabIndex = 63;
      this.bSort.Text = "Sort All";
      this.bSort.UseVisualStyleBackColor = true;
      this.bSort.Click += new System.EventHandler(this.bSort_Click);
      // 
      // bMoveDown
      // 
      this.bMoveDown.Enabled = false;
      this.bMoveDown.Location = new System.Drawing.Point(59, 377);
      this.bMoveDown.Name = "bMoveDown";
      this.bMoveDown.Size = new System.Drawing.Size(50, 50);
      this.bMoveDown.TabIndex = 62;
      this.bMoveDown.Text = "Move Down";
      this.bMoveDown.UseVisualStyleBackColor = true;
      this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
      // 
      // bMoveUp
      // 
      this.bMoveUp.Enabled = false;
      this.bMoveUp.Location = new System.Drawing.Point(3, 377);
      this.bMoveUp.Name = "bMoveUp";
      this.bMoveUp.Size = new System.Drawing.Size(50, 50);
      this.bMoveUp.TabIndex = 61;
      this.bMoveUp.Text = "Move Up";
      this.bMoveUp.UseVisualStyleBackColor = true;
      this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
      // 
      // bDeleteTrigger
      // 
      this.bDeleteTrigger.Enabled = false;
      this.bDeleteTrigger.Location = new System.Drawing.Point(104, 472);
      this.bDeleteTrigger.Name = "bDeleteTrigger";
      this.bDeleteTrigger.Size = new System.Drawing.Size(90, 32);
      this.bDeleteTrigger.TabIndex = 60;
      this.bDeleteTrigger.Text = "Delete";
      this.bDeleteTrigger.UseVisualStyleBackColor = true;
      this.bDeleteTrigger.Click += new System.EventHandler(this.bDeleteTrigger_Click);
      // 
      // bNewTrigger
      // 
      this.bNewTrigger.Location = new System.Drawing.Point(3, 472);
      this.bNewTrigger.Name = "bNewTrigger";
      this.bNewTrigger.Size = new System.Drawing.Size(95, 32);
      this.bNewTrigger.TabIndex = 59;
      this.bNewTrigger.Text = "New Trigger";
      this.bNewTrigger.UseVisualStyleBackColor = true;
      this.bNewTrigger.Click += new System.EventHandler(this.bNewTrigger_Click);
      // 
      // ttControl
      // 
      this.ttControl.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.ttControl.Location = new System.Drawing.Point(200, 3);
      this.ttControl.Name = "ttControl";
      this.ttControl.Size = new System.Drawing.Size(600, 500);
      this.ttControl.TabIndex = 58;
      // 
      // lboxTriggerList
      // 
      this.lboxTriggerList.DisplayMember = "Name";
      this.lboxTriggerList.FormattingEnabled = true;
      this.lboxTriggerList.Location = new System.Drawing.Point(3, 3);
      this.lboxTriggerList.Name = "lboxTriggerList";
      this.lboxTriggerList.Size = new System.Drawing.Size(191, 368);
      this.lboxTriggerList.TabIndex = 57;
      this.lboxTriggerList.SelectedIndexChanged += new System.EventHandler(this.lboxTriggerList_SelectedIndexChanged);
      // 
      // TriggerTypesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bDuplicate);
      this.Controls.Add(this.bSort);
      this.Controls.Add(this.bMoveDown);
      this.Controls.Add(this.bMoveUp);
      this.Controls.Add(this.bDeleteTrigger);
      this.Controls.Add(this.bNewTrigger);
      this.Controls.Add(this.ttControl);
      this.Controls.Add(this.lboxTriggerList);
      this.Name = "TriggerTypesControl";
      this.Size = new System.Drawing.Size(800, 512);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button bDuplicate;
    private System.Windows.Forms.Button bSort;
    private System.Windows.Forms.Button bMoveDown;
    private System.Windows.Forms.Button bMoveUp;
    private System.Windows.Forms.Button bDeleteTrigger;
    private System.Windows.Forms.Button bNewTrigger;
    private TriggerTypeControl ttControl;
    private System.Windows.Forms.ListBox lboxTriggerList;
  }
}
