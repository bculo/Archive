using ModelArchive.Core.Queries;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts
{
    public interface IAuthService
    {
        Task CreateCultureCookie(string culture);
        Task SignInAsync(ArchiveUser user);
        Task SignOutAsync();
    }
}
