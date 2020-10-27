using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Queries
{
    public class QueryError : KeyValue
    {
        public QueryError(string key, string value) : base(key, value)
        {
        }
    }
}
