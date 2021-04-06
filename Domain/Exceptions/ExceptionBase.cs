using System;

namespace Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract ExceptionType Type { get; }

        public enum ExceptionType
        {
            Error,
            Warning,
            Information,
        }
    }
}
