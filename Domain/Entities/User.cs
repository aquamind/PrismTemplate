using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class User
    {
        private readonly UserId id;
        private readonly UserName name;

        public User(UserId id, UserName name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
