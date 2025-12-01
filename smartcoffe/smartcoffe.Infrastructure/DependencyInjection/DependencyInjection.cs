using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using smartcoffe.Infrastructure.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace smartcoffe.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {

            services.AddDbContext<SmartcoffeDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))); 
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpClient<IPaymentGatewayService, IzipayPaymentService>();

            return services;
        }
    }
}