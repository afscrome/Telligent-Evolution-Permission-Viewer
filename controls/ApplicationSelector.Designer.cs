namespace PermissionViewer.Controls
{
	partial class ApplicationSelector
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
			this.applicationSelectionTabs = new System.Windows.Forms.TabControl();
			this.browseApplicationTab = new System.Windows.Forms.TabPage();
			this.browseApplicationTree = new System.Windows.Forms.TreeView();
			this.searchApplicationTab = new System.Windows.Forms.TabPage();
			this.searchTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.searchLabel = new System.Windows.Forms.Label();
			this.searchButton = new System.Windows.Forms.Button();
			this.searchApplicationTree = new System.Windows.Forms.TreeView();
			this.applicationSelectionTabs.SuspendLayout();
			this.browseApplicationTab.SuspendLayout();
			this.searchApplicationTab.SuspendLayout();
			this.searchTabLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// applicationSelectionTabs
			// 
			this.applicationSelectionTabs.Controls.Add(this.browseApplicationTab);
			this.applicationSelectionTabs.Controls.Add(this.searchApplicationTab);
			this.applicationSelectionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.applicationSelectionTabs.Location = new System.Drawing.Point(0, 0);
			this.applicationSelectionTabs.Name = "applicationSelectionTabs";
			this.applicationSelectionTabs.SelectedIndex = 0;
			this.applicationSelectionTabs.Size = new System.Drawing.Size(150, 150);
			this.applicationSelectionTabs.TabIndex = 2;
			// 
			// browseApplicationTab
			// 
			this.browseApplicationTab.AutoScroll = true;
			this.browseApplicationTab.Controls.Add(this.browseApplicationTree);
			this.browseApplicationTab.Location = new System.Drawing.Point(4, 22);
			this.browseApplicationTab.Name = "browseApplicationTab";
			this.browseApplicationTab.Padding = new System.Windows.Forms.Padding(3);
			this.browseApplicationTab.Size = new System.Drawing.Size(142, 124);
			this.browseApplicationTab.TabIndex = 0;
			this.browseApplicationTab.Text = "Browse";
			this.browseApplicationTab.UseVisualStyleBackColor = true;
			// 
			// browseApplicationTree
			// 
			this.browseApplicationTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseApplicationTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.browseApplicationTree.Location = new System.Drawing.Point(3, 3);
			this.browseApplicationTree.Name = "browseApplicationTree";
			this.browseApplicationTree.ShowNodeToolTips = true;
			this.browseApplicationTree.Size = new System.Drawing.Size(136, 118);
			this.browseApplicationTree.TabIndex = 0;
			this.browseApplicationTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.browseApplicationTree_BeforeExpand);
			this.browseApplicationTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.applicationTree_AfterSelect);
			// 
			// searchApplicationTab
			// 
			this.searchApplicationTab.AutoScroll = true;
			this.searchApplicationTab.Controls.Add(this.searchTabLayoutPanel);
			this.searchApplicationTab.Location = new System.Drawing.Point(4, 22);
			this.searchApplicationTab.Name = "searchApplicationTab";
			this.searchApplicationTab.Padding = new System.Windows.Forms.Padding(3);
			this.searchApplicationTab.Size = new System.Drawing.Size(142, 124);
			this.searchApplicationTab.TabIndex = 1;
			this.searchApplicationTab.Text = "Search";
			this.searchApplicationTab.UseVisualStyleBackColor = true;
			// 
			// searchTabLayoutPanel
			// 
			this.searchTabLayoutPanel.AutoSize = true;
			this.searchTabLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.searchTabLayoutPanel.ColumnCount = 2;
			this.searchTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.searchTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.searchTabLayoutPanel.Controls.Add(this.searchTextBox, 0, 1);
			this.searchTabLayoutPanel.Controls.Add(this.searchLabel, 0, 0);
			this.searchTabLayoutPanel.Controls.Add(this.searchButton, 1, 1);
			this.searchTabLayoutPanel.Controls.Add(this.searchApplicationTree, 0, 2);
			this.searchTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
			this.searchTabLayoutPanel.Name = "searchTabLayoutPanel";
			this.searchTabLayoutPanel.RowCount = 3;
			this.searchTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.searchTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.searchTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.searchTabLayoutPanel.Size = new System.Drawing.Size(136, 118);
			this.searchTabLayoutPanel.TabIndex = 0;
			// 
			// searchTextBox
			// 
			this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchTextBox.Location = new System.Drawing.Point(3, 16);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(73, 20);
			this.searchTextBox.TabIndex = 0;
			// 
			// searchLabel
			// 
			this.searchLabel.AutoSize = true;
			this.searchTabLayoutPanel.SetColumnSpan(this.searchLabel, 2);
			this.searchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchLabel.Location = new System.Drawing.Point(3, 0);
			this.searchLabel.Name = "searchLabel";
			this.searchLabel.Size = new System.Drawing.Size(130, 13);
			this.searchLabel.TabIndex = 1;
			this.searchLabel.Text = "Search for an Application:";
			// 
			// searchButton
			// 
			this.searchButton.AutoSize = true;
			this.searchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.searchButton.Location = new System.Drawing.Point(82, 16);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(51, 23);
			this.searchButton.TabIndex = 3;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// searchApplicationTree
			// 
			this.searchTabLayoutPanel.SetColumnSpan(this.searchApplicationTree, 2);
			this.searchApplicationTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchApplicationTree.Location = new System.Drawing.Point(3, 45);
			this.searchApplicationTree.Name = "searchApplicationTree";
			this.searchApplicationTree.ShowLines = false;
			this.searchApplicationTree.ShowNodeToolTips = true;
			this.searchApplicationTree.ShowPlusMinus = false;
			this.searchApplicationTree.ShowRootLines = false;
			this.searchApplicationTree.Size = new System.Drawing.Size(130, 70);
			this.searchApplicationTree.TabIndex = 4;
			this.searchApplicationTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.applicationTree_AfterSelect);
			// 
			// ApplicationSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.applicationSelectionTabs);
			this.MinimumSize = new System.Drawing.Size(150, 150);
			this.Name = "ApplicationSelector";
			this.applicationSelectionTabs.ResumeLayout(false);
			this.browseApplicationTab.ResumeLayout(false);
			this.searchApplicationTab.ResumeLayout(false);
			this.searchApplicationTab.PerformLayout();
			this.searchTabLayoutPanel.ResumeLayout(false);
			this.searchTabLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl applicationSelectionTabs;
		private System.Windows.Forms.TabPage browseApplicationTab;
		private System.Windows.Forms.TreeView browseApplicationTree;
		private System.Windows.Forms.TabPage searchApplicationTab;
		private System.Windows.Forms.TableLayoutPanel searchTabLayoutPanel;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Label searchLabel;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.TreeView searchApplicationTree;
	}
}
