using ModelArchive.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelArchive.Core.Entities
{
    public class ArchiveUser : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Guid IdentityId { get; set; }

        public virtual ICollection<ModelFolder> Folders { get; set; }
        public virtual ICollection<Printer> Printers { get; set; }

        public ArchiveUser()
        {
            Folders = new HashSet<ModelFolder>();
            Printers = new HashSet<Printer>();
        }
    }
}
