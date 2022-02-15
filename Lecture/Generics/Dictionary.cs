namespace Lecture8Generics
{
    public class Dictionary<TKey,TValue> 
        where TKey : notnull 
        where TValue : class
    {
        private List<KeyValuePair<TKey,TValue>> _List = new();
        public void Add(TKey key,TValue value)
        {
            if (KeyExists(key)) { throw new ArgumentException("key already exists"); }
            _List.Add(new KeyValuePair<TKey,TValue>(key, value));
        }

        public TValue this[TKey key]
        {
            get
            {
                foreach (var kvp in _List)
                {
                    if (key.Equals(kvp.Key))
                    {
                        return kvp.Value;
                    }
                }
                throw new KeyNotFoundException($"{key} not in dictionary");
            }
            set
            {
                // see if exists
                if (KeyExists(key)) {
                    // find kvp
                    Remove(key);
                }
                Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            foreach (var kvp in _List)
            {
                if (key.Equals(kvp.Key))
                {
                    _List.Remove(kvp);
                    return;
                }
            }
            throw new KeyNotFoundException($"{key} not in dictionary");
        }

        public bool KeyExists(TKey key)
        {
            foreach (var kvp in _List)
            {
                if (key.Equals(kvp.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public int Count { get { return _List.Count; } }
    }
}