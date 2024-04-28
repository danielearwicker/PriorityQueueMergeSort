namespace PriorityQueueMergeSort.Benchmarks;

using BenchmarkDotNet.Attributes;

public class BenchmarksStringAsync
{
    [ParamsSource(nameof(GetChunkCount))]
    public int ChunkCount { get; set; }

    public int[] GetChunkCount() => Helpers.ChunkCounts;

    [ParamsSource(nameof(GetAlgorithms))]
    public AsyncAlgorithm<string>? Algorithm { get; set; }

    public IEnumerable<AsyncAlgorithm<string>> GetAlgorithms() => Helpers.GetAsyncAlgorithms<string>();

    private IEnumerable<IAsyncEnumerable<string>> _chunks = Enumerable.Empty<IAsyncEnumerable<string>>();
        
    [GlobalSetup]
    public void GlobalSetup() => _chunks = Helpers.Prepare(ChunkCount, n => $"challenging-prefix-{n}")
        .Select(x => x.ToAsyncEnumerable())
        .ToList();

    [Benchmark]
    public void StringAsync() => Helpers.Run(_chunks, Algorithm!);
}
