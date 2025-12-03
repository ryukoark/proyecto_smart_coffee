using Microsoft.Extensions.DependencyInjection;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.Services;

namespace smartcoffe.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IExcelService, ExcelService>();

        return services;
    }
}