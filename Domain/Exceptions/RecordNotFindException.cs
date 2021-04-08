namespace Domain.Exceptions
{
    public class RecordNotFindException : ExceptionBase
    {
        public override ExceptionType Type => ExceptionType.Information;

        public RecordNotFindException() : base("データが存在しません。") { }
    }
}
