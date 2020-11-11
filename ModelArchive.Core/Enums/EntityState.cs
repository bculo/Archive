using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModelArchive.Core.Enums
{
    public enum EntityState
    {
        [Description("New entity created")]
        Created = 0,

        [Description("Entity updated")]
        Updated = 1,

        [Description("Entity deleted")]
        Deleted = 2
    }
}
