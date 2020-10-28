using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelArchive.Common
{
    public abstract class KeyValueErrorContainer
    {
        public List<KeyValueError> Errors { get; set; }

        public bool Success => Errors.Count == 0;

        public KeyValueErrorContainer()
        {
            Errors = new List<KeyValueError>();
        }

        public void AddError(KeyValueError error)
        {
            Errors.Add(error);
        }

        public IReadOnlyDictionary<string, string> ToDictionary()
        {
            if (Success)
                return new Dictionary<string, string>();

            return Errors.ToDictionary(error => error.Key, error => error.Value);
        }
    }
}
