using PriorityQueueMergeSort;

var chunkCounts = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 30 };

Console.WriteLine("IEnumerable");

Console.WriteLine("int:");
SyncTest.Test(1_000_000, chunkCounts, n => n);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("string:");
SyncTest.Test(100_000, chunkCounts, n => $"challenging-prefix-{n}");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("IAsyncEnumerable");

Console.WriteLine("int:");
await AsyncTest.Test(1_000_000, chunkCounts, n => n);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("string:");
await AsyncTest.Test(100_000, chunkCounts, n => $"challenging-prefix-{n}");
