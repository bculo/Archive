using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Queries
{
    public class QueryError : KeyValueError
    {
        public QueryError(string key, string value) : base(key, value)
        {
        }
    }
}
