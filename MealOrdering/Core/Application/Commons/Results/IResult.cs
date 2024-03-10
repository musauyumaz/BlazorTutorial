namespace Application.Commons.Results
{
    public interface IResult
    {
        string Message { get; }
        bool IsSucceeded { get; }
    }
}


