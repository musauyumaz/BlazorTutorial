using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommandRequest(string Firstname, string Lastname, string EmailAddress) : IRequest<IDataResult<UserDTO>>;
public class CreateUserCommandHandler(IUserRepository _userRepository, UserBusinessRules _userBusinessRules) : IRequestHandler<CreateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserExists(request.EmailAddress);

        User? user = await _userRepository.AddAsync(request.Adapt<User>());
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, user.Adapt<UserDTO>());
    }
}



