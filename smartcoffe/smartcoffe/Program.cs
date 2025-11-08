using smartcoffe.Application.Extension;
using smartcoffe.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using Microsoft.OpenApi.Models; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Mvc; // Aseguramos este using si lo necesitas
using smartcoffe.Configuration; // El using para tus extensiones personalizadas

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS (Dependency Injection) ---

// Llama al registro de la capa de Aplicación (MediatR y Handlers)
builder.Services.AddProjectServices();

// Llama al registro de Infraestructura (DbContext de PostgreSQL y UnitOfWork)
builder.Services.AddInfrastructure(builder.Configuration);

// ⭐ CONFIGURACIÓN DE SWAGGER ⭐
builder.Services.AddEndpointsApiExplorer();
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

// ⭐ LÓGICA DE SERVICIOS PERSONALIZADA (DEBE IR ANTES DE app.Build()) ⭐
builder.Services.AddAppServices(builder.Configuration, builder.Environment);


// --- 2. CONSTRUCCIÓN Y CONFIGURACIÓN DEL PIPELINE ---

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // ⭐ MIDDLEWARE DE SWAGGER ⭐
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Coffee API V1");
    });
}

app.UseHttpsRedirection();

// ⭐ MIDDLEWARE PERSONALIZADO (DEBE IR DESPUÉS DE app.Build()) ⭐
app.UseApp();

// Mapeo de Endpoints
app.MapControllers(); 

app.Run();