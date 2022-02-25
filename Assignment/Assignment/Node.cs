namespace Assignment;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Node<T> : IEnumerable<Node<T>>, IEnumerable
{
    //This is a direct copy from our Assignment-4 submission.
    //The required methods that we added for Assignment-5+6 are below

    private Node<T>? _Next;
    public T? Data { get; private set; }

    public Node<T> Next
    {
        get { return _Next!; }
        private set { _Next = value!; }
    }

    public Node(T data)
    {
        Data = data;
        Next = this!;
    }

    public override string ToString()
    {
        return Data?.ToString()!;
    }

    public void Append(T data)
    {
        if (Exists(data))
        {
            throw new Exception("Duplicate value! Cannot append a value already in list.");
        }
        else
        {
            Node<T> newNode = new(data);

            newNode.Next = Next;
            Next = newNode;
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

    //New methods for Assignment-5+6 below...
    public IEnumerator<Node<T>> GetEnumerator()
    {
            Node<T> curr = this;

            do
            {
                yield return curr!;
                curr = curr.Next;

            } while (curr != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerable<Node<T>> ChildItems(int maximum)
    {
        Node<T> curr = this;
        int count = 0;
      
        do
        {
            yield return curr!;
            curr = curr.Next;
            count++;
        } while (count > maximum);
    }

}