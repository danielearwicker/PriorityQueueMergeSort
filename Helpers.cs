namespace PriorityQueueMergeSort;

using PriorityQueueMergeSort.Algorithms;
using SuperLinq;
using SuperLinq.Async;

public record SyncAlgorithm<T>(string Name, Func<IEnumerable<T>, IEnumerable<T>[], IEnumerable<T>> SortedMerge)
{
    public override string ToString() => Name;    
} 

public record AsyncAlgorithm<T>(string Name, Func<IAsyncEnumerable<T>, IAsyncEnumerable<T>[], IAsyncEnumerable<T>> SortedMerge)
{
    public override string ToString() => Name;    
} 

public class Helpers
{
    public static int[] ChunkCounts = new[] { 2, 5, 50 };

    public static IEnumerable<SyncAlgorithm<T>> GetSyncAlgorithms<T>() where T : notnull 
        => new SyncAlgorithm<T>[]        
        {
            new ("SuperLinq_Sync", (first, rest) => first.SortedMerge(rest)),
            new ("PriorityQueue_Sync", (first, rest) => first.PqSortedMerge(rest)),
            new ("SortedSet_Sync", (first, rest) => first.SsSortedMerge(rest)),
            new ("SortedList_Sync", (first, rest) => first.SlSortedMerge(rest)),
            new ("SortedLinked_Sync", (first, rest) => first.SllSortedMerge(rest)),
            new ("BinaryLinked_Sync", (first, rest) => first.BsllSortedMerge(rest)),
            new ("BinaryArray_Sync", (first, rest) => first.SaSortedMerge(rest)),
        };

    public static IEnumerable<AsyncAlgorithm<T>> GetAsyncAlgorithms<T>() 
        => new AsyncAlgorithm<T>[]
        {
            new ("SuperLinq_Async", (first, rest) => first.SortedMerge(rest)),
            new ("PriorityQueue_Async", (first, rest) => first.PqSortedMerge(rest)),
        };

    const int ItemCount = 100_000;

    public static IEnumerable<IEnumerable<T>> Prepare<T>(int chunks, Func<int, T> generate)
    {
        var source = Enumerable.Range(0, ItemCount).Select(generate).Shuffle().ToList();
        var rand = source.Chunk(ItemCount / chunks).ToList();

        foreach (var random in rand)
        {
            Array.Sort(random);
        }

        return rand;
    }

    public static void Run<T>(IEnumerable<IEnumerable<T>> source, SyncAlgorithm<T> algorithm)
    {        
        var comparer = Comparer<T>.Default;
        var last = default(T);
        var count = 0;
        
        foreach (var item in algorithm.SortedMerge(source.First(), source.Skip(1).ToArray())) 
        {            
            if (count != 0 && comparer.Compare(last, item) >= 0) throw new InvalidOperationException("Sort unsuccessful");
            last = item;
            count++;
        }

        if (count != ItemCount) throw new InvalidOperationException($"{count} != {ItemCount}");
    }

    public static async void Run<T>(IEnumerable<IAsyncEnumerable<T>> chunks, AsyncAlgorithm<T> algorithm)
    {        
        var comparer = Comparer<T>.Default;
        var last = default(T);
        var count = 0;
        
        await foreach (var item in algorithm.SortedMerge(chunks.First(), chunks.Skip(1).ToArray()))
        {
            if (count != 0 && comparer.Compare(last, item) >= 0) throw new InvalidOperationException("Sort unsuccessful");
            last = item;
            count++;
        }

        if (count != ItemCount) throw new InvalidOperationException($"{count} != {ItemCount}");
    }
}
