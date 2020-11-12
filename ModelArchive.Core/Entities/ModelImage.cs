using ModelArchive.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public class ModelImage : AuditableEntity, IImage
    {
        public Guid Id { get; set; }
        public string Extension { get; set; }
        public string FullName { get; set; }
        public string FolderName { get; set; }
        public Guid ModelId { get; set; }
        public virtual Model3D Model { get; set; }
    }
}
