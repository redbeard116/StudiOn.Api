using ResponceModel.Extensions;
using Authentication.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Fields
        private readonly ILogger<LoginController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public LoginController(IMediator mediator, ILogger<LoginController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
            _logger.LogInformation("POST api/login");
            var result = await _mediator.Send(userLogin);

            return this.Result(result);
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> UserRefreshToken(int id)
        {
            _logger.LogInformation($"POST api/login/{id}/refresh-token");
            var refreshToken = this.Request.Headers["refresh-token"];
            var result = await _mediator.Send(new RefreshToken(id, refreshToken));
            return this.Result(result);
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
            _logger.LogInformation($"POST api/login/logout");
            var refreshToken = this.Request.Headers["refresh-token"];
            await _mediator.Send(new UserLogout(refreshToken));
        }
        #endregion
    }
}
