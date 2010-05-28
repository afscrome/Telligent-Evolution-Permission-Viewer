using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PermissionViewer.Entities;
using PermissionViewer.Services;
using PermissionViewer.Controls;

namespace PermissionViewer
{
	/// <summary>
	/// The main form used by the PermissionViewer application
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Creates a new MainForm object
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event handler for the ConnectionChanged event of the
		/// ConnectionArea control
		/// </summary>
		private void connectionArea_ConnectionChanged(object sender, ConnectionChangedEventArgs e)
		{
			applicationSelector.Connection = e.NewConnection;
			permissionDisplay.Connection = e.NewConnection;
			permissionDisplay.CurrentApplication = null;

			applicationSelectionGroupBox.Visible = (e.NewConnection != null);
			permissionDisplayGroupBox.Visible = (e.NewConnection != null);

			SetVersionInfo();
		}


		/// <summary>
		/// Event handler for the SelectedApplicationChanged event of
		/// the ApplicationSelector control
		/// </summary>
		private void applicationSelector_SelectedApplicationChanged(object sender, SelectedApplicationChangedEventArgs e)
		{
			var application = applicationSelector.SelectedApplication;

			permissionDisplay.CurrentApplication = application;
			permissionDisplayGroupBox.Visible = (application != null);
		}

		/// <summary>
		/// Loads version information from the EvolutionConnection and 
		/// reports it in the StatusBar at the bottom of the form
		/// </summary>
		protected void SetVersionInfo()
		{
			string product, platformVersion, webservicesVersion;
			var connection = connectionArea1.Connection;
			if (connection == null)
				product = platformVersion = webservicesVersion = "UNKNOWN";
			else
			{
				product = connection.Product;
				platformVersion = connection.PlatformVersion.ToString();
				webservicesVersion = connection.WebservicesVersion.ToString();
			}

			productLabel.Text = "Product: " + product;
			versionLabel.Text = "Platform: " + platformVersion;
			webservicesLabel.Text = "Webservices: " + webservicesVersion;

		}



	}
}
