using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity
{
    public class IdentityServerSampleClients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                GetClient(),
                GetRoClient(),
                GetMvcClient(),
            };
        }

        // client credentials client
        public static Client GetClient()
        {
            return new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                AllowedScopes = { "api1" }
            };
        }

        // resource owner password grant client
        public static Client GetRoClient()
        {
            return new Client
            {
                ClientId = "ro.client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                AllowedScopes = { "api1" }
            };
        }

        // OpenID Connect hybrid flow and client credentials client (MVC)
        public static Client GetMvcClient()
        {
            return new Client
            {
                ClientId = "mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                RequireConsent = true,

                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                RedirectUris = { "http://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5002" },

                AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                AllowOfflineAccess = true
            };
        }
    }
}
