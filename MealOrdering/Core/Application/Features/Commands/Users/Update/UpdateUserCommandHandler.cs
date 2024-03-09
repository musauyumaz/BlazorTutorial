using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Users.Update;

public record UpdateUserCommandRequest(string Id,string Firstname, string Lastname, string EmailAddress, bool IsActive) : IRequest<IDataResult<UserDTO>>;
public class UpdateUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<UpdateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        User? updatedUser = await _userRepository.UpdateAsync(request.Adapt<User>());
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, updatedUser.Adapt<UserDTO>());
    }
}



