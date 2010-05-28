namespace PermissionViewer.Controls
{
	partial class ConnectionArea
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
			this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.urlFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.urlLabel = new System.Windows.Forms.Label();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.connectButton = new System.Windows.Forms.Button();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.passwordPanel = new System.Windows.Forms.Panel();
			this.apiKeyPanel = new System.Windows.Forms.Panel();
			this.usernamePanel = new System.Windows.Forms.Panel();
			this.credentialsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.apiKeyLabel = new System.Windows.Forms.Label();
			this.apiKeyTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loginButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.urlFlowLayoutPanel.SuspendLayout();
			this.passwordPanel.SuspendLayout();
			this.apiKeyPanel.SuspendLayout();
			this.usernamePanel.SuspendLayout();
			this.credentialsFlowLayoutPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainFlowLayoutPanel
			// 
			this.mainFlowLayoutPanel.AutoSize = true;
			this.mainFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainFlowLayoutPanel.Location = new System.Drawing.Point(3, 68);
			this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
			this.mainFlowLayoutPanel.Size = new System.Drawing.Size(0, 0);
			this.mainFlowLayoutPanel.TabIndex = 0;
			// 
			// urlFlowLayoutPanel
			// 
			this.urlFlowLayoutPanel.AutoSize = true;
			this.urlFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.urlFlowLayoutPanel.Controls.Add(this.urlLabel);
			this.urlFlowLayoutPanel.Controls.Add(this.urlTextBox);
			this.urlFlowLayoutPanel.Controls.Add(this.connectButton);
			this.urlFlowLayoutPanel.Controls.Add(this.disconnectButton);
			this.urlFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.urlFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
			this.urlFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.urlFlowLayoutPanel.Name = "urlFlowLayoutPanel";
			this.urlFlowLayoutPanel.Size = new System.Drawing.Size(741, 29);
			this.urlFlowLayoutPanel.TabIndex = 0;
			// 
			// urlLabel
			// 
			this.urlLabel.AutoSize = true;
			this.urlLabel.Location = new System.Drawing.Point(3, 6);
			this.urlLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.urlLabel.Name = "urlLabel";
			this.urlLabel.Size = new System.Drawing.Size(23, 13);
			this.urlLabel.TabIndex = 0;
			this.urlLabel.Text = "Url:";
			// 
			// urlTextBox
			// 
			this.urlTextBox.Location = new System.Drawing.Point(32, 3);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(300, 20);
			this.urlTextBox.TabIndex = 1;
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(338, 3);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(75, 23);
			this.connectButton.TabIndex = 2;
			this.connectButton.Text = "Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// disconnectButton
			// 
			this.disconnectButton.Location = new System.Drawing.Point(419, 3);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(75, 23);
			this.disconnectButton.TabIndex = 3;
			this.disconnectButton.Text = "Disconnect";
			this.disconnectButton.UseVisualStyleBackColor = true;
			this.disconnectButton.Visible = false;
			this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
			// 
			// passwordPanel
			// 
			this.passwordPanel.AutoSize = true;
			this.passwordPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.passwordPanel.Controls.Add(this.passwordLabel);
			this.passwordPanel.Controls.Add(this.passwordTextBox);
			this.passwordPanel.Location = new System.Drawing.Point(443, 0);
			this.passwordPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.passwordPanel.Name = "passwordPanel";
			this.passwordPanel.Size = new System.Drawing.Size(214, 28);
			this.passwordPanel.TabIndex = 9;
			this.passwordPanel.Visible = false;
			// 
			// apiKeyPanel
			// 
			this.apiKeyPanel.AutoSize = true;
			this.apiKeyPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.apiKeyPanel.Controls.Add(this.apiKeyLabel);
			this.apiKeyPanel.Controls.Add(this.apiKeyTextBox);
			this.apiKeyPanel.Location = new System.Drawing.Point(223, 0);
			this.apiKeyPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.apiKeyPanel.Name = "apiKeyPanel";
			this.apiKeyPanel.Size = new System.Drawing.Size(214, 28);
			this.apiKeyPanel.TabIndex = 8;
			// 
			// usernamePanel
			// 
			this.usernamePanel.AutoSize = true;
			this.usernamePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.usernamePanel.Controls.Add(this.usernameLabel);
			this.usernamePanel.Controls.Add(this.userNameTextBox);
			this.usernamePanel.Location = new System.Drawing.Point(3, 0);
			this.usernamePanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.usernamePanel.Name = "usernamePanel";
			this.usernamePanel.Size = new System.Drawing.Size(214, 28);
			this.usernamePanel.TabIndex = 5;
			// 
			// credentialsFlowLayoutPanel
			// 
			this.credentialsFlowLayoutPanel.AutoSize = true;
			this.credentialsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.credentialsFlowLayoutPanel.Controls.Add(this.usernamePanel);
			this.credentialsFlowLayoutPanel.Controls.Add(this.apiKeyPanel);
			this.credentialsFlowLayoutPanel.Controls.Add(this.passwordPanel);
			this.credentialsFlowLayoutPanel.Controls.Add(this.loginButton);
			this.credentialsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.credentialsFlowLayoutPanel.Location = new System.Drawing.Point(3, 32);
			this.credentialsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.credentialsFlowLayoutPanel.Name = "credentialsFlowLayoutPanel";
			this.credentialsFlowLayoutPanel.Size = new System.Drawing.Size(741, 36);
			this.credentialsFlowLayoutPanel.TabIndex = 1;
			this.credentialsFlowLayoutPanel.Visible = false;
			this.credentialsFlowLayoutPanel.WrapContents = false;
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Location = new System.Drawing.Point(0, 8);
			this.usernameLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(58, 13);
			this.usernameLabel.TabIndex = 4;
			this.usernameLabel.Text = "Username:";
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Location = new System.Drawing.Point(61, 5);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(150, 20);
			this.userNameTextBox.TabIndex = 5;
			// 
			// apiKeyLabel
			// 
			this.apiKeyLabel.AutoSize = true;
			this.apiKeyLabel.Location = new System.Drawing.Point(0, 8);
			this.apiKeyLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.apiKeyLabel.Name = "apiKeyLabel";
			this.apiKeyLabel.Size = new System.Drawing.Size(48, 13);
			this.apiKeyLabel.TabIndex = 6;
			this.apiKeyLabel.Text = "API Key:";
			// 
			// apiKeyTextBox
			// 
			this.apiKeyTextBox.Location = new System.Drawing.Point(61, 5);
			this.apiKeyTextBox.Name = "apiKeyTextBox";
			this.apiKeyTextBox.Size = new System.Drawing.Size(150, 20);
			this.apiKeyTextBox.TabIndex = 7;
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(0, 8);
			this.passwordLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(56, 13);
			this.passwordLabel.TabIndex = 8;
			this.passwordLabel.Text = "Password:";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(61, 5);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
			this.passwordTextBox.TabIndex = 9;
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(663, 3);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(75, 23);
			this.loginButton.TabIndex = 10;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.credentialsFlowLayoutPanel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.urlFlowLayoutPanel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 71);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// ConnectionArea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.mainFlowLayoutPanel);
			this.Name = "ConnectionArea";
			this.Size = new System.Drawing.Size(747, 71);
			this.urlFlowLayoutPanel.ResumeLayout(false);
			this.urlFlowLayoutPanel.PerformLayout();
			this.passwordPanel.ResumeLayout(false);
			this.passwordPanel.PerformLayout();
			this.apiKeyPanel.ResumeLayout(false);
			this.apiKeyPanel.PerformLayout();
			this.usernamePanel.ResumeLayout(false);
			this.usernamePanel.PerformLayout();
			this.credentialsFlowLayoutPanel.ResumeLayout(false);
			this.credentialsFlowLayoutPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel urlFlowLayoutPanel;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Panel passwordPanel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Panel apiKeyPanel;
		private System.Windows.Forms.Label apiKeyLabel;
		private System.Windows.Forms.TextBox apiKeyTextBox;
		private System.Windows.Forms.Panel usernamePanel;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.TextBox userNameTextBox;
		private System.Windows.Forms.FlowLayoutPanel credentialsFlowLayoutPanel;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


	}
}
