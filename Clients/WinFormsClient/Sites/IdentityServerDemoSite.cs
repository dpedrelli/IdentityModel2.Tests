using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    class IdentityServerDemoSite
    {
        public static List<SiteSettings> GetSites()
        {
            return new List<SiteSettings>
            {
                new SiteSettings {
                    Description = "IS Demo native.hybrid",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "native.hybrid",
                    ClientSecret = "",
                    Scope = "openid email api offline_access",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }
                        
                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo native.code",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "native.code",
                    ClientSecret = "",
                    Scope = "openid profile email api offline_access",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo server.hybrid",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "server.hybrid",
                    ClientSecret = "secret",
                    Scope = "openid profile email api offline_access",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo server.code",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "server.code",
                    ClientSecret = "secret",
                    Scope = "openid profile email api offline_access",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo implicit",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "implicit",
                    ClientSecret = "",
                    Scope = "openid profile email api",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo implicit.reference",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "implicit.reference",
                    ClientSecret = "",
                    Scope = "openid profile email api",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo implicit.shortlived",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "implicit.shortlived",
                    ClientSecret = "",
                    Scope = "openid profile email api",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },

                new SiteSettings
                {
                    Description = "IS Demo client",
                    Authority = "https://demo.identityserver.io",
                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "openid profile email api",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "https://api.identityserver.io",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        }

                    }
                },
            };
        }
    }
}
