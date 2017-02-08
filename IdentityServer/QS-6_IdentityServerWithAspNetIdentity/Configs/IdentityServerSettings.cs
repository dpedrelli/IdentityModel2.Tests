using System.Collections.Generic;

namespace IdentityServerWithAspNetIdentity.Configs
{
    public class ClientSettings
    {
        public string Type { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<string> AllowedGrantTypes { get; set; }
        public ICollection<string> BaseRedirectUris { get; set; }
        public ICollection<string> RedirectUris { get; set; }
        public ICollection<string> PostLogoutRedirectUris { get; set; }
        public string LogoutUri { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public bool RequirePkce { get; set; }
        public ICollection<string> AllowedScopes { get; set; }
    }
    public class IdentityServerClients
    {
        public ClientSettings[] ClientSettings { get; set; }
    }
}
