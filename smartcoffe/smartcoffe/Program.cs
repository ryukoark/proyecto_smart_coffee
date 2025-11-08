using smartcoffe.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseApp();

app.Run();