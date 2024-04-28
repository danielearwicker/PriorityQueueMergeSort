namespace PriorityQueueMergeSort.Benchmarks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

public class BenchmarksIntSync
{
    [ParamsSource(nameof(GetChunkCounts))]
    public int ChunkCount { get; set; }

    public int[] GetChunkCounts() => Helpers.ChunkCounts;

    [ParamsSource(nameof(GetAlgorithms))]
    public SyncAlgorithm<int>? Algorithm { get; set; }

    public IEnumerable<SyncAlgorithm<int>> GetAlgorithms() => Helpers.GetSyncAlgorithms<int>();

    private IEnumerable<IEnumerable<int>> _chunks = Enumerable.Empty<IEnumerable<int>>();
        
    [GlobalSetup]
    public void GlobalSetup() => _chunks = Helpers.Prepare(ChunkCount, n => n);
    
    [Benchmark]
    public void IntSync() => Helpers.Run(_chunks, Algorithm!);
}
