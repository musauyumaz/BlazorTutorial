using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderRepository(MealOrderingDbContext _context) : IOrderRepository
    {
        public DbSet<Order> Table => _context.Set<Order>();

        public async Task<Order> AddAsync(Order entity)
            => (await Table.AddAsync(entity)).Entity;

        public async Task<Order> DeleteAsync(Guid id)
        {
            Order? deletedEntity = await GetAsync(id);
            deletedEntity.IsActive = false;
            return deletedEntity;
        }

        public async Task<IQueryable<Order>> GetAllAsync()
            => Table.AsQueryable();

        public async Task<Order> GetAsync(Guid id)
            => await Table.FindAsync(id);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<Order> UpdateAsync(Order entity)
            => Table.Update(entity).Entity;
    }
}



