using System.Data.Common;

namespace Infrastructure.Sql
{
    public interface IConnectionFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand(string sql);
        DbParameter GetParameter(string name, object value);
    }
}