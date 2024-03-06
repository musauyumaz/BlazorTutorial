namespace Application.Features.Results
{
    public interface IResult
    {
        string Message { get; }
        bool IsSucceeded { get; }
    }
}


