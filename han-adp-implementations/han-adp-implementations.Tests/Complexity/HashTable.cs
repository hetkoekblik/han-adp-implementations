using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class HashTable(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckInsertComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newHashTableFull = new DataStructures.Others.HashTable<int, int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Insert(item, item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<int, int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newHashTable100.Insert(data.lijst_willekeurig_10000[i], data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<int, int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newHashTable10.Insert(data.lijst_willekeurig_10000[i], data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckGetComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newHashTableFull = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Insert(item, item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Get(item);
            
            //wait for 1ms to simulate the time it takes to get an item, since getting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable100.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newHashTable100.Get(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to get an item, since getting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable10.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newHashTable10.Get(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to get an item, since getting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckDeleteComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newHashTableFull = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Insert(item, item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Delete(item);
            
            //wait for 1ms to simulate the time it takes to delete an item, since deleting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable100.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newHashTable100.Delete(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to delete an item, since deleting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable10.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newHashTable10.Delete(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to delete an item, since deleting is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckUpdateComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newHashTableFull = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Insert(item, item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTableFull.Update(item, item);
            
            //wait for 1ms to simulate the time it takes to update an item, since updating is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newHashTable100 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable100.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newHashTable100.Update(data.lijst_willekeurig_10000[i], data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to update an item, since updating is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newHashTable10 = new DataStructures.Others.HashTable<int, int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newHashTable10.Insert(item, item);
        }
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newHashTable10.Update(data.lijst_willekeurig_10000[i], data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to update an item, since updating is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}