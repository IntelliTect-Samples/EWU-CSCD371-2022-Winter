namespace GenericsHomework;

using System;
public class Node<T> : IComparable<Node<T>>
{
    private Node<T> _Next;
    public T? Data { get; private set; }

    public Node<T> Next
    {
        get { return _Next; }
        private set { _Next = value; }
    }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public override string ToString()
    {
        return Data?.ToString();
    }

    public void Append(T data) 
    {
        if (Exists(data))
        {
            throw new Exception("Duplicate value! Cannot append a value already in list.");
        }
        else
        {
            Node<T> nn = new(data);

            nn.Next = Next;
            Next = nn;
        }
    }

    public bool Exists(T data)
    {
        Node<T> current = this;
        do
        {
            if (current.Data is not null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
            }
            current = current.Next;
        } while (current != this);
        return false;
    }

    public void Clear()
    {
        Node<T> head = this;
        Node<T> current = this;

        while (current.Next != current && current.Next != head)
        {
            current = current.Next;
        }

        if (current.Next == current)
        {
            head.Next = head;
        }

        else
        {
            current.Next = current;
            head.Next = head;
        }

    }



    public int CompareTo(Node<T>? node)
    {
        return this.CompareTo(node);
    }




}
