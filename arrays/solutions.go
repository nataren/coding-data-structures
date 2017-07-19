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
	if n <= 0 {
		return 1
	}
	return n * factorial(n-1)
}

type Permutation struct {
	Original  string
	Sanitized string
}

func permutations(s string) []Permutation {
	sanitized := removeSpaces(s)
	runes := []rune(sanitized)
	n := len(runes)
	if s == "" || n == 1 {
		return []Permutation{
			Permutation{Original: s, Sanitized: s},
		}
	}
	if n == 2 {
		return []Permutation{
			Permutation{Original: s, Sanitized: sanitized},
			Permutation{Original: s, Sanitized: reverse(sanitized)},
		}
	}
	var perms []Permutation
	i := 0
	for _, c := range sanitized {
		for _, p := range permutations(sanitized[:i] + sanitized[i+1:]) {
			perms = append(perms, Permutation{Original: p.Original, Sanitized: string(c) + p.Sanitized})
		}
		i++
	}
	return perms
}

func PalindromePermutation(s string) (bool, string) {
	for _, permutation := range permutations(s) {
		// fmt.Printf("%v,%v\n", i, permutation.Sanitized)
		if palindrome(permutation.Sanitized) {
			return true, permutation.Sanitized
		}
	}
	return false, ""
}

func main() {
	phrase := "Tact Coa"
	isPalindrome, perm := PalindromePermutation(phrase)
	fmt.Printf("PalindromePermutation(%v)=[%v, `%v`]\n", phrase, isPalindrome, perm)
}
