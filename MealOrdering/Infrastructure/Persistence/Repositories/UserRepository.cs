using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository(MealOrderingDbContext _context) : IUserRepository
    {
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}



