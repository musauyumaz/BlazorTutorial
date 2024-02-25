using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<MealOrderingDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("NpgSQL")));
        }
    }
}
