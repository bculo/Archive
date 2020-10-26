using Microsoft.AspNetCore.Identity;
using ModelArchive.Application.Contracts.Authentication;
using ModelArchive.Application.Models;
using ModelArchive.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Infrastracture.Identity
{
    public class IIdentityAuthentication : IAuthenticationService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public IIdentityAuthentication(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IArchiveUser> Register(string userName, string email, string password)
        {
            var newUser = new IdentityUser<Guid> { Email = email, UserName = userName };

            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
                return new ArchiveUser(newUser.Id, newUser.UserName, newUser.Email);

            throw new NotImplementedException();
        }
    }
}
