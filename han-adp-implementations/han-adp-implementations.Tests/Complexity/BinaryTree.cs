using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class BinaryTree(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_sorting";
    private const string Data = "lijst_willekeurig_10000";
    
    [Fact]
    public async Task CheckFindComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            tree.Find(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Find {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Find {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Find {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckFindMinComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var _ in data)
        {
            tree.FindMin();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"FindMin {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"FindMin {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"FindMin {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckFindMaxComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var _ in data)
        {
            tree.FindMax();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"FindMax {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"FindMax {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"FindMax {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckInsertComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            tree.Insert(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Insert {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Insert {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Insert {data.Count()} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckRemoveComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData<int>(Dataset, Data);
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            tree.Remove(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 100; i++)
        {
            hundredTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count() / 10; i++)
        {
            tenTree.Insert(data[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Remove {data.Count() / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Remove {data.Count() / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Remove {data.Count()} items: {elapsedMsFull} ticks");
    }
}