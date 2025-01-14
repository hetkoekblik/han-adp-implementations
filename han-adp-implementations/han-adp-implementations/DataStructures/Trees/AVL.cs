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
        while (true)
        {
            if (node == null)
            {
                return default;
            }

            switch (item.CompareTo(node.Value))
            {
                case < 0:
                    node = node.Left;
                    continue;
                case > 0:
                    node = node.Right;
                    continue;
                default:
                    return node.Value;
            }
        }
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
        _root = Insert(_root, item);
    }
    
    private static Node? Insert(Node? node, T item)
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
    
    private static Node? Balance(Node? node)
    {
        if (node == null)
        {
            return null;
        }

        var balance = GetBalance(node);

        switch (balance)
        {
            case > 1:
            {
                if (node.Left != null && GetBalance(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }
            case < -1:
            {
                if (node.Right != null && GetBalance(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }
            default:
                return node;
        }
    }
    
    private static int GetBalance(Node node)
    {
        return GetHeight(node.Left) - GetHeight(node.Right);
    }
    
    private static int GetHeight(Node? node)
    {
        return node == null ? 0 : 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
    }
    
    private static Node RotateRight(Node node)
    {
        var newRoot = node.Left;
        
        node.Left = newRoot?.Right;
        
        if (newRoot == null) return node;
        
        newRoot.Right = node;
        
        return newRoot;
    }
    
    private static Node RotateLeft(Node node)
    {
        var newRoot = node.Right;
        
        node.Right = newRoot?.Left;
        
        if (newRoot == null) return node;
        
        newRoot.Left = node;
        
        return newRoot;
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