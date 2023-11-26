using Authentication.Services.Extensions;
using Authentication.Api.Extensions;
using NLog.Web;

var logFactory = NLogBuilder.ConfigureNLog(GetNlogConfig());
var logger = logFactory.GetCurrentClassLogger();
logger.Info("Init main");

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Configurations/appsettings.json");
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.SetDatabaseMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetNlogConfig()
{
#if DEBUG
    return "Configurations/nlog.debug.config";
#endif
    return "Configurations/nlog.config";
}