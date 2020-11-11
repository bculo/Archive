using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Interfaces
{
    public interface IImage
    {
        string Extension { get; set; }
        string FullName { get; set; }
        string FolderName { get; set; }
    }
}
