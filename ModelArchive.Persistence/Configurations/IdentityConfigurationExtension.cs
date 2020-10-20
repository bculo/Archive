using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations
{
    public static class IdentityConfigurationExtension
    {
        public static void ConfigureIdentity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => entity.ToTable("IdentityUserClaim", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity => entity.ToTable("IdentityRoleClaim", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityUser<Guid>>(entity => entity.ToTable("IdentityUser", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity => entity.ToTable("IdentityUserRole", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityRole<Guid>>(entity => entity.ToTable("IdentityRole", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity => entity.ToTable("IdentityUserToken", SchemaType.Security.ToString()));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => entity.ToTable("IdentityUserLogin", SchemaType.Security.ToString()));
        }
    }
}
