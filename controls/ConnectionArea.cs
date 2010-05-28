using System;
using System.Windows.Forms;
using PermissionViewer.Services;
using System.Net;

namespace PermissionViewer.Controls
{
	/// <summary>
	/// User Control for obtaining REST API connection information for
	/// a user to connect to a Telligent Evolution platform community 
	/// </summary>
	public partial class ConnectionArea : UserControl
	{
		/// <summary>
		/// Event fired whenever the connection obtained by the control changes
		/// </summary>
		public event EventHandler<ConnectionChangedEventArgs> ConnectionChanged;

		private EvolutionConnection _connection;
		/// <summary>
		/// The EvolutionConnection being used to connect to the a Telligent Evolution
		/// platform community's REST API
		/// </summary>
		public EvolutionConnection Connection
		{
			get { return _connection; }
			private set
			{
				var eventArgs = new ConnectionChangedEventArgs(value, Connection);

				_connection = value;

				if (ConnectionChanged != null)
					ConnectionChanged.Invoke(this, eventArgs);
			}
		}

		/// <summary>
		/// Creates a new ConnectionArea control
		/// </summary>
		public ConnectionArea()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event handler handling the Click event of the connect button
		/// </summary>
		private void connectButton_Click(object sender, EventArgs e)
		{
			if (!Uri.IsWellFormedUriString(urlTextBox.Text, UriKind.Absolute))
			{
				MessageBox.Show("Url is not valid");
				return;
			}

			connectButton.Text = "Connecting...";
			connectButton.Enabled = false;
			urlTextBox.Enabled = false;
			try
			{
				Connection = new EvolutionConnection(urlTextBox.Text);
				ShowDisconnectButton();
			}
			catch (WebException ex)
			{
				var response = ex.Response as HttpWebResponse;
				if (response == null)
					throw ex;

				// 401 status suggests that username/password authentication may be required
				if (response.StatusCode == HttpStatusCode.Unauthorized)
					passwordPanel.Visible = true;
				else if (response.StatusCode == HttpStatusCode.NotFound)
				{
					MessageBox.Show("The requested url could not be found");
					return;
				}
				else if (response.StatusCode != HttpStatusCode.Forbidden)
				{
					ResetConnectionArea();
					throw ex;
				}

				ResetCredentialsArea();
			}
		}

		/// <summary>
		/// Event handler for the Click event of the login button
		/// </summary>
		private void loginButton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(userNameTextBox.Text))
			{
				MessageBox.Show("Username must not be blank");
				return;
			}
			if (String.IsNullOrEmpty(apiKeyTextBox.Text))
			{
				MessageBox.Show("API Key must not be blank");
				return;
			}
			if (passwordPanel.Visible && String.IsNullOrEmpty(passwordTextBox.Text))
			{
				MessageBox.Show("Password must not be blank");
				return;
			}

			loginButton.Text = "Logging in";
			loginButton.Enabled = false;
			try
			{
				//If password panel is visible, use network credentials with the request
				if (passwordPanel.Visible)
				{
					var credentials = new NetworkCredential(userNameTextBox.Text, passwordTextBox.Text);
					Connection = new EvolutionConnection(urlTextBox.Text, credentials, apiKeyTextBox.Text);
				}
				else
					Connection = new EvolutionConnection(urlTextBox.Text, userNameTextBox.Text, apiKeyTextBox.Text);

				userNameTextBox.Enabled = false;
				apiKeyTextBox.Enabled = false;
				passwordTextBox.Enabled = false;

				loginButton.Visible = false;
			}
			catch (WebException ex)
			{
				ResetLoginButton();

				var response = ex.Response as HttpWebResponse;
				if (response == null)
					throw ex;

				// 401 status suggests that username/password authentication may be required
				if (response.StatusCode == HttpStatusCode.Unauthorized )
					MessageBox.Show("The Username and Password provided were not correct", "Unable to connect");
				// 403 status suggests that API Key authentication may be required
				else if (response.StatusCode == HttpStatusCode.Forbidden)
					MessageBox.Show(@"Unable to connect to the Telligent Evolution platform API
this may occur because:
* The REST API is not enabled
* The Username you supplied does not have permisison to use the REST API
* The API Key you entered was invalid
", "Unable to connect");

			}
		}

		/// <summary>
		/// Event handler for the Click event of the Disconnect button
		/// </summary>
		private void disconnectButton_Click(object sender, EventArgs e)
		{
			ResetConnectionArea();
			ResetConnectionArea();
		}

		/// <summary>
		/// Resets the Connection Area to it's default state
		/// </summary>
		private void ResetConnectionArea()
		{
			connectButton.Text = "Connect";
			connectButton.Enabled = true;
			connectButton.Visible = true;

			disconnectButton.Enabled = true;
			disconnectButton.Visible = false;

			urlTextBox.Enabled = true;

			credentialsFlowLayoutPanel.Visible = false;
			passwordPanel.Visible = false;

			urlTextBox.Clear();

			Connection = null;
		}

		/// <summary>
		/// Shows the disconnect button
		/// </summary>
		private void ShowDisconnectButton()
		{
			connectButton.Visible = false;
			disconnectButton.Visible = true;
		}

		/// <summary>
		/// Resets the Credentials Area to it's default state
		/// </summary>
		private void ResetCredentialsArea()
		{
			credentialsFlowLayoutPanel.Visible = true;

			ShowDisconnectButton();

			//Clear current credentials and enable the text boxes
			userNameTextBox.Clear();
			userNameTextBox.Enabled = true;
			apiKeyTextBox.Clear();
			apiKeyTextBox.Enabled = true;
			passwordTextBox.Clear();
			passwordTextBox.Enabled = true;

			ResetLoginButton();

			Connection = null;
		}

		/// <summary>
		/// Resets the login button to it's default state
		/// </summary>
		private void ResetLoginButton()
		{
			loginButton.Text = "Login";
			loginButton.Enabled = true;
			loginButton.Visible = true;
		}

	}

	/// <summary>
	/// Event Arguments for the ConnectionChanged event
	/// </summary>
	public class ConnectionChangedEventArgs : EventArgs
	{
		/// <summary>
		/// The Old Connection used to access the REST API
		/// </summary>
		/// <remarks>May be null</remarks>
		public EvolutionConnection NewConnection { get; set; }
		/// <summary>
		/// The Old Connection used to access the REST API
		/// </summary>
		/// <remarks>May be null</remarks>
		public EvolutionConnection OldConnection { get; set; }

		/// <summary>
		/// Creates a new ConnectionChangedEventArgs object
		/// </summary>
		/// <param name="newConnection">The new connection </param>
		/// <param name="oldConnection">The previous connection</param>
		public ConnectionChangedEventArgs(EvolutionConnection newConnection, EvolutionConnection oldConnection)
		{
			NewConnection = newConnection;
			OldConnection = oldConnection;
		}

	}

}
