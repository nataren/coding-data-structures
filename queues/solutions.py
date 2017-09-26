class Queue:
    class Node:
        def __init__(self, data):
            self.data = data
            self.next = None

    def __init__(self):
        self.first = None
        self.last = None

    def add(self, item):
        new_node = Node(item)
        if self.last:
            self.last.next = new_node
        self.last = new_node

    def remove(self):
        if self.first is None:
            raise Exception('Queue is empty')

        current_first = self.first
        current_data = current_first.data
        self.first = current_first.next

        if self.first is None:
            self.last = None

        return current_data

    def peek(self):
        if self.first:
            return self.first.data
        raise Exception('No elements to peek')

    def is_empty(self):
        return self.first is None
