namespace han_adp_implementations.DataStructures.Trees;

public class BinaryTree<T> where T : IComparable<T>
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

    private static void Insert(Node? node, T item)
    {
        while (true)
        {
            if(node == null)
                return;
            
            switch (item.CompareTo(node.Value))
            {
                case < 0 when node.Left == null:
                    node.Left = new Node(item, null, null);
                    break;
                case < 0:
                    node = node.Left;
                    continue;
                case > 0 when node.Right == null:
                    node.Right = new Node(item, null, null);
                    break;
                case > 0:
                    node = node.Right;
                    continue;
                default:
                    node.Amount++;
                    break;
            }

            break;
        }
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
                if (node.Amount > 1)
                {
                    node.Amount--;
                    break;
                }
                
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;
                
                var min = FindMin(node.Right);
                node.Value = min.Value;
                node.Right = Remove(node.Right, min.Value);
                break;
        }

        return node;
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