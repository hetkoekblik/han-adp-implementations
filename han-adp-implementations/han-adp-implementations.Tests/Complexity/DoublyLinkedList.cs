using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class DoublyLinkedList(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";
    
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newArrayFull.Add(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 100; i++)
        {
            newArray100.Add(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 10; i++)
        {
            newArray10.Add(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckRemoveByIndexComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = data.Count() - 1; i >= 0; i--)
        {
            newArrayFull.Remove(i);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = (data.Count() - 1) / 100; i >= 0; i--)
        {
            newArray100.Remove(i);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = (data.Count() - 1) / 10; i >= 0; i--)
        {
            newArray10.Remove(i);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckRemoveByItemComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.Count(); i++)
        {
            newArrayFull.RemoveItem(newArrayFull[0]);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 100; i++)
        {
            newArray100.RemoveItem(newArray100[0]);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 10; i++)
        {
            newArray10.RemoveItem(newArray10[0]);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckContainsComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.Count(); i++)
        {
            newArrayFull.Contains(newArrayFull[0]);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 100; i++)
        {
            newArray100.Contains(newArray100[0]);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 10; i++)
        {
            newArray10.Contains(newArray10[0]);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckIndexOfComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.Count(); i++)
        {
            newArrayFull.IndexOf(newArrayFull[0]);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedTicks;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 100; i++)
        {
            newArray100.IndexOf(newArray100[0]);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedTicks;

        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < data.Count() / 10; i++)
        {
            newArray10.IndexOf(newArray10[0]);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedTicks;

        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
}