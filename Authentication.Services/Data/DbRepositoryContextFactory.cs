using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data
{
    internal interface IDbRepositoryContextFactory: IDbContextFactory<DBService>
    {
    }

    internal class DbRepositoryContextFactory: IDbRepositoryContextFactory
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public DbRepositoryContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        } 
        #endregion

        public DBService CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBService>();
            optionsBuilder
                .UseNpgsql(_connectionString);

            return new DBService(optionsBuilder.Options);
        }
    }
}
