using System.Text;

namespace QuickDataStructures.QuickDataStructure;

public abstract class QuickDataStructure<T> : IQuickDataStructure<T>
{
    public int Length { get; protected set; }
    protected Node<T>? _head;
    protected readonly object _lock;

    protected QuickDataStructure()
    {
        _lock = new();
    }

    public string GetValues()
    {
        lock (_lock)
        {
            var sb = new StringBuilder();

            var current = _head;
            while (current != null)
            {
                sb.Append(current.Value).Append(' ');

                current = current.Next;
            }

            return sb.ToString().Trim();
        }
    }

    public void Print()
    {
        lock (_lock)
        {
            var current = _head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    public abstract void Push(T value);
    public abstract T Pop();
}
