namespace smartcoffe.Configuration;

public static class ControllersExtensions
{
    public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}