namespace PriorityQueueMergeSort.Benchmarks;

using BenchmarkDotNet.Attributes;

public class BenchmarksStringSync
{
    [ParamsSource(nameof(GetChunkCount))]
    public int ChunkCount { get; set; }

    public int[] GetChunkCount() => Helpers.ChunkCounts;

    [ParamsSource(nameof(GetAlgorithms))]
    public SyncAlgorithm<string>? Algorithm { get; set; }

    public IEnumerable<SyncAlgorithm<string>> GetAlgorithms() => Helpers.GetSyncAlgorithms<string>();

    private IEnumerable<IEnumerable<string>> _chunks = Enumerable.Empty<IEnumerable<string>>();
        
    [GlobalSetup]
    public void GlobalSetup() => _chunks = Helpers.Prepare(ChunkCount, n => $"challenging-prefix-{n}");
    
    [Benchmark]
    public void StringSync() => Helpers.Run(_chunks, Algorithm!);
}
