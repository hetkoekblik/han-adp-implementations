using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class BinaryTree(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckFindComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Find(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            hundredTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            tenTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Find {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Find {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Find {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckFindMinComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var _ in data.lijst_willekeurig_10000)
        {
            tree.FindMin();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            hundredTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            tenTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"FindMin {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"FindMin {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"FindMin {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckFindMaxComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var _ in data.lijst_willekeurig_10000)
        {
            tree.FindMax();
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            hundredTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            tenTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"FindMax {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"FindMax {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"FindMax {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckInsertComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Insert(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            hundredTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            tenTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Insert {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Insert {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Insert {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }

    [Fact]
    public async Task CheckRemoveComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var tree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Insert(item);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            tree.Remove(item);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedTicks;
        
        var hundredTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 100; i++)
        {
            hundredTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedTicks;
        
        var tenTree = new DataStructures.Trees.BinaryTree<int>();
        
        watch.Restart();
        
        for (var i = 0; i < data.lijst_willekeurig_10000.Length / 10; i++)
        {
            tenTree.Insert(data.lijst_willekeurig_10000[i]);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Remove {data.lijst_willekeurig_10000.Length / 100} items: {elapsedMs100} ticks");
        testOutputHelper.WriteLine($"Remove {data.lijst_willekeurig_10000.Length / 10} items: {elapsedMs10} ticks");
        testOutputHelper.WriteLine($"Remove {data.lijst_willekeurig_10000.Length} items: {elapsedMsFull} ticks");
    }
}