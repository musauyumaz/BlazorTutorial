using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities.Identity;
using Mapster;
using Mediator;

namespace Application.Features.Users.Commands.Update;

public record UpdateUserCommandRequest(string Id, string Firstname, string Lastname, string EmailAddress, bool IsActive) : IRequest<IDataResult<UserDTO>>;
public class UpdateUserCommandHandler() : IRequestHandler<UpdateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        //await _userBusinessRules.UserNotFoundAsync(request.Id);

        return new DataResult<UserDTO>(true, new("asdsa", "adsad", "asdasd", "asdsad", true, DateTime.Now, "asdsad"));
    }
}



