using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities.Identity;
using Mapster;
using Mediator;

namespace Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(string Id) : IRequest<IDataResult<UserDTO>>;
public class DeleteUserCommandHandler() : IRequestHandler<DeleteUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        //await _userBusinessRules.UserNotFoundAsync(request.Id);

        //AppUser? deletedUser = await _userRepository.DeleteAsync(Guid.Parse(request.Id));
        //await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, new("asdsa", "adsad", "asdasd", "asdsad", true, DateTime.Now, "asdsad"));
    }
}



