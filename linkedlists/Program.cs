using System;
using System.Collections.Generic;

//--- Types ---
public class Node<T> {
    public T Value;
    public Node<T> Next;

    public Node(T value) {
        this.Value = value;
    }

    public override bool Equals(object obj) {
        if(obj == null) {
            return false;
        }
        var other = obj as Node<T>;
        EqualityComparer<T> c = EqualityComparer<T>.Default;
        return c.Equals(Value, other.Value);
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }
}

public class LinkedList<T> {

    //--- Fields ---
    private Node<T> Head;
    private Node<T> Tail;

    //--- Properties ---
    public int Length { get; private set; }

    //--- Methods ---
    public void Add(Node<T> node) {
        if(Head == null) {
            Head = node;
            Tail = Head;
        } else {
            Tail.Next = node;
            Tail = node;
        }
        Length++;
    }

   public bool Remove(Node<T> node) {
        var current = Head;
        Node<T> prev = null;
        while(current != null) {
            if(Object.ReferenceEquals(current, node)) {
                if(prev != null) {
                    prev.Next = current.Next;
                } else {
                    Head = current.Next;
                }
                current  = null;
                Length--;
                return true;
            }
            prev = current;
            current  = current.Next;
        }
        return false;
    }

    public Node<T> Find(T value) {
        EqualityComparer<T> c = EqualityComparer<T>.Default;
        var current = Head;
        while(current != null) {
            if(c.Equals(value, current.Value)) {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public void PrintAll() {
        var elements = new T[Length];
        var current = Head;
        var i = 0;
        while(current != null) {
            elements[i++] = current.Value;
            current = current.Next;
        }
        Console.WriteLine("Length={0}, Elements=[{1}]", Length, String.Join(", ", elements));
    }
}

public static class Driver {
    public static void Main() {
        var l = new LinkedList<int>();
        for(var i = 0; i < 5; i++) {
            l.Add(new Node<int>(i));
        }
        var currentLength = l.Length;
        if(currentLength <= 0) {
            return;
        }
        l.PrintAll();
    }
}
