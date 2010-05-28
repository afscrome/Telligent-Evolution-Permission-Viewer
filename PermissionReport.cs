using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PermissionViewer.Entities;

namespace PermissionViewer
{
	/// <summary>
	/// Utility class for building an HTML xocument for displaying permissions
	/// </summary>
	public class PermissionReport
	{
		/// <summary>
		/// A Collection for storing XML elements to include in the output report
		/// </summary>
		private IList<XElement> InternalElements = new List<XElement>();

		/// <summary>
		/// Writes out the HTML Report generated so far
		/// </summary>
		public string WriteReport()
		{
			var mainContent = string.Concat(InternalElements.Select(x => x.ToString()).ToArray());

			return string.Format(ReportTemplate, mainContent);
		}

		/// <summary>
		/// Adds a title into the HTML Report
		/// </summary>
		/// <param name="title">The contents of the title</param>
		public PermissionReport AddTitle(string title)
		{
			InternalElements.Add(new XElement("h2") { Value = title });
			return this;
		}

		/// <summary>
		/// Adds a title for an applicatiopn into the HTML Report
		/// </summary>
		/// <param name="application">The Application to add the title for</param>
		public PermissionReport AddApplicationTitle(EvolutionApplication application)
		{
			var builder = new StringBuilder();
			builder.Append("Permissions for: ");
			builder.Append(application.Name);
			builder.Append(" (");
			builder.Append(application.ApplicationType);
			builder.Append(" #");
			builder.Append(application.Id);
			builder.Append(")");

			AddTitle(builder.ToString());
			if (application.GroupId.HasValue)
				InternalElements.Add(new XElement("p") { Value = "In Group #" + application.GroupId.Value.ToString() });

			return this;
		}


		private readonly static string RoleReminder = "If a role is not listed in the table below, it has been granted no permissions for the application";
		/// <summary>
		/// Adds a permission grid into the HTML Report
		/// </summary>
		/// <param name="permissions">The permissions to build the permission grid with</param>
		public PermissionReport AddPermissionGrid(IEnumerable<PermissionEntry> permissions)
		{
			var reminder = new XElement("p") { Value = RoleReminder };
			InternalElements.Add(reminder);

			permissions = permissions.ToArray();
			var groupedPermissions = permissions.GroupBy(x => x.Name).ToArray();
			var table = new XElement("table");

			var roles = groupedPermissions.SelectMany(x => x.Select(y => y.Role)).Distinct();
			roles = OrderRoles(roles);

			table.Add(PermissionTableHeader(roles));
			table.Add(PermissionTableBody(roles, groupedPermissions));

			InternalElements.Add(table);

			return this;
		}

		string[] SpecialRoles = new[] { "Everyone", "Registered Users", "Members", "Managers", "Owners", "Moderators", "Administrators" };
		/// <summary>
		/// Reorders a collection of roles to place common roles in a standard order at 
		/// teh begining of hte list
		/// </summary>
		/// <param name="roles">The roles to reorder</param>
		/// <returns>An ordered list of roles</returns>
		private IEnumerable<Role> OrderRoles(IEnumerable<Role> roles)
		{
			var orderedRoles = new List<Role>();

			foreach (var specialRole in SpecialRoles)
			{
				Role role = roles.FirstOrDefault(x => x.Name == specialRole);
				if (role != null)
					orderedRoles.Add(role);
			}

			return orderedRoles.Union(roles);
		}

		/// <summary>
		/// Generates the header for a permission table
		/// </summary>
		/// <param name="roles">The roles to list in the header</param>
		/// <returns>An XElement containing the thead HTML element for a table</returns>
		private static XElement PermissionTableHeader(IEnumerable<Role> roles)
		{
			var header = new XElement("thead");
			var headerRow = new XElement("tr");

			headerRow.Add(new XElement("th") { Value = "Permission" });
			foreach (var role in roles)
				headerRow.Add(new XElement("th") { Value = role.Name });

			header.Add(headerRow);
			return header;
		}

		/// <summary>
		/// Generates the body for a permisison table
		/// </summary>
		private static XElement PermissionTableBody(IEnumerable<Role> roles, IEnumerable<IGrouping<string, PermissionEntry>> permissions)
		{
			var body = new XElement("tbody");

			foreach (var rolePermissions in permissions)
			{
				var row = new XElement("tr");
				row.Add(CreateTableCell(rolePermissions.Key, "permission-name"));

				foreach (var role in roles)
				{
					var permission = rolePermissions.Where(x => x.Role.Id == role.Id).FirstOrDefault();
					row.Add(PermissionCell(permission));
				}
				body.Add(row);
			}

			return body;
		}


		/// <summary>
		/// Creates a Table Cell for the given permission
		/// </summary>
		/// <param name="permission">The permission to display a </param>
		private static XElement PermissionCell(PermissionEntry permission)
		{
			string cssClass, value;
			if (permission == null)
			{
				cssClass = "unknown";
				value = "?";
			}
			else if (permission.Allowed)
			{
				cssClass = "granted";
				value = "X";
			}
			else
			{
				cssClass = "denied";
				value = ".";
			}

			var cell = new XElement("td") { Value = value };
			cell.SetAttributeValue("class", cssClass);

			return cell;
		}

		/// <summary>
		/// Creates an XElement for an HTML Table Cell
		/// </summary>
		/// <param name="text">The text to include in the table cell</param>
		/// <param name="cssClass">A CSS Class to apply to the table cell</param>
		/// <returns>An XElement containing an HTML td element</returns>
		private static XElement CreateTableCell(string text, string cssClass)
		{
			var cell = new XElement("td") { Value = text };
			if (!String.IsNullOrEmpty(cssClass))
				cell.SetAttributeValue("class", cssClass);

			return cell;
		}

		/// <summary>
		/// Template used to generate the final HTMl Report
		/// </summary>
		private static readonly string ReportTemplate = @"
<html>
	<head>
		<title>Permissions Report</title>
		<style type=""text/css"">
			h2 {{ margin-bottom: 0; border-bottom: solid 1px; }}
			p {{ margin: 6px 0; font-size: 14px; }}
			table {{ margin: 1em 0; border-collapse: collapse; }}
			th {{ border-top: dotted 1px #ccc; border-bottom: solid 1px #999; padding: 8px; margin: 0; font-size: 11px;}}
			td {{ border-bottom: dotted 1px #ccc; border-left: dotted 1px #ccc; padding: 1px; margin: 0; }}
               
			.granted {{ background-color: #9f9; color: green; text-align: center; }}
			.denied {{background-color: transparent; color: white; text-align: center;  }}
			.unknown {{ background-color: #ff9; color: yellow; text-align: center; }}
			.permission-name {{ border-right: solid 1px #ccc; border-right: none 0; font-size: 11px; padding: 1px; margin:0; }} 
		</style>
	</head>
	<body>{0}</body>
</html>
";
	}
}
