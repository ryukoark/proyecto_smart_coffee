namespace smartcoffe.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{

    public static void AddAppServices(this IServiceCollection services, ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "SmartCoffe API",
                Version = "v1",
                Description = "API for SmartCoffe project",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "SmartCoffe",
                    Email = "support@smartcoffe.local"
                }
            });

        });
    }

    public static void UseApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
    }
}