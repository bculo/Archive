using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelArchive.Application.Contracts;
using ModelArchive.Core.Queries;
using System;
using System.Threading.Tasks;

namespace ModelArchive.Infrastracture.Services
{
    public class IdentityAuthService : IAuthService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public IdentityAuthService(UserManager<IdentityUser<Guid>> userManager,
            SignInManager<IdentityUser<Guid>> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ArchiveUser> Register(string userName, string email, string password)
        {
            var user = new IdentityUser<Guid> { UserName = userName, Email = email };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return new ArchiveUser(user.Id, user.UserName, user.Email);
            }

            throw new Exception();
        }

        public async Task<bool> ValidCredentials(string identifier, string password)
        {
            var user = await GetUserByIdentifier(identifier);

            if (user is null)
                return false;

            return true;
        }

        public async Task<bool> SignIn(string identifier)
        {
            var user = await GetUserByIdentifier(identifier);

            if (user is null)
                return false;

            await _signInManager.SignInAsync(user, new AuthenticationProperties());

            return true;
        }

        private async Task<IdentityUser<Guid>> GetUserByIdentifier(string identifier)
        {
            return await _userManager.Users.SingleOrDefaultAsync(v => v.UserName == identifier);
        }
    }
}
