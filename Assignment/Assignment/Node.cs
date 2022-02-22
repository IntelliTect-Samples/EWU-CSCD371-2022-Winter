using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CircularLinkedList<T> : ICollection<T> where T : notnull
    {
        private class Node<T1>  
            where T1 : notnull
        {
            public T1 NodeData { get; set; }
            public Node<T1> Next { get; set; }

            public Node(T1 data)
            {
                NodeData = data;
                Next = this;
            }
        }


        private Node<T> Cursor { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;



        public CircularLinkedList(T value)
        {

            if (value is null)
                throw new ArgumentNullException();

            Cursor = new Node<T>(value);
            Count = 1;
        }

        public void Next()
        {

            Cursor = Cursor.Next;
        }
        public T GetData()
        {
            return Cursor.NodeData;
        }
        public CircularLinkedList<T> Append(T value)
        {

            Add(value);
            return this;
        }
        public bool Exists(T value)
        {
            return Contains(value);
        }

        public void Clear()
        {
            Cursor.Next = Cursor;
            Count = 1;
        }

        public override string ToString()
        {
            StringBuilder outputListAsString = new();
 
            Node<T> current = Cursor!;
            for (int i = 0; i < Count; i++)
            {
                if (outputListAsString.Length > 0 && i != Count)
                {
                    outputListAsString.Append("->");
                }
                outputListAsString.Append(current.NodeData.ToString());
                current = current.Next;
            }

            return outputListAsString.ToString();
        }

        public void Add(T item)
        {
            if (item is null)
                throw new ArgumentNullException($" {nameof(item)} was null");

            Node<T> current = Cursor;
            for (int i = 0; i < Count; i++)
            {
                if (current.NodeData.Equals(item))
                {
                    throw new ArgumentException($"NodeData with value {item} has a duplicate");
                }
                current = current.Next;
            }
            Count++;
            Node<T> temp = current.Next;
            current.Next = new(item);
            current.Next.Next = temp;
            Cursor = current.Next;
        }

        public bool Contains(T item)
        {
            if (item is null)
                return false;
            Node<T> current = Cursor;
            for (int i = 0; i < Count; i++)
            {
                if (current.NodeData.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException($" {nameof(array)} was null");
            }
            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException($"The array was not large enough for {Count} {arrayIndex}");
            }
            Node<T> current = Cursor;
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex++] = current.NodeData;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                return false;
            }
            Node<T> current = Cursor;
            int searched = 0;
            while (!current.Next.Equals(current) && searched++ < Count)
            {
                current = current.Next;
            }
            if (searched < Count)
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Cursor.NodeData;
                Cursor = Cursor.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}