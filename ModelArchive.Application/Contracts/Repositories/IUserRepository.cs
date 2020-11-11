using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidCredentials(string identifier, string password);
        Task<UserQuery> GetArchiveUser(string identifier);
        Task<QueryResult<UserQuery>> AddUser(string userName, string email, string password);
        Task<bool> SetUserLanguage(string userIdentifier, string language);
    }
}
