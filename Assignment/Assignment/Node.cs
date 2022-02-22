﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<TType> : IEnumerable<Node<TType>>, IEnumerable
{
    private readonly TType? _Value;
    public Node<TType> Next
    {
        get;
        private set;
    }

    public Node(TType value)
    {
        Next = this;
        _Value = value;
    }

    public override string? ToString()
    {
        if (_Value is null)
        {
            return null;
        }
        else
        {
            return _Value.ToString();
        }
    }

    public void Append(TType newValue)
    {
        if (this.Exists(newValue))
        {
            throw new InvalidOperationException($"The {nameof(newValue)} already exists in the list.");
        }
        Node<TType> newNode = new(newValue);
        newNode.Next = this.Next;
        this.Next = newNode;
    }

    public Node<TType> Clear()
    {
        /*
         *  Simply having this node loop back on itself will work.
         *  GC will see that the only node with any reference to it within the code
         *  base will be the main node that called the function.
         */
        this.Next = this;
        return this;
    }

    public bool Exists(TType valueToFind)
    {
        Node<TType> currentNode = this;
        do
        {
            if (currentNode._Value is null)
            {
                if (valueToFind is null)
                {
                    return true;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            else if (currentNode._Value.Equals(valueToFind))
            {
                return true;
            }
            else
            {
                currentNode = currentNode.Next;
            }

        } while (currentNode != this);

        return false;
    }

    public IEnumerator<Node<TType>> GetEnumerator()
    {
        Node<TType> currentNode = this;
        do
        {
            yield return currentNode;
            currentNode = currentNode.Next;
        } while (currentNode != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerable<Node<TType>> ChildItems(int maximum)
    {
        Node<TType> currentNode = this;
        int num = 0;
        do
        {
            yield return currentNode;
            currentNode = currentNode.Next;
            num++;
        }while(num < maximum);
    }
}
