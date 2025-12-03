namespace smartcoffe.Configuration;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        // Lee la variable de entorno FRONTEND_URL.
        // Si no está definida (ej: al correr localmente), usa el localhost:5175 por defecto.
        var corsOrigin = Environment.GetEnvironmentVariable("FRONTEND_URL") 
                         ?? "http://localhost:5175"; // <-- Fallback local

        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins(corsOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}