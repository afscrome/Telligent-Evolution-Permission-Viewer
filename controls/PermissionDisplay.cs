using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PermissionViewer.Entities;
using PermissionViewer.Services;
using System.IO;
using System.Net;

namespace PermissionViewer.Controls
{
	/// <summary>
	/// User control for displaying permissions to a user
	/// </summary>
	public partial class PermissionDisplay : UserControl
	{
		/// <summary>
		/// Gets the PermissionService being used by the control
		/// </summary>
		public PermissionService PermissionService { get; private set; }

		/// <summary>
		/// Gets the GroupApplicationService being used by the control
		/// </summary>
		public GroupApplicationService GroupApplicationService { get; private set; }

		private EvolutionConnection _connection;
		/// <summary>
		/// Gets or Sets the EvolutionConnection being used by the control
		/// </summary>
		public EvolutionConnection Connection
		{
			get { return _connection; }
			set
			{
				_connection = value;
				PermissionService = new PermissionService(value);
				GroupApplicationService = new GroupApplicationService(value);
			}
		}

		private EvolutionApplication _currentApplication;
		/// <summary>
		/// Gets or Sets the Application to show permissions for
		/// </summary>
		/// <remarks>If null, displays sitewide permissions</remarks>
		public EvolutionApplication CurrentApplication
		{
			get { return _currentApplication; }
			set
			{
				_currentApplication = value;
				if (Connection != null)
					UpdatePermissionDisplay();
			}
		}


		/// <summary>
		/// Creates a new PermissionDisplay object
		/// </summary>
		public PermissionDisplay()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Event handler for the Click event of the "Show Site Permissions" button
		/// </summary>
		private void sitePermissionsButton_Click(object sender, EventArgs e)
		{
			CurrentApplication = null;
		}

		/// <summary>
		/// Event handler for the Click event of the Export button
		/// </summary>
		private void exportButton_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog()
			{
				Filter = "HTML File (*.html)|*.html",
				FileName = "PermissionReport.html",
				AddExtension = true,
				DefaultExt = "html",
				RestoreDirectory = true,
			};

			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				var stream = saveFileDialog.OpenFile();
				if (stream != null)
				{
					var writer = new StreamWriter(stream);
					BuildExportReport(writer);
					writer.Close();
				}
			}
		}

		/// <summary>
		/// Updates the Permission Display to show permissions
		/// for the CurrentApplication
		/// </summary>
		protected virtual void UpdatePermissionDisplay()
		{
			IEnumerable<PermissionEntry> permissions;
			var report = new PermissionReport();
			try
			{
				if (CurrentApplication == null)
				{
					permissions = PermissionService.GetSitePermisisons();
					report.AddTitle("Overall Site Permissions");
				}
				else
				{
					permissions = PermissionService.GetApplicationPermisisons(CurrentApplication);
					report.AddApplicationTitle(CurrentApplication);
				}

				// Convert permissions to array to prevent LINQ queries hitting the permissions 
				// endpoint multiple times
				report.AddPermissionGrid(permissions.ToArray());

				permissionDisplayBrowser.DocumentText = report.WriteReport();
			}
			catch (WebException ex)
			{
				StringBuilder b = new StringBuilder("<h1>An error occured obtaining permissions</h1>");
				b.Append("<p>");
				b.Append(ex.GetType().ToString());
				b.Append("<br />");
				b.Append(ex.Message);
				b.Append("</p>");
				var reader = new StreamReader(ex.Response.GetResponseStream());
				b.Append(reader.ReadToEnd());

				permissionDisplayBrowser.DocumentText = b.ToString();
			}
		}

		/// <summary>
		/// Builds the Permissions report to export to an HTML file
		/// </summary>
		/// <param name="writer">The StreamWriter to write the report to</param>
		protected virtual void BuildExportReport(StreamWriter writer)
		{
			var application = CurrentApplication;
			var report = new PermissionReport();

			while (application != null)
			{
				var appPermissions = PermissionService.GetApplicationPermisisons(application);

				report.AddApplicationTitle(application)
						.AddPermissionGrid(appPermissions);

				if (application.GroupId.HasValue)
					application = GroupApplicationService.GetGroup(application.GroupId.Value);
				else
					application = null;
			}

			var sitePermissions = PermissionService.GetSitePermisisons();
			report.AddTitle("Overall Site Permissions")
					.AddPermissionGrid(sitePermissions);

			writer.Write(report.WriteReport());
		}

	}
}
