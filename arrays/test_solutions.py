from solutions import contains_duplicates

import pytest
class TestArraySolutions(object):
    def test_does_not_contains_duplicates(self):
        assert False == contains_duplicates("abcde")

    def test_contains_duplicates(self):
        assert contains_duplicates("abcdea")

    def test_contains_duplicates_side_by_side(self):
        assert contains_duplicates("aa")

    def test_contains_duplicates_at_the_end(self):
        assert contains_duplicates("abcdeaxyz")
