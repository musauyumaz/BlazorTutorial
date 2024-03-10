namespace Application.Commons.Results
{
    public class Result : IResult
    {
        public Result(string message, bool isSucceed) : this(isSucceed) => Message = message;
        public Result(bool isSucceed) => IsSucceeded = isSucceed;

        public string Message { get; }

        public bool IsSucceeded { get; }
    }
}



