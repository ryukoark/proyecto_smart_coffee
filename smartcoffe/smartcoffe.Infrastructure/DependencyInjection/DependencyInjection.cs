using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Registrar IUnitOfWork como Scoped (lo más común para transacciones de web request)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // (Opcional) Si quieres exponer el Repositorio Genérico directamente
            // services.AddScoped(typeof(IGenericRepository<>), typeof(Repositories.GenericRepository<>));

            return services;
        }
    }
}