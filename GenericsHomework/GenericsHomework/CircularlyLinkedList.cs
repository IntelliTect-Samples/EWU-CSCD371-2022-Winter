using System.Diagnostics.CodeAnalysis;

namespace GenericsHomework;
public class CircularlyLinkedList<T>
{
    protected Node<T>? _Cursor { get; set; }

    public int Count { get; protected set; } = 0;

    public T this[int index]
    {
        get => ReturnDataAtIndex(index);
    }

    public string GetStringOfIndex(int index)
    {
        if (_Cursor is null) { throw new InvalidOperationException($"{nameof(GetStringOfIndex)} called when there were no nodes in the list"); }
        Node<T> origin = _Cursor;
        SetOrigin(index);
        string retString = _Cursor.ToString();
        _Cursor = origin;
        return retString;
    }

    //Summary :
    //Adds information from an array of type T to the linked list
    //Starts at the end of an array and "adds backwards"
    //The end result is the the information in the linked list has the same order as in the array
    //
    //data[0] will be stored in _Cursor if the linked list is empty,
    //or in _Cursor.next if the linked list has at least one node
    public void AddData(params T[] data)
    {
        if (_Cursor is null)
        {
            Insert(data[0]);
            for (int i = data.Length - 1; i > 0; i--)
            {
                if (data[i] is not null) Insert(data[i]);

                else Console.WriteLine($"{nameof(AddData)}: index{i} is null and was rejected");

            }
        }
        else
        {
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] is not null) Insert(data[i]);

                else Console.WriteLine($"{nameof(AddData)}: index{i} is null and was rejected");

            }
        }
    }


    private void Insert(T data)
    {
        if (data is null) throw new ArgumentNullException($"{nameof(Insert)} should never receive null");
        if (Exists(data)) throw new ArgumentException($"{data} exists in the circularly linked list");


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


    //Summary:
    //
    //Deletes all nodes but the one pointed to by Cursor
    //
    //This works because the garbage collector will trace the references in the root graph
    //Since only _Cursor populates the root graph, only the nodes accessible to _Cursor will remain uncollected by the GC
    //Meaning that only _Cursor remains uncollected. The nodes that originally existed in the linked list, not being accessible in the root graph
    //will all be garbage collected, even though one points to _Cursor
    public void Clear()
    {
        if (_Cursor is not null)
        {
            _Cursor.ClearFrom();
            Count = 1;
        }
    }

    //Summary:
    // Method used to move Cursor to a new index
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



    //Summary:
    //
    // Returns data from the node index steps away from the current selected node.
    //  Handles negative values on a "index step backwards" basis
    //  accessed by indexer
    protected T ReturnDataAtIndex(int index)
    {
        if (_Cursor is null) { throw new InvalidOperationException($"{nameof(ReturnDataAtIndex)} called when there were no nodes in the list"); }
        Node<T> origin = _Cursor;
        SetOrigin(index);
        T retVal = _Cursor.Data;
        _Cursor = origin;
        return retVal;
    }

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

        public void Append([DisallowNull] Tdata nodeData)
        {

            Node<Tdata> temp = Next;
            Node<Tdata> addedNode = new(nodeData) { Next = temp };
            Next = addedNode;
        }

        public void ClearFrom()
        {
            Next = this;
        }

    }
}