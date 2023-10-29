
namespace RA_Mission_Editor.UI
{
  partial class MainEditor
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
      this.splitMain = new System.Windows.Forms.SplitContainer();
      this.lboxObjects = new System.Windows.Forms.ListBox();
      this.lblPreplaceHouse = new System.Windows.Forms.Label();
      this.pObjectCanvas = new System.Windows.Forms.Panel();
      this.pbObjectCanvas = new System.Windows.Forms.PictureBox();
      this.bSetEntity = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pText = new System.Windows.Forms.Panel();
      this.tbInfo = new System.Windows.Forms.TextBox();
      this.pObjectTop = new System.Windows.Forms.Panel();
      this.pbMiniMapCanvas = new RA_Mission_Editor.UI.UserControls.MiniMapCanvasControl();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.lblHint = new System.Windows.Forms.Label();
      this.split2 = new System.Windows.Forms.SplitContainer();
      this.cbGrid = new System.Windows.Forms.CheckBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.panel5 = new System.Windows.Forms.Panel();
      this.tbarZoom = new System.Windows.Forms.TrackBar();
      this.cbHint = new System.Windows.Forms.CheckBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.bSelectMode = new System.Windows.Forms.Button();
      this.bExtract = new System.Windows.Forms.Button();
      this.bLayerCellTriggers = new System.Windows.Forms.Button();
      this.bLayerWaypoints = new System.Windows.Forms.Button();
      this.bLayerBases = new System.Windows.Forms.Button();
      this.bLayerStructures = new System.Windows.Forms.Button();
      this.bLayerShips = new System.Windows.Forms.Button();
      this.bLayerUnits = new System.Windows.Forms.Button();
      this.bLayerInfantry = new System.Windows.Forms.Button();
      this.bLayerSmudge = new System.Windows.Forms.Button();
      this.bLayerTerrain = new System.Windows.Forms.Button();
      this.bLayerOverlay = new System.Windows.Forms.Button();
      this.bLayerTemplate = new System.Windows.Forms.Button();
      this.pbMapCanvas = new RA_Mission_Editor.UI.UserControls.MapCanvasControl();
      this.pTechnoList = new System.Windows.Forms.Panel();
      this.lblSelectCell = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openRecentMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.importFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openRAbinFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.closeMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setRedAlertDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadDirectoryContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mapAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.shiftMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.basicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.housesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.missionStringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.triggersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.teamTypesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.terrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.smudgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.infantryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.shipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.structureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.baseBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.waypointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cellTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copySelectedCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteSelectedCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSelectedCellsInExtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteObjectsInSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clearTemplateInSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editINIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openOtherEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.visibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.overlayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.terrainToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.smudgeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.infantryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.shipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.structuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.basesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.waypointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cellTriggersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.boundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.renderToImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tssCoord = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssCellTemplateInfo = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssCellOverlayInfo = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssCellInfo = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssBlank = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssRemark = new System.Windows.Forms.ToolStripStatusLabel();
      this.ttipInfo = new System.Windows.Forms.ToolTip(this.components);
      this.templateColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
      this.splitMain.Panel1.SuspendLayout();
      this.splitMain.Panel2.SuspendLayout();
      this.splitMain.SuspendLayout();
      this.pObjectCanvas.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbObjectCanvas)).BeginInit();
      this.pText.SuspendLayout();
      this.pObjectTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.split2)).BeginInit();
      this.split2.Panel1.SuspendLayout();
      this.split2.Panel2.SuspendLayout();
      this.split2.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbarZoom)).BeginInit();
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitMain
      // 
      this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitMain.IsSplitterFixed = true;
      this.splitMain.Location = new System.Drawing.Point(0, 24);
      this.splitMain.Name = "splitMain";
      // 
      // splitMain.Panel1
      // 
      this.splitMain.Panel1.Controls.Add(this.lboxObjects);
      this.splitMain.Panel1.Controls.Add(this.lblPreplaceHouse);
      this.splitMain.Panel1.Controls.Add(this.pObjectCanvas);
      this.splitMain.Panel1.Controls.Add(this.bSetEntity);
      this.splitMain.Panel1.Controls.Add(this.panel2);
      this.splitMain.Panel1.Controls.Add(this.pText);
      this.splitMain.Panel1.Controls.Add(this.pObjectTop);
      this.splitMain.Panel1MinSize = 200;
      // 
      // splitMain.Panel2
      // 
      this.splitMain.Panel2.Controls.Add(this.splitContainer1);
      this.splitMain.Size = new System.Drawing.Size(1184, 815);
      this.splitMain.SplitterDistance = 200;
      this.splitMain.TabIndex = 0;
      // 
      // lboxObjects
      // 
      this.lboxObjects.DisplayMember = "DisplayName";
      this.lboxObjects.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lboxObjects.Font = new System.Drawing.Font("Consolas", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lboxObjects.FormattingEnabled = true;
      this.lboxObjects.HorizontalScrollbar = true;
      this.lboxObjects.ItemHeight = 12;
      this.lboxObjects.Location = new System.Drawing.Point(0, 218);
      this.lboxObjects.MultiColumn = true;
      this.lboxObjects.Name = "lboxObjects";
      this.lboxObjects.ScrollAlwaysVisible = true;
      this.lboxObjects.Size = new System.Drawing.Size(200, 424);
      this.lboxObjects.TabIndex = 3;
      this.lboxObjects.SelectedIndexChanged += new System.EventHandler(this.lboxObjects_SelectedIndexChanged);
      // 
      // lblPreplaceHouse
      // 
      this.lblPreplaceHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPreplaceHouse.AutoSize = true;
      this.lblPreplaceHouse.BackColor = System.Drawing.Color.DimGray;
      this.lblPreplaceHouse.Location = new System.Drawing.Point(3, 645);
      this.lblPreplaceHouse.Name = "lblPreplaceHouse";
      this.lblPreplaceHouse.Size = new System.Drawing.Size(0, 13);
      this.lblPreplaceHouse.TabIndex = 13;
      this.lblPreplaceHouse.Visible = false;
      // 
      // pObjectCanvas
      // 
      this.pObjectCanvas.AutoScroll = true;
      this.pObjectCanvas.BackColor = System.Drawing.Color.DimGray;
      this.pObjectCanvas.Controls.Add(this.pbObjectCanvas);
      this.pObjectCanvas.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pObjectCanvas.Location = new System.Drawing.Point(0, 642);
      this.pObjectCanvas.Name = "pObjectCanvas";
      this.pObjectCanvas.Size = new System.Drawing.Size(200, 150);
      this.pObjectCanvas.TabIndex = 14;
      // 
      // pbObjectCanvas
      // 
      this.pbObjectCanvas.BackColor = System.Drawing.Color.DimGray;
      this.pbObjectCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbObjectCanvas.Location = new System.Drawing.Point(0, 0);
      this.pbObjectCanvas.Name = "pbObjectCanvas";
      this.pbObjectCanvas.Size = new System.Drawing.Size(50, 50);
      this.pbObjectCanvas.TabIndex = 7;
      this.pbObjectCanvas.TabStop = false;
      this.pbObjectCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbObjectCanvas_MouseClick);
      // 
      // bSetEntity
      // 
      this.bSetEntity.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.bSetEntity.Enabled = false;
      this.bSetEntity.Location = new System.Drawing.Point(0, 792);
      this.bSetEntity.Name = "bSetEntity";
      this.bSetEntity.Size = new System.Drawing.Size(200, 23);
      this.bSetEntity.TabIndex = 8;
      this.bSetEntity.Text = "Set Entity Properties";
      this.bSetEntity.UseVisualStyleBackColor = true;
      this.bSetEntity.Click += new System.EventHandler(this.bSetEntity_Click);
      // 
      // panel2
      // 
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.panel2.Location = new System.Drawing.Point(0, 188);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(200, 30);
      this.panel2.TabIndex = 6;
      // 
      // pText
      // 
      this.pText.Controls.Add(this.tbInfo);
      this.pText.Dock = System.Windows.Forms.DockStyle.Top;
      this.pText.Location = new System.Drawing.Point(0, 150);
      this.pText.Name = "pText";
      this.pText.Padding = new System.Windows.Forms.Padding(2);
      this.pText.Size = new System.Drawing.Size(200, 38);
      this.pText.TabIndex = 4;
      // 
      // tbInfo
      // 
      this.tbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbInfo.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbInfo.Location = new System.Drawing.Point(2, 2);
      this.tbInfo.Multiline = true;
      this.tbInfo.Name = "tbInfo";
      this.tbInfo.ReadOnly = true;
      this.tbInfo.Size = new System.Drawing.Size(196, 34);
      this.tbInfo.TabIndex = 1;
      // 
      // pObjectTop
      // 
      this.pObjectTop.Controls.Add(this.pbMiniMapCanvas);
      this.pObjectTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pObjectTop.Location = new System.Drawing.Point(0, 0);
      this.pObjectTop.Name = "pObjectTop";
      this.pObjectTop.Size = new System.Drawing.Size(200, 150);
      this.pObjectTop.TabIndex = 2;
      // 
      // pbMiniMapCanvas
      // 
      this.pbMiniMapCanvas.BackColor = System.Drawing.Color.Black;
      this.pbMiniMapCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pbMiniMapCanvas.Location = new System.Drawing.Point(0, 0);
      this.pbMiniMapCanvas.Name = "pbMiniMapCanvas";
      this.pbMiniMapCanvas.Size = new System.Drawing.Size(200, 150);
      this.pbMiniMapCanvas.TabIndex = 5;
      this.pbMiniMapCanvas.Text = "miniMapCanvasControl1";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.lblHint);
      this.splitContainer1.Panel1.Controls.Add(this.split2);
      this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pTechnoList);
      this.splitContainer1.Panel2.Controls.Add(this.lblSelectCell);
      this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer1.Panel2MinSize = 240;
      this.splitContainer1.Size = new System.Drawing.Size(980, 815);
      this.splitContainer1.SplitterDistance = 732;
      this.splitContainer1.TabIndex = 6;
      // 
      // lblHint
      // 
      this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblHint.BackColor = System.Drawing.SystemColors.ControlDark;
      this.lblHint.Location = new System.Drawing.Point(442, 53);
      this.lblHint.Name = "lblHint";
      this.lblHint.Size = new System.Drawing.Size(268, 133);
      this.lblHint.TabIndex = 12;
      this.lblHint.Text = resources.GetString("lblHint.Text");
      this.lblHint.Visible = false;
      // 
      // split2
      // 
      this.split2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.split2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.split2.Location = new System.Drawing.Point(0, 0);
      this.split2.Name = "split2";
      this.split2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // split2.Panel1
      // 
      this.split2.Panel1.Controls.Add(this.cbGrid);
      this.split2.Panel1.Controls.Add(this.panel4);
      this.split2.Panel1.Controls.Add(this.cbHint);
      this.split2.Panel1.Controls.Add(this.panel3);
      this.split2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      // 
      // split2.Panel2
      // 
      this.split2.Panel2.AutoScroll = true;
      this.split2.Panel2.BackColor = System.Drawing.Color.Black;
      this.split2.Panel2.Controls.Add(this.pbMapCanvas);
      this.split2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.split2.Size = new System.Drawing.Size(732, 815);
      this.split2.SplitterDistance = 45;
      this.split2.TabIndex = 1;
      // 
      // cbGrid
      // 
      this.cbGrid.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbGrid.Dock = System.Windows.Forms.DockStyle.Left;
      this.cbGrid.Location = new System.Drawing.Point(472, 0);
      this.cbGrid.Name = "cbGrid";
      this.cbGrid.Size = new System.Drawing.Size(44, 45);
      this.cbGrid.TabIndex = 9;
      this.cbGrid.Text = "Show Grid";
      this.cbGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.cbGrid.UseVisualStyleBackColor = true;
      this.cbGrid.CheckedChanged += new System.EventHandler(this.cbGrid_CheckedChanged);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.label2);
      this.panel4.Controls.Add(this.panel5);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel4.Location = new System.Drawing.Point(392, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(80, 45);
      this.panel4.TabIndex = 8;
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
      this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(80, 15);
      this.label2.TabIndex = 11;
      this.label2.Text = "Zoom";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.tbarZoom);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel5.Location = new System.Drawing.Point(0, 15);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(80, 30);
      this.panel5.TabIndex = 5;
      // 
      // tbarZoom
      // 
      this.tbarZoom.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbarZoom.LargeChange = 1;
      this.tbarZoom.Location = new System.Drawing.Point(0, 0);
      this.tbarZoom.Maximum = 3;
      this.tbarZoom.Name = "tbarZoom";
      this.tbarZoom.Size = new System.Drawing.Size(80, 30);
      this.tbarZoom.TabIndex = 8;
      this.tbarZoom.Value = 1;
      this.tbarZoom.Scroll += new System.EventHandler(this.tbarZoom_Scroll);
      // 
      // cbHint
      // 
      this.cbHint.Appearance = System.Windows.Forms.Appearance.Button;
      this.cbHint.Dock = System.Windows.Forms.DockStyle.Right;
      this.cbHint.Location = new System.Drawing.Point(648, 0);
      this.cbHint.Name = "cbHint";
      this.cbHint.Size = new System.Drawing.Size(84, 45);
      this.cbHint.TabIndex = 7;
      this.cbHint.Text = "Mouse Usage";
      this.cbHint.UseVisualStyleBackColor = true;
      this.cbHint.CheckedChanged += new System.EventHandler(this.cbHint_CheckedChanged);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label3);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.panel1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(392, 45);
      this.panel3.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
      this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Location = new System.Drawing.Point(360, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(32, 15);
      this.label3.TabIndex = 12;
      this.label3.Text = "Esc";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label1.Dock = System.Windows.Forms.DockStyle.Left;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(360, 15);
      this.label1.TabIndex = 11;
      this.label1.Text = "Insert (Alt + 1 to Alt + \'-\')";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.bSelectMode);
      this.panel1.Controls.Add(this.bExtract);
      this.panel1.Controls.Add(this.bLayerCellTriggers);
      this.panel1.Controls.Add(this.bLayerWaypoints);
      this.panel1.Controls.Add(this.bLayerBases);
      this.panel1.Controls.Add(this.bLayerStructures);
      this.panel1.Controls.Add(this.bLayerShips);
      this.panel1.Controls.Add(this.bLayerUnits);
      this.panel1.Controls.Add(this.bLayerInfantry);
      this.panel1.Controls.Add(this.bLayerSmudge);
      this.panel1.Controls.Add(this.bLayerTerrain);
      this.panel1.Controls.Add(this.bLayerOverlay);
      this.panel1.Controls.Add(this.bLayerTemplate);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 15);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(392, 30);
      this.panel1.TabIndex = 5;
      // 
      // bSelectMode
      // 
      this.bSelectMode.Dock = System.Windows.Forms.DockStyle.Left;
      this.bSelectMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bSelectMode.Location = new System.Drawing.Point(360, 0);
      this.bSelectMode.Name = "bSelectMode";
      this.bSelectMode.Size = new System.Drawing.Size(30, 30);
      this.bSelectMode.TabIndex = 11;
      this.bSelectMode.Text = "N";
      this.bSelectMode.Click += new System.EventHandler(this.bLayerNone_Click);
      // 
      // bExtract
      // 
      this.bExtract.Dock = System.Windows.Forms.DockStyle.Left;
      this.bExtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bExtract.Location = new System.Drawing.Point(330, 0);
      this.bExtract.Name = "bExtract";
      this.bExtract.Size = new System.Drawing.Size(30, 30);
      this.bExtract.TabIndex = 12;
      this.bExtract.Text = "Ex";
      this.bExtract.UseVisualStyleBackColor = true;
      this.bExtract.Click += new System.EventHandler(this.bExtract_Click);
      // 
      // bLayerCellTriggers
      // 
      this.bLayerCellTriggers.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerCellTriggers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerCellTriggers.Image = global::RA_Mission_Editor.Properties.Resources.button_celltriggers;
      this.bLayerCellTriggers.Location = new System.Drawing.Point(300, 0);
      this.bLayerCellTriggers.Name = "bLayerCellTriggers";
      this.bLayerCellTriggers.Size = new System.Drawing.Size(30, 30);
      this.bLayerCellTriggers.TabIndex = 10;
      this.bLayerCellTriggers.UseVisualStyleBackColor = true;
      this.bLayerCellTriggers.Click += new System.EventHandler(this.bLayerCellTriggers_Click);
      // 
      // bLayerWaypoints
      // 
      this.bLayerWaypoints.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerWaypoints.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerWaypoints.Image = global::RA_Mission_Editor.Properties.Resources.button_waypoint;
      this.bLayerWaypoints.Location = new System.Drawing.Point(270, 0);
      this.bLayerWaypoints.Name = "bLayerWaypoints";
      this.bLayerWaypoints.Size = new System.Drawing.Size(30, 30);
      this.bLayerWaypoints.TabIndex = 9;
      this.bLayerWaypoints.UseVisualStyleBackColor = true;
      this.bLayerWaypoints.Click += new System.EventHandler(this.bLayerWaypoints_Click);
      // 
      // bLayerBases
      // 
      this.bLayerBases.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerBases.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerBases.Image = global::RA_Mission_Editor.Properties.Resources.button_bases;
      this.bLayerBases.Location = new System.Drawing.Point(240, 0);
      this.bLayerBases.Name = "bLayerBases";
      this.bLayerBases.Size = new System.Drawing.Size(30, 30);
      this.bLayerBases.TabIndex = 8;
      this.bLayerBases.UseVisualStyleBackColor = true;
      this.bLayerBases.Click += new System.EventHandler(this.bLayerBases_Click);
      // 
      // bLayerStructures
      // 
      this.bLayerStructures.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerStructures.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerStructures.Image = global::RA_Mission_Editor.Properties.Resources.button_structures;
      this.bLayerStructures.Location = new System.Drawing.Point(210, 0);
      this.bLayerStructures.Name = "bLayerStructures";
      this.bLayerStructures.Size = new System.Drawing.Size(30, 30);
      this.bLayerStructures.TabIndex = 7;
      this.bLayerStructures.UseVisualStyleBackColor = true;
      this.bLayerStructures.Click += new System.EventHandler(this.bLayerStructures_Click);
      // 
      // bLayerShips
      // 
      this.bLayerShips.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerShips.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerShips.Image = global::RA_Mission_Editor.Properties.Resources.button_ships;
      this.bLayerShips.Location = new System.Drawing.Point(180, 0);
      this.bLayerShips.Name = "bLayerShips";
      this.bLayerShips.Size = new System.Drawing.Size(30, 30);
      this.bLayerShips.TabIndex = 6;
      this.bLayerShips.UseVisualStyleBackColor = true;
      this.bLayerShips.Click += new System.EventHandler(this.bLayerShips_Click);
      // 
      // bLayerUnits
      // 
      this.bLayerUnits.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerUnits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerUnits.Image = global::RA_Mission_Editor.Properties.Resources.button_units;
      this.bLayerUnits.Location = new System.Drawing.Point(150, 0);
      this.bLayerUnits.Name = "bLayerUnits";
      this.bLayerUnits.Size = new System.Drawing.Size(30, 30);
      this.bLayerUnits.TabIndex = 5;
      this.bLayerUnits.UseVisualStyleBackColor = true;
      this.bLayerUnits.Click += new System.EventHandler(this.bLayerUnits_Click);
      // 
      // bLayerInfantry
      // 
      this.bLayerInfantry.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerInfantry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerInfantry.Image = global::RA_Mission_Editor.Properties.Resources.button_infantry;
      this.bLayerInfantry.Location = new System.Drawing.Point(120, 0);
      this.bLayerInfantry.Name = "bLayerInfantry";
      this.bLayerInfantry.Size = new System.Drawing.Size(30, 30);
      this.bLayerInfantry.TabIndex = 4;
      this.bLayerInfantry.UseVisualStyleBackColor = true;
      this.bLayerInfantry.Click += new System.EventHandler(this.bLayerInfantry_Click);
      // 
      // bLayerSmudge
      // 
      this.bLayerSmudge.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerSmudge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerSmudge.Image = global::RA_Mission_Editor.Properties.Resources.button_smudge;
      this.bLayerSmudge.Location = new System.Drawing.Point(90, 0);
      this.bLayerSmudge.Name = "bLayerSmudge";
      this.bLayerSmudge.Size = new System.Drawing.Size(30, 30);
      this.bLayerSmudge.TabIndex = 3;
      this.bLayerSmudge.UseVisualStyleBackColor = true;
      this.bLayerSmudge.Click += new System.EventHandler(this.bLayerSmudge_Click);
      // 
      // bLayerTerrain
      // 
      this.bLayerTerrain.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerTerrain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerTerrain.Image = global::RA_Mission_Editor.Properties.Resources.button_terrain;
      this.bLayerTerrain.Location = new System.Drawing.Point(60, 0);
      this.bLayerTerrain.Name = "bLayerTerrain";
      this.bLayerTerrain.Size = new System.Drawing.Size(30, 30);
      this.bLayerTerrain.TabIndex = 2;
      this.bLayerTerrain.UseVisualStyleBackColor = true;
      this.bLayerTerrain.Click += new System.EventHandler(this.bLayerTerrain_Click);
      // 
      // bLayerOverlay
      // 
      this.bLayerOverlay.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerOverlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerOverlay.Image = global::RA_Mission_Editor.Properties.Resources.button_overlay;
      this.bLayerOverlay.Location = new System.Drawing.Point(30, 0);
      this.bLayerOverlay.Name = "bLayerOverlay";
      this.bLayerOverlay.Size = new System.Drawing.Size(30, 30);
      this.bLayerOverlay.TabIndex = 1;
      this.bLayerOverlay.UseVisualStyleBackColor = true;
      this.bLayerOverlay.Click += new System.EventHandler(this.bLayerOverlay_Click);
      // 
      // bLayerTemplate
      // 
      this.bLayerTemplate.Dock = System.Windows.Forms.DockStyle.Left;
      this.bLayerTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.bLayerTemplate.Image = global::RA_Mission_Editor.Properties.Resources.button_template;
      this.bLayerTemplate.Location = new System.Drawing.Point(0, 0);
      this.bLayerTemplate.Name = "bLayerTemplate";
      this.bLayerTemplate.Size = new System.Drawing.Size(30, 30);
      this.bLayerTemplate.TabIndex = 0;
      this.bLayerTemplate.UseVisualStyleBackColor = true;
      this.bLayerTemplate.Click += new System.EventHandler(this.bLayerTemplate_Click);
      // 
      // pbMapCanvas
      // 
      this.pbMapCanvas.Location = new System.Drawing.Point(0, 0);
      this.pbMapCanvas.Name = "pbMapCanvas";
      this.pbMapCanvas.Size = new System.Drawing.Size(1, 1);
      this.pbMapCanvas.TabIndex = 1;
      this.pbMapCanvas.TabStop = false;
      this.pbMapCanvas.Zoom = 1F;
      // 
      // pTechnoList
      // 
      this.pTechnoList.AutoScroll = true;
      this.pTechnoList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pTechnoList.Location = new System.Drawing.Point(0, 14);
      this.pTechnoList.Name = "pTechnoList";
      this.pTechnoList.Size = new System.Drawing.Size(244, 801);
      this.pTechnoList.TabIndex = 0;
      // 
      // lblSelectCell
      // 
      this.lblSelectCell.BackColor = System.Drawing.SystemColors.ControlDark;
      this.lblSelectCell.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblSelectCell.Location = new System.Drawing.Point(0, 0);
      this.lblSelectCell.Name = "lblSelectCell";
      this.lblSelectCell.Size = new System.Drawing.Size(244, 14);
      this.lblSelectCell.TabIndex = 12;
      this.lblSelectCell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.Color.Silver;
      this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.visibilityToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.renderToolStripMenuItem,
            this.testToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openMapToolStripMenuItem,
            this.openRecentMapToolStripMenuItem,
            this.importFromToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeMapToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newMapToolStripMenuItem
      // 
      this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
      this.newMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.newMapToolStripMenuItem.Text = "New Map";
      this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
      // 
      // openMapToolStripMenuItem
      // 
      this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
      this.openMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.openMapToolStripMenuItem.Text = "Open Map";
      this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
      // 
      // openRecentMapToolStripMenuItem
      // 
      this.openRecentMapToolStripMenuItem.Enabled = false;
      this.openRecentMapToolStripMenuItem.Name = "openRecentMapToolStripMenuItem";
      this.openRecentMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.openRecentMapToolStripMenuItem.Text = "Open Recent Map";
      // 
      // importFromToolStripMenuItem
      // 
      this.importFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRAbinFileToolStripMenuItem});
      this.importFromToolStripMenuItem.Name = "importFromToolStripMenuItem";
      this.importFromToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.importFromToolStripMenuItem.Text = "Import from";
      // 
      // openRAbinFileToolStripMenuItem
      // 
      this.openRAbinFileToolStripMenuItem.Name = "openRAbinFileToolStripMenuItem";
      this.openRAbinFileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.openRAbinFileToolStripMenuItem.Text = "OpenRA .bin File";
      this.openRAbinFileToolStripMenuItem.Click += new System.EventHandler(this.openRAbinFileToolStripMenuItem_Click);
      // 
      // saveMapToolStripMenuItem
      // 
      this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
      this.saveMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.saveMapToolStripMenuItem.Text = "Save Map";
      this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
      // 
      // saveMapAsToolStripMenuItem
      // 
      this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
      this.saveMapAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.saveMapAsToolStripMenuItem.Text = "Save Map As";
      this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(239, 6);
      // 
      // closeMapToolStripMenuItem
      // 
      this.closeMapToolStripMenuItem.Name = "closeMapToolStripMenuItem";
      this.closeMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
      this.closeMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
      this.closeMapToolStripMenuItem.Text = "Close Map";
      this.closeMapToolStripMenuItem.Click += new System.EventHandler(this.closeMapToolStripMenuItem_Click);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRedAlertDirectoryToolStripMenuItem,
            this.reloadDirectoryContentsToolStripMenuItem});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // setRedAlertDirectoryToolStripMenuItem
      // 
      this.setRedAlertDirectoryToolStripMenuItem.Name = "setRedAlertDirectoryToolStripMenuItem";
      this.setRedAlertDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.setRedAlertDirectoryToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
      this.setRedAlertDirectoryToolStripMenuItem.Text = "Set Red Alert directory";
      this.setRedAlertDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setRedAlertDirectoryToolStripMenuItem_Click);
      // 
      // reloadDirectoryContentsToolStripMenuItem
      // 
      this.reloadDirectoryContentsToolStripMenuItem.Name = "reloadDirectoryContentsToolStripMenuItem";
      this.reloadDirectoryContentsToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
      this.reloadDirectoryContentsToolStripMenuItem.Text = "Reload directory contents";
      this.reloadDirectoryContentsToolStripMenuItem.Click += new System.EventHandler(this.reloadDirectoryContentsToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapAttributesToolStripMenuItem,
            this.shiftMapToolStripMenuItem,
            this.basicToolStripMenuItem,
            this.housesToolStripMenuItem,
            this.missionStringsToolStripMenuItem,
            this.triggersToolStripMenuItem1,
            this.teamTypesToolStripMenuItem1});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // mapAttributesToolStripMenuItem
      // 
      this.mapAttributesToolStripMenuItem.Name = "mapAttributesToolStripMenuItem";
      this.mapAttributesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
      this.mapAttributesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.mapAttributesToolStripMenuItem.Text = "Map Attributes";
      this.mapAttributesToolStripMenuItem.Click += new System.EventHandler(this.mapAttributesToolStripMenuItem_Click);
      // 
      // shiftMapToolStripMenuItem
      // 
      this.shiftMapToolStripMenuItem.Name = "shiftMapToolStripMenuItem";
      this.shiftMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
      this.shiftMapToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.shiftMapToolStripMenuItem.Text = "Shift Map";
      this.shiftMapToolStripMenuItem.Click += new System.EventHandler(this.shiftMapToolStripMenuItem_Click);
      // 
      // basicToolStripMenuItem
      // 
      this.basicToolStripMenuItem.Name = "basicToolStripMenuItem";
      this.basicToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
      this.basicToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.basicToolStripMenuItem.Text = "Basic";
      this.basicToolStripMenuItem.Click += new System.EventHandler(this.basicToolStripMenuItem_Click);
      // 
      // housesToolStripMenuItem
      // 
      this.housesToolStripMenuItem.Name = "housesToolStripMenuItem";
      this.housesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.housesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.housesToolStripMenuItem.Text = "Houses";
      this.housesToolStripMenuItem.Click += new System.EventHandler(this.housesToolStripMenuItem_Click);
      // 
      // missionStringsToolStripMenuItem
      // 
      this.missionStringsToolStripMenuItem.Name = "missionStringsToolStripMenuItem";
      this.missionStringsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
      this.missionStringsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.missionStringsToolStripMenuItem.Text = "Mission Strings";
      this.missionStringsToolStripMenuItem.Click += new System.EventHandler(this.missionStringsToolStripMenuItem_Click);
      // 
      // triggersToolStripMenuItem1
      // 
      this.triggersToolStripMenuItem1.Name = "triggersToolStripMenuItem1";
      this.triggersToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
      this.triggersToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
      this.triggersToolStripMenuItem1.Text = "Triggers";
      this.triggersToolStripMenuItem1.Click += new System.EventHandler(this.triggersToolStripMenuItem_Click);
      // 
      // teamTypesToolStripMenuItem1
      // 
      this.teamTypesToolStripMenuItem1.Name = "teamTypesToolStripMenuItem1";
      this.teamTypesToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.teamTypesToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
      this.teamTypesToolStripMenuItem1.Text = "TeamTypes";
      this.teamTypesToolStripMenuItem1.Click += new System.EventHandler(this.teamTypesToolStripMenuItem_Click);
      // 
      // insertToolStripMenuItem
      // 
      this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateToolStripMenuItem,
            this.overlayToolStripMenuItem,
            this.terrainToolStripMenuItem,
            this.smudgeToolStripMenuItem,
            this.toolStripSeparator1,
            this.infantryToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.shipToolStripMenuItem,
            this.structureToolStripMenuItem,
            this.baseBuildingToolStripMenuItem,
            this.toolStripSeparator2,
            this.waypointToolStripMenuItem,
            this.cellTagToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearToolStripMenuItem,
            this.copySelectedCellsToolStripMenuItem,
            this.pasteSelectedCellsToolStripMenuItem,
            this.saveSelectedCellsInExtractToolStripMenuItem,
            this.deleteObjectsInSelectionToolStripMenuItem,
            this.clearTemplateInSelectionToolStripMenuItem});
      this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
      this.insertToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.insertToolStripMenuItem.Text = "Insert";
      // 
      // templateToolStripMenuItem
      // 
      this.templateToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_template;
      this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
      this.templateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
      this.templateToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.templateToolStripMenuItem.Text = "Template";
      this.templateToolStripMenuItem.Click += new System.EventHandler(this.bLayerTemplate_Click);
      // 
      // overlayToolStripMenuItem
      // 
      this.overlayToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_overlay;
      this.overlayToolStripMenuItem.Name = "overlayToolStripMenuItem";
      this.overlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
      this.overlayToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.overlayToolStripMenuItem.Text = "Overlay";
      this.overlayToolStripMenuItem.Click += new System.EventHandler(this.bLayerOverlay_Click);
      // 
      // terrainToolStripMenuItem
      // 
      this.terrainToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_terrain;
      this.terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
      this.terrainToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
      this.terrainToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.terrainToolStripMenuItem.Text = "Terrain";
      this.terrainToolStripMenuItem.Click += new System.EventHandler(this.bLayerTerrain_Click);
      // 
      // smudgeToolStripMenuItem
      // 
      this.smudgeToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_smudge;
      this.smudgeToolStripMenuItem.Name = "smudgeToolStripMenuItem";
      this.smudgeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
      this.smudgeToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.smudgeToolStripMenuItem.Text = "Smudge";
      this.smudgeToolStripMenuItem.Click += new System.EventHandler(this.bLayerSmudge_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(330, 6);
      // 
      // infantryToolStripMenuItem
      // 
      this.infantryToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_infantry;
      this.infantryToolStripMenuItem.Name = "infantryToolStripMenuItem";
      this.infantryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
      this.infantryToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.infantryToolStripMenuItem.Text = "Infantry";
      this.infantryToolStripMenuItem.Click += new System.EventHandler(this.bLayerInfantry_Click);
      // 
      // unitToolStripMenuItem
      // 
      this.unitToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_units;
      this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
      this.unitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D6)));
      this.unitToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.unitToolStripMenuItem.Text = "Unit";
      this.unitToolStripMenuItem.Click += new System.EventHandler(this.bLayerUnits_Click);
      // 
      // shipToolStripMenuItem
      // 
      this.shipToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_ships;
      this.shipToolStripMenuItem.Name = "shipToolStripMenuItem";
      this.shipToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D7)));
      this.shipToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.shipToolStripMenuItem.Text = "Ship";
      this.shipToolStripMenuItem.Click += new System.EventHandler(this.bLayerShips_Click);
      // 
      // structureToolStripMenuItem
      // 
      this.structureToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_structures;
      this.structureToolStripMenuItem.Name = "structureToolStripMenuItem";
      this.structureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D8)));
      this.structureToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.structureToolStripMenuItem.Text = "Structure";
      this.structureToolStripMenuItem.Click += new System.EventHandler(this.bLayerStructures_Click);
      // 
      // baseBuildingToolStripMenuItem
      // 
      this.baseBuildingToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_bases;
      this.baseBuildingToolStripMenuItem.Name = "baseBuildingToolStripMenuItem";
      this.baseBuildingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D9)));
      this.baseBuildingToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.baseBuildingToolStripMenuItem.Text = "Base Building";
      this.baseBuildingToolStripMenuItem.Click += new System.EventHandler(this.bLayerBases_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(330, 6);
      // 
      // waypointToolStripMenuItem
      // 
      this.waypointToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_waypoint;
      this.waypointToolStripMenuItem.Name = "waypointToolStripMenuItem";
      this.waypointToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
      this.waypointToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.waypointToolStripMenuItem.Text = "Waypoint";
      this.waypointToolStripMenuItem.Click += new System.EventHandler(this.bLayerWaypoints_Click);
      // 
      // cellTagToolStripMenuItem
      // 
      this.cellTagToolStripMenuItem.Image = global::RA_Mission_Editor.Properties.Resources.button_celltriggers;
      this.cellTagToolStripMenuItem.Name = "cellTagToolStripMenuItem";
      this.cellTagToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.OemMinus)));
      this.cellTagToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.cellTagToolStripMenuItem.Text = "Cell Tag";
      this.cellTagToolStripMenuItem.Click += new System.EventHandler(this.bLayerCellTriggers_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(330, 6);
      // 
      // clearToolStripMenuItem
      // 
      this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
      this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
      this.clearToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.clearToolStripMenuItem.Text = "Select Mode";
      this.clearToolStripMenuItem.Click += new System.EventHandler(this.bLayerNone_Click);
      // 
      // copySelectedCellsToolStripMenuItem
      // 
      this.copySelectedCellsToolStripMenuItem.Name = "copySelectedCellsToolStripMenuItem";
      this.copySelectedCellsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copySelectedCellsToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.copySelectedCellsToolStripMenuItem.Text = "Copy Selected Cells";
      this.copySelectedCellsToolStripMenuItem.Click += new System.EventHandler(this.copySelectedCellsToolStripMenuItem_Click);
      // 
      // pasteSelectedCellsToolStripMenuItem
      // 
      this.pasteSelectedCellsToolStripMenuItem.Name = "pasteSelectedCellsToolStripMenuItem";
      this.pasteSelectedCellsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteSelectedCellsToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.pasteSelectedCellsToolStripMenuItem.Text = "Paste Selected Cells";
      this.pasteSelectedCellsToolStripMenuItem.Click += new System.EventHandler(this.pasteSelectedCellsToolStripMenuItem_Click);
      // 
      // saveSelectedCellsInExtractToolStripMenuItem
      // 
      this.saveSelectedCellsInExtractToolStripMenuItem.Name = "saveSelectedCellsInExtractToolStripMenuItem";
      this.saveSelectedCellsInExtractToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.saveSelectedCellsInExtractToolStripMenuItem.Text = "Save Selected Cells in Extract";
      this.saveSelectedCellsInExtractToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedCellsInExtractToolStripMenuItem_Click);
      // 
      // deleteObjectsInSelectionToolStripMenuItem
      // 
      this.deleteObjectsInSelectionToolStripMenuItem.Name = "deleteObjectsInSelectionToolStripMenuItem";
      this.deleteObjectsInSelectionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.deleteObjectsInSelectionToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.deleteObjectsInSelectionToolStripMenuItem.Text = "Delete Objects in Selection";
      this.deleteObjectsInSelectionToolStripMenuItem.Click += new System.EventHandler(this.deleteObjectsInSelectionToolStripMenuItem_Click);
      // 
      // clearTemplateInSelectionToolStripMenuItem
      // 
      this.clearTemplateInSelectionToolStripMenuItem.Name = "clearTemplateInSelectionToolStripMenuItem";
      this.clearTemplateInSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
      this.clearTemplateInSelectionToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
      this.clearTemplateInSelectionToolStripMenuItem.Text = "Clear Template in Selection";
      this.clearTemplateInSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearTemplateInSelectionToolStripMenuItem_Click);
      // 
      // advancedToolStripMenuItem
      // 
      this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editINIToolStripMenuItem,
            this.openOtherEditorToolStripMenuItem});
      this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
      this.advancedToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
      this.advancedToolStripMenuItem.Text = "Advanced";
      // 
      // editINIToolStripMenuItem
      // 
      this.editINIToolStripMenuItem.Name = "editINIToolStripMenuItem";
      this.editINIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
      this.editINIToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.editINIToolStripMenuItem.Text = "INI Editor";
      this.editINIToolStripMenuItem.Click += new System.EventHandler(this.editINIToolStripMenuItem_Click);
      // 
      // openOtherEditorToolStripMenuItem
      // 
      this.openOtherEditorToolStripMenuItem.Name = "openOtherEditorToolStripMenuItem";
      this.openOtherEditorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.openOtherEditorToolStripMenuItem.Text = "Open Other Editor";
      this.openOtherEditorToolStripMenuItem.Click += new System.EventHandler(this.openOtherEditorToolStripMenuItem_Click);
      // 
      // visibilityToolStripMenuItem
      // 
      this.visibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlayToolStripMenuItem1,
            this.terrainToolStripMenuItem1,
            this.smudgeToolStripMenuItem1,
            this.infantryToolStripMenuItem1,
            this.unitsToolStripMenuItem,
            this.shipsToolStripMenuItem,
            this.structuresToolStripMenuItem,
            this.basesToolStripMenuItem,
            this.waypointsToolStripMenuItem,
            this.cellTriggersToolStripMenuItem,
            this.boundsToolStripMenuItem,
            this.templateColorsToolStripMenuItem});
      this.visibilityToolStripMenuItem.Name = "visibilityToolStripMenuItem";
      this.visibilityToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
      this.visibilityToolStripMenuItem.Text = "Visibility";
      // 
      // overlayToolStripMenuItem1
      // 
      this.overlayToolStripMenuItem1.Checked = true;
      this.overlayToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.overlayToolStripMenuItem1.Name = "overlayToolStripMenuItem1";
      this.overlayToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.overlayToolStripMenuItem1.Text = "Overlay";
      this.overlayToolStripMenuItem1.Click += new System.EventHandler(this.overlayToolStripMenuItem1_Click);
      // 
      // terrainToolStripMenuItem1
      // 
      this.terrainToolStripMenuItem1.Checked = true;
      this.terrainToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.terrainToolStripMenuItem1.Name = "terrainToolStripMenuItem1";
      this.terrainToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.terrainToolStripMenuItem1.Text = "Terrain";
      this.terrainToolStripMenuItem1.Click += new System.EventHandler(this.terrainToolStripMenuItem1_Click);
      // 
      // smudgeToolStripMenuItem1
      // 
      this.smudgeToolStripMenuItem1.Checked = true;
      this.smudgeToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.smudgeToolStripMenuItem1.Name = "smudgeToolStripMenuItem1";
      this.smudgeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.smudgeToolStripMenuItem1.Text = "Smudge";
      this.smudgeToolStripMenuItem1.Click += new System.EventHandler(this.smudgeToolStripMenuItem1_Click);
      // 
      // infantryToolStripMenuItem1
      // 
      this.infantryToolStripMenuItem1.Checked = true;
      this.infantryToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.infantryToolStripMenuItem1.Name = "infantryToolStripMenuItem1";
      this.infantryToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.infantryToolStripMenuItem1.Text = "Infantry";
      this.infantryToolStripMenuItem1.Click += new System.EventHandler(this.infantryToolStripMenuItem1_Click);
      // 
      // unitsToolStripMenuItem
      // 
      this.unitsToolStripMenuItem.Checked = true;
      this.unitsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
      this.unitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.unitsToolStripMenuItem.Text = "Units";
      this.unitsToolStripMenuItem.Click += new System.EventHandler(this.unitsToolStripMenuItem_Click);
      // 
      // shipsToolStripMenuItem
      // 
      this.shipsToolStripMenuItem.Checked = true;
      this.shipsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.shipsToolStripMenuItem.Name = "shipsToolStripMenuItem";
      this.shipsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.shipsToolStripMenuItem.Text = "Ships";
      this.shipsToolStripMenuItem.Click += new System.EventHandler(this.shipsToolStripMenuItem_Click);
      // 
      // structuresToolStripMenuItem
      // 
      this.structuresToolStripMenuItem.Checked = true;
      this.structuresToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.structuresToolStripMenuItem.Name = "structuresToolStripMenuItem";
      this.structuresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.structuresToolStripMenuItem.Text = "Structures";
      this.structuresToolStripMenuItem.Click += new System.EventHandler(this.structuresToolStripMenuItem_Click);
      // 
      // basesToolStripMenuItem
      // 
      this.basesToolStripMenuItem.Checked = true;
      this.basesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.basesToolStripMenuItem.Name = "basesToolStripMenuItem";
      this.basesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.basesToolStripMenuItem.Text = "Bases";
      this.basesToolStripMenuItem.Click += new System.EventHandler(this.basesToolStripMenuItem_Click);
      // 
      // waypointsToolStripMenuItem
      // 
      this.waypointsToolStripMenuItem.Checked = true;
      this.waypointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.waypointsToolStripMenuItem.Name = "waypointsToolStripMenuItem";
      this.waypointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.waypointsToolStripMenuItem.Text = "Waypoints";
      this.waypointsToolStripMenuItem.Click += new System.EventHandler(this.waypointsToolStripMenuItem_Click);
      // 
      // cellTriggersToolStripMenuItem
      // 
      this.cellTriggersToolStripMenuItem.Checked = true;
      this.cellTriggersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cellTriggersToolStripMenuItem.Name = "cellTriggersToolStripMenuItem";
      this.cellTriggersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.cellTriggersToolStripMenuItem.Text = "Cell Triggers";
      this.cellTriggersToolStripMenuItem.Click += new System.EventHandler(this.cellTriggersToolStripMenuItem_Click);
      // 
      // boundsToolStripMenuItem
      // 
      this.boundsToolStripMenuItem.Checked = true;
      this.boundsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.boundsToolStripMenuItem.Name = "boundsToolStripMenuItem";
      this.boundsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.boundsToolStripMenuItem.Text = "Bounds";
      this.boundsToolStripMenuItem.Click += new System.EventHandler(this.boundsToolStripMenuItem_Click);
      // 
      // statisticsToolStripMenuItem
      // 
      this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStatisticsToolStripMenuItem});
      this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
      this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
      this.statisticsToolStripMenuItem.Text = "Statistics";
      // 
      // viewStatisticsToolStripMenuItem
      // 
      this.viewStatisticsToolStripMenuItem.Name = "viewStatisticsToolStripMenuItem";
      this.viewStatisticsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
      this.viewStatisticsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
      this.viewStatisticsToolStripMenuItem.Text = "View Statistics";
      this.viewStatisticsToolStripMenuItem.Click += new System.EventHandler(this.viewStatisticsToolStripMenuItem_Click);
      // 
      // renderToolStripMenuItem
      // 
      this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderToImageToolStripMenuItem});
      this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
      this.renderToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.renderToolStripMenuItem.Text = "Render";
      // 
      // renderToImageToolStripMenuItem
      // 
      this.renderToImageToolStripMenuItem.Name = "renderToImageToolStripMenuItem";
      this.renderToImageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
      this.renderToImageToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.renderToImageToolStripMenuItem.Text = "Render to Image";
      this.renderToImageToolStripMenuItem.Click += new System.EventHandler(this.renderToImageToolStripMenuItem_Click);
      // 
      // testToolStripMenuItem
      // 
      this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testMapToolStripMenuItem});
      this.testToolStripMenuItem.Name = "testToolStripMenuItem";
      this.testToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.testToolStripMenuItem.Text = "Test";
      // 
      // testMapToolStripMenuItem
      // 
      this.testMapToolStripMenuItem.Name = "testMapToolStripMenuItem";
      this.testMapToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.testMapToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.testMapToolStripMenuItem.Text = "Test Map";
      this.testMapToolStripMenuItem.Click += new System.EventHandler(this.testMapToolStripMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCoord,
            this.tssCellTemplateInfo,
            this.tssCellOverlayInfo,
            this.tssCellInfo,
            this.tssBlank,
            this.tssRemark});
      this.statusStrip1.Location = new System.Drawing.Point(0, 839);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tssCoord
      // 
      this.tssCoord.AutoSize = false;
      this.tssCoord.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
      this.tssCoord.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssCoord.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssCoord.Name = "tssCoord";
      this.tssCoord.Size = new System.Drawing.Size(180, 17);
      this.tssCoord.Text = "Cell:00000 X:000 Y:000 Sub:0";
      // 
      // tssCellTemplateInfo
      // 
      this.tssCellTemplateInfo.AutoSize = false;
      this.tssCellTemplateInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
      this.tssCellTemplateInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssCellTemplateInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssCellTemplateInfo.Name = "tssCellTemplateInfo";
      this.tssCellTemplateInfo.Size = new System.Drawing.Size(60, 17);
      this.tssCellTemplateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tssCellOverlayInfo
      // 
      this.tssCellOverlayInfo.AutoSize = false;
      this.tssCellOverlayInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
      this.tssCellOverlayInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssCellOverlayInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssCellOverlayInfo.Name = "tssCellOverlayInfo";
      this.tssCellOverlayInfo.Size = new System.Drawing.Size(60, 17);
      this.tssCellOverlayInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tssCellInfo
      // 
      this.tssCellInfo.AutoSize = false;
      this.tssCellInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
      this.tssCellInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssCellInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssCellInfo.Name = "tssCellInfo";
      this.tssCellInfo.Size = new System.Drawing.Size(400, 17);
      this.tssCellInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tssBlank
      // 
      this.tssBlank.AutoSize = false;
      this.tssBlank.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssBlank.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssBlank.Name = "tssBlank";
      this.tssBlank.Size = new System.Drawing.Size(302, 17);
      this.tssBlank.Spring = true;
      this.tssBlank.Text = " ";
      this.tssBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tssRemark
      // 
      this.tssRemark.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.tssRemark.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
      this.tssRemark.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tssRemark.Name = "tssRemark";
      this.tssRemark.Size = new System.Drawing.Size(167, 17);
      this.tssRemark.Text = "Editor by lovalmidas, 2022";
      this.tssRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ttipInfo
      // 
      this.ttipInfo.AutomaticDelay = 0;
      this.ttipInfo.BackColor = System.Drawing.Color.AliceBlue;
      this.ttipInfo.OwnerDraw = true;
      this.ttipInfo.ShowAlways = true;
      this.ttipInfo.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ttipInfo_Draw);
      this.ttipInfo.Popup += new System.Windows.Forms.PopupEventHandler(this.ttipInfo_Popup);
      // 
      // templateColorsToolStripMenuItem
      // 
      this.templateColorsToolStripMenuItem.Name = "templateColorsToolStripMenuItem";
      this.templateColorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.templateColorsToolStripMenuItem.Text = "Template Colors";
      this.templateColorsToolStripMenuItem.Click += new System.EventHandler(this.templateColorsToolStripMenuItem_Click);
      // 
      // MainEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1184, 861);
      this.Controls.Add(this.splitMain);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainEditor";
      this.Text = "Red Alert Map and Mission Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
      this.Load += new System.EventHandler(this.MainEditor_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainEditor_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainEditor_KeyUp);
      this.splitMain.Panel1.ResumeLayout(false);
      this.splitMain.Panel1.PerformLayout();
      this.splitMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
      this.splitMain.ResumeLayout(false);
      this.pObjectCanvas.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbObjectCanvas)).EndInit();
      this.pText.ResumeLayout(false);
      this.pText.PerformLayout();
      this.pObjectTop.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.split2.Panel1.ResumeLayout(false);
      this.split2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.split2)).EndInit();
      this.split2.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbarZoom)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitMain;
    private System.Windows.Forms.Panel pObjectTop;
    private System.Windows.Forms.ListBox lboxObjects;
    private System.Windows.Forms.Panel pText;
    private System.Windows.Forms.TextBox tbInfo;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bLayerWaypoints;
    private System.Windows.Forms.Button bLayerTerrain;
    private System.Windows.Forms.Button bLayerOverlay;
    private System.Windows.Forms.Button bLayerTemplate;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button bLayerStructures;
    private System.Windows.Forms.Button bLayerShips;
    private System.Windows.Forms.Button bLayerUnits;
    private System.Windows.Forms.Button bLayerInfantry;
    private System.Windows.Forms.Button bLayerBases;
    private System.Windows.Forms.Button bLayerCellTriggers;
    private System.Windows.Forms.SplitContainer split2;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem setRedAlertDirectoryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeMapToolStripMenuItem;
    private UserControls.MapCanvasControl pbMapCanvas;
    private System.Windows.Forms.PictureBox pbObjectCanvas;
    private System.Windows.Forms.Button bLayerSmudge;
    private System.Windows.Forms.ToolStripStatusLabel tssCoord;
    private System.Windows.Forms.ToolStripStatusLabel tssCellInfo;
    private System.Windows.Forms.ToolStripStatusLabel tssCellTemplateInfo;
    private System.Windows.Forms.ToolStripStatusLabel tssCellOverlayInfo;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Panel pTechnoList;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem overlayToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem terrainToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem smudgeToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem infantryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem shipToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem structureToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem baseBuildingToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem waypointToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cellTagToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    private System.Windows.Forms.Label lblSelectCell;
    private System.Windows.Forms.ToolStripMenuItem openRecentMapToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolTip ttipInfo;
    private System.Windows.Forms.Button bSetEntity;
    private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editINIToolStripMenuItem;
    private UserControls.MiniMapCanvasControl pbMiniMapCanvas;
    private System.Windows.Forms.ToolStripMenuItem basicToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem housesToolStripMenuItem;
    private System.Windows.Forms.CheckBox cbHint;
    private System.Windows.Forms.Label lblHint;
    private System.Windows.Forms.ToolStripMenuItem mapAttributesToolStripMenuItem;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.TrackBar tbarZoom;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripMenuItem visibilityToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem overlayToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem terrainToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem smudgeToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem infantryToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem shipsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem structuresToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem basesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem waypointsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cellTriggersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewStatisticsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testMapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem triggersToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem teamTypesToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem missionStringsToolStripMenuItem;
    private System.Windows.Forms.Label lblPreplaceHouse;
    private System.Windows.Forms.ToolStripMenuItem importFromToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openRAbinFileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem shiftMapToolStripMenuItem;
    private System.Windows.Forms.CheckBox cbGrid;
    private System.Windows.Forms.ToolStripStatusLabel tssRemark;
    private System.Windows.Forms.ToolStripStatusLabel tssBlank;
    private System.Windows.Forms.Button bSelectMode;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ToolStripMenuItem copySelectedCellsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteSelectedCellsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteObjectsInSelectionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearTemplateInSelectionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem renderToImageToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem boundsToolStripMenuItem;
    private System.Windows.Forms.Button bExtract;
    private System.Windows.Forms.ToolStripMenuItem saveSelectedCellsInExtractToolStripMenuItem;
    private System.Windows.Forms.Panel pObjectCanvas;
    private System.Windows.Forms.ToolStripMenuItem reloadDirectoryContentsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openOtherEditorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem templateColorsToolStripMenuItem;
  }
}