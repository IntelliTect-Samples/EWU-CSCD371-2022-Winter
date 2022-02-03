namespace GenericsHomework;
public class CircularlyLinkedList<T>
{
    public Node<T>? _Cursor { get; private set; }

    public int _Count { get; private set; } = 0;

    public void Append(T nodeData)
    {
        Node<T> addedNode = new(nodeData);

        //cases....
        //If there are no nodes
        //If there is 1 node
        //If there are 2 or more nodes

        _Count++;
    }









    public class Node<T>
    {
        public Node<T>(T data)=> _Data = data;

    
        public T _Data { get; private set; }

        [NotNull] [DisallowNull]
        public Node<T> _Next { get; private set; }

        public override string ToString()
        {
            return _Data?.ToString();
        }
    }

    


}


