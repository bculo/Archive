using ModelArchive.Common;
using ModelArchive.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ModelArchive.Core.Queries
{
    public static class QueryResult
    {
        public static QueryResult<TResult> Error<TResult>(string key, string message)
        {
            return Error<TResult>(new KeyValueError(key, message));
        }

        public static QueryResult<TResult> Error<TResult>(KeyValueError error)
        {
            var result = new QueryResult<TResult>();
            result.AddError(error);
            return result;
        }

        public static QueryResult<TResult> Error<TResult>(IEnumerable<KeyValueError> errors)
        {
            var result = new QueryResult<TResult>();
            result.AddErrors(errors);
            return result;
        }

        public static QueryResult<TResult> Success<TResult>(TResult result)
        {
            return new QueryResult<TResult>(result);
        }
    }

    public class QueryResult<TResult> : KeyValueErrorContainer
    {
        public TResult Result { get; set; }

        public QueryResult() : base()
        {

        }

        public QueryResult(TResult result) : base()
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
