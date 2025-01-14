using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class BinaryTree
{
    [Fact]
    public void IsFindFindMinFindMaxAndInsertWorking()
    {
        var newTree = new DataStructures.Trees.BinaryTree<int>();

        newTree.Insert(4);
        newTree.Insert(2);
        newTree.Insert(6);
        newTree.Insert(1);
        newTree.Insert(3);
        newTree.Insert(5);
        
        Assert.Equal(4, newTree.Find(4));
        
        Assert.Equal(1, newTree.FindMin());
        
        Assert.Equal(6, newTree.FindMax());
    }
    
    [Fact]
    public void IsRemoveWorking()
    {
        var newTree = new DataStructures.Trees.BinaryTree<string>();

        newTree.Insert("d");
        newTree.Insert("b");
        newTree.Insert("f");
        newTree.Insert("a");
        newTree.Insert("c");
        newTree.Insert("e");
        
        newTree.Remove("b");
        
        Assert.Null(newTree.Find("b"));
        
        Assert.Equal("d", newTree.Find("d"));
        Assert.Equal("f", newTree.Find("f"));
        Assert.Equal("a", newTree.Find("a"));
        Assert.Equal("c", newTree.Find("c"));
        Assert.Equal("e", newTree.Find("e"));
    }
}