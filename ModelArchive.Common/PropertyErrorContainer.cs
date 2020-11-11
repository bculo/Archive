using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelArchive.Common
{
    public class PropertyErrorContainer
    {
        public Dictionary<string, HashSet<string>> Errors { get; }

        public PropertyErrorContainer()
        {
            Errors = new Dictionary<string, HashSet<string>>();
        }

        public void AddPropertyError(string propertyName, string error)
        {
            if(Errors.TryGetValue(propertyName, out HashSet<string> values))
            {
                if (values is null)
                    values = new HashSet<string>();

                values.Add(error);

                return;
            }

            Errors.Add(propertyName, new HashSet<string>(new[] { error }));
        }

        public void AddPropertyErrors(string propertyName, IEnumerable<string> errors)
        {
            if (errors.Count() == 0)
                return;

            Errors.Add(propertyName, new HashSet<string>(errors));
        }

        public bool ContainsError => Errors.Count > 0;
    }
}
