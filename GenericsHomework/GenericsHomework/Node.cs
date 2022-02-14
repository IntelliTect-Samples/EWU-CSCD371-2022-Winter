namespace GenericsHomework
{
    public class Node<T>
    {
        public Node<T> Next { get; private set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Next = this;
            Value = value;
        }

        public bool SetNextNode(Node<T>? node)
        {
            bool success = false;
            if(node != null)
            {
                Next = node;
                success = true;
            }
            
            return success;
        }

        public Node<T> AppendNode(T value)
        {
            if (ValueExists(value))
            {
                throw new ArgumentException($"Cannot add duplicate {nameof(value)} to list");
            }
            Node<T> nextNode = new Node<T>(value);
            nextNode.Next = Next;
            Next = nextNode;

            return nextNode;
        }

        public void Clear() //No need to worry about garbage collection because each node will be self referencing.
        {
            bool endNode = false;
            Node<T> currentNode = this;
            Node<T> nextNode;
            do
            {
                nextNode = currentNode.Next;
                if (nextNode == this)
                {
                    SetNextNode(this);
                    endNode = true;
                }
                else
                {
                    currentNode = nextNode;
                    currentNode.Next = currentNode;
                }
            }
            while (!endNode);
           
        }

        public bool ValueExists(T value)
        {
            bool exists = false;
            bool endOfList = false;
            Node<T> currentNode = this;

            do
            {
                if (currentNode.Value?.Equals(value) == true)
                {
                    exists = true;  
                }
                else if(currentNode.Next == this)
                {
                    endOfList = true;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            } while (!endOfList || exists);

            return exists;

        }

        public override string ToString()
        {
            return Value?.ToString() ?? "";
        }
    }
}