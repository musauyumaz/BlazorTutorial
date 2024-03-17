using Application.Commons.Abstractions.ExtarnalServices.Tokens;
using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Auths.DTOs;
using Application.Features.Auths.Rules;
using Domain.Entities.Identity;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Commands;

public record LoginUserCommandRequest(string EmailOrUsername, string password) : IRequest<IDataResult<TokenDTO>>;
public class LoginUserCommandHandler(IUserRepository _userRepository, ITokenHandler _tokenHandler, AuthBusinessRules _authBusinessRules) : IRequestHandler<LoginUserCommandRequest, IDataResult<TokenDTO>>
{
    public async ValueTask<IDataResult<TokenDTO>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserNotFoundAsync(request.EmailOrUsername);

        User? user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == request.EmailOrUsername);
        TokenDTO token = _tokenHandler.CreateAccessToken(user);
        return new DataResult<TokenDTO>(true, token);
    }
}



