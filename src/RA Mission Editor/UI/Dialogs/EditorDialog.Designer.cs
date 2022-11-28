
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class EditorDialog
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
      this.tabSelection = new System.Windows.Forms.TabControl();
      this.pageBasic = new System.Windows.Forms.TabPage();
      this.ttControl_Basic = new RA_Mission_Editor.UI.UserControls.BasicControl();
      this.pageHouses = new System.Windows.Forms.TabPage();
      this.ttControl_Houses = new RA_Mission_Editor.UI.UserControls.HousesControl();
      this.pageTutorial = new System.Windows.Forms.TabPage();
      this.ttControl_Tutorial = new RA_Mission_Editor.UI.UserControls.TutorialControl();
      this.pageTriggers = new System.Windows.Forms.TabPage();
      this.ttControl_Triggers = new RA_Mission_Editor.UI.UserControls.TriggerTypesControl();
      this.pageTeamTypes = new System.Windows.Forms.TabPage();
      this.ttControl_TeamTypes = new RA_Mission_Editor.UI.UserControls.TeamTypesControl();
      this.pageGlobals = new System.Windows.Forms.TabPage();
      this.ttControl_Globals = new RA_Mission_Editor.UI.UserControls.GlobalsControl();
      this.tabSelection.SuspendLayout();
      this.pageBasic.SuspendLayout();
      this.pageHouses.SuspendLayout();
      this.pageTutorial.SuspendLayout();
      this.pageTriggers.SuspendLayout();
      this.pageTeamTypes.SuspendLayout();
      this.pageGlobals.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabSelection
      // 
      this.tabSelection.Controls.Add(this.pageBasic);
      this.tabSelection.Controls.Add(this.pageHouses);
      this.tabSelection.Controls.Add(this.pageTutorial);
      this.tabSelection.Controls.Add(this.pageTriggers);
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
      // pageBasic
      // 
      this.pageBasic.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageBasic.Controls.Add(this.ttControl_Basic);
      this.pageBasic.Location = new System.Drawing.Point(4, 22);
      this.pageBasic.Name = "pageBasic";
      this.pageBasic.Padding = new System.Windows.Forms.Padding(3);
      this.pageBasic.Size = new System.Drawing.Size(800, 513);
      this.pageBasic.TabIndex = 2;
      this.pageBasic.Text = "Basic";
      // 
      // ttControl_Basic
      // 
      this.ttControl_Basic.Location = new System.Drawing.Point(0, 0);
      this.ttControl_Basic.Name = "ttControl_Basic";
      this.ttControl_Basic.Size = new System.Drawing.Size(800, 512);
      this.ttControl_Basic.TabIndex = 0;
      // 
      // pageHouses
      // 
      this.pageHouses.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageHouses.Controls.Add(this.ttControl_Houses);
      this.pageHouses.Location = new System.Drawing.Point(4, 22);
      this.pageHouses.Name = "pageHouses";
      this.pageHouses.Padding = new System.Windows.Forms.Padding(3);
      this.pageHouses.Size = new System.Drawing.Size(800, 513);
      this.pageHouses.TabIndex = 3;
      this.pageHouses.Text = "Houses";
      // 
      // ttControl_Houses
      // 
      this.ttControl_Houses.Location = new System.Drawing.Point(0, 0);
      this.ttControl_Houses.Name = "ttControl_Houses";
      this.ttControl_Houses.Size = new System.Drawing.Size(800, 512);
      this.ttControl_Houses.TabIndex = 1;
      // 
      // pageTutorial
      // 
      this.pageTutorial.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageTutorial.Controls.Add(this.ttControl_Tutorial);
      this.pageTutorial.Location = new System.Drawing.Point(4, 22);
      this.pageTutorial.Name = "pageTutorial";
      this.pageTutorial.Padding = new System.Windows.Forms.Padding(3);
      this.pageTutorial.Size = new System.Drawing.Size(800, 513);
      this.pageTutorial.TabIndex = 4;
      this.pageTutorial.Text = "Mission Strings";
      // 
      // ttControl_Tutorial
      // 
      this.ttControl_Tutorial.Location = new System.Drawing.Point(0, 0);
      this.ttControl_Tutorial.Name = "ttControl_Tutorial";
      this.ttControl_Tutorial.Size = new System.Drawing.Size(800, 512);
      this.ttControl_Tutorial.TabIndex = 0;
      // 
      // pageTriggers
      // 
      this.pageTriggers.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageTriggers.Controls.Add(this.ttControl_Triggers);
      this.pageTriggers.Location = new System.Drawing.Point(4, 22);
      this.pageTriggers.Name = "pageTriggers";
      this.pageTriggers.Padding = new System.Windows.Forms.Padding(3);
      this.pageTriggers.Size = new System.Drawing.Size(800, 513);
      this.pageTriggers.TabIndex = 0;
      this.pageTriggers.Text = "Triggers";
      // 
      // ttControl_Triggers
      // 
      this.ttControl_Triggers.Location = new System.Drawing.Point(0, 0);
      this.ttControl_Triggers.Name = "ttControl_Triggers";
      this.ttControl_Triggers.Size = new System.Drawing.Size(800, 512);
      this.ttControl_Triggers.TabIndex = 0;
      // 
      // pageTeamTypes
      // 
      this.pageTeamTypes.BackColor = System.Drawing.Color.WhiteSmoke;
      this.pageTeamTypes.Controls.Add(this.ttControl_TeamTypes);
      this.pageTeamTypes.Location = new System.Drawing.Point(4, 22);
      this.pageTeamTypes.Name = "pageTeamTypes";
      this.pageTeamTypes.Padding = new System.Windows.Forms.Padding(3);
      this.pageTeamTypes.Size = new System.Drawing.Size(800, 513);
      this.pageTeamTypes.TabIndex = 1;
      this.pageTeamTypes.Text = "TeamTypes";
      // 
      // ttControl_TeamTypes
      // 
      this.ttControl_TeamTypes.Location = new System.Drawing.Point(0, 0);
      this.ttControl_TeamTypes.Name = "ttControl_TeamTypes";
      this.ttControl_TeamTypes.Size = new System.Drawing.Size(800, 512);
      this.ttControl_TeamTypes.TabIndex = 0;
      // 
      // pageGlobals
      // 
      this.pageGlobals.Controls.Add(this.ttControl_Globals);
      this.pageGlobals.Location = new System.Drawing.Point(4, 22);
      this.pageGlobals.Name = "pageGlobals";
      this.pageGlobals.Padding = new System.Windows.Forms.Padding(3);
      this.pageGlobals.Size = new System.Drawing.Size(800, 513);
      this.pageGlobals.TabIndex = 5;
      this.pageGlobals.Text = "Global Variables";
      this.pageGlobals.UseVisualStyleBackColor = true;
      // 
      // ttControl_Globals
      // 
      this.ttControl_Globals.Location = new System.Drawing.Point(0, 0);
      this.ttControl_Globals.Name = "ttControl_Globals";
      this.ttControl_Globals.Size = new System.Drawing.Size(800, 512);
      this.ttControl_Globals.TabIndex = 0;
      // 
      // EditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(808, 539);
      this.Controls.Add(this.tabSelection);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "EditorDialog";
      this.Text = "Editor";
      this.tabSelection.ResumeLayout(false);
      this.pageBasic.ResumeLayout(false);
      this.pageHouses.ResumeLayout(false);
      this.pageTutorial.ResumeLayout(false);
      this.pageTriggers.ResumeLayout(false);
      this.pageTeamTypes.ResumeLayout(false);
      this.pageGlobals.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabSelection;
    private System.Windows.Forms.TabPage pageTriggers;
    private UserControls.TriggerTypesControl ttControl_Triggers;
    private System.Windows.Forms.TabPage pageTeamTypes;
    private UserControls.TeamTypesControl ttControl_TeamTypes;
    private System.Windows.Forms.TabPage pageBasic;
    private System.Windows.Forms.TabPage pageHouses;
    private System.Windows.Forms.TabPage pageTutorial;
    private UserControls.BasicControl ttControl_Basic;
    private UserControls.HousesControl ttControl_Houses;
    private UserControls.TutorialControl ttControl_Tutorial;
    private System.Windows.Forms.TabPage pageGlobals;
    private UserControls.GlobalsControl ttControl_Globals;
  }
}