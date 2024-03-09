using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Users.Create;

public record CreateUserCommandRequest(string Firstname, string Lastname, string EmailAddress) : IRequest<IDataResult<UserDTO>>;
public class CreateUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<CreateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.AddAsync(request.Adapt<User>());
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true,user.Adapt<UserDTO>());
    }
}



