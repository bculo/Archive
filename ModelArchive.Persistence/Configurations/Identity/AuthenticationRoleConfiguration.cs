using Microsoft.EntityFrameworkCore;
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
    
    public class AuthenticationRoleConfiguration : IEntityTypeConfiguration<AuthenticationRole>
    {
        public void Configure(EntityTypeBuilder<AuthenticationRole> builder)
        {
            builder.HasMany(i => i.UserRoles)
                .WithOne(i => i.Role)
                .HasForeignKey(i => i.RoleId)
                .IsRequired();

            builder.HasData(new AuthenticationRole[]
            {
                new AuthenticationRole 
                {
                    Id = Guid.NewGuid(),
                    Name = ArchiveRole.ADMIN, 
                    NormalizedName =  ArchiveRole.ADMIN.ToUpper()
                },
                new AuthenticationRole 
                { 
                    Id = Guid.NewGuid(), 
                    Name = ArchiveRole.USER, 
                    NormalizedName =  ArchiveRole.USER.ToUpper() 
                }
            });

            builder.ToTable(name: "IdentityRole", schema: SchemaType.Security.ToString());
        }
    }
    
}
