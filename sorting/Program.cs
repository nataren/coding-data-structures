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

        // Insertion sort
        // PrintArray(InsertionSortFaster(TESTING_ARRAY));

        var TESTING_ARRAY = new int[14] { 0, 10, 1, 9, 2, 8, 1, 13, 17, 7, 4, 6, 5, 11 };
        Console.WriteLine("Merge Sort Efficient:");        
        PrintArray(TESTING_ARRAY);
        MergeSortEfficient(TESTING_ARRAY);
        PrintArray(TESTING_ARRAY);
    }

    private static void MergeSortEfficient(int[] c) {
        if(c == null || c.Length <= 1) {
            return;
        }
        MergeSortEfficientHelper(c, 1, c.Length);
    }

    private static void MergeSortEfficientHelper(int[] c, int start, int end) {
        if(start < end) {
            var half = (int)Math.Floor((double)(start + end) / 2);
            MergeSortEfficientHelper(c, start, half);
            MergeSortEfficientHelper(c, half + 1, end);
            MergeEfficient(c, start, half, end);
        }
    }

    private static void MergeEfficient(int[] c, int start, int q, int end) {
        var leftSize = q - start + 1;
        var rightSize = end - q;
        var left = new int[leftSize + 1];
        var right = new int[rightSize + 1];

        // Copy the current values
        for(var i = 0; i < leftSize; i++) {
            left[i] = c[start + i - 1];
        }
        for(var j = 0; j < rightSize; j++) {
            right[j] = c[q + j];
        }

        // Store sentinels
        left[leftSize] = int.MaxValue;
        right[rightSize] = int.MaxValue;

        // Merge the values from the two already sorted collections
        int x = 0, y = 0;
        for(var k = start - 1; k < end; k++) {
            if(left[x] < right[y]) {
                c[k] = left[x++];
            } else {
                c[k] = right[y++];
            }
        }
    }

    private static int[] MergeSort(int[] c) {
        return MergeSortHelper(c, 0, c.Length - 1);
    }
    
    private static int[] MergeSortHelper(int[] c, int p, int q) {
        if(p == q || p > q) {
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
