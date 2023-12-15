using Microsoft.AspNetCore.Builder;
using UMBIT.UsersBlogs.API.Configurate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig();
builder.Services.AddUMBITServiceMySQL();
var app = builder.Build();

app.UseApiConfig(app.Environment);

app.Run();
