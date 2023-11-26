using Authentication.Services.Models;
using IdentityService.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using ResponceModel;

namespace Authentication.Services.Mediatr;

internal class RefreshTokenServices : IRequestHandler<RefreshToken, ResponseData<AuthResponce>>
{
    #region Fields
    private readonly ILogger<RefreshTokenServices> _logger;
    #endregion

    #region Fields
    public RefreshTokenServices(ILogger<RefreshTokenServices> logger)
    {
        _logger = logger;
    }
    #endregion

    #region IRequestHandler
    public Task<ResponseData<AuthResponce>> Handle(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Refresh token {refreshToken.UserId}");
        return Task.FromResult(new ResponseData<AuthResponce>(new AuthResponce()));
    } 
    #endregion
}
