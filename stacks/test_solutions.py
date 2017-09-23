import pytest

from solutions import Stack
from solutions import DoubleLinkedList

class TestDoubleLinkedList(object):
    def test_add(self):
        dll = DoubleLinkedList()
        n = 7
        dll.add_range(*range(0, n))
        current = dll.head
        for i in range(0, n):
            assert current.data == i
            current = current.next

class TestStack(object):
    def test_push(self):
        stack = Stack()
        for i in range(0, 5):
            stack.push(i)
        for i in range(1, 6):
            top = stack.pop()
            assert top == 5 - i
        assert stack.is_empty()
