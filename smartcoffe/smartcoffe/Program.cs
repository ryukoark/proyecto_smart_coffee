using smartcoffe.Application.Extension;
using smartcoffe.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using Microsoft.OpenApi.Models; // Necesario para OpenApiInfo
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Mvc; 

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS (Dependency Injection) ---

// Llama al registro de la capa de Aplicación (MediatR y Handlers)
builder.Services.AddProjectServices();

// Llama al registro de Infraestructura (DbContext de PostgreSQL y UnitOfWork)
builder.Services.AddInfrastructure(builder.Configuration);

// ⭐ CONFIGURACIÓN DE SWAGGER ⭐
// Habilita el explorador de endpoints para generar documentación
builder.Services.AddEndpointsApiExplorer();

// Define la documentación de Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Smart Coffee API",
        Version = "v1",
        Description = "API para la gestión de categorías, productos y promociones en Smart Coffee."
    });
});

// Agregar soporte para Controllers
builder.Services.AddControllers();

// --- 2. CONSTRUCCIÓN Y CONFIGURACIÓN DEL PIPELINE ---

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // ⭐ MIDDLEWARE DE SWAGGER ⭐
    // Habilita el middleware de Swagger (Genera el archivo JSON de especificación)
    app.UseSwagger();

    // Habilita el middleware de SwaggerUI (La interfaz web interactiva)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Coffee API V1");
    });
}

app.UseHttpsRedirection();

// Mapeo de Endpoints
app.MapControllers(); 

app.Run();