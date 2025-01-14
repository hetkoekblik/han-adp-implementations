using System.Collections;

namespace han_adp_implementations.Algorithms;

public static class Sorting
{
    public static T[] InsertionSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var itemsArray = items.ToArray();
        
        for (var i = 1; i < itemsArray.Length; i++)
        {
            var key = itemsArray[i];
            var j = i - 1;
            
            while (j >= 0 && itemsArray[j].CompareTo(key) > 0)
            {
                itemsArray[j + 1] = itemsArray[j];
                j--;
            }
            
            itemsArray[j + 1] = key;
        }
        
        return itemsArray;
    }
    
    public static T[] SelectionSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var itemsArray = items.ToArray();
        
        for (var i = 0; i < itemsArray.Length - 1; i++)
        {
            var minIndex = i;
            
            for (var j = i + 1; j < itemsArray.Length; j++)
            {
                if (itemsArray[j].CompareTo(itemsArray[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
                (itemsArray[i], itemsArray[minIndex]) = (itemsArray[minIndex], itemsArray[i]);
            }
        }
        
        return itemsArray;
    }
    
    public static T[] ParallelMergeSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var itemsArray = items.ToArray();
        
        if (itemsArray.Length <= 1)
        {
            return itemsArray;
        }
        
        var middle = itemsArray.Length / 2;
        
        var left = itemsArray.Take(middle).ToArray().ParallelMergeSort().ToArray();
        var right = itemsArray.Skip(middle).ToArray().ParallelMergeSort().ToArray();
        
        return Merge(left, right);
    }
    
    private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
    {
        var leftIndex = 0;
        var rightIndex = 0;
        
        var result = new List<T>();
        
        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left.ElementAt(leftIndex).CompareTo(right.ElementAt(rightIndex)) <= 0)
            {
                result.Add(left.ElementAt(leftIndex));
                leftIndex++;
            }
            else
            {
                result.Add(right.ElementAt(rightIndex));
                rightIndex++;
            }
        }
        
        while (leftIndex < left.Length)
        {
            result.Add(left.ElementAt(leftIndex));
            leftIndex++;
        }
        
        while (rightIndex < right.Length)
        {
            result.Add(right.ElementAt(rightIndex));
            rightIndex++;
        }
        
        return result.ToArray();
    }
    
    public static T[] QuickSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var itemsArray = items.ToArray();
        
        if (itemsArray.Length <= 1)
        {
            return itemsArray;
        }
        
        var pivot = itemsArray[itemsArray.Length / 2];
        
        var less = new List<T>();
        var greater = new List<T>();
        
        for (var i = 0; i < itemsArray.Length; i++)
        {
            if (i == itemsArray.Length / 2)
            {
                continue;
            }
            
            if (itemsArray[i].CompareTo(pivot) <= 0)
            {
                less.Add(itemsArray[i]);
            }
            else
            {
                greater.Add(itemsArray[i]);
            }
        }
        
        return QuickSort(less).Concat([pivot]).Concat(QuickSort(greater)).ToArray();
    }
}