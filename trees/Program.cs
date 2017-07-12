using System;

public class Node {
    public int Value;
    public Node[] Children;

    public Node(int value, Node[] children) {
        this.Value = value;
        this.Children = children;
    }
}

public class BinaryTreeNode<T> {
    public T Value;
    public BinaryTreeNode<T> Left;
    public BinaryTreeNode<T> Right;

    public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right) {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }

    public void InOrderTraversal() {
        if(Left != null) {
            Left.InOrderTraversal();
        }
        Visit();
        if(Right != null) {
            Right.InOrderTraversal();
        }
    }

    private void Visit() {
        Console.WriteLine(Value);
    }
}

static class Program {
    static void Main(string[] args) {
        var tree = new Node(10,
                            new Node[] {
                                new Node(5,
                                         new Node[] {
                                             new Node(3, null),
                                             new Node(6, null)
                                         }),
                                new Node(15,
                                         new Node[] {
                                             new Node(11, null),
                                             new Node(16, null)
                                         })
                            });

        var bt = new BinaryTreeNode<int>(
                                                 10,
                                                 new BinaryTreeNode<int>(5, new BinaryTreeNode<int>(3, null, null), new BinaryTreeNode<int>(6, null, null)),
                                                 new BinaryTreeNode<int>(15, new BinaryTreeNode<int>(11, null, null), new BinaryTreeNode<int>(16, null, new BinaryTreeNode<int>(17, null, null))));
        bt.InOrderTraversal();
    }
}

