﻿using Domain.Entities;
using Domain.Entities.Commons;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Persistence.Contexts
{
    public class MealOrderingDbContext : DbContext
    {
        public MealOrderingDbContext(DbContextOptions<MealOrderingDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>>? datas = ChangeTracker.Entries<BaseEntity>();

            Parallel.ForEach(datas, data =>
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                    data.Entity.IsActive = true;
                }
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
