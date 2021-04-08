using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    internal static class SqlConnectionFactory
    {
        private static readonly string connectionString;

        static SqlConnectionFactory()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                InitialCatalog = "",
                IntegratedSecurity = true,
                Password = "",
                UserID = "",
            };
            connectionString = builder.ToString();
        }

        internal static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
