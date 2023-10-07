using System;

namespace MMRR_Tracker
{
	public class Connection
	{
		private static string encryptedDirJson = System.IO.Path.GetDirectoryName(
			System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Encrypted Connection String Json\appsettings.encrypted.json";

		private static byte[] encryptionKey = Convert.FromBase64String("8tamjC6ImOYawOccJIVBkZynlmMA7p/ce0nZa9zepUc=");

		// Initialize ConnectionString property during construction
		public static string ConnectionString { get; }

		static Connection()
		{
			// Decrypt the JSON file and set ConnectionString
			ConnectionString = GetConnectionStringFromJson(Program_decryptor.DecryptJsonFile(encryptedDirJson, encryptionKey), "MyConnection");
		}

		private static string GetConnectionStringFromJson(string json, string connectionStringName)
		{
			try
			{
				// Implement your JSON parsing logic here
				// You can use the JSON parsing code provided in earlier responses
				// For example:
				using (System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(json))
				{
					var root = doc.RootElement;

					if (root.TryGetProperty("ConnectionStrings", out var connectionStringsNode))
					{
						var connectionStrings = connectionStringsNode.EnumerateObject();

						foreach (var connStr in connectionStrings)
						{
							if (connStr.Name == connectionStringName)
							{
								return connStr.Value.GetString();
							}
						}
					}
				}

				return "Connection string not found.";
			}
			catch (Exception ex)
			{
				return "Error parsing JSON: " + ex.Message;
			}
		}
	}
}
