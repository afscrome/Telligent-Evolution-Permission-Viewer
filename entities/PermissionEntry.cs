using System;
using System.Xml.Linq;

namespace PermissionViewer.Entities
{
	/// <summary>
	/// Represents a permisison entry from the Telligent Evolution REST API
	/// </summary>
	public class PermissionEntry
	{
		/// <summary>
		/// The ID of the Permission
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// The friendly name for this permission
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Is the permission granted to the role
		/// </summary>
		public bool Allowed { get; private set; }

		/// <summary>
		/// The role the Permission Entry applies to
		/// </summary>
		public Role Role { get; private set; }


		/// <summary>
		/// Creates a new Permission Entry belonging to the given Role
		/// from the given XElement
		/// </summary>
		/// <param name="role">The role this permission entry belongs to</param>
		/// <param name="element">A "PermissionEntry" XElement from the REST API</param>
		public PermissionEntry(Role role, XElement element)
		{
			if (element.Name != "PermissionEntry")
				throw new InvalidOperationException("Can only create a PermissionEntry from a PermissionEntry element");

			Role = role;
			Id = element.Element("PermissionId").Value;
			Name = element.Element("Name").Value;
			Allowed = bool.Parse(element.Element("IsAllowed").Value);
		}

	}
}
