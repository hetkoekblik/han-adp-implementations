namespace han_adp_implementations.DataStructures.Others;

public class Stack<T> : IDataStructure<T>
{
    private class Node(T value, Node? next)
    {
        public T Value { get; set; } = value;
        public Node? Next { get; set; } = next;
    }
    
    private Node? _head;
    
    private int _count;
    
    public void Push(T item)
    {
        var newNode = new Node(item, _head);
        
        _head = newNode;
        
        _count++;
    }
    
    public T Pop()
    {
        if (_head == null)
        {
            throw new InvalidOperationException();
        }
        
        var value = _head.Value;
        
        _head = _head.Next;
        
        _count--;
        
        return value;
    }
    
    public T Top()
    {
        if (_head == null)
        {
            throw new InvalidOperationException();
        }
        
        return _head.Value;
    }
    
    public T Peek()
    {
        var value = Top();
        
        if(value == null)
            throw new InvalidOperationException();

        return value;
    }
    
    public bool IsEmpty()
    {
        return _head == null;
    }
    
    public int Count()
    {
        return _count;
    }
}