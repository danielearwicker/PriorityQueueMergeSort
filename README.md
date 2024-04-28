# PriorityQueueMergeSort

Test program for `PqSortedMerge`, alternative implementation of [SuperLinq](https://github.com/viceroypenguin/SuperLinq)'s `SortedMerge`.

Created by copying the `IEnumerable` and `IAsyncEnumerable` extension methods from SuperLinq, renaming them with the prefix `Pq`, and replacing the `Impl` with one that uses the CLR's `PriorityQueue` class.

Later extended to test (in non-async versions only):

-   `SortedSet` - `SortedSet<T>`, but the items have to be unique, so it's actually `SortedSet<List<(TItem Item, TKey Key)>>` to hold multiple items with the same key.
-   `SortedList` - `List<T>` using linear search to find insertion point (does lots of key comparison for insertion, also has to copy array elements to insert/remove)
-   `SortedLinked` - `LinkedList<T>`, still using linear search but avoiding copying
-   `BinarySortedArray` - Uses an array to get built-in `Array.BinarySearch` for fast insertion with ($log_2$) key comparisons
-   `BinarySortedLinked` - Linked list with an adapted binary search to allow skipping through list nodes while avoiding key comparisons

Run all benchmarks with:

    dotnet run -c Release -- -f '*' --join
