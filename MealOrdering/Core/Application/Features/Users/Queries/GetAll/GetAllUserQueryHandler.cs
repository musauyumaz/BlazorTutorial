﻿using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Users.DTOs;
using Application.Features.Users.Rules;
using Domain.Entities.Identity;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetAll;

public record GetAllUserQueryRequest : IRequest<IDataResult<List<UserDTO>>>;
public class GetAllUserQueryHandler(IBaseRepository<User> _userRepository) : IRequestHandler<GetAllUserQueryRequest, IDataResult<List<UserDTO>>>
{
    public async ValueTask<IDataResult<List<UserDTO>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        List<UserDTO>? users = await _userRepository.GetAllAsync().Result.Where(u => u.IsActive).ProjectToType<UserDTO>().ToListAsync();
        return new DataResult<List<UserDTO>>(true, users);
    }
}



