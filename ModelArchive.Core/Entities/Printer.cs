using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelArchive.Core.Entities
{
    public class Printer : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public ArchiveUser User { get; set; }


        public virtual ICollection<PrinterImage> PrinterImages { get; set; }

        public Printer()
        {
            PrinterImages = new HashSet<PrinterImage>();
        }
    }
}
