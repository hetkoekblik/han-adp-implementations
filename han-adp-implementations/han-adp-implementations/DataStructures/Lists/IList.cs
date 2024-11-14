namespace han_adp_implementations.DataStructures.Lists;

public interface IList<T> : IDataStructure<T>
{
    public void Add(T item);
    public T Get(int index);
    public void Set(int index, T item);
    public void Remove(int index);
    public void Remove(T item);
    public bool Contains(T item);
    public int IndexOf(T item);
}