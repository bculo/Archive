using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModelArchive.Core.Enums
{
    public enum ImageType
    {
        [Description("Portable Network Graphics")]
        PNG = 0,

        [Description("Joint Photographic Experts Group")]
        JPEG = 1
    }
}
