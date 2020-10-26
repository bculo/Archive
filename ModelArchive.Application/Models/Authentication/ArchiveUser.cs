using ModelArchive.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Models.Authentication
{
    public class ArchiveUser : IArchiveUser
    {
        public string Id { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public ArchiveUser(Guid id, string userName, string email)
        {
            Id = id.ToString();
            UserName = userName ?? throw new ArgumentNullException(userName);
            Email = userName ?? throw new ArgumentNullException(email);
        }
    }
}