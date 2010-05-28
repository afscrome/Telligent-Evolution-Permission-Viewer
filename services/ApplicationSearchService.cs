using System;
using System.Collections.Generic;
using System.Linq;
using PermissionViewer.Entities;

namespace PermissionViewer.Services
{
	/// <summary>
	/// Service class for getting Groups and Applications from the REST API
	/// </summary>
	/// <remarks>
	/// If enumerating a collection from this class multiple times, convert
	/// the collection to a list to avoid repeated calls to the REST API
	/// </remarks>
	public class GroupApplicationService
	{
		/// <summary>
		/// The EvolutionConnection used to access the REST API
		/// </summary>
		public EvolutionConnection Connection { get; private set; }


		/// <summary>
		/// Creates a new GroupApplicationService object
		/// </summary>
		/// <param name="connection">
		/// The EvolutionConnection used to access the Telligent
		/// Evolution Platform REST API
		/// </param>
		public GroupApplicationService(EvolutionConnection connection)
		{
			Connection = connection;
		}


		/// <summary>
		/// The endpoint format used for getting child groups
		/// </summary>
		private static readonly string childGroupEndpoint = "/api.ashx/v2/groups/{0}/groups.xml?pagesize=100";
		/// <summary>
		/// Gets the child groups of the given group
		/// </summary>
		/// <param name="parentGroupId">The groupId to get children of</param>
		/// <returns>A collection of applications that are children of the specified group</returns>
		public IEnumerable<EvolutionGroup> GetChildGroups(int parentGroupId)
		{
			var endpoint = string.Format(childGroupEndpoint, parentGroupId);
			var response = Connection.GetResponse(endpoint);

			foreach (var child in response.Descendants("Group"))
				yield return new EvolutionGroup(child);
		}

		/// <summary>
		/// The endpoint format used for getting child groups
		/// </summary>
		private static readonly string individualGroupEndpoint = "/api.ashx/v2/groups/{0}.xml";
		/// <summary>
		/// Gets a group
		/// </summary>
		/// <param name="groupId">The ID of the group to get</param>
		/// <returns>The group if it could be found, otherwise null</returns>
		public EvolutionGroup GetGroup(int groupId)
		{
			var endpoint = string.Format(individualGroupEndpoint, groupId);
			var response = Connection.GetResponse(endpoint);

			var group = response.Descendants("Group").FirstOrDefault();
			if (group == null)
				return null;

			return new EvolutionGroup(group);
		}
	
		/// <summary>
		/// The endpoint format used for a search query
		/// </summary>
		/// <remarks>
		/// {0} = search query
		/// </remarks>
		private static readonly string searchEndpoint = "/api.ashx/v2/search.xml?query={0}&filters=type::forumapp,blogapp,wikiapp,fileapp,group&pageSize=100";

		/// <summary>
		/// Returns all applications contained in the given group
		/// </summary>
		/// <param name="groupId">The Group to get all applications from</param>
		/// <returns>A collections of groups and applications contained in the requested group</returns>
		public ICollection<EvolutionApplication> GetApplicationsInGroup(int groupId)
		{
			var appEndpoint = string.Format(childAppEndpoint, groupId);
			var childApps = GetContentFromSearchEndpoint(appEndpoint);

			var childGroups = GetChildGroups(groupId);

			return childGroups.Cast<EvolutionApplication>().Concat(childApps).ToList();
		}

		/// <summary>
		/// The search endpoint format for getting applications in a particular group
		/// </summary>
		/// <remarks>
		/// {0} = group id to get children in
		/// </remarks>
		private static readonly string childAppEndpoint = "/api.ashx/v2/search.xml?filters=type::forumapp,blogapp,wikiapp,fileapp||group::{0}&pageSize=100";

		/// <summary>
		/// Searches for applications matching the given search query
		/// </summary>
		/// <param name="query">A query to search for applications with</param>
		/// <returns>A collection of EvolutionApplications matching the search query</returns>
		public ICollection<EvolutionApplication> Search(string query)
		{
			// Encode the search query
			query = Uri.EscapeDataString(query);
			var endpoint = string.Format(searchEndpoint, query);
			return GetContentFromSearchEndpoint(endpoint).ToList();
		}


		/// <summary>
		/// Helper method to get a collection of Applications from the a search endpoint
		/// </summary>
		/// <param name="endpoint">A search endpoint to obtain applications from</param>
		/// <returns>A collection of groups and applications found by the given search endpoint</returns>
		private IEnumerable<EvolutionApplication> GetContentFromSearchEndpoint(string endpoint)
		{
			var response = Connection.GetResponse(endpoint);

			foreach (var child in response.Descendants("SearchResult"))
				if (child.Element("ContentType").Value == "group" && child.Element("Group") != null)
					yield return new EvolutionGroup(child.Element("Group"));
				else
					yield return new EvolutionApplication(child);
		}
	}
}
