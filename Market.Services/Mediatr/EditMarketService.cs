using Market.Services.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using ResponceModel;

namespace Market.Services.Mediatr;

internal class EditMarketService : IRequestHandler<MarketEditM, ResponseData<Models.Market>>
{
    #region Fields
    private readonly ILogger<EditMarketService> _logger;
    #endregion

    #region Constructor
    public EditMarketService(ILogger<EditMarketService> logger)
    {
        _logger = logger;
    }
    #endregion

    #region IRequestHandler
    public Task<ResponseData<Models.Market>> Handle(MarketEditM editMarket, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Edit market: {editMarket.Id}");
        return Task.FromResult(new ResponseData<Models.Market>(new Models.Market()));
    } 
    #endregion
}
