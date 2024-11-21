using System.Text;
using System.Text.Json;

namespace han_adp_implementations.Tests;

public class DataRetriever
{
    public class SortingData
    {
        public int[] lijst_aflopend_2 { get; set; }
        public int[] lijst_oplopend_2 { get; set; }
        public double[] lijst_float_8001 { get; set; }
        public int[] lijst_gesorteerd_aflopend_3 { get; set; }
        public int[] lijst_gesorteerd_oplopend_3 { get; set; }
        public int[] lijst_herhaald_1000 { get; set; }
        public object[] lijst_leeg_0 { get; set; }
        public object[] lijst_null_1 { get; set; }
        public int?[] lijst_null_3 { get; set; }
        public object[] lijst_onsorteerbaar_3 { get; set; }
        public int[] lijst_oplopend_10000 { get; set; }
        public int[] lijst_willekeurig_10000 { get; set; }
        public int[] lijst_willekeurig_3 { get; set; }
    }
    
    public static async Task<SortingData> RetrieveSortingData()
    {
        var data = await File.ReadAllTextAsync("dataset_sorteren.json");

        var dataObject = await JsonSerializer.DeserializeAsync<SortingData>(new MemoryStream(Encoding.UTF8.GetBytes(data)));

        if (dataObject != null) return dataObject;
        
        throw new Exception("Data could not be retrieved");
    }
}