using System.Collections.Generic;

namespace WinFormsClient
{
    public enum HttpMethod { HttpGet, HttpPost };
    public class ResourceEndpoint
    {
        //public string Name { get; set; }
        public string Endpoint { get; set; }
        public HttpMethod Method { get; set; }
    }

    public class SiteSettings
    {
        public string Description { get; set; }
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string RedirectUri { get; set; }
        public string BaseAddress { get; set; }
        public List<ResourceEndpoint> ResourceEndpoints { get; set; }
    }
}
