using NLog.Web;
using User.Api.Extensions;
using User.Services.Extensions;

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

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

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