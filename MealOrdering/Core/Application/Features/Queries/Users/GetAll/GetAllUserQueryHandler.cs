using Application.Commons.Abstractions.Repositories;
using Application.Features.Commands.Users;
using Application.Features.Results;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Users.GetAll;

public record GetAllUserQueryRequest : IRequest<IDataResult<List<UserDTO>>>;
public class GetAllUserQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetAllUserQueryRequest, IDataResult<List<UserDTO>>>
{
    public async ValueTask<IDataResult<List<UserDTO>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        List<UserDTO>? users = await _userRepository.GetAllAsync().Result.ProjectToType<UserDTO>().ToListAsync();
        return new DataResult<List<UserDTO>>(true, users);
    }
}



