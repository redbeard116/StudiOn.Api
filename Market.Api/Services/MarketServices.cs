using Market.Api.Data;

namespace Market.Api.Services
{
    public interface IMarketServices
    {

    }

    internal class MarketServices: IMarketServices
    {
        #region Fields
        private readonly ILogger<MarketServices> _logger;
        private readonly IDbRepositoryContextFactory _dbRepositoryContextFactory;
        #endregion

        #region Constructor
        public MarketServices(ILogger<MarketServices> logger,
                              IDbRepositoryContextFactory dbRepositoryContextFactory)
        {
            _logger = logger;
            _dbRepositoryContextFactory = dbRepositoryContextFactory;
        }
        #endregion

        #region IMarketServices

        #endregion
    }
}
