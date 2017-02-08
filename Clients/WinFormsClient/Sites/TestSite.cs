using System.Collections.Generic;

namespace WinFormsClient
{
    public class TestSite
    {
        public static List<SiteSettings> GetSites()
        {
            return new List<SiteSettings>
            {
                new SiteSettings
                {
                    Description = "Test EXE Client",
                    Authority = "http://localhost:5000",
                    ClientId = "execlient",
                    ClientSecret = "secret",
                    Scope = "openid api1 offline_access",
                    RedirectUri = "http://127.0.0.1:7890/",
                    BaseAddress = "http://localhost:5001/",
                    ResourceEndpoints = new List<ResourceEndpoint>
                    {
                        new ResourceEndpoint
                        {
                            Endpoint = "identity",
                            Method = HttpMethod.HttpGet,
                        },

                        new ResourceEndpoint
                        {
                            Endpoint = "identity/GetWithRole",
                            Method = HttpMethod.HttpGet,
                        },
                    }
                },

            };
        }
    }
}
