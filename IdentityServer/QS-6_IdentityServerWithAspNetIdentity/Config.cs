// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IdentityServerWithAspNetIdentity.Configs;
using IdentityServerWithAspNetIdentity.Configs.Clients;
using IdentityServerWithAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerWithAspNetIdentity
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
                {
                    // Necessary to pass Identity user roles to API
                    UserClaims = {"role"}
                }
                ,
            };
        }

        public static IEnumerable<Client> GetClients(IdentityServerClients clients, string secret)
        {
            List<Client> result = new List<Client>();
            foreach (ClientSettings client in clients.ClientSettings)
            {
                result.Add(Get(client, secret));
            }
            return result;
        }

        public static Client Get(ClientSettings clientSettings, string secret)
        {
            if (clientSettings.AllowedGrantTypes == null)
            {
                clientSettings.AllowedGrantTypes = new List<string>();
            }
            if (clientSettings.AllowedGrantTypes.Count() == 0)
            {
                if (clientSettings.Type == "EXE")
                {
                    clientSettings.AllowedGrantTypes = GrantTypes.Hybrid;
                }
                else
                {
                    clientSettings.AllowedGrantTypes = GrantTypes.HybridAndClientCredentials;
                }
            }

            if (clientSettings.RedirectUris == null)
            {
                clientSettings.RedirectUris = new List<string>();
            }
            if (clientSettings.PostLogoutRedirectUris == null)
            {
                clientSettings.PostLogoutRedirectUris = new List<string>();
            }
            // RedirectUris not specified.  Use the BaseRedirectUris to construct RedirectUris and PostLogoutRedirectUris
            if ((clientSettings.RedirectUris.Count() == 0) && (clientSettings.BaseRedirectUris.Count() > 0))
            {
                foreach (string uri in clientSettings.BaseRedirectUris)
                {
                    string redirectUri = uri;
                    string postLogoutRedirectUri = uri;
                    // Check for and strip trailing "/" to allow for parsing the URI.
                    if (redirectUri.LastIndexOf("/") == redirectUri.Length - 1)
                    {
                        redirectUri = uri.Substring(0, uri.Length-1);
                        postLogoutRedirectUri = uri.Substring(0, uri.Length - 1);
                    }
                    // If EXE, ensure that the Redirect URIs include a port number.
                    if ((clientSettings.Type == "EXE") && (uri.LastIndexOf(":") == uri.IndexOf(":")))
                    {
                        redirectUri += ":7890";
                        postLogoutRedirectUri += ":7890";
                    }
                    else if (clientSettings.Type == "MVC")
                    {
                        redirectUri += "/signin-oidc";
                    }
                    clientSettings.RedirectUris.Add(redirectUri);
                    clientSettings.PostLogoutRedirectUris.Add(postLogoutRedirectUri);
                }
            }

            return new Client
            {
                ClientId = clientSettings.ClientId,
                ClientName = clientSettings.ClientName,
                AllowedGrantTypes = clientSettings.AllowedGrantTypes,

                RequireConsent = false,
                ClientSecrets =
                {
                    new Secret(secret.Sha256())
                },
                RedirectUris = clientSettings.RedirectUris,
                PostLogoutRedirectUris = clientSettings.PostLogoutRedirectUris,
                AllowOfflineAccess = clientSettings.AllowOfflineAccess, 
                // EXE using IdentityModel2 requires PKCE or returns an invalid_grant error.
                RequirePkce = ((clientSettings.RequirePkce) || (clientSettings.Type == "EXE")),
                AllowedScopes = clientSettings.AllowedScopes,
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
            };
        }
    }

    //https://stackoverflow.com/questions/41687659/how-to-add-additional-claims-to-be-included-in-the-access-token-using-asp-net-id
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userTask = _userManager.FindByNameAsync(context.UserName);
            var user = userTask.Result;

            context.Result = new GrantValidationResult(user.Id, "password", null, "local", null);
            return Task.FromResult(context.Result);
        }
    }

    public class AspNetIdentityProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AspNetIdentityProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject;
            if (subject == null) throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(subjectId);
            if (user == null)
                throw new ArgumentException("Invalid subject identifier");

            var claims = await GetClaimsFromUser(user);

            context.IssuedClaims.Add(new Claim(JwtClaimTypes.Email, user.Email));
            var siteIdClaim = claims.SingleOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            if (siteIdClaim == null)
            {
                siteIdClaim = claims.SingleOrDefault(x => x.Type == "email");
            }
            if (siteIdClaim != null)
            {
                context.IssuedClaims.Add(new Claim("siteid", siteIdClaim.Value));
            }
            //context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, "User"));

            var roleClaims = claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            if ((roleClaims == null) || (roleClaims.Count() == 0))
            {
                roleClaims = claims.Where(x => x.Type == "role");
            }
            foreach (var roleClaim in roleClaims)
            {
                context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, roleClaim.Value));
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject;
            if (subject == null) throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(subjectId);

            context.IsActive = false;

            if (user != null)
            {
                if (_userManager.SupportsUserSecurityStamp)
                {
                    var security_stamp = subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault();
                    if (security_stamp != null)
                    {
                        var db_security_stamp = await _userManager.GetSecurityStampAsync(user);
                        if (db_security_stamp != security_stamp)
                            return;
                    }
                }

                context.IsActive =
                    !user.LockoutEnabled ||
                    !user.LockoutEnd.HasValue ||
                    user.LockoutEnd <= DateTime.Now;
            }
        }

        private async Task<IEnumerable<Claim>> GetClaimsFromUser(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName)
            };

            if (_userManager.SupportsUserEmail)
            {
                claims.AddRange(new[]
                {
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
            });
            }

            if (_userManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.AddRange(new[]
                {
                new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
            });
            }

            if (_userManager.SupportsUserClaim)
            {
                claims.AddRange(await _userManager.GetClaimsAsync(user));
            }

            if (_userManager.SupportsUserRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(role => new Claim(JwtClaimTypes.Role, role)));
            }

            return claims;
        }
    }

}