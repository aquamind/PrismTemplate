using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    internal sealed class Query
    {
        private string sql = string.Empty;

        private readonly List<SqlParameter> parameters = new List<SqlParameter>();

        public void  SetSql(string sql)
        {
            this.sql = sql;
        }

        public void SetParameter(string name, object value)
        {
            parameters.Add(new SqlParameter(name, value));
        }

        internal void GetDataReader(Action<SqlDataReader> action)
        {
            using (var connection = SqlConnectionFactory.GetSqlConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddRange(parameters.ToArray());
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        action(reader);
                    }
                }
            }
        }
    }
}
