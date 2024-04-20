# PriorityQueueMergeSort

Test program for `PqSortedMerge`, alternative implementation of [SuperLinq](https://github.com/viceroypenguin/SuperLinq)'s `SortedMerge`.

Created by copying the `IEnumerable` and `IAsyncEnumerable` extension methods from SuperLinq, renaming them with the prefix `Pq`, and replacing the `Impl` with one that uses the CLR's `PriorityQueue` class.
