using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class DoublyLinkedList(ITestOutputHelper testOutputHelper)
{
    //check if the add method has a complexity of O(n)
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedMilliseconds;
        
        var newArray10 = new DataStructures.Lists.DoublyLinkedList<int>();
        
        watch.Restart();
        
        for (var i = 0; i < 100; i++)
        {
            newArray10.Add(i);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs100 = watch.ElapsedMilliseconds;
        
        var newArray1000 = new DataStructures.Lists.DoublyLinkedList<int>();
        
        watch.Restart();
        
        for (var i = 0; i < 1000; i++)
        {
            newArray1000.Add(i);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs1000 = watch.ElapsedMilliseconds;
        
        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
    }
    
    //check if the remove by index method has a complexity of O(n)
    [Fact]
    public async Task CheckRemoveByIndexComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 9998; i >= 0; i--)
        {
            newArrayFull.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedMilliseconds;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 98; i >= 0; i--)
        {
            newArray100.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedMilliseconds;

        var newArray1000 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray1000.Add(item);
        }

        watch.Restart();

        for (var i = 998; i >= 0; i--)
        {
            newArray1000.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs1000 = watch.ElapsedMilliseconds;

        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
    }
    
    //check if the remove by item method has a complexity of O(n)
    [Fact]
    public async Task CheckRemoveByItemComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.RemoveItem(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedMilliseconds;

        var newArray1000 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray1000.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 999; i++)
        {
            newArray1000.RemoveItem(newArray1000[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs1000 = watch.ElapsedMilliseconds;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 99; i++)
        {
            newArray100.RemoveItem(newArray100[0]);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedMilliseconds;

        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
    }
    
    //check if the contains method has a complexity of O(n)
    [Fact]
    public async Task CheckContainsComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.Contains(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedMilliseconds;

        var newArray1000 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray1000.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 999; i++)
        {
            newArray1000.Contains(newArray1000[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs1000 = watch.ElapsedMilliseconds;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 99; i++)
        {
            newArray100.Contains(newArray100[0]);

            //wait for 1ms to simulate the time it takes to check if an item is in the list, since checking is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedMilliseconds;

        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
    }
    
    //check if the index of method has a complexity of O(n)
    [Fact]
    public async Task CheckIndexOfComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();

        var newArrayFull = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = Stopwatch.StartNew();

        for (var i = 0; i < data.lijst_willekeurig_10000.Length; i++)
        {
            newArrayFull.IndexOf(newArrayFull[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMsFull = watch.ElapsedMilliseconds;

        var newArray1000 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray1000.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 999; i++)
        {
            newArray1000.IndexOf(newArray1000[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs1000 = watch.ElapsedMilliseconds;

        var newArray100 = new DataStructures.Lists.DoublyLinkedList<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 0; i < 99; i++)
        {
            newArray100.IndexOf(newArray100[0]);

            //wait for 1ms to simulate the time it takes to get the index of an item, since getting the index is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedMilliseconds;

        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
    }
}