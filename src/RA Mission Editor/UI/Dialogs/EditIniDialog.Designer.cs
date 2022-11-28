
namespace RA_Mission_Editor.UI.Dialogs
{
  partial class EditIniDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIniDialog));
      this.cbSection = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tbValue = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.bDeleteKey = new System.Windows.Forms.Button();
      this.bAddKey = new System.Windows.Forms.Button();
      this.bAddSection = new System.Windows.Forms.Button();
      this.bDeleteSection = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.lboxKeys = new System.Windows.Forms.ListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.bSetValue = new System.Windows.Forms.Button();
      this.bOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cbSection
      // 
      this.cbSection.DisplayMember = "Name";
      this.cbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSection.FormattingEnabled = true;
      this.cbSection.Location = new System.Drawing.Point(15, 87);
      this.cbSection.Name = "cbSection";
      this.cbSection.Size = new System.Drawing.Size(313, 21);
      this.cbSection.TabIndex = 49;
      this.cbSection.SelectedIndexChanged += new System.EventHandler(this.cbSection_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 71);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 50;
      this.label1.Text = "Section";
      // 
      // tbValue
      // 
      this.tbValue.Location = new System.Drawing.Point(56, 449);
      this.tbValue.Name = "tbValue";
      this.tbValue.Size = new System.Drawing.Size(398, 20);
      this.tbValue.TabIndex = 51;
      this.tbValue.TextChanged += new System.EventHandler(this.tbValue_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 452);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 13);
      this.label2.TabIndex = 52;
      this.label2.Text = "Value";
      // 
      // bDeleteKey
      // 
      this.bDeleteKey.Location = new System.Drawing.Point(460, 114);
      this.bDeleteKey.Name = "bDeleteKey";
      this.bDeleteKey.Size = new System.Drawing.Size(100, 20);
      this.bDeleteKey.TabIndex = 53;
      this.bDeleteKey.Text = "Delete Key";
      this.bDeleteKey.UseVisualStyleBackColor = true;
      this.bDeleteKey.Click += new System.EventHandler(this.bDeleteKey_Click);
      // 
      // bAddKey
      // 
      this.bAddKey.Location = new System.Drawing.Point(334, 114);
      this.bAddKey.Name = "bAddKey";
      this.bAddKey.Size = new System.Drawing.Size(120, 20);
      this.bAddKey.TabIndex = 54;
      this.bAddKey.Text = "Add New Key";
      this.bAddKey.UseVisualStyleBackColor = true;
      this.bAddKey.Click += new System.EventHandler(this.bAddKey_Click);
      // 
      // bAddSection
      // 
      this.bAddSection.Location = new System.Drawing.Point(334, 87);
      this.bAddSection.Name = "bAddSection";
      this.bAddSection.Size = new System.Drawing.Size(120, 21);
      this.bAddSection.TabIndex = 56;
      this.bAddSection.Text = "Add New Section";
      this.bAddSection.UseVisualStyleBackColor = true;
      this.bAddSection.Click += new System.EventHandler(this.bAddSection_Click);
      // 
      // bDeleteSection
      // 
      this.bDeleteSection.Location = new System.Drawing.Point(460, 87);
      this.bDeleteSection.Name = "bDeleteSection";
      this.bDeleteSection.Size = new System.Drawing.Size(100, 21);
      this.bDeleteSection.TabIndex = 55;
      this.bDeleteSection.Text = "Delete Section";
      this.bDeleteSection.UseVisualStyleBackColor = true;
      this.bDeleteSection.Click += new System.EventHandler(this.bDeleteSection_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 121);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 13);
      this.label3.TabIndex = 57;
      this.label3.Text = "Keys";
      // 
      // lboxKeys
      // 
      this.lboxKeys.FormattingEnabled = true;
      this.lboxKeys.Location = new System.Drawing.Point(15, 140);
      this.lboxKeys.Name = "lboxKeys";
      this.lboxKeys.Size = new System.Drawing.Size(545, 303);
      this.lboxKeys.TabIndex = 58;
      this.lboxKeys.SelectedIndexChanged += new System.EventHandler(this.lboxKeys_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(12, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(548, 62);
      this.label4.TabIndex = 59;
      this.label4.Text = "You may modify map INI entries here. Your changes are applied immediately. There " +
    "is no undo. Use at your own risk. \r\n\r\nThe map will be refreshed upon exit from t" +
    "his window.";
      // 
      // bSetValue
      // 
      this.bSetValue.Location = new System.Drawing.Point(460, 449);
      this.bSetValue.Name = "bSetValue";
      this.bSetValue.Size = new System.Drawing.Size(100, 20);
      this.bSetValue.TabIndex = 60;
      this.bSetValue.Text = "Set Value";
      this.bSetValue.UseVisualStyleBackColor = true;
      this.bSetValue.Click += new System.EventHandler(this.bSetValue_Click);
      // 
      // bOK
      // 
      this.bOK.Image = ((System.Drawing.Image)(resources.GetObject("bOK.Image")));
      this.bOK.Location = new System.Drawing.Point(460, 475);
      this.bOK.Name = "bOK";
      this.bOK.Size = new System.Drawing.Size(100, 32);
      this.bOK.TabIndex = 48;
      this.bOK.Text = "Close";
      this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.bOK.UseVisualStyleBackColor = true;
      this.bOK.Click += new System.EventHandler(this.bOK_Click);
      // 
      // EditIniDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(573, 510);
      this.Controls.Add(this.bSetValue);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.lboxKeys);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.bAddSection);
      this.Controls.Add(this.bDeleteSection);
      this.Controls.Add(this.bAddKey);
      this.Controls.Add(this.bDeleteKey);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbValue);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbSection);
      this.Controls.Add(this.bOK);
      this.Font = new System.Drawing.Font("Consolas", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "EditIniDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit INI Entries";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bOK;
    private System.Windows.Forms.ComboBox cbSection;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbValue;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button bDeleteKey;
    private System.Windows.Forms.Button bAddKey;
    private System.Windows.Forms.Button bAddSection;
    private System.Windows.Forms.Button bDeleteSection;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ListBox lboxKeys;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button bSetValue;
  }
}