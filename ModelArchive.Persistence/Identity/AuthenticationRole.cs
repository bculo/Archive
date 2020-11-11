using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Identity
{
    public class AuthenticationRole : IdentityRole<Guid>
    {
        public virtual ICollection<AuthenticationUserRole> UserRoles { get; set; }

        public AuthenticationRole()
        {
            UserRoles = new HashSet<AuthenticationUserRole>();
        }
    }
}
