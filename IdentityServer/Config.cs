using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    internal static class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                   new Client
                   {
                        ClientId = "productClient",
                        ClientSecrets =
                        {
                           new Secret("product_secret".ToSha256())
                        },
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = { "ProductsAPI" }
                   }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ProductsAPI")
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("ProductsAPI")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            };
        }

        public static List<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "test",
                    Password = "12345678",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Test"),
                        new Claim(JwtClaimTypes.GivenName, "Test"),
                        new Claim(JwtClaimTypes.FamilyName, "Test")
                    }
                }
            };
        }
    }
}
