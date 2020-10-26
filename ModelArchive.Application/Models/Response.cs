using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModelArchive.Application.Models
{
    public static class Response
    {
        public static Response<T> Error<T>(string key, string message)
        {
            return new Response<T>();
        }

        public static Response<T> Success<T>(T result)
        {
            return new Response<T>(result)
        }
    }

    public class Response<T>
    {
        public T Result { get; set; }

        public List<ResponseError> Errors { get; set; }

        public bool Success => Errors?.Count == 0;

        public Response()
        {
            Errors = new List<ResponseError>();
        }

        public Response(T result) : this()
        {
            Result = result;
        }

        public Response<T> AddError(string key, string message)
        {
            Errors.Add(new ResponseError(key, message));
            return this;
        }

        public Response<T> AddError(ResponseError error)
        {
            Errors.Add(error);
            return this;
        }
    }
}
