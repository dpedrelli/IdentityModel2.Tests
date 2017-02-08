using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity
{
    public class QCClient
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
            return GetV2();
        }

        //public static Client GetV1()
        //{
        //    return new Client
        //    {
        //        ClientId = "qcclient",
        //        ClientName = "QC Client",
        //        AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
        //        RequireConsent = true,

        //        ClientSecrets =
        //            {
        //                new Secret("secret".Sha256())
        //            },

        //        RedirectUris = { "http://localhost/winforms.client" },
        //        PostLogoutRedirectUris = { "http://localhost/winforms.client" },

        //        AllowedScopes =
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                "qcserver"
        //            },
        //        AllowOfflineAccess = true,
        //        AccessTokenType = AccessTokenType.Jwt,
        //        RequirePkce = true
        //    };
        //}

        public static Client GetV2()
        {
            return new Client
            {
                ClientId = "qcclient",
                ClientName = "QC Client",
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                RequireConsent = true,

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
                        "qcserver"
                    },
                AllowOfflineAccess = true,
                AccessTokenType = AccessTokenType.Jwt,
                RequirePkce = true
            };
        }
    }
}
