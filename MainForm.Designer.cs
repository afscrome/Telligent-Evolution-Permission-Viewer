namespace PermissionViewer
{
	partial class MainForm
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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.productLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.webservicesLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.connectionGroupBox = new System.Windows.Forms.GroupBox();
			this.applicationSelectionGroupBox = new System.Windows.Forms.GroupBox();
			this.permissionDisplayGroupBox = new System.Windows.Forms.GroupBox();
			this.connectionArea1 = new PermissionViewer.Controls.ConnectionArea();
			this.applicationSelector = new PermissionViewer.Controls.ApplicationSelector();
			this.permissionDisplay = new PermissionViewer.Controls.PermissionDisplay();
			this.statusStrip.SuspendLayout();
			this.mainTableLayoutPanel.SuspendLayout();
			this.connectionGroupBox.SuspendLayout();
			this.applicationSelectionGroupBox.SuspendLayout();
			this.permissionDisplayGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productLabel,
            this.versionLabel,
            this.webservicesLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 567);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(975, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// productLabel
			// 
			this.productLabel.Name = "productLabel";
			this.productLabel.Size = new System.Drawing.Size(117, 17);
			this.productLabel.Text = "Product: UNKNOWN";
			// 
			// versionLabel
			// 
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(121, 17);
			this.versionLabel.Text = "Platform: UNKNOWN";
			// 
			// webservicesLabel
			// 
			this.webservicesLabel.Name = "webservicesLabel";
			this.webservicesLabel.Size = new System.Drawing.Size(140, 17);
			this.webservicesLabel.Text = "Webservices: UNKNOWN";
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.AutoScroll = true;
			this.mainTableLayoutPanel.AutoSize = true;
			this.mainTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTableLayoutPanel.ColumnCount = 2;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.Controls.Add(this.connectionGroupBox, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.applicationSelectionGroupBox, 0, 1);
			this.mainTableLayoutPanel.Controls.Add(this.permissionDisplayGroupBox, 1, 1);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 2;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(975, 567);
			this.mainTableLayoutPanel.TabIndex = 1;
			// 
			// connectionGroupBox
			// 
			this.connectionGroupBox.AutoSize = true;
			this.connectionGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTableLayoutPanel.SetColumnSpan(this.connectionGroupBox, 2);
			this.connectionGroupBox.Controls.Add(this.connectionArea1);
			this.connectionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.connectionGroupBox.Location = new System.Drawing.Point(3, 3);
			this.connectionGroupBox.Name = "connectionGroupBox";
			this.connectionGroupBox.Size = new System.Drawing.Size(969, 54);
			this.connectionGroupBox.TabIndex = 4;
			this.connectionGroupBox.TabStop = false;
			this.connectionGroupBox.Text = "Connection";
			// 
			// applicationSelectionGroupBox
			// 
			this.applicationSelectionGroupBox.AutoSize = true;
			this.applicationSelectionGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.applicationSelectionGroupBox.Controls.Add(this.applicationSelector);
			this.applicationSelectionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.applicationSelectionGroupBox.Location = new System.Drawing.Point(3, 63);
			this.applicationSelectionGroupBox.Name = "applicationSelectionGroupBox";
			this.applicationSelectionGroupBox.Size = new System.Drawing.Size(314, 501);
			this.applicationSelectionGroupBox.TabIndex = 3;
			this.applicationSelectionGroupBox.TabStop = false;
			this.applicationSelectionGroupBox.Text = "Application Selection";
			this.applicationSelectionGroupBox.Visible = false;
			// 
			// permissionDisplayGroupBox
			// 
			this.permissionDisplayGroupBox.AutoSize = true;
			this.permissionDisplayGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.permissionDisplayGroupBox.Controls.Add(this.permissionDisplay);
			this.permissionDisplayGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.permissionDisplayGroupBox.Location = new System.Drawing.Point(323, 63);
			this.permissionDisplayGroupBox.Name = "permissionDisplayGroupBox";
			this.permissionDisplayGroupBox.Size = new System.Drawing.Size(649, 501);
			this.permissionDisplayGroupBox.TabIndex = 5;
			this.permissionDisplayGroupBox.TabStop = false;
			this.permissionDisplayGroupBox.Text = "Permission Display";
			this.permissionDisplayGroupBox.Visible = false;
			// 
			// connectionArea1
			// 
			this.connectionArea1.AutoSize = true;
			this.connectionArea1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.connectionArea1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.connectionArea1.Location = new System.Drawing.Point(3, 16);
			this.connectionArea1.Name = "connectionArea1";
			this.connectionArea1.Size = new System.Drawing.Size(963, 35);
			this.connectionArea1.TabIndex = 0;
			this.connectionArea1.ConnectionChanged += new System.EventHandler<PermissionViewer.Controls.ConnectionChangedEventArgs>(this.connectionArea_ConnectionChanged);
			// 
			// applicationSelector
			// 
			this.applicationSelector.AutoScroll = true;
			this.applicationSelector.AutoSize = true;
			this.applicationSelector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.applicationSelector.Connection = null;
			this.applicationSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.applicationSelector.Location = new System.Drawing.Point(3, 16);
			this.applicationSelector.MinimumSize = new System.Drawing.Size(175, 150);
			this.applicationSelector.Name = "applicationSelector";
			this.applicationSelector.SelectedApplication = null;
			this.applicationSelector.Size = new System.Drawing.Size(308, 482);
			this.applicationSelector.TabIndex = 0;
			this.applicationSelector.SelectedApplicationChanged += new System.EventHandler<PermissionViewer.Controls.SelectedApplicationChangedEventArgs>(this.applicationSelector_SelectedApplicationChanged);
			// 
			// permissionDisplay
			// 
			this.permissionDisplay.AutoSize = true;
			this.permissionDisplay.Connection = null;
			this.permissionDisplay.CurrentApplication = null;
			this.permissionDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.permissionDisplay.Location = new System.Drawing.Point(3, 16);
			this.permissionDisplay.Name = "permissionDisplay";
			this.permissionDisplay.Size = new System.Drawing.Size(643, 482);
			this.permissionDisplay.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(975, 589);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Controls.Add(this.statusStrip);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Permission Viewer";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.connectionGroupBox.ResumeLayout(false);
			this.connectionGroupBox.PerformLayout();
			this.applicationSelectionGroupBox.ResumeLayout(false);
			this.applicationSelectionGroupBox.PerformLayout();
			this.permissionDisplayGroupBox.ResumeLayout(false);
			this.permissionDisplayGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
		private System.Windows.Forms.ToolStripStatusLabel productLabel;
		private System.Windows.Forms.ToolStripStatusLabel versionLabel;
		private System.Windows.Forms.ToolStripStatusLabel webservicesLabel;
		private System.Windows.Forms.GroupBox connectionGroupBox;
		private System.Windows.Forms.GroupBox applicationSelectionGroupBox;
		private PermissionViewer.Controls.ApplicationSelector applicationSelector;
		private System.Windows.Forms.GroupBox permissionDisplayGroupBox;
		private PermissionViewer.Controls.PermissionDisplay permissionDisplay;
		private PermissionViewer.Controls.ConnectionArea connectionArea1;

	}
}

