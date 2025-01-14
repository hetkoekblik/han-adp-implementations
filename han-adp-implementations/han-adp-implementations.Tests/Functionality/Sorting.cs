using han_adp_implementations.Algorithms;
using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class Sorting
{
    [Fact]
    public void IsInsertionSortWorking()
    {
        var newList = new DataStructures.Lists.DynamicArray<int>
        {
            3,
            1,
            2,
            6,
            4,
            5
        };

        var sorted = newList.InsertionSort();
        
        Assert.Equal(1, sorted[0]);
        Assert.Equal(2, sorted[1]);
        Assert.Equal(3, sorted[2]);
        Assert.Equal(4, sorted[3]);
        Assert.Equal(5, sorted[4]);
        Assert.Equal(6, sorted[5]);
    }
    
    [Fact]
    public void IsSelectionSortWorking()
    {
        var newList = new DataStructures.Lists.DynamicArray<int>
        {
            3,
            1,
            2,
            6,
            4,
            5
        };

        var sorted = newList.SelectionSort();
        
        Assert.Equal(1, sorted[0]);
        Assert.Equal(2, sorted[1]);
        Assert.Equal(3, sorted[2]);
        Assert.Equal(4, sorted[3]);
        Assert.Equal(5, sorted[4]);
        Assert.Equal(6, sorted[5]);
    }
    
    [Fact]
    public void IsParallelMergeSortWorking()
    {
        var newList = new DataStructures.Lists.DynamicArray<int>
        {
            3,
            1,
            2,
            6,
            4,
            5
        };

        var sorted = newList.ParallelMergeSort();
        
        Assert.Equal(1, sorted[0]);
        Assert.Equal(2, sorted[1]);
        Assert.Equal(3, sorted[2]);
        Assert.Equal(4, sorted[3]);
        Assert.Equal(5, sorted[4]);
        Assert.Equal(6, sorted[5]);
    }
    
    [Fact]
    public void IsQuickSortWorking()
    {
        var newList = new DataStructures.Lists.DynamicArray<int>
        {
            3,
            1,
            2,
            6,
            4,
            5
        };

        var sorted = newList.QuickSort();
        
        Assert.Equal(1, sorted[0]);
        Assert.Equal(2, sorted[1]);
        Assert.Equal(3, sorted[2]);
        Assert.Equal(4, sorted[3]);
        Assert.Equal(5, sorted[4]);
        Assert.Equal(6, sorted[5]);
    }
}