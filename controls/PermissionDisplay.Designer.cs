namespace PermissionViewer.Controls
{
	partial class PermissionDisplay
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
			this.permissionDisplayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.permissionDisplayBrowser = new System.Windows.Forms.WebBrowser();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.exportButton = new System.Windows.Forms.Button();
			this.sitePermissionsButton = new System.Windows.Forms.Button();
			this.permissionDisplayTableLayoutPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// permissionDisplayTableLayoutPanel
			// 
			this.permissionDisplayTableLayoutPanel.AutoSize = true;
			this.permissionDisplayTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.permissionDisplayTableLayoutPanel.ColumnCount = 1;
			this.permissionDisplayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.permissionDisplayTableLayoutPanel.Controls.Add(this.permissionDisplayBrowser, 0, 0);
			this.permissionDisplayTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.permissionDisplayTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.permissionDisplayTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.permissionDisplayTableLayoutPanel.Name = "permissionDisplayTableLayoutPanel";
			this.permissionDisplayTableLayoutPanel.RowCount = 2;
			this.permissionDisplayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.permissionDisplayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.permissionDisplayTableLayoutPanel.Size = new System.Drawing.Size(602, 400);
			this.permissionDisplayTableLayoutPanel.TabIndex = 1;
			// 
			// permissionDisplayBrowser
			// 
			this.permissionDisplayBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.permissionDisplayBrowser.Location = new System.Drawing.Point(3, 3);
			this.permissionDisplayBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.permissionDisplayBrowser.Name = "permissionDisplayBrowser";
			this.permissionDisplayBrowser.Size = new System.Drawing.Size(596, 359);
			this.permissionDisplayBrowser.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.exportButton);
			this.flowLayoutPanel1.Controls.Add(this.sitePermissionsButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 368);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(596, 29);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// exportButton
			// 
			this.exportButton.AutoSize = true;
			this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exportButton.Location = new System.Drawing.Point(434, 3);
			this.exportButton.Name = "exportButton";
			this.exportButton.Size = new System.Drawing.Size(159, 23);
			this.exportButton.TabIndex = 0;
			this.exportButton.Text = "Export Permisison Report";
			this.exportButton.UseVisualStyleBackColor = true;
			this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
			// 
			// sitePermissionsButton
			// 
			this.sitePermissionsButton.AutoSize = true;
			this.sitePermissionsButton.Location = new System.Drawing.Point(305, 3);
			this.sitePermissionsButton.Name = "sitePermissionsButton";
			this.sitePermissionsButton.Size = new System.Drawing.Size(123, 23);
			this.sitePermissionsButton.TabIndex = 1;
			this.sitePermissionsButton.Text = "Show Site Permissions";
			this.sitePermissionsButton.UseVisualStyleBackColor = true;
			this.sitePermissionsButton.Click += new System.EventHandler(this.sitePermissionsButton_Click);
			// 
			// PermissionViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.permissionDisplayTableLayoutPanel);
			this.Name = "PermissionViewer";
			this.Size = new System.Drawing.Size(602, 400);
			this.permissionDisplayTableLayoutPanel.ResumeLayout(false);
			this.permissionDisplayTableLayoutPanel.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel permissionDisplayTableLayoutPanel;
		private System.Windows.Forms.WebBrowser permissionDisplayBrowser;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Button sitePermissionsButton;

	}
}
