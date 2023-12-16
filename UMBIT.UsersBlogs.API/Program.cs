using Microsoft.AspNetCore.Builder;
using Prototico.Core.API.Configurate.ApiConfigurate;
using Prototico.Core.API.Configurate.Swagger;
using UMBIT.UsersBlogs.API.Configurate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig();
builder.Services.AddUMBITServiceMySQL(builder.Configuration, "mariadb");
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddMapper();

var app = builder.Build();

app.UseApiConfig(app.Environment);
app.UseUMBITServiceMySQL();

app.Run();
