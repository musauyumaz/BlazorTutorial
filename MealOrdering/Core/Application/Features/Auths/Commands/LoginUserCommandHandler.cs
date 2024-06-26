﻿using Application.Commons.Abstractions.ExtarnalServices.Tokens;
using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Auths.DTOs;
using Application.Features.Auths.Rules;
using Application.Features.Auths.Utilities;
using Application.Features.Users.DTOs;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Commands;

public record LoginUserCommandRequest(string EmailOrUsername, string Password) : IRequest<IDataResult<LoginUserCommandResponse>>;
public record LoginUserCommandResponse(TokenDTO Token, UserDTO User);
public class LoginUserCommandHandler(IBaseRepository<User> _userRepository, ITokenHandler _tokenHandler, AuthBusinessRules _authBusinessRules) : IRequestHandler<LoginUserCommandRequest, IDataResult<LoginUserCommandResponse>>
{
    public async ValueTask<IDataResult<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        string? encryptedPassword = PasswordEncrypter.Encrypt(request.Password);
        await _authBusinessRules.UserPasswordEmailAddressNotFound(request.EmailOrUsername, encryptedPassword);
        User? user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == request.EmailOrUsername && u.Password == encryptedPassword);
        await _authBusinessRules.UserIsPassive(user!);
        TokenDTO token = _tokenHandler.CreateAccessToken(user!);
        return new DataResult<LoginUserCommandResponse>(true, new(token, user.Adapt<UserDTO>()));
    }
}



