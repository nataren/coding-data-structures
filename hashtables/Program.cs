using System;
using System.Collections.Generic;

namespace Kata {
    interface IHashTable<TKey, TValue> {
        void Add(TKey key, TValue value);
        void Remove(TKey key);
        bool TryFind(TKey k, out TValue v);
    }

    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue> {

        // Internal Types
        private struct KeyPair<Tkey, Tvalue> {
            public Tkey Key;
            public Tvalue Value;

            public KeyPair(Tkey key, Tvalue value) {
                this.Key = key;
                this.Value = value;
            }

            public override bool Equals(object obj) {
                if(obj  == null) {
                    return false;
                }
                if(obj is KeyPair<Tkey, Tvalue>) {
                    var other = (KeyPair<Tkey, Tvalue>)obj;
                    EqualityComparer<Tkey> c = EqualityComparer<Tkey>.Default;
                    return c.Equals(Key, other.Key);
                }
                return false;
            }

            public override int GetHashCode() {
                return Key.GetHashCode() ^ Value.GetHashCode();
            }
        }

        // Fields
        private ResizableArray<LinkedList<KeyPair<TKey, TValue>>> _buckets;
        private int _inserted;

        // Constructors
        public HashTable(int capacity) {
            _buckets = new ResizableArray<LinkedList<KeyPair<TKey, TValue>>>(capacity);
        }

        // Methods
        private int Hash(TKey key) {
            return Math.Abs(key.GetHashCode());
        }

        public void Add(TKey key, TValue value) {
            if(_inserted + 1 > _buckets.Length) {
                var newArray = new ResizableArray<LinkedList<KeyPair<TKey, TValue>>>(_buckets.Length * 2);
                var keyPairsToRehash = new List<KeyPair<TKey, TValue>>();
                foreach(var bucket in _buckets) {
                    if(bucket == null) {
                        continue;
                    }
                    foreach(KeyPair<TKey, TValue> pair in bucket) {
                        keyPairsToRehash.Add(pair);
                    }
                }
                _buckets = newArray;

                // Add them back in
                foreach(var pair in keyPairsToRehash) {
                    AddHelper(pair.Key, pair.Value);
                }
            }
            AddHelper(key, value);
        }

        private void AddHelper(TKey key, TValue value) {
            var i = Hash(key) % _buckets.Length;
            var bucket = _buckets[i];
            if(bucket == null) {
                bucket = new LinkedList<KeyPair<TKey, TValue>>();
                _buckets[i] = bucket;
            }

            // TODO: Handle duplicates
            bucket.Add(new Node<KeyPair<TKey, TValue>>(new KeyPair<TKey, TValue>(key, value)));
            _inserted++;
        }

        public void Remove(TKey key) {
            throw new NotImplementedException();
        }

        public bool TryFind(TKey key, out TValue value) {
            var hash = Hash(key);
            var i = hash % _buckets.Length;
            var bucket =  _buckets[i];
            if(bucket == null) {
                bucket = new LinkedList<KeyPair<TKey, TValue>>();
                _buckets[i] = bucket;
            }
            var node = bucket.Find(new KeyPair<TKey, TValue>(key, default(TValue)));
            if(node != null) {
                value = node.Value.Value;
                return true;
            }
            value = default(TValue);
            return false;
        }
    }

    class Program {
        static void Main(string[] args) {
            var dict = new HashTable<string, int>(100);
            var COUNT = 12345;
            for(var i = 0; i < COUNT; i++) {
                dict.Add("key" + i.ToString(), i);
            }
            for(var i = COUNT - 1; i >= 0; i--) {
                Find<string, int>(dict, "key" + i.ToString());
            }
        }

        static void Find<K, V>(HashTable<K, V> dict, K key) {
            V result;
            var found = dict.TryFind(key, out result);
        }
    }
}
