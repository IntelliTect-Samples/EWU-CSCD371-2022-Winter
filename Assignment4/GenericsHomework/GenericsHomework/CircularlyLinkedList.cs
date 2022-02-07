using System.Diagnostics.CodeAnalysis;

namespace GenericsHomework;
public class CircularlyLinkedList<T>
{
    protected Node<T>? _Cursor { get; set; }

    public int Count { get; protected set; } = 0;

    protected class Node<Tdata>
    {
        public Node([DisallowNull] Tdata data)
        {
            Data = data;
            Next = this;
        }

        [DisallowNull]
        public Tdata Data { get; private set; }

        [NotNull]
        [DisallowNull]
        public Node<Tdata> Next { get; private set; }

        public override string ToString()
        {
            return Data?.ToString()!;
        }

        public void Append([DisallowNull] Tdata node)
        {

            Node<Tdata> temp = Next;
            Node<Tdata> newNode = new(node) { Next = temp };
            Next = newNode;
        }

        public void SetNext(Node<Tdata> next)
        {
            Next = next;
        }
    }

    public T this[int index]
    {
        get => ReturnDataAtIndex(index);
    }

    public string GetStringOfIndex(int index)
    {
        if (_Cursor is null) { throw new InvalidOperationException($"{nameof(GetStringOfIndex)}"); }
        Node<T> beg = _Cursor;
        SetOrigin(index);
        string newString = _Cursor.ToString();
        _Cursor = beg;
        return newString;
    }

    public void AddData(params T[] data)
    {
        if (_Cursor is null)
        {
            Insert(data[0]);
            for (int i = data.Length - 1; i > 0; i--)
            {
                if (data[i] is not null) Insert(data[i]);

                else Console.WriteLine($"{nameof(AddData)}: index{i}");

            }
        }
        else
        {
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] is not null) Insert(data[i]);
                else Console.WriteLine($"{nameof(AddData)}: index{i}");
            }
        }
    }

    private void Insert(T data)
    {
        if (data is null) throw new ArgumentNullException($"{nameof(Insert)}");
        if (Exists(data)) throw new ArgumentException($"{data}");
        if (_Cursor is null) _Cursor = new Node<T>(data);
        else _Cursor.Append(data);
        Count++;

    }

    public bool Exists([DisallowNull] T value)
    {
        if (_Cursor is not null)
        {
            Node<T> head = _Cursor;
            do
            {
                if (value.Equals(_Cursor.Data))
                    return true;
                StepForward();
            }
            while (_Cursor != head);
        }
        return false;
    }

    public void Clear()
    {
        if (_Cursor is not null)
        {
            _Cursor.SetNext(_Cursor);
            Count = 1;
        }
    }

    public void SetOrigin(int Index)
    {
        int distance = Index % Count;
        if (distance < 0) distance += Count;
        for (; distance != 0; distance--)
        {
            StepForward();
        }
    }

    protected void StepForward()
    {
        if (_Cursor is not null)
            _Cursor = _Cursor.Next;
    }

    protected T ReturnDataAtIndex(int index)
    {
        if (_Cursor is null) { throw new InvalidOperationException($"{nameof(ReturnDataAtIndex)}"); }
        Node<T> beg = _Cursor;
        SetOrigin(index);
        T val = _Cursor.Data;
        _Cursor = beg;
        return val;
    }
}