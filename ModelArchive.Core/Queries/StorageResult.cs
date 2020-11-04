using ModelArchive.Common;
using System;
using System.Collections.Generic;

namespace ModelArchive.Core.Queries
{
    public static class StorageResult
    {
        public static StorageResult<TResult> Error<TResult>(string key, string message)
        {
            return Error<TResult>(new KeyValueError(key, message));
        }

        public static StorageResult<TResult> Error<TResult>(KeyValueError error)
        {
            var result = new StorageResult<TResult>();
            result.AddError(error);
            return result;
        }

        public static StorageResult<TResult> Error<TResult>(IEnumerable<KeyValueError> errors)
        {
            var result = new StorageResult<TResult>();
            result.AddErrors(errors);
            return result;
        }

        public static StorageResult<TResult> Success<TResult>(TResult result)
        {
            return new StorageResult<TResult>(result);
        }
    }

    public class StorageResult<TResult> : KeyValueErrorContainer
    {
        public TResult Result { get; set; }

        public StorageResult() : base()
        {

        }

        public StorageResult(TResult result) : base()
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
