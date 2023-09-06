using Microsoft.AspNetCore.Mvc;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It`s live!");
        }
        #endregion
    }
}
