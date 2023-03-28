using Authentication.Api.Extensions;
using Authentication.Api.Services;
using IdentityService;
using IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Fields
        private readonly IAuthService _authService;
        #endregion

        #region Constructor
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthRequest userLogin)
        {
            var result = await _authService.AuthUser(userLogin);

            return this.Result(result);
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        //[ProducesResponseType(200, Type = typeof(ResponseData<UserResponse>))]
        public async Task<IActionResult> UserRefreshToken()
        {
            return Ok("It`s live");
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("logout")]
        [ProducesResponseType(200)]
        public async Task LogOut()
        {

        }
        #endregion
    }
}
