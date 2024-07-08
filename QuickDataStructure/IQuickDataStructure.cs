namespace QuickDataStructures.QuickDataStructure;

public interface IQuickDataStructure<T>
{
    public void Push(T value);
    public T Pop();
    public string GetValues();
    void Print();
}
