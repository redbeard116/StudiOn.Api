using Market.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<MarketsController> _logger;
        private readonly IMarketServices _marketServices;
        #endregion

        #region Constructor
        public MarketsController(ILogger<MarketsController> logger,
                                 IMarketServices marketServices)
        {
            _logger = logger;
            _marketServices = marketServices;

        }
        #endregion

        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It`s live!");
        }
        #endregion
    }
}
