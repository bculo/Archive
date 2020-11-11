using ModelArchive.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    public class PrinterImage : AuditableEntity, IImage
    {
        public string Extension { get; set; }
        public string FullName { get; set; }
        public string FolderName { get; set; }
        public Guid PrinterId { get; set; }
        public virtual Printer Printer { get; set; }
    }
}
