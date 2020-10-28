using System;

namespace ModelArchive.Common
{
    public class KeyValueError
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public KeyValueError(string key, string value)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
