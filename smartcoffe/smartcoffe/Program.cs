using smartcoffe.Application.Extension;
// Asegúrate de que este using esté apuntando al namespace correcto donde definiste AddInfrastructure
using smartcoffe.Infrastructure.DependencyInjection; 
// Necesario para IConfiguration que se usa en AddInfrastructure
using Microsoft.Extensions.Configuration; 

var builder = WebApplication.CreateBuilder(args);

// --- Configuración de Servicios (Dependency Injection) ---

// Llama al registro de la capa de Aplicación (MediatR, etc.)
builder.Services.AddProjectServices();

// ⭐ CORRECCIÓN CLAVE ⭐
// Llama al registro de la capa de Infraestructura, 
// pasándole la configuración (builder.Configuration) para que AddInfrastructure
// pueda configurar el DbContext de PostgreSQL.
builder.Services.AddInfrastructure(builder.Configuration);

// ... el resto de las llamadas de servicios
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// --- Construcción y Configuración del Pipeline ---

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Nota: Las siguientes líneas son el ejemplo de WebApp template
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// ... Mapeo de Endpoints y Middleware

app.Run();