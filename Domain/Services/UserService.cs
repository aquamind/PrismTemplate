using Domain.Repositories;

namespace Domain.Services
{
    public sealed class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
