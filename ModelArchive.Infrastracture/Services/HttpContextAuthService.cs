using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts;
using ModelArchive.Common;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModelArchive.Infrastracture.Services
{
    public class HttpContextAuthService : IAuthService
    {
        private readonly IDateTime _time;
        private readonly IHttpContextAccessor _accessor;

        public HttpContextAuthService(IHttpContextAccessor accessor,
            IDateTime time)
        {
            _time = time;
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
            await CreateCultureCookie(user.Language);
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

            //Delete culture cookie
            _accessor.HttpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
        }

        public Task CreateCultureCookie(string culture)
        {
            _accessor.HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(30)
                }
            );

            return Task.CompletedTask;
        }
    }
}
