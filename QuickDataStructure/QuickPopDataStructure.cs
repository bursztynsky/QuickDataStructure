namespace QuickDataStructures.QuickDataStructure;

public class QuickPopDataStructure<T> : QuickDataStructure<T> where T : IComparable<T>
{
    public QuickPopDataStructure() : base()
    {
    }

    public override void Push(T value)
    {
        lock (_lock)
        {
            var newNode = new Node<T>(value);

            if (_head == null || value.CompareTo(_head.Value) > 0)
            {
                newNode.Next = _head;
                _head = newNode;

                return;
            }

            var current = _head;
            while (current.Next != null && current.Next.Value.CompareTo(value) > 0)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }

    public override T Pop()
    {
        lock (_lock)
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Pop operation cannot be performed because the collection is empty");
            }

            var result = _head.Value;
            _head = _head.Next;

            return result;
        }
    }
}