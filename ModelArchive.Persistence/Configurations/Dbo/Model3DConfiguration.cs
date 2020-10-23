using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations.Dbo
{
    public class Model3DConfiguration : EntityConfiguration<Model3D>
    {
        public override void Configure(EntityTypeBuilder<Model3D> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.FileName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.Description)
                .HasMaxLength(5000);

            builder.HasMany(v => v.Images)
                .WithOne(v => v.Model)
                .HasForeignKey(t => t.ModelId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
