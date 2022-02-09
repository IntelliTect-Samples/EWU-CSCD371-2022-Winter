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

    public bool Exists(T data, Node<T> root)
    {
        Node<T> current = root;

        while (current.Next != current && current.Next != root)
        {
            if (new Node<T>(data).CompareTo(current) == 0)
            {
                return true;
            }
        }

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
