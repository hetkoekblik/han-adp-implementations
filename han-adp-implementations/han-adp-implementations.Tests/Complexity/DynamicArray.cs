using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class DynamicArray(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newArray100 = new DataStructures.Lists.DynamicArray<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newArray100.Add(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newArray10 = new DataStructures.Lists.DynamicArray<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newArray10.Add(data.lijst_willekeurig_10000[i]);
            
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
    public async Task CheckRemoveByIndexComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.Remove(0);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newArray100.Remove(0);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newArray10.Remove(0);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckRemoveByItemComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.RemoveItem(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newArray100.RemoveItem(newArray100[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newArray10.RemoveItem(newArray10[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckContainsComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.Contains(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newArray100.Contains(newArray100[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newArray10.Contains(newArray10[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckIndexOfComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.IndexOf(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newArray100.IndexOf(newArray100[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newArray10.IndexOf(newArray10[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}