using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelArchive.Common
{
    public static class EnumerableExtension
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        {
            if (self is null)
                throw new ArgumentNullException(nameof(self));

            return self.Select((item, index) => (item, index));
        }
    }
}
