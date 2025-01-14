using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Deque(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckInsertLeftComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDequeFull.InsertLeft(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newDeque100.InsertLeft(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newDeque10.InsertLeft(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckInsertRightComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDequeFull.InsertRight(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newDeque100.InsertRight(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newDeque10.InsertRight(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckDeleteLeftComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDequeFull.InsertLeft(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newDequeFull.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDeque100.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newDeque100.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDeque10.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newDeque10.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckDeleteRightComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDequeFull.InsertLeft(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newDequeFull.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDeque100.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            newDeque100.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newDeque10.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            newDeque10.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}