using ModelArchive.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public class Model3D : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public ModelType ModelType { get; set; }
        public string Description { get; set; }
        public Guid FolderId { get; set; }
        public virtual ModelFolder Folder { get; set; }
        public virtual ICollection<ModelImage> Images { get; set; }

        public Model3D()
        {
            Images = new HashSet<ModelImage>();
        }
    }
}
