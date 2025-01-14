using System.Text;
using System.Text.Json;
using han_adp_implementations.DataStructures.Lists;

namespace han_adp_implementations.Tests;

public static class DataRetriever
{
    public static async Task<List<T>> RetrieveSortingData<T>(string fileName, string? subName = null)
    {
        var data = await File.ReadAllTextAsync(Path.Combine("Datasets", "Sorting", $"{fileName}.json"));
        
        var json = JsonDocument.Parse(data);
        
        var root = json.RootElement;
        
        var list = new List<T>();
        
        if (subName != null)
        {
            var sub = root.GetProperty(subName);
            
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
            foreach (var item in sub.EnumerateArray())
            {
                var value = JsonSerializer.Deserialize<T>(item.GetRawText());
                
                if(value != null)
                {
                    list.Add(value);
                }
            }
        }
        else
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
            foreach (var item in root.EnumerateArray())
            {
                var value = JsonSerializer.Deserialize<T>(item.GetRawText());
                
                if(value != null)
                {
                    list.Add(value);
                }
            }
        }
        
        return list;
    }
    
    public static async Task<Dictionary<TKey, TValue>> RetrieveHashingData<TKey, TValue>(string fileName, string? subName = null) where TKey : notnull
    {
        var data = await File.ReadAllTextAsync(Path.Combine("Datasets", "Hashing", $"{fileName}.json"));
        
        var json = JsonDocument.Parse(data);
        
        var root = json.RootElement;
        
        var dict = new Dictionary<TKey, TValue>();
        
        if (subName != null)
        {
            var sub = root.GetProperty(subName);
            
            foreach (var item in sub.EnumerateObject())
            {
                var keyJson = JsonSerializer.Serialize(item.Name);
                var key = JsonSerializer.Deserialize<TKey>(keyJson);
                
                var valueString = item.Value.GetRawText().Trim('"');
                var value = JsonSerializer.Deserialize<TValue>(valueString);
                
                if (key != null && value != null) dict.Add(key, value);
            }
        }
        else
        {
            foreach (var item in root.EnumerateObject())
            {
                var keyJson = JsonSerializer.Serialize(item.Name);
                var key = JsonSerializer.Deserialize<TKey>(keyJson);
                
                var valueString = item.Value.GetRawText().Trim('"');
                var value = JsonSerializer.Deserialize<TValue>(valueString);
                
                if (key != null && value != null) dict.Add(key, value);
            }
        }
        
        return dict;
    }

    public static async Task<List<GraphingData>> RetrieveGraphingData(string fileName, string subName, GraphingType type)
    {
        var data = await File.ReadAllTextAsync(Path.Combine("Datasets", "Graphs", $"{fileName}.json"));
        
        var json = JsonDocument.Parse(data);
        
        var root = json.RootElement;
        
        var list = new List<GraphingData>();
        
        var sub = root.GetProperty(subName);

        switch (type)
        {
            case GraphingType.Lines:
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
                foreach (var item in sub.EnumerateArray())
                {
                    var from = item[0].GetInt32();
                    var to = item[1].GetInt32();
                    
                    list.Add(new GraphingData(from.ToString(), to.ToString(), 1));
                }

                break;
            case GraphingType.Connections:
                for(var i = 0; i < sub.GetArrayLength(); i++)
                {
                    // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
                    foreach (var item in sub[i].EnumerateArray())
                    {
                        var to = item.GetInt32();
                        
                        list.Add(new GraphingData(i.ToString(), to.ToString(), 1));
                    }
                }

                break;
            case GraphingType.ConnectionMatrix:
                for(var y = 0; y < sub.GetArrayLength(); y++)
                {
                    for(var x = 0; x < sub[y].GetArrayLength(); x++)
                    {
                        if(sub[y][x].GetInt32() == 1)
                        {
                            list.Add(new GraphingData(y.ToString(), x.ToString(), 1));
                        }
                    }
                }

                break;
            case GraphingType.LinesWeighted:
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
                foreach (var item in sub.EnumerateArray())
                {
                    var from = item[0].GetInt32();
                    var to = item[1].GetInt32();
                    var weight = item[2].GetInt32();
                    
                    list.Add(new GraphingData(from.ToString(), to.ToString(), weight));
                }

                break;
            case GraphingType.ConnectionsWeighted:
                for (var i = 0; i < sub.GetArrayLength(); i++)
                {
                    // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because of resharper wanting to convert it to a linq query)
                    foreach (var item in sub[i].EnumerateArray())
                    {
                        var to = item[0].GetInt32();
                        var weight = item[1].GetInt32();
                        
                        list.Add(new GraphingData(i.ToString(), to.ToString(), weight));
                    }
                }

                break;
            case GraphingType.ConnectionMatrixWeighted:
                for (var y = 0; y < sub.GetArrayLength(); y++)
                {
                    for (var x = 0; x < sub[y].GetArrayLength(); x++)
                    {
                        var weight = sub[y][x].GetInt32();
                        
                        if (weight > 0)
                        {
                            list.Add(new GraphingData(y.ToString(), x.ToString(), weight));
                        }
                    }
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return list;
    }
    
    public class GraphingData(string from, string to, int weight)
    {
        public string From { get; set; } = from;
        public string To { get; set; } = to;
        public int Weight { get; set; } = weight;
    }

    public enum GraphingType
    {
        Lines,
        Connections,
        ConnectionMatrix,
        LinesWeighted,
        ConnectionsWeighted,
        ConnectionMatrixWeighted
    }
}