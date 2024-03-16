using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Mediator;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommandRequest(string Firstname, string Lastname, string EmailAddress) : IRequest<IDataResult<UserDTO>>;
public class CreateUserCommandHandler() : IRequestHandler<CreateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        //await _userBusinessRules.EmailExists(request.EmailAddress);

        //AppUser? user = await _userRepository.AddAsync(request.Adapt<AppUser>());
        //await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, new("asdsa","adsad","asdasd","asdsad",true,DateTime.Now,"asdsad"));
    }
}



