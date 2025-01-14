using Xunit;

namespace han_adp_implementations.Tests.Functionality;

public class Graph
{
    [Fact]
    public void IsAddVertexAndGetWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        
        Assert.Equal("A", graph.GetVertex("A")?.Name);
        Assert.Equal("B", graph.GetVertex("B")?.Name);
        Assert.Equal("C", graph.GetVertex("C")?.Name);
    }
    
    [Fact]
    public void IsAddEdgeWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 2);
        
        Assert.Equal(1, graph.GetVertex("A")?.Edges[0].Weight);
        Assert.Equal(2, graph.GetVertex("A")?.Edges[1].Weight);
    }
    
    [Fact]
    public void IsRemoveVertexWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 2);
        
        graph.RemoveVertex("A");
        
        Assert.Null(graph.GetVertex("A"));
    }
    
    [Fact]
    public void IsRemoveEdgeWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 2);
        
        graph.RemoveEdge("A", "B");
        
        Assert.Equal(2, graph.GetVertex("A")?.Edges[0].Weight);
    }

    [Fact]
    public void IsPathUnweightedWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        graph.AddVertex("D");
        graph.AddVertex("E");
        
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 1);
        graph.AddEdge("B", "D", 1);
        graph.AddEdge("C", "D", 1);
        graph.AddEdge("D", "E", 1);
        
        graph.PathUnweighted("A");
        
        Assert.Equal(0, graph.GetVertex("A")?.Distance);
        Assert.Equal(1, graph.GetVertex("B")?.Distance);
        Assert.Equal(1, graph.GetVertex("C")?.Distance);
        Assert.Equal(2, graph.GetVertex("D")?.Distance);
        Assert.Equal(3, graph.GetVertex("E")?.Distance);
    }
    
    [Fact]
    public void IsPathDijkstraWorking()
    {
        var graph = new DataStructures.Others.Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        graph.AddVertex("D");
        graph.AddVertex("E");
        
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 2);
        graph.AddEdge("B", "D", 3);
        graph.AddEdge("C", "D", 4);
        graph.AddEdge("D", "E", 5);
        
        graph.PathDijkstra("A");
        
        Assert.Equal(0, graph.GetVertex("A")?.Distance);
        Assert.Equal(1, graph.GetVertex("B")?.Distance);
        Assert.Equal(2, graph.GetVertex("C")?.Distance);
        Assert.Equal(4, graph.GetVertex("D")?.Distance);
        Assert.Equal(9, graph.GetVertex("E")?.Distance);
    }
}