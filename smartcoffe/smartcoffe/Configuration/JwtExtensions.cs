using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace smartcoffe.Configuration;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ??
                        throw new InvalidOperationException(
                            "Jwt:Key not found in configuration"))),
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],

                    ValidateLifetime = true,
                    // Define el tipo de claim que contiene el rol, necesario para [Authorize(Roles = "...")]
                    RoleClaimType = "Rrole",// Asegúrate de que este es el nombre del claim que usas
                    NameClaimType = "email",
                };
            });

        // Asegúrate de añadir AddAuthorization() también si no está en el Program.cs
        services.AddAuthorization();
        
        return services;
    }
}