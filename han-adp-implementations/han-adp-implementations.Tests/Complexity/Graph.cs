using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests.Complexity;

public class Graph(ITestOutputHelper testOutputHelper)
{
    private const string Dataset = "dataset_graphs";
    private const string Data = "lijnlijst";
    private const string DataWeighted = "lijnlijst_gewogen";
    
    [Fact]
    public async Task CheckAddComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, Data, DataRetriever.GraphingType.Lines);
        
        var graphFull = new DataStructures.Others.Graph();
        
        var watch = Stopwatch.StartNew();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, 1);
        }
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 4; i++)
        {
            graphQuarter.AddVertex(data[i].From);
            graphQuarter.AddVertex(data[i].To);
            
            graphQuarter.AddEdge(data[i].From, data[i].To, 1);
        }
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 2; i++)
        {
            graphHalf.AddVertex(data[i].From);
            graphHalf.AddVertex(data[i].To);
            
            graphHalf.AddEdge(data[i].From, data[i].To, 1);
        }
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }

    [Fact]
    public async Task CheckRemoveVertexComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, Data, DataRetriever.GraphingType.Lines);
        
        var graphFull = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, 1);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var newT in data)
        {
            if(graphFull.GetVertex(newT.From) != null)
            {
                graphFull.RemoveVertex(newT.From);
            }
        }
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphQuarter.AddVertex(item.From);
            graphQuarter.AddVertex(item.To);
            
            graphQuarter.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 4; i++)
        {
            if (graphQuarter.GetVertex(data[i].From) != null)
            {
                graphQuarter.RemoveVertex(data[i].From);
            }
        }
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphHalf.AddVertex(item.From);
            graphHalf.AddVertex(item.To);
            
            graphHalf.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 2; i++)
        {
            if (graphHalf.GetVertex(data[i].From) != null)
            {
                graphHalf.RemoveVertex(data[i].From);
            }
        }
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }
    
    [Fact]
    public async Task CheckRemoveEdgeComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, Data, DataRetriever.GraphingType.Lines);
        
        var graphFull = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, 1);
        }
        
        var watch = Stopwatch.StartNew();
        
        for (var i = data.Count - 1; i >= 0; i--)
        {
            graphFull.RemoveEdge(data[i].From, data[i].To);
        }
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphQuarter.AddVertex(item.From);
            graphQuarter.AddVertex(item.To);
            
            graphQuarter.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = (data.Count - 1) / 4; i >= 0; i--)
        {
            graphQuarter.RemoveEdge(data[i].From, data[i].To);
        }
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphHalf.AddVertex(item.From);
            graphHalf.AddVertex(item.To);
            
            graphHalf.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = (data.Count - 1) / 2; i >= 0; i--)
        {
            graphHalf.RemoveEdge(data[i].From, data[i].To);
        }
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }
    
    [Fact]
    public async Task CheckGetVertexComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, Data, DataRetriever.GraphingType.Lines);
        
        var graphFull = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, 1);
        }
        
        var watch = Stopwatch.StartNew();
        
        foreach (var newT in data)
        {
            graphFull.GetVertex(newT.From);
            graphFull.GetVertex(newT.To);
        }
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphQuarter.AddVertex(item.From);
            graphQuarter.AddVertex(item.To);
            
            graphQuarter.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 4; i++)
        {
            graphQuarter.GetVertex(data[i].From);
            graphQuarter.GetVertex(data[i].To);
        }
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphHalf.AddVertex(item.From);
            graphHalf.AddVertex(item.To);
            
            graphHalf.AddEdge(item.From, item.To, 1);
        }
        
        watch.Restart();
        
        for (var i = 0; i < data.Count / 2; i++)
        {
            graphHalf.GetVertex(data[i].From);
            graphHalf.GetVertex(data[i].To);
        }
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }

    [Fact]
    public async Task CheckPathUnweightedComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, Data, DataRetriever.GraphingType.Lines);
        
        var graphFull = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, 1);
        }
        
        var watch = Stopwatch.StartNew();
        
        graphFull.PathUnweighted(data[0].From);
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        for(var i = 0; i < data.Count / 4; i++)
        {
            graphQuarter.AddVertex(data[i].From);
            graphQuarter.AddVertex(data[i].To);
            
            graphQuarter.AddEdge(data[i].From, data[i].To, 1);
        }
        
        watch.Restart();
        
        graphQuarter.PathUnweighted(data[0].From);
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        for(var i = 0; i < data.Count / 2; i++)
        {
            graphHalf.AddVertex(data[i].From);
            graphHalf.AddVertex(data[i].To);
            
            graphHalf.AddEdge(data[i].From, data[i].To, 1);
        }
        
        watch.Restart();
        
        graphHalf.PathUnweighted(data[0].From);
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }
    
    [Fact]
    public async Task CheckPathDijkstraComplexity()
    {
        var data = await DataRetriever.RetrieveGraphingData(Dataset, DataWeighted, DataRetriever.GraphingType.LinesWeighted);
        
        var graphFull = new DataStructures.Others.Graph();
        
        foreach (var item in data)
        {
            graphFull.AddVertex(item.From);
            graphFull.AddVertex(item.To);
            
            graphFull.AddEdge(item.From, item.To, item.Weight);
        }
        
        var watch = Stopwatch.StartNew();
        
        graphFull.PathDijkstra(data[0].From);
        
        watch.Stop();
        
        var elapsedFull = watch.ElapsedTicks;
        
        var graphQuarter = new DataStructures.Others.Graph();
        
        for(var i = 0; i < data.Count / 4; i++)
        {
            graphQuarter.AddVertex(data[i].From);
            graphQuarter.AddVertex(data[i].To);
            
            graphQuarter.AddEdge(data[i].From, data[i].To, data[i].Weight);
        }
        
        watch.Restart();
        
        graphQuarter.PathDijkstra(data[0].From);
        
        watch.Stop();
        
        var elapsedQuarter = watch.ElapsedTicks;
        
        var graphHalf = new DataStructures.Others.Graph();
        
        for(var i = 0; i < data.Count / 2; i++)
        {
            graphHalf.AddVertex(data[i].From);
            graphHalf.AddVertex(data[i].To);
            
            graphHalf.AddEdge(data[i].From, data[i].To, data[i].Weight);
        }
        
        watch.Restart();
        
        graphHalf.PathDijkstra(data[0].From);
        
        watch.Stop();
        
        var elapsedHalf = watch.ElapsedTicks;
        
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 4} items: {elapsedQuarter} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count / 2} items: {elapsedHalf} ticks");
        testOutputHelper.WriteLine($"Elapsed time for {data.Count} items: {elapsedFull} ticks");
    }
}