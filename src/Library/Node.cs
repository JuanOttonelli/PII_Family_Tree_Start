using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Library
{
    public class Node
    {
        private int number;

        private List<Node> children = new List<Node>();

        public int Number {
            get
            {
                return this.number;
            }
        }

        public ReadOnlyCollection<Node> Children {
            get
            {
                return this.children.AsReadOnly();
            }
        }

        public Node(int number)
        {
            this.number = number;
        }

        public void AddChildren(Node n)
        {
            this.children.Add(n);
        }
        
        public class Person
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }

            public Person(string nombre, int edad)
            {
                Nombre = nombre;
                Edad = edad;
            }

            public override string ToString()
            {
                return $"{Nombre}, {Edad} años";
            }
        }

    }
}
