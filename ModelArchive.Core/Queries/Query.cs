﻿using ModelArchive.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Core.Queries
{
    public static class Query
    {
        public static Query<TResult> Error<TResult>(string key, string message)
        {
            return new Query<TResult>();
        }

        public static Query<TResult> Success<TResult>(TResult result)
        {
            return new Query<TResult>(result);
        }
    }

    public class Query<TResult> : KeyValueErrorContainer
    {
        public TResult Result { get; set; }

        public Query() : base()
        {

        }

        public Query(TResult result) : base()
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
