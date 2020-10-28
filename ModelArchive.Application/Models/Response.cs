using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelArchive.Application.Models
{
    /// <summary>
    /// Used in handlers
    /// </summary>
    public static class Response
    {
        public static Response<T> Error<T>(string key, string message)
        {
            return new Response<T>();
        }

        public static Response<T> Success<T>(T result)
        {
            return new Response<T>(result);
        }
    }

    public class Response<TResult> : KeyValueErrorContainer
    {
        public TResult Result { get; set; }

        public Response() : base()
        {

        }

        public Response(TResult result) : base()
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
