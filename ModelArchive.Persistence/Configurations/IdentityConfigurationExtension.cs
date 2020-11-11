using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelArchive.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations
{
    public static class IdentityConfigurationExtension
    {
        public static void ConfigureIdentity(this ModelBuilder modelBuilder)
        {
            string schemaName = SchemaType.Security.ToString();

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => entity.ToTable("IdentityUserClaim", schemaName));
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity => entity.ToTable("IdentityRoleClaim", schemaName));
            modelBuilder.Entity<AuthenticationUser>(entity => entity.ToTable("IdentityUser", schemaName));
            modelBuilder.Entity<AuthenticationUserRole>(entity => entity.ToTable("IdentityUserRole", schemaName));
            modelBuilder.Entity<AuthenticationRole>(entity => entity.ToTable("IdentityRole", schemaName));
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity => entity.ToTable("IdentityUserToken", schemaName));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => entity.ToTable("IdentityUserLogin", schemaName));
        }
    }
}
