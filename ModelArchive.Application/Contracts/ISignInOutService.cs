using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts
{
    public interface ISignInOutService
    {
        Task SignInAsync(ArchiveUser user);
        Task SignOutAsync();
    }
}
