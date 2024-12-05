using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class PriorityQueue
{
    [Fact]
    public void IsAddPollAndCountWorking()
    {
        var newQueue = new DataStructures.Others.PriorityQueue<int>();
        
        newQueue.Add(1);
        newQueue.Add(2);
        newQueue.Add(3);
        
        Assert.Equal(3, newQueue.Count());
        
        Assert.Equal(1, newQueue.Poll());
        Assert.Equal(2, newQueue.Poll());
        Assert.Equal(3, newQueue.Poll());
    }

    [Fact]
    public void IsPeekWorking()
    {
        var newQueue = new DataStructures.Others.PriorityQueue<int>();
        
        newQueue.Add(1);
        newQueue.Add(2);
        newQueue.Add(3);
        
        Assert.Equal(3, newQueue.Count());
        
        Assert.Equal(1, newQueue.Peek());

        newQueue.Poll();
        
        Assert.Equal(2, newQueue.Peek());

        newQueue.Poll();
        
        Assert.Equal(3, newQueue.Peek());
    }
}