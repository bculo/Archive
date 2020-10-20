using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public abstract class AuditableEntity : IEntity
    {
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid LastModifiedBy { get; set; }
    }
}
