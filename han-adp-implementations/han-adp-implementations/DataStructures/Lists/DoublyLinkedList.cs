namespace han_adp_implementations.DataStructures.Lists;

public class DoublyLinkedList<T> : IList<T>
{
    private class Node(T value, Node? next, Node? previous)
    {
        public T Value { get; set; } = value;
        public Node? Next { get; set; } = next;
        public Node? Previous { get; set; } = previous;
    }
    
    private Node? _head;
    
    private Node? _tail;
    
    private int _count;
    
    public int Count()
    {
        return _count;
    }

    public void Add(T item)
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

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        var currentNode = _head;
        
        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode?.Next;
        }

        if (currentNode != null) return currentNode.Value;
        
        throw new IndexOutOfRangeException();
    }

    public void Set(int index, T item)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        var currentNode = _head;
        
        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode?.Next;
        }

        if (currentNode != null) currentNode.Value = item;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        
        var currentNode = _head;
        
        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode?.Next;
        }

        if (currentNode == null) return;
        
        if (currentNode.Previous != null)
        {
            currentNode.Previous.Next = currentNode.Next;
        }
        else
        {
            _head = currentNode.Next;
        }
        
        if (currentNode.Next != null)
        {
            currentNode.Next.Previous = currentNode.Previous;
        }
        else
        {
            _tail = currentNode.Previous;
        }
        
        _count--;
    }

    public void Remove(T item)
    {
        var currentNode = _head;
        
        while (currentNode != null)
        {
            if (currentNode.Value != null && currentNode.Value.Equals(item))
            {
                if (currentNode.Previous != null)
                {
                    currentNode.Previous.Next = currentNode.Next;
                }
                else
                {
                    _head = currentNode.Next;
                }
        
                if (currentNode.Next != null)
                {
                    currentNode.Next.Previous = currentNode.Previous;
                }
                else
                {
                    _tail = currentNode.Previous;
                }
        
                _count--;
        
                return;
            }
        
            currentNode = currentNode.Next;
        }
    }

    public bool Contains(T item)
    {
        var currentNode = _head;
        
        while (currentNode != null)
        {
            if (currentNode.Value != null && currentNode.Value.Equals(item))
            {
                return true;
            }
        
            currentNode = currentNode.Next;
        }
        
        return false;
    }

    public int IndexOf(T item)
    {
        var currentNode = _head;
        
        var index = 0;
        
        while (currentNode != null)
        {
            if (currentNode.Value != null && currentNode.Value.Equals(item))
            {
                return index;
            }
        
            currentNode = currentNode.Next;
        
            index++;
        }
        
        return -1;
    }
}