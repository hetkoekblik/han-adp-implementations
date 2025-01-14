using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Stack(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckPushComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStackFull.Push(item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newStack100.Push(data.lijst_willekeurig_10000[i]);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newStack10.Push(data.lijst_willekeurig_10000[i]);
            
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
    public async Task CheckPopComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            var tempItem = newStackFull.Pop();
            
            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            var tempItem = newStack100.Pop();
            
            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            var tempItem = newStack10.Pop();
            
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
    public async Task CheckTopComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            var tempItem = newStackFull.Top();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            var tempItem = newStack100.Top();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            var tempItem = newStack10.Top();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
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
        
        var newStackFull = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStackFull.Push(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            var tempItem = newStackFull.Peek();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newStack100 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack100.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            var tempItem = newStack100.Peek();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newStack10 = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newStack10.Push(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            var tempItem = newStack10.Peek();
            
            //wait for 1ms to simulate the time it takes to get the top item, since getting the top item is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}