namespace han_adp_implementations.DataStructures.Lists;

public class DynamicArray<T> : IList<T>
{
    private T[] _array = new T[1];
    
    private int _count;

    public int Count()
    {
        return _count;
    }

    public void Add(T item)
    {
        if (_count == _array.Length)
        {
            var newArray = new T[_array.Length * 2];
            
            for (var i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }
            
            _array = newArray;
        }
        
        _array[_count] = item;
        _count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        return _array[index];
    }

    public void Set(int index, T item)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        _array[index] = item;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        for (var i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
        
        _count--;
    }

    public void Remove(T item)
    {
        var index = IndexOf(item);
        
        if (index != -1)
        {
            Remove(index);
        }
    }

    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    public int IndexOf(T item)
    {
        for (var i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_array[i], item))
            {
                return i;
            }
        }
        
        return -1;
    }
}