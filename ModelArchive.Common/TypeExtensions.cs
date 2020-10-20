using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModelArchive.Common
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetNonAstractTypes(this IEnumerable<Type> types, Type assignableTo = null)
        {
            return types.Where(type => !type.IsAbstract && assignableTo.IsAssignableFrom(type) && !type.IsInterface);
        }
    }
}
