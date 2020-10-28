using Microsoft.AspNetCore.Identity;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Core.Queries;
using ModelArchive.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ArchiveUser> GetArchiveUser(string identifier)
        {
            var appUser = await GetAppUserByIdentifier(identifier);

            if (appUser is null)
                return null;

            return appUser.ToArchiveUser();
        }

        public Task<ArchiveUser> AddUser(string userName, string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetUserLanguage(string userIdentifier, string language)
        {
            var appUser = await GetAppUserByIdentifier(userIdentifier);

            if (appUser is null)
                return false;

            appUser.DefaultLanguage = language;

            var updateResult = await _userManager.UpdateAsync(appUser);

            if (updateResult.Succeeded)
                return true;

            return false;
        }

        public async Task<bool> ValidCredentials(string identifier, string password)
        {
            var appUser = await GetAppUserByIdentifier(identifier);

            if (appUser is null)
                return false;

            return await _userManager.CheckPasswordAsync(appUser, password);
        }

        protected async Task<AppUser> GetAppUserByIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                return null;

            if (identifier.Contains("@"))
                return await _userManager.FindByEmailAsync(identifier);
            else
                return await _userManager.FindByNameAsync(identifier);
        }
    }
}
