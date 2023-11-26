using Market.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResponceModel.Extensions;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<MarketsController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public MarketsController(ILogger<MarketsController> logger,
                                 IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MarketAdd marketAdd)
        {
            _logger.LogInformation("POST api/market");
            var result = await _mediator.Send(marketAdd);
            return this.Result(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] MarketEdit marketEdit)
        {
            _logger.LogInformation($"PATCH api/market/{id}");
            MarketEditM marketEditM = (MarketEditM)marketEdit;
            marketEditM.Id = id;
            var result = await _mediator.Send(marketEdit);
            return this.Result(result);
        }
        #endregion
    }
}
