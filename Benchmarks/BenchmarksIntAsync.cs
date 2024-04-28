namespace PriorityQueueMergeSort.Benchmarks;

using BenchmarkDotNet.Attributes;

public class BenchmarksIntAsync
{
    [ParamsSource(nameof(GetChunkCounts))]
    public int ChunkCount { get; set; }

    public int[] GetChunkCounts() => Helpers.ChunkCounts;

    [ParamsSource(nameof(GetAlgorithms))]
    public AsyncAlgorithm<int>? Algorithm { get; set; }

    public IEnumerable<AsyncAlgorithm<int>> GetAlgorithms() => Helpers.GetAsyncAlgorithms<int>();

    private IEnumerable<IAsyncEnumerable<int>> _chunks = Enumerable.Empty<IAsyncEnumerable<int>>();
        
    [GlobalSetup]
    public void GlobalSetup() => _chunks = Helpers.Prepare(ChunkCount, n => n)
        .Select(x => x.ToAsyncEnumerable())
        .ToList();

    [Benchmark]
    public void IntAsync() => Helpers.Run(_chunks, Algorithm!);
}
