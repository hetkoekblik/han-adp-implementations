using System.Collections;

namespace han_adp_implementations.DataStructures.Others;

public class Graph
{
    private HashTable<string, Vertex?> _vertices = new();
    
    public class Vertex(string name)
    {
        public string Name { get; set; } = name;
        public List<Edge> Edges { get; } = [];
        
        public double Distance { get; set; } = double.PositiveInfinity;
        public Vertex? Previous { get; set; } = null;
        
        public bool Processed { get; set; } = false;
    }
    
    public class Edge(Vertex to, int weight)
    {
        public Vertex To { get; set; } = to;
        public int Weight { get; set; } = weight;
    }
    
    public void AddVertex(string name)
    {
        if (_vertices.Get(name) != null)
            return;
        
        _vertices.Insert(name, new Vertex(name));
    }
    
    public void AddEdge(string from, string to, int weight)
    {
        var fromVertex = _vertices.Get(from);
        var toVertex = _vertices.Get(to);
        
        if (fromVertex == null || toVertex == null)
        {
            throw new InvalidOperationException();
        }
        
        if(fromVertex.Edges.Any(e => e.To == toVertex))
            return;
        
        fromVertex.Edges.Add(new Edge(toVertex, weight));
    }
    
    public void RemoveVertex(string name)
    {
        var vertex = _vertices.Get(name);
        
        if (vertex == null)
        {
            throw new InvalidOperationException();
        }
        
        foreach (var (_, value) in _vertices)
        {
            if (value == null) continue;
            
            for (var i = 0; i < value.Edges.Count; i++)
            {
                if (value.Edges[i].To == vertex)
                {
                    value.Edges.Remove(value.Edges[i]);
                }
            }
        }
        
        _vertices.Delete(name);
    }
    
    public void RemoveEdge(string from, string to)
    {
        var fromVertex = _vertices.Get(from);
        var toVertex = _vertices.Get(to);
        
        if (fromVertex == null || toVertex == null)
        {
            throw new InvalidOperationException();
        }
        
        for (var i = 0; i < fromVertex.Edges.Count; i++)
        {
            if (fromVertex.Edges[i].To == toVertex)
            {
                fromVertex.Edges.Remove(fromVertex.Edges[i]);
            }
        }
    }

    public Vertex? GetVertex(string name)
    {
        return _vertices.Get(name);
    }
    
    public Edge? GetEdge(string from, string to)
    {
        var fromVertex = _vertices.Get(from);
        var toVertex = _vertices.Get(to);
        
        if (fromVertex == null || toVertex == null)
        {
            throw new InvalidOperationException();
        }
        
        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a LINQ query)
        foreach (var edge in fromVertex.Edges)
        {
            if (edge.To == toVertex)
            {
                return edge;
            }
        }
        
        return null;
    }

    private void ClearPaths()
    {
        foreach (var (_, value) in _vertices)
        {
            if (value == null) continue;
            
            value.Distance = double.PositiveInfinity;
            value.Previous = null;
            value.Processed = false;
        }
    }
    
    public void PathUnweighted(string start)
    {
        var startVertex = GetVertex(start);
        
        if (startVertex == null)
        {
            throw new InvalidOperationException();
        }
        
        ClearPaths();
        
        startVertex.Distance = 0;
        
        var queue = new Queue<Vertex>();
        queue.Enqueue(startVertex);
        
        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();
            
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator (disabled due to resharper wanting to turn this into a LINQ query)
            foreach (var edge in currentVertex.Edges)
            {
                var toVertex = edge.To;

                if (!double.IsPositiveInfinity(toVertex.Distance)) continue;
                
                toVertex.Distance = currentVertex.Distance + 1;
                toVertex.Previous = currentVertex;
                queue.Enqueue(toVertex);
            }
        }
    }
    
    public void PathDijkstra(string start)
    {
        var startVertex = GetVertex(start);
        
        if (startVertex == null)
        {
            throw new InvalidOperationException();
        }
        
        ClearPaths();
        
        startVertex.Distance = 0;
        
        var priorityQueue = new PriorityQueue<Path>();
        priorityQueue.Add(new Path(startVertex, 0));

        var nodesSeen = 0;
        while (priorityQueue.Count() > 0 && nodesSeen < _vertices.Count())
        {
            var currentPath = priorityQueue.Poll();
            var currentVertex = currentPath.Destination;
            
            if (currentVertex.Processed) continue;
            
            currentVertex.Processed = true;
            nodesSeen++;
            
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator (disabled due to resharper wanting to turn this into a LINQ query)
            foreach (var edge in currentVertex.Edges)
            {
                var toVertex = edge.To;
                var toCost = edge.Weight;
                
                if(toCost < 0)
                    throw new InvalidOperationException("Graph has negative edges");

                if (!(toVertex.Distance > currentVertex.Distance + toCost)) continue;
                
                toVertex.Distance = currentVertex.Distance + toCost;
                toVertex.Previous = currentVertex;
                priorityQueue.Add(new Path(toVertex, toVertex.Distance));
            }
        }
    }

    public class Path(Vertex destination, double cost) : IComparable<Path>
    {
        public readonly Vertex Destination = destination;
        private readonly double _cost = cost;

        public int CompareTo(Path? other)
        {
            return other == null ? 1 : _cost.CompareTo(other._cost);
        }
    }
}