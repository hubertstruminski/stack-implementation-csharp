using Stack_implementation.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_implementation
{
    public class StosWLiscie<T> : IStos<T>
    {
        public class Node<S>
        {
            public Node<S> Next { get; set; }
            public S Data { get; set; }
        }

        public Node<T> Head;
        private int Szczyt = -1;

        public StosWLiscie()
        {
            Szczyt = -1;
            Head = null;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : this[Szczyt];

        public int Count => Szczyt + 1;

        public bool IsEmpty => Szczyt == -1;

        public T this[int index]
        {
            get
            {
                if (index > Count - 1 || index < 0)
                    throw new IndexOutOfRangeException();
                Node<T> currentNode = Head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Data;
            }
        }

        public void Push(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>();

                Head.Data = value;
                Head.Next = null;
            }
            else
            {
                Node<T> newNode = new Node<T>();
                newNode.Data = value;

                Node<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            Szczyt++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            Node<T> currentNode = Head;
            for (int i = 0; i < Szczyt - 1; i++)
                currentNode = currentNode.Next;

            Node<T> last = currentNode.Next;

            currentNode.Next = null;
            Szczyt--;

            return last.Data;
        }

        public void Clear()
        {
            Szczyt = -1;
            Head = null;
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
