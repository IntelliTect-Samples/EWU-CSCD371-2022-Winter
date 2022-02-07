namespace GenericsHomework
{
    public class Node<TValue>
        where TValue : notnull
    {
        private TValue Value { get; set; }
        public Node<TValue> Next { get; private set; }

        public Node(TValue value)
        {
            Value = value;
            Next = this;
        }

        public void Clear()
        {
            this.Next = this;
        }//end of Clear method

        public void Append(TValue value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("Value exist in the list.");
            }
            else
            {
                Node <TValue> nn = new(value);
                Node<TValue> cur = Next;

                while(cur.Next != this)
                {
                    cur = cur.Next;
                }

                cur.Next = nn;
                nn.Next = this;

            }
        }//end of Append method

        public bool Exists(TValue value)
        {
            Node<TValue> head = this;
            Node<TValue> cur = Next;

            while(cur != head)
            {
                if (cur.Value.Equals(value))
                {
                    return true;
                }
                cur = cur.Next;
            }

            return false;

        }//end of Exists method

        public override string ToString()
        {
            if (Value == null)
                return null;
            return Value.ToString();
        }

    }//end of Node class
}
