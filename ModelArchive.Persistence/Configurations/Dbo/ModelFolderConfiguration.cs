using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelArchive.Core.Entities;
using ModelArchive.Persistence.Abstracts;

namespace ModelArchive.Persistence.Configurations.Dbo
{
    public class ModelFolderConfiguration : EntityConfiguration<ModelFolder>
    {
        public override void Configure(EntityTypeBuilder<ModelFolder> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.HasMany(i => i.Models)
                .WithOne(v => v.Folder)
                .HasForeignKey(v => v.FolderId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
