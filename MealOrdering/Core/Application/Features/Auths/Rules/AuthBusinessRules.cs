using Application.Commons.Abstractions.Repositories;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules(IUserRepository _userRepository)
    {
        public async Task UserNotFoundAsync(string emailAddress)
        {
            User? user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
            if (user == null) throw new Exception("User Not Found");
        }

        public async Task UserIsPassive(User user)
        {
            if (!user.IsActive) throw new Exception("User is Passive");
        }
    }
}



