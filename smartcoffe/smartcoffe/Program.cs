using smartcoffe.Application.Extension;
using smartcoffe.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using Microsoft.OpenApi.Models; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Mvc;
using smartcoffe.Configuration;
using Hangfire;
using Hangfire.PostgreSql;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

// --- 1. CONFIGURACIÓN DE SERVICIOS (Dependency Injection) ---

// Llama al registro de la capa de Aplicación (MediatR y Handlers)
builder.Services.AddProjectServices();

// Llama al registro de Infraestructura (DbContext de PostgreSQL y UnitOfWork)
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddInfrastructureServices();

// CONFIGURACIÓN DE JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = jwtSettings.GetValue<string>("Key") ?? throw new InvalidOperationException("Jwt:Key not found.");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

// IMPORTANTE: Asegúrate de añadir el servicio de Autorización.
builder.Services.AddAuthorization();


// CONFIGURACIÓN DE HANGFIRE
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Añade el servidor de Hangfire (quien procesa las tareas en segundo plano)
builder.Services.AddHangfireServer();

// CONFIGURACIÓN DE SWAGGER (Asegurando que soporte la entrada de JWT)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Smart Coffee API",
        Version = "v1",
        Description = "API para la gestión de categorías, productos y promociones en Smart Coffee."
    });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token: Bearer {token}"
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    };
    c.AddSecurityRequirement(securityRequirement);
});

// Agregar soporte para Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    // Define una política de nombre "AllowFrontend"
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            // Reemplaza 5173 por el puerto de tu React si es diferente
            policy.WithOrigins("http://localhost:5173") 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Importante si usas cookies o JWT en headers
        });
});
// LÓGICA DE SERVICIOS PERSONALIZADA
builder.Services.AddAppServices(builder.Configuration, builder.Environment);


// --- 2. CONSTRUCCIÓN Y CONFIGURACIÓN DEL PIPELINE ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Coffee API V1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

// IMPORTANTE: Los middlewares de autenticación y autorización deben ir aquí,
// antes de app.MapControllers().
app.UseAuthentication();
app.UseAuthorization(); // Mantenemos este uso aquí para el pipeline global

app.UseHangfireDashboard(); 
HangfireJobScheduler.ScheduleRecurringJobs(app);

app.UseApp();

// Mapeo de Endpoints
app.MapControllers(); 

app.Run();