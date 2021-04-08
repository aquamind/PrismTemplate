using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        User Find(UserId id);
    }
}
