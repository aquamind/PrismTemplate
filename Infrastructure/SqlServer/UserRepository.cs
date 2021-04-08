using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.SqlServer
{
    public sealed class UserRepository : IUserRepository
    {
        public User Find(UserId id)
        {
            var query = new Query();
            query.SetSql(@"select name from users where name = @id;");
            query.SetParameter("id", id.ToString());

            var list = new List<User>();
            query.GetDataReader(reader =>
                {
                    list.Add(new User(id, new UserName(reader["name"].ToString())));
                }
            );
            if (list.Count == 0)
            {
                throw new RecordNotFindException();
            }

            return list.First();
        }
    }
}
