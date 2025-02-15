﻿namespace QuickDataStructures.QuickDataStructure;

public class QuickPushDataStructure<T> : QuickDataStructure<T> where T : IComparable<T>
{
    private Node<T>? _tail;

    public QuickPushDataStructure() : base()
    {
    }

    public override void Push(T value)
    {
        lock (_lock)
        {
            var newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;

                _length++;
                return;
            }

            _tail!.Next = newNode;
            _tail = newNode;
            _length++;
        }
    }

    public override T Pop()
    {
        lock (_lock)
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Pop operation cannot be performed, because the collection is empty");
            }

            var current = _head;
            T max = _head.Value;
            Node<T>? previous = null;
            Node<T>? maxPrevious = null;

            while (current != null)
            {
                if (current.Value.CompareTo(max) > 0)
                {
                    max = current.Value;
                    maxPrevious = previous;
                }

                previous = current;
                current = current.Next;
            }


            if (maxPrevious != null)
            {
                maxPrevious.Next = maxPrevious.Next!.Next;
            }
            else
            {
                _head = _head.Next;
            }

            _length--;

            return max;
        }
    }

    public override void Clear()
    {
        base.Clear();

        lock(_lock)
        {
            _tail = null;
        }
    }
}