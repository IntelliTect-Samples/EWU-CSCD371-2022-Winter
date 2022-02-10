﻿namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        private T Value { get; set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public override string? ToString()
        {
            if (Value == null) return null;
            return Value.ToString();
        }

        public void Append(T value)
        {
            if(Exists(value)) { throw new ArgumentException("The value already exists"); }

            Node<T> newNode = new(value);
            Node<T> currentNode = this.Next;

            while(currentNode.Next != this) { currentNode = currentNode.Next; }

            currentNode.Next = newNode;
            newNode.Next = this;
        }

        public void Clear()
        {
            // don't need to garbage collect as c# does so automatically
            Next = this;
        }

        public bool Exists(T value)
        {
            if(this.Value.Equals(value)) { return true; }

            Node<T> currentNode = this.Next;

            while(currentNode != this)
            {
                if(currentNode.Value.Equals(value)) { return true; }
                currentNode = currentNode.Next;
            }

            return false;
        }
    }
}