using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModelArchive.Persistence.Abstracts
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        protected virtual string TableName => typeof(T).Name;

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName, GetSchema().ToString());
        }

        protected virtual SchemaType GetSchema()
        {
            return SchemaType.Dbo;
        }
    }
}
