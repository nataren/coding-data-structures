import pytest

from solutions import contains_duplicates
from solutions import check_permutation
from solutions import urlify

class TestContainsDuplicatesSolution(object):
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


class TestCheckPermutation(object):
    def test_empty_strings(self):
        assert check_permutation('', '')

    def test_single_character_permutation(self):
        assert check_permutation('a', 'a')

    def test_single_character_different(self):
        assert not check_permutation('a', 'b')

    def test_multiple_characters_are_not_permutation(self):
        assert not check_permutation('aabbc', 'azzzz')

    def test_different_length_strings(self):
        assert not check_permutation('asdfasdfasdf', 'ab')

    def test_multiple_characters_permutation(self):
        assert check_permutation('abcd', 'dcba')

class TestUrlify(object):
    def test_empty_string(self):
        assert '' == urlify('')

    def test_many_spaces(self):
        assert 'a%20b%20c%20d%20%20e' == urlify('a b c d  e')

    def test_no_encoding(self):
        assert 'abc' == urlify('abc')

    def test_single_space_is_replaced(self):
        assert 'a%20b' == urlify('a b')
