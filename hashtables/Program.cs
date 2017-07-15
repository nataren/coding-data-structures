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
            if(_inserted + 1 >= _buckets.Length) {
                var newArray = new ResizableArray<LinkedList<KeyPair<TKey, TValue>>>(_buckets, _buckets.Length * 2);
                _buckets = newArray;
            }
            var i = Hash(key) % _buckets.Length;
            Console.WriteLine($"key={key}, Hash(key)={Hash(key)}, buckets.Length={_buckets.Length}, i={i}");
            var bucketList = _buckets[i];
            if(bucketList == null) {
                bucketList = new LinkedList<KeyPair<TKey, TValue>>();
                _buckets[i] = bucketList;
            }

            // TODO: Handle duplicates
            bucketList.Add(new Node<KeyPair<TKey, TValue>>(new KeyPair<TKey, TValue>(key, value)));
            _inserted++;
        }

        public void Remove(TKey key) {
            throw new NotImplementedException();
        }

        public bool TryFind(TKey key, out TValue value) {
            var i = Hash(key) % _buckets.Length;
            var node = _buckets[i].Find(new KeyPair<TKey, TValue>(key, default(TValue)));
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
            var dict = new HashTable<string, int>(3);
            dict.Add("keynumberone", 1);
            dict.Add("keynumbertwo", 2);
            dict.Add("keynumberthree", 3);

            Find<string, int>(dict, "keynumberthree");
        }

        static void Find<K, V>(HashTable<K, V> dict, K key) {
            V result;
            Console.WriteLine("Found `{0}`? {1}, value=`{2}`", key, dict.TryFind(key, out result), result);
        }
    }
}
