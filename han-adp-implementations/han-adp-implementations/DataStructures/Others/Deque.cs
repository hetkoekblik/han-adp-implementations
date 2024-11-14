namespace han_adp_implementations.DataStructures.Others;

public class Deque<T> : IDataStructure<T>
{
    private class Node(T value, Node? next, Node? prev)
    {
        public T Value { get; set; } = value;
        public Node? Next { get; set; } = next;
        public Node? Prev { get; set; } = prev;
    }
    
    private Node? _head;
    
    private Node? _tail;
    
    private int _count;
    
    public void InsertLeft(T item)
    {
        var newNode = new Node(item, _head, null);
        
        if (_head != null)
        {
            _head.Prev = newNode;
        }
        
        _head = newNode;
        
        _tail ??= newNode;
        
        _count++;
    }
    
    public void InsertRight(T item)
    {
        var newNode = new Node(item, null, _tail);
        
        if (_tail != null)
        {
            _tail.Next = newNode;
        }
        
        _tail = newNode;
        
        _head ??= newNode;
        
        _count++;
    }
    
    public T DeleteLeft()
    {
        if (_head == null)
        {
            throw new InvalidOperationException();
        }
        
        var value = _head.Value;
        
        _head = _head.Next;
        
        if (_head != null)
        {
            _head.Prev = null;
        }
        
        _count--;
        
        return value;
    }
    
    public T DeleteRight()
    {
        if (_tail == null)
        {
            throw new InvalidOperationException();
        }
        
        var value = _tail.Value;
        
        _tail = _tail.Prev;
        
        if (_tail != null)
        {
            _tail.Next = null;
        }
        
        _count--;
        
        return value;
    }
    
    public int Count()
    {
        return _count;
    }
}