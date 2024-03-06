using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderItemRepository(MealOrderingDbContext _context) : IOrderItemRepository
    {
        public DbSet<OrderItem> Table => _context.OrderItems;

        public async Task<OrderItem> AddAsync(OrderItem entity)
            => (await Table.AddAsync(entity)).Entity;

        public async Task<OrderItem> DeleteAsync(Guid id)
        {
            OrderItem? deletedEntity = await GetAsync(id);
            Table.Remove(deletedEntity);
            return deletedEntity;
        }

        public async Task<IQueryable<OrderItem>> GetAllAsync()
            => Table.AsQueryable();

        public async Task<OrderItem> GetAsync(Guid id)
            => await Table.FindAsync(id);

        public Task<int> SaveAsync()
            => _context.SaveChangesAsync();

        public async Task<OrderItem> UpdateAsync(OrderItem entity)
            => Table.Update(entity).Entity;
    }
}



