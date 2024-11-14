namespace han_adp_implementations.DataStructures;

public interface IList<T>
{
    public int Count();
    public void Add(T item);
    public T Get(int index);
    public void Set(int index, T item);
    public void Remove(int index);
    public void Remove(T item);
    public bool Contains(T item);
    public int IndexOf(T item);
}