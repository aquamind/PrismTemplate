using System;

namespace Domain.ValueObjects
{
    public sealed class UserName : ValueObject<UserName>
    {
        private readonly string value;

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException();

            this.value = value;
        }

        protected override bool EqualsCore(UserName obj)
        {
            return value.Equals(obj.value);
        }

        public override string ToString()
        {
            return value;
        }
    }
}
