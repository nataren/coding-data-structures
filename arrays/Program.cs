using System;

namespace Kata {
    public class ResizableArray<T> {

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

class Driver {
    public static void Main() {
        var sb = new Kata.StringBuilder();
        for(var i = 0; i < 1503; i++) {
            sb.Append("my string" + i.ToString() + "\n");
        }
        Console.WriteLine(sb.ToString());
    }
}
