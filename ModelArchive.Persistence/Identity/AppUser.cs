using Microsoft.AspNetCore.Identity;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string DefaultLanguage { get; set; }

        public ArchiveUser ToArchiveUser()
        {
            return new ArchiveUser(Id, Email, UserName, DefaultLanguage);
        }
    }
}
