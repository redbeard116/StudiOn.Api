using Market.Services.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using ResponceModel;

namespace Market.Services.Mediatr;

internal class AddMarketService : IRequestHandler<MarketAdd, ResponseData<Models.Market>>
{
    #region Fields
    private readonly ILogger<AddMarketService> _logger;
    #endregion

    #region Constructor
    public AddMarketService(ILogger<AddMarketService> logger)
    {
        _logger = logger;
    }
    #endregion

    #region IRequestHandler
    public Task<ResponseData<Models.Market>> Handle(MarketAdd request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Add new market");
        return Task.FromResult(new ResponseData<Models.Market>(new Models.Market()));
    } 
    #endregion
}
