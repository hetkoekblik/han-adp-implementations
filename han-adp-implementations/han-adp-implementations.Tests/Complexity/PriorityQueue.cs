using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class PriorityQueue(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueueFull.Add(item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newQueue100.Add(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newQueue10.Add(data.lijst_willekeurig_10000[i]);
            
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
    public async Task CheckPeekComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueueFull.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newQueueFull.Peek();
            
            //wait for 1ms to simulate the time it takes to peek, since peeking is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueue100.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newQueue100.Peek();
            
            //wait for 1ms to simulate the time it takes to peek, since peeking is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueue10.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newQueue10.Peek();
            
            //wait for 1ms to simulate the time it takes to peek, since peeking is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckPollComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newQueueFull = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueueFull.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newQueueFull.Poll();
            
            //wait for 1ms to simulate the time it takes to poll, since polling is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newQueue100 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueue100.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newQueue100.Poll();
            
            //wait for 1ms to simulate the time it takes to poll, since polling is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newQueue10 = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newQueue10.Add(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newQueue10.Poll();
            
            //wait for 1ms to simulate the time it takes to poll, since polling is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}