class Queue:
    class Node:
        def __init__(self, data):
            self.data = data
            self.next = None

    def __init__(self):
        self.first = None
        self.last = None

    def add(self, item):
        new_node = self.Node(item)
        if self.last:
            self.last.next = new_node
        self.last = new_node
        if not self.first:
            self.first = self.last

    def remove(self):
        if self.first is None:
            raise Exception('Queue is empty')

        data = self.first.data
        self.first = self.first.next
        if not self.first:
            self.last = None
        return data


    def peek(self):
        if self.first:
            return self.first.data
        raise Exception('No elements to peek')

    def is_empty(self):
        return self.first is None
