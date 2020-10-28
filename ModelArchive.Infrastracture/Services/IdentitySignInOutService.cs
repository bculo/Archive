using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ModelArchive.Application.Contracts;
using ModelArchive.Core.Queries;
using ModelArchive.Persistence.Identity;
using System;
using System.Threading.Tasks;

namespace ModelArchive.Infrastracture.Services
{
    public class IdentitySignInOutService : ISignInOutService
    {
        private readonly UserManager<AppUser> _userRepo;
        private readonly SignInManager<AppUser> _signInManager;

        public IdentitySignInOutService(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userRepo)
        {
            _userRepo = userRepo;
            _signInManager = signInManager;
        }

        public async Task SignInAsync(ArchiveUser user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            //we need IdentityUser instance for SignInManager
            var identityUser = await _userRepo.FindByIdAsync(user.Id);

            await _signInManager.SignInAsync(identityUser, new AuthenticationProperties());
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
