using System;
using System.Linq;
using System.Collections.Generic;

public class BinaryTreeNode<T> {
    public T Value;
    public BinaryTreeNode<T> Left;
    public BinaryTreeNode<T> Right;

    public BinaryTreeNode(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null) {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }

    public IEnumerable<T> InOrderTraversal() {
        if(Left != null) {
            foreach(var node in Left.InOrderTraversal()) {
                yield return node;
            }
        }
        yield return Visit();
        if(Right != null) {
            foreach(var node in Right.InOrderTraversal()) {
                yield return node;
            }
        }
    }

    public IEnumerable<T> PreOrderTraversal() {
        yield return Visit();
        if(Left != null) {
            foreach(var node in  Left.PreOrderTraversal()) {
                yield return node;
            }
        }
        if(Right != null) {
            foreach(var node in Right.PreOrderTraversal()) {
                yield return node;
            }
        }
    }

    public IEnumerable<T> PostOrderTraversal() {
        if(Left != null) {
            foreach(var node in Left.PostOrderTraversal()) {
                yield return node;
            }
        }
        if(Right != null) {
            foreach(var node in Right.PostOrderTraversal()) {
                yield return node;
            }
        }
        yield return Visit();
    }

    private T Visit() {
        return Value;
    }
}

static class Program {
    static void Main(string[] args) {
        var bt = new BinaryTreeNode<int>(10,
                                         new BinaryTreeNode<int>(5, new BinaryTreeNode<int>(3), new BinaryTreeNode<int>(6)),
                                         new BinaryTreeNode<int>(15, new BinaryTreeNode<int>(11), new BinaryTreeNode<int>(16, null, new BinaryTreeNode<int>(17))));

        Console.WriteLine("InOrder=[{0}]", string.Join(", ", bt.InOrderTraversal().ToArray()));
        Console.WriteLine("PreOrder=[{0}]", string.Join(", ", bt.PreOrderTraversal().ToArray()));
        Console.WriteLine("PostOrder=[{0}]", string.Join(", ", bt.PostOrderTraversal().ToArray()));
    }
}

