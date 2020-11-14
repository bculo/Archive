using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Core.Entities;
using ModelArchive.Core.Queries;
using ModelArchive.Persistence.Extensions;
using ModelArchive.Persistence.Identity;
using System.Threading.Tasks;

namespace ModelArchive.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AuthenticationUser> _userManager;
        private readonly RoleOptions _options;
        private readonly ArchiveDbContext _dbContext;

        public UserRepository(UserManager<AuthenticationUser> userManager,
            IOptions<RoleOptions> options,
            ArchiveDbContext dbContext)
        {
            _userManager = userManager;
            _options = options.Value;
            _dbContext = dbContext;
        }

        public async Task<UserQuery> GetArchiveUser(string identifier)
        {
            var appUser = await GetAppUserByIdentifier(identifier);

            if (appUser is null)
                return null;

            return appUser.ToQueryResult();
        }

        public async Task<QueryResult<UserQuery>> AddUser(string userName, string email, string password)
        {
            AuthenticationUser newUserInstance = new AuthenticationUser { UserName = userName, Email = email };

            //add user to identity table
            var identityResult = await _userManager.CreateAsync(newUserInstance, password);

            if (!identityResult.Succeeded)
            {
                return identityResult.ToBadResult<UserQuery>();
            }

            //add user to role
            identityResult = await _userManager.AddToRoleAsync(newUserInstance, _options.DefaultRole);

            if (!identityResult.Succeeded)
            {
                return identityResult.ToBadResult<UserQuery>();
            }

            //add user to domain table
            var newArchiveUser = new ArchiveUser
            {
                UserName = newUserInstance.UserName,
                IdentityId = newUserInstance.Id,
            };

            _dbContext.ArchiveUsers.Add(newArchiveUser);

            await _dbContext.SaveChangesAsync();

            return QueryResult.Success(newUserInstance.ToQueryResult());
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

        protected async Task<AuthenticationUser> GetAppUserByIdentifier(string identifier)
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
