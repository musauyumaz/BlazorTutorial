using Application.Commons.Abstractions.Repositories;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

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

        public async Task UserPasswordOrEmailAddressNotFound(string email, string password)
        {
            User? user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == email && u.Password == password);
            if (user == null) throw new Exception("User Password Or Email Not Found");
        }
    }
}



