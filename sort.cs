using System;

public static class Sorting {

    public static int[] InsertionSort(int[] c) {

        // Trivial cases
        if(c == null) {
            return null;
        }
        var length = c.Length;
        if(length == 0 || length == 1) {
            return c;
        }

        // Actual sorting cases
        for(var i = 1; i < length; i++) {
            var j = i;
            while(j > 0 && c[j - 1] > c[j]) {
                var tmp = c[j];
                c[j] = c[j - 1];
                c[j - 1] = tmp;
                j = j - 1;
            }
        } 
        return c;
    }

    private static void PrintArray(int[] c) {
        if(c == null) {
            Console.WriteLine("null");
            return;
        }
        if(c.Length == 0) {
            Console.WriteLine("[]");
            return;
        }
        Console.WriteLine("[{0}]", string.Join(",", c));
    }

    public static void Main() {
        var TESTING_ARRAY = new int[] { 0, 10, 1, 9, 2, 8, -3, 7, 4, 6, 5, 11 };

        // Insertion sort
        // PrintArray(InsertionSortFaster(TESTING_ARRAY));

        PrintArray(MergeSort(TESTING_ARRAY));
    }

    private static int[] MergeSort(int[] c) {
        return MergeSortHelper(c, 0, c.Length - 1);
    }
    
    private static int[] MergeSortHelper(int[] c, int p, int q) {
        if(p == q) {
            return new int[] { c[p] };
        }
        var half = (int)Math.Floor((double)((p + q) / 2));
        return Merge(MergeSortHelper(c, p, half), MergeSortHelper(c, half + 1, q));
    }

    private static int[] Merge(int[] first, int[] second) {
        var firstSize = first.Length;
        var secondSize = second.Length;
        var size = firstSize + secondSize;
        var merged = new int[size];
              
        // Merge the values
        int i, j, k;
        for(i = 0, j = 0, k = 0; i < firstSize && j < secondSize; k++) {
            if(first[i] < second[j]) {
                merged[k] = first[i++];
            } else {
                merged[k] = second[j++];
            }
        }
        if(i >= firstSize) {
            for(; j < secondSize; j++) {
                merged[k] = second[j];
            }
        } else if(j >= secondSize) {
            for(; i < firstSize; i++) {
                merged[k] = first[i];
            }
        }
        return merged;
    }
}
