using Application.Commons.Abstractions.Repositories;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    //public class UserRepository(MealOrderingDbContext _context) : IUserRepository
    //{
    //    public DbSet<AppUser> Table => _context.Users;

    //    public async Task<AppUser> AddAsync(AppUser entity)
    //        => (await Table.AddAsync(entity)).Entity;

    //    public async Task<AppUser> DeleteAsync(Guid id)
    //    {
    //        AppUser? deletedEntity = await GetAsync(id);
    //        deletedEntity.IsActive = false;
    //        return await UpdateAsync(deletedEntity);
    //    }

    //    public async Task<IQueryable<AppUser>> GetAllAsync()
    //        => Table.AsQueryable();

    //    public async Task<AppUser> GetAsync(Guid id)
    //        => await Table.FindAsync(id);

    //    public async Task<int> SaveAsync()
    //        => await _context.SaveChangesAsync();

    //    public async Task<AppUser> UpdateAsync(AppUser entity)
    //        => Table.Update(entity).Entity;
    //}
}



