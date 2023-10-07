using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

public class SqlToCsvExtractor
{
	private string connectionString; // Connection string for your SQL Server
	private string outputFilePath; // Path where the CSV file will be saved

	public SqlToCsvExtractor(string connectionString, string outputFilePath)
	{
		this.connectionString = connectionString;
		this.outputFilePath = outputFilePath;
	}

	public async Task ExtractToCsvAsync(string sqlQuery)
	{
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			await connection.OpenAsync();

			using (SqlCommand command = new SqlCommand(sqlQuery, connection))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					using (StreamWriter writer = new StreamWriter(outputFilePath))
					{
						// Write the column headers to the CSV file
						for (int i = 0; i < reader.FieldCount; i++)
						{
							if (i > 0)
							{
								writer.Write(",");
							}
							writer.Write(reader.GetName(i));
						}
						writer.WriteLine();

						// Write the data rows to the CSV file
						while (await reader.ReadAsync())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{
								if (i > 0)
								{
									writer.Write(",");
								}
								writer.Write(reader[i]);
							}
							writer.WriteLine();
						}
					}
				}
			}
		}
	}
}