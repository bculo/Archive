namespace ModelArchive.Persistence.Abstracts
{
    public class IdentityConfiguration<T> : AbstractConfiguration<T> where T : class
    {
        protected override SchemaType GetSchema()
        {
            return SchemaType.Security;
        }
    }
}
