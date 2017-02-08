using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace IdentityServerWithAspNetIdentity.Models
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        private UserManager<ApplicationUser> um;

        public ApplicationSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            um = userManager;
        }

        //public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        //{
        //    return await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        //}

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure, HttpContext httpContext)
        {
            return await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

    }
}
