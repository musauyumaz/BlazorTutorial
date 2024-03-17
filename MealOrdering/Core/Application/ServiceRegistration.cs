using Application.Features.Auths.Rules;
using Application.Features.Users.Rules;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
        }
    }
}



