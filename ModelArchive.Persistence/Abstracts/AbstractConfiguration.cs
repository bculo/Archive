using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModelArchive.Persistence.Abstracts
{
    public abstract class AbstractConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        protected virtual string TableName => typeof(T).Name;
        protected abstract SchemaType GetSchema();

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName, GetSchema().ToString());
        }
    }
}
