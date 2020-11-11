using ModelArchive.Core.Interfaces;
using System;

namespace ModelArchive.Core.Queries
{
    public class UserQuery : IQuery
    {
        public string Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Language { get; set; }

        public UserQuery(Guid id, string userName, string email, string language)
        {
            Id = id.ToString();
            UserName = userName;
            Email = email;
            Language = language;
        }
    }
}
