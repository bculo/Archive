using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts
{
    public interface IAuthService
    {
        Task<ArchiveUser> Register(string userName, string email, string password);
        Task<bool> ValidCredentials(string identifier, string password);
        Task<bool> SignIn(string identifier);
    }
}
