using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class Stack
{
    [Fact]
    public void IsPushPopAndCountWorking()
    {
        var newStack = new DataStructures.Others.Stack<int>();

        newStack.Push(1);
        newStack.Push(2);
        newStack.Push(3);

        Assert.Equal(3, newStack.Count());
        
        Assert.Equal(3, newStack.Pop());
        Assert.Equal(2, newStack.Pop());
        Assert.Equal(1, newStack.Pop());
    }

    [Fact]
    public void IsTopAndPeekWorking()
    {
        var newStack = new DataStructures.Others.Stack<string>();

        newStack.Push("a");
        newStack.Push("b");
        newStack.Push("c");

        Assert.Equal(3, newStack.Count());
        
        Assert.Equal("c", newStack.Top());
        Assert.Equal("c", newStack.Peek());
    }
    
    [Fact]
    public void IsIsEmptyWorking()
    {
        var newStack = new DataStructures.Others.Stack<int>();

        Assert.True(newStack.IsEmpty());
        
        newStack.Push(1);
        
        Assert.False(newStack.IsEmpty());
        
        newStack.Pop();
        
        Assert.True(newStack.IsEmpty());
    }
}