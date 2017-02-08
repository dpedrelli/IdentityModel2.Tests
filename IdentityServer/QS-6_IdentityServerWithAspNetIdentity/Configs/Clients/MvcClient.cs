using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity.Configs.Clients
{
    public class MvcClient
    {
        public static List<Client> GetList(string clientId, string clientName, string secret, string resource, ICollection<string> baseRedirectUris)
        {
            return new List<Client>
            {
                Get(clientId, clientName, secret, resource, baseRedirectUris)
            };
        }
        public static Client Get(string clientId, string clientName, string secret, string resource, ICollection<string> baseRedirectUris)
        {
            List<string> redirectUris = new List<string>();
            List<string> postLogoutRedirectUris = new List<string>();
            foreach (string uri in baseRedirectUris)
            {
                string temp = uri;
                if (temp.LastIndexOf("/") < temp.Length - 1)
                {
                    temp += "/";
                }
                redirectUris.Add(temp + "signin-oidc");
                postLogoutRedirectUris.Add(temp);
            }

            // OpenID Connect hybrid flow and client credentials client (MVC)
            return new Client
            {
                ClientId = clientId,//"mvc",
                ClientName = clientName,//"MVC Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireConsent = false,

                ClientSecrets =
                {
                    //new Secret("secret".Sha256())
                    new Secret(secret.Sha256())
                },

                //RedirectUris = { "http://localhost:5002/signin-oidc" },
                //PostLogoutRedirectUris = { "http://localhost:5002" },
                RedirectUris = redirectUris,
                PostLogoutRedirectUris = postLogoutRedirectUris,

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    resource
                },
                AllowOfflineAccess = true,

                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
            };
        }
    }
}
