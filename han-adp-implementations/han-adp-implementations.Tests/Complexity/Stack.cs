using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Stack(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";

    [Fact]
    public async Task CheckPushComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newStackFull.Push(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 100; i++)
        {
            newStack100.Push(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 10; i++)
        {
            newStack10.Push(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckPopComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newStackFull.Pop();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newStack100.Pop();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newStack10.Pop();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckTopComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newStackFull.Top();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newStack100.Top();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newStack10.Top();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckPeekComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newStackFull.Peek();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newStack100.Peek();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newStack10.Peek();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
}