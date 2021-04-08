using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Infrastructure.InMemory
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly Dictionary<UserId, User> dictionary = new Dictionary<UserId, User>();

        public User Find(UserId id)
        {
            if (dictionary.TryGetValue(id, out User user))
            {
                return user;
            }

            throw new System.Exception();
        }
    }
}
