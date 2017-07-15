import pytest

from solutions import contains_duplicates

class TestArraySolutions(object):
    def test_does_not_contains_on_empty_string(self):
        assert not contains_duplicates("")

    def test_does_not_contains_duplicates(self):
        assert not contains_duplicates("abcde")

    def test_contains_duplicates(self):
        assert contains_duplicates("abcdea")

    def test_contains_duplicates_side_by_side(self):
        assert contains_duplicates("aa")

    def test_contains_duplicates_at_the_end(self):
        assert contains_duplicates("abcdexyza")

    def test_contains_duplicates_in_the_middle(self):
        assert contains_duplicates("abcdefgaxyz")
