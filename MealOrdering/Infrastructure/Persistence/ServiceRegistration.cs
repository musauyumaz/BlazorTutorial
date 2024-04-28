using Application.Commons.Abstractions.Repositories;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MealOrderingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("NpgSQL"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IBaseRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Order>, OrderRepository>();
            services.AddScoped<IBaseRepository<OrderItem>, OrderItemRepository>();
        }
    }
}
