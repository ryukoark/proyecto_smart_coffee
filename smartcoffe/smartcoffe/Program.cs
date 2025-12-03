using Hangfire;
using smartcoffe.Application.Extension; // Asumo que contiene AddProjectServices
using smartcoffe.Configuration;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.DependencyInjection; // Asumo que contiene AddInfrastructure/AddInfrastructureServices
using smartcoffe.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ======================== REGISTRO DE SERVICIOS (builder.Services) ========================

// 1. Servicios del Framework (controladores, endpoints)
builder.Services.AddControllersConfiguration();
builder.Services.AddEndpointsApiExplorer(); // Asegura la compatibilidad con Swagger

// 2. Seguridad y Documentación
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsConfiguration();

// 3. Autenticación y Autorización (Usando la extensión JwtExtensions)
builder.Services.AddJwtAuthentication(builder.Configuration);

// 4. Background Job Processing (Usando la extensión HangfireExtensions)
//builder.Services.AddHangfireConfiguration(builder.Configuration);

// 5. Servicios de Infraestructura y Negocio
builder.Services.AddProjectServices(); // Lógica de la capa Application
builder.Services.AddInfrastructure(builder.Configuration); // Configuración de la persistencia
builder.Services.AddInfrastructureServices(); // Implementaciones de servicios de dominio

// Servicios que fueron explícitamente registrados en tu código parcial
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IExcelService, ExcelService>();

// Servicios generales de la aplicación (extensión ServiceRegistrationExtensions)
builder.Services.AddAppServices(builder.Configuration, builder.Environment);


// =============================== MIDDLEWARE (app) ===============================

var app = builder.Build();

// Configuración del Pipeline de Peticiones HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger y Swagger UI (desde SwaggerExtensions)
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

// 1. CORS Middleware (debe ir antes de UseRouting/MapControllers)
app.UseCors("AllowFrontend");

// 2. Hangfire Dashboard (se activa la interfaz web)
//app.UseHangfireDashboard();

// 3. Autenticación y Autorización (EL ORDEN ES CRÍTICO: Auth debe ir antes de Authz)
app.UseAuthentication();
app.UseAuthorization(); 

// 4. Custom Application Middleware (desde ServiceRegistrationExtensions)
app.UseApp();

// 5. Programar Tareas Recurrentes de Hangfire
// Esto debe ejecutarse después de app.Build() y de que los servicios estén configurados.
//HangfireJobScheduler.ScheduleRecurringJobs(app);

// 6. Mapping (siempre debe ir al final)
app.MapControllers();

app.Run();