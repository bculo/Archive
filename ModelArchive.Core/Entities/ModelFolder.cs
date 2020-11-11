using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public class ModelFolder : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public ArchiveUser User { get; set; }
        public virtual ICollection<Model3D> Models { get; set; }


        public ModelFolder()
        {
            Models = new HashSet<Model3D>();
        }
    }
}
