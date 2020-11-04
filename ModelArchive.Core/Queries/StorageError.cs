using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Queries
{
    public class StorageError : KeyValueError
    {
        public StorageError(string key, string value) : base(key, value)
        {
        }
    }
}
