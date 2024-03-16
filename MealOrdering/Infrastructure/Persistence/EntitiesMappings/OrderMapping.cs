using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesMappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.Property(o => o.Description).HasMaxLength(1000);

            builder.HasOne(o => o.CreateUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CreateUserId);

            builder.HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId);
        }
    }
}



