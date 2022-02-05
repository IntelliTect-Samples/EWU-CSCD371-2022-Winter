using System.Diagnostics.CodeAnalysis;

namespace GenericsHomework;
public class CircularlyLinkedList<T>
{
    private Node<T>? _Cursor { get; set; }

    public int Count { get; private set; } = 0;

    public T this[int index]
    {
        get =>  ReturnDataAtIndex(index);
    }
    
    //Summary :
    //Adds information from an array of type T to the linked list
    //The array will have the appearance of being "loaded backwards," 
    //for example, an ascended array will be loaded as a descending array on traversal
    public void AddData(params T[] data)
    {
        for (int i = data.Length-1; i >= 0; i--)
        {
            if (data[i] is not null) Insert(data[i]);

            else Console.WriteLine($"{nameof(AddData)}: index{i} is null and was rejected");

        }
    }

    private void Insert(T data) { 
        if (data is null) throw new ArgumentNullException($"{nameof(Insert)} should never receive null");
    
        if (_Cursor is null) _Cursor = new Node<T>(data);
       
        else _Cursor.Append(data);
        
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
    // Deletes all nodes except the node who calls this method (referred to as _Cursor)
    //  Does this by traversing to the node behind the _Cursor, setting it's Next reference to be the node after _Cursor,
    //  setting _Cursor to it's original node, and then setting _Cursor's next to be a reference to itself.
    //
    // Since Next is a non-nullable property, the nodes to be deleted must reform a circular node formation.
    //  However, as there is no access to this circular node formation from a root (such as a variable or static member,)
    //  garbage collection will safely dispose of the circular node formation created in this function
    public void Clear()
    {
        if (_Cursor is not null)
        {

            Node<T> head = _Cursor!;

            while (_Cursor.Next != head)
            {
                StepForward();
            }

            _Cursor.SetNext(head.Next);
            _Cursor = head;
            _Cursor.SetNext(head);
            Count = 1;
        }
    }
    private void StepForward()
    {
        if (_Cursor is not null)
            _Cursor = _Cursor.Next;
    }


    private void StepTo(int Index)
    {
        int distance = Index % Count;

        if (distance < 0) distance += Count;

        for (; distance!= 0; distance--)
        {
            StepForward();
        }
    }

    //Summary:
    //
    // Returns data from the node index steps away from the current selected node.
    //  Handles negative values on a "index step backwards" basis
    //  accessed by indexer
    private T ReturnDataAtIndex(int index)
    {
        if (_Cursor is null) { throw new InvalidOperationException($"{nameof(ReturnDataAtIndex)} called when there were no nodes in the list"); }
        Node<T> origin = _Cursor;
        StepTo(index);
        T retVal = _Cursor.Data;
        _Cursor = origin;
        return retVal;
    }

    private class Node<Tdata>
    {
        public Node(Tdata data)
        {
            Data = data;
            Next = this;
        }

        public Tdata Data { get; private set; }

        [NotNull]
        [DisallowNull]
        public Node<Tdata> Next { get; private set; }

        public override string ToString()
        {
            return Data?.ToString()!;
        }

        public void Append([DisallowNull]Tdata nodeData)
        {
            Node<Tdata> temp = Next;
            Node<Tdata> addedNode = new(nodeData) { Next = temp };
            Next = addedNode;
        }

        public void SetNext(Node<Tdata> next)
        {
            Next = next;
        }



    }

}





