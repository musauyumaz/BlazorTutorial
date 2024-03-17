using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntitiesMappings
{
    public class AppUserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
        }
    }
}



