using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class DoublyLinkedList
{
    [Fact]
    public void IsCountAddAndGetWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>
        {
            1,
            2,
            3
        };

        Assert.Equal(3, newArray.Count());
        
        Assert.Equal(1, newArray[0]);
        Assert.Equal(2, newArray[1]);
        Assert.Equal(3, newArray[2]);
    }
    
    [Fact]
    public void IsRemoveByIndexWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>
        {
            1,
            2,
            3
        };

        newArray.Remove(1);
        
        Assert.Equal(2, newArray.Count());
        
        Assert.Equal(1, newArray[0]);
        Assert.Equal(3, newArray[1]);
    }
    
    [Fact]
    public void IsRemoveByItemWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<string>
        {
            "a",
            "b",
            "c"
        };

        newArray.Remove("b");
        
        Assert.Equal(2, newArray.Count());
        
        Assert.Equal("a", newArray[0]);
        Assert.Equal("c", newArray[1]);
    }

    [Fact]
    public void IsSetWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>
        {
            1,
            2,
            3
        };

        newArray[1] = 4;
        
        Assert.Equal(3, newArray.Count());
        
        Assert.Equal(1, newArray[0]);
        Assert.Equal(4, newArray[1]);
        Assert.Equal(3, newArray[2]);
    }

    [Fact]
    public void IsContainsWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>
        {
            1,
            2,
            3
        };

        Assert.True(newArray.Contains(2));
        Assert.False(newArray.Contains(4));
    }
    
    [Fact]
    public void IsIndexOfWorking()
    {
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>
        {
            1,
            2,
            3
        };

        Assert.Equal(1, newArray.IndexOf(2));
        Assert.Equal(-1, newArray.IndexOf(4));
    }
}