using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Contracts.Authentication
{
    public interface IArchiveUser
    {
        public string Id { get; }
        public string UserName { get; }
        public string Email { get; }
    }
}
