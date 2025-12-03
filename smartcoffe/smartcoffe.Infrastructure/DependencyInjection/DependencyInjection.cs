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
            services.AddScoped<IInventoryService, smartcoffe.Infrastructure.Services.InventoryService>();
            services.AddDbContext<SmartcoffeDbContext>(options =>
            {
                // Usa la conexión a Supabase (PostgreSQL)
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"), // Asegúrate que el nombre sea correcto
                    npgsqlOptions =>
                    {
                        // ** CLAVE: Habilitar la Estrategia de Reintento **
                        npgsqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5, // Reintentará hasta 5 veces
                            maxRetryDelay: TimeSpan.FromSeconds(30), // Espera máxima de 30 segundos
                            errorCodesToAdd: null // Usa los códigos de error por defecto (incluye timeouts)
                        );
                    
                        // Opcional: También puedes aumentar el tiempo de espera del comando aquí si lo deseas:
                        // npgsqlOptions.CommandTimeout(60); 
                    }
                );
            });
            return services;
        }
    }
}