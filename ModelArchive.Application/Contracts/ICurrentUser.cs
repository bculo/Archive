using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Contracts
{
    public interface ICurrentUser
    {
        public Guid UserId { get; }


    }
}
