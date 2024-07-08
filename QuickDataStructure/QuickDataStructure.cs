using System.Text;

namespace QuickDataStructures.QuickDataStructure;

public abstract class QuickDataStructure<T> : IQuickDataStructure<T>
{
    protected int _length;
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

    public abstract void Push(T value);
    public abstract T Pop();

    public int Count()
    {
        lock (_lock)
        {
            return _length;
        }
    }

    public virtual void Clear()
    {
        lock (_lock)
        {
            _head = null;
            _length = 0;
        }
    }
}
