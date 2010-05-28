using System;
using System.Xml.Linq;

namespace PermissionViewer.Entities
{
	/// <summary>
	/// Represents a Role from the Telligent Eovlution Platform.
	/// </summary>
	public class Role
	{
		/// <summary>
		/// The Unique identifier of the role
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// The name of the role
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Creates a new role, populating it's value from the given XElement
		/// </summary>
		/// <param name="element">A "Role" XElement from the REST API</param>
		public Role(XElement element)
		{
			if (element.Name != "Role")
				throw new InvalidOperationException("Can only create a Role from a Role element");

			Id = int.Parse(element.Element("Id").Value);
			Name = element.Element("Name").Value;

			// HACK: The "Moderators" group role is always displayed as "Managers" in the Telligent Evolution
			//       platform UI So make that change here for consistency.
			if (Name == "Moderators" && !bool.Parse(element.Element("IsSystemRole").Value))
				Name = "Managers";
		}
	}
}
