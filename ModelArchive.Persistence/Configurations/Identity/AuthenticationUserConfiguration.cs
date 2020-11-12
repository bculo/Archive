using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Persistence.Abstracts;
using ModelArchive.Persistence.Identity;
using System;

namespace ModelArchive.Persistence.Configurations.Identity
{
    public class AuthenticationUserConfiguration : IEntityTypeConfiguration<AuthenticationUser>
    {
        public void Configure(EntityTypeBuilder<AuthenticationUser> builder)
        {
            builder.Property(i => i.DefaultLanguage)
                .HasMaxLength(30)
                .HasDefaultValue("en-US")
                .IsRequired();

            builder.HasMany(i => i.UserRoles)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .IsRequired();

            builder.ToTable(name: "IdentityUser", schema: SchemaType.Security.ToString());
        }
    }
}
