package main

import (
	"fmt"
	"strings"
)

func removeSpaces(s string) string {
	var new_s []rune
	for _, c := range s {
		if c == ' ' {
			continue
		}
		new_s = append(new_s, c)
	}
	return string(new_s)
}

func reverse(s string) string {
	n := len([]rune(s))
	new_s := make([]rune, n)
	for i, v := range s {
		new_s[n-1-i] = v
	}
	return string(new_s)
}

func palindrome(s string) bool {
	new_s := removeSpaces(s)
	return strings.EqualFold(new_s, reverse(new_s))
}

func factorial(n int) int {
	acc := 1
	for i := n; i >= 1; i-- {
		acc *= i
	}
	return acc
}

func permutations(s string) []string {
	var perms []string
	n := len([]rune(s))
	if s == "" || n == 1 {
		return []string{s}
	}
	if n == 2 {
		return []string{
			s,
			reverse(s),
		}
	}
	for i, c := range s {
		for _, p := range permutations(s[:i] + s[i+1:]) {
			perms = append(perms, string(c)+p)
		}
	}
	return perms
}

func PalindromePermutation(s string) (bool, string) {
	for _, permutation := range permutations(s) {
		if palindrome(permutation) {
			return true, permutation
		}
	}
	return false, ""
}

func main() {
	phrase := "Tact Coa"
	isPalindrome, perm := PalindromePermutation(phrase)
	fmt.Printf("PalindromePermutation(`%v`)=[%v, `%v`]\n", phrase, isPalindrome, perm)
}
