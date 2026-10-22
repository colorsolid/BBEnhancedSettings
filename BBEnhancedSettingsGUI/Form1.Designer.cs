namespace BBEnhancedSettingsGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            settingDescriptionPanel = new Panel();
            settingDescriptionLabel = new Label();
            saveButton = new Button();
            savedStatusLabel = new Label();
            savedStatusPanel = new Panel();
            settingTitleLabel = new Label();
            emevdPathTextBox = new TextBox();
            browseEmevdPathButton = new Button();
            settingsListPanel = new FlowLayoutPanel();
            clearFilterButton = new Button();
            settingsFilterInput = new TextBox();
            toolStrip1 = new ToolStrip();
            ExtrasMenu = new ToolStripDropDownButton();
            disableAllVB = new ToolStripMenuItem();
            enableAllVB = new ToolStripMenuItem();
            removeDropsButton = new ToolStripMenuItem();
            restoreDropsButton = new ToolStripMenuItem();
            removeVBFromShopsButton = new ToolStripMenuItem();
            restoreVBToShopsButton = new ToolStripMenuItem();
            disableVBStorageButton = new ToolStripMenuItem();
            enableVBStorageButton = new ToolStripMenuItem();
            settingDescriptionPanel.SuspendLayout();
            savedStatusPanel.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // settingDescriptionPanel
            // 
            settingDescriptionPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            settingDescriptionPanel.AutoScroll = true;
            settingDescriptionPanel.BackColor = Color.Transparent;
            settingDescriptionPanel.Controls.Add(settingDescriptionLabel);
            settingDescriptionPanel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingDescriptionPanel.ForeColor = SystemColors.WindowText;
            settingDescriptionPanel.Location = new Point(12, 38);
            settingDescriptionPanel.Name = "settingDescriptionPanel";
            settingDescriptionPanel.Size = new Size(324, 95);
            settingDescriptionPanel.TabIndex = 1;
            settingDescriptionPanel.Resize += SettingDescriptionPanel_Resize;
            // 
            // settingDescriptionLabel
            // 
            settingDescriptionLabel.AutoSize = true;
            settingDescriptionLabel.BackColor = Color.Transparent;
            settingDescriptionLabel.Location = new Point(0, 0);
            settingDescriptionLabel.Name = "settingDescriptionLabel";
            settingDescriptionLabel.Size = new Size(0, 15);
            settingDescriptionLabel.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveButton.Enabled = false;
            saveButton.Location = new Point(343, 38);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(80, 42);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // savedStatusLabel
            // 
            savedStatusLabel.Dock = DockStyle.Fill;
            savedStatusLabel.Location = new Point(0, 0);
            savedStatusLabel.Name = "savedStatusLabel";
            savedStatusLabel.Size = new Size(80, 23);
            savedStatusLabel.TabIndex = 0;
            savedStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // savedStatusPanel
            // 
            savedStatusPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            savedStatusPanel.Controls.Add(savedStatusLabel);
            savedStatusPanel.Location = new Point(343, 86);
            savedStatusPanel.Name = "savedStatusPanel";
            savedStatusPanel.Size = new Size(80, 23);
            savedStatusPanel.TabIndex = 3;
            // 
            // settingTitleLabel
            // 
            settingTitleLabel.AutoSize = true;
            settingTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            settingTitleLabel.Location = new Point(12, 9);
            settingTitleLabel.Name = "settingTitleLabel";
            settingTitleLabel.Size = new Size(0, 15);
            settingTitleLabel.TabIndex = 4;
            // 
            // emevdPathTextBox
            // 
            emevdPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emevdPathTextBox.BorderStyle = BorderStyle.FixedSingle;
            emevdPathTextBox.Location = new Point(12, 9);
            emevdPathTextBox.Name = "emevdPathTextBox";
            emevdPathTextBox.Size = new Size(324, 23);
            emevdPathTextBox.TabIndex = 1;
            // 
            // browseEmevdPathButton
            // 
            browseEmevdPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseEmevdPathButton.Location = new Point(342, 9);
            browseEmevdPathButton.Name = "browseEmevdPathButton";
            browseEmevdPathButton.Size = new Size(80, 23);
            browseEmevdPathButton.TabIndex = 5;
            browseEmevdPathButton.Text = "Browse";
            browseEmevdPathButton.UseVisualStyleBackColor = true;
            browseEmevdPathButton.Click += BrowseEmevdPathButton_Click;
            // 
            // settingsListPanel
            // 
            settingsListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            settingsListPanel.AutoScroll = true;
            settingsListPanel.BackColor = SystemColors.GradientInactiveCaption;
            settingsListPanel.FlowDirection = FlowDirection.TopDown;
            settingsListPanel.Location = new Point(12, 139);
            settingsListPanel.Name = "settingsListPanel";
            settingsListPanel.Size = new Size(411, 444);
            settingsListPanel.TabIndex = 6;
            settingsListPanel.WrapContents = false;
            // 
            // clearFilterButton
            // 
            clearFilterButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clearFilterButton.Location = new Point(347, 590);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(75, 23);
            clearFilterButton.TabIndex = 8;
            clearFilterButton.Text = "Clear";
            clearFilterButton.UseVisualStyleBackColor = true;
            clearFilterButton.Click += clearFilterButton_Click;
            // 
            // settingsFilterInput
            // 
            settingsFilterInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            settingsFilterInput.Location = new Point(12, 590);
            settingsFilterInput.Name = "settingsFilterInput";
            settingsFilterInput.Size = new Size(329, 23);
            settingsFilterInput.TabIndex = 9;
            settingsFilterInput.TextChanged += settingsFilterInput_TextChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { ExtrasMenu });
            toolStrip1.Location = new Point(343, 108);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(93, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // ExtrasMenu
            // 
            ExtrasMenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ExtrasMenu.DropDownItems.AddRange(new ToolStripItem[] { disableAllVB, enableAllVB, removeDropsButton, restoreDropsButton, removeVBFromShopsButton, restoreVBToShopsButton, disableVBStorageButton, enableVBStorageButton });
            ExtrasMenu.Image = (Image)resources.GetObject("ExtrasMenu.Image");
            ExtrasMenu.ImageTransparentColor = Color.Magenta;
            ExtrasMenu.Name = "ExtrasMenu";
            ExtrasMenu.Size = new Size(50, 22);
            ExtrasMenu.Text = "Extras";
            // 
            // disableAllVB
            // 
            disableAllVB.Name = "disableAllVB";
            disableAllVB.Size = new Size(270, 22);
            disableAllVB.Text = "Vials and Bullets: Disable all";
            disableAllVB.ToolTipText = "Disable drops, shop entries, and storage ability for vials and bullets.";
            disableAllVB.Click += disableAllVB_Click;
            // 
            // enableAllVB
            // 
            enableAllVB.Name = "enableAllVB";
            enableAllVB.Size = new Size(270, 22);
            enableAllVB.Text = "Vials and Bullets: Enable all";
            enableAllVB.ToolTipText = "Enable drops, shop entries, and storage ability for vials and bullets.";
            enableAllVB.Click += enableAllVB_Click;
            // 
            // removeDropsButton
            // 
            removeDropsButton.Name = "removeDropsButton";
            removeDropsButton.Size = new Size(270, 22);
            removeDropsButton.Text = "Vials and Bullets: Disable drops";
            removeDropsButton.ToolTipText = "Remove all item drops for blood vials and bullets from enemies and bodies throughout the game.";
            removeDropsButton.Click += removeDropsButton_Click;
            // 
            // restoreDropsButton
            // 
            restoreDropsButton.Name = "restoreDropsButton";
            restoreDropsButton.Size = new Size(270, 22);
            restoreDropsButton.Text = "Vials and Bullets: Enable drops";
            restoreDropsButton.ToolTipText = "Restore all item drops for blood vials and bullets to enemies and bodies throughout the game.";
            restoreDropsButton.Click += restoreDropsButton_Click;
            // 
            // removeVBFromShopsButton
            // 
            removeVBFromShopsButton.Name = "removeVBFromShopsButton";
            removeVBFromShopsButton.Size = new Size(270, 22);
            removeVBFromShopsButton.Text = "Vials and Bullets: Disable shop entries";
            removeVBFromShopsButton.ToolTipText = "Hide blood vials and bullets in shops.";
            removeVBFromShopsButton.Click += removeVBFromShopsButton_Click;
            // 
            // restoreVBToShopsButton
            // 
            restoreVBToShopsButton.Name = "restoreVBToShopsButton";
            restoreVBToShopsButton.Size = new Size(270, 22);
            restoreVBToShopsButton.Text = "Vials and Bullets: Enable shop entries";
            restoreVBToShopsButton.ToolTipText = "Display blood vials and bullets in shops.";
            restoreVBToShopsButton.Click += restoreVBToShopsButton_Click;
            // 
            // disableVBStorageButton
            // 
            disableVBStorageButton.Name = "disableVBStorageButton";
            disableVBStorageButton.Size = new Size(270, 22);
            disableVBStorageButton.Text = "Vials and Bullets: Disable storage";
            disableVBStorageButton.ToolTipText = "Disable ability to place blood vials and bullets into storage.";
            disableVBStorageButton.Click += disableVBStorageButton_Click;
            // 
            // enableVBStorageButton
            // 
            enableVBStorageButton.Name = "enableVBStorageButton";
            enableVBStorageButton.Size = new Size(270, 22);
            enableVBStorageButton.Text = "Vials and Bullets: Enable storage";
            enableVBStorageButton.ToolTipText = "Enable ability to place blood vials and bullets into storage.";
            enableVBStorageButton.Click += enableVBStorageButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(434, 624);
            Controls.Add(toolStrip1);
            Controls.Add(settingsFilterInput);
            Controls.Add(clearFilterButton);
            Controls.Add(settingsListPanel);
            Controls.Add(browseEmevdPathButton);
            Controls.Add(emevdPathTextBox);
            Controls.Add(settingTitleLabel);
            Controls.Add(savedStatusPanel);
            Controls.Add(saveButton);
            Controls.Add(settingDescriptionPanel);
            ForeColor = SystemColors.WindowText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(450, 396);
            Name = "Form1";
            Text = "Bloodborne Enhanced - Default Settings Customizer";
            settingDescriptionPanel.ResumeLayout(false);
            settingDescriptionPanel.PerformLayout();
            savedStatusPanel.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel settingDescriptionPanel;
        private Label settingDescriptionLabel;
        private Button saveButton;
        private Label savedStatusLabel;
        private Panel savedStatusPanel;
        private Label settingTitleLabel;
        private TextBox emevdPathTextBox;
        private Button browseEmevdPathButton;
        private FlowLayoutPanel settingsListPanel;
        private TextBox textBox1;
        private Button clearFilterButton;
        private TextBox settingsFilterInput;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton ExtrasMenu;
        private ToolStripMenuItem removeDropsButton;
        private ToolStripMenuItem restoreDropsButton;
        private ToolStripMenuItem removeVBFromShopsButton;
        private ToolStripMenuItem restoreVBToShopsButton;
        private ToolStripMenuItem disableVBStorageButton;
        private ToolStripMenuItem enableVBStorageButton;
        private ToolStripMenuItem disableAllVB;
        private ToolStripMenuItem enableAllVB;
    }
}
