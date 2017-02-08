using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity.Configs.Clients
{
    public class ExeClient
    {
        public static IEnumerable<Client> GetList(string clientId, string clientName, string secret, string resource, int port)
        {
            return new List<Client>
            {
                Get(clientId, clientName, secret, resource, port)
            };
        }

        public static Client Get(string clientId, string clientName, string secret, string resource, int port = 7890)
        {
            string redirectUri = "http://127.0.0.1:" + port.ToString() + "/";
            return new Client
            {
                ClientId = clientId,//"execlient",
                ClientName = clientName,//"EXE Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                RequireConsent = false,

                ClientSecrets =
                    {
                        //new Secret("secret".Sha256())
                        new Secret(secret.Sha256())
                    },

                RedirectUris = { redirectUri },
                PostLogoutRedirectUris = { redirectUri },
                //RedirectUris = { "http://127.0.0.1:7890/" },
                //PostLogoutRedirectUris = { "http://127.0.0.1:7890/" },

                AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        resource
                        //"api1"
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
