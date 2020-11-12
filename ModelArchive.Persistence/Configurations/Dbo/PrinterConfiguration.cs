using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations.Dbo
{
    public class PrinterConfiguration : EntityConfiguration<Printer>
    {
        public override void Configure(EntityTypeBuilder<Printer> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(i => i.Model)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasMaxLength(5000);

            builder.HasMany(i => i.PrinterImages)
                .WithOne(v => v.Printer)
                .HasForeignKey(v => v.PrinterId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
