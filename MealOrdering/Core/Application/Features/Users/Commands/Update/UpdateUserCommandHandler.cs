﻿using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities.Identity;
using Mapster;
using Mediator;

namespace Application.Features.Users.Commands.Update;

public record UpdateUserCommandRequest(string Id, string FirstName, string LastName, string EmailAddress, bool IsActive) : IRequest<IDataResult<UserDTO>>;
public class UpdateUserCommandHandler(IBaseRepository<User> _userRepository, UserBusinessRules _userBusinessRules) : IRequestHandler<UpdateUserCommandRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserNotFoundAsync(request.Id);

        User? updatedUser = await _userRepository.UpdateAsync(request.Adapt<User>());
        await _userRepository.SaveAsync();
        return new DataResult<UserDTO>(true, updatedUser.Adapt<UserDTO>());
    }
}



