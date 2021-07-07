using System.Collections;
using System.Collections.Generic;

namespace CustomSerializator.Utilities
{
    public class JsonDictionary<TKey, TValue> : IEnumerable
    {
        public Dictionary<TKey, TValue> _dictionary;

        public JsonDictionary()
        {
            _dictionary = new();
        }

        public void Add(TKey key, TValue value)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key] = value;
            }
            else
            {
                _dictionary.Add(key, value);
            }
        }

        public TValue Get(TKey key)
        {
            TValue result = default;

            if (_dictionary.ContainsKey(key))
            {
                result = _dictionary[key];
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return _dictionary.Keys.GetEnumerator();
        }

        public TValue this[TKey index]
        {
            set { _dictionary[index] = value; }
            get { return _dictionary[index]; }
        }

    }
}
