using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class DynamicArray(ITestOutputHelper testOutputHelper)
{
    //check if the add method has a complexity of O(n)
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();
        
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMsFull = watch.ElapsedMilliseconds;
        
        var newArray10 = new DataStructures.Lists.DynamicArray<int>();
        
        watch.Restart();
        
        for (var i = 0; i < 10; i++)
        {
            newArray10.Add(i);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs10 = watch.ElapsedMilliseconds;
        
        var newArray1000 = new DataStructures.Lists.DynamicArray<int>();
        
        watch.Restart();
        
        for (var i = 0; i < 1000; i++)
        {
            newArray1000.Add(i);
            
            //wait for 1ms to simulate the time it takes to add an item, since adding is too fast to measure
            await Task.Delay(1);
        }
        
        watch.Stop();
        
        var elapsedMs1000 = watch.ElapsedMilliseconds;
        
        testOutputHelper.WriteLine($"10 items: {elapsedMs10}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");
        testOutputHelper.WriteLine($"10000 items: {elapsedMsFull}ms");
        
        //check if the time it takes to add an item is linear with a margin of 10% to account for small differences
        Assert.InRange(elapsedMs10 * 1000, elapsedMsFull * 0.9, elapsedMsFull * 1.1);
        Assert.InRange(elapsedMs1000 * 10, elapsedMsFull * 0.9, elapsedMsFull * 1.1);
    }
    
    //check if the remove by index method has a complexity of O(n)
    [Fact]
    public async Task CheckRemoveByIndexComplexity()
    {
        var data = await DataRetriever.RetrieveSortingData();
        
        var newArrayFull = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArrayFull.Add(item);
        }

        var watch = System.Diagnostics.Stopwatch.StartNew();

        for (var i = 999; i >= 0; i--)
        {
            newArrayFull.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs1000 = watch.ElapsedMilliseconds;

        var newArray10 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray10.Add(item);
        }

        watch.Restart();

        for (var i = 9; i >= 0; i--)
        {
            newArray10.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs10 = watch.ElapsedMilliseconds;

        var newArray100 = new DataStructures.Lists.DynamicArray<int>();

        foreach (var item in data.lijst_willekeurig_10000)
        {
            newArray100.Add(item);
        }

        watch.Restart();

        for (var i = 99; i >= 0; i--)
        {
            newArray100.Remove(i);

            //wait for 1ms to simulate the time it takes to remove an item, since removing is too fast to measure
            await Task.Delay(1);
        }

        watch.Stop();

        var elapsedMs100 = watch.ElapsedMilliseconds;

        testOutputHelper.WriteLine($"10 items: {elapsedMs10}ms");
        testOutputHelper.WriteLine($"100 items: {elapsedMs100}ms");
        testOutputHelper.WriteLine($"1000 items: {elapsedMs1000}ms");

        //check if the time it takes to remove an item is linear with a margin of 10% to account for small differences
        Assert.InRange(elapsedMs10 * 10, elapsedMs100 * 0.9, elapsedMs100 * 1.1);
        Assert.InRange(elapsedMs100 * 10, elapsedMs1000 * 0.9, elapsedMs1000 * 1.1);
    }
}