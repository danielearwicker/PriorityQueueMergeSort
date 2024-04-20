namespace PriorityQueueMergeSort;

using SuperLinq;
using SuperLinq.Async;
using System.Diagnostics;

public static class AsyncTest
{
    static async Task<double> TimeEnumeration<T>(IAsyncEnumerable<T> source)
    {
        var timer = new Stopwatch();
        timer.Start();

        T latest = default(T)!;

        await foreach (var item in source)
        {
            latest = item;
        }

        timer.Stop();

        return timer.Elapsed.TotalMilliseconds;
    }

    static IEnumerable<IAsyncEnumerable<T>> Prepare<T>(int count, int chunks, Func<int, T> generate)
    {
        var source = Enumerable.Range(0, count).Select(generate).Shuffle().ToList();

        var randoms = source.Chunk(count / chunks).ToList();

        foreach (var random in randoms)
        {
            Array.Sort(random);
        }

        return randoms.Select(x => x.ToAsyncEnumerable());
    }

    public static async Task Test<T>(int wholeListCount, int[] chunkCounts, Func<int, T> generate)
    {
        foreach (var chunkCount in chunkCounts)
        {
            var superLinq = new List<double>();
            var priorityQueue = new List<double>();

            for (var rep = 0; rep < 10; rep++)
            {
                var source = Prepare(wholeListCount, chunkCount, generate);

                superLinq.Add(await TimeEnumeration(source.First().SortedMerge(source.Skip(1).ToArray())));
                priorityQueue.Add(await TimeEnumeration(source.First().PqSortedMerge(source.Skip(1).ToArray())));
            }

            Console.WriteLine($"{chunkCount},{superLinq.Average()},{priorityQueue.Average()}");
        }
    }
}
