namespace DatabaseModelsBase
{
    internal interface IDbRepositoryContextFactory : IDbRepositoryContextFactory<BaseDataBaseContext>
    {
    }

    internal interface IDbRepositoryContextFactory<T> where T : BaseDataBaseContext
    {
        T CreateDbContext();
    }
}
