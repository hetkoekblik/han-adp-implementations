using System.Collections;

namespace han_adp_implementations.DataStructures.Others;

public class HashTable<TKey, TValue> : IEnumerable<(TKey Key, TValue Value)> where TKey : IComparable<TKey>
{
    private class Node(TKey key, TValue value)
    {
        public TKey Key { get; set; } = key;
        public TValue Value { get; set; } = value;
        public bool Deleted { get; set; }
    }
    
    private const int InitialCapacity = 5;
    
    private Node?[] _array = new Node[InitialCapacity];
    
    private int _count;
    
    public void Insert(TKey key, TValue value)
    {
        if (_count == _array.Length / 2)
        {
            Resize();
        }
        
        var index = GetHash(key);

        var i = 0;
        
        while (_array[index] != null && !_array[index]!.Deleted)
        {
            index = (index + i * i) % _array.Length;
            i++;
        }
        
        _array[index] = new Node(key, value);
        
        _count++;
    }
    
    public TValue? Get(TKey key)
    {
        var index = GetHash(key);
        
        var i = 0;
        
        while (_array[index] != null && (!_array[index]!.Key.Equals(key) || _array[index]!.Deleted))
        {
            index = (index + i * i) % _array.Length;
            i++;
        }

        return _array[index] == null || _array[index]!.Deleted ? default : _array[index]!.Value;
    }

    public void Delete(TKey key)
    {
        var index = GetHash(key);
        
        var i = 0;
        
        while (_array[index] != null && (!_array[index]!.Key.Equals(key) || _array[index]!.Deleted))
        {
            index = (index + i * i) % _array.Length;
            i++;
        }
        
        if(_array[index] == null || _array[index]!.Deleted)
            throw new KeyNotFoundException();
        
        _array[index]!.Deleted = true;
        
        _count--;
    }

    public void Update(TKey key, TValue value)
    {
        var index = GetHash(key);
        
        var i = 0;
        
        while (_array[index] != null && (!_array[index]!.Key.Equals(key) || _array[index]!.Deleted))
        {
            index = (index + i * i) % _array.Length;
            i++;
        }
        
        if (_array[index] == null || _array[index]!.Deleted)
            throw new KeyNotFoundException();
        
        _array[index]!.Value = value;
    }

    private void Resize()
    {
        var oldArray = _array;
        _array = new Node?[NextPrime(_array.Length * 2)];
        
        foreach (var node in oldArray)
        {
            if (node == null)
            {
                continue;
            }
            
            var index = GetHash(node.Key);

            var i = 0;
            
            while (_array[index] != null)
            {
                index = (index + i * i) % _array.Length;
                i++;
            }
            
            _array[index] = node;
        }
    }

    private int GetHash(TKey key)
    {
        var keyString = key.ToString();

        var hash = 0;
        
        if(keyString == null)
            throw new ArgumentNullException(nameof(key), "ToString() on key returned null");
        
        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator (disabled because resharper kept trying to convert it to a linq query)
        foreach (var c in keyString)
        {
            hash = hash * 31 + c;
        }
        
        if (hash < 0)
        {
            hash = -hash;
        }

        return hash % _array.Length;
    }

    private static int NextPrime(int start)
    {
        if (start < 2) return 2; 

        var candidate = start;
        
        while (!IsPrime(candidate))
        {
            candidate++;
        }
        
        return candidate;
    }
    
    private static bool IsPrime(int n)
    {
        switch (n)
        {
            case <= 1:
                return false;
            case <= 3:
                return true;
        }

        if (n % 2 == 0 || n % 3 == 0) return false;

        var limit = IntegerSquareRoot(n);
        
        for (var i = 5; i <= limit; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
    
    private static int IntegerSquareRoot(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Cannot compute square root of a negative number.");

        var left = 0;
        var right = n;
        
        while (left <= right)
        {
            var mid = (left + right) / 2;
            var sq = (long)mid * mid;

            if (sq == n)
            {
                return mid;
            }

            if (sq < n)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        
        return right;
    }

    public IEnumerator<(TKey Key, TValue Value)> GetEnumerator()
    {
        foreach (var node in _array)
        {
            if (node is { Deleted: false })
            {
                yield return (node.Key, node.Value);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}