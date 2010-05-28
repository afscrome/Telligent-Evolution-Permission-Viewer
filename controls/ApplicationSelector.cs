using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using PermissionViewer.Entities;
using PermissionViewer.Resources;
using PermissionViewer.Services;

namespace PermissionViewer.Controls
{
	/// <summary>
	/// Allows selection of an Application from a Telligent Evolution platform community
	/// either via a tree control, or search
	/// </summary>
	public partial class ApplicationSelector : UserControl
	{
		/// <summary>
		/// Event fired whenever a new application is selected
		/// </summary>
		public event EventHandler<SelectedApplicationChangedEventArgs> SelectedApplicationChanged;

		private EvolutionApplication _selectedApplication;
		/// <summary>
		/// The currently selected Application
		/// </summary>
		public EvolutionApplication SelectedApplication
		{
			get { return _selectedApplication; }
			set
			{
				var eventArgs = new SelectedApplicationChangedEventArgs(value, SelectedApplication);

				_selectedApplication = value;

				if (SelectedApplicationChanged != null)
					SelectedApplicationChanged(this, eventArgs);
			}
		}

		/// <summary>
		/// Gets the GroupApplicationService being used by the ApplicationSelector
		/// </summary>
		public GroupApplicationService GroupApplicationService { get; private set; }

		private EvolutionConnection _connection;
		/// <summary>
		/// Gets or Sets the EvolutionService being used by the ApplicationSelector
		/// </summary>
		public EvolutionConnection Connection
		{
			get { return _connection; }
			set
			{
				_connection = value;
				GroupApplicationService = new GroupApplicationService(_connection);

				SelectedApplication = null;

				ResetApplicationTrees();
				searchTextBox.ResetText();
				ReloadBrowseTree();

				applicationSelectionTabs.SelectTab(0);
			}
		}


		/// <summary>
		/// Creates a new ApplicationSelector control
		/// </summary>
		public ApplicationSelector()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event Handler fired before a Tree Node is expanded
		/// </summary>
		/// <remarks>This event handler is used to load child applications of a group</remarks>
		private void browseApplicationTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			var groupNode = e.Node as GroupTreeNode;
			if (groupNode == null)
				return;

			groupNode.LoadChildren();

		}

		/// <summary>
		/// Event handler fired when the search button is clicked
		/// </summary>
		private void searchButton_Click(object sender, EventArgs e)
		{
			//Provide an indication that something's happening
			searchButton.Text = "Searching...";
			searchButton.Enabled = false;

			//Empty existing search results
			searchApplicationTree.Nodes.Clear();

			try
			{
				var results = GroupApplicationService.Search(searchTextBox.Text);

				if (results.Count() == 0)
				{
					// If there are no results, clear the image list to ensure
					// the message gets no  default icon
					//searchApplicationTree.ImageList.Images.Clear();
					searchApplicationTree.Nodes.Add("No results");
				}
				else foreach (var app in results)
					{
						var group = app as EvolutionGroup;
						if (group == null)
						{
							var appNode = new ApplicationTreeNode(app);
							searchApplicationTree.Nodes.Add(appNode);
						}
						else
						{
							var groupNode = new GroupTreeNode(group, GroupApplicationService);
							searchApplicationTree.Nodes.Add(groupNode);
							groupNode.LoadAvatar();
						}
					}
			}
			catch
			{
				// If there are no results, clear the image list to ensure
				// the message gets no default icon
				searchApplicationTree.ImageList.Images.Clear();
				searchApplicationTree.Nodes.Add("An error occured whilst searching for applications");
			}
			finally
			{
				// Reset the search button
				searchButton.Text = "Search";
				searchButton.Enabled = true;
			}

		}

		/// <summary>
		/// Event handler fired when a tree node is selected
		/// </summary>
		/// <remarks>Used to set the SelectedApplication property</remarks>
		private void applicationTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			// Escape if the node is not an Application TreeNode
			var appTreeNode = e.Node as ApplicationTreeNode;
			if (appTreeNode == null)
				return;

			// Prepare the EventArgs
			var oldApplication = SelectedApplication;
			var eventArgs = new SelectedApplicationChangedEventArgs(oldApplication, appTreeNode.Application);

