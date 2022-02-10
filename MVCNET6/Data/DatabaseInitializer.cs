using System.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace MVCNET6.Data
{
    public class DatabaseInitializer
    {
        public static void Create(string connectionString, string contentRootPath)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "master";
            var masterConnection = sqlConnectionStringBuilder.ToString();
            using (SqlConnection connection = new SqlConnection(masterConnection))
            {
                var dbExistsCommand = new SqlCommand("SELECT name FROM master.sys.databases WHERE name = @dbname", connection);
                dbExistsCommand.Parameters.AddWithValue("@dbname", databaseName);
                connection.Open();
                var existingDatabase = dbExistsCommand.ExecuteScalar();

                if (existingDatabase == null)
                {
                    Server server = new Server(new ServerConnection(connection));
                    try
                    {
                        var schemaScript = File.ReadAllText($"{contentRootPath}\\SqlScripts\\Schema.sql");

                        server.ConnectionContext.ExecuteNonQuery(schemaScript);
                        var dataScript = File.ReadAllText($"{contentRootPath}\\SqlScripts\\SeedData.sql");
                        server.ConnectionContext.ExecuteNonQuery(dataScript);
                    }
                    finally
                    {
                        server.ConnectionContext.Disconnect();
                    }
                }
            }
        }
    }
}
