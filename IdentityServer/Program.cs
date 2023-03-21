using IdentityServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.UseRouting();

app.UseIdentityServer();

app.MapControllers();

app.Run();