using han_adp_implementations.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace han_adp_implementations.Tests;

public class Data(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task CheckIfDynamicArrayDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DynamicArray<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {newArray.Count()}");
        
        Assert.Equal(data.Count, newArray.Count());
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {newArray[i]}");
            
            Assert.Equal(data[i], newArray[i]);
        }
    }

    [Fact]
    public async Task CheckIfDoublyLinkedListDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DoublyLinkedList<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {newArray.Count()}");
        
        Assert.Equal(data.Count, newArray.Count());
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {newArray[i]}");
            
            Assert.Equal(data[i], newArray[i]);
        }
    }

    [Fact]
    public async Task CheckIfStackDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newStack = new DataStructures.Others.Stack<int>();
        
        foreach (var item in data)
        {
            newStack.Push(item);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewStack length: {newStack.Count()}");
        
        Assert.Equal(data.Count, newStack.Count());
        
        data.Reverse();
        
        foreach (var newT in data)
        {
            var t = newStack.Pop();
            
            testOutputHelper.WriteLine($"Data: {newT} - NewStack: {t}");
            
            Assert.Equal(newT, t);
        }
    }

    [Fact]
    public async Task CheckIfDequeDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newDeque = new DataStructures.Others.Deque<int>();
        
        foreach (var item in data)
        {
            newDeque.InsertLeft(item);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewDeque length: {newDeque.Count()}");
        
        Assert.Equal(data.Count, newDeque.Count());
        
        foreach (var newT in data)
        {
            var t = newDeque.DeleteRight();
            
            testOutputHelper.WriteLine($"Data: {newT} - NewDeque: {t}");
            
            Assert.Equal(newT, t);
        }
    }
    
    [Fact]
    public async Task CheckIfPriorityQueueDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newQueue = new DataStructures.Others.PriorityQueue<int>();
        
        foreach (var item in data)
        {
            newQueue.Add(item);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewQueue length: {newQueue.Count()}");
        
        Assert.Equal(data.Count, newQueue.Count());
        
        data.Sort();
        
        foreach (var newT in data)
        {
            var t = newQueue.Poll();
            
            testOutputHelper.WriteLine($"Data: {newT} - NewQueue: {t}");
            
            Assert.Equal(newT, t);
        }
    }

    [Fact]
    public async Task CheckIfHashTableDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveHashingData<string, int[]>("dataset_hashing", "hashtabelsleutelswaardes");
        
        var newHashTable = new DataStructures.Others.HashTable<string, int[]>();
        
        foreach (var item in data)
        {
            newHashTable.Insert(item.Key, item.Value);
        }
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewHashTable length: {newHashTable.Count()}");
        
        Assert.Equal(data.Count, newHashTable.Count());
        
        foreach (var item in data)
        {
            var t = newHashTable.Get(item.Key);

            if (t == null) continue;
            
            testOutputHelper.WriteLine($"Data: {string.Join(',', item.Value)} - NewHashTable: {string.Join(',', t)}");

            Assert.Equal(item.Value, t);
        }
    }
    
    [Fact]
    public async Task CheckIfBinaryTreeDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newTree = new DataStructures.Trees.BinaryTree<int>();
        
        foreach (var item in data)
        {
            newTree.Insert(item);
        }
        
        foreach (var newT in data)
        {
            var t = newTree.Find(newT);
            
            testOutputHelper.WriteLine($"Data: {newT} - NewTree: {t}");
            
            Assert.Equal(newT, t);
        }
    }

    [Fact]
    public async Task CheckIfAVLDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newTree = new DataStructures.Trees.AVL<int>();
        
        foreach (var item in data)
        {
            newTree.Insert(item);
        }
        
        foreach (var newT in data)
        {
            var t = newTree.Find(newT);
            
            testOutputHelper.WriteLine($"Data: {newT} - NewTree: {t}");
            
            Assert.Equal(newT, t);
        }
    }

    [Fact]
    public async Task CheckIfGraphDataIsCorrect()
    {
        var lineData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "lijnlijst", DataRetriever.GraphingType.Lines);
        
        var lineGraph = new DataStructures.Others.Graph();
        
        foreach (var item in lineData)
        {
            lineGraph.AddVertex(item.From);
            lineGraph.AddVertex(item.To);
            
            lineGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in lineData)
        {
            var t = lineGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - LineGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = lineGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - LineGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = lineGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - LineGraph: {edge?.Weight}");
            
            Assert.Equal(1, edge?.Weight);
        }
        
        var connectionData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "verbindingslijst", DataRetriever.GraphingType.Connections);
        
        var connectionGraph = new DataStructures.Others.Graph();
        
        foreach (var item in connectionData)
        {
            connectionGraph.AddVertex(item.From);
            connectionGraph.AddVertex(item.To);
            
            connectionGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in connectionData)
        {
            var t = connectionGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - ConnectionGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = connectionGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - ConnectionGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = connectionGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - ConnectionGraph: {edge?.Weight}");
            
            Assert.Equal(1, edge?.Weight);
        }
        
        var matrixData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "verbindingsmatrix", DataRetriever.GraphingType.ConnectionMatrix);
        
        var matrixGraph = new DataStructures.Others.Graph();
        
        foreach (var item in matrixData)
        {
            matrixGraph.AddVertex(item.From);
            matrixGraph.AddVertex(item.To);
            
            matrixGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in matrixData)
        {
            var t = matrixGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - MatrixGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = matrixGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - MatrixGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = matrixGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - MatrixGraph: {edge?.Weight}");
            
            Assert.Equal(1, edge?.Weight);
        }
        
        var weightedLineData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "lijnlijst_gewogen", DataRetriever.GraphingType.LinesWeighted);
        
        var weightedLineGraph = new DataStructures.Others.Graph();
        
        foreach (var item in weightedLineData)
        {
            weightedLineGraph.AddVertex(item.From);
            weightedLineGraph.AddVertex(item.To);
            
            weightedLineGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in weightedLineData)
        {
            var t = weightedLineGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - WeightedLineGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = weightedLineGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - WeightedLineGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = weightedLineGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - WeightedLineGraph: {edge?.Weight}");
            
            Assert.Equal(item.Weight, edge?.Weight);
        }
        
        var weightedConnectionData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "verbindingslijst_gewogen", DataRetriever.GraphingType.ConnectionsWeighted);
        
        var weightedConnectionGraph = new DataStructures.Others.Graph();
        
        foreach (var item in weightedConnectionData)
        {
            weightedConnectionGraph.AddVertex(item.From);
            weightedConnectionGraph.AddVertex(item.To);
            
            weightedConnectionGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in weightedConnectionData)
        {
            var t = weightedConnectionGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - WeightedConnectionGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = weightedConnectionGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - WeightedConnectionGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = weightedConnectionGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - WeightedConnectionGraph: {edge?.Weight}");
            
            Assert.Equal(item.Weight, edge?.Weight);
        }
        
        var weightedMatrixData = await DataRetriever.RetrieveGraphingData("dataset_graphs", "verbindingsmatrix_gewogen", DataRetriever.GraphingType.ConnectionMatrixWeighted);
        
        var weightedMatrixGraph = new DataStructures.Others.Graph();
        
        foreach (var item in weightedMatrixData)
        {
            weightedMatrixGraph.AddVertex(item.From);
            weightedMatrixGraph.AddVertex(item.To);
            
            weightedMatrixGraph.AddEdge(item.From, item.To, item.Weight);
        }
        
        foreach (var item in weightedMatrixData)
        {
            var t = weightedMatrixGraph.GetVertex(item.From);
            
            testOutputHelper.WriteLine($"Data (from): {item.From} - WeightedMatrixGraph: {t?.Name}");
            
            Assert.Equal(item.From, t?.Name);
            
            t = weightedMatrixGraph.GetVertex(item.To);
            
            testOutputHelper.WriteLine($"Data (to): {item.To} - WeightedMatrixGraph: {t?.Name}");
            
            Assert.Equal(item.To, t?.Name);
            
            var edge = weightedMatrixGraph.GetEdge(item.From, item.To);
            
            testOutputHelper.WriteLine($"Data (edge): {item.From} -> {item.To} - WeightedMatrixGraph: {edge?.Weight}");
            
            Assert.Equal(item.Weight, edge?.Weight);
        }
    }

    [Fact]
    public async Task CheckIfInsertionSortDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DynamicArray<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        var sorted = newArray.InsertionSort();
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {sorted.Length}");
        
        Assert.Equal(data.Count, sorted.Length);
        
        data.Sort();
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {sorted[i]}");
            
            Assert.Equal(data[i], sorted[i]);
        }
    }
    
    [Fact]
    public async Task CheckIfSelectionSortDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DynamicArray<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        var sorted = newArray.SelectionSort();
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {sorted.Length}");
        
        Assert.Equal(data.Count, sorted.Length);
        
        data.Sort();
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {sorted[i]}");
            
            Assert.Equal(data[i], sorted[i]);
        }
    }

    [Fact]
    public async Task CheckIfParallelMergeSortDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DynamicArray<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        var sorted = newArray.ParallelMergeSort();
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {sorted.Length}");
        
        Assert.Equal(data.Count, sorted.Length);
        
        data.Sort();
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {sorted[i]}");
            
            Assert.Equal(data[i], sorted[i]);
        }
    }
    
    [Fact]
    public async Task CheckIfQuickSortDataIsCorrect()
    {
        var data = await DataRetriever.RetrieveSortingData<int>("dataset_sorting", "lijst_willekeurig_10000");
        
        var newArray = new DataStructures.Lists.DynamicArray<int>();
        
        foreach (var item in data)
        {
            newArray.Add(item);
        }
        
        var sorted = newArray.QuickSort();
        
        testOutputHelper.WriteLine($"Data length: {data.Count} - NewArray length: {sorted.Length}");
        
        Assert.Equal(data.Count, sorted.Length);
        
        data.Sort();
        
        for (var i = 0; i < data.Count; i++)
        {
            testOutputHelper.WriteLine($"Data: {data[i]} - NewArray: {sorted[i]}");
            
            Assert.Equal(data[i], sorted[i]);
        }
    }
}