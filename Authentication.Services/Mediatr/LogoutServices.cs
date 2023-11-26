using Authentication.Services.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Authentication.Services.Mediatr;

internal class LogoutServices : IRequestHandler<UserLogout>
{
    #region Fields
    private readonly ILogger<LogoutServices> _logger;
    #endregion

    #region Constructor
    public LogoutServices(ILogger<LogoutServices> logger)
    {
        _logger = logger;
    }
    #endregion

    #region IRequestHandler
    public Task Handle(UserLogout request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Logout");
        return Task.CompletedTask;
    } 
    #endregion
}
