using ModelArchive.Core.Enums;
using ModelArchive.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Entities
{
    /// <summary>
    /// Entites that can be modified
    /// </summary>
    public abstract class AuditableEntity : IEntity
    {
        /// <summary>
        /// Modification date
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Entity state
        /// Default is Created 
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.Created;
    }
}
