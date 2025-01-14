using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class PriorityQueue(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";
    
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newQueueFull.Add(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newQueue100.Add(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newQueue10.Add(data[i]);
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
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueueFull.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newQueueFull.Peek();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueue100.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newQueue100.Peek();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueue10.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newQueue10.Peek();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckPollComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueueFull.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newQueueFull.Poll();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueue100.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newQueue100.Poll();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueue10.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newQueue10.Poll();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
}