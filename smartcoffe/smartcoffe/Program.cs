using System.Text;
using Microsoft.IdentityModel.Tokens;
using smartcoffe.Application.Extension;
using smartcoffe.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models; 
using smartcoffe.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// === Agregar autenticación JWT ===
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var cfg = builder.Configuration;
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = cfg["Jwt:Issuer"],
        ValidAudience = cfg["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Jwt:Key"] ?? string.Empty)),
        ClockSkew = TimeSpan.Zero
    };
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
// --- 1. CONFIGURACIÓN DE SERVICIOS (Dependency Injection) ---

// Llama al registro de la capa de Aplicación (MediatR y Handlers)
builder.Services.AddProjectServices();

// Llama al registro de Infraestructura (DbContext de PostgreSQL y UnitOfWork)
builder.Services.AddInfrastructure(builder.Configuration);

// CONFIGURACIÓN DE SWAGGER
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

// LÓGICA DE SERVICIOS PERSONALIZADA (DEBE IR ANTES DE app.Build())
builder.Services.AddAppServices(builder.Configuration, builder.Environment);

// Registrar servicios existentes
builder.Services.AddProjectServices();
builder.Services.AddInfrastructure(builder.Configuration);


// --- 2. CONSTRUCCIÓN Y CONFIGURACIÓN DEL PIPELINE ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // MIDDLEWARE DE SWAGGER
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Coffee API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// MIDDLEWARE PERSONALIZADO
app.UseApp();

// Mapeo de Endpoints
app.MapControllers(); 

app.Run();