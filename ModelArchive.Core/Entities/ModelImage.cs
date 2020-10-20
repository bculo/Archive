using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public class ModelImage : AuditableEntity
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public Guid ModelId { get; set; }
        public virtual Model3D Model { get; set; }
    }
}
