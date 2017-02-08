using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity.Configs.Clients
{
    public class ExeClient
    {
        public static IEnumerable<Client> GetList()
        {
            return new List<Client>
            {
                Get()
            };
        }

        public static Client Get()
        {
            return new Client
            {
                ClientId = "execlient",
                ClientName = "EXE Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                RequireConsent = false,

                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                RedirectUris = { "http://127.0.0.1:7890/" },
                PostLogoutRedirectUris = { "http://127.0.0.1:7890/" },

                AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                AllowOfflineAccess = true,
                AccessTokenType = AccessTokenType.Jwt,
                RequirePkce = true,

                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
            };
        }
    }
}
