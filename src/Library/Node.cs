using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Library
{
    public class Node<T>
    {
        public T Value { get; private set; }

        private List<Node<T>> children = new List<Node<T>>();

        public Node(T value)
        {
            Value = value;
        }

        public ReadOnlyCollection<Node<T>> Children {
            get
            {
                return this.children.AsReadOnly();
            }
        }
        

        public void AddChildren(Node<T> n)
        {
            
            this.children.Add(n);
            Console.WriteLine(children.Count);
        }
    }
}
