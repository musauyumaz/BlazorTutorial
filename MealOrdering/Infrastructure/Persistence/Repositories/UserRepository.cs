using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository(MealOrderingDbContext _context) : IUserRepository
    {
        public DbSet<User> Table => _context.Users;

        public async Task<User> AddAsync(User entity)
            => (await Table.AddAsync(entity)).Entity;

        public async Task<User> DeleteAsync(Guid id)
        {
            User? deletedEntity = await GetAsync(id);
            deletedEntity.IsActive = false;
            return await UpdateAsync(deletedEntity);
        }

        public async Task<IQueryable<User>> GetAllAsync()
            => Table.AsQueryable();

        public async Task<User> GetAsync(Guid id)
            => await Table.FindAsync(id);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<User> UpdateAsync(User entity)
            => Table.Update(entity).Entity;
    }
}



