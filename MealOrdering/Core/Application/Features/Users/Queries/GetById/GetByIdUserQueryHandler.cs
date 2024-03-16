﻿using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities.Identity;
using Mapster;
using Mediator;

namespace Application.Features.Users.Queries.GetById;

public record GetByIdUserQueryRequest(string Id) : IRequest<IDataResult<UserDTO>>;
public class GetByIdUserQueryHandler() : IRequestHandler<GetByIdUserQueryRequest, IDataResult<UserDTO>>
{
    public async ValueTask<IDataResult<UserDTO>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        //await _userBusinessRules.UserNotFoundAsync(request.Id);

        //AppUser? user = await _userRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<UserDTO>(true, new("asdsa", "adsad", "asdasd", "asdsad", true, DateTime.Now, "asdsad"));
    }
}



