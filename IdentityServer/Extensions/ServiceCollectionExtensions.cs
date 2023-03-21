namespace IdentityServer.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentityServer()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddTestUsers(Config.TestUsers())
                .AddDeveloperSigningCredential();
        }
    }
}
