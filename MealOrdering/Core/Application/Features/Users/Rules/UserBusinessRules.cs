using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules(IUserRepository _userRepository)
    {
        public async Task UserNotFoundAsync(string id)
        {
            User? user = await _userRepository.GetAsync(Guid.Parse(id));
            _ = user ?? throw new Exception("User Not Found");
        }

        public async Task UserExists(string email)
        {
            User? user = await _userRepository.Table.FirstOrDefaultAsync(u => u.EmailAddress == email);
            if (user != null) throw new Exception("User Exists");
        }
    }
}



