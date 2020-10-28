using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Persistence.Abstracts;
using ModelArchive.Persistence.Identity;
using System;

namespace ModelArchive.Persistence.Configurations.Identity
{
    public class AppUserConfiguration : IdentityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.DefaultLanguage)
                .HasMaxLength(30)
                .HasDefaultValue("en-US")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
