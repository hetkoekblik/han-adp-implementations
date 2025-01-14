using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Deque(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";
    
    [Fact]
    public async Task CheckInsertLeftComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newDequeFull.InsertLeft(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 100; i++)
        {
            newDeque100.InsertLeft(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 10; i++)
        {
            newDeque10.InsertLeft(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckInsertRightComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            newDequeFull.InsertRight(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 100; i++)
        {
            newDeque100.InsertRight(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        watch.Restart();
        
        for(var i = 0; i < data.Count() / 10; i++)
        {
            newDeque10.InsertRight(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckDeleteLeftComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDequeFull.InsertLeft(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newDequeFull.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDeque100.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newDeque100.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDeque10.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newDeque10.DeleteLeft();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckDeleteRightComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var newDequeFull = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDequeFull.InsertLeft(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < data.Count(); i++)
        {
            newDequeFull.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var newDeque100 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDeque100.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            newDeque100.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var newDeque10 = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDeque10.InsertLeft(item);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            newDeque10.DeleteRight();
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count()} items: {elapsedMsFull} ticks");
    }
}