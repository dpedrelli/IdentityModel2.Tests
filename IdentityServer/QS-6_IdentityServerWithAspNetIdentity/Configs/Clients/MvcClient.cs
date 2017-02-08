using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity.Configs.Clients
{
    public class MvcClient
    {
        public static List<Client> GetList()
        {
            return new List<Client>
            {
                Get()
            };
        }
        public static Client Get()
        {
            // OpenID Connect hybrid flow and client credentials client (MVC)
            return new Client
            {
                ClientId = "mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireConsent = false,

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
                AllowOfflineAccess = true,

                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
            };
        }
    }
}
