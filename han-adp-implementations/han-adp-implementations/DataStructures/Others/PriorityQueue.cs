namespace han_adp_implementations.DataStructures.Others;

public class PriorityQueue<T> : IDataStructure<T> where T : IComparable<T>
{
    private T[] _items = new T[1];
    
    private int _count;
    
    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            
            for (var i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            
            _items = newItems;
        }
        
        _items[_count] = item;
        _count++;
    }
    
    public T Peek()
    {
        var minIndex = 0;
        
        for (var i = 1; i < _count; i++)
        {
            if (_items[i].CompareTo(_items[minIndex]) < 0)
            {
                minIndex = i;
            }
        }
        
        return _items[minIndex];
    }
    
    public T Poll()
    {
        var minIndex = 0;
        
        for (var i = 1; i < _count; i++)
        {
            if (_items[i].CompareTo(_items[minIndex]) < 0)
            {
                minIndex = i;
            }
        }
        
        var value = _items[minIndex];
        
        for (var i = minIndex; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        
        _count--;
        
        return value;
    }
    
    public int Count()
    {
        return _count;
    }
}