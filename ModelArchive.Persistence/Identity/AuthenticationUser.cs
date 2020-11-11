using Microsoft.AspNetCore.Identity;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Identity
{
    public class AuthenticationUser : IdentityUser<Guid>
    {
        public string DefaultLanguage { get; set; }
        public virtual ICollection<AuthenticationUserRole> UserRoles { get; set; }

        public AuthenticationUser()
        {
            UserRoles = new HashSet<AuthenticationUserRole>();
        }

        public UserQuery ToQueryResult()
        {
            return new UserQuery(Id, Email, UserName, DefaultLanguage);
        }
    }
}

