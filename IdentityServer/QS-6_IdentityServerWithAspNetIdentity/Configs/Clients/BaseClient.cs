using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity
{
    public class BaseClient
    {
        public static Client Get(string id, string name, string secret, string uri, IEnumerable<string> grantTypes, bool requireConsent, bool allowOffline, bool requirePkce, bool useJwt, bool openId, bool profile, string scopes)
        {
            ICollection<string> scope = new List<string>();
            if (openId)
            {
                scope.Add(IdentityServerConstants.StandardScopes.OpenId);
            }
            if (profile)
            {
                scope.Add(IdentityServerConstants.StandardScopes.Profile);
            }
            string[] words = scopes.Split(' ');
            foreach (var word in words)
            {
                scope.Add(word);
            }

            AccessTokenType accessTokenType = AccessTokenType.Reference;
            if (useJwt) { accessTokenType = AccessTokenType.Jwt; }
            var client = new Client
            {
                ClientId = id,
                ClientName = name,
                AllowedGrantTypes = grantTypes,
                RequireConsent = requireConsent,
                RedirectUris = { uri },
                PostLogoutRedirectUris = { uri },
                AllowOfflineAccess = allowOffline,
                RequirePkce = requirePkce,
                AccessTokenType = accessTokenType,
                AllowedScopes = scope,
            };

            if (secret.Length > 0)
            {
                ICollection<Secret> secrets = new List<Secret>();
                secrets.Add(new Secret(secret.Sha256()));
                client.ClientSecrets = secrets;
            }

            return client;
        }
    }
}
