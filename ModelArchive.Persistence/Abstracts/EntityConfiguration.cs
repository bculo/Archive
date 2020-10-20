namespace ModelArchive.Persistence.Abstracts
{
    public abstract class EntityConfiguration<T> : AbstractConfiguration<T> where T : class
    {
        protected override SchemaType GetSchema()
        {
            return SchemaType.Dbo;
        }
    }
}
