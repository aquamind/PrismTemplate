using Infrastructure.Sql;
using System.Data.Common;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    internal class ConnectionFactory : IConnectionFactory
    {
        private static readonly string connectionString;

        static ConnectionFactory()
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

        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public DbParameter GetParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
