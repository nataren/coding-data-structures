class Queue:
    class Node:
        def __init__(self, data, next):
            self.data = data
            self.next = next

    def __init__(self):
        self.first = None
        self.last = None

    def add(self, item):
        pass

    def remove(self):
        pass

    def peek(self):
        pass

    def is_empty(self):
        return self.first is None
