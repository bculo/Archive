using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Models
{
    public class ResponseError : KeyValueError
    {
        public ResponseError(string key, string value) : base(key, value)
        {
        }
    }
}
