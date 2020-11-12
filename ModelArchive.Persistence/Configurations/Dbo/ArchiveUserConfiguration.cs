using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations.Dbo
{
    public class ArchiveUserConfiguration : EntityConfiguration<ArchiveUser>
    {
        public override void Configure(EntityTypeBuilder<ArchiveUser> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(i => i.UserName)
                .IsUnique();

            builder.Property(v => v.IdentityId)
                .IsRequired();

            builder.HasIndex(i => i.IdentityId)
                .IsUnique();

            builder.HasMany(v => v.Printers)
                .WithOne(v => v.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(v => v.Folders)
                .WithOne(v => v.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
