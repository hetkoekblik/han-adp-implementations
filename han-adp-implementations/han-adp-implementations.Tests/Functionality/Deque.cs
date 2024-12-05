using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class Deque
{
    [Fact]
    public void IsInsertLeftAndDeleteLeftAndCountWorking()
    {
        var newDeque = new DataStructures.Others.Deque<int>();
        
        newDeque.InsertLeft(1);
        newDeque.InsertLeft(2);
        newDeque.InsertLeft(3);

        Assert.Equal(3, newDeque.Count());
        
        Assert.Equal(3, newDeque.DeleteLeft());
        Assert.Equal(2, newDeque.DeleteLeft());
        Assert.Equal(1, newDeque.DeleteLeft());
    }

    [Fact]
    public void IsInsertRightAndDeleteRightWorking()
    {
        var newDeque = new DataStructures.Others.Deque<int>();
        
        newDeque.InsertRight(1);
        newDeque.InsertRight(2);
        newDeque.InsertRight(3);

        Assert.Equal(3, newDeque.Count());
        
        Assert.Equal(3, newDeque.DeleteRight());
        Assert.Equal(2, newDeque.DeleteRight());
        Assert.Equal(1, newDeque.DeleteRight());
    }
}