using Domain.Entities.Commons;

namespace Application.Commons.Results
{
    public interface IDataResult<T> : IResult where T : class
    {
        T Data { get; }
    }
}


