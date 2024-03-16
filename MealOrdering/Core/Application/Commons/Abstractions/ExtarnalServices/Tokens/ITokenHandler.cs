using Application.Features.Auths.DTOs;
using Domain.Entities.Identity;

namespace Application.Commons.Abstractions.ExtarnalServices.Tokens
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second, AppUser user);
    }
}



