import pytest

from solutions import contains_duplicates
from solutions import check_permutation
from solutions import urlify
from solutions import oneway
from solutions import compress
from solutions import Node
from solutions import remove_dups
from solutions import prepend
from solutions import kth_to_last

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

class TestOneAway(object):
    def test_changes_are_acceptable(self):
        s1 = 'abcd'
        s2 = 'abcd'
        assert oneway(s1, s2)

    def test_one_change_is_acceptable(self):
        s1 = 'abcde'
        s2 = 'jbcde'
        assert oneway(s1, s2)

    def test_one_change_is_acceptable_2(self):
        s1 = 'abcde'
        s2 = 'abcxe'
        assert oneway(s1, s2)

    def test_more_than_one_removal_is_not_one_change_away(self):
        s1 = 'abc'
        s2 = 'c'
        assert False == oneway(s1, s2)


    def test_more_than_one_removal_is_not_one_change_away_2(self):
        s1 = 'abc'
        s2 = 'c'
        assert False == oneway(s2, s1)

    def test_1(self):
        s1 = 'pale'
        s2 = 'ple'
        assert oneway(s1, s2)

    def test_2(self):
        s1 = 'pales'
        s2 = 'pale'
        assert oneway(s1, s2)

    def test_3(self):
        s1 = 'pale'
        s2 = 'bale'
        assert oneway(s1, s2)

    def test_4(self):
        s1 = 'pale'
        s2 = 'bake'
        assert False == oneway(s1, s2)

class TestCompress(object):
    def test_compress_1(self):
        assert 'a2b1c5a3' == compress('aabcccccaaa')

class TestRemoveDups(object):
    def length(self, n):
        k = 0
        node = n
        while node:
            k += 1
            node = node.next
        return k

    def test_remove_dups(self):
        ll = Node(None, 5, None)
        ll = prepend(ll, 4)
        ll = prepend(ll, 4)
        ll = prepend(ll, 3)
        ll = prepend(ll, 2)
        ll = prepend(ll, 1)
        n = self.length(ll)
        remove_dups(ll)
        assert self.length(ll) == n - 1

    def test_remove_dups(self):
        ll = Node(None, 5, None)
        ll = prepend(ll, 5)
        ll = prepend(ll, 5)
        ll = prepend(ll, 5)
        ll = prepend(ll, 5)
        ll = prepend(ll, 5)
        n = self.length(ll)
        remove_dups(ll)
        assert self.length(ll) == n - 5


    def test_no_removal(self):
        ll = Node(None, 3, None)
        ll = prepend(ll, 2)
        ll = prepend(ll, 1)
        n = self.length(ll)
        remove_dups(ll)
        assert self.length(ll) == n

class TestKthToLast(object):
    def find_2nd_to_last_even(self):
        l = Nonde(None, 4, None)
        l =prepend(l, 3)
        l = prepend(l, 2)
        l = prepend(l, 1)
        kth = kth_to_last(2, l)
        assert kth == 3

    def find_2nd_to_last_odd(self):
        l = Nonde(None, 3, None)
        l =prepend(l, 2)
        l = prepend(l, 1)

        kth = kth_to_last(2, l)
        assert kth == 2

    def find_3th_to_last(self):
        l = Nonde(None, 3, None)
        l =prepend(l, 2)
        l = prepend(l, 1)

        kth = kth_to_last(3, l)
        assert kth == 1

    def find_4th_to_last(self):
        l = Nonde(None, 3, None)
        l =prepend(l, 2)
        l = prepend(l, 1)

        kth = kth_to_last(4, l)
        assert kth == None
