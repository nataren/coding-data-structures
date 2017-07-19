using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata {
    public class ResizableArray<T> : IEnumerable<T> {

        // Fields
        private T[] _items;
        private int _inserted;

        // Constructors
        public ResizableArray(int capacity = 10) {
            _items = new T[capacity];
            _inserted = 0;
        }

        public ResizableArray(ResizableArray<T> source, int capacity) {
            _items = new T[capacity];
            _inserted = 0;
            source.Items.CopyTo(_items, 0);
        }

        // Properties
        public int Length { get { return _items.Length; }}
        public T[] Items { get { return _items; }}

        // Methods
        public T this[int index] {
            get {
                return _items[index];
            }
            set {
                _items[index] = value;
            }
        }

        public void Add(T item) {
            if(_inserted + 1 > _items.Length) {
                var doubled = new T[_items.Length * 2];
                _items.CopyTo(doubled, 0);
                _items = null;
                _items = doubled;
            }
            _items[_inserted] = item;
            _inserted++;
        }

        public void Disposable() {}

        public IEnumerator<T> GetEnumerator() {
            return _items.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }
    }

    public class StringBuilder {
        private ResizableArray<string> _items;

        public StringBuilder() {
            _items = new ResizableArray<string>();
        }

        public void Append(string str) {
            _items.Add(str);
        }

        public override string ToString() {
            return string.Join("", _items.Items);
        }
    }
}

public static class Solutions {
    public static string Urlify(string s, int length) {
        var urlified = new char[s.Length];
        for(int i = 0, j = 0; i < length; i++) {
            var c = s[i];
            if(c == ' ') {
                urlified[j] = '%';
                urlified[j+1] = '2';
                urlified[j+2] = '0';
                j += 3;
            } else {
                urlified[j] = c;
                j++;
            }
        }
        return string.Join("", urlified);
    }
}

class Driver {
    public static void Main() {
        /*
        var sb = new Kata.StringBuilder();
        for(var i = 0; i < 1503; i++) {
            sb.Append("my string" + i.ToString() + "\n");
        }
        Console.WriteLine(sb.ToString());
        */

        Console.WriteLine("urlifiy('xyz')={0}", Solutions.Urlify("", 0));
        Console.WriteLine("urlifiy('Mr John Smith    ')={0}", Solutions.Urlify("Mr John Smith    ", 13));
    }
}
