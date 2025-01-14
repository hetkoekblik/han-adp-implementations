namespace han_adp_implementations.DataStructures.Trees;

public class AVL<T> where T : IComparable<T>
{
    private class Node(T value, Node? left, Node? right, int amount = 1)
    {
        public T Value { get; set; } = value;
        public Node? Left { get; set; } = left;
        public Node? Right { get; set; } = right;
        public int Amount { get; set; } = amount;
    }
    
    private Node? _root;
    
    public T? Find(T item)
    {
        return Find(_root, item);
    }
    
    private static T? Find(Node? node, T item)
    {
        while (node != null)
        {
            switch (item.CompareTo(node.Value))
            {
                case < 0:
                    node = node.Left;
                    break;
                case > 0:
                    node = node.Right;
                    break;
                default:
                    return node.Value;
            }
        }

        return default;
    }
    
    public T? FindMin()
    {
        return _root == null ? default : FindMin(_root).Value;
    }
    
    public T? FindMax()
    {
        return _root == null ? default : FindMax(_root).Value;
    }
    
    public void Insert(T item)
    {
        if (_root == null)
        {
            _root = new Node(item, null, null);
        }
        else
        {
            Insert(_root, item);
        }
    }
    
    private static Node Insert(Node node, T item)
    {
        if (node == null)
        {
            return new Node(item, null, null);
        }
        
        switch (item.CompareTo(node.Value))
        {
            case < 0:
                node.Left = Insert(node.Left, item);
                break;
            case > 0:
                node.Right = Insert(node.Right, item);
                break;
            default:
                node.Amount++;
                break;
        }

        return Balance(node);
    }
    
    private static Node Balance(Node node)
    {
        var balance = GetBalance(node);
        
        if (balance > 1)
        {
            if (GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left!);
            }
            
            return RotateRight(node);
        }
        
        if (balance < -1)
        {
            if (GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right!);
            }
            
            return RotateLeft(node);
        }

        return node;
    }
    
    private static int GetBalance(Node node)
    {
        return GetHeight(node.Left) - GetHeight(node.Right);
    }
    
    private static int GetHeight(Node? node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }
    
    private static Node RotateLeft(Node node)
    {
        var pivot = node.Right!;
        
        node.Right = pivot.Left;
        pivot.Left = node;
        
        return pivot;
    }
    
    private static Node RotateRight(Node node)
    {
        var pivot = node.Left!;
        
        node.Left = pivot.Right;
        pivot.Right = node;
        
        return pivot;
    }
    
    public void Remove(T item)
    {
        _root = Remove(_root, item);
    }
    
    private static Node? Remove(Node? node, T item)
    {
        if (node == null)
            return null;
        
        switch (item.CompareTo(node.Value))
        {
            case < 0:
                node.Left = Remove(node.Left, item);
                break;
            case > 0:
                node.Right = Remove(node.Right, item);
                break;
            default:
                if(node.Amount > 1)
                {
                    node.Amount--;
                    return node;
                }
                
                if (node.Left == null || node.Right == null)
                {
                    node = node.Left ?? node.Right;
                }
                else
                {
                    var minNode = FindMin(node.Right);
                    
                    node.Value = minNode.Value;
                    node.Right = Remove(node.Right, minNode.Value);
                }
                break;
        }

        return node != null ? Balance(node) : null;
    }
    
    private static Node FindMin(Node node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        
        return node;
    }
    
    private static Node FindMax(Node node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }
        
        return node;
    }
}