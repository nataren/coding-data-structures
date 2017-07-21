package arrays

import (
	"testing"
)

func TestPalindromeExamples(t *testing.T) {
	samples := []struct {
		input    string
		expected bool
	}{
		{"Tact Coa", true},
		{"a   a b ", true},
		{"", true},
	}
	for _, sample := range samples {
		isIt, _ := PalindromePermutation(sample.input)
		if isIt != sample.expected {
			t.Errorf("ERROR: PalindromePermutation(%v) must be %v: Got %v", sample.input, sample.expected, isIt)
		}
	}
}
