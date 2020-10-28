using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Core.Queries;
using ModelArchive.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModelArchive.Infrastracture.Services
{
    public class SignInOutService : ISignInOutService
    {
        private readonly IHttpContextAccessor _accessor;

        public SignInOutService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task SignInAsync(ArchiveUser user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var claims = PrepareClaims(user);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            
        }

        private List<Claim> PrepareClaims(ArchiveUser user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };
        }

        public async Task SignOutAsync()
        {
            await _accessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
