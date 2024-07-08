namespace QuickDataStructures.QuickDataStructure;

public interface IQuickDataStructure<T>
{
    void Push(T value);
    T Pop();
    string GetValues();
    int Count();
    void Clear(); 
}
