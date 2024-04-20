namespace PriorityQueueMergeSort;

using SuperLinq;
using System.Diagnostics;

public static class SyncTest
{
    static double TimeEnumeration<T>(IEnumerable<T> source)
    {
        var timer = new Stopwatch();
        timer.Start();

        T latest = default!;

        foreach (var item in source)
        {
            if (Comparer<T>.Default.Compare(item, latest) < 0)
            {
                throw new InvalidOperationException();
            }

            latest = item;
        }

        timer.Stop();

        return timer.Elapsed.TotalMilliseconds;
    }

    static IEnumerable<IEnumerable<T>> Prepare<T>(int count, int chunks, Func<int, T> generate)
    {
        var source = Enumerable.Range(0, count).Select(generate).Shuffle().ToList();

        var randoms = source.Chunk(count / chunks).ToList();

        foreach (var random in randoms)
        {
            Array.Sort(random);
        }

        return randoms;
    }

    public static void Test<T>(int wholeListCount, int[] chunkCounts, Func<int, T> generate)
    {
        foreach (var chunkCount in chunkCounts)
        {
            var superLinq = new List<double>();
            var priorityQueue = new List<double>();

            for (var rep = 0; rep < 50; rep++)
            {
                var source = Prepare(wholeListCount, chunkCount, generate);

                superLinq.Add(TimeEnumeration(source.First().SortedMerge(source.Skip(1).ToArray())));
                priorityQueue.Add(TimeEnumeration(source.First().PqSortedMerge(source.Skip(1).ToArray())));
            }

            Console.WriteLine($"{chunkCount},{superLinq.Average()},{priorityQueue.Average()}");
        }
    }
}
