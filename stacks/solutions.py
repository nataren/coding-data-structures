class DoubleLinkedList:
    class Node:
        def __init__(self, prev, data, next):
            self.prev = prev
            self.data = data
            self.next = next

    def __init__(self):
        self.head = None

    def add(self, v):
        if not self.head:
            self.head = self.Node(None, v, None)
            return
        current = self.head
        last = None
        while current:
            last = current
            current = current.next
        last.next =  self.Node(last, v, None)

    def add_range(self, *args):
        for arg in args:
            self.add(arg)

    def prepend(self, v):
        new_node = self.Node(None, v, self.head)
        if self.head:
            self.head.prev = new_node
        self.head = new_node

class Stack:
    class Node:
        def __init__(self, data, next):
            self.data = data
            self.next = next

    def __init__(self):
        self.top = None

    def is_empty(self):
        return self.top is None

    def push(self, item):
        new_node = self.Node(item, self.top)
        self.top = new_node

    def pop(self):
        if self.is_empty():
            raise Exception('Empty Stack')
        data = self.top.data
        self.top = self.top.next
        return data

    def peek(self):
        if self.is_empty():
            raise Exception('Empty Stack')
        return self.top.data

