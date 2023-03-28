using Producst.Api.Data;

namespace Producst.Api.Services
{
    public interface IProductServices
    {

    }

    internal class ProductServices: IProductServices
    {
        #region Fields
        private readonly ILogger<ProductServices> _logger;
        private readonly IDbRepositoryContextFactory _dbRepositoryContextFactory;
        #endregion

        #region Constructor
        public ProductServices(ILogger<ProductServices> logger,
                               IDbRepositoryContextFactory dbRepositoryContextFactory)
        {
            _logger = logger;
            _dbRepositoryContextFactory = dbRepositoryContextFactory;
        }
        #endregion

        #region IProductServices

        #endregion
    }
}
