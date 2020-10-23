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
            string schemaName = SchemaType.Security.ToString();

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => entity.ToTable("IdentityUserClaim", schemaName));
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity => entity.ToTable("IdentityRoleClaim", schemaName));
            modelBuilder.Entity<IdentityUser<Guid>>(entity => entity.ToTable("IdentityUser", schemaName));
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity => entity.ToTable("IdentityUserRole", schemaName));
            modelBuilder.Entity<IdentityRole<Guid>>(entity => entity.ToTable("IdentityRole", schemaName));
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity => entity.ToTable("IdentityUserToken", schemaName));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => entity.ToTable("IdentityUserLogin", schemaName));
        }
    }
}
