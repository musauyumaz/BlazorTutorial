using Domain.Entities.Commons;

namespace Application.Features.Results
{
    public interface IDataResult<T> : IResult where T : class, new()
    {
        T Data { get; }
    }
}


