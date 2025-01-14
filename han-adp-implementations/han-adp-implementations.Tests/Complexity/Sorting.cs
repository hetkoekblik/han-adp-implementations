using System.Diagnostics;
using han_adp_implementations.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Sorting(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";

    [Fact]
    public async Task CheckInsertionSortComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var fullList = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data)
        {
            fullList.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        fullList.InsertionSort();
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredList.Add(data[i]);
        }
        
        watch.Restart();
        
        hundredList.InsertionSort();
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenList.Add(data[i]);
        }
        
        watch.Restart();
        
        tenList.InsertionSort();
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Insertion sort {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Insertion sort {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Insertion sort {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckSelectionSortComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var fullList = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data)
        {
            fullList.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        fullList.SelectionSort();
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredList.Add(data[i]);
        }
        
        watch.Restart();
        
        hundredList.SelectionSort();
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenList.Add(data[i]);
        }
        
        watch.Restart();
        
        tenList.SelectionSort();
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Selection sort {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Selection sort {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Selection sort {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckParallelMergeSortComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var fullList = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data)
        {
            fullList.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        fullList.ParallelMergeSort();
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredList.Add(data[i]);
        }
        
        watch.Restart();
        
        hundredList.ParallelMergeSort();
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenList.Add(data[i]);
        }
        
        watch.Restart();
        
        tenList.ParallelMergeSort();
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Parallel merge sort {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Parallel merge sort {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Parallel merge sort {data.Count()} items: {elapsedMsFull} ticks");
    }
    
    [Fact]
    public async Task CheckQuickSortComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var fullList = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data)
        {
            fullList.Add(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        fullList.QuickSort();
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredList.Add(data[i]);
        }
        
        watch.Restart();
        
        hundredList.QuickSort();
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenList = new DataStructures.Lists.DynamicArray<int>();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenList.Add(data[i]);
        }
        
        watch.Restart();
        
        tenList.QuickSort();
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Quick sort {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Quick sort {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Quick sort {data.Count()} items: {elapsedMsFull} ticks");
    }
}