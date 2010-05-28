using System;
using System.Xml.Linq;

namespace PermissionViewer.Entities
{
	/// <summary>
	/// Represents an application in the Telligent Evolution Platform
	/// e.g. Blog, Forum, Media Gallery, Wiki, Group
	/// </summary>
	public class EvolutionApplication
	{
		/// <summary>
		/// The unique Id for the current Application
		/// </summary>
		/// <remarks>This ID is only unique within the Application's ApplicationType</remarks>
		public int Id { get; protected set; }

		/// <summary>
		/// A friendly name for the application
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// A description of the application
		/// </summary>
		/// <remarks>May be null or empty</remarks>
		public string Description { get; protected set; }

		/// <summary>
		/// The type of the Application
		/// </summary>
		/// <remarks>e.g. Forum, Blog, Wiki, Media Gallery, Group</remarks>
		public string ApplicationType { get; protected set; }

		/// <summary>
		/// The ID of the group this application is in
		/// </summary>
		public int? GroupId { get; protected set; }

		/// <summary>
		/// Creates an empty EvolutionApplication object
		/// </summary>
		public EvolutionApplication() { }

		/// <summary>
		/// Creates a new EvolutionApplication populating it's values
		/// from the provided from XElement Search Result
		/// </summary>
		/// <param name="element">The XElement search result from the REST API describing an Evolution Application</param>
		public EvolutionApplication(XElement element)
		{
			if (element.Name != "SearchResult")
				throw new InvalidOperationException(String.Format("Cannot cast {0} XElement to an EvolutionApplication", element.Name));

			var tempId = -1;
			int.TryParse(element.Element("ContentId").Value, out tempId);
			if (tempId < 0)
				throw new InvalidOperationException("Application must have a ContentId");

			Id = tempId;
			Name = element.Element("Title").Value;
			Description = element.Element("Body").Value;

			var contentType = element.Element("ContentType").Value;
			ApplicationType = ConvertContentTypeToApplicationType(contentType);

			var group = element.Element("Group");
			if (group != null)
			{
				int tempGroupId = -1;
				int.TryParse(group.Element("Id").Value, out tempGroupId);
				if (tempGroupId > 0)
					GroupId = tempGroupId;
			}

		}


		/// <summary>
		/// Helper method for converting a ContentType from Search
		/// to an ApplicationType
		/// </summary>
		/// <param name="contentType">Search CotnentType</param>
		/// <returns>The item's Application Type</returns>
		public virtual string ConvertContentTypeToApplicationType(string contentType)
		{
			switch (contentType)
			{
				case "group":
					return "Group";
				case "forumapp":
					return "Forum";
				case "blogapp":
					return "Blog";
				case "fileapp":
					return "Media Gallery";
				case "wikiapp":
					return "Wiki";
				default:
					return "Unknown";
			}
		}

	}
}
