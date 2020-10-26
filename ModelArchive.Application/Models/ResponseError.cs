using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Models
{
    public class ResponseError
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public ResponseError(string key, string message)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}
