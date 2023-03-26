using Authentication.Api.Data;
using Authentication.Api.Data.Models;
using IdentityService;
using IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using ResponceModel;

namespace Authentication.Api.Services
{
    public interface IAuthService
    {
        Task<ResponseData<AuthResponce>> AuthUser(AuthRequest userAuth);
        Task<ResponseData<AuthResponce>> RefreshToken(int userId, string refreshToken);
        Task Logout(string refreshToken);
    }

    internal class AuthService : IAuthService
    {
        #region Fields
        private readonly ILogger<AuthService> _logger;
        private readonly IDbRepositoryContextFactory _contextFactory;
        private readonly IJwtTokenHandler _loginService;
        #endregion

        #region Constructor
        public AuthService(ILogger<AuthService> logger,
                           IDbRepositoryContextFactory contextFactory,
                           IJwtTokenHandler loginService)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _loginService = loginService;
        }
        #endregion

        #region IAuthService
        public async Task<ResponseData<AuthResponce>> AuthUser(AuthRequest userAuth)
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
                _logger.LogError(ex, $"Error in {nameof(AuthUser)}");
                throw;
            }
        }

        public Task Logout(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<AuthResponce>> RefreshToken(int userId, string refreshToken)
        {
            throw new NotImplementedException();
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
                    var auth = await db.Users.FirstOrDefaultAsync(w => w.Login == user.Login);

                    if (auth != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(user.Password, auth.Password))
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
}
