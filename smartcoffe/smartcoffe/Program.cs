using Hangfire;
using smartcoffe.Application.Extension;
using smartcoffe.Configuration;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.DependencyInjection;
using smartcoffe.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------------------- SERVICIOS ------------------------

// PASO CLAVE 1: Configuración de Autenticación JWT Bearer
// Esto resuelve el error "No authenticationScheme was specified..."
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        // Usar ?? para asegurar que haya una clave, si no lanza una excepción más clara
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key not found in configuration"))),
        
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        
        ValidateLifetime = true,
        // Define el tipo de claim que contiene el rol, necesario para [Authorize(Roles = "...")]
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" 
    };
});

// PASO CLAVE 2: Registro faltante para IInventoryService (resuelve el error de DI inicial)
// Se asume que la clase de implementación se llama 'InventoryService'
builder.Services.AddScoped<IInventoryService, InventoryService>();

// Registros originales
builder.Services.AddProjectServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddScoped<IExcelService, ExcelService>();

// --- Extensiones personalizadas ---
builder.Services.AddSwaggerDocumentation();
builder.Services.AddHangfireConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddControllersConfiguration();

builder.Services.AddAppServices(builder.Configuration, builder.Environment);

// ---------------------- APP ------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

// PASO CLAVE 3: El orden es CRÍTICO: Authentication debe ir ANTES de Authorization
app.UseAuthentication(); 
app.UseAuthorization(); // Esta línea ahora funcionará correctamente

app.UseHangfireDashboard();
app.UseApp();

app.MapControllers();
app.Run();