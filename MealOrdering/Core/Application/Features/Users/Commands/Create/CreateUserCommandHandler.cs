using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Auths.Utilities;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using Mediator;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommandRequest(string FirstName, string LastName, string EmailAddress, string Password) : IRequest<IDataResult<UserDTO>>;
public class CreateUserCommandHandler(IBaseRepository<User> _userRepository, UserBusinessRules _userBusinessRules) : IRequestHandler<CreateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.EmailExists(request.EmailAddress);
        User? user = await _userRepository.AddAsync(request.Adapt<User>());
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, user.Adapt<UserDTO>());
    }
}



