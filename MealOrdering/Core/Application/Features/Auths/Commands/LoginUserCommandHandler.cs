using Application.Commons.Results;
using Application.Features.Auths.DTOs;
using Mediator;

namespace Application.Features.Auths.Commands;

public record LoginUserCommandRequest(string EmailOrUsername, string password);
//public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, IDataResult<>>
//{
//}



