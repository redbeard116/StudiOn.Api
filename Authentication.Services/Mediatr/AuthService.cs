using Authentication.Services.Data;
using Authentication.Services.Data.Models;
using Authentication.Services.Models;
using IdentityService;
using IdentityService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResponceModel;

namespace Authentication.Services.Mediatr;

internal class AuthService : IRequestHandler<AuthRequest, ResponseData<AuthResponce>>
{
    #region Fields
    private readonly ILogger<AuthService> _logger;
    private readonly IDbRepositoryContextFactory _contextFactory;
    private readonly IJwtTokenHandler _loginService;
    private readonly IPasswordVerificator _passwordVerificator;
    #endregion

    #region Constructor
    public AuthService(ILogger<AuthService> logger,
                       IDbRepositoryContextFactory contextFactory,
                       IJwtTokenHandler loginService,
                       IPasswordVerificator passwordVerificator)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _loginService = loginService;
        _passwordVerificator = passwordVerificator;
    }
    #endregion

    #region IRequestHandler
    public async Task<ResponseData<AuthResponce>> Handle(AuthRequest userAuth, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug($"Auth user {userAuth.Login}");
            if (userAuth == null)
            {
                return new ResponseData<AuthResponce>(System.Net.HttpStatusCode.BadRequest, "Object is null");
            }

            var user = await GetUserAuth(userAuth);

            if (user != null)
            {
                //TODO role
                var authResonse = _loginService.GenerateJwtToken(user.Login, "Admin", user.Id);

                return new ResponseData<AuthResponce>(authResonse);
            }

            return new ResponseData<AuthResponce>(System.Net.HttpStatusCode.NotFound, "Неверный логин или пароль");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error in {nameof(Handle)}");
            throw;
        }
    }
    #endregion

    #region Private methods
    private async Task<UserDb> GetUserAuth(AuthRequest user)
    {
        try
        {
            _logger.LogInformation($"Auth in server");
            using (var db = _contextFactory.CreateDbContext())
            {
                var auth = await db.Users.AsNoTracking().FirstOrDefaultAsync(w => w.Login == user.Login);

                if (auth != null)
                {
                    if (_passwordVerificator.Verify(user.Password, auth.Password))
                    {
                        return auth;
                    }
                }
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"GetUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
            throw;
        }
    }
    #endregion
}
