using System.Data.Common;

namespace Infrastructure.Sql
{
    public interface IConnectionFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbParameter GetParameter(string name, object value);
    }
}