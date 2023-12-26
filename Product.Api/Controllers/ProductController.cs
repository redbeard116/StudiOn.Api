using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET api/product");
            return Ok("It`s live!");
        }
        #endregion
    }
}
