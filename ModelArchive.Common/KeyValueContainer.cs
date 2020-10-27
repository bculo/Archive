using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Common
{
    public abstract class KeyValueContainer<TResult>
    {
        public TResult Result { get; set; }

        public List<KeyValue> Errors { get; set; }

        public bool Success => Errors.Count == 0;

        public KeyValueContainer()
        {
            Errors = new List<KeyValue>();
        }

        public KeyValueContainer(TResult result) : base()
        {
            Result = result;
        }

        public void AddError(string key, string value)
        {
            Errors.Add(new KeyValue(key, value));
        }

        public void AddError(KeyValue error)
        {
            Errors.Add(error);
        }
    }
}
