using System;

namespace Domain.ValueObjects
{
    public sealed class UserId : ValueObject<UserId>
    {
        private readonly string value;

        public UserId(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException();

            this.value = value;
        }

        protected override bool EqualsCore(UserId obj)
        {
            return value.Equals(obj.value);
        }

        public override string ToString()
        {
            return value;
        }
    }
}
