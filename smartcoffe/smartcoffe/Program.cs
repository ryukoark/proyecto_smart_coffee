using Hangfire;
using smartcoffe.Application.Extension;
using smartcoffe.Configuration;
using smartcoffe.Domain.Interfaces;
using smartcoffe.Infrastructure.DependencyInjection;
using smartcoffe.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------- SERVICIOS ------------------------
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
app.UseAuthorization();

app.UseHangfireDashboard();
app.UseApp();

app.MapControllers();
app.Run();