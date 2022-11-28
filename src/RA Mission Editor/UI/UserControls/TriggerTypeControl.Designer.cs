
namespace RA_Mission_Editor.UI.UserControls
{
  partial class TriggerTypeControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerTypeControl));
      this.bOK = new System.Windows.Forms.Button();
      this.bCancel = new System.Windows.Forms.Button();
      this.tbHint = new System.Windows.Forms.TextBox();
      this.lblA2P3 = new System.Windows.Forms.Label();
      this.cbA2P3 = new System.Windows.Forms.ComboBox();
      this.lblA2P2 = new System.Windows.Forms.Label();
      this.cbA2P2 = new System.Windows.Forms.ComboBox();
      this.lblA2P1 = new System.Windows.Forms.Label();
      this.cbA2P1 = new System.Windows.Forms.ComboBox();
      this.cbAction2 = new System.Windows.Forms.ComboBox();
      this.lblAction2 = new System.Windows.Forms.Label();
      this.lblA1P3 = new System.Windows.Forms.Label();
      this.cbA1P3 = new System.Windows.Forms.ComboBox();
      this.lblA1P2 = new System.Windows.Forms.Label();
      this.cbA1P2 = new System.Windows.Forms.ComboBox();
      this.lblA1P1 = new System.Windows.Forms.Label();
      this.cbA1P1 = new System.Windows.Forms.ComboBox();
      this.cbAction1 = new System.Windows.Forms.ComboBox();
      this.lblE2P = new System.Windows.Forms.Label();
      this.cbE2P = new System.Windows.Forms.ComboBox();
      this.lblAction1 = new System.Windows.Forms.Label();
      this.cbEvent2 = new System.Windows.Forms.ComboBox();
      this.lblEvent2 = new System.Windows.Forms.Label();
      this.lblE1P = new System.Windows.Forms.Label();
      this.cbE1P = new System.Windows.Forms.ComboBox();
      this.cbEvent1 = new System.Windows.Forms.ComboBox();
      this.cbEventType = new System.Windows.Forms.ComboBox();
      this.cbRepeating = new System.Windows.Forms.ComboBox();
      this.cbOwner = new System.Windows.Forms.ComboBox();
      this.lblName = new System.Windows.Forms.Label();
      this.lblEvent1 = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.lblOwner = new System.Windows.Forms.Label();
      this.lblEventType = new System.Windows.Forms.Label();
      this.lblRepeating = new System.Windows.Forms.Label();
      this.tbComment = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(363, 454);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(92, 32);
      this.bOK.TabIndex = 48;
      this.bOK.Text = "Apply";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // bCancel
      // 
      this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
      this.bCancel.Location = new System.Drawing.Point(505, 454);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(92, 32);
      this.bCancel.TabIndex = 47;
      this.bCancel.Text = "Revert";
      this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bCancel.UseVisualStyleBackColor = true;
      this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
      // 
      // tbHint
      // 
      this.tbHint.AcceptsReturn = true;
      this.tbHint.Font = new System.Drawing.Font("Consolas", 7.25F);
      this.tbHint.Location = new System.Drawing.Point(9, 332);
      this.tbHint.Multiline = true;
      this.tbHint.Name = "tbHint";
      this.tbHint.ReadOnly = true;
      this.tbHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbHint.Size = new System.Drawing.Size(588, 116);
      this.tbHint.TabIndex = 92;
      // 
      // lblA2P3
      // 
      this.lblA2P3.AutoSize = true;
      this.lblA2P3.Location = new System.Drawing.Point(417, 254);
      this.lblA2P3.Name = "lblA2P3";
      this.lblA2P3.Size = new System.Drawing.Size(19, 13);
      this.lblA2P3.TabIndex = 91;
      this.lblA2P3.Text = "P3";
      // 
      // cbA2P3
      // 
      this.cbA2P3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA2P3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA2P3.DisplayMember = "Name";
      this.cbA2P3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA2P3.FormattingEnabled = true;
      this.cbA2P3.Location = new System.Drawing.Point(411, 270);
      this.cbA2P3.Name = "cbA2P3";
      this.cbA2P3.Size = new System.Drawing.Size(161, 21);
      this.cbA2P3.TabIndex = 90;
      this.cbA2P3.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA2P3.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA2P3.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblA2P2
      // 
      this.lblA2P2.AutoSize = true;
      this.lblA2P2.Location = new System.Drawing.Point(252, 254);
      this.lblA2P2.Name = "lblA2P2";
      this.lblA2P2.Size = new System.Drawing.Size(19, 13);
      this.lblA2P2.TabIndex = 89;
      this.lblA2P2.Text = "P2";
      // 
      // cbA2P2
      // 
      this.cbA2P2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA2P2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA2P2.DisplayMember = "Name";
      this.cbA2P2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA2P2.FormattingEnabled = true;
      this.cbA2P2.Location = new System.Drawing.Point(244, 270);
      this.cbA2P2.Name = "cbA2P2";
      this.cbA2P2.Size = new System.Drawing.Size(161, 21);
      this.cbA2P2.TabIndex = 88;
      this.cbA2P2.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA2P2.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA2P2.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblA2P1
      // 
      this.lblA2P1.AutoSize = true;
      this.lblA2P1.Location = new System.Drawing.Point(87, 254);
      this.lblA2P1.Name = "lblA2P1";
      this.lblA2P1.Size = new System.Drawing.Size(19, 13);
      this.lblA2P1.TabIndex = 87;
      this.lblA2P1.Text = "P1";
      // 
      // cbA2P1
      // 
      this.cbA2P1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA2P1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA2P1.DisplayMember = "Name";
      this.cbA2P1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA2P1.FormattingEnabled = true;
      this.cbA2P1.Location = new System.Drawing.Point(77, 270);
      this.cbA2P1.Name = "cbA2P1";
      this.cbA2P1.Size = new System.Drawing.Size(161, 21);
      this.cbA2P1.TabIndex = 86;
      this.cbA2P1.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA2P1.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA2P1.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // cbAction2
      // 
      this.cbAction2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbAction2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbAction2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAction2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbAction2.FormattingEnabled = true;
      this.cbAction2.Location = new System.Drawing.Point(77, 230);
      this.cbAction2.Name = "cbAction2";
      this.cbAction2.Size = new System.Drawing.Size(292, 21);
      this.cbAction2.TabIndex = 85;
      this.cbAction2.SelectedIndexChanged += new System.EventHandler(this.cbAction2_SelectedIndexChanged);
      this.cbAction2.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbAction2.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbAction2.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblAction2
      // 
      this.lblAction2.AutoSize = true;
      this.lblAction2.Location = new System.Drawing.Point(9, 233);
      this.lblAction2.Name = "lblAction2";
      this.lblAction2.Size = new System.Drawing.Size(55, 13);
      this.lblAction2.TabIndex = 84;
      this.lblAction2.Text = "Action 2";
      // 
      // lblA1P3
      // 
      this.lblA1P3.AutoSize = true;
      this.lblA1P3.Location = new System.Drawing.Point(417, 173);
      this.lblA1P3.Name = "lblA1P3";
      this.lblA1P3.Size = new System.Drawing.Size(19, 13);
      this.lblA1P3.TabIndex = 83;
      this.lblA1P3.Text = "P3";
      // 
      // cbA1P3
      // 
      this.cbA1P3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA1P3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA1P3.DisplayMember = "Name";
      this.cbA1P3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA1P3.FormattingEnabled = true;
      this.cbA1P3.Location = new System.Drawing.Point(411, 189);
      this.cbA1P3.Name = "cbA1P3";
      this.cbA1P3.Size = new System.Drawing.Size(161, 21);
      this.cbA1P3.TabIndex = 82;
      this.cbA1P3.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA1P3.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA1P3.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblA1P2
      // 
      this.lblA1P2.AutoSize = true;
      this.lblA1P2.Location = new System.Drawing.Point(252, 173);
      this.lblA1P2.Name = "lblA1P2";
      this.lblA1P2.Size = new System.Drawing.Size(19, 13);
      this.lblA1P2.TabIndex = 81;
      this.lblA1P2.Text = "P2";
      // 
      // cbA1P2
      // 
      this.cbA1P2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA1P2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA1P2.DisplayMember = "Name";
      this.cbA1P2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA1P2.FormattingEnabled = true;
      this.cbA1P2.Location = new System.Drawing.Point(244, 189);
      this.cbA1P2.Name = "cbA1P2";
      this.cbA1P2.Size = new System.Drawing.Size(161, 21);
      this.cbA1P2.TabIndex = 80;
      this.cbA1P2.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA1P2.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA1P2.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblA1P1
      // 
      this.lblA1P1.AutoSize = true;
      this.lblA1P1.Location = new System.Drawing.Point(87, 173);
      this.lblA1P1.Name = "lblA1P1";
      this.lblA1P1.Size = new System.Drawing.Size(19, 13);
      this.lblA1P1.TabIndex = 79;
      this.lblA1P1.Text = "P1";
      // 
      // cbA1P1
      // 
      this.cbA1P1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbA1P1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbA1P1.DisplayMember = "Name";
      this.cbA1P1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbA1P1.FormattingEnabled = true;
      this.cbA1P1.Location = new System.Drawing.Point(77, 189);
      this.cbA1P1.Name = "cbA1P1";
      this.cbA1P1.Size = new System.Drawing.Size(161, 21);
      this.cbA1P1.TabIndex = 78;
      this.cbA1P1.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbA1P1.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbA1P1.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // cbAction1
      // 
      this.cbAction1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbAction1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbAction1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAction1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbAction1.FormattingEnabled = true;
      this.cbAction1.Location = new System.Drawing.Point(77, 149);
      this.cbAction1.Name = "cbAction1";
      this.cbAction1.Size = new System.Drawing.Size(292, 21);
      this.cbAction1.TabIndex = 77;
      this.cbAction1.SelectedIndexChanged += new System.EventHandler(this.cbAction1_SelectedIndexChanged);
      this.cbAction1.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbAction1.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbAction1.Enter += new System.EventHandler(this.cbAction_Enter);
      // 
      // lblE2P
      // 
      this.lblE2P.AutoSize = true;
      this.lblE2P.Location = new System.Drawing.Point(375, 99);
      this.lblE2P.Name = "lblE2P";
      this.lblE2P.Size = new System.Drawing.Size(61, 13);
      this.lblE2P.TabIndex = 76;
      this.lblE2P.Text = "Parameter";
      // 
      // cbE2P
      // 
      this.cbE2P.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbE2P.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbE2P.DisplayMember = "Name";
      this.cbE2P.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbE2P.FormattingEnabled = true;
      this.cbE2P.Location = new System.Drawing.Point(436, 96);
      this.cbE2P.Name = "cbE2P";
      this.cbE2P.Size = new System.Drawing.Size(161, 21);
      this.cbE2P.TabIndex = 75;
      this.cbE2P.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbE2P.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbE2P.Enter += new System.EventHandler(this.cbEvent_Enter);
      // 
      // lblAction1
      // 
      this.lblAction1.AutoSize = true;
      this.lblAction1.Location = new System.Drawing.Point(9, 152);
      this.lblAction1.Name = "lblAction1";
      this.lblAction1.Size = new System.Drawing.Size(55, 13);
      this.lblAction1.TabIndex = 69;
      this.lblAction1.Text = "Action 1";
      // 
      // cbEvent2
      // 
      this.cbEvent2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbEvent2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbEvent2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbEvent2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbEvent2.FormattingEnabled = true;
      this.cbEvent2.Location = new System.Drawing.Point(77, 96);
      this.cbEvent2.Name = "cbEvent2";
      this.cbEvent2.Size = new System.Drawing.Size(292, 21);
      this.cbEvent2.TabIndex = 74;
      this.cbEvent2.SelectedIndexChanged += new System.EventHandler(this.cbEvent2_SelectedIndexChanged);
      this.cbEvent2.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbEvent2.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbEvent2.Enter += new System.EventHandler(this.cbEvent_Enter);
      // 
      // lblEvent2
      // 
      this.lblEvent2.AutoSize = true;
      this.lblEvent2.Location = new System.Drawing.Point(9, 99);
      this.lblEvent2.Name = "lblEvent2";
      this.lblEvent2.Size = new System.Drawing.Size(49, 13);
      this.lblEvent2.TabIndex = 73;
      this.lblEvent2.Text = "Event 2";
      // 
      // lblE1P
      // 
      this.lblE1P.AutoSize = true;
      this.lblE1P.Location = new System.Drawing.Point(375, 72);
      this.lblE1P.Name = "lblE1P";
      this.lblE1P.Size = new System.Drawing.Size(61, 13);
      this.lblE1P.TabIndex = 72;
      this.lblE1P.Text = "Parameter";
      // 
      // cbE1P
      // 
      this.cbE1P.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbE1P.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbE1P.DisplayMember = "Name";
      this.cbE1P.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbE1P.FormattingEnabled = true;
      this.cbE1P.Location = new System.Drawing.Point(436, 69);
      this.cbE1P.Name = "cbE1P";
      this.cbE1P.Size = new System.Drawing.Size(161, 21);
      this.cbE1P.TabIndex = 71;
      this.cbE1P.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbE1P.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbE1P.Enter += new System.EventHandler(this.cbEvent_Enter);
      // 
      // cbEvent1
      // 
      this.cbEvent1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbEvent1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbEvent1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbEvent1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbEvent1.FormattingEnabled = true;
      this.cbEvent1.Location = new System.Drawing.Point(77, 69);
      this.cbEvent1.Name = "cbEvent1";
      this.cbEvent1.Size = new System.Drawing.Size(292, 21);
      this.cbEvent1.TabIndex = 70;
      this.cbEvent1.SelectedIndexChanged += new System.EventHandler(this.cbEvent1_SelectedIndexChanged);
      this.cbEvent1.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbEvent1.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbEvent1.Enter += new System.EventHandler(this.cbEvent_Enter);
      // 
      // cbEventType
      // 
      this.cbEventType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbEventType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbEventType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbEventType.FormattingEnabled = true;
      this.cbEventType.Location = new System.Drawing.Point(77, 29);
      this.cbEventType.Name = "cbEventType";
      this.cbEventType.Size = new System.Drawing.Size(520, 21);
      this.cbEventType.TabIndex = 68;
      this.cbEventType.SelectedIndexChanged += new System.EventHandler(this.cbEventType_SelectedIndexChanged);
      this.cbEventType.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbEventType.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbEventType.Enter += new System.EventHandler(this.cbEventType_Enter);
      // 
      // cbRepeating
      // 
      this.cbRepeating.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbRepeating.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbRepeating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRepeating.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbRepeating.FormattingEnabled = true;
      this.cbRepeating.Location = new System.Drawing.Point(389, 3);
      this.cbRepeating.Name = "cbRepeating";
      this.cbRepeating.Size = new System.Drawing.Size(208, 21);
      this.cbRepeating.TabIndex = 67;
      this.cbRepeating.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbRepeating.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbRepeating.Enter += new System.EventHandler(this.cbRepeating_Enter);
      // 
      // cbOwner
      // 
      this.cbOwner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbOwner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbOwner.FormattingEnabled = true;
      this.cbOwner.Location = new System.Drawing.Point(200, 3);
      this.cbOwner.Name = "cbOwner";
      this.cbOwner.Size = new System.Drawing.Size(121, 21);
      this.cbOwner.TabIndex = 66;
      this.cbOwner.SelectionChangeCommitted += new System.EventHandler(this.Value_Changed);
      this.cbOwner.TextUpdate += new System.EventHandler(this.Value_Changed);
      this.cbOwner.Enter += new System.EventHandler(this.cbOwner_Enter);
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(9, 6);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(31, 13);
      this.lblName.TabIndex = 60;
      this.lblName.Text = "Name";
      // 
      // lblEvent1
      // 
      this.lblEvent1.AutoSize = true;
      this.lblEvent1.Location = new System.Drawing.Point(9, 72);
      this.lblEvent1.Name = "lblEvent1";
      this.lblEvent1.Size = new System.Drawing.Size(49, 13);
      this.lblEvent1.TabIndex = 65;
      this.lblEvent1.Text = "Event 1";
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(50, 3);
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(100, 20);
      this.tbName.TabIndex = 61;
      this.tbName.TextChanged += new System.EventHandler(this.Value_Changed);
      this.tbName.Enter += new System.EventHandler(this.tbName_Enter);
      // 
      // lblOwner
      // 
      this.lblOwner.AutoSize = true;
      this.lblOwner.Location = new System.Drawing.Point(156, 6);
      this.lblOwner.Name = "lblOwner";
      this.lblOwner.Size = new System.Drawing.Size(37, 13);
      this.lblOwner.TabIndex = 62;
      this.lblOwner.Text = "Owner";
      // 
      // lblEventType
      // 
      this.lblEventType.AutoSize = true;
      this.lblEventType.Location = new System.Drawing.Point(9, 32);
      this.lblEventType.Name = "lblEventType";
      this.lblEventType.Size = new System.Drawing.Size(67, 13);
      this.lblEventType.TabIndex = 64;
      this.lblEventType.Text = "Event Type";
      // 
      // lblRepeating
      // 
      this.lblRepeating.AutoSize = true;
      this.lblRepeating.Location = new System.Drawing.Point(327, 6);
      this.lblRepeating.Name = "lblRepeating";
      this.lblRepeating.Size = new System.Drawing.Size(61, 13);
      this.lblRepeating.TabIndex = 63;
      this.lblRepeating.Text = "Repeating";
      // 
      // tbComment
      // 
      this.tbComment.Location = new System.Drawing.Point(77, 306);
      this.tbComment.Name = "tbComment";
      this.tbComment.Size = new System.Drawing.Size(520, 20);
      this.tbComment.TabIndex = 93;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 309);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 94;
      this.label1.Text = "Comment";
      // 
      // TriggerTypeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbComment);
      this.Controls.Add(this.tbHint);
      this.Controls.Add(this.lblA2P3);
      this.Controls.Add(this.cbA2P3);
      this.Controls.Add(this.lblA2P2);
      this.Controls.Add(this.cbA2P2);
      this.Controls.Add(this.lblA2P1);
      this.Controls.Add(this.cbA2P1);
      this.Controls.Add(this.cbAction2);
      this.Controls.Add(this.lblAction2);
      this.Controls.Add(this.lblA1P3);
      this.Controls.Add(this.cbA1P3);
      this.Controls.Add(this.lblA1P2);
      this.Controls.Add(this.cbA1P2);
      this.Controls.Add(this.lblA1P1);
      this.Controls.Add(this.cbA1P1);
      this.Controls.Add(this.cbAction1);
      this.Controls.Add(this.lblE2P);
      this.Controls.Add(this.cbE2P);
      this.Controls.Add(this.lblAction1);
      this.Controls.Add(this.cbEvent2);
      this.Controls.Add(this.lblEvent2);
      this.Controls.Add(this.lblE1P);
      this.Controls.Add(this.cbE1P);
      this.Controls.Add(this.cbEvent1);
      this.Controls.Add(this.cbEventType);
      this.Controls.Add(this.cbRepeating);
      this.Controls.Add(this.cbOwner);
      this.Controls.Add(this.lblName);
      this.Controls.Add(this.lblEvent1);
      this.Controls.Add(this.tbName);
      this.Controls.Add(this.lblOwner);
      this.Controls.Add(this.lblEventType);
      this.Controls.Add(this.lblRepeating);
      this.Controls.Add(this.bOK);
      this.Controls.Add(this.bCancel);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.Name = "TriggerTypeControl";
      this.Size = new System.Drawing.Size(600, 500);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.TextBox tbHint;
    private System.Windows.Forms.Label lblA2P3;
    private System.Windows.Forms.ComboBox cbA2P3;
    private System.Windows.Forms.Label lblA2P2;
    private System.Windows.Forms.ComboBox cbA2P2;
    private System.Windows.Forms.Label lblA2P1;
    private System.Windows.Forms.ComboBox cbA2P1;
    private System.Windows.Forms.ComboBox cbAction2;
    private System.Windows.Forms.Label lblAction2;
    private System.Windows.Forms.Label lblA1P3;
    private System.Windows.Forms.ComboBox cbA1P3;
    private System.Windows.Forms.Label lblA1P2;
    private System.Windows.Forms.ComboBox cbA1P2;
    private System.Windows.Forms.Label lblA1P1;
    private System.Windows.Forms.ComboBox cbA1P1;
    private System.Windows.Forms.ComboBox cbAction1;
    private System.Windows.Forms.Label lblE2P;
    private System.Windows.Forms.ComboBox cbE2P;
    private System.Windows.Forms.Label lblAction1;
    private System.Windows.Forms.ComboBox cbEvent2;
    private System.Windows.Forms.Label lblEvent2;
    private System.Windows.Forms.Label lblE1P;
    private System.Windows.Forms.ComboBox cbE1P;
    private System.Windows.Forms.ComboBox cbEvent1;
    private System.Windows.Forms.ComboBox cbEventType;
    private System.Windows.Forms.ComboBox cbRepeating;
    private System.Windows.Forms.ComboBox cbOwner;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblEvent1;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Label lblOwner;
    private System.Windows.Forms.Label lblEventType;
    private System.Windows.Forms.Label lblRepeating;
    private System.Windows.Forms.TextBox tbComment;
    private System.Windows.Forms.Label label1;
  }
}
