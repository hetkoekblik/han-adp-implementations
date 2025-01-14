using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class HashTable(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_hashing";
    private const string Data = "hashtabelsleutelswaardes";
    
    [Fact]
    public async Task CheckInsertComplexity()
    {
        var data = await DataRetriever.RetrieveHashingData<string, int[]>(Dataset, Data);
        
        var newHashTableFull = new DataStructures.Others.HashTable<string, int[]>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newHashTableFull.Insert(item.Key, item.Value);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<string, int[]>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 100; i++)
        {
            newHashTable100.Insert(data.ElementAt(i).Key, data.ElementAt(i).Value);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<string, int[]>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 10; i++)
        {
            newHashTable10.Insert(data.ElementAt(i).Key, data.ElementAt(i).Value);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckGetComplexity()
    {
        var data = await DataRetriever.RetrieveHashingData<string, int[]>(Dataset, Data);
        
        var newHashTable = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable.Insert(item.Key, item.Value);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newHashTable.Get(item.Key);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 100; i++)
        {
            newHashTable.Get(data.ElementAt(i).Key);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 10; i++)
        {
            newHashTable.Get(data.ElementAt(i).Key);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckDeleteComplexity()
    {
        var data = await DataRetriever.RetrieveHashingData<string, int[]>(Dataset, Data);
        
        var newHashTableFull = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTableFull.Insert(item.Key, item.Value);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newHashTableFull.Delete(item.Key);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable100.Insert(item.Key, item.Value);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 100; i++)
        {
            newHashTable100.Delete(data.ElementAt(i).Key);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable10.Insert(item.Key, item.Value);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 10; i++)
        {
            newHashTable10.Delete(data.ElementAt(i).Key);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckUpdateComplexity()
    {
        var data = await DataRetriever.RetrieveHashingData<string, int[]>(Dataset, Data);
        
        var replaceData = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        
        var newHashTableFull = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTableFull.Insert(item.Key, item.Value);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newHashTableFull.Update(item.Key, replaceData);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable100.Insert(item.Key, item.Value);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 100; i++)
        {
            newHashTable100.Update(data.ElementAt(i).Key, replaceData);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable10.Insert(item.Key, item.Value);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.Count / 10; i++)
        {
            newHashTable10.Update(data.ElementAt(i).Key, replaceData);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedMsFull} ticks");
    }
}