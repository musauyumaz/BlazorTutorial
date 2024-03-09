using Application.Commons.Abstractions.Repositories;
using Application.Features.Commands.Users;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Queries.Users.GetById;

public record GetByIdUserQueryRequest(string Id) : IRequest<IDataResult<UserDTO>>;
public class GetByIdUserQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetByIdUserQueryRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<UserDTO>(true,user.Adapt<UserDTO>());
    }
}



