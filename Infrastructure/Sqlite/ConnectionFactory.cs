using Infrastructure.Sql;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Infrastructure.Sqlite
{
    internal sealed class ConnectionFactory : IConnectionFactory
    {
        private const string DATABASE_FILE_NAME = "sqlite.db";

        private static void CreateDatabaseFile()
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            using (var command = new SQLiteCommand(GetDdl(), connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private static string GetDdl()
        {
            var sql = new StringBuilder();
            sql.AppendLine(@"CREATE TABLE IF NOT EXISTS users (");
            sql.AppendLine(@"  id STRING NOT NULL PRIMARY KEY");
            sql.AppendLine(@"  , name STRING NOT NULL");
            sql.AppendLine(@");");
            return sql.ToString();
        }
        private static string GetConnectionString()
        {
            return new SQLiteConnectionStringBuilder() { DataSource = DATABASE_FILE_NAME }.ToString();
        }

        public DbConnection GetConnection()
        {
            if (!File.Exists(DATABASE_FILE_NAME))
            {
                CreateDatabaseFile();
            }
            return new SQLiteConnection(GetConnectionString()); ;
        }

        public DbCommand GetCommand(string sql)
        {
            return new SQLiteCommand(sql) ;
        }

        public DbParameter GetParameter(string name, object value)
        {
            return new SQLiteParameter(name, value);
        }
    }
}
