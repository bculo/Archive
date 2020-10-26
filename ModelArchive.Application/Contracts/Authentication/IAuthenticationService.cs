using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        Task<IArchiveUser> Register(string userName, string email, string password);
    }
}
