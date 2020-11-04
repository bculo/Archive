using Microsoft.AspNetCore.Http;
using ModelArchive.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModelArchive.WebApi.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        private ClaimsPrincipal ClaimsPrincipal => _accessor.HttpContext?.User;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid UserId
        {
            get
            {
                string userId = ClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

                GuardAgainstNull(userId);

                if (Guid.TryParse(userId, out Guid result))
                    return result;

                throw new InvalidOperationException($"{nameof(userId)} is not GUID");
            }
        }

        public string UserName
        {
            get
            {
                string userName = ClaimsPrincipal.FindFirstValue(ClaimTypes.Name);

                GuardAgainstNull(userName);

                return userName;
            }
        }

        private void GuardAgainstNull(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
        }
    }
}
