using Authentication.Services.Models;
using IdentityService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResponceModel;
using System.IdentityModel.Tokens.Jwt;

namespace Authentication.Services.Mediatr;

internal class RefreshTokenServices : IRequestHandler<RefreshToken, ResponseData<AuthResponce>>
{
    #region Fields
    private readonly ILogger<RefreshTokenServices> _logger;
    private readonly TokenValidationParameters _tokenValidationParameters;
    #endregion

    #region Fields
    public RefreshTokenServices(ILogger<RefreshTokenServices> logger, TokenValidationParameters tokenValidationParameters)
    {
        _logger = logger;
        _tokenValidationParameters = tokenValidationParameters;
        _tokenValidationParameters.ValidateLifetime = false;
    }
    #endregion

    #region IRequestHandler
    public async Task<ResponseData<AuthResponce>> Handle(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        var userId = GetUserId(refreshToken.HttpRequest);

        if (!userId.HasValue)
            return new ResponseData<AuthResponce>(System.Net.HttpStatusCode.Unauthorized, "Invalid Token");

        _logger.LogInformation($"Refresh token {userId}");


        return new ResponseData<AuthResponce>(new AuthResponce());
    }
    #endregion

    #region Private methods
    private int? GetUserId(HttpRequest context)
    {
        try
        {
            string tokenStr = null;

            if (context.Headers.ContainsKey("Authorization"))
            {
                tokenStr = context.Headers["Authorization"].First().Replace("Bearer ", "");
            }
            if (string.IsNullOrWhiteSpace(tokenStr) && context.Query.ContainsKey("token"))
            {
                tokenStr = context.Query["token"];
            }

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var claims = jwtSecurityTokenHandler.ValidateToken(tokenStr, _tokenValidationParameters, out _);

            string userId = claims.Claims.FirstOrDefault(w => w.Type == "userid").Value;
            return Convert.ToInt32(userId);
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion
}
