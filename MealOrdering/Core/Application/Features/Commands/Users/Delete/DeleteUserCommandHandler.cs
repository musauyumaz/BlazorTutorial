using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Users.Delete;

public record DeleteUserCommandRequest(string Id) : IRequest<IDataResult<UserDTO>>;
public class DeleteUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<DeleteUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        User? deletedUser = await _userRepository.DeleteAsync(Guid.Parse(request.Id));
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true,deletedUser.Adapt<UserDTO>());
    }
}



