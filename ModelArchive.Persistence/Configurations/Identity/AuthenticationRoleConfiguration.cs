using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Application.Constants;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;
using ModelArchive.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations.Identity
{
    public class AuthenticationRoleConfiguration : IdentityConfiguration<AuthenticationRole>
    {
        public override void Configure(EntityTypeBuilder<AuthenticationRole> builder)
        {
            builder.HasMany(i => i.UserRoles)
                .WithOne(i => i.Role)
                .HasForeignKey(i => i.RoleId)
                .IsRequired();

            builder.HasData(new AuthenticationRole[]
            {
                new AuthenticationRole { Name = ArchiveRole.ADMIN },
                new AuthenticationRole { Name = ArchiveRole.USER },
            });

            base.Configure(builder);
        }
    }
}