			// Persist the new Application
			SelectedApplication = appTreeNode.Application;
		}

		/// <summary>
		/// Resets the application trees by clearing
		/// all children and reseting the ImageList
		/// </summary>
		private void ResetApplicationTrees()
		{
			browseApplicationTree.Nodes.Clear();
			searchApplicationTree.Nodes.Clear();

			var imageList = new ImageList();
			imageList.Images.Add("Group", TreeImages.Group);
			imageList.Images.Add("Blog", TreeImages.Blog);
			imageList.Images.Add("Forum", TreeImages.Forum);
			imageList.Images.Add("Media Gallery", TreeImages.MediaGallery);
			imageList.Images.Add("Wiki", TreeImages.Wiki);

			//Set the trees to use the same image list to avoid multiple
			//requests to get group avatars for search and browse
			browseApplicationTree.ImageList = imageList;
			searchApplicationTree.ImageList = imageList;
		}


		/// <summary>
		/// Reloads the browse application tree
		/// </summary>
		private void ReloadBrowseTree()
		{
			if (Connection != null)
			{
				var group = GroupApplicationService.GetChildGroups(-1).First();
				var node = new GroupTreeNode(group, GroupApplicationService);
				node.Nodes.Add("Dummy");
				browseApplicationTree.Nodes.Add(node);
				node.Expand();

				browseApplicationTree.Refresh();
			}
		}


		/// <summary>
		/// A TreeNode holding an EvolutionApplication
		/// </summary>
		private class ApplicationTreeNode : TreeNode
		{
			/// <summary>
			/// The application this node is representing
			/// </summary>
			public EvolutionApplication Application { get; private set; }

			/// <summary>
			/// Creates a new ApplicationTree Node for the given EvolutionApplication
			/// </summary>
			/// <param name="app">The application</param>
			public ApplicationTreeNode(EvolutionApplication app)
			{

				Application = app;
				Text = app.Name;
				ToolTipText = app.Description;

				// Default the image key to the Application Type
				ImageKey = SelectedImageKey = Application.ApplicationType;
			}
		}

		/// <summary>
		/// A Treenode holding an EvolutionGroup
		/// </summary>
		private class GroupTreeNode : ApplicationTreeNode
		{
			/// <summary>
			/// The GroupApplicationService used to get child applications with
			/// </summary>
			public GroupApplicationService GroupApplicationService { get; private set; }

			/// <summary>
			/// Creates a new GrouopTreeNode for the given EvolutionGroup using the specified ApplicationService
			/// to get child Application Nodes.
			/// </summary>
			/// <param name="group">The Group</param>
			/// <param name="service">The service to use for getting child applications</param>
			public GroupTreeNode(EvolutionGroup group, GroupApplicationService service)
				: base(group)
			{
				GroupApplicationService = service;
			}

			/// <summary>
			/// Loads the Group avatar as the Image Key
			/// </summary>
			/// <remarks>Must be called after the node has been added to a tree</remarks>
			public void LoadAvatar()
			{
				var group = Application as EvolutionGroup;
				if (group.AvatarUri.AbsolutePath.EndsWith("utility/defaulthub.gif"))
					return;

				// Use the avatar url as part of the key - ensures we don't have to
				// request the same image multiple times
				// (e.g. the default group avatar may be very commonly used)
				var avatarKey = "groupavatar-" + group.AvatarUri.ToString();
				if (TreeView.ImageList.Images.ContainsKey(avatarKey))
				{
					// We've already got the image, so use it
					ImageKey = SelectedImageKey = avatarKey;
					return;
				}

				// Try and load the avatar url and if it works replace the default
				// icon with it.
				try
				{
					var imageStream = new WebClient().OpenRead(group.AvatarUri);
					var image = Image.FromStream(imageStream);
					TreeView.ImageList.Images.Add(avatarKey, image);
					ImageKey = SelectedImageKey = avatarKey;
				}
				catch { }
			}

			private bool hasLoadedChildren = false;
			/// <summary>
			/// Loads applications and groups within the current group
			/// as child tree nodes
			/// </summary>
			public void LoadChildren()
			{
				if (hasLoadedChildren)
					return;

				this.Nodes.Clear();
				var children = GroupApplicationService.GetApplicationsInGroup(Application.Id);
				foreach (var child in children)
				{
					var group = child as EvolutionGroup;
					if (group != null)
					{
						var groupNode = new GroupTreeNode(group, GroupApplicationService);
						groupNode.Nodes.Add("Dummy");
						this.Nodes.Add(groupNode);
						groupNode.LoadAvatar();
					}
					else
					{
						var appNode = new ApplicationTreeNode(child);
						appNode.NodeFont = new Font(SystemFonts.DefaultFont, FontStyle.Regular);
						this.Nodes.Add(appNode);
					}
				}

				hasLoadedChildren = true;
			}
		}
	}


	/// <summary>
	/// Provides Data for the SelectedApplicationChanged event
	/// </summary>
	public class SelectedApplicationChangedEventArgs : EventArgs
	{

		/// <summary>
		/// The previously selected Application
		/// </summary>
		public EvolutionApplication OldApplication { get; private set; }

		/// <summary>
		/// The newly selected Application
		/// </summary>
		public EvolutionApplication NewApplication { get; private set; }

		/// <summary>
		/// Creates a new SelectedApplicationChangedEventArgs object
		/// </summary>
		/// <param name="newApp">The newly selected application</param>
		/// <param name="oldApp">The previously selected application</param>
		public SelectedApplicationChangedEventArgs(EvolutionApplication newApp, EvolutionApplication oldApp)
		{
			NewApplication = newApp;
			OldApplication = oldApp;
		}
	}





}
