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
        private readonly JwtTokenHandler _loginService;
        #endregion

        #region Constructor
        public LoginController()
        {
            _loginService = new JwtTokenHandler();
        }
        #endregion

        #region Actions
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] AuthRequest userLogin)
        {
            var result = _loginService.GenerateJwtToken(userLogin);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        //[ProducesResponseType(200, Type = typeof(ResponseData<UserResponse>))]
        public async Task<IActionResult> UserRefreshToken()
        {
            return Ok();
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
