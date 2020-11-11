
using Microsoft.AspNetCore.Identity;
using ModelArchive.Common;
using ModelArchive.Core.Queries;
using System;
using System.Linq;

namespace ModelArchive.Persistence.Extensions
{
    public static class IdentityResultExtension
    {
        public static QueryResult<T> ToBadResult<T>(this IdentityResult result)
        {
            if (result.Succeeded)
                throw new InvalidOperationException(nameof(result));

            var errors = result.Errors.Select(i => new KeyValueError(i.Code, i.Description));

            return QueryResult.Error<T>(errors);
        } 
    }
}
