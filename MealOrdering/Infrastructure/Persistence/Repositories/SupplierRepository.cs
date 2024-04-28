using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SupplierRepository(MealOrderingDbContext _context) : IBaseRepository<Supplier>
    {
        public DbSet<Supplier> Table => _context.Suppliers;

        public async Task<Supplier> AddAsync(Supplier entity)
            => (await Table.AddAsync(entity)).Entity;

        public async Task<Supplier> DeleteAsync(Guid id)
        {
            Supplier? deletedEntity = await GetAsync(id);
            deletedEntity.IsActive = false;
            return await UpdateAsync(deletedEntity);
        }

        public async Task<IQueryable<Supplier>> GetAllAsync()
            => Table.AsQueryable();

        public async Task<Supplier> GetAsync(Guid id)
            => await Table.FindAsync(id);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<Supplier> UpdateAsync(Supplier entity)
            => Table.Update(entity).Entity;
    }
}



