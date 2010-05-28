using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace PermissionViewer.Services
{
	//TODO: Support Impersonation

	/// <summary>
	/// Helper class for using the Telligent Evolution Platform REST API
	/// </summary>
	/// <remarks>Used the Cretae method to create a new EvolutionService object</remarks>
	public class EvolutionConnection
	{
		/// <summary>
		/// The name of the Telligent Evolution platform product being used by the community
		/// </summary>
		public string Product { get; private set; }
		/// <summary>
		/// The version number of the Telligent Evolution Platform
		/// </summary>
		public Version PlatformVersion { get; private set; }
		/// <summary>
		/// The version number of the Telligent Evolution Platform REST API.
		/// </summary>
		/// <remarks>Should never be older than the PlatformVersion</remarks>
		public Version WebservicesVersion { get; private set; }

		/// <summary>
		/// The Url of the Telligent Evolution Platform community
		/// </summary>
		public string Url { get; private set; }
		/// <summary>
		/// The Username being used to connect to the Telligent Evolution REST API
		/// </summary>
		public string Username { get; private set; }

		private WebClient client = new WebClient();

		private void AddRestUserToken(string username, string apiKey)
		{
			var adminKey = String.Format("{0}:{1}", apiKey, username);
			var restUserToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));
			client.Headers.Add("Rest-User-Token", restUserToken);
		}

		/// <summary>
		/// Creates a new EvolutionConnection for the given community url
		/// </summary>
		/// <param name="url">The url to the root of the Telligent Evolution platform community</param>
		public EvolutionConnection(string url)
		{
			TryConnect(url);
		}

		/// <summary>
		/// Creates a new EvolutionConnection for the given community url
		/// using the given username and api key
		/// </summary>
		/// <param name="url">The url to the root of the Telligent Evolution platform community</param>
		/// <param name="username">The user to connect as</param>
		/// <param name="apiKey">The API Key to use for authentication</param>
		public EvolutionConnection(string url, string username, string apiKey)
		{
			if (String.IsNullOrEmpty(username))
				throw new InvalidOperationException("Username must not be null or empty");

			if (String.IsNullOrEmpty(apiKey))
				throw new InvalidOperationException("API Key must not be null or empty");
			AddRestUserToken(username, apiKey);

			TryConnect(url);
		}

		/// <summary>
		/// Creates a new EvolutionConnection for the given community url using the given credentials
		/// </summary>
		/// <param name="url">The url to the root of the Telligent Evolution platform community</param>
		/// <param name="credentials">The Credentials to connect with</param>
		/// <param name="apiKey">The API Key to connect with</param>
		public EvolutionConnection(string url, NetworkCredential credentials, string apiKey)
		{
			if (credentials == null)
				throw new InvalidOperationException("Credentials must not be null");

			if (String.IsNullOrEmpty(apiKey))
				throw new InvalidOperationException("API Key must not be null or empty");

			AddRestUserToken(credentials.UserName, apiKey);
			client.Credentials = credentials;

			TryConnect(url);
		}

		/// <summary>
		/// Helper method to try and make a connection
		/// </summary>
		/// <param name="url">The url to the root of the Telligent Evolution platform community to connect to</param>
		private void TryConnect(string url)
		{
			if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
				throw new InvalidOperationException("Url is not in a valid format");

			Url = url;

			try
			{
				LoadVersionInfo();
			}
			catch (WebException ex)
			{
				var response = ex.Response as HttpWebResponse;
				//If we got a 401 response, try reconnecting with default credentials
				if (response == null || response.StatusCode != HttpStatusCode.Unauthorized)
					throw;

				//Try and connect using default windows credentials
				client.UseDefaultCredentials = true;
				try
				{
					LoadVersionInfo();
				}
				catch
				{
					//Throw the original exception
					throw ex;
				}
			}

		}

		/// <summary>
		/// Loads version information using the Site Information endpoint
		/// </summary>
		private void LoadVersionInfo()
		{
			var response = GetResponse("/api.ashx/v2/info.xml");

			//Populate product and version information
			Product = response.Descendants(XName.Get("Product")).First().Value;
			PlatformVersion = new Version(response.Descendants(XName.Get("Platform")).First().Value);
			WebservicesVersion = new Version(response.Descendants(XName.Get("Webservice")).First().Value);
		}

		/// <summary>
		/// Creates a new EvolutionService object, validating that the credentials
		/// are valid
		/// </summary>
		/// <param name="url">The url of the Telligent Evolution platform community</param>
		/// <param name="username">The username to connect as</param>
		/// <param name="apiKey">The API Key to connect with</param>
		/// <returns>An EvolutionService holding the credentials if valid, otherwise throws an exception.</returns>
		public static EvolutionConnection Create(string url, string username, string apiKey)
		{
			return new EvolutionConnection(url, username, apiKey);
		}

		/// <summary>
		/// Converts a relative endpoint url to an absolute url
		/// </summary>
		/// <param name="endpoint">An endpoint with a relative url</param>
		/// <returns>The absolute path for the endpoint</returns>
		public string GetFullEndpointUrl(string endpoint)
		{
			if (!endpoint.StartsWith("/"))
				endpoint = "/" + endpoint;

			return Url + endpoint;
		}

		/// <summary>
		/// Gets the Response from the given endpoint
		/// </summary>
		/// <param name="endpoint">The relative url for the endpoint to hit</param>
		/// <returns>An XDocument containing the response from the endpoint</returns>
		public XDocument GetResponse(string endpoint)
		{
			var requestUrl = GetFullEndpointUrl(endpoint);

			using (var response = client.OpenRead(requestUrl))
			{
				using (var reader = new StreamReader(response))
				{
					return XDocument.Load(reader);
				}
			}
		}



	}
}
