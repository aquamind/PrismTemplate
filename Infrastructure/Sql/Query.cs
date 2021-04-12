using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Infrastructure.Sql
{
    internal sealed class Query
    {
        private readonly IConnectionFactory connectionFactory;

        public Query(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        private string sql = string.Empty;

        private readonly List<DbParameter> parameters = new List<DbParameter>();

        public void SetSql(string sql)
        {
            this.sql = sql;
        }

        public void SetParameter(string name, object value)
        {
            parameters.Add(connectionFactory.GetParameter(name, value));
        }

        internal void GetDataReader(Action<DbDataReader> action)
        {
            using (var connection = connectionFactory.GetConnection())
            using (var command = connectionFactory.GetCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
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
