using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Identity
{
    public class AuthenticationUserRole : IdentityUserRole<Guid>
    {
        public virtual AuthenticationUser User { get; set; }
        public virtual AuthenticationRole Role { get; set; }
    }
}
