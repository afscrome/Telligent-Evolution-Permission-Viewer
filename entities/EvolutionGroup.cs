using System;
using System.Xml.Linq;

namespace PermissionViewer.Entities
{
	/// <summary>
	/// Represents a group in the Telligent Evolution Platform
	/// </summary>
	public class EvolutionGroup : EvolutionApplication
	{
		/// <summary>
		/// The URI of the Group's Avatar
		/// </summary>
		public Uri AvatarUri { get; private set; }

		/// <summary>
		/// Creates a new group populating values from the provided XElement
		/// </summary>
		/// <param name="element">A "Group" XElement from the REST API describing the group.</param>
		public EvolutionGroup(XElement element)
		{
			if (element.Name != "Group")
				throw new InvalidOperationException(String.Format("Cannot cast {0} XElement to group", element.Name));

			int tempId = -1;
			int.TryParse(element.Element("Id").Value, out tempId);
			if (tempId < 0)
				throw new InvalidOperationException("Group must have an ID");

			Id = tempId;
			Name = element.Element("Name").Value;
			Description = element.Element("Description").Value;

			ApplicationType = "Group";
			AvatarUri = new Uri(element.Element("AvatarUrl").Value);

			int tempGroupId = -1;
			int.TryParse(element.Element("ParentGroupId").Value, out tempGroupId);
			if (tempGroupId > 0)
				GroupId = tempGroupId;

		}

	}

}
