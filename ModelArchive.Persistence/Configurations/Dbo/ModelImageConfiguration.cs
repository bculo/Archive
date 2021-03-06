﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence.Configurations.Dbo
{
    class ModelImageConfiguration : EntityConfiguration<ModelImage>
    {
        public override void Configure(EntityTypeBuilder<ModelImage> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Ignore(i => i.Extension);

            builder.Property(v => v.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.FolderName)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
