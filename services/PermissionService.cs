using System;
using System.Linq;
using System.Collections.Generic;
using PermissionViewer.Entities;
using PermissionViewer.Services;

namespace PermissionViewer.Services
{
	/// <summary>
	/// Service class for getting Permissions from a Telligent Evolution Platform community
	/// </summary>
	/// <remarks>
	/// If enumerating a collection from this class multiple times, convert
	/// the collection to a list to avoid repeated calls to the REST API
	/// </remarks>
	public class PermissionService
	{
		/// <summary>
		/// The EvolutionConnection being used to access the REST API
		/// </summary>
		public EvolutionConnection Connection { get; private set; }

		/// <summary>
		/// Creates a new PermissionService using the given EvolutionService
		/// to access the REST API of a Telligent Evolution Platform community
		/// </summary>
		/// <param name="connection">The EvolutionService to access the REST API with</param>
		public PermissionService(EvolutionConnection connection)
		{
			Connection = connection;
		}


		#region Endpoints

		/// <summary>
		/// The endpoint for getting site permissions
		/// </summary>
		private readonly static string sitePermissionsEndpoint = "/api.ashx/v2/roles/permissions.xml";

		/// <summary>
		/// The endpoint for getting permissions for a particular application
		/// </summary>
		/// <remarks>
		/// {0} = Application Type
		/// {1} = Application Id
		/// </remarks>
		private readonly static string applicationPermissionsEndpoint = "/api.ashx/v2/{0}/{1}/roles/permissions.xml";

		#endregion

		/// <summary>
		/// Gets Site Wide Permissions
		/// </summary>
		/// <returns>A list of permissions applying at the site level</returns>
		public IEnumerable<PermissionEntry> GetSitePermisisons()
		{
			return GetPermisisonsFromEndpoint(sitePermissionsEndpoint).ToList();
		}

		/// <summary>
		/// Gets permissions for a particular application
		/// </summary>
		/// <param name="application">The application to get permissions from</param>
		/// <returns></returns>
		public IEnumerable<PermissionEntry> GetApplicationPermisisons(EvolutionApplication application)
		{
			var app = GetEndpointApplicationFromApplicationType(application.ApplicationType);
			var endpoint = String.Format(applicationPermissionsEndpoint, app, application.Id);

			return GetPermisisonsFromEndpoint(endpoint).ToList();
		}

		/// <summary>
		/// Private method for getting permissions from an endpoint
		/// </summary>
		/// <param name="endpoint">The endpoint to get permissions from</param>
		/// <returns>A collection of Permissions from the given endpoint</returns>
		private IEnumerable<PermissionEntry> GetPermisisonsFromEndpoint(string endpoint)
		{
			var response = Connection.GetResponse(endpoint);

			foreach (var roleNode in response.Descendants("Role"))
			{
				var role = new Role(roleNode);

				foreach (var permission in roleNode.Descendants("PermissionEntry"))
					yield return new PermissionEntry(role, permission);
			}
		}

		private string GetEndpointApplicationFromApplicationType(string applicationType)
		{
			switch (applicationType)
			{
				case "Group":
					return "groups";
				case "Blog":
					return "blogs";
				case "Forum":
					return "forums";
				case "Media Gallery":
					return "mediagalleries";
				case "Wiki":
					return "wikis";
			}
			return String.Empty;
		}

	}

}
